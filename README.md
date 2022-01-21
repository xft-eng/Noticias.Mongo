- # Introdução

  A API de notícias é apenas uma arquitetura de consumo de dados em NoSQL com o MongoDB.


- # Acesso e Autenticação


  API sem autenticação

  

- 
  # Arquitetura da Aplicação


  A solução da API se baseia em projeto .NET 5.0

  Segue abaixo a lista dos principais pacotes/plugins que a API utiliza, todos instalados via NuGet:

  - **Swagger** - Responsável pela documentação *online* de uso e versionamento da API;
  - **FluentValidation** - Responsável pela validação do modelo de dados no back-end;
  - **AutoMapper** - Mapeamento entre objetos de diferentes camadas da aplicação.
  - **MongoDB.Bson** - Formato de serialização binária usado para armazenar documentos e fazer chamadas de procedimento remoto no *MongoDB*.

