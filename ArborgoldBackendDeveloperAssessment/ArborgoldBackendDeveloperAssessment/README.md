# How To Run Application
1. Navigate to the ArborgoldBackendDevelopersAssessment
2. Run command - dotnet run

# How To Run Tests
1. Navigate to Solutions folder
1. Run command - dotnet test

# Key Design Choices
I encapsulate the functions of the app into different service projects

-	AccountManagement.Service – Handles all work related to the account
-	FundTransfers.Service – Handles withdraws and charges taxes
-	Reporting.Service – Handles account reports
-	Security.Service – Handles authentication
-	ArborgoldBackendDeveloperAssessment – Orchestration of all these services for the Banking App
	
I made this design choice to highlight how in a full-fledged application these functionalities could be decoupled to have single responsibilities. 

Within each service project, I used a DDD approach to structure the code. The Domain folder contains the business logic, Infrastructure the connection to the database, and the Presentation as the interface with the service.

Each service follows SOLID principles, primarily to allow decoupling of code for ease of changing functionality in the future but coding for the present request.

I also implemented a few design patterns, like factories for object instantiation and repositories for database access. The repositories follow a rudimentary CQRS patter to segregate reading and writing to the database.

For unit testing I created a separate project to decouple the main service from its tests. The unit test use mocking to mimic test cases.

The entire project uses dependency injection.

## Things to note:

-Given my constraint on time many things could be further improved. 
-I only wrote unit tests for one service to highlight my approach to unit testing. But in a real-world application all functionalities should be unit tested. Including non-golden path scenarios.
-The database should have encrypted fields and not store plain text secrets.
-My approach of reporting could be improved to rely more on the database to do the heavy lifting and not just use in memory processing. 
-The Bank Application could use refactoring to make it more readable and less coupled. 
-Better and more robust error handling.
-Please feel free to ask my thoughts on how to approach the bonus problems.
