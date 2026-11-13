-- Guarded rollback for an unused amendment only. Never discard audit/idempotency history.
BEGIN;
LOCK TABLE checkout_idempotency, order_transition_events, audit_logs IN ACCESS EXCLUSIVE MODE;
DO $$ BEGIN
  IF EXISTS (SELECT 1 FROM checkout_idempotency)
     OR EXISTS (SELECT 1 FROM order_transition_events)
     OR EXISTS (SELECT 1 FROM audit_logs WHERE customer_id IS NOT NULL) THEN
    RAISE EXCEPTION 'Rollback refused: consistency/audit evidence exists; prepare an approved data-preserving recovery';
  END IF;
END $$;
ALTER TABLE audit_logs DROP COLUMN actor_type;
ALTER TABLE audit_logs DROP CONSTRAINT audit_logs_one_named_actor;
ALTER TABLE audit_logs DROP COLUMN customer_id;
DROP TABLE order_transition_events;
DROP TABLE checkout_idempotency;
COMMIT;
