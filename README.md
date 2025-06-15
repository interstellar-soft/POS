# POS System

This repository contains a proof-of-concept point of sale system.

## Structure

- `backend` - ASP.NET Core Web API using Entity Framework Core and MySQL
- `frontend` - minimal React client with Tailwind CSS

## Development

1. Copy `backend/POS.API/.env.example` to `.env` and adjust the connection string.
2. From the `backend/POS.API` folder run:
   ```bash
   dotnet build
   # optional: dotnet ef database update
   dotnet run
   ```
3. Serve the frontend:
   ```bash
   cd frontend
   npx serve public
   ```
