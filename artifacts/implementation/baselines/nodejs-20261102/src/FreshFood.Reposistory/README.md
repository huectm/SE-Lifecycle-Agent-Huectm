# FreshFood.Reposistory

Domain entities, exact VND policies, repository contracts and parameterized PostgreSQL repository implementations mapped from the approved design. Preserve this project name exactly.

Contracts live directly in Repository; implementations live in Repository/Implements. Entities and value objects live in Entities. UnitOfWork owns BEGIN/COMMIT/ROLLBACK; transition execution in a current transaction must not commit independently. Domain attributes marked private-set are exposed through read-only getters; internal EntityState helpers support domain operations and data mapping.

The deployment runtime supplies DatabaseConnection.QueryAsync on one dedicated physical PostgreSQL client per request. No PostgreSQL driver, schema migration, database instance or provider credentials have been silently created. SQL has not been executed against a real database in this increment. Durable event storage and customer audit persistence remain explicit 503 gaps pending the existing design TBDs. See the API README and implementation review for operational limits.
