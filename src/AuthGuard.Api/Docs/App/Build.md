## Build Project

There are two services in the Auth Guard solution.

Each service is dockerized. So you can build the project using the relevant dockerfiles.

For the api project responsible for Employee Management operations, use the following command;

```
docker build -t 'api' -f 'Dockerfile' .
```

For the IdentityServer4 project, which is responsible for the authentication operations, use the following command;

```
docker build -t 'identity-server' -f 'DockerfileIdentityServer' .
```