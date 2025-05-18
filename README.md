🧠 Overview
This project is a full-stack URL Shortener application built with:

Backend: ASP.NET Core (.NET 8), SQLite, EF Core

Frontend: React + TypeScript + Axios

⚙️ Backend – Setup Instructions
<pre> <code>```plaintext  📁 Project Structure UrlShortener/ ├── UrlShortener.Api/ # Web API project (entry point) ├── UrlShortener.Core/ # Domain models & interfaces ├── UrlShortener.Infrastructure/ # EF Core + database context ├── UrlShortener.sln # Solution file ```</code> </pre>

✅ Prerequisites
.NET 8 SDK

EF Core CLI tools (install via dotnet tool install --global dotnet-ef)

SQLite installed (optional for inspecting DB)

