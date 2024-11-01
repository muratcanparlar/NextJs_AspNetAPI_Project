# Next.js & ASP.NET API Project

This repository is an example of an integrated project using Next.js for the frontend and ASP.NET for the backend API. The goal is to showcase a clean architecture for a scalable web application with a strong separation of concerns.

## Project Structure

- **Frontend**: Built using Next.js, housed in the `client` directory.
- **Backend**: ASP.NET API, located in the `api` directory.
- **Shared**: Any shared resources or configurations.

## Features

- Role-based folder structure in the frontend.
- Initial components like Menu and Navbar.
- Skeleton structure for the frontend application.

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
    cd client
    npm install
    ```

3. **Navigate to the backend directory and restore dependencies**:
    ```sh
    cd ../api
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
    cd client
    npm run dev
    ```

## Upcoming Features

Stay tuned for exciting new features including:

- Integration with Keycloak for authentication.
- Token retrieval and refresh functionality.
- Login via credentials.
- Role-based authentication on the frontend.
- Integration with ASP.NET Web API to fetch data post-authentication.

Keep checking back for updates and improvements!

## Contributing

Pull requests are welcome. For significant changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License.
