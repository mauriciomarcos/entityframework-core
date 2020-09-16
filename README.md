# Entity Framework Core
Repositório contendo um overview com conceitos básico sobre o ORM Entity Framework Core, e foi criado com o objetivo de estudos sobre o framework.

O Entity Framework Core (ORM) possibilita aos desenvolvedores abstraírem totalmente a camada de acesso ao banco de dados, permitindo aos mesmos manipularem os dados persistidos em uma base de dados sem a necessidade de escrever nunhma instrução SQL em suas aplicações, possibilitando assim, total foco na complexidade nas regras de negócio do problema que a aplicação se propõem a resolver. Além disso, o Entitiy Framework Core disponibiliza uma única interface para se comunicar com qualquer banco de dados que disponham de um provider com o ORM e também reduz consideravelmente a quantidade de código escrito para manipulação de dados dentro da aplicação.

Mas o que possibilita essa abstração entre os diferentes tipos de banco de dados e sua aplicação? Pois bem, o Entity Framework Core necessita que a aplicação seja configurada (adicionada as dependências) com o provider do banco de dados que se deseja trabalhar sua aplicação. Os providers são bibliotecas que implementam o ADO.NET (ActiveX Data Object) e é através dele que, de fato, os comandos são executados na base de dados. 
O ADO.NET pode ser entendido como uma especificação que os bancos de dados, como: PostigreSQL, MySQL SQLite, Oracle, SQL Server dentre outros devem implementar, dando origem assim aos providres que acessam de fato os dados de uma base de dados. Dessa forma, pode-se concluir que o EF Core (Entity Framework Core) atua na camada mais alta de acesso aos dados, entre o ADO.NET e os providres que implementam os métodos de acesso aos dados.
Os Providres disponíveis para o Entity Framework Core podem ser verificados nesse link da documentação oficial da Microsoft: https://docs.microsoft.com/pt-br/ef/core/providers/?tabs=dotnet-core-cli


### Migrations
Para utilizar esse recurso, é necessário que seja incorporado ao seu projeto o pacote Microsoft.EntityFrameworkCore.Design. Esse pacote é responsável por prover um conjunto de métodos responsáveis para manipulação dos comandos de Migrations. Além do pacote supramencionado, para que possamos interagir com o EFCore, há a necessidade de adicionarmos o pacote Microsoft.EntityFrameworkCore.Tools. 

Com os pacotes devidamente instalados, ao executarmos o comando get-help EntityFramework no Package Manager Console, teremos o seguinte resultado:

                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

TOPIC
    about_EntityFrameworkCore

SHORT DESCRIPTION
    Provides information about the Entity Framework Core Package Manager Console Tools.

LONG DESCRIPTION
    This topic describes the Entity Framework Core Package Manager Console Tools. See https://docs.efproject.net for
    information on Entity Framework Core.

    The following Entity Framework Core commands are available.
        Cmdlet                      Description
        --------------------------  ---------------------------------------------------
        Add-Migration               Adds a new migration.
        Drop-Database               Drops the database.
        Get-DbContext               Gets information about a DbContext type.
        Remove-Migration            Removes the last migration.
        Scaffold-DbContext          Scaffolds a DbContext and entity types for a database.
        Script-DbContext            Generates a SQL script from the current DbContext. 
        Script-Migration            Generates a SQL script from migrations.
        Update-Database             Updates the database to a specified migration.

SEE ALSO
    Add-Migration
    Drop-Database
    Get-DbContext
    Remove-Migration
    Scaffold-DbContext
    Script-DbContext
    Script-Migration
    Update-Database
