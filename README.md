# Dairy Management System

Dairy Management System is a layered ASP.NET Core MVC application developed to manage dairy products, categories, suppliers, and customer orders through a modern administration panel.

The project was built using the Entity Framework Core Code First approach and follows a layered architecture to provide a clean, maintainable, and scalable structure. It also includes an advanced reporting module with LINQ, JOIN, and GROUP BY queries, along with PDF and Excel export features.

---

# Technologies

- ASP.NET Core MVC
- Entity Framework Core
- Code First
- SQL Server
- Layered Architecture
- LINQ
- Bootstrap 5
- HTML5
- CSS3
- JavaScript
- ClosedXML
- QuestPDF

---

# Project Architecture

The project consists of three layers.

## DairyManagement.Entity

Contains all entity classes used by the application.

- Category
- Product
- Supplier
- CustomerOrder

---

## DairyManagement.Data

Responsible for database operations.

Includes:

- AppDbContext
- Entity Framework Core
- Code First
- Migrations

---

## DairyManagement.UI

Presentation layer of the application.

Includes:

- Controllers
- Views
- Admin Dashboard
- CRUD Operations
- Reports
- PDF Export
- Excel Export

---

# Database

The project contains four related tables.

- Categories
- Products
- Suppliers
- CustomerOrders

---

# Database Relationships

| Table | Relationship |
|--------|--------------|
| Categories | 1 → N Products |
| Suppliers | 1 → N Products |
| Products | 1 → N CustomerOrders |

---

# Features

- Modern Admin Dashboard
- Category Management
- Product Management
- Supplier Management
- Customer Order Management
- Responsive Interface
- Advanced Reporting
- PDF Export
- Excel Export

---

# Reports

The project contains **12 different reports**.

The reporting module includes various LINQ operations such as:

- Count
- Sum
- Average
- Max
- Min
- JOIN
- GROUP BY

Example reports:

- Total Category Count
- Total Product Count
- Total Supplier Count
- Total Customer Order Count
- Total Product Stock
- Total Order Amount
- Most Expensive Product
- Cheapest Product
- Products by Category
- Products by Supplier
- Orders by Product
- Supplier Statistics

---

# CRUD Operations

CRUD operations have been implemented for all entities.

- Create
- Read
- Update
- Delete

---

# Export Features

Reports can be exported in the following formats:

- PDF
- Excel
# Libraries & NuGet Packages

# Libraries & NuGet Packages

- Microsoft.EntityFrameworkCore.SqlServer (10.0.0)
- Microsoft.EntityFrameworkCore.Tools (10.0.0)
- Microsoft.EntityFrameworkCore.Design (10.0.0)
- ClosedXML (0.105.0)
- QuestPDF (2026.6.1)
---

# Project Screenshots

## Layered Architecture

![Layered Architecture](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/katmanliyapi.png?raw=true)

---

## Home Page

![Home Page](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/anasayfa.png?raw=true)

---

## Category Management

![Category Management](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/kategori.png?raw=true)

---

## Add Category

![Add Category](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/kategoriekle.png?raw=true)

---

## Product Management

![Product Management](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/urunler.png?raw=true)

---

## Add Product

![Add Product](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/urunekle.png?raw=true)

---

## Supplier Management

![Supplier Management](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/tedarikci.png?raw=true)

---

## Reports

![Reports](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/raporlar.png?raw=true)

---

## PDF Export

![PDF Export](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/pdf.png?raw=true)

---

## Excel Export

![Excel Export](https://github.com/adenyabasak/DairyManagement.UI/blob/master/images/excel.png?raw=true)

---

# What I Learned

During this project I improved my practical knowledge of:

- ASP.NET Core MVC
- Entity Framework Core
- Code First Development
- Layered Architecture
- SQL Server
- LINQ Queries
- JOIN Queries
- GROUP BY Queries
- CRUD Operations
- Responsive Dashboard Design
- PDF Generation
- Excel Export
- Bootstrap

---

# Developer

**Başak Erdoğan**

Backend Developer

**Tech Stack:** ASP.NET Core MVC • Entity Framework Core • Code First • SQL Server • Layered Architecture
