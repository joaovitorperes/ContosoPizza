# 🍕 Contoso Pizza

Sistema de gerenciamento de pizzas desenvolvido com ASP.NET Core Web API, Blazor Server e PostgreSQL.

---

## 🚀 Tecnologias Utilizadas

### Backend

- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- Role-Based Authorization
- Repository Pattern
- Swagger

### Frontend

- Blazor Server
- Bootstrap

### Banco de Dados

- PostgreSQL

---

## 🏗️ Arquitetura

```text
Blazor Server
      ↓
JWT Authentication
      ↓
ASP.NET Core Web API
      ↓
Entity Framework Core
      ↓
PostgreSQL
```

---

## 🔐 Controle de Acesso

### Admin

- Visualizar pizzas
- Criar pizzas
- Editar pizzas
- Excluir pizzas

### User

- Visualizar pizzas
- Acesso somente leitura

---

## ✅ Funcionalidades

- Login
- Logout
- CRUD de Pizzas
- Autenticação com JWT
- Controle de acesso por perfil
- Validação de formulários
- Mensagens de sucesso e erro
- Confirmação antes de excluir
- Proteção de páginas

---

## 📂 Estrutura da Solução

```text
ContosoPizza

├── ContosoPizza
│   ├── Controllers
│   ├── Data
│   ├── DTOs
│   ├── Migrations
│   ├── Models
│   └── Repositories
│
├── ContosoPizza.Web
│   ├── Components
│   ├── Models
│   └── Services
│
└── README.md
```

---

## 🛠️ Tecnologias Praticadas

- ASP.NET Core
- Blazor Server
- Entity Framework Core
- PostgreSQL
- JWT
- Claims
- Roles
- Session Storage
- Repository Pattern

---

## 📸 Telas

- Home
- Login
- Gerenciamento de Pizzas

---

## 🎯 Objetivos de Aprendizado

Durante o desenvolvimento deste projeto foram praticados:

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Repository Pattern
- JWT Authentication
- Claims e Roles
- Blazor Server
- Session Storage
- Controle de acesso baseado em perfil

---

## ⚙️ Configuração

Antes de executar o projeto, configure os valores do arquivo `appsettings.json`.

### Connection String

```json
"ConnectionStrings": {
  "PizzaDb": "Host=localhost;Database=pizzadb;Username=SEU_USUARIO;Password=SUA_SENHA"
}
```

### JWT

```json
"Jwt": {
  "Key": "INSIRA_SUA_CHAVE_JWT_AQUI"
}
```

---

## 📌 Versão

**1.0**

---

## 👨‍💻 Autor

**João Peres**

Projeto desenvolvido para estudo e prática de ASP.NET Core, Blazor Server, PostgreSQL e autenticação JWT.