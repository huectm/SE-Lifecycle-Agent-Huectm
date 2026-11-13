from pathlib import Path
import json
p=Path('src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.js');s=p.read_text();pos=s.rfind('}')
s=s[:pos]+'''  async ClaimCheckoutAsync(customerId, reference, key, requestHash, signal) {
    if (!this.session.active) throw new Error('Idempotency claim requires current transaction');
    const inserted = await rows(this.session, `INSERT INTO checkout_idempotency
      (customer_id, operation, idempotency_key, checkout_reference, request_hash)
      VALUES ($1, 'PlaceOrder', $2, $3, $4) ON CONFLICT DO NOTHING RETURNING idempotency_key`,
      [customerId, key, reference, requestHash], signal);
    const saved = await one(this.session, `SELECT * FROM checkout_idempotency
      WHERE customer_id=$1 AND operation='PlaceOrder' AND idempotency_key=$2 FOR UPDATE`, [customerId,key], signal);
    if (!saved) throw Object.assign(new Error('CHECKOUT_REFERENCE_REUSED'), {code:'CHECKOUT_REFERENCE_REUSED',status:409});
    if (saved.RequestHash !== requestHash || saved.CheckoutReference !== reference)
      throw Object.assign(new Error('IDEMPOTENCY_KEY_REUSED'), {code:'IDEMPOTENCY_KEY_REUSED',status:409});
    if (saved.Response != null) return { Replay:true, Response:saved.Response };
    if (!inserted.length) throw Object.assign(new Error('INCOMPLETE_IDEMPOTENCY_RECORD'), {code:'INCOMPLETE_IDEMPOTENCY_RECORD',status:503});
    return {Replay:false};
  }
  async CompleteCheckoutAsync(customerId, reference, key, response, signal) {
    if (!this.session.active) throw new Error('Idempotency completion requires current transaction');
    const updated = await rows(this.session, `UPDATE checkout_idempotency SET order_id=$1,response=$2::jsonb,completed_at=CURRENT_TIMESTAMP
      WHERE customer_id=$3 AND operation='PlaceOrder' AND idempotency_key=$4 AND checkout_reference=$5 AND response IS NULL
      RETURNING order_id`, [response.OrderId,JSON.stringify(response),customerId,key,reference], signal);
    if (updated.length !== 1) throw new Error('IDEMPOTENCY_COMPLETION_CONFLICT');
    await rows(this.session, `UPDATE order_transition_events SET order_id=$1
      WHERE aggregate_key=$2 AND event_id=$3 AND order_id IS NULL`, [response.OrderId,'checkout:'+customerId+':'+reference,key],signal);
  }
''' + s[pos:]
s=s.replace("WHERE customer_id=$1 AND address_id=$2',[customerId,addressId]", "WHERE customer_id=$1 AND address_id=$2'+lock(this.session),[customerId,addressId]")
p.write_text(s,encoding='utf-8')
p=Path('src/FreshFood.Reposistory/Repository/ICheckoutRepository.js');s=p.read_text();pos=s.rfind('}');s=s[:pos]+'''  async ClaimCheckoutAsync(customerId, reference, key, requestHash, signal) { throw new Error('Abstract storage amendment contract'); }
  async CompleteCheckoutAsync(customerId, reference, key, response, signal) { throw new Error('Abstract storage amendment contract'); }
'''+s[pos:];p.write_text(s,encoding='utf-8')
p=Path('src/FreshFood.Reposistory/Repository/Implements/OrderLifecycleRepository.js');s=p.read_text();s=s.replace("gap('DURABLE_TRANSITION_EVENT_STORAGE_TBD');",'''if (!this.session.active) throw new Error('Transition evidence requires current transaction');
    const orderId=/^[1-9][0-9]*$/.test(aggregateId)?aggregateId:null;
    return (await rows(this.session,`INSERT INTO order_transition_events(aggregate_key,event_id,transition_id,order_id)
      VALUES($1,$2,$3,$4) ON CONFLICT(aggregate_key,event_id,transition_id) DO NOTHING RETURNING transition_event_id`,
      [aggregateId,eventId,transitionId,orderId],signal)).length===1;''')
s=s.replace("gap('CUSTOMER_AUDIT_SCHEMA_TBD');",'''if (!this.session.active) throw new Error('Customer audit requires current transaction');
    if (!audit.ActorCustomerId || !audit.OrderId) throw new Error('Customer audit identity required');
    const result=await rows(this.session,`INSERT INTO audit_logs(staff_id,customer_id,action_type,entity_name,record_identifier,old_values,new_values)
      SELECT NULL,$1,'UPDATE','orders',order_id::text,$2::jsonb,$3::jsonb FROM orders WHERE order_id=$4 AND customer_id=$1 RETURNING log_id`,
      [audit.ActorCustomerId,JSON.stringify({order_status:audit.PreviousStatus}),JSON.stringify({order_status:'CANCELLED',cancellation_reason:audit.Reason}),audit.OrderId],signal);
    if(result.length!==1)throw Object.assign(new Error('AUDIT_ORDER_NOT_OWNED'),{code:'AUDIT_ORDER_NOT_OWNED',status:403});''')
p.write_text(s,encoding='utf-8')
p=Path('src/FreshFood-API/Services/Implements/CheckoutService.js');s=p.read_text().replace("import { randomUUID }", "import { randomUUID, createHash }")
a=s.index('    const p=await this.plan(request,signal);',s.index('  async PlaceOrderAsync'));b=s.index('      const allocation=await this.allocate',a)
s=s[:a]+'''    const requestHash=createHash('sha256').update(JSON.stringify({AddressId:request.AddressId,PaymentMethod:request.PaymentMethod,CheckoutReference:reference})).digest('hex');
    // Maps calls stay outside the transaction. A retry may replay even if its cart is now empty.
    let preparation, preparationError;
    try { preparation=await this.plan(request,signal); } catch(error) { preparationError=error; }
    const result=await this.unitOfWork.ExecuteAsync(async()=>{
      const claim=await this.checkoutRepository.ClaimCheckoutAsync(customerId,reference,eventId,requestHash,signal);
      if(claim.Replay)return {confirmation:claim.Response,replay:true};
      if(preparationError)throw preparationError;
      const p={...preparation,cart:await this.checkoutRepository.GetCheckoutCartAsync(customerId,signal)};
      requireValue(p.cart?.Items.length>0,'EMPTY_CART',422);
      const address=owned(await this.checkoutRepository.GetOwnedAddressAsync(customerId,request.AddressId,signal));
      for(const field of ['StreetAddress','Latitude','Longitude'])requireValue(address[field]===preparation.address[field],'CHECKOUT_ADDRESS_CHANGED',409);
''' + s[b:]
s=s.replace("PhoneConfirmationStatus:'NotRequired'", "PhoneConfirmationStatus:'NOT_CONTACTED'")
s=s.replace('AggregateId:reference,CheckoutReference:reference',"AggregateId:'checkout:'+customerId+':'+reference,CheckoutReference:reference")
s=s.replace('AggregateId:reference,EventId:eventId',"AggregateId:'checkout:'+customerId+':'+reference,EventId:eventId")
s=s.replace("      return {OrderId:order.OrderId,OrderNumber:order.OrderNumber,Status:order.OrderStatus,PaymentStatus:order.PaymentStatus,Total:order.TotalAmount};",'''      const confirmation={OrderId:order.OrderId,OrderNumber:order.OrderNumber,Status:order.OrderStatus,PaymentStatus:order.PaymentStatus,Total:order.TotalAmount};
      await this.checkoutRepository.CompleteCheckoutAsync(customerId,reference,eventId,confirmation,signal);
      return {confirmation,replay:false};''')
s=s.replace("    await publishAfterCommit(this.notificationGateway,{OrderId:result.OrderId,EventCode:'ORDER_ACCEPTED'},signal);return result;", "    if(!result.replay)await publishAfterCommit(this.notificationGateway,{OrderId:result.confirmation.OrderId,EventCode:'ORDER_ACCEPTED'},signal);return result.confirmation;")
p.write_text(s,encoding='utf-8')
p=Path('src/FreshFood-API/Services/Implements/MyOrdersService.js');s=p.read_text();a=s.index('    await this.unitOfWork.ExecuteAsync',s.index('  async CancelOrderAsync'));b=s.index('  async ReorderAsync',a)
s=s[:a]+'''    const applied=await this.unitOfWork.ExecuteAsync(async()=>{
      const o=owned(await this.myOrdersRepository.LockOwnedAsync(customerId,request.OrderId,signal));
      if(o.OrderStatus==='Cancelled')return false;
      const transitions={PendingUnpaid:'T08u',PendingPaid:'T08p',Confirmed:'T09'};
      requireValue(transitions[o.OrderStatus],'CANCELLATION_NOT_ALLOWED',409);
      const snapshot=trustedSnapshot({AggregateId:o.OrderId,CustomerId:customerId,FulfillmentState:o.OrderStatus,PaymentState:o.PaymentStatus,ActorId:customerId,GuardFacts:{}},{order:o});
      const effect=await this.transitionExecutor.ExecuteInCurrentTransactionAsync(snapshot,{TransitionId:transitions[o.OrderStatus],AggregateId:o.OrderId,EventId:'cancel:'+o.OrderId,Reason:reason},signal);
      return effect.Applied;
    },signal);
    if(applied)await publishAfterCommit(this.notificationGateway,{OrderId:request.OrderId,EventCode:'ORDER_CANCELLED'},signal);
    return {Success:true,MessageCode:applied?'ORDER_CANCELLED':'ORDER_ALREADY_CANCELLED'};
  }
''' + s[b:];p.write_text(s,encoding='utf-8')
p=Path('src/FreshFood-API/Services/Implements/TransitionHandler.js');s=p.read_text().replace("      c.order.OrderStatus='Cancelled';", "      const previousStatus=c.order.OrderStatus;\n      c.order.OrderStatus='Cancelled';").replace("ActionType:'Cancel',Reason:command.Reason", "ActionType:'UPDATE',PreviousStatus:previousStatus,Reason:command.Reason");p.write_text(s,encoding='utf-8')
# The two new operations are an explicit storage amendment, not a silent baseline rewrite.
p=Path('src/FreshFood-API/design-contracts.json');meta=json.loads(p.read_text());
for name in ['ICheckoutRepository','CheckoutRepository']:
 for op in ['ClaimCheckoutAsync','CompleteCheckoutAsync']:
  if op not in meta[name]['operations']:meta[name]['operations'].append(op)
 meta[name]['amendment']='2026-11-02 storage amendment; design review pending'
p.write_text(json.dumps(meta,indent=2),encoding='utf-8')
print('Implemented durable claims/replay, event uniqueness, customer audit and repeat-safe cancellation')
