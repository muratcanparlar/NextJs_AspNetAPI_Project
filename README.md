# Next.js & ASP.NET API Project

Goal: Authenticate a Next.js project with Keycloak using credentials.

This repository demonstrates an integrated project using Next.js for the frontend and ASP.NET for the backend API, aiming to showcase a clean architecture for a scalable web application with a strong separation of concerns. The goal is to implement the Keycloak authentication process for secure user login and role-based access control.

## Project Structure

- **Frontend**: Built using Next.js, housed in the `frontend` directory.
- **Backend**: ASP.NET API, located in the `backend` directory.
- **Shared**: Any shared resources or configurations.

## Features

- Role-based folder structure in the frontend.
- Initial components like Menu and Navbar.
- Skeleton structure for the frontend application.
- Integration with Keycloak for authentication.
- Token retrieval and refresh functionality.
- Login via credentials.
- Role-based authentication on the frontend.

## Getting Started

### Prerequisites

- Node.js
- .NET Core SDK

### Installation

1. **Clone the repository**:
    ```sh
    git clone https://github.com/muratcanparlar/NextJs_AspNetAPI_Project.git
    cd NextJs_AspNetAPI_Project
    ```

2. **Navigate to the frontend directory and install dependencies**:
    ```sh
    cd frontend/web-app
    npm install
    ```

3. **Navigate to the backend directory and restore dependencies**:
    ```sh
    cd ../backend/
    dotnet restore
    ```

### Running the Project

1. **Start the backend server**:
    ```sh
    cd api
    dotnet run
    ```

2. **Start the frontend development server**:
    ```sh
    cd frontend/web-api
    npm run dev
    ```

## Upcoming Features

Stay tuned for exciting new features including:

- Integration with ASP.NET Web API to fetch data post-authentication.

Keep checking back for updates and improvements!

## Contributing

Pull requests are welcome. For significant changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License.
