# Member 1 – Database and Startup (explanation, final version)

For the whole project (every class and file) read `PROJECT_OVERVIEW.md` in the repository root
(one folder up). This file explains
**Member 1's part** and lists every change made at the end of the project, including the small
changes made to teammates' files.

## 1. Overview

Member 1's part has two jobs.

1. **DBConnectorControl** is the only class that talks to the SQLite database. It creates the
   tables, adds sample data, and turns database rows into the Entity objects (`UserAccount`,
   `Product`, `ProductRating`, `ProductList`, `ReviewList`) that everyone else uses. Nobody else
   writes SQL: teammates just call its methods.
2. The **Startup use case** (`RatingSystem` → `StartupForm` → `StartupControl`) starts the program,
   shows the **Startup Page**, and when the user clicks **Startup** it prepares the database and
   opens the **Login** page. `RatingSystem` also makes sure the program ends only when the last
   window is closed.

---

## 2. Summary of the final changes

### 2.1 Member 1's own files
| Area | Final state |
|---|---|
| Startup flow | `Main` shows `StartupForm`; the **Startup** button runs `StartupControl.initiate()`, which opens `LoginForm`. (Earlier versions opened an empty `Form1`.) |
| App lifetime | One central rule in `RatingSystem`: the program ends when no visible form is left. |
| Startup Page look | Title "PRODUCT RATING / SYSTEM" Times New Roman Bold **40 pt**; subtitle Segoe UI **20 pt** with extra space around it; three showcase product cards; **Startup** button in the shared outline-button style. `StartupForm` now inherits `ApplicationForm`. |
| `StartupControl` | Inherits `Controller` (empty base class) and has its own `db` field; opens `LoginForm` with `display()`. |
| Sample data | **6 users** (3 customers, 3 sellers) and 3 products. |
| Images | `Images/` now holds `product1-3.png` (Startup Page) and `headphones.png`, `keyboard.png`, `charger.png` (sample products). |
| `.csproj` | `Microsoft.Data.Sqlite 9.0.23`, `<None Update="Images\*.png">` (copy to output), `EnableWindowsTargeting` (added by a teammate). |
| Deleted | `Form1.cs`, `Form1.Designer.cs`, `Form1.resx` (old default form) and the empty `mainmenu.md`. |

### 2.2 Changes made to the whole interface (touching teammates' files)
| Change | Files |
|---|---|
| **Same window size for every form**: 600 × 780 client area, fixed border, no maximize, centered. Set once in the base class; the menus and Login no longer set their own size. | `ApplicationForm.cs` (`FormClientSize`), `CustomerMenu.cs`, `SellerMenu.cs`, `LoginForm.Designer.cs`, `AddProductForm.Designer.cs`, `RatingForm.Designer.cs` |
| **Login page:** bigger Times New Roman title (two lines like the Startup Page), a user symbol under it (black since the RAD change, section 2.3), then Username, Password, Login, with space between the sections. | `LoginForm.Designer.cs`, `LoginForm.cs` |
| **Menus:** a boxed grey top bar with the user name on the left and the buttons on the right (Seller: `[Add Product] [Logout]`, Customer: `[Logout]`); a second boxed bar with the page title on the left and **Count** on the right; boxes line up with the product cards. The header code is shared in `MainMenu`. | `MainMenu.cs`, `SellerMenu.cs`, `CustomerMenu.cs`, `LoginForm.cs` (passes the customer's name) |
| **Product card:** price in a box; the Overall Rating bar has the text on the left and the stars on the right. | `ProductCard.cs`, `ProductCard.Designer.cs` |
| **Light-grey top bars** on the Add Product and Rate Product pages. | `AddProductForm.Designer.cs`, `RatingForm.Designer.cs` |
| **Rate Product page:** a box around the Rating row (caption, 5 stars, "(not selected)"). | `RatingForm.Designer.cs` |
| **One button style everywhere:** white rectangle, dark thin border, black text. A focused or clicked button keeps the same 1 px border (Windows normally draws it thicker). | `ApplicationForm.cs` (`StyleSecondaryButton`) |

### 2.3 Changes made to match RAD_V5 (latest)
The colours "grey top bars" and "blue text" above were later replaced: the design document asks for
black text on a white background. The code was also changed to follow the RAD class diagrams and
sequence diagrams. Full list: `PROJECT_OVERVIEW.md` section 12. In short:

| Change | Files |
|---|---|
| `UiTheme` was merged into `ApplicationForm` (colours `TextColor`, `MutedTextColor`, `ButtonTextColor`..., fonts, `StyleSecondaryButton`) and **deleted**; all forms use `ApplicationForm.` instead of `UiTheme.`. Everything is white with black text. | `ApplicationForm.cs`, `UiTheme.cs` (deleted), all forms, `ProductCard.cs` |
| `ApplicationForm` now has `display()` / `close()` for every form (`AddProductForm` and `RatingForm` override them). `StartupForm` lost its own copies. | `ApplicationForm.cs`, `StartupForm.cs`, `AddProductForm.cs`, `RatingForm.cs` |
| `Controller` is now an **empty** base class; `DBConnectorControl : Controller`; every control (`StartupControl`, `LoginControl`, `LogoutControl`, `AddProductControl`, `RateProductControl`) has its own `private DBConnectorControl db`. | `Controller.cs`, `DBConnectorControl.cs`, the five controls |
| Login: `LoginControl.submit()` + `validate()` (username ≤ 50, password ≤ 100, field-specific messages); the control opens the menu, `LoginForm.openMenu` was removed; `LoginForm.submit()` and `display(string)` added. | `LoginControl.cs`, `LoginForm.cs` |
| Logout: `LogoutControl(MainMenu)`, closes the menu first, `clearSession()`, Login shows "You have been logged out." | `LogoutControl.cs`, `MainMenu.cs` |
| Menus: `MainMenu` keeps `username` and `productList` private (accessors), has abstract `display(ProductList, string)`; `SellerMenu` no longer reads the database (`setReviews`; the controls load the reviews); `CustomerMenu.selectProduct()` has no parameter. | `MainMenu.cs`, `SellerMenu.cs`, `CustomerMenu.cs`, `AddProductControl.cs` |
| Error messages never show exception text (Startup, Add Product, Rate Product). | `StartupForm.cs`, `AddProductControl.cs`, `RateProductControl.cs` |
| The product's overall rating is stored as the exact average (no rounding). | `RateProductControl.cs` |
| Removed unused `using` lines. | the five Entity files |

**Not changed:** the Startup Page and **Startup** button (kept on purpose), the database tables and
`DBConnectorControl` methods, the Entity logic.

---

## 3. File by file (Member 1's files)

### 3.1 `ProductRatingSystem/RatingSystem.cs` (renamed from `Program.cs`)
**What it is for:** the entry point of the program. Windows runs `Main` first. `public static
class RatingSystem` in the root namespace.

| Member | Parameters | Returns | What it does |
|---|---|---|---|
| `static void Main()` | none | nothing | Calls `ApplicationConfiguration.Initialize()`. Creates an `ApplicationContext` (a message loop with no main form), adds an `Application.Idle` check that calls `context.ExitThread()` when no visible form is left, shows `new StartupForm().display()`, then runs `Application.Run(context)`. `[STAThread]`; it must be named `Main`. |
| `private static bool hasVisibleForm()` | none | `bool` | `true` if at least one form in `Application.OpenForms` is visible. |

### 3.2 `ProductRatingSystem/Control/StartupControl.cs`
**What it is for:** the Startup use case. `public class StartupControl : Controller`.

| Member | Parameters | Returns | What it does |
|---|---|---|---|
| `private string configFile` | – | – | Path of `config.txt` next to the `.exe`. |
| `private Dictionary<string,string> settings` | – | – | Helper: the `key=value` lines read from `config.txt` (nothing uses them yet). |
| `private DBConnectorControl db` | – | – | Its own database connector (`Controller` has no members). |
| `StartupControl()` | none | – | Constructor. Sets `configFile`. |
| `public void initiate()` | none | nothing | Called by `StartupForm`. Runs `loadConfiguration()`, `db.initializeDB()`, then `new LoginForm().display()`. It does not call `Application.Run` (the loop is already running) and does not catch errors: `StartupForm` shows them. |
| `private void loadConfiguration()` | none | nothing | Reads `config.txt` if it exists (`key=value`, `#` = comment). A missing or unreadable file is ignored. Never throws. |

### 3.3 `ProductRatingSystem/Control/DBConnectorControl.cs`
**What it is for:** all database access (SQLite via `Microsoft.Data.Sqlite`). `public class
DBConnectorControl : Controller`. Each method opens its
own connection in a `using` block; every query uses parameters (`@name`), so user input cannot
change the SQL.

| Field | Description |
|---|---|
| `private string connectionString` | `ProductRatingSystem.db` in `AppContext.BaseDirectory`; foreign keys on; connection pooling off (the file is never left locked). |

| Method | Parameters | Returns | What it does |
|---|---|---|---|
| `initializeDB()` | none | `void` | Creates the 5 tables if missing; if `USERACCOUNT` is empty, inserts the sample data (section 5). Safe on every start. |
| `getAccount(musername, mpasswordHash)` | `string`, `string` | `UserAccount` / `null` | User whose username **and** hash match. Does not hash. |
| `logSession(muserID, meventType, mtimestamp)` | `int`, `string`, `DateTime` | `void` | Log row for a known user (`LOGIN`, `LOGOUT`). |
| `logSession(musername, meventType, mtimestamp)` | `string`, `string`, `DateTime` | `void` | Log row with `userID = NULL` (`FAILED_LOGIN`). |
| `getProducts()` | none | `ProductList` | All products. |
| `getProducts(muserID)` | `int` | `ProductList` | Seller → own products. Customer → products **not yet rated**. Unknown user → empty list. |
| `saveProduct(muserID, mproduct)` | `int`, `Product` | `void` | Inserts with `sellerID = muserID`, `overallRating = 0`. |
| `getRatings(mproductID)` | `int` | `ProductRating` | A blank rating for the Rating Page. **Nothing is saved.** |
| `saveReview(muserID, mproductID, mrating, mreview, mtimestamp)` | `int`, `int`, `int`, `string`, `DateTime` | `void` | Inserts the rating and sets `PURCHASE.rated = 1` in one transaction. Does not calculate the average. |
| `getReviews(mproductID)` | `int` | `ReviewList` | All ratings of the product, newest first. |
| `updateRating(mproductID, maverage)` | `int`, `double` | `void` | Sets `PRODUCT.overallRating` (the average is calculated by `RateProductControl`). |

Private helpers: `openConnection`, `runNonQuery`, `readProducts`, `insertSampleData`,
`insertAccount`, `insertSampleProduct`, `hashPassword`, `readString` (NULL → `""`), `toDb` (C# `null`
→ database NULL), `formatTimestamp`, `parseTimestamp`.

### 3.4 `ProductRatingSystem/Boundary/StartupForm.cs` and `StartupForm.Designer.cs`
**What it is for:** the Startup Page, the first window. `public partial class StartupForm :
ApplicationForm` (so it gets the standard 600 × 780 window). The Designer file holds the layout.

Layout (top to bottom, centered): title "PRODUCT RATING / SYSTEM" (Times New Roman Bold 40 pt,
black); subtitle "Discover products and / view customer ratings" (Segoe UI 20 pt); three product
cards (picture, `Zoom`, plus stars `★★★★☆`); **Startup** button. The pictures and the star values
(4, 3, 5) are fixed showcase content, not from the database (it does not exist yet).

| Member | Returns | What it does |
|---|---|---|
| `StartupForm()` | – | Builds the page, styles the button, fills the three cards. |
| `display()` / `close()` | `void` | Inherited from `ApplicationForm` (`Show()` / `Close()`). |
| `private void startup()` | `void` | Disables the button, calls `new StartupControl().initiate()`, then `close()`. On an exception: message box "The system could not be started. Please close the program and try again." (no exception text), page stays open, button enabled again. |
| `private void startupButton_Click(sender, e)` | `void` | Calls `startup()`. |
| `private void showProduct(mpicture, mstars, mfileName, mrating)` | `void` | Fills one card. |
| `private Image loadImage(mfileName)` | `Image` | Loads `Images/<file>` next to the `.exe`; grey picture if missing. |
| `private void startupForm_FormClosed(sender, e)` | `void` | Frees the three pictures. |

### 3.5 `ProductRatingSystem/Images/`
| File | Used by |
|---|---|
| `product1.png`, `product2.png`, `product3.png` | The three showcase cards on the Startup Page. |
| `headphones.png`, `keyboard.png`, `charger.png` | The 3 sample products (their database paths are `images/headphones.png` etc.; Windows ignores upper/lower case in folder names). |

The `.csproj` copies every `Images\*.png` to `bin/Debug/net9.0-windows/Images/` when you build.
Only `.png` is copied. Products added by sellers are stored in `Images/Products/` next to the `.exe`.

### 3.6 `ProductRatingSystem/ProductRatingSystem.csproj`
- `Microsoft.Data.Sqlite` **9.0.23** (version 11.x only supports .NET 10).
- `<None Update="Images\*.png">` with `CopyToOutputDirectory = PreserveNewest`.
- `EnableWindowsTargeting` (added by a teammate), target framework `net9.0-windows` unchanged.

### 3.7 Deleted files
`Form1.cs`, `Form1.Designer.cs`, `Form1.resx` (the old default form, no longer used) and
`mainmenu.md` (empty).

---

## 4. How the files are connected

### 4.1 Startup chain
```
RatingSystem.Main()
   ├─ ApplicationConfiguration.Initialize()
   ├─ new StartupForm().display()                  the Startup Page appears
   └─ Application.Run(context)                     message loop starts
         │   (user clicks "Startup")
         ▼
   StartupForm.startup()
         ├─ disables the button
         ├─ new StartupControl().initiate()
         │      ├─ 1. loadConfiguration()          reads config.txt (or uses defaults)
         │      ├─ 2. db.initializeDB()            creates tables + sample data (first run)
         │      └─ 3. new LoginForm().display()    the Login page appears
         ├─ (on an exception: message box, page stays open, button enabled again)
         └─ close()                                 the Startup Page closes
```

### 4.2 How the app stays open (and when it ends)
A WinForms program normally ends when its main form closes. Here one window is replaced by another
(Startup → Login → menu → Login …), so there is no single main form. `RatingSystem.Main` therefore:
1. runs `Application.Run(context)` with a plain `ApplicationContext` that has **no main form**, so
   closing one window does not end the program;
2. listens to `Application.Idle` (fires when there is nothing left to process) and calls
   `context.ExitThread()` when `hasVisibleForm()` is `false`.

Because a new form is shown **before** the old one is closed, inside one click, the Idle check
never sees "no window" during a switch. When the user closes the last window, the program ends.
Other forms need no special code: show the next form, then close the old one. A form that is only
hidden (`Hide()`) does not count as visible.

### 4.3 How database rows become Entity objects
| Table | Entity class | Notes |
|---|---|---|
| `USERACCOUNT` | `UserAccount` | `userID, username, passwordHash, role` (no getter for the hash). |
| `PRODUCT` | `Product` → `ProductList` | `sellerID` → `getUserID()` = the **seller's** ID. |
| `PRODUCTRATING` | `ProductRating` → `ReviewList` | `buyerID` → `getUserID()` = the **buyer's** ID. |
| `PURCHASE`, `SESSIONLOG` | – | Only used inside `DBConnectorControl`. |

The Entity constructors silently ignore invalid values (a blank review becomes `null`, a rating
outside 1–5 stays 0, a blank title becomes `null`), so `getRatings()` returns a rating whose
`getReview()` is `null`.

### 4.4 Who calls `DBConnectorControl`, in order (final code)
**Login – valid:** `LoginControl.submit` → `getAccount` → `logSession(userID,"LOGIN")` →
`getProducts(userID)` (sellers: `getReviews(productID)` for each product) → the control opens the menu.
**Login – invalid:** `getAccount` returns `null` → `logSession(username,"FAILED_LOGIN")`.
**Logout:** `LogoutControl.logout(userID)` → `logSession(userID,"LOGOUT")`.
**Seller page:** the control that opens it (`LoginControl` or `AddProductControl`) calls
`getReviews(productID)` for each product and hands the result over with `SellerMenu.setReviews`.
**Add Product:** `AddProductControl.submit` → `saveProduct(userID, product)` → `getProducts(userID)` +
`getReviews(...)`.
**Rate Product:** `RateProductControl.rateProduct` → `getRatings(productID)` + `getProducts(userID)`;
`submit` → `saveReview(...)` → `getReviews(productID)` → (average calculated in the control) →
`updateRating(productID, average)` → `getProducts(userID)`.

### 4.5 Call-flow diagram
```
 Boundary (forms)        Control                        DBConnectorControl          SQLite file
 ----------------        -------                        ------------------          -----------
 (program start)  --->   RatingSystem.Main
 StartupForm      --->   StartupControl.initiate  --->  initializeDB()          --->  create tables
 (Startup button)                                                                     + sample data
 LoginForm        --->   LoginControl.submit      --->  getAccount()            --->  USERACCOUNT
                                                  --->  logSession(...)         --->  SESSIONLOG
                                                  --->  getProducts(userID)     --->  PRODUCT, PURCHASE
 AddProductForm   --->   AddProductControl        --->  saveProduct()           --->  PRODUCT
 RatingForm       --->   RateProductControl       --->  getRatings()                  (nothing saved)
                                                  --->  saveReview()            --->  PRODUCTRATING + PURCHASE
                                                  --->  getReviews()            --->  PRODUCTRATING
                                                  --->  updateRating()          --->  PRODUCT
 Logout           --->   LogoutControl            --->  logSession(...)         --->  SESSIONLOG
```

---

## 5. Database

File `ProductRatingSystem.db`. Timestamps are ISO-8601 text, e.g. `2026-11-20T14:05:09`.
PK = primary key, FK = foreign key.

| Table | Columns | Written by | Read by |
|---|---|---|---|
| `USERACCOUNT` | `userID` PK auto, `username` unique, `passwordHash`, `role` | `initializeDB` | `getAccount`, `getProducts(muserID)`, `logSession(int…)` |
| `PRODUCT` | `productID` PK auto, `title`, `image`, `description`, `price`, `overallRating` (default 0), `sellerID` FK | `initializeDB`, `saveProduct`, `updateRating` | both `getProducts` |
| `PRODUCTRATING` | `ratingID` PK auto, `rating`, `review`, `timestamp`, `buyerID` FK, `productID` FK | `saveReview` | `getReviews` |
| `PURCHASE` | `buyerID` FK, `productID` FK, `rated`; PK (`buyerID`,`productID`) | `saveReview` | `getProducts(muserID)` (customers) |
| `SESSIONLOG` | `sessionID` PK auto, `username`, `eventType`, `timestamp`, `userID` FK (NULL allowed) | both `logSession` | – |

**Sample data** (only inserted when `USERACCOUNT` is empty; password for every account `pass123`):

| Username | Role |
|---|---|
| `customer1`, `customer2`, `customer3` | Customer |
| `seller1`, `seller2`, `seller3` | Seller |

Products: *Wireless Headphones* ($79.99), *Mechanical Keyboard* ($59.50), *USB-C Charger* ($24.99),
all listed by `seller1` with `overallRating` 0. `seller2` and `seller3` start with no products.
Passwords are stored only as a hash.

---

## 6. For teammates

### Public methods of `DBConnectorControl`
Create it with `new DBConnectorControl()` in a control class (`private DBConnectorControl db = new
DBConnectorControl();`). Forms never use it directly.

| Method | Returns | Use it for |
|---|---|---|
| `initializeDB()` | `void` | `StartupControl` only. |
| `getAccount(string musername, string mpasswordHash)` | `UserAccount` / `null` | Login check (pass the **hash**). |
| `logSession(int muserID, string meventType, DateTime mtimestamp)` | `void` | `"LOGIN"` / `"LOGOUT"`. |
| `logSession(string musername, string meventType, DateTime mtimestamp)` | `void` | `"FAILED_LOGIN"`. |
| `getProducts()` | `ProductList` | All products. |
| `getProducts(int muserID)` | `ProductList` | Seller: own products. Customer: not yet rated. |
| `saveProduct(int muserID, Product mproduct)` | `void` | Add Product. |
| `getRatings(int mproductID)` | `ProductRating` | Blank rating for the Rating Page. |
| `saveReview(int muserID, int mproductID, int mrating, string mreview, DateTime mtimestamp)` | `void` | Save a rating. |
| `getReviews(int mproductID)` | `ReviewList` | All reviews of a product. |
| `updateRating(int mproductID, double maverage)` | `void` | Store the new average. |

### Password hashing (the login code must use exactly this)
```csharp
using System.Security.Cryptography;
using System.Text;

string passwordHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
```
The hash is **uppercase** hex; case matters.

### Where is the database, and how to reset it
`ProductRatingSystem.db` is created when **Startup** is clicked, in
`ProductRatingSystem/bin/Debug/net9.0-windows/` (Git ignores it). To reset to the sample data:
**close the app, delete `ProductRatingSystem.db`, run the app again.** (If Windows says the file is
in use, close DB Browser for SQLite or any other program that has it open.) Delete the file also
when you change the sample data in `insertSampleData`; it is only inserted into an empty database.

### Adding pictures to the sample products
Put `headphones.png`, `keyboard.png` and `charger.png` in `ProductRatingSystem/Images/` (exact
names), then build. For other names, change the three paths in `insertSampleData` and reset the
database. Only `.png` files are copied to the output folder.

### Form rules (every page looks the same)
- Inherit from `ApplicationForm`. It sets the client size **600 × 780**, `FixedSingle` border, no
  maximize, `CenterScreen`. Do **not** set `Size`, `ClientSize` or `FormBorderStyle` yourself.
- Style buttons with `StyleSecondaryButton(button)` (white, dark thin border, black text).
  `StylePrimaryButton` gives the same look.
- Use the colours and fonts that `ApplicationForm` provides (`TextColor`, `BodyFont`, ...; top bars use
  `HeaderBackground`). Everything is black text on white.
- Show messages with fixed texts; never show `ex.Message` to the user.
- To change windows: `Show()` the next form, then `Close()` the old one. No `Application.Exit()`
  is needed; `RatingSystem` ends the program when the last visible window closes (section 4.2).
- Exception: `AddProductForm` and `RatingForm` shrink themselves only if the screen is smaller than
  the form (for example a laptop at 150% display scaling) and then scroll.

---

## 7. How to test it in Visual Studio

1. Open `ProductRatingSystem.sln`, build with **Ctrl+Shift+B** (0 errors; nullable-type warnings are
   normal).
2. Press **F5**. The **Startup Page** opens; there is no database file yet.
3. Click **Startup**. The Startup Page closes and the **Login** page opens. Open
   `bin/Debug/net9.0-windows/`: `ProductRatingSystem.db` now exists.
4. Log in as `seller1` / `pass123` (Seller page with 3 products) or `customer1` / `pass123`
   (Customer page). Try **Add Product**, **Rate Product**, the **Reviews** button and **Logout**.
5. Close the last window: the program must end (the debugger stops).
6. Error case: create a **folder** named `ProductRatingSystem.db` next to the `.exe`, run and click
   Startup: a message box appears, the Startup Page stays open and the button works again. Delete
   the folder afterwards.
7. Look at the data: open the `.db` file in **DB Browser for SQLite** (6 users, 3 products; after
   using the app, also `PRODUCTRATING`, `PURCHASE` and `SESSIONLOG` rows).
8. `config.txt` next to the `.exe` is optional (`name=test`); the app starts with or without it.
