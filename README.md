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
    
As Migrations provê uma forma eficaz de versionar o modelo de dados, podendo realizar um undo sempre que necessário no contexto do projeto. Comando para realizar uma Migration do modelo de domínio da aplicação mapeada com o Fluente API para uma base de dados: Add-Migration MigracaoInicialProjeto -c DataBaseContext, onde o parâmetro -c indica o nome da classe de contexto da aplicação e é útil quando há mais de uma contexto de banco de dados no mesmo projeto.
O controle das alterações e versionamento da estrutuda do modelo de dados são controlados pelos arquivos gerado a partir do comand Add-Migration
  1. 20200916200109_MigracaoInicialProjeto.cs => Contém o método Up() e Down() que são responsáveis por evoluir ou reverver uma migração
  2. 20200916200109_MigracaoInicialProjeto.Designer.cs => Possui os metadados da estrutuda de mapeamento das classes da aplicação no momento aplicação. É a versão atual.
  3. DataBaseContextModelSnapshot.cs => Esse aquivo é gerado apenas na primeira migração e nas migrações posteriores, o EFCore saberá quais instruções devem ser adicionadas    ou removidas no modelo de dados, mantendo a integridade do modelo. :tw-1f3c6:
  
  ### Exportando o script SQL gerado pela Migration para um arquivo
 Para exportar o script gerado a partir da migração executada, deve-se utilizar o comando Script-Migration -o c:\MigracaoInicialProjeto.sql, por intermédio do Package Manager Console, onde o parâmetro -o c:\MigracaoInicialProjeto.sql é o path e nome do arquivo .sql que conterá as instruções DDL para ser executada na base de dados de destino. Muito útil quando não se tem acesso ao servidor de banco de dados ao qual queremos realizar a migração. 
 
 Outra forma de realizar esse processo é executando o comando Script-Migration -o c:\MigracaoInicialProjeto.sql --idempotent, onde o parâmetro --idempotent ou simplesmente -i, gerará um script com algumas validações sobre a existencia ou não dos objetos criados pela migração. Dessa forma, o script gerado torna-se mais seguro e possibilita que o mesmo possa ser executado mais de uma vez na mesma base de dados sem acarretar nenhum problema.
 
 ### Aplicando as alterações da Migration
 Para aplicar as alterações realizadas pela migração diretamente pelo Package Manager Console, uma vez que se tenha acessoa ao servidor de banco de dados, basta executar o comando: Update-Database -v, onde o parâmetro -v fará com que o prompt do Package Manager Console apresente todos os comandos que estão sendo executados contra a base de dados de destino. 
 
 ### Considerações importantes sobre o Migration
 Quando realizamos uma alteração em uma classe de domínio, por exemplo adicionando uma nova propriedade como NomeCliente do tipo string, ao ser executado o comando Add-Migration e posteriormento o Update-Database, o EFCore criará esse novo campo na base de dados como o NomeCliente com os valores default, pois não houve qualquer configuração na classe de mapeamento (classe que implementa o IEntityTypeConfiguration<Cliente> - para o exemplo). Então é importante ter em mente que os ajustes finos da propriedade que está sendo alterado no modelo de domínio, também deverá ser configurada nas respectivas classes de mapeamento.
  
  Para reverter qualquer alteração realizada na base de dados, é utilizado o comando Update-Database <target-da-migração> -v, onde o target-da-migração é o nome da Migration que deseja-se posicionar a base de dados. Após isso, caso é recomendado realizar o comando Remove-Migration <nome-da-migrations-que-será-removida> para remover o arquivo correspondente a migration, evitando que em futuras migrações, essas atualizações não seja aplicadas na base de dados.
    
