# Rainfall API

An API providing rainfall reading data using Clean Architecture and micro SaaS framework.

## Table of Contents

- [Rainfall API](#rainfall-api)
  - [Table of Contents](#table-of-contents)
  - [Description](#description)
  - [Installation](#installation)
  - [Usage](#usage)
  - [API Documentation](#api-documentation)
  - [Project Structure](#project-structure)
  - [Dependencies](#dependencies)

## Description

The Rainfall API is designed using Clean Architecture and follows the Micro SaaS framework. It provides endpoints for retrieving rainfall readings based on station ID. The project is structured to maintain separation of concerns and facilitate maintainability.

## Installation

To run the project locally, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/digitaljobsdev/RainfallApi.git
2. Navigate to the project directory:
    ```bash
    cd RainfallApi
3. Restore dependencies:
    ```bash
    dotnet restore
4. Build the solution:
    ```bash
    dotnet build
5. Run the application:
    ```bash
    dotnet run --project RainfallApi.Web
6. Run the Test
    ```bash
    dotnet run --project RainfallApi.Application.Test    

## Usage
The API provides endpoints for fetching rainfall readings based on station ID. You can access the API documentation to understand the available endpoints and their usage.

## API Documentation
The API documentation is generated using Swagger and can be accessed at http://localhost:3000/swagger.
(Swagger currently not working will update this soon)
## Project Structure
The project is organized into layers following Clean Architecture principles:

RainfallApi.Core: Contains the core entities and interfaces.
RainfallApi.Application: Implements application services and use cases.
RainfallApi.Infrastructure: Implements infrastructure concerns such as external API communication.
RainfallApi.Web: The web layer responsible for handling HTTP requests and presenting data.

## Dependencies
The project uses the following key dependencies:

ASP.NET Core 3.1
Entity Framework Core
Swashbuckle.AspNetCore for API documentation
Moq and xUnit for testing

**Side Note
The project was code in Visual Studio Code for MacOS. not tested in Windows Environment nore in Visual studio for windows.