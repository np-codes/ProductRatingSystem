# Product Rating System

CSCI 4711 Software Engineering team project. A Windows desktop application written in C# (Windows
Forms, .NET 9) where **sellers** list products and **customers** rate and review them. Data is
stored in a local SQLite file; no server or internet connection is needed.

## What it does
- **Startup Page** → press **Startup** → **Login** page.
- **Customer:** sees the products they have not rated yet, gives each 1–5 stars and a written review.
- **Seller:** sees their own products with the overall rating and all reviews, and can **add a product**
  (title, picture, description, price).
- Passwords are stored only as SHA-256 hashes. Logins, failed logins and logouts are logged.

## Requirements
| Need | Notes |
|---|---|
| **Windows 10 or 11** | The app is a Windows Forms program; it only runs on Windows. |
| **.NET 9 SDK** | Download from <https://dotnet.microsoft.com/download/dotnet/9.0>. Check with `dotnet --version` (should start with `9.`). |
| **Visual Studio 2022 (17.12 or newer)** | Optional but recommended. Install the **".NET desktop development"** workload. |
| Internet (first build only) | NuGet downloads the `Microsoft.Data.Sqlite` package. |

## How to run

### Option A – Visual Studio
1. Clone the repository (or download it as a ZIP and unzip it):
   ```
   git clone https://github.com/np-codes/ProductRatingSystem.git
   ```
2. Open `ProductRatingSystem.sln`.
3. Build with **Ctrl+Shift+B** (it should say 0 errors), then press **F5** to run.

### Option B – command line
From the folder that contains `ProductRatingSystem.sln`:
```
dotnet build
dotnet run --project ProductRatingSystem
```

### Using the program
1. The **Startup Page** opens. Click **Startup**. The database is created on the first click.
2. Log in with a sample account. The password for every account is **`pass123`**.

| Username | Role |
|---|---|
| `customer1`, `customer2`, `customer3` | Customer |
| `seller1`, `seller2`, `seller3` | Seller |

3. The three sample products belong to `seller1`; `seller2` and `seller3` start with no products
   (use **Add Product**). Customers see all products they have not rated yet.
4. Click **Logout** to return to the Login page. Closing the last window ends the program.

### Where is the database? How do I reset it?
The file `ProductRatingSystem.db` is created next to the program, in
`ProductRatingSystem/bin/Debug/net9.0-windows/`. It is not part of the repository.
To start again with fresh sample data: **close the app, delete `ProductRatingSystem.db`, and run
the app again.** If Windows says the file is in use, close any program that has it open (for
example DB Browser for SQLite). Pictures added by sellers are copied to `Images/Products/` next to
the program.

### Troubleshooting
| Problem | Fix |
|---|---|
| `dotnet` is not recognized, or a build error mentions the target framework / `net9.0-windows` | Install the .NET 9 SDK (see Requirements). |
| Package `Microsoft.Data.Sqlite` cannot be restored | Connect to the internet and build again. |
| Product pictures are grey boxes | The picture file is missing. Sample pictures live in `ProductRatingSystem/Images/` (only `.png` files are copied on build). |
| New sample users or products do not appear | Sample data is only added to an empty database; delete `ProductRatingSystem.db` (see above). |

## The team

| Member | Name | Work |
|---|---|---|
| 1 | **Nisarg Patel** | **Database and Startup.** `DBConnectorControl` (SQLite tables, sample data, every database read/write), the Startup use case (`RatingSystem`, `StartupControl`, `StartupForm`), and keeping the project building. |
| 2 | **Dean Thompson** | **Login, Logout and menus.** `LoginForm`, `LoginControl`, `LogoutControl`, and the Customer and Seller menus (`CustomerMenu`, `SellerMenu`, `MainMenu`) with the shared look (`ApplicationForm`, `UiTheme`). |
| 3 | **Daniel Reed** | **Add Product and Rate Product.** `AddProductForm` / `AddProductControl` for sellers, `RatingForm` / `RateProductControl` for customers, the product cards (`ProductCard`) and showing reviews and overall ratings. |

The `Entity` classes (`UserAccount`, `Product`, `ProductRating`, `ProductList`, `ReviewList`) are
shared by everyone.

## Project structure
```
ProductRatingSystem.sln
ProductRatingSystem/
├── RatingSystem.cs     Program entry point (Main)
├── Entity/             Data classes: UserAccount, Product, ProductRating, ProductList, ReviewList
├── Control/            Logic: DBConnectorControl (database), Startup/Login/Logout/AddProduct/RateProduct controls
├── Boundary/           Screens (Windows Forms): Startup, Login, menus, Add Product, Rating, product card
└── Images/             Pictures copied next to the program when you build
```
The code follows the **Boundary – Control – Entity** pattern: forms (Boundary) call controls
(Control), which use `DBConnectorControl` and the Entity classes.

## More documentation
| File | Contents |
|---|---|
| `PROJECT_OVERVIEW.md` | Start here for details: every file and class, methods, database tables, how the program runs. |
| `Work_Explanation/MEMBER1_EXPLANATION.md` | Database, startup, final changes (Nisarg Patel). |
| `Work_Explanation/MEMBER2_EXPLANATION.md` | Login, logout and menus (Dean Thompson). |
| `Work_Explanation/MEMBER3_EXPLANATION.md` | Add Product and Rate Product (Daniel Reed). |

## For contributors

### Coding rules
- Class and method names follow RAD sections 4.2.1 and 4.2.2.
- Namespaces: `ProductRatingSystem.Entity`, `ProductRatingSystem.Control`, `ProductRatingSystem.Boundary`.
- Every class is `public class`. Visual Studio's Add → Class makes it `internal`, so change it.
- One class per file; the file name matches the class name (e.g. `LoginControl.cs`).
- Parameters start with `m` (e.g. `muserID`), like the Entity classes.
- In Boundary files write `LoginControl`, not `Control.LoginControl`.
- New forms inherit from `ApplicationForm` (same 600 × 780 window) and style buttons with
  `UiTheme.StyleSecondaryButton`. Do not set your own form size.
- Don't change Entity classes or someone else's files without telling the team first.

### Git workflow
```
git clone https://github.com/np-codes/ProductRatingSystem.git     (first time only)
git checkout -b your-branch-name                                  (first time only)

git checkout your-branch-name                                     (every time you start)
git pull origin main

dotnet build                                                      (must say 0 errors)
git add .
git commit -m "Short description of what you did"
git push -u origin your-branch-name
```
Then on GitHub click **Compare & pull request** → **Create pull request**; a teammate reviews and
merges it, and everyone runs `git pull origin main` again.

- Never push directly to `main`.
- Build before every push. Pull from `main` before starting work and before opening a pull request.
- If Git reports a merge conflict, don't guess. Ask the person who wrote the other code.
