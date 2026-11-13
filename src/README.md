# FreshFood Project Structure

Stakeholder decision 2026-11-02: ASP.NET Core C# backend. Approved use-case IDs and business behavior remain the basis.

| Project | Type | Responsibility |
|---|---|---|
| FreshFood-API | ASP.NET Core 10 C# Web API | Controllers, service contracts/implementations, DTOs, DI composition |
| FreshFood.Reposistory | .NET 10 C# class library | Entities, repository contracts/implementations, Npgsql transactions |
| FreshFood-API.Tests | .NET 10 xUnit | Unit, HTTP and disposable PostgreSQL integration tests |
| FreshFood-Customer-Web | React | Customer Pages / CallService |
| FreshFood-Web | React | Staff Pages / CallService |
| FreshFood-App | Flutter | Views / ViewModels / Models |
| FreshFood-DB | PostgreSQL SQL assets | Migrations and seeds |

Solution: `FreshFood.sln`. Build/run instructions and configuration limits: [API README](FreshFood-API/README.md). Former Node backend sources are historical evidence under `artifacts/implementation/baselines/nodejs-20261102/src/` and are outside the active solution.

## Test project layout

- Tests/Backend/FreshFood-API.Tests: existing backend regression and opt-in integration suite.
- Tests/Backend/FreshFood.Backend.UnitTests: class-organized backend unit suite.
- Tests/Frontend: frontend test projects, one subdirectory per project; currently reserved.
