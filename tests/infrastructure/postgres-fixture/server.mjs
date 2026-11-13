import {PGlite} from '@electric-sql/pglite';
import {PGLiteSocketServer} from '@electric-sql/pglite-socket';
const db=await PGlite.create();
const server=new PGLiteSocketServer({db,port:55439,host:'127.0.0.1'});
await server.start();
console.log('READY: disposable test-only PostgreSQL protocol fixture 127.0.0.1:55439; single underlying connection');
process.on('SIGINT',async()=>{await server.stop();await db.close();process.exit(0);});
