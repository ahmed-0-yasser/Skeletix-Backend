# Skeletix Backend API

Backend API for the Skeletix AI Bone Fracture Detection System, developed using ASP.NET Core Web API as part of the Graduation Project at The Egyptian E-Learning University (EELU).

## Overview

Skeletix is an AI-powered healthcare system designed to assist healthcare professionals in detecting bone fractures from X-ray images. The backend provides secure RESTful APIs for authentication, medical file management, AI integration, reporting, dashboard statistics, and system administration.

## Features

* JWT Authentication and Authorization
* User Authentication
* Medical File Management
* AI Fracture Analysis Integration
* Dashboard and Reports
* File Upload Management
* RESTful API Architecture
* Swagger API Documentation

## Technologies Used

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger (OpenAPI)
* RESTful APIs

## Project Structure

```text
Skeletix
│
├── Controllers
├── Contracts
├── Entities
├── Migrations
├── Persistence
├── Services
├── Uploads
├── Program.cs
└── appsettings.json
```

## Authentication

The API uses JWT Bearer Authentication.

Include the generated token in the Authorization header when accessing protected endpoints.

```http
Authorization: Bearer YOUR_TOKEN
```

## API Documentation

Swagger documentation is available after running the application.

```text
/swagger
```

Example:

```text
https://localhost:7045/swagger
```

## Getting Started

### Clone the repository

```bash
git clone https://github.com/a7medyasser-tech/Skeletix-Backend.git
```

### Navigate to the project

```bash
cd Skeletix-Backend
```

### Restore dependencies

```bash
dotnet restore
```

### Configure the database

Update the connection string inside `appsettings.json`, then run:

```bash
dotnet ef database update
```

### Run the application

```bash
dotnet run
```

## Graduation Project

This backend was developed as part of the Graduation Project at The Egyptian E-Learning University (EELU).

**Project Title:** Skeletix – AI Bone Fracture Detection System

The system leverages Artificial Intelligence to analyze X-ray images, detect bone fractures, estimate urgency levels, and support healthcare professionals with faster and more accurate clinical decision-making. The backend is responsible for authentication, data management, AI service integration, reporting, and secure API communication with the frontend application.

## Author

**Ahmed Yasser**

* GitHub: https://github.com/a7medyasser-tech
* LinkedIn: https://www.linkedin.com/in/ahmed-0-yasser

## License

This project was developed for educational purposes.
