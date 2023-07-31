# OesteFly

This is my web app called *OesteFly*. Enjoy it.

## Common steps:

### Create ASP.NET Core Web API (`cd backend/`):
- `dotnet new webapi`

### Install Entity Framework:
- `dotnet tool install --global dotnet-ef` ou `dotnet tool update --global dotnet-ef`
    - `dotnet add package Microsoft.EntityFrameworkCore.Sqlite` ou
    - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` ou
    - `dotnet add package Pomelo.EntityFrameworkCore.MySql`
- `dotnet add package Microsoft.EntityFrameworkCore.Design`
- `dotnet add package Microsoft.EntityFrameworkCore.Tools`

### Install AutoMapper:
- `dotnet add package AutoMapper`
- `dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection`
<!-- - `dotnet add package Microsoft.AspNetCore.Session`
- `dotnet add package Microsoft.Extensions.DependencyInjection` -->

### Do Migrations:
- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`

### Create a React project with Next (`cd ../`):
- Only **React**:
    - `npx create-react-app frontend --template typescript`
- **Next**:
    - `npx create-next-app@latest frontend`
        - TypeScript YES
        - ESLint YES
        - Tailwind CSS YES
        - 'src/' directory YES
        - App Router YES
        - import alias NO

### Installing useful libs (`cd frontend/`):
- Installing SASS (use it with SCSS files):
    - `npm i sass`
- Installing Material-UI and Material-Icons:
    - `npm install @mui/material @emotion/react @emotion/styled`
    - `npm i @mui/icons-material`
- Routes:
    - `npm i react-router-dom`
- Axios:
    - `npm install axios`
- Moment:
    - `npm i moment`
- sweetalert2:
    - `npm i sweetalert2`

### Now on the root of the project, after create React project (`cd ../`):
- `npm init`
- Add in *package.json > scripts* this item:
    - *"start": "concurrently \"dotnet watch run\" \"cd frontend && npm run dev\""*
- `npm install --sav-dev concurrently`
- `npm install react react-dom next --sav-dev concurrently`

Now, to run both backend and frontend together, just type `npm start`.
