# Member 1 – Database and Startup (explanation)

## 1. Overview

Member 1's part has two jobs. First, **DBConnectorControl** is the only class that talks to the
SQLite database: it creates the tables, adds sample data, and turns database rows into the
Entity objects (`UserAccount`, `Product`, `ProductRating`, `ProductList`, `ReviewList`) that
everyone else uses. Second, the **Startup use case** (`RatingSystem` → `StartupForm` → `StartupControl`) starts
the program, shows the **Startup Page**, and when the user clicks **Startup** it prepares the
database and opens the login screen. `RatingSystem` also makes sure the program ends only when
the last window is closed. Nobody else needs to write any SQL: teammates just call the methods
of `DBConnectorControl`.

---

## 2. File by file

### 2.1 `ProductRatingSystem/RatingSystem.cs` (renamed from `Program.cs`)

**What it is for:** the entry point of the program. Windows runs `Main` first.

Changes: the file and class were renamed `Program` → `RatingSystem`; the class is now
`public static class`. It stays in the root namespace `ProductRatingSystem`. It now shows the
Startup Page and keeps the program alive until the last window closes (see section 3.2).

| Member | Parameters | Returns | What it does |
|---|---|---|---|
| `static void Main()` | none | nothing | Calls `ApplicationConfiguration.Initialize()` (standard WinForms setup). Creates an `ApplicationContext` (a message loop with no main form), adds an `Application.Idle` check that ends the program when no visible form is left, shows `new StartupForm().display()`, then runs `Application.Run(context)`. Marked `[STAThread]`. It must be called `Main` because C# requires that name for the entry method. |
| `private static bool hasVisibleForm()` | none | `bool` | Helper. Returns `true` if at least one form in `Application.OpenForms` is visible. |

### 2.2 `ProductRatingSystem/Control/StartupControl.cs` (new)

**What it is for:** the Startup use case. It runs the start-up steps in the right order.

| Member | Parameters | Returns | What it does |
|---|---|---|---|
| `private string configFile` | – | – | Path of `config.txt`, next to the `.exe`. Set in the constructor. |
| `private Dictionary<string,string> settings` | – | – | Extra helper field. Holds the `key=value` lines read from `config.txt` (nothing uses them yet). |
| `StartupControl()` | none | – | Constructor. Sets `configFile` and creates the empty settings dictionary. |
| `public void initiate()` | none | nothing | Called by `StartupForm` when the Startup button is clicked. Runs `loadConfiguration()`, then `DBConnectorControl.initializeDB()`, then creates the login form and shows it with `Show()`. It does **not** call `Application.Run` (the message loop is already running). It does **not** catch errors: if `initializeDB()` throws, the exception goes back to `StartupForm`, which shows the message. |
| `private void loadConfiguration()` | none | nothing | Reads `config.txt` if it exists (lines like `key=value`, `#` starts a comment). If the file is missing, empty or unreadable, it silently uses the defaults. It never throws. |

`LoginForm` does not exist yet, so for now `initiate()` ends with `new Form1()` and `Show()`.
There is a `TODO` comment with the exact lines to change once Member 2 has written `LoginForm`
(see section 5, "Switching StartupControl to LoginForm").

### 2.3 `ProductRatingSystem/Control/DBConnectorControl.cs` (new)

**What it is for:** all database access. It uses SQLite through the NuGet package
`Microsoft.Data.Sqlite`. Every method opens its own connection inside a `using` block, and every
query uses parameters (`@name`) so user input can never change the SQL (SQL-injection safe).

**Field**

| Field | Description |
|---|---|
| `private string connectionString` | Points to `ProductRatingSystem.db` in `AppContext.BaseDirectory` (the `bin/Debug/net9.0-windows/` folder). Foreign keys are switched on and connection pooling is off (so the file is never left locked). |

**Public methods** (exactly as in the design)

| Method | Parameters | Returns | What it does |
|---|---|---|---|
| `initializeDB()` | none | `void` | Creates the 5 tables if they do not exist. If `USERACCOUNT` is empty, inserts the sample users and products. Safe to call on every start. |
| `getAccount(musername, mpasswordHash)` | `string`, `string` | `UserAccount` (or `null`) | Finds the user whose username **and** password hash both match. It does not hash anything; the caller passes the hash. Returns `null` when nothing matches. |
| `logSession(muserID, meventType, mtimestamp)` | `int`, `string`, `DateTime` | `void` | Adds a `SESSIONLOG` row for a known user. The username is looked up from the user ID. Used for `"LOGIN"` and `"LOGOUT"`. |
| `logSession(musername, meventType, mtimestamp)` | `string`, `string`, `DateTime` | `void` | Adds a `SESSIONLOG` row with the typed username and `userID = NULL`. Used for `"FAILED_LOGIN"`. |
| `getProducts()` | none | `ProductList` | All products. Used for the main menu after login. |
| `getProducts(muserID)` | `int` | `ProductList` | Looks up the user's role. **Seller** → the products that seller listed. **Customer** → the products this customer has **not** rated yet. Unknown user → empty list. |
| `saveProduct(muserID, mproduct)` | `int`, `Product` | `void` | Inserts the product with `sellerID = muserID` and `overallRating = 0`. The database assigns `productID`. |
| `getRatings(mproductID)` | `int` | `ProductRating` | Returns a blank rating for the RatingForm (`productID` set; `ratingID`, `userID`, `rating` all 0; no review; timestamp = now). **Nothing is saved.** |
| `saveReview(muserID, mproductID, mrating, mreview, mtimestamp)` | `int`, `int`, `int`, `string`, `DateTime` | `void` | Inserts the rating into `PRODUCTRATING` (`buyerID = muserID`) and inserts/updates the `PURCHASE` row with `rated = 1`. Both happen in one transaction (both succeed or neither). It does **not** recalculate the average. |
| `getReviews(mproductID)` | `int` | `ReviewList` | All ratings of that product, newest first. |
| `updateRating(mproductID, maverage)` | `int`, `double` | `void` | Sets `PRODUCT.overallRating`. The average is calculated by `RateProductControl`, not here. |

**Private helpers** (not part of the design, not callable by others): `openConnection`,
`runNonQuery`, `readProducts`, `insertSampleData`, `insertAccount`, `insertSampleProduct`,
`hashPassword`, `readString` (turns a NULL column into `""`), `toDb` (turns a C# `null` into
database NULL), `formatTimestamp`, `parseTimestamp`.

### 2.4 `ProductRatingSystem/ProductRatingSystem.csproj` (changed)

Two additions:
- `<PackageReference Include="Microsoft.Data.Sqlite" Version="9.0.23" />`. The target framework
  (`net9.0-windows`) was not changed. Version 9.0.23 was chosen on purpose: the newest version
  (11.x) only supports .NET 10, so it does not install on our .NET 9 project.
- `<None Update="Images\*.png">` with `CopyToOutputDirectory = PreserveNewest`. This copies every
  `.png` in the `Images/` folder next to the `.exe` when you build, so the Startup Page can load it.

### 2.5 `ProductRatingSystem/Boundary/StartupForm.cs` and `StartupForm.Designer.cs` (new)

**What it is for:** the Startup Page, the first window the user sees. It is a normal Visual Studio
form: `StartupForm.Designer.cs` holds the layout (`InitializeComponent`) and opens in the Visual
Studio designer; `StartupForm.cs` holds the logic. It is `public partial class StartupForm : Form`.

**Look** (all text black on white, as the RAD requires; window 600 x 780, `FixedSingle`, no maximize,
centered on screen, title "Product Rating System"), top to bottom and centered:
1. Title "PRODUCT RATING / SYSTEM": Times New Roman, bold, 28 pt.
2. Subtitle "Discover products and / view customer ratings": Segoe UI, 16 pt.
3. Three equal product cards with a thin light-grey border. Each has a picture (`PictureBox`,
   `Zoom`) and a star rating under it (Segoe UI Symbol, e.g. `★★★★☆`).
4. A "Startup" button: Times New Roman, bold, 14 pt.

The pictures and the star ratings (4, 3 and 5) are fixed showcase content. They do **not** come
from the database, because the database is not initialized until the button is clicked.

| Member | Parameters | Returns | What it does |
|---|---|---|---|
| `StartupForm()` | none | – | Constructor. Builds the controls and fills the three cards (picture + stars). |
| `public void display()` | none | nothing | Shows the form (`Show()`). |
| `public void close()` | none | nothing | Closes the form (`Close()`). |
| `private void startup()` | none | nothing | The Startup button logic. Disables the button, calls `new StartupControl().initiate()`, then calls `close()`. If an exception is thrown it shows a message box ("The system could not be started: …"), keeps the page open and enables the button again. |
| `private void startupButton_Click(sender, e)` | `object`, `EventArgs` | nothing | Button click event. Only calls `startup()`. |
| `private void showProduct(mpicture, mstars, mfileName, mrating)` | `PictureBox`, `Label`, `string`, `int` | nothing | Helper. Puts the image and the star text on one card. |
| `private Image loadImage(mfileName)` | `string` | `Image` | Helper. Loads `Images/<file>` next to the `.exe`. If the file is missing or broken it returns a light-grey picture instead of crashing. |
| `private void startupForm_FormClosed(sender, e)` | `object`, `FormClosedEventArgs` | nothing | Frees the three pictures when the form closes. |

### 2.6 `ProductRatingSystem/Images/` (new folder)

Contains `product1.png`, `product2.png`, `product3.png`: simple generated light-grey placeholder
pictures. **Replace them with real product photos** (keep the same file names). The build copies
them to `bin/Debug/net9.0-windows/Images/`. The pictures are shown square-ish (`Zoom`), so photos
of any size work.

---

## 3. How the files are connected

### 3.1 Startup chain

```
RatingSystem.Main()
   ├─ ApplicationConfiguration.Initialize()
   ├─ new StartupForm().display()                  the Startup Page appears
   └─ Application.Run(context)                     message loop starts
         │
         │   (user clicks the "Startup" button)
         ▼
   StartupForm.startup()
         ├─ disables the button
         ├─ new StartupControl().initiate()
         │      ├─ 1. loadConfiguration()          reads config.txt (or uses defaults)
         │      ├─ 2. new DBConnectorControl().initializeDB()
         │      │        creates tables + sample data (first run only)
         │      └─ 3. new Form1().Show()           later: new LoginForm().display()
         ├─ (on an exception: message box, page stays open, button enabled again)
         └─ close()                                 the Startup Page closes
```

### 3.2 How the app stays open (and when it ends)

Normally a WinForms program ends when its main form closes. Here the first window (Startup Page)
is replaced by the login form, which will later be replaced by the menus and back again, so no
single form can be the "main form". `RatingSystem.Main` solves it in one place:

1. `Application.Run(context)` is called with a plain `ApplicationContext` that has **no main
   form**. That means closing any one window does **not** end the program.
2. `Main` subscribes to `Application.Idle`. This event fires whenever the program has nothing
   left to process. The handler calls `hasVisibleForm()`; if no form in `Application.OpenForms`
   is visible, it calls `context.ExitThread()` and the program ends.
3. When one window replaces another the new form is shown **before** the old one is closed
   (as `StartupForm.startup()` does), and all of that happens inside one button click. The Idle
   event cannot fire in the middle of it, so the program never exits during the switch.
4. When the user closes the last visible window, the next Idle check finds nothing visible and
   the program ends.

Teammates' forms need **no special code** for this. They only have to show the next form with
`Show()` (or `display()`) and close or hide the old one afterwards. A form that is hidden with
`Hide()` does not count as visible, so if every form is hidden the program ends.

### 3.3 How rows become Entity objects

| Table | Entity class | Notes |
|---|---|---|
| `USERACCOUNT` | `UserAccount` | `userID, username, passwordHash, role` → constructor arguments in the same order. (`UserAccount` has no getter for the hash on purpose.) |
| `PRODUCT` | `Product` (many → `ProductList`) | `sellerID` → the `userID` argument, so **`Product.getUserID()` = the seller's ID**. |
| `PRODUCTRATING` | `ProductRating` (many → `ReviewList`) | `buyerID` → the `userID` argument, so **`ProductRating.getUserID()` = the buyer's ID**. |
| `PURCHASE`, `SESSIONLOG` | (no Entity class) | Only used inside `DBConnectorControl`. |

The same mapping works in reverse when saving: `saveProduct(muserID, …)` writes `muserID` into
`sellerID`, and `saveReview(muserID, …)` writes it into `buyerID`.

Things to know about the Entity constructors (they quietly ignore invalid values instead of
throwing): a blank `review` becomes `null`, a rating outside 1–5 stays 0, and a title/image/
description that is blank or too long becomes `null`. That is why `getRatings()` returns a
rating whose `getReview()` is `null` and `getRating()` is 0.

### 3.4 Who calls what (use cases)

This is how the teammates' classes are expected to use `DBConnectorControl`, in order. Check it
against the sequence diagrams in the RAD.

**Login – valid** (Member 2: `LoginForm` → `LoginControl`)
1. `LoginControl` hashes the typed password (code in section 5).
2. `getAccount(username, hash)` → returns a `UserAccount`.
3. `logSession(account.getUserID(), "LOGIN", DateTime.Now)`.
4. Menu: `getProducts()` (all products) or `getProducts(userID)` (seller's own / customer's unrated).

**Login – invalid** (Member 2)
1. `getAccount(username, hash)` → returns `null`.
2. `logSession(username, "FAILED_LOGIN", DateTime.Now)` (userID is stored as NULL).
3. The LoginForm shows an error message.

**Logout** (Member 2: `LogoutControl`)
1. `logSession(userID, "LOGOUT", DateTime.Now)`.
2. Return to the login screen.

**Add Product** (Member 3: `AddProductControl`, seller only)
1. The seller fills in the form; the control builds a `Product` (use `0` for `productID`/`userID`).
2. `saveProduct(sellerUserID, product)`.
3. `getProducts(sellerUserID)` to show the updated list.

**Rate Product** (Member 3: `RateProductControl`, customer only)
1. `getProducts(customerUserID)` → the products this customer has not rated yet.
2. Customer picks a product → `getRatings(productID)` → blank `ProductRating` for the RatingForm.
3. Customer submits → `saveReview(userID, productID, rating, review, DateTime.Now)`.
4. `getReviews(productID)` → all ratings → **the control calculates the average**.
5. `updateRating(productID, average)`.

### 3.5 Call-flow diagram

```
 Boundary (forms)        Control                        DBConnectorControl          SQLite file
 ----------------        -------                        ------------------          -----------
 (program start)  --->   RatingSystem.Main
 StartupForm      --->   StartupControl.initiate  --->  initializeDB()          --->  create tables
 (Startup button)                                                                     + sample data
 LoginForm        --->   LoginControl.login       --->  getAccount()            --->  USERACCOUNT
                                                  --->  logSession(...)         --->  SESSIONLOG
 Menus            --->   (menu code)              --->  getProducts()/(userID)  --->  PRODUCT, PURCHASE
 AddProductForm   --->   AddProductControl        --->  saveProduct()           --->  PRODUCT
 RatingForm       --->   RateProductControl       --->  getRatings()                  (nothing saved)
                                                  --->  saveReview()            --->  PRODUCTRATING + PURCHASE
                                                  --->  getReviews()            --->  PRODUCTRATING
                                                  --->  updateRating()          --->  PRODUCT
 Logout           --->   LogoutControl            --->  logSession(...)         --->  SESSIONLOG
```

---

## 4. Database

File: `ProductRatingSystem.db`. Timestamps are stored as ISO-8601 text, e.g. `2026-11-18T16:26:24`.
PK = primary key, FK = foreign key.

**USERACCOUNT**

| Column | Type / key | Notes |
|---|---|---|
| `userID` | INTEGER, PK, autoincrement | |
| `username` | TEXT, unique | |
| `passwordHash` | TEXT | SHA-256 hex, never the plain password |
| `role` | TEXT | `"Customer"` or `"Seller"` |

Written by: `initializeDB` (sample data). Read by: `getAccount`, `getProducts(muserID)`, `logSession(int…)`.

**PRODUCT**

| Column | Type / key | Notes |
|---|---|---|
| `productID` | INTEGER, PK, autoincrement | |
| `title`, `image`, `description` | TEXT | `image` is just a text path/name |
| `price` | REAL | |
| `overallRating` | REAL, default 0 | |
| `sellerID` | INTEGER, FK → `USERACCOUNT.userID` | |

Written by: `initializeDB`, `saveProduct`, `updateRating`. Read by: both `getProducts`.

**PRODUCTRATING**

| Column | Type / key | Notes |
|---|---|---|
| `ratingID` | INTEGER, PK, autoincrement | |
| `rating` | INTEGER | 1–5 |
| `review` | TEXT | |
| `timestamp` | TEXT | |
| `buyerID` | INTEGER, FK → `USERACCOUNT.userID` | |
| `productID` | INTEGER, FK → `PRODUCT.productID` | |

Written by: `saveReview`. Read by: `getReviews`.

**PURCHASE**

| Column | Type / key | Notes |
|---|---|---|
| `buyerID` | INTEGER, FK → `USERACCOUNT.userID` | part of the PK |
| `productID` | INTEGER, FK → `PRODUCT.productID` | part of the PK |
| `rated` | INTEGER, default 0 | 1 = this buyer has rated this product |

Primary key is `(buyerID, productID)`. Written by: `saveReview` (insert, or update to `rated = 1`).
Read by: `getProducts(muserID)` for customers (products with no `rated = 1` row are the "unreviewed" ones).

**SESSIONLOG**

| Column | Type / key | Notes |
|---|---|---|
| `sessionID` | INTEGER, PK, autoincrement | |
| `username` | TEXT | |
| `eventType` | TEXT | `"LOGIN"`, `"LOGOUT"`, `"FAILED_LOGIN"` |
| `timestamp` | TEXT | |
| `userID` | INTEGER, FK → `USERACCOUNT.userID`, may be NULL | NULL for failed logins |

Written by: both `logSession` methods. Nothing reads it (it is only a log).

**Sample data** (inserted only when `USERACCOUNT` is empty): users `customer1` and `seller1`, and
three products listed by `seller1` (Wireless Headphones, Mechanical Keyboard, USB-C Charger),
all with `overallRating` 0.

---

## 5. For teammates

### Public methods of `DBConnectorControl`

Add `using ProductRatingSystem.Control;` (and `.Entity`) and create it with `new DBConnectorControl()`.
Every instance uses the same database file.

| Method | Returns | Use it for |
|---|---|---|
| `initializeDB()` | `void` | Called by `StartupControl` only. |
| `getAccount(string musername, string mpasswordHash)` | `UserAccount` / `null` | Login check. Pass the **hash**, not the password. |
| `logSession(int muserID, string meventType, DateTime mtimestamp)` | `void` | `"LOGIN"` / `"LOGOUT"` for a known user. |
| `logSession(string musername, string meventType, DateTime mtimestamp)` | `void` | `"FAILED_LOGIN"`. |
| `getProducts()` | `ProductList` | All products. |
| `getProducts(int muserID)` | `ProductList` | Seller: own products. Customer: not-yet-rated products. |
| `saveProduct(int muserID, Product mproduct)` | `void` | Add Product. |
| `getRatings(int mproductID)` | `ProductRating` | Blank rating for the RatingForm (not saved). |
| `saveReview(int muserID, int mproductID, int mrating, string mreview, DateTime mtimestamp)` | `void` | Save a customer's rating. |
| `getReviews(int mproductID)` | `ReviewList` | All reviews of a product. |
| `updateRating(int mproductID, double maverage)` | `void` | Store the new average (you calculate it). |

### Password hashing (LoginControl must use exactly this)

```csharp
using System.Security.Cryptography;
using System.Text;

string passwordHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
```

Then call `getAccount(username, passwordHash)`. The hash is **uppercase** hex. Case matters.

### Sample login accounts

| Username | Password | Role |
|---|---|---|
| `customer1` | `pass123` | Customer |
| `seller1` | `pass123` | Seller |

### Where is the database, and how to reset it

The file `ProductRatingSystem.db` is created the first time the app runs, in
`ProductRatingSystem/bin/Debug/net9.0-windows/` (next to the `.exe`). It is inside `bin/`, so
Git ignores it and it is never committed. Every teammate has their own copy.
To reset it to the original sample data: **close the app, delete `ProductRatingSystem.db`, and run the app again.**
(If Windows says the file is "being used by another process", close DB Browser for SQLite or any
other program that has it open.) The file is only created when the **Startup** button is clicked,
not when the Startup Page opens.

### Form rules (all forms use the same look)

- Size: `ClientSize` **600 x 780** (portrait).
- `FormBorderStyle = FixedSingle`, `MaximizeBox = false`, `StartPosition = CenterScreen`.
- `BackColor = White` and all text `ForeColor = Black` (RAD requirement).
- To get the same look, copy the settings from `Boundary/StartupForm.Designer.cs`
  (the part under `// StartupForm`).
- Closing windows: just `Show()` the next form and `Close()` the old one. You do **not** need to
  call `Application.Exit()` or anything else; `RatingSystem` ends the program when the last visible
  window closes (section 3.2).

### Switching StartupControl to LoginForm

`LoginForm` must be a `Form` in `ProductRatingSystem.Boundary` with a `display()` method. When it
exists, open `Control/StartupControl.cs`, add `using ProductRatingSystem.Boundary;` at the top, and
in `initiate()` replace

```csharp
Form1 loginForm = new Form1();
loginForm.Show();
```

with

```csharp
LoginForm loginForm = new LoginForm();
loginForm.display();
```

(`display()` must call `Show()`, not `ShowDialog()`/`Application.Run`.) Nothing else changes.

---

## 6. How to test it myself in Visual Studio

1. Open `ProductRatingSystem.sln`, build with **Ctrl+Shift+B**. It should say 0 errors
   (some warnings about nullable types are normal).
2. Press **F5**. The **Startup Page** opens (title, subtitle, three product cards, Startup button).
   At this point there is no database file yet.
3. Click **Startup**. The Startup Page closes and an empty `Form1` window opens (it will be the
   login form later). That means the startup chain worked. Then close `Form1`: the program must end
   (the debugger stops). Open `bin/Debug/net9.0-windows/`: `ProductRatingSystem.db` should now exist.
   To see the error handling, create a **folder** named `ProductRatingSystem.db` there, run the
   app and click Startup: a message box appears, the Startup Page stays open and the button works
   again. (Delete the folder afterwards.)
4. Look inside the database: install the free **DB Browser for SQLite**, open the `.db` file,
   and check the tables and the sample rows (2 users, 3 products).
   To see the reset, delete the file and press F5 again.
5. To try the methods before the other screens exist, temporarily add a few lines in
   `StartupControl.initiate()` after `initializeDB()`, for example:
   ```csharp
   var account = db.getAccount("seller1", Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes("pass123"))));
   MessageBox.Show(account == null ? "not found" : account.getUsername() + " / " + account.getRole());
   MessageBox.Show("Products: " + db.getProducts().getCount());
   ```
   (add `using System.Security.Cryptography; using System.Text;` at the top.) **Remove these
   lines again before committing.**
6. Put a breakpoint (F9) on a line inside `DBConnectorControl` and step through with F10/F11.
7. Test `loadConfiguration`: create `config.txt` next to the `.exe` (e.g. `name=test`), or leave
   it out. The app must start either way.
