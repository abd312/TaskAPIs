# This task created by Abdullah Okkeh (Task Management System API .NET 8

A simple Task/User management API with role-based access control.

## Tech
- .NET 8
- EF Core InMemory
- Swagger/OpenAPI
- xUnit, FluentAssertions, Moq

## Getting Started
1. Prerequisites: .NET 8 SDK
2. Restore: `dotnet restore`
3. Run API: `dotnet run --project Genovation.TaskApi`
4. Open Swagger: http://localhost:5xxx/swagger

## Auth Model (for assessment)
Set the following HTTP headers in each request:
- `X-User-Id`: GUID of the acting user
- `X-User-Role`: `Admin` or `User`

Seeded users:
- Admin: `<id-guid-here>`
- User:  `<id-guid-here>`

## Endpoints
### Users (Admin only)
- `POST /api/users`
- `GET /api/users/{id}`
- `GET /api/users`
- `PUT /api/users/{id}`
- `DELETE /api/users/{id}`

### Tasks
- `POST /api/tasks` (Admin only)
- `GET /api/tasks/{id}` (Admin or assigned user)
- `GET /api/tasks` (Admin only)
- `PUT /api/tasks/{id}` (Admin full; User only Status on own tasks)
- `DELETE /api/tasks/{id}` (Admin only)

## Testing
- Run: `dotnet test`
- Includes service and controller tests for key RBAC rules.

## Architecture
- Domain, Infrastructure, Application, Web folders within one project.
- Repository + Service pattern.
- Middleware extracts current user from headers.

## Seeding
On startup, the app seeds:
- 2 users (Admin, User)
- 3+ tasks (at least one assigned to the User)

## Notes
- InMemory DB is for demo/testing only; data resets on restart.
