# 🚀 MiniERP API

MiniERP is a simple ERP (Enterprise Resource Planning) backend system built with **.NET 8** and **SQL Server**. It provides APIs for managing users, roles, customers, products, sales, and reports.

---

## 📦 Features

* 🔐 JWT Authentication (Login/Register)
* 👥 Role-based access control
* 🧑 Customers management
* 📦 Products management
* 💰 Sales processing
* 📊 Reports generation
* 🗄️ SQL Stored Procedures support

---

## 🛠️ Tech Stack

* .NET 8 (ASP.NET Core Web API)
* Entity Framework Core
* SQL Server / LocalDB
* JWT Authentication
* Swagger (API testing)

---

## ⚙️ Prerequisites

Make sure you have installed:

* .NET 8 SDK
* SQL Server or SQL Server LocalDB
* Visual Studio 2022 or VS Code
* Git
* Postman (optional)

---

## 📥 Clone the Repository

```bash
git clone https://github.com/your-username/MINIERP.git
cd MINIERP
```

---

## 🗄️ Database Configuration

Open:

```
MiniERP_Api/appsettings.json
```

### Default (LocalDB)

```json
"DefaultConnection": "Server=(localdb)\\ProjectModels;Database=MINIERP_DB;Trusted_Connection=True;"
```

### SQL Server (Optional)

```json
"DefaultConnection": "Server=YOUR_SERVER;Database=MINIERP_DB;User Id=sa;Password=YOUR_PASSWORD;"
```

---

## ▶️ Run the Application

```bash
cd MiniERP_Api
dotnet run
```

Or run using Visual Studio (**F5**).

---

## 🌐 Swagger UI

Open in browser:

```
https://localhost:7123/swagger
```

Use Swagger to test all API endpoints.

---

## 🧾 Run Stored Procedures

File:

```
DBscript/data.txt
```

Steps:

1. Open SQL Server Management Studio (SSMS)
2. Connect to database
3. Open new query
4. Paste script from `data.txt`
5. Execute (F5)

✔ Run only once

---

## 🔐 Authentication Flow

### 1. Create Role

```
POST /api/role
```

```json
{
  "name": "Admin"
}
```

---

### 2. Register User

```
POST /api/auth/register
```

```json
{
  "username": "admin",
  "password": "yourpassword123",
  "roleId": 1
}
```

---

### 3. Login

```
POST /api/auth/login
```

```json
{
  "username": "admin",
  "password": "yourpassword123"
}
```

Response:

```json
{
  "accessToken": "...",
  "refreshToken": "..."
}
```

---

### 4. Use Token

Add this header to protected APIs:

```
Authorization: Bearer YOUR_ACCESS_TOKEN
```

---

## 📡 API Endpoints

| Feature       | Method   | Endpoint           |
| ------------- | -------- | ------------------ |
| Register      | POST     | /api/auth/register |
| Login         | POST     | /api/auth/login    |
| Refresh Token | POST     | /api/auth/refresh  |
| Roles         | GET/POST | /api/role          |
| Customers     | GET/POST | /api/customer      |
| Products      | GET/POST | /api/product       |
| Sales         | GET/POST | /api/sales         |
| Reports       | GET      | /api/report        |




