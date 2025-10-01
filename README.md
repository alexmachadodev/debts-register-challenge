# Debts Register Challenger

## Project Summary

The **Debts Register Challenger** is a sample Full Stack application that implements a system to register and list debts. The application allows users to create new debts, view their details, and track interest calculations and installments.

## Tech Stack

The application uses a monorepo approach, clearly separating the backend and frontend.

### **Backend**

- **Framework:** .NET 9  
- **ORM:** Entity Framework Core 9  
- **Database:** In-memory (to simplify execution)  
- **Testing:** xUnit, FluentAssertions, NSubstitute  
- **API:** Minimal APIs  

### **Frontend**

- **Framework:** Angular 19  
- **Styling:** SCSS  
- **HTTP Client:** Angular HTTP Client  

## Architecture

The project's backend is structured with a hybrid approach that combines the best concepts from different architectural patterns to maximize maintainability, scalability, and code clarity:

- **Clean Architecture:** Ensures separation of concerns (SoC) by decoupling the business logic (domain) from infrastructure details (like databases and frameworks). Dependencies always flow towards the center (Domain -> Application -> Infrastructure/Api).  

- **Domain-Driven Design (DDD):** The application's core is modeled around the "debts" business domain. Rich entities and value objects, such as `Debt` and `Installment`, contain the business logic and rules, ensuring that the heart of the software is robust and expressive.  

- **SOLID, DRY, KISS, YAGNI:** The development follows these core principles to ensure the system remains maintainable, simple, and free from over-engineering.  

This combination results in a cohesive system where business logic is protected and isolated, and features are organized logically and independently.

## How to Run

To run the complete application (Backend and Frontend), you need to have Docker Desktop installed and running.

1. **Clone the repository:**
   ```sh
   git clone https://github.com/alexmachadodev/debts-register-challenge.git
   cd debts-register-challenge
   ```

2. **Run the application with Docker Compose:**
   Open a terminal at the project root and run the command below. It will build the backend and frontend images and start the containers.

   ```sh
   docker-compose up --build
   ```

3. **Access the applications:**
   After the build is complete, the applications will be available at the following addresses:

   - **Frontend (Angular):** [http://localhost:4200](http://localhost:4200)  
   - **Backend API (Swagger UI):** [http://localhost:8080/swagger](http://localhost:8080/swagger)  

## Folder Structure

The project is organized as a monorepo with the following main folders:

```
/
├── backend/                # Contains all backend source code (.NET)
│   ├── src/
│   │   ├── Api/            # API Endpoints
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

## Contributing

Contributions are welcome!  
To contribute:  

1. Fork the repository  
2. Create a new branch (`git checkout -b feature/your-feature`)  
3. Commit your changes (`git commit -m "Add your feature"`)  
4. Push to the branch (`git push origin feature/your-feature`)  
5. Open a Pull Request  

## License

This project is licensed under the MIT License. You are free to use, modify, and distribute it as permitted.