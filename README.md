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

# Next Step

Now you need to create an account to use to project. Otherwise you will get 401 error.

![401](./doc/images/not-authorized.PNG)

Simply just go to register method and create an account.

![Register User](./doc/images/register-user.PNG)

You should get following response if nothing went wrong :)

![Register User Response](./doc/images/register-user-response.PNG)

Now go to authenticate method and login with your credentials.

![User Login](./doc/images/user-login.PNG)

You should get following response if nothing went wrong :)

![User Response](./doc/images/user-login-response.PNG)

Get the token from the response and authorize swagger now you should be good.

# Create Your First To-Do

![Task-1](./doc/images/create-task.PNG)
![Task-2](./doc/images/create-task-response.PNG)
![Task-3](./doc/images/getall-todolist-byuser.PNG)
![Task-4](./doc/images/getall-todo.PNG)

