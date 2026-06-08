 # Library App

 ## Description

 Library App is a small example .NET application that models a simple library system. It includes a core domain project with entities and services, a console application that provides a simple UI, an infrastructure project with JSON-based repositories, and unit tests that exercise business logic.

 ## Project Structure

- src/
  - Library.ApplicationCore/
    - Entities/
      - `Author.cs`
      - `Book.cs`
      - `BookItem.cs`
      - `Loan.cs`
      - `Patron.cs`
    - Enums/
      - `EnumHelper.cs`
      - `LoanExtensionStatus.cs`
      - `LoanReturnStatus.cs`
      - `MembershipRenewalStatus.cs`
    - Interfaces/
      - `ILoanRepository.cs`
      - `ILoanService.cs`
      - `IPatronRepository.cs`
      - `IPatronService.cs`
    - Services/
      - `LoanService.cs`
      - `PatronService.cs`
  - Library.Console/
    - `Program.cs`
    - `ConsoleApp.cs`
    - `ConsoleState.cs`
    - `CommonActions.cs`
    - `appSettings.json`
    - Json/
      - `Authors.json`
      - `Books.json`
      - `BookItems.json`
      - `Loans.json`
      - `Patrons.json`
  - Library.Infrastructure/
    - Data/
      - `JsonData.cs`
      - `JsonLoanRepository.cs`
      - `JsonPatronRepository.cs`
- tests/
  - UnitTests/
    - `LoanFactory.cs`
    - `PatronFactory.cs`
    - ApplicationCore/
      - LoanService/
        - `ExtendLoan.cs`
        - `ReturnLoan.cs`
      - PatronService/
        - `RenewMembership.cs`

## Key Classes and Interfaces

- `LoanService` — Implements loan-related business logic (extend/return loans, status updates).
- `PatronService` — Handles patron-related operations such as membership renewal.
- `ILoanRepository` / `IPatronRepository` — Abstract repository interfaces used by services to persist and retrieve domain objects.
- `ILoanService` / `IPatronService` — Service interfaces that define application-level operations for loans and patrons.
- `JsonLoanRepository` / `JsonPatronRepository` — Infrastructure implementations that read/write JSON files in the `Json` folder for persistence.
- `JsonData` — Helper for loading and saving JSON-backed data stores.
- `ConsoleApp`, `ConsoleState`, `CommonActions`, `Program` — Console UI and supporting types used to run the application interactively.
- Domain entities: `Author`, `Book`, `BookItem`, `Loan`, `Patron` — core models used across services and repositories.

## Usage

Build and run the console application from the repository root or from the `AccelerateDevGHCopilot` folder. Example commands:

```bash
cd "EX: Analyze and document code using GitHub Copilot/AccelerateDevGHCopilot"

# Create a solution (if you don't have one already) and add projects:
dotnet new sln -n AccelerateDevGHCopilot
dotnet sln AccelerateDevGHCopilot.sln add src/Library.ApplicationCore/Library.ApplicationCore.csproj \
  src/Library.Infrastructure/Library.Infrastructure.csproj src/Library.Console/Library.Console.csproj

# Restore, build and run the console app:
dotnet restore
dotnet build
dotnet run --project src/Library.Console/Library.Console.csproj

# Run unit tests (optional):
dotnet test tests/UnitTests/UnitTests.csproj
```

Notes:
- If you prefer opening the solution in an IDE (Visual Studio / VS Code), open the generated `AccelerateDevGHCopilot.sln` and build from the IDE.
- The JSON files under `Library.Console/Json` are sample data used by the `Json` repositories in the infrastructure project.

## License

This project is provided under the MIT License. See the `LICENSE` file for full terms, or replace with your preferred license.
