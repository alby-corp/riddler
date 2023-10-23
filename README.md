# Assessment
## Objective
The objective of this assessment is to solidify the programming concepts covered during team-shared review sessions. 
The project consists of three parts: a minimal API, a console application and a shared model.

## Project Structure
1. **API Project:** This project should not be modified in any way. It is a minimal API application.
2. **Console Project:** The console project is written in a single class named _Program_ and requires improvement from the developer.
3. **Shared Projects:** Contains the models shared between **Console** and **API**. 

## API Usage
To simplify the use of the tool, a PowerShell script named _publish.api.ps1_ has been created. This script generates a folder named _dist.api_ containing the executable required to run the **API** locally.

## Assessment Focus
The entire assessment focuses on the **Console** project. During the assessment, specific changes will be requested in the project, each designed to reinforce a particular topic. The requested changes will provide an opportunity to demonstrate the skills and knowledge acquired during the team-shared review sessions.

The changes should follow a predefined commit flow, as indicated below:

1. Apply the Single Responsibility Principle of OOP: This change involves consolidating the creation of instances of business logic classes within the **Program** class. For example:
    ```csharp
    var reader = new Reader();
    var writer = new Writer();
    ```
2. Transform the **Console** model from anemic to a rich model without using records.
3. Implement the rich model using records.
4. Add an Inversion of Control (IoC) system.
5. Create [typed clients](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#how-to-use-typed-clients-with-ihttpclientfactory) using the appropriate extension method.
6. Apply the [options pattern](https://learn.microsoft.com/en-us/dotnet/core/extensions/options) using the appropriate extension method.
7. Make the code async when it is possible
8. During retrieve phase, use yield instead of materialized collection

These points are left open to allow the developer to fully express their creativity and competence in applying them.

Good job to everyone!