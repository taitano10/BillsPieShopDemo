

# 🥧 Bill’s Pie Shop Demo

A full-stack **ASP.NET Core MVC** web application showcasing clean architecture, data-driven design, and a complete shopping experience — from browsing pies to placing orders.
Built as a modern .NET sample for portfolios, technical interviews, and Azure deployment practice.

![.NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-Core-green)
![Bootstrap 5](https://img.shields.io/badge/UI-Bootstrap%205-lightblue)
![License](https://img.shields.io/badge/license-MIT-lightgrey)

---

## 🧰 Tech Stack

| Layer    | Technology                      | Purpose                     |
| -------- | ------------------------------- | --------------------------- |
| Backend  | **ASP.NET Core MVC (.NET 8)**   | Application logic & routing |
| Data     | **Entity Framework Core**       | ORM & migrations            |
| Database | **SQL Server / LocalDB**        | Persistent data             |
| Frontend | **Razor Views + Bootstrap 5**   | Responsive UI               |
| Auth     | **ASP.NET Identity (Optional)** | Login & secure checkout     |
| State    | **Session Storage**             | Shopping cart persistence   |
| Cloud    | **Azure App Service**           | Hosting & deployment        |

---

## ✨ Features

* Browse pies by **category** or featured “Pies of the Week”
* Add to a **shopping cart** with quantity updates and remove option
* Complete **checkout** with validation and database persistence
* **Search** and **filter** across catalog items
* **Clean architecture** (Controller → Service → Repository)
* **Responsive design** for desktop & mobile
* Optional **user authentication** with ASP.NET Identity

---

## 🧱 Project Structure

```
BillsPieShopDemo/
├── BillsPieShop.Web/           # MVC web app (controllers, views, wwwroot)
│   ├── Controllers/            # Home, Pie, Cart, Order controllers
│   ├── Models/                 # Domain & view models
│   ├── Views/                  # Razor views
│   ├── wwwroot/                # Static assets (CSS/JS/images)
│   └── appsettings.json        # Configurations
├── BillsPieShop.Data/          # EF Core context, repositories, seed data
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
* SQL Server LocalDB or SQL Express
* (Optional) Visual Studio 2022 or VS Code

### 1️⃣ Clone & Restore

```bash
git clone https://github.com/taitano10/BillsPieShopDemo.git
cd BillsPieShopDemo
dotnet restore
```

### 2️⃣ Configure Database

Edit `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "PieShopConnection": "Server=(localdb)\\mssqllocaldb;Database=BillsPieShopDemo;Trusted_Connection=True;"
}
```

### 3️⃣ Run EF Core Migrations

```bash
dotnet ef database update
```

### 4️⃣ Launch

```bash
dotnet run --project BillsPieShop.Web
```

Open your browser at **[http://localhost:5000](http://localhost:5000)**

---

## ☁️ Deploy to Azure App Service

### Option 1 – Via Visual Studio

1. Right-click the project → **Publish**.
2. Select **Azure → Azure App Service → Create New**.
3. Configure:

   * **Runtime:** .NET 8 (LTS)
   * **OS:** Windows or Linux
   * **Region:** closest to you
4. Visual Studio handles build & deployment automatically.
5. Once deployed, your site is live at
   `https://<your-app-name>.azurewebsites.net`

---

### Option 2 – Via Azure CLI

```bash
# Login
az login

# Create resource group
az group create --name PieShopRG --location westus

# Create App Service plan
az appservice plan create --name PieShopPlan --resource-group PieShopRG --sku B1 --is-linux

# Create web app
az webapp create --resource-group PieShopRG --plan PieShopPlan --name bills-pie-shop --runtime "DOTNETCORE|8.0"

# Deploy
dotnet publish -c Release
az webapp deploy --resource-group PieShopRG --name bills-pie-shop --src-path ./BillsPieShop.Web/bin/Release/net8.0/publish
```

After deployment, visit
👉 `https://bills-pie-shop.azurewebsites.net`

---

### Option 3 – CI/CD with GitHub Actions

1. In GitHub, go to **Settings → Pages → Environments → Add Azure Web App**.
2. Under **Actions**, choose **“Set up a workflow for deploying .NET to Azure App Service”**.
3. Replace the generated YAML with:

```yaml
name: Deploy to Azure

on:
  push:
    branches: [ "main" ]

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'
      - name: Build
        run: dotnet build --configuration Release
      - name: Publish
        run: dotnet publish BillsPieShop.Web -c Release -o ./publish
      - name: Deploy to Azure Web App
        uses: azure/webapps-deploy@v2
        with:
          app-name: 'bills-pie-shop'
          publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
          package: ./publish
```

4. Save and commit. GitHub will automatically deploy every time you push to `main`.

---

## 🐳 Run with Docker (Optional)

If you want to containerize locally or for Azure Container Apps:

```bash
# Build image
docker build -t billspieshop .

# Run container
docker run -p 8080:80 billspieshop
```

Then visit **[http://localhost:8080](http://localhost:8080)**

*(Optional: add a `Dockerfile` if not already present — I can generate one.)*

---

## 🧠 Architecture Overview

* **MVC Pattern** — separation of concerns
* **Repository + Service Layers** — clean data and business abstraction
* **Dependency Injection** — registered in `Program.cs`
* **Session-based Cart** — persisted via `ISession`
* **EF Core Seeding** — prepopulated sample pies and categories

---

## 📸 Screenshots

| Home Page                                              | Product Detail                                             | Shopping Cart                                          | Checkout                                                       |
| ------------------------------------------------------ | ---------------------------------------------------------- | ------------------------------------------------------ | -------------------------------------------------------------- |
| ![Home](https://via.placeholder.com/250x150?text=Home) | ![Detail](https://via.placeholder.com/250x150?text=Detail) | ![Cart](https://via.placeholder.com/250x150?text=Cart) | ![Checkout](https://via.placeholder.com/250x150?text=Checkout) |

> Replace these with screenshots from your running Azure site.

---

## 🧭 Roadmap

* [ ] Admin area for pie management
* [ ] REST API for external clients
* [ ] Enhanced search & pagination
* [ ] Localization & accessibility support
* [ ] Integration with Azure SQL Database

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
© 2025 Bill Taitano

---

## 👋 About the Developer

Created by **[Bill Taitano](https://github.com/taitano10)** —
Full-stack developer passionate about clean architecture, data-driven applications, and cloud deployment with Azure.

> *“A simple project that tastes like a real-world app.”* 🥧


