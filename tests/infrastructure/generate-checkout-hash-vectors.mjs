// Historical Node JSON.stringify compatibility vectors. No application runtime dependency.
import {createHash} from 'node:crypto';
import {writeFile} from 'node:fs/promises';
const references=['normal','A\u000b\u2028B','unicode-Đơn-hàng','emoji-🍏','quote-"\\\n'];
const rows=references.map(reference=>({Reference:reference,Hash:createHash('sha256').update(JSON.stringify({AddressId:'2',PaymentMethod:'Cod',CheckoutReference:reference})).digest('hex')}));
await writeFile('src/FreshFood-API.Tests/Fixtures/checkout-hash-vectors.json',JSON.stringify(rows,null,2)+'\n');
