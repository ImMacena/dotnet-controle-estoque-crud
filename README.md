# API de Controle de Estoque

Este projeto consiste em uma API para controle de estoque, desenvolvida com ASP.NET Core 8, utilizando o padrão de arquitetura Clean Architecture, com autenticação JWT, acesso a banco de dados SQL Server via Entity Framework, e testes unitários. O objetivo da API é gerenciar produtos, vendas e estoques de forma segura e escalável.

## Tecnologias Utilizadas

- **ASP.NET Core 8**: Framework para o desenvolvimento da API.
- **Entity Framework Core**: ORM para a persistência de dados no SQL Server.
- **JWT (JSON Web Tokens)**: Utilizado para autenticação e autorização de usuários.
- **SQL Server**: Banco de dados para armazenar as informações da aplicação.
- **XUnit**: Framework para a criação de testes unitários.
- **AutoMapper**: Para facilitar o mapeamento entre as entidades e DTOs.
- **Swagger**: Para documentação e teste das rotas da API.

## Funcionalidades da API

A API será capaz de:

- **Cadastrar e Gerenciar Produtos**: Inclusão, edição, exclusão e listagem de produtos no estoque.
- **Gerenciar Estoque**: Controle de quantidades disponíveis, alertas de estoque baixo.
- **Realizar Vendas**: Registrar vendas e atualizar o estoque automaticamente.
- **Autenticar Usuários**: Login, logout e controle de permissões por meio de JWT.
- **Testes Unitários**: Garantir o bom funcionamento das funcionalidades.

## Estrutura do Projeto (Clean Architecture)

- **Domain**: Contém as entidades principais da aplicação, como `Produto`, `Estoque`, `Venda`, `Usuario` e interfaces de repositório.
- **Application**: Implementa os casos de uso da aplicação, como `GerenciarProduto`, `RealizarVenda`, além de conter os DTOs.
- **Infrastructure**: Implementação dos repositórios, persistência de dados no SQL Server, autenticação JWT, e serviços de infraestrutura.
- **Presentation**: Camada de API (Controllers), responsável por expor as funcionalidades ao cliente via HTTP.
- **Tests**: Contém os testes unitários, focando nos casos de uso e serviços.

## Diagrama de Classes

```plaintext
┌───────────────────┐            ┌─────────────────────┐
│      Produto      │            │      Venda          │
├───────────────────┤            ├─────────────────────┤
│ + Id: int         │            │ + Id: int           │
│ + Nome: string    │◄───────────┤ + ProdutoId: int    │
│ + Preço: decimal  │            │ + Quantidade: int   │
│ + EstoqueId: int  │            │ + Data: DateTime    │
└───────────────────┘            └─────────────────────┘

        ▲
        │
        │
┌───────────────────┐
│     Estoque       │
├───────────────────┤
│ + Id: int         │
│ + ProdutoId: int  │
│ + Quantidade: int │
└───────────────────┘
```

## Endpoints da API

### Produtos

- `POST /api/produtos` – Cadastrar um novo produto
- `GET /api/produtos` – Listar todos os produtos
- `GET /api/produtos/{id}` – Obter detalhes de um produto específico
- `PUT /api/produtos/{id}` – Atualizar um produto existente
- `DELETE /api/produtos/{id}` – Remover um produto do sistema

### Estoque

- `POST /api/estoques/{produtoId}` – Adicionar estoque a um produto
- `GET /api/estoques/{produtoId}` – Verificar quantidade disponível de um produto

### Vendas

- `POST /api/vendas` – Registrar uma nova venda
- `GET /api/vendas` – Listar todas as vendas realizadas

### Autenticação

- `POST /api/auth/login` – Autenticar usuário e receber um token JWT
- `POST /api/auth/register` – Registrar um novo usuário

### Gerenciamento de Usuários

A API terá funcionalidades para gerenciar usuários, com autenticação JWT e controle de permissões. Apenas usuários autenticados poderão realizar operações de gerenciamento de produtos, estoque e vendas. Haverá dois tipos de perfis de usuário:

- **Administrador**: Tem acesso total ao sistema, podendo gerenciar produtos, vendas, estoques e usuários.
- **Usuário Comum**: Pode realizar apenas consultas, visualizar produtos e estoques.

### Fluxo de Autenticação

- **Registro**: Um novo usuário pode se registrar utilizando um e-mail e senha. O registro retorna um token JWT.
- **Login**: Usuários podem fazer login, recebendo um token JWT válido por um período de tempo (por exemplo, 1 hora).
- **Autorização**: Algumas rotas serão protegidas, exigindo um token JWT válido para serem acessadas. Apenas administradores poderão criar, editar e excluir produtos ou realizar vendas.

### Endpoints de Gerenciamento de Usuários

- `POST /api/auth/register` – Registrar um novo usuário (Administrador ou Comum)
- `POST /api/auth/login` – Fazer login e receber um token JWT
- `GET /api/users` – Listar todos os usuários (Apenas Administrador)
- `GET /api/users/{id}` – Detalhes de um usuário específico (Apenas Administrador)
- `PUT /api/users/{id}` – Atualizar um usuário (Apenas Administrador)
- `DELETE /api/users/{id}` – Excluir um usuário (Apenas Administrador)

### Exemplo de Registro de Usuário

Quando um novo usuário é registrado, ele recebe um token JWT, que pode ser usado nas requisições subsequentes.

**Request:**

```json
POST /api/auth/register
{
  "username": "admin",
  "password": "P@ssw0rd",
  "role": "Admin"
}
```

**Response:**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

O `role` define o tipo de usuário, podendo ser `"Admin"` para administradores ou `"User"` para usuários comuns.

### Proteção de Rotas

As rotas de criação, atualização e exclusão de produtos, estoques e vendas serão protegidas, acessíveis apenas para usuários autenticados com tokens JWT válidos e permissões adequadas.

## Configuração do Banco de Dados

Utilize o **Entity Framework Core** para aplicar as migrations e configurar o banco de dados SQL Server.

### Exemplo de Configuração no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ControleEstoqueDB;Trusted_Connection=True;"
}
```

### Comandos para aplicar Migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Autenticação JWT

A API utiliza JWT para autenticação dos usuários. Após fazer login, o usuário recebe um token JWT, que deve ser enviado no header das requisições protegidas.

### Exemplo de Header para autenticação JWT:

```
Authorization: Bearer <token>
```

## Testes Unitários

Os testes unitários são implementados utilizando o **XUnit** e cobrem os casos de uso principais da aplicação, como:

- Criação de Produtos
- Vendas
- Atualização de Estoque
- Autenticação

### Execução dos Testes:

```bash
dotnet test
```

## Como Executar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/usuario/api-controle-estoque.git
```

2. Acesse a pasta do projeto:

```bash
cd api-controle-estoque
```

3. Configure a string de conexão com o SQL Server no arquivo `appsettings.json`.

4. Execute as migrations para configurar o banco de dados:

```bash
dotnet ef database update
```

5. Inicie a aplicação:

```bash
dotnet run
```

6. Acesse a documentação da API no navegador utilizando Swagger:

```
http://localhost:5000/swagger
```
