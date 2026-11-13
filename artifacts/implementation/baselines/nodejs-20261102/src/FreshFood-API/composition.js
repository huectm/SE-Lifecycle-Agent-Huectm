import { RegistrationMap } from './RegistrationMap.js';
import { ApiCompositionRoot } from './ApiCompositionRoot.js';
export function createRequestScope({connection,principal,transport}) {
 const scope=new RegistrationMap();scope.Bind('DatabaseConnection',()=>connection);scope.Bind('AuthenticatedPrincipal',()=>principal);scope.Bind('HttpTransport',()=>transport);
 new ApiCompositionRoot().ConfigureServices(scope);return scope;
}
