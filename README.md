**Deployed links**

- [Web Application](https://consumptionweb.z6.web.core.windows.net)
- [REST API](https://electricity-consumption-server-as.azurewebsites.net)
- [GRCP Server](https://electricity-consumption-api-as.azurewebsites.net)

**Web Application**

The frontend application is a Single Page Application built using Angular. It is calling the deployed REST API to get the electricity usage information. It is following the structure of presentational components, containers and views. A service is used to get the data from the API.

**REST API**

API application is built using .NET 6 and follows the guidelines of the [Clean Architecture](https://github.com/ardalis/CleanArchitecture) pattern.

ElectricityConsumption.API project has the controllers, validators for the API requests and the health check service. It also has an Error Controller as a global error handler. Fluent Validation library is used to validate the incoming requests.

In the ElectricityConsumption.API.Core project, the shared services are implemented. For example, Protos and the service used to fetch data from the GRCP server. This project is acting as a client to get data from the GRCP server. The GRCP client is injected using dependency injection and client factory instead of creating a new client on the spot. It is using OpenAPI to document its API endpoints and the Logger to log information to Application Insights.

ElectricityConsumption.API.Infrastructure project act as the point to call the external GRC service and is registering the GRCP client and the handler to be used in the Core project. 

- Grpc.Net.Client and Grpc.Net.ClientFactory libraries are used to implement the GRCP client.
- Fluent Validation to validate requests.

**GRCP Server**

ElectricityConsumption.Server is the GRCP server. It implements the GRCP server in the Proto file.

ElectricityConsumption.Server.Core is the business logic project and implements the shared Proto file and the service interfaces. Since the implementation follows the repository pattern, it also has the interfaces for the repositories.

ElectricityConsumption.Server.Infrastructure project implements the infrastructure used by the project. It is using an SQLite database to store the data and is managed as code using EF Core. All the requests are paginated to improve the performance.

Since the initial data is provided using a CSV file, in the project startup, that CSV file is read and its content seeded into the SQLite database using the database Configuration service.

- gRPC for .NET library is used to implement the GRPC server. 
- EF Core and SQLite libraries are used to implement the database infrastructure. 

**Docker**

docker-compose up will build and run the application containers locally.

Docker compose links.

- [Web Application](http://localhost:8000)
- [REST API](http://localhost:8002)
- [GRCP Server](http://localhost:8001)

**Future Considerations**

Core libraries can be implemented as a nuget package and used in both projects without repeating the files.
