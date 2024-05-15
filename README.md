# SWT Stub API

The Stub API is a .NET service designed to simulate responses from different services within the IPAFFS domain.


## Running the Application

You can either run the application directly on your local machine or via Docker.

### Database

#### In memory

Setting the environment variable `ASPNETCORE_ENVIRONMENT` to `Development` will use an in-memory database.

#### SQL

Setting the environment variable `ASPNETCORE_ENVIRONMENT` to anything other than `Development` will use a SQL Database.

The app setting `ConnectionStrings__StubApiDatabase` will need set with a SQL Database connection string.

### Running via Docker

#### Prerequisites

If not already installed, you will need [Docker Desktop](https://www.docker.com/products/docker-desktop).

#### Steps

1. Open terminal and `cd` into the root of the repository
2. Run `docker-compose build`
3. Run `docker-compose up`

Following the completion of the steps above, the application should now be running on port `6000`.

### Running on Local Machine

#### Prerequisites

If not already installed, you will need:

- .NET 8 Runtime and SDK - [Microsofts .NET 8 Downloads](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

#### Steps

1. Open terminal and `cd` into the `src/STW.StubApi.Presentation` directory
2. Run `dotnet run`

Following the completion of the steps above, the application should now be running on the port specified in the console output.


## Licence

THIS INFORMATION IS LICENSED UNDER THE CONDITIONS OF THE OPEN GOVERNMENT LICENCE found at:

<http://www.nationalarchives.gov.uk/doc/open-government-licence/version/3>

The following attribution statement MUST be cited in your products and applications when using this information.

> Contains public sector information licensed under the Open Government licence v3

### About the licence

The Open Government Licence (OGL) was developed by the Controller of Her Majesty's Stationery Office (HMSO) to enable information providers in the public sector to license the use and re-use of their information under a common open licence.

It is designed to encourage use and re-use of information freely and flexibly, with only a few conditions.