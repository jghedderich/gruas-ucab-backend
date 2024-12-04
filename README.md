![.NET Banner](https://neosmart.net/blog/wp-content/uploads/2019/06/dot-NET-Standard-Logo-Rectangle.png)

# Gruas UCAB Backend

Welcome to the backend of **Gruas UCAB**! This project is a .NET 8 Web API built using a microservices architecture. It consists of three microservices: **Orders**, **Providers**, and **Admin**, all accessed through a YARP API Gateway. Each service is dockerized and orchestrated using Docker Compose.

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Running the Project](#running-the-project)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Microservices Architecture**: Modular design with separate services for Orders, Providers, and Admin functionalities.
- **YARP API Gateway**: Simplifies routing and management of microservices.
- **Dockerized Services**: Each microservice runs in its own Docker container for easy deployment and scalability.
- **Orchestration with Docker Compose**: Simplifies the setup and management of multi-container Docker applications.

## Architecture

The backend is structured into three main microservices:

1. **Orders Microservice**: Manages order-related operations.
2. **Providers Microservice**: Handles provider information and interactions.
3. **Admin Microservice**: Admin controls and configurations.

All services communicate through the YARP API Gateway, which routes requests to the appropriate microservice.

## Getting Started

To get started with the Gruas UCAB backend, follow these steps:

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/) with ASP.NET and web development tools
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

## Running the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/gruas-ucab-backend.git
   ```

2. Open the project in Visual Studio.

3. Ensure that you have the ASP.NET and web development tools installed.

4. Set `docker-compose` as the startup project:
   - Right-click on the solution in Solution Explorer.
   - Select "Set Startup Projects..."
   - Choose "Docker Compose" as the startup project.

5. Run the project without debugging:
   - Click on the "Run" button or press `Ctrl + F5`.

The application should now be running, and you can access it through the configured endpoints.

## Technologies Used

- **.NET 8**
- **YARP (Yet Another Reverse Proxy)**
- **Docker**
- **Docker Compose**

## Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

Thank you for checking out the Gruas UCAB backend! We hope you find it useful for your projects. If you have any questions or feedback, feel free to reach out!
