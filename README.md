# Debts Register Challenger

## Project Summary

The **Debts Register Challenger** is a sample Full Stack application that implements a system to register and list debts. The application allows users to create new debts, view their details, and track interest calculations and installments.

## Tech Stack

The application uses a monorepo approach, clearly separating the backend and frontend.

### **Backend**

- **Framework:** .NET 9
- **ORM:** Entity Framework Core 9
- **Database:** In-memory (to simplify execution)
- **Logging:** Serilog
- **Testing:** xUnit
- **API:** Minimal APIs

### **Frontend**

- **Framework:** Angular 19
- **Styling:** SCSS
- **HTTP Client:** Angular HTTP Client

## Architecture

The project's backend is structured with a hybrid approach that combines the best concepts from different architectural patterns to maximize maintainability, scalability, and code clarity:

- **Clean Architecture:** Ensures separation of concerns (SoC) by decoupling the business logic (domain) from infrastructure details (like databases and frameworks). Dependencies always flow towards the center (Domain -> Application -> Infrastructure/Api).

- **Domain-Driven Design (DDD):** The application's core is modeled around the "debts" business domain. Rich entities and value objects, such as `Debt` and `Installment`, contain the business logic and rules, ensuring that the heart of the software is robust and expressive.

- **Vertical Slice Architecture:** Instead of organizing code by technical layers (e.g., one folder for all `Services`, another for all `Controllers`), the architecture is sliced vertically by functionality. For example, all the logic for "Creating a Debt" (from the API endpoint, through the application command, to persistence) is grouped, making it easier to locate and modify code related to a specific feature.

This combination results in a cohesive system where business logic is protected and isolated, and features are organized logically and independently.

## How to Run

To run the complete application (Backend and Frontend), you need to have Docker Desktop installed and running.

1.  **Prerequisite:** Make sure [Docker Desktop](https://www.docker.com/products/docker-desktop/) is installed and running on your machine.

2.  **Clone the repository:**
    ```sh
    git clone <REPOSITORY_URL>
    cd debts-register-challenge
    ```

3.  **Run the application with Docker Compose:**
    Open a terminal at the project root and run the command below. It will build the backend and frontend images and start the containers.

    ```sh
    docker-compose up --build
    ```

4.  **Access the applications:**
    After the build is complete, the applications will be available at the following addresses:

    - **Frontend (Angular):** [http://localhost:4200](http://localhost:4200)
    - **Backend API (Swagger UI):** [http://localhost:8080/swagger](http://localhost:8080/swagger)

## Folder Structure

The project is organized as a monorepo with the following main folders:

```
/
├── backend/                # Contains all backend source code (.NET)
│   ├── src/
│   │   ├── Api/            # API Endpoints (Vertical Slice)
│   │   ├── Application/    # Application logic (commands, queries)
│   │   ├── Domain/         # Entities and business rules (DDD)
│   │   └── Infrastructure/ # Persistence, services, etc. implementations
│   └── tests/              # Unit and integration tests
│
├── frontend/               # Contains all frontend source code (Angular)
│   └── src/
│       └── app/
│           └── features/   # Application features
│
├── .gitignore
├── docker-compose.yml      # Container orchestrator
└── README.md
```