## Features

- [ASP.NET Core 3.0](http://www.dot.net/)
- [Entity Framework Core 3.0](https://docs.efproject.net/en/latest/)
- [Angular 8](https://angular.io/)
- [Angular CLI 8](https://cli.angular.io/)

## Pre-requisites

You may need:
1. [.Net core 3.0 SDK](https://www.microsoft.com/net/core#windows)
2. [Visual studio 2017](https://www.visualstudio.com/) or later version OR [VSCode](https://code.visualstudio.com/) with [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) extension
3. [NodeJs](https://nodejs.org/en/) (Latest LTS)

## Introduction
    The frontend is inside directory `ClientApp`
## Installation

1. Clone the repo:
    `git clone https://github.com/luotyzl/TodoList.git`
2. open project with VS and modify the database connection string in the `appsettings.json` file
    ```bash
  "ConnectionString": {
    "TodoListDb": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoList;Integrated Security=True"
  },
    ```
3. Run the following command in the Package Manager console:
    `PM> update-database`

## Debug
    Press Ctrl + F5 in VS