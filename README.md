# Kibernum Project

This repository contains two main applications:
- **Kibernum_Back**: A .NET Core API backend.
- **Kibernum_Front**: An Angular frontend application.

These applications work together to provide a full-stack solution for managing contacts (or any other domain).

## Table of Contents

- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
  - [Backend (Kibernum_Back)](#backend-setup-kibernum_back)
  - [Frontend (Kibernum_Front)](#frontend-setup-kibernum_front)
- [Running the Applications](#running-the-applications)
  - [Running with Docker Compose](#running-with-docker-compose)
  - [Running Individually](#running-individually)
- [Environment Configuration](#environment-configuration)
- [Technologies Used](#technologies-used)

## Project Structure

The repository is structured as follows:

```plaintext
project-root/
├── Kibernum_Back/         # .NET Core API backend
│   ├── Controllers/       # API Controllers
│   ├── Models/            # Data Models
│   ├── Services/          # Business Logic Services
│   ├── appsettings.json   # Configuration
│   └── ...                # Other backend files
├── Kibernum_Front/        # Angular frontend application
│   ├── src/               # Angular source code
│   ├── dist/              # Build output
│   ├── angular.json       # Angular CLI configuration
│   └── ...                # Other frontend files
└── docker-compose.yml     # Docker Compose configuration for running both apps
```

## Prerequisites

Before you begin, ensure you have the following installed:

- **.NET Core SDK**: [Download here](https://dotnet.microsoft.com/download)
- **Node.js and npm**: [Download here](https://nodejs.org/en/download/)
- **Angular CLI**: Install globally with `npm install -g @angular/cli`
- **Docker and Docker Compose**: [Download Docker Desktop](https://www.docker.com/products/docker-desktop)

## Setup Instructions

### Backend Setup (Kibernum_Back)

1. Navigate to the backend directory:
   ```bash
   cd Kibernum_Back
   dotnet restore
   dotnet build

### Backend Setup (Kibernum_Front)

1. Navigate to the Frontend directory:
   ```bash
   cd Kibernum_Front
   npm install
   ng build --prod

### Running with Docker Compose

1. Navigate to the base directory:
   ```bash
   docker-compose up --build

This will build the Docker images and start the containers for both the backend and frontend.

The backend will be accessible at http://localhost:5000.
The frontend will be accessible at http://localhost:80.

2. To stop the containers, press Ctrl+C or run:
   ```bash
   docker-compose down

## Running Individually

1. Running the Backend:
    ```bash
    cd Kibernum_Back
    dotnet run

1. Running the Frontend:
    ```bash
    cd Kibernum_Front
    ng serve


### Technologies Used

1. Backend (Kibernum_Back):
    - .NET Core
    - Entity Framework Core
    - ASP.NET Core Web API

2. Frontend (Kibernum_Front):
    - Angular
    - Angular Material

3. Containerization:
    - Docker
    - Docker Compose


### **Explanation:**

1. **Project Structure:** The `README` explains the structure of the repository, showing how the backend and frontend directories are organized.
2. **Prerequisites:** It lists the required software tools, such as .NET Core SDK, Node.js, Angular CLI, and Docker.
3. **Setup Instructions:** Step-by-step instructions are provided to set up both the backend (.NET Core API) and the frontend (Angular) applications.
4. **Running the Applications:** Instructions are given for running both applications either using Docker Compose or individually.
5. **Environment Configuration:** Information on configuring the environment for both the backend and frontend is provided. This includes setting up the API URL and other configurations.
6. **Technologies Used:** A section listing the main technologies used in both the backend and frontend applications, as well as Docker for containerization.
7. **License:** A placeholder for the license, assuming the project is open source and licensed under MIT. You can change this based on your project's actual license.

This `README.md` should provide all the necessary information for someone to understand, set up, and run your project. If you need further customization or additions, feel free to ask!







