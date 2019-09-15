Launchpad Challenge
===

## A simple service designed to retrieve launchpad data from the public SpaceX API

## Key Technologies & Assemblies Used
- Nunit and Nunit Test Adapter
- Microsoft.Extensions.Logging
- Microsoft.Extensions.Configuration

## Getting Started

You must have [Microsoft .NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) installed to run this project.

##### to fork project:
[Fork here](https://github.com/estorms/launchpad_challenge)

##### to clone project

```git clone https://github.com/estorms/launchpad_challenge.git```

##### then run the following terminal commands

```
dotnet restore
dotnet build
dotnet run
```

##### to view project
Navigate to [https://localhost:5001](https://localhost:5001) in your browser

## Future Improvements

- Further adherence to CQRS via introduction of [Mediatr](https://github.com/jbogard/MediatR.git)
- Exception-handing middleware
- Replacement of external API with SQL database

## Ideas For Refactoring

- Use GraphQL to facilitate single-use endpoints that retrieve data from external API's OR databases

- I
