# BookStore API Reqnroll Test Suite

## Introduction

This project is an automated API test suite for the [BookStore API](https://demoqa.com/swagger/#/BookStore), an open-source RESTful service for managing books and user accounts. The suite validates key API endpoints such as user creation, authorization, and book management, ensuring the API behaves as expected.

## BDD with Reqnroll

The project uses [Reqnroll](https://reqnroll.net/) (formerly SpecFlow) to implement Behavior-Driven Development (BDD) for .NET. BDD allows you to write human-readable feature files that describe application behavior in plain English, which are then mapped to automated test steps. This approach improves collaboration between developers, testers, and non-technical stakeholders.

- **Feature files** (`.feature`) describe scenarios in Gherkin syntax.
- **Step definitions** implement the logic for each scenario step.
- Tests are executed using the NUnit framework.

## Project Structure

```
BookStore-API-reqnroll/
│
├── BookStore-API-reqnroll.sln         # Solution file
├── BookStoreApiReqnrollTest.csproj    # Project file
├── Features/                          # BDD feature files (Gherkin)
│   ├── Account.feature
│   └── Calculator.feature
├── StepDefinitions/                   # Step definition classes
├── Models/                            # Data models for requests/responses
├── Helpers/                           # Test client, custom exceptions, utilities
├── Drivers/                           # (Reserved for driver code)
├── Support/                           # (Reserved for support code)
└── README.md
```

### Navigating the Project

1. **Clone the repository** and open the solution in Visual Studio or your preferred IDE.
2. **Feature files** are in the Features directory.
3. **Step definitions** are in the StepDefinitions directory.
4. **Test logic and API clients** are in the Helpers directory.
5. **Models** for request/response payloads are in the Models directory.

To run the tests:
- Restore NuGet packages.
- Build the solution.
- Run tests using the Test Explorer or `dotnet test`.

## Libraries Used

### RestSharp

- The [RestSharp](https://restsharp.dev/) library is used for making HTTP requests to the BookStore API.
- It simplifies sending requests, handling responses, and managing headers and payloads.

### JSON Serialization

- The project uses `System.Text.Json` for serializing and deserializing JSON data.
- Response data is mapped to C# models for type-safe access and validation.

### Exception Handling

- Custom exceptions are defined in CustomException.cs to handle API error responses.
- For example, unauthorized or not acceptable responses are deserialized and thrown as specific exceptions, making test failures more informative and easier to debug.

