# Network Testing Application

A comprehensive network diagnostic tool built with ASP.NET Core MVC that allows you to test network connectivity through Ping, Port checking, and HTTP requests.

## Features

- **Ping Testing**: Check host availability and measure response times
- **Port Scanning**: Verify open/closed ports on target hosts
- **HTTP Requests**: Test API endpoints and web services with full HTTP method support
- **History Management**: Save and reload previous test results
- **Export Results**: Download test results in JSON or CSV format

## Prerequisites

Before running this application, ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ZawHtut01/NetworkTestApp.git
   cd NetworkTestApp

2. Restore the NuGet packages
    dotnet restore

3. Build the application
   dotnet build

4. Run the application
   dotnet run
