<p align="center">
  <img src="banner.jpeg" alt="Skeletix Banner" width="100%">
</p>

# Skeletix Backend API

## AI-Powered Bone Fracture Detection System Backend

Skeletix Backend is a production-style RESTful API developed using **ASP.NET Core Web API** as part of the Graduation Project at **The Egyptian E-Learning University (EELU)**.

The backend provides secure, scalable, and maintainable services for an AI-powered healthcare platform that assists medical professionals in analyzing X-ray images, detecting bone fractures, generating reports, and managing patient medical data.

---

# Overview

Skeletix is an intelligent healthcare system that combines **Artificial Intelligence** with **Backend Engineering** to support faster and more accurate bone fracture analysis.

The backend is responsible for:

- User Authentication & Authorization
- Patient Management
- Medical File Management
- X-ray Image Upload
- AI Model Integration
- Fracture Detection Results
- Medical Report Generation
- Dashboard Statistics
- Secure Communication with Frontend

The project follows a clean, scalable, and production-style architecture suitable for real-world healthcare applications.

---

# Key Features

## Authentication & Security

- JWT Authentication
- User Registration & Login
- Role-Based Authorization
- Secure API Endpoints
- ASP.NET Identity
- Password Hashing

## Medical File Management

- Upload X-ray Images
- Store Patient Medical Files
- Analysis History
- Medical Examination Records

## AI Fracture Analysis

The backend integrates with an Artificial Intelligence model capable of:

- Detecting Bone Fractures
- Returning Confidence Scores
- Generating Detection Results
- Providing Medical Recommendations
- Returning Processed X-ray Images

The backend manages the complete communication between users, the AI service, SQL Server database, and the frontend application.

## Reports & Dashboard

- Medical Analysis Reports
- Dashboard Statistics
- Analysis History
- System Monitoring

## API Documentation

- Interactive Swagger UI
- OpenAPI Documentation
- Easy API Testing

---

# System Architecture

```
Skeletix Backend

│
├── Controllers
│   └── API Endpoints
│
├── Contracts
│   └── Interfaces
│
├── Entities
│   └── Database Models
│
├── Services
│   └── Business Logic
│
├── Persistence
│   └── Database Context
│
├── Migrations
│   └── Entity Framework Core Migrations
│
├── Uploads
│   └── Uploaded X-ray Images
│
├── Program.cs
│
└── appsettings.json
```

---

# Technologies Used

## Backend

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- LINQ
- Dependency Injection
- JWT Authentication
- RESTful APIs

## AI Integration

- AI Fracture Detection Model
- REST API Communication
- Image Processing Workflow

## Development Tools

- Visual Studio 2022
- Git
- GitHub
- Swagger / OpenAPI

---

# Database

The project uses:

- SQL Server
- Entity Framework Core
- Code First Approach
- EF Core Migrations

Responsibilities include:

- User Data
- Patient Records
- Medical Files
- AI Analysis Results
- Reports
- System Records

---

# Authentication

The API uses **JWT Bearer Authentication**.

Include the generated access token inside the request header.

```http
Authorization: Bearer YOUR_TOKEN
```

---

# API Documentation

After running the project, open:

```text
/swagger
```

Example:

```text
https://localhost:7045/swagger
```

---

# Swagger Screenshots

## Authentication APIs

![Authentication](1.png)

---

## Medical Files APIs

![Medical Files](2.png)

---

## AI Analysis APIs

![AI Analysis](3.png)

---

## Reports APIs

![Reports](4.png)

---

## Dashboard APIs

![Dashboard](5.png)

---

## Education APIs

![Education](6.png)

---

## Chatbot APIs

![Chatbot](7.png)

---

## Additional APIs

![Additional APIs](8.png)

---

# Getting Started

## Clone Repository

```bash
git clone https://github.com/a7medyasser-tech/Skeletix-Backend.git
```

## Navigate to Project

```bash
cd Skeletix-Backend
```

## Restore Packages

```bash
dotnet restore
```

## Configure Database

Update the SQL Server connection string inside:

```text
appsettings.json
```

Then run:

```bash
dotnet ef database update
```

## Run the Application

```bash
dotnet run
```

---

# Graduation Project

## Skeletix – AI Bone Fracture Detection System

This backend was developed as part of the Graduation Project at **The Egyptian E-Learning University (EELU)**.

The system leverages Artificial Intelligence to:

- Analyze X-ray Images
- Detect Bone Fractures
- Estimate Confidence Levels
- Generate Medical Recommendations
- Produce Structured Medical Reports

The backend is responsible for:

- REST API Development
- Authentication
- Database Management
- AI Integration
- Report Generation
- Secure Communication Between System Components

---

# Future Improvements

- Cloud Deployment
- Advanced Medical Analytics
- Real-time Notifications
- Mobile Application Integration
- Enhanced AI Prediction Models

---

# Author

## Ahmed Yasser

**Junior Backend Developer | .NET**

Specialized in:

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- RESTful APIs
- JWT Authentication
- Clean Architecture

**GitHub**

https://github.com/ahmed-0-yasser

**LinkedIn**

https://www.linkedin.com/in/ahmed-0-yasser

---

# License

This project was developed as a Graduation Project for educational purposes. It demonstrates backend development, RESTful API design, AI integration, and software engineering best practices.

---

⭐ If you found this project useful, consider giving it a Star on GitHub.
