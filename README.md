**WORK MANAGEMENT SYSTEM API**

A production-grade backend system built using .NET 8, following Clean Architecture principles.

## Features

- Task Management (Create, Get)
- Clean Architecture (Domain, Application, Infrastructure, API)
- Entity Framework Core with SQL Server
- Repository + Unit of Work pattern
- DTO-based API contracts
- Global Exception Handling Middleware
- Standardized API Response Wrapper
- Structured Logging with ILogger
- Health Check Endpoint

##  Architecture

- Domain Layer → Core business logic
- Application Layer → Use cases, DTOs, interfaces
- Infrastructure Layer → EF Core, repositories
- API Layer → Controllers

## Tech Stack

- .NET 8 Web API
- Entity Framework Core
- SQL Server
- Clean Architecture

## Key Engineering Decisions

- Avoided Generic Repository (domain-focused design)
- Used DTOs to decouple API and domain
- Implemented UnitOfWork for transaction consistency
- Centralized exception handling
