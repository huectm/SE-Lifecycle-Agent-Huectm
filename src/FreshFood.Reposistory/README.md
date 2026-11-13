# FreshFood.Reposistory

.NET 10 C# class library: entities, repository interfaces, Npgsql implementations, exact VND policies and scoped unit of work. `Reposistory` is the approved component/project spelling.

The API references this library; this library does not reference API DTOs/controllers. SQL converts string BIGINT IDs to long parameters. NpgsqlDataSource is shared; PostgreSqlSession and UnitOfWork are scoped. Write operations require a transaction. SQL migrations remain in `../FreshFood-DB/migrations/`.
