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
```
## ⚙️ Backend Setup (`UrlShortener.Api`)

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Setup Instructions

1. **Clone the repository**

   ```bash
   git clone --branch master https://github.com/khloudMohamed/UrlShortener.git
   cd urlshortener
   ```

2. **Restore NuGet packages**

```bash
dotnet restore
```
3. **Apply EF Core migrations**
Make sure you’re in the root folder of the solution, then run:


```bash
dotnet ef database update --project UrlShortener.Infrastructure --startup-project UrlShortener.Api
```

4. **Run the API**

```bash
dotnet run --project UrlShortener.Api
```

5. **Access API**
Swagger UI: https://localhost:7250/swagger

POST /urls/shorten: Accepts { "url": "https://example.com" } and returns a short code.

GET /{shortCode}: Redirects to the original URL.
