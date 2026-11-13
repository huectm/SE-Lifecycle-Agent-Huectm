import { createRequestScope } from './composition.js';
import { DatabaseConnection } from '../FreshFood.Reposistory/Repository/DatabaseConnection.js';
import { HttpTransport } from './Services/HttpTransport.js';
// Health-only default wiring. Replace these external protocols with real adapters.
export async function authenticate(){return {};}
export async function scopeFactory(principal){return createRequestScope({principal,connection:new DatabaseConnection(),transport:new HttpTransport()});}
