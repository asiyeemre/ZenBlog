# 🚀 ZenBlog - .NET 9 Clean Architecture API

![.NET 9](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20%2F%20Onion-blue?style=for-the-badge&logo=dotnet)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

ZenBlog is a scalable **Backend RESTful API** project designed with modern software development principles and **Onion (Clean) Architecture**. It provides a testable, loosely coupled, and maintainable structure, strictly avoiding "spaghetti code."

---

## 🎯 Project Overview
This project targets **enterprise-level** application development standards. It aims to build a secure, high-performance infrastructure using the latest features of the **.NET 9** ecosystem.

---

## 🛠️ Key Features & Architecture

The project utilizes the following technologies and design patterns:

### 🏗️ Onion / Clean Architecture
* **Modular Structure:** Strict separation of concerns to manage dependencies effectively.
* **Layered Design:** Fully modular architecture with **Core**, **Infrastructure**, and **Presentation** layers.

### 🔄 Mediator Design Pattern (MediatR)
* **CQRS Implementation:** Separation of Command (Write) and Query (Read) responsibilities.
* **Decoupled Communication:** Centralized communication management to reduce tight coupling between objects.

### 🔒 Security (Authentication & Authorization)
* **Identity Management:** User management using **ASP.NET Core Identity**.
* **JWT Security:** Secure authentication based on **JSON Web Token (JWT)**.
* **RBAC:** Endpoint security ensured via **Role-based Authorization**.

### 💾 Data Management
* **Entity Framework Core:** Implementation of **Code-First** approach.
* **Optimization:** Optimized SQL database operations and relational modeling.

### 🌐 API Standards
* **RESTful Design:** Standardized endpoint design and naming conventions.
* **Error Handling:** Proper management of HTTP status codes and global exception handling.

---

## 📂 Requirements
To run this project, you will need:

* .NET 9 SDK
* SQL Server (or LocalDB for development)
* Visual Studio 2022 / VS Code

---

## 💻 Installation
1.  Clone the repository:
    ```bash
    git clone [https://github.com/asiyeemre/ZenBlog.git](https://github.com/asiyeemre/ZenBlog.git)
    ```
2.  Configure the connection string in `appsettings.json`.
3.  Update the database:
    ```bash
    Update-Database
    ```
4.  Run the application!
