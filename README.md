# 🔗 URL Shortener

A simple, production-ready URL shortening web application built with:

- ASP.NET Core Web API (backend)
- SQLite + Entity Framework Core (data storage)
- React + TypeScript (frontend)

---

## 📁 Project Structure

```bash
UrlShortener/
├── UrlShortener.Api/             # Web API project (entry point)
├── UrlShortener.Core/           # Domain models & interfaces
├── UrlShortener.Infrastructure/ # EF Core + database context and repositories
├── UrlShortener.sln             # Solution file

## ⚙️ Backend Setup (`UrlShortener.Api`)

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Setup Instructions

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/urlshortener.git
   cd urlshortener
