# OesteFly

This is my web app called *OesteFly*. Enjoy it.

## Etapas comuns:

### Criar ASP.NET Core Web API (`cd backend/`):
- `dotnet new webapi`

### Instalar Entity Framework:
- `dotnet tool install --global dotnet-ef` ou `dotnet tool update --global dotnet-ef`
    - `dotnet add package Microsoft.EntityFrameworkCore.Sqlite` ou
    - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` ou
    - `dotnet add package Pomelo.EntityFrameworkCore.MySql`
- `dotnet add package Microsoft.EntityFrameworkCore.Design`
- `dotnet add package Microsoft.EntityFrameworkCore.Tools`

### Instalar AutoMapper:
- `dotnet add package AutoMapper`
- `dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection`
<!-- - `dotnet add package Microsoft.AspNetCore.Session`
- `dotnet add package Microsoft.Extensions.DependencyInjection` -->

### Realizar Migrations:
- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`

### Criar projeto React.js com Next.js (`cd ../`):
- Com **React**:
    - `npx create-react-app frontend --template typescript`
- Com **Next**:
    - `npx create-next-app@latest frontend`
        - TypeScript YES
        - ESLint YES
        - Tailwind CSS YES
        - 'src/' directory YES
        - App Router YES
        - import alias NO

### Instalando libs úteis no projeto (`cd frontend/`):
- Instalando SASS (usar com arquivos SCSS):
    - `npm i sass`
- Instalando Material-UI e Material-Icons:
    - `npm install @mui/material @emotion/react @emotion/styled`
    - `npm i @mui/icons-material`
- Rotas:
    - `npm i react-router-dom`
- Axios:
    - `npm install axios`
- Moment:
    - `npm i moment`
- sweetalert2:
    - `npm i sweetalert2`

### Após criar React, agora na raiz do projeto (`cd ../`):
- `npm init`
- Acrescentar em *package.json*, em *scripts*, o item:
    - *"start": "concurrently \"dotnet watch run\" \"cd frontend && npm run dev\""*
- `npm install --sav-dev concurrently`
- `npm install react react-dom next --sav-dev concurrently`

Agora, para rodar, basta digitar `npm start` que já irá rodar tanto o backend quanto o frontend.