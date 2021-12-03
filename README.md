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

# Install (Optinal)

You will need to setup Couchbase Server for project to work. First install Docker and make sure it's working properly. ([See](https://www.docker.com/get-started)) If you already have installed on your pc;

```PowerShell
docker run -d --name db -p 8091-8096:8091-8096 -p 11210-11211:11210-11211 couchbase
```

After that you need to setup a cluster. You can check offical document ([here](https://docs.couchbase.com/server/current/install/getting-started-docker.html))

Go to Appcent.NetCoreCase/Appcent.WebApi/appsettings.json configure your connection settings. After your configuration, start the project and you should see SwaggerUI screen.

# Install From Docker Hub

You can get project from Docker Hub. Do the following steps;
Create a network for couchbasedb and for our app
```PowerShell
docker network create testnetwork
```

Run couchbasedb in your network
```PowerShell
docker run -d --name couchbasedb -p 8091-8096:8091-8096 -p 11210-11211:11210-11211 --network=testnetwork couchbase
```
Lets set up couchbasedb manually this time using "couchbase-cli"

Go to your docker containers and find container named 'couchbasedb' that we just created and open CLI. First we are going to create our cluster

```PowerShell
couchbase-cli cluster-init -c 127.0.0.1 \
--cluster-username Admin \
--cluster-password 123456 \
--services data,index,query \
--cluster-ramsize 512 \
--cluster-index-ramsize 256
```
Next we are going to create our bucket named `default`
```PowerShell
couchbase-cli bucket-create -c 127.0.0.1 --bucket=default --bucket-ramsize=200 --bucket-type=couchbase -u Admin -p 123456
```
Lastly we need to create a default index so n1ql can work.
```PowerShell
cd /opt/couchbase/bin
```
```PowerShell
cbq -u Admin -p 123456 -e "http://localhost:8091" --script="CREATE PRIMARY INDEX ON default"
```

Now you should see following screen.
![401](./doc/images/not-authorized.PNG)

Now get my project from docker hub app and run
```PowerShell
docker run --rm -p 8787:80 -e Couchbase:ConnectionString=couchbasedb --network=testnetwork aserefoglu/appcent:v1
```
:)

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

