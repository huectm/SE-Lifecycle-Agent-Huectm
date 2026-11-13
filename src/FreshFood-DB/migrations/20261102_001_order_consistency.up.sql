-- Authorized storage amendment: UC-C06 / UC-C07, 2026-11-02.
-- Prerequisites: the existing customers, orders, staff_accounts and audit_logs schema.
-- Apply once through the deployment migration ledger. No production execution is implied.
BEGIN;
CREATE TABLE checkout_idempotency (
  customer_id BIGINT NOT NULL REFERENCES customers(customer_id),
  operation VARCHAR(32) NOT NULL CHECK (operation = 'PlaceOrder'),
  idempotency_key VARCHAR(128) NOT NULL CHECK (length(btrim(idempotency_key)) > 0),
  checkout_reference VARCHAR(128) NOT NULL CHECK (length(btrim(checkout_reference)) > 0),
  request_hash CHAR(64) NOT NULL CHECK (request_hash ~ '^[0-9a-f]{64}$'),
  order_id BIGINT REFERENCES orders(order_id),
  response JSONB,
  created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
  completed_at TIMESTAMPTZ,
  PRIMARY KEY (customer_id, operation, idempotency_key),
  UNIQUE (customer_id, operation, checkout_reference),
  CHECK ((response IS NULL AND order_id IS NULL AND completed_at IS NULL)
      OR (response IS NOT NULL AND order_id IS NOT NULL AND completed_at IS NOT NULL)),
  CHECK (response IS NULL OR jsonb_typeof(response) = 'object'),
  CHECK (response IS NULL OR COALESCE(jsonb_typeof(response->'OrderId') = 'string' AND response->>'OrderId' = order_id::text,FALSE))
);
CREATE TABLE order_transition_events (
  transition_event_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  aggregate_key VARCHAR(256) NOT NULL CHECK (length(btrim(aggregate_key)) > 0),
  event_id VARCHAR(128) NOT NULL CHECK (length(btrim(event_id)) > 0),
  transition_id VARCHAR(64) NOT NULL CHECK (length(btrim(transition_id)) > 0),
  order_id BIGINT REFERENCES orders(order_id),
  recorded_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
  UNIQUE (aggregate_key, event_id, transition_id)
);
CREATE INDEX order_transition_events_order_idx ON order_transition_events(order_id, recorded_at);
ALTER TABLE audit_logs ADD COLUMN customer_id BIGINT REFERENCES customers(customer_id);
ALTER TABLE audit_logs ADD CONSTRAINT audit_logs_one_named_actor
  CHECK (NOT (staff_id IS NOT NULL AND customer_id IS NOT NULL));
-- Existing automated entries with both actor IDs NULL remain valid SYSTEM entries.
ALTER TABLE audit_logs ADD COLUMN actor_type VARCHAR(16)
  GENERATED ALWAYS AS (CASE WHEN customer_id IS NOT NULL THEN 'CUSTOMER'
                           WHEN staff_id IS NOT NULL THEN 'STAFF' ELSE 'SYSTEM' END) STORED;
CREATE INDEX audit_logs_customer_idx ON audit_logs(customer_id, timestamp) WHERE customer_id IS NOT NULL;
COMMIT;
