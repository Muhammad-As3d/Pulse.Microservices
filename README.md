# Pulse Microservices

Pulse is a .NET 10 microservices solution for authentication, profiles, workouts,
nutrition, progress tracking, notifications, subscriptions, fitness calculations,
and smart coaching. YARP exposes the services through `ApiGateway`.

## Repository layout

```text
src/
  ApiGateway/
  AuthenticationService/
  FitnessCalculationService/
  NotificationService/
  NutritionService/
  ProgressTrackingService/
  SmartCoachService/
  SubscriptionService/
  UserProfileService/
  WorkoutService/
  Shared/BuildingBlocks/
tests/
  BuildingBlocks.Tests/
```

Services that contain business functionality follow a vertical-slice layout under
`Features`. Shared code is restricted to stable cross-cutting abstractions,
authentication setup, and integration-event contracts. Domain entities and
service-specific request/response contracts stay inside their owning service.

## Prerequisites

- .NET SDK 10.0.400 or a compatible patch selected by `global.json`
- Docker Desktop with Docker Compose v2

## Build and test

```powershell
dotnet restore Pulse.Microservices.slnx
dotnet build Pulse.Microservices.slnx --no-restore
dotnet test Pulse.Microservices.slnx --no-build
```

## Run with Docker Compose

Copy `.env.example` to `.env`, then replace every placeholder with a local secret.
The `.env` file is ignored by Git and must never be committed.

```powershell
Copy-Item .env.example .env
docker compose up --build
```

Main endpoints:

| Component | Host port |
| --- | ---: |
| API Gateway | 8080 |
| Authentication | 5001 |
| Workout | 5002 |
| User Profile | 5003 |
| Notification | 5004 |
| Progress Tracking | 5005 |
| Nutrition | 5006 |
| Fitness Calculation | 5007 |
| Subscription | 5008 |
| Smart Coach | 5009 |
| SQL Server | 1433 |
| RabbitMQ management | 15672 |

Compose passes container-specific connection strings using the service names
`sqlserver` and `rabbitmq`. SQL Server and RabbitMQ have health checks so dependent
services are not started before the infrastructure is ready.

## Configuration and secrets

Committed `appsettings.json` files contain only non-secret defaults. For local
non-container development, configure connection strings and JWT settings with
.NET User Secrets or environment variables:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<connection-string>" --project src/UserProfileService
dotnet user-secrets set "Jwt:Key" "<random-signing-key>" --project src/UserProfileService
```

Use the same JWT issuer, audience, and signing key across the authentication service
and APIs that validate its tokens. Production secrets should come from the target
platform's secret store, not source control or container image layers.

## Conventions

- Folders and namespaces use `Interfaces`, `Implementations`, and `UnitOfWork` casing.
- New business use cases go under `Features/<Area>/<UseCase>`.
- Database and broker integrations belong under infrastructure/persistence folders.
- Package-wide defaults and security pins live in `Directory.Build.props`.
- Every service owns its database schema and migrations.
