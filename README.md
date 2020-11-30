# Todo.Blazor (Estudo sobre SPA com Blazor)

Essa é uma aplicação contendo um esquema de CRUD genérico utilizando Blazor. <br>
Existem 2 entidades, uma de "Tarefas - Todo" e outra de "Categorias - Category".

### Rodando a API
Existe uma API fake para servir o front, foi feito com json-server rodando com node.
<br><br>
Para rodar a API, é necessário ter o Node instalado e rodar os seguintes comandos.

1. Após baixar o repositório, acesse a pasta api pelo terminal ou cmd.
2. Rode o comando "npm install"
3. Rode esse comando para gerar os dados fake "npm run generate".
4. Rode o comando "npm start" para iniciar a API.
5. Deixe o terminal rodando essa API e abra outro terminal para executar os passos do front (Caso esteja usando vs code).

<br>
### Rodando o front

É necessário ter o dotnet 5 instalado. https://dotnet.microsoft.com/download/dotnet/5.0 <br>
Se for rodar pelo VS code, abra a pasta do projeto e no terminal execute o comando "dotnet watch run" para rodar a aplicação.
Se for rodar pelo VS studio, basta abrir a solution e dar play.

<br>
Acesse pelo navegador a url, https://localhost:5001/login, e crie uma conta e faça o acesso para testar a aplicação. <br>
Ou acesse o arquivo db.json na pasta api e procure por algum e-mail e faça o acesso usando a senha 123456.

<br>


### Entendo o fluxo da aplicação

Procurei criar um esquema de cadastro genérico no Blazor.
Para isso, utilizei alguns conceitos de orientação a objetos e generics do C#.
<br>
Em resumo, existe os models, que são Category e Todo, que herdam de ModelBase. <br>
Para cada model, existe um service (CategoryService e TodoService), que implementa uma interface genérica IServiceBase<Tipo do Model>. <br>
Na tela de listagem, por exemplo, "Todo.Blazor\Pages\Todo\TodoList.razor", a listagem é feita por meio de um componente genérico de lista "BaseList". <br>
Onde passo como parâmetro o service e outros parâmetros para que funcione normalmente. <br>
Foi feita dessa forma para testar como o Blazor se comporta na questão de componentização e com ideia de maximizar o reaproveitamento de código. Com isso, com poucas linhas de código é possível criar uma tela de listagem de alguma entidade vindo da API.
