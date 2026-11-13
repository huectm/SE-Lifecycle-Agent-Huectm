import { createApiServer } from './http.js';
// Trusted local runtime module owns authentication, connection pooling and provider credentials.
const file=process.env.FRESHFOOD_RUNTIME_MODULE??'./runtime.example.js';
if(!process.env.FRESHFOOD_RUNTIME_MODULE)console.warn('Using unconfigured runtime: /health is available; database/provider operations fail closed.');
const runtime=await import(file);const server=createApiServer(runtime);server.listen(Number(process.env.PORT??3000),process.env.HOST??'127.0.0.1');
