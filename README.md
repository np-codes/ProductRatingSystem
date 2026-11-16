# Product Rating System
CSCI 4711 Software Engineering – team project (C#, Windows Forms, .NET 9)

## Work split
Entity classes (Appendix A) are already done and in `Entity/`.
Exact class and method names for every task are in RAD sections 4.2.1 and 4.2.2.

### Member 1 – Database and Startup
- Database connector in `Control/`: set up SQLite and the tables for users, products and ratings
- Methods to read and save users, products and ratings
- Startup use case: app opens, connects to the database, shows the login screen (`Program.cs`)
- Sample data (test users and products) so the others can test
- Merges pull requests into `main` and keeps the project building

### Member 2 – Login and Logout
- Login use case: login form (`Boundary/`) and login control (`Control/`)
- Logout use case: logout control and returning to the login screen
- Customer menu and Seller menu (`Boundary/`): the screens each role sees after logging in

### Member 3 – Add Product and Rate Product
- Add Product use case: add product form (`Boundary/`) and add product control (`Control/`), for Sellers
- Rate Product use case: product list / rate product form (`Boundary/`) and rate product control (`Control/`), for Customers
- Showing a product's reviews and overall rating

## Project structure
- `Entity/` – data classes (UserAccount, Product, ProductRating, ProductList, ReviewList)
- `Control/` – logic for each use case and the database connector
- `Boundary/` – forms and menus

## Coding rules
- Class and method names must match RAD sections 4.2.1 and 4.2.2 exactly.
- Namespaces: `ProductRatingSystem.Entity`, `ProductRatingSystem.Control`, `ProductRatingSystem.Boundary`
- Every class is `public class`. Visual Studio's Add → Class makes it `internal`, so change it.
- One class per file; the file name matches the class name (e.g. `LoginControl.cs`).
- Constructor and method parameters start with `m` (e.g. `muserID`), like Appendix A.
- Use other folders with `using`, e.g. `using ProductRatingSystem.Entity;`
- In Boundary files, write `LoginControl`, not `Control.LoginControl`.
- Don't change Entity classes or someone else's files without telling the team first.

## Git commands

### First time only
```
git clone https://github.com/np-codes/ProductRatingSystem.git
cd ProductRatingSystem
git checkout -b your-branch-name
```

### Every time you start working
```
git checkout your-branch-name
git pull origin main
```
(`git pull origin main` brings in everyone's merged work.)

### Saving and pushing your work
```
dotnet build
git add .
git commit -m "Short description of what you did"
git push -u origin your-branch-name
```
After the first push, `git push` on its own is enough.

### Getting your work into main
1. On GitHub, click **Compare & pull request** for your branch.
2. Click **Create pull request**.
3. A teammate checks it and clicks **Merge pull request**.
4. Everyone else runs `git pull origin main` on their own branch.

### Rules
- Never push directly to `main`.
- Build before every push. It must say 0 errors.
- Pull from `main` often, at least before starting work and before opening a pull request.
- If Git reports a merge conflict, don't guess. Ask the person who wrote the other code.

## Getting started
1. Install Visual Studio with the ".NET desktop development" workload.
2. Clone the repo (see above) and open `ProductRatingSystem.sln`.
3. Build with Ctrl+Shift+B. It should say 0 errors.