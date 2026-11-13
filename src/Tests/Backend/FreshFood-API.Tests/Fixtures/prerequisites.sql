-- Minimal integration fixture reflecting the required approved catalog columns.
-- Not a replacement for the full project schema or a production bootstrap migration.
CREATE TABLE customers(customer_id BIGINT PRIMARY KEY,full_name TEXT);
CREATE TABLE staff_accounts(staff_id INT PRIMARY KEY);
CREATE TABLE customer_addresses(address_id BIGINT PRIMARY KEY,customer_id BIGINT NOT NULL REFERENCES customers,recipient_name TEXT,recipient_phone TEXT,street_address TEXT,latitude NUMERIC,longitude NUMERIC,is_default BOOLEAN DEFAULT FALSE);
CREATE TABLE products(product_id BIGINT PRIMARY KEY,product_name TEXT,unit_of_measure TEXT,is_active BOOLEAN NOT NULL DEFAULT TRUE);
CREATE TABLE batch_inventory(batch_id BIGINT PRIMARY KEY,product_id BIGINT REFERENCES products,expiry_date DATE NOT NULL,current_stock INT NOT NULL,reserved_stock INT NOT NULL DEFAULT 0,retail_price NUMERIC(18,0) NOT NULL,discount_rate NUMERIC(5,2) NOT NULL DEFAULT 0,sale_status TEXT NOT NULL DEFAULT 'ACTIVE',CHECK(reserved_stock>=0 AND current_stock>=reserved_stock));
CREATE TABLE carts(cart_id BIGSERIAL PRIMARY KEY,customer_id BIGINT REFERENCES customers,session_id TEXT,created_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,updated_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP);
CREATE UNIQUE INDEX fixture_customer_cart ON carts(customer_id) WHERE customer_id IS NOT NULL;
CREATE TABLE cart_items(cart_item_id BIGSERIAL PRIMARY KEY,cart_id BIGINT REFERENCES carts,product_id BIGINT REFERENCES products,quantity INT NOT NULL CHECK(quantity>0),added_at TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,UNIQUE(cart_id,product_id));
CREATE TABLE orders(order_id BIGSERIAL PRIMARY KEY,order_number TEXT UNIQUE NOT NULL,customer_id BIGINT NOT NULL REFERENCES customers,delivery_address_id BIGINT NOT NULL REFERENCES customer_addresses,order_date TIMESTAMPTZ NOT NULL,sub_total NUMERIC(18,0) NOT NULL,delivery_distance NUMERIC(5,2) NOT NULL,shipping_fee NUMERIC(18,0) NOT NULL,total_amount NUMERIC(18,0) NOT NULL,payment_method TEXT NOT NULL CHECK(payment_method IN ('COD','VIETQR')),payment_status TEXT NOT NULL CHECK(payment_status IN ('UNPAID','PAID','PARTIALLY_REFUNDED','REFUNDED')),order_status TEXT NOT NULL CHECK(order_status IN ('PENDING_UNPAID','PENDING_PAID','CONFIRMED','PACKING','SHIPPING','DELIVERED','CANCELLED','DELIVERY_FAILED','RETURNED')),is_first_order BOOLEAN NOT NULL,phone_confirmation_status TEXT NOT NULL CHECK(phone_confirmation_status IN ('NOT_CONTACTED','CONFIRMED','UNCONFIRMED')),cancellation_reason TEXT);
CREATE TABLE order_details(order_detail_id BIGSERIAL PRIMARY KEY,order_id BIGINT NOT NULL REFERENCES orders,batch_id BIGINT NOT NULL REFERENCES batch_inventory,quantity INT NOT NULL CHECK(quantity>0),unit_price NUMERIC(18,0),discount_amount NUMERIC(18,0),line_total NUMERIC(18,0));
CREATE TABLE audit_logs(log_id BIGSERIAL PRIMARY KEY,staff_id INT REFERENCES staff_accounts,action_type TEXT NOT NULL CHECK(action_type IN ('INSERT','UPDATE','DELETE','LOGIN','REVOKE')),entity_name TEXT NOT NULL,record_identifier TEXT NOT NULL,old_values JSONB,new_values JSONB,ip_address VARCHAR(45),timestamp TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP);
INSERT INTO customers VALUES(7,'Test customer'),(8,'Other test customer');
INSERT INTO staff_accounts VALUES(1);
INSERT INTO customer_addresses VALUES(2,7,'Tester','0901234567','Test street',10,106,TRUE),(3,8,'Other','0901234568','Other test street',10,106,TRUE);
INSERT INTO products VALUES(1,'Organic greens','pack',TRUE);
INSERT INTO batch_inventory VALUES(1,1,'2099-01-01',10,0,10000,0,'ACTIVE');
INSERT INTO carts(customer_id) VALUES(7),(8);
INSERT INTO cart_items(cart_id,product_id,quantity) SELECT cart_id,1,3 FROM carts;
INSERT INTO audit_logs(staff_id,action_type,entity_name,record_identifier) VALUES(1,'UPDATE','orders','legacy-staff'),(NULL,'UPDATE','orders','legacy-system');
