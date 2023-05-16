<h1 align="center">CQRS no .NET 7.0</h1>

<p align="center">Uma exemplo de API REST que implementa o padrão CQRS e os princípios SOLID através de um CRUD de usuários.</p>

### 🛠 Tecnologias

- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [SQL Server](https://www.quartz-scheduler.net/)

### 📝 Requisitos

É necessário ter o  [NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) e o [Docker](https://www.docker.com/). 


### 🧐 Como Usar

Após o clone do repositório, podemos ir no diretório [/src](https://github.com/bcaua321/dotnetcore-api-cqrs-sample/tree/main/src) e rodar o seguinte comando:


```bash
$ cd src
$ docker compose build
$ docker compose up
```

### 🔭 Sobre o projeto

A organização geral foi feita através da divisão em subprojetos:

<ul>
    <li><strong>ApiCQRS.Core</strong>: Onde é definido o contexto de usuário, através da definição de entidades e a abstração de acesso a dados.</li>
    <li><strong>ApiCQRS.Infrastructure</strong>: Onde é realizado a implementação da definição feita em ApiCQRS.Core, através da criação e definição de acesso aos dados.</li>
    <li><strong>ApiCQRS.Application</strong>: Definição de Commands e Queries.</li>
</ul>

#### 🚩 Observação 
<p>Tive alguns desafios na hora de realizar a Injenção de Dependência para o <a src="https://github.com/jbogard/MediatR">MediatR 12.0.1</a> no .NET 7.0, no entando consegui resolver referenciando o 
  Assembly de forma "manual", como pode ser visto em ConfigureServices no arquivo <a href="https://github.com/bcaua321/dotnetcore-api-cqrs-sample/blob/main/src/ApiCQRS.Api/Startup.cs">Startup</a>.</p>
