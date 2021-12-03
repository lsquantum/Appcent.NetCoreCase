# Appcent.NetCoreCase

 ToDoList using 'Clean Architecture Principles' and CQRS

Technology Stack:
- .NET Core
- Couchbase
- Swagger
- Docker
- Nunit and Moq
- Automapper
- FluentValidation
- MediatR
- JWT

# Project Structure

![Project Structure](./doc/images/project_layers.PNG)

# Install

You will need to setup Couchbase Server for project to work. First install Docker and make sure it's working properly. ([See](https://www.docker.com/get-started)) If you already have installed on your pc;

```PowerShell
docker run -d --name db -p 8091-8096:8091-8096 -p 11210-11211:11210-11211 couchbase
```

After that you need to setup a cluster. You can check offical document ([here](https://docs.couchbase.com/server/current/install/getting-started-docker.html))

Go to Appcent.NetCoreCase/Appcent.WebApi/appsettings.json configure your connection settings. After your configuration, start the project and you should see SwaggerUI screen.
