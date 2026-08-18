Live demo: katuwang.runasp.net

# Katuwang

Katuwang is an ASP.NET Core MVC membership and operations management application. It centralizes member records, household groupings, duty assignments, transfers, dashboards, authentication, and PDF reporting in one system.

## Features

- Secure sign-in and registration with ASP.NET Core Identity
- Member masterlist with create, view, update, soft-delete, and profile-image workflows
- Household and relationship organization
- Duty and assignment management
- Incoming and outgoing transfer tracking
- Dashboard summaries and address-directory information
- SQL Server persistence through Entity Framework Core
- Stored-procedure-backed dashboard queries
- Crystal Reports PDF generation

## Technology

- ASP.NET Core MVC and Razor Pages
- .NET 6
- Entity Framework Core 6
- ASP.NET Core Identity
- Microsoft SQL Server
- Bootstrap and the NiceAdmin interface template
- SAP Crystal Reports

## Local development

### Prerequisites

- Visual Studio 2022 or the .NET 6 SDK
- SQL Server LocalDB or another SQL Server instance
- Entity Framework Core command-line tools
- SAP Crystal Reports runtime for the reporting feature

The committed connection strings use SQL Server LocalDB and contain no credentials. For another SQL Server instance, set both connection strings through .NET user secrets or environment variables instead of committing passwords.

```powershell
dotnet user-secrets set "ConnectionStrings:AuthDBContextConnection" "YOUR_CONNECTION_STRING"
dotnet user-secrets set "ConnectionStrings:KatuwangContextConnection" "YOUR_CONNECTION_STRING"
```

Restore the tools and create the Entity Framework databases:

```powershell
dotnet tool restore
dotnet restore
dotnet ef database update --context AuthDBContext
dotnet ef database update --context KatuwangContext
dotnet run
```

The dashboard also calls SQL Server stored procedures such as `sp_Dashboard_SerialNumber`, `sp_Dashboard_AddressDirectory`, `sp_Dashboard_Sambahayan`, and `sp_Dashboard_BirthdayCelebrants`. Their deployment scripts will be added as part of the database portability work.

## Configuration and security

- No passwords, tokens, database backups, or production data are stored in this repository.
- Production connection strings belong in the hosting platform's secure configuration.
- Use fictional records when demonstrating the application publicly.

## Project status

This repository is a portfolio restoration of an existing application. The current work focuses on reproducible database setup, automated builds, tests, and restoring the Azure-hosted demonstration.

## Interface credit

The interface uses the [NiceAdmin](https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/) template by BootstrapMade. Its original attribution is preserved in the application source.
