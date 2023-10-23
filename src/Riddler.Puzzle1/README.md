# Puzzle 1

## Background

We entrusted a 16-year-old, the son of one of our employees, with the task of developing a basic console application. Unfortunately, the outcome did not meet our expectations. Consequently, we have decided to reach out to you to request improvements to the code.

## Functional Analysis

The project's objective is to create an interactive interface through a console to facilitate user interaction. The initial request will be to specify the path to a folder containing input files.
After providing this path, the user will be prompted to specify the name of the file containing the **txt** input file. This file will contain information about the **names** and **surnames** of different individuals, separated by a **semicolon**.
Currently, no immediate changes are anticipated regarding the file extension or the separator used; however, the possibility of future modifications to the file format or separator choice is acknowledged.

Regarding the program's functionality:

1. the code will handle reading the file's content to extract the names and surnames contained within.
2. subsequently, the program will utilize an API to retrieve the user's email, providing the name and surname extracted from the file as query string parameters.
3. once the necessary data is obtained, the program will write a new file named output_{yyyy-MM-dd hh-mm-ss}, in txt format, containing an informative message for each user with a registered email on the API:
   _Ciao {name} {surname}, this is your email: {email}_

Upon completion of these operations, the user will receive a completion notification through the message **Done**. Importantly, if no user in the input file has a registered email, the program will refrain from producing an output file, and a specific message will be conveyed: **No users found!**.

## Technical Analysis

We have previously sought the expertise of an external consultant to assess the quality of our current code and provide crucial insights for enhancing its maintainability and extensibility. Below, we outline the critical points that have been identified and that we intend to address:

1. **Application of the Single Responsibility Principle (S in SOLID) in Object-Oriented Programming (OOP):** Currently, our code could benefit from dividing responsibilities within classes, adhering to the principle that each class should have only one reason to change.

2. **Transformation of the Puzzle1 Model from Anemic to Rich, without Using Records:** The approach involves enriching the console model, aiming to avoid the creation of classes with mutable data and instead focusing on immutable models, thereby improving state management.

3. **Implementation of the Model using Records:** The use of records, as immutable data types, can help simplify state management and enhance code clarity and readability.

4. **Addition of an Inversion of Control (IoC) System:** Introducing an IoC mechanism can make our system more flexible and easily extendable, allowing for more effective dependency management.

5. **Creation of [Typed Clients](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#how-to-use-typed-clients-with-ihttpclientfactory):** Adopting typed clients can enhance code safety and facilitate maintenance, ensuring that API calls are handled robustly.

6. **Application of the [Options Pattern](https://learn.microsoft.com/en-us/dotnet/core/extensions/options):** Implementing the options pattern can streamline our code configuration and provide greater flexibility in settings.

7. **Making the Code Asynchronous Where Possible:** Utilizing asynchronous operations can improve the responsiveness of our system, enabling better handling of time-consuming operations.

8. **Using Yield Instead of Materialized Collection during the Retrieval Phase:** Changing the approach to the retrieval phase by favoring the use of yield instead of materialized collection can enhance efficiency in managing large datasets.

9. **Adoption of the [Worker Service](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers?pivots=dotnet-8-0):** Implementing the worker service template can contribute to improving system efficiency, allowing for more efficient management.

The goal is to address each of these points to optimize our code, making it more robust, maintainable, and extensible over time.

## Code Review

Upon completion of the work, the produced code will undergo a review by our external expert specialized in code quality. To facilitate their analysis, separate commits are requested for each point previously listed in the technical analysis.

Additionally, upload the code to our repository via a pull request.

The external consultant will evaluate each commit, assigning a specific score. The code will be deemed acceptable if it achieves or surpasses a total score of 20 points out of a maximum of 30. Otherwise, the work will be considered unsatisfactory, leading to the non-acceptance of the code and, consequently, the withholding of payment for the work performed.

| Commit   | Score |
|----------|-------|
| Commit 1 | 6     |
| Commit 2 | 2     |
| Commit 3 | 1     |
| Commit 4 | 3     |
| Commit 5 | 3     |
| Commit 6 | 4     |
| Commit 7 | 2     |
| Commit 8 | 3     |
| Commit 9 | 6     |

## Conclusions

We wish you a fruitful work, and with confidence in your skills, we eagerly await the moment when you can share with us the outcome of your work.