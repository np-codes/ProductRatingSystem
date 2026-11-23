# Product Rating System – Project Overview

CSCI 4711 Software Engineering team project. A Windows desktop application (C#, Windows Forms,
.NET 9) where **Sellers** list products and **Customers** rate and review them. Data is stored in a
local SQLite database file.

This file explains the whole project: what every file is for, what every class contains, which
object creates which, and how a click on a button travels through the program. For Member 1's own
notes (database, startup, final changes) see `Work_Explanation/MEMBER1_EXPLANATION.md`; for the
other members see `Work_Explanation/MEMBER2_EXPLANATION.md` and
`Work_Explanation/MEMBER3_EXPLANATION.md`.

---

## 1. What the program does

| Who | What they can do |
|---|---|
| Anyone | See the Startup Page, press **Startup**, and log in. |
| **Customer** | See the list of products they have **not rated yet**, press **Rate Product**, give 1–5 stars and a written review. Log out. |
| **Seller** | See their own products with their overall rating and all reviews. **Add Product** (title, picture, description, price). Log out. |

Every login, failed login and logout is written to a log table (`SESSIONLOG`). Passwords are never
stored; only a SHA-256 hash is.

### Technology
- C# on **.NET 9** (`net9.0-windows`), **Windows Forms** for the screens.
- **SQLite** through the NuGet package `Microsoft.Data.Sqlite` (version 9.0.23, the newest that
  supports .NET 9).
- Visual Studio 2022 (".NET desktop development" workload).

### Quick start
1. Open `ProductRatingSystem.sln` in Visual Studio and press **Ctrl+Shift+B** (build) then **F5** (run).
2. The **Startup Page** opens. Click **Startup**. The database is created and the **Login** page opens.
3. Log in with one of the sample accounts (password for all: `pass123`):

| Username | Role |
|---|---|
| `customer1`, `customer2`, `customer3` | Customer |
| `seller1`, `seller2`, `seller3` | Seller |

The 3 sample products belong to `seller1`; `seller2` and `seller3` start with no products.

**Database file:** `ProductRatingSystem.db`, created next to the `.exe` (in
`ProductRatingSystem/bin/Debug/net9.0-windows/`). It is inside `bin/`, so Git ignores it.
**To reset everything:** close the app (and any program that has the file open, such as DB Browser
for SQLite), delete that file, and start the app again.

---

## 2. Folder and file map

```
ProductRatingSystem/                      (repository root)
├── ProductRatingSystem.sln               Visual Studio solution (lists the project and README.md)
├── README.md                             Team work split, coding rules, git commands
├── PROJECT_OVERVIEW.md                   This file
├── Work_Explanation/                     Each member's explanation of their own work
│   ├── MEMBER1_EXPLANATION.md            Member 1 (Nisarg Patel): database, startup, final changes
│   ├── MEMBER2_EXPLANATION.md            Member 2 (Dean Thompson): login, logout, menus
│   └── MEMBER3_EXPLANATION.md            Member 3 (Daniel Reed): add product, rate product
├── .gitignore                            Files Git must not track (bin/, obj/, *.user, *.db ...)
└── ProductRatingSystem/                  The C# project
    ├── ProductRatingSystem.csproj        Project settings, NuGet package, image copy rule
    ├── ProductRatingSystem.csproj.user   Visual Studio personal settings (ignored by Git)
    ├── RatingSystem.cs                   Program entry point (Main)
    ├── Entity/                           DATA classes (no screens, no database)
    │   ├── UserAccount.cs
    │   ├── Product.cs
    │   ├── ProductRating.cs
    │   ├── ProductList.cs
    │   └── ReviewList.cs
    ├── Control/                          LOGIC classes (one per use case + database)
    │   ├── Controller.cs                 Base class: gives a controller its DBConnectorControl
    │   ├── DBConnectorControl.cs         The only class that talks to SQLite
    │   ├── StartupControl.cs             Startup use case
    │   ├── LoginControl.cs               Login use case
    │   ├── LogoutControl.cs              Logout use case
    │   ├── AddProductControl.cs          Add Product use case
    │   └── RateProductControl.cs         Rate Product use case
    ├── Boundary/                         SCREEN classes (Windows Forms)
    │   ├── ApplicationForm.cs            Base form: same size, font and colours for every window
    │   ├── UiTheme.cs                    Shared colours, fonts and button style
    │   ├── StartupForm.cs / .Designer.cs / .resx
    │   ├── LoginForm.cs / .Designer.cs / .resx
    │   ├── MainMenu.cs                   Base class of the two menus (header, heading, logout)
    │   ├── CustomerMenu.cs               Customer page
    │   ├── SellerMenu.cs                 Seller page
    │   ├── ProductCard.cs / .Designer.cs / .resx     One product shown as a card
    │   ├── AddProductForm.cs / .Designer.cs / .resx  Add Product page
    │   └── RatingForm.cs / .Designer.cs / .resx      Rate Product page
    └── Images/                           Pictures copied next to the .exe when you build
        ├── product1.png, product2.png, product3.png      Startup Page showcase photos
        └── headphones.png, keyboard.png, charger.png     Pictures of the 3 sample products
```

**File types you will see**
- `X.cs` – the logic of a class. `X.Designer.cs` – layout code written by the Visual Studio form
  designer (`InitializeComponent`); the two files together form one `partial class`. `X.resx` –
  resources for that form (generated by Visual Studio).
- `bin/` and `obj/` – build output (created automatically, ignored by Git).

---

## 3. Architecture

The code follows the **Boundary – Control – Entity** pattern from the RAD (the class diagrams):

| Layer | Folder / namespace | Job | Must not |
|---|---|---|---|
| **Boundary** | `Boundary/` – `ProductRatingSystem.Boundary` | Windows, buttons, text boxes. Shows data and passes the user's actions on. | Contain business rules (it only calls a control). |
| **Control** | `Control/` – `ProductRatingSystem.Control` | Rules and steps of a use case: validate input, call the database, decide what happens next. | Draw controls (it only tells the boundary to show something). |
| **Entity** | `Entity/` – `ProductRatingSystem.Entity` | Plain data objects with checked values. | Know about screens or the database. |

### Coding rules (from the README)
- Every class is `public class`, one class per file, file name = class name.
- Method and parameter names follow the RAD: camelCase methods (`getAccount`), parameters start
  with `m` (`muserID`).
- Each file starts with a comment `// Subsystem: Entity | Control | Boundary`.
- In Boundary files write `LoginControl`, not `Control.LoginControl` (the namespace `Control`
  would otherwise clash with `System.Windows.Forms.Control`).

### Who creates whom (objects at run time)

```
RatingSystem.Main
 └─ StartupForm ──(button)──> StartupControl ──> DBConnectorControl.initializeDB()
                                   └─ LoginForm
                                        └─ LoginControl (created by LoginForm, gets the form)
                                              ├─ DBConnectorControl  (every Controller has one: field "db")
                                              └─ LoginForm.openMenu(account)
                                                    ├─ SellerMenu ── ProductCard (one per product)
                                                    │      ├─ AddProductControl ── AddProductForm
                                                    │      └─ LogoutControl ── new LoginForm
                                                    └─ CustomerMenu ── ProductCard (one per product)
                                                           ├─ RateProductControl ── RatingForm
                                                           └─ LogoutControl ── new LoginForm
```

A control passes **a method to call back** (an `Action<ProductList>`) when it finishes, so the menu
can redraw its list: `new AddProductControl(list => display(list, username))`.

---

## 4. How the program runs, step by step

1. **`RatingSystem.Main`** sets up Windows Forms, creates an `ApplicationContext` (a message loop
   with no main form), shows `StartupForm`, and starts the loop.
2. The user clicks **Startup** → `StartupForm.startup()` → `StartupControl.initiate()`:
   `loadConfiguration()` → `DBConnectorControl.initializeDB()` (creates tables and, the first time,
   the sample users and products) → `new LoginForm().display()`. The Startup Page then closes.
   If the database cannot start, a message box appears and the Startup Page stays open.
3. **Login:** `LoginForm.login()` → `LoginControl.login(username, password)`: checks the fields are
   not empty, hashes the password (SHA-256, uppercase hex), asks the database. Wrong data → writes
   `FAILED_LOGIN` to the log and shows "Invalid username or password." Right data → writes `LOGIN`
   and `LoginForm.openMenu(account)` opens the **SellerMenu** or **CustomerMenu** and closes the
   login page.
4. **Seller:** sees own products (picture, title, description, price, overall rating with stars,
   and a **Reviews (n)** button that opens the list of reviews). **Add Product** →
   `AddProductControl` opens `AddProductForm` (modal). On **Submit** the control validates, copies
   the chosen picture to `Images/Products/` next to the `.exe`, saves the product, closes the form
   and the list is redrawn.
5. **Customer:** sees the products not rated yet. **Rate Product** → `RateProductControl` opens
   `RatingForm` (modal). The customer picks 1–5 stars and writes a review; on **Submit** the control
   validates, saves the review, **calculates the new average**, stores it, closes the form and the
   list is redrawn (the rated product disappears from the customer's list).
6. **Logout:** `MainMenu.logout()` → `LogoutControl.logout(userID)` writes `LOGOUT`, shows a new
   `LoginForm`, and the menu closes.
7. **Exit:** closing the last visible window ends the program (see `RatingSystem` below).

The Add Product and Rating pages **cannot be cancelled**: closing them with the X shows a message
until a valid product / rating has been submitted (RAD rule 1.1).

---

## 5. Entity classes (`Entity/`)

Entity classes keep data and **silently ignore invalid values** (a field simply stays `null`/0).
That is why the controls check for `null` to find out whether the user's input was valid.

### `UserAccount` – a person who can log in
Fields: `userID`, `username`, `passwordHash`, `role`.

| Method | Description |
|---|---|
| `UserAccount(muserID, musername, mpasswordHash, mrole)` | Constructor. Accepts `userID` ≥ 0; hash 1–256 characters; username 1–50 characters; role must be exactly `"Customer"` or `"Seller"`. |
| `getUserID()`, `getUsername()`, `getRole()` | Getters. (There is **no** getter for the password hash on purpose.) |
| `setUsername(musername)`, `setRole(mrole)` | Setters with the same checks as the constructor. |

### `Product` – an item for sale
Fields: `productID`, `userID` (**the seller's ID**), `title`, `image` (path text), `description`,
`price`, `overallRating`.

| Method | Description |
|---|---|
| `Product(mproductID, muserID, mtitle, mimage, mdescription, mprice, moverallRating)` | Constructor. Rating must be 0.0–5.0. Other fields use the setters' checks. |
| `getProductID()`, `getUserID()`, `getTitle()`, `getImage()`, `getDescription()`, `getPrice()`, `getOverallRating()` | Getters. There is no setter for `overallRating` (only the database/average code changes it). |
| `setTitle(mtitle)` | 1–100 characters (not blank). |
| `setImage(mimage)` | 1–255 characters (not blank). |
| `setDescription(mdescription)` | 1–1000 characters (not blank). |
| `setPrice(mprice)` | A real number from 0 to 1,000,000. |

### `ProductRating` – one review written by a customer
Fields: `ratingID`, `productID`, `userID` (**the buyer's ID**), `rating`, `review`, `timestamp`.

| Method | Description |
|---|---|
| `ProductRating(mratingID, mproductID, muserID, mrating, mreview, mtimestamp)` | Constructor. Rating must be 1–5; review 1–1000 characters (not blank); timestamp must not be in the future. |
| `getRatingID()`, `getProductID()`, `getUserID()`, `getRating()`, `getReview()`, `getTimestamp()` | Getters. A blank rating (rating 0, review `null`) is what `getRatings()` returns for the Rating Page. |

### `ProductList` – many products
Field: `public Product[] products`.

| Method | Description |
|---|---|
| `ProductList(mproducts)` | Constructor. `null` becomes an empty array. |
| `getCount()` | Number of products. |
| `getProduct(mindex)` | The product at that position, or `null` if the index is out of range. |

### `ReviewList` – many ratings
Field: `public ProductRating[] reviews`.

| Method | Description |
|---|---|
| `ReviewList(mreviews)` | Constructor. `null` becomes an empty array. |
| `getCount()` | Number of reviews. |
| `getReview(mindex)` | The rating at that position, or `null` if out of range. |

---

## 6. Control classes (`Control/`)

### `Controller` (abstract base class)
Gives every control that needs the database its own `DBConnectorControl`.

| Member | Description |
|---|---|
| `protected readonly DBConnectorControl db` | Created in the constructor. Subclasses use `db.getAccount(...)` etc. |

### `DBConnectorControl` – the database (only class that writes SQL)
Uses SQLite. Each method opens its own connection inside a `using` block and uses **parameters**
for every value (so typed text can never change the SQL). Foreign keys are on.

| Member | Parameters → returns | Description |
|---|---|---|
| `connectionString` (field) | – | `ProductRatingSystem.db` in `AppContext.BaseDirectory`. |
| `initializeDB()` | – → `void` | Creates the 5 tables if missing; if `USERACCOUNT` is empty, inserts the 6 sample users and 3 sample products. Safe to run on every start. |
| `getAccount(musername, mpasswordHash)` | `string, string` → `UserAccount` or `null` | User whose name **and** hash match. Does not hash. |
| `logSession(muserID, meventType, mtimestamp)` | `int, string, DateTime` → `void` | Log row for a known user (`LOGIN`, `LOGOUT`). |
| `logSession(musername, meventType, mtimestamp)` | `string, string, DateTime` → `void` | Log row with `userID = NULL` (`FAILED_LOGIN`). |
| `getProducts()` | – → `ProductList` | All products. |
| `getProducts(muserID)` | `int` → `ProductList` | Seller: their own products. Customer: products they have **not** rated. Unknown user: empty list. |
| `saveProduct(muserID, mproduct)` | `int, Product` → `void` | Inserts a product (`sellerID = muserID`, `overallRating = 0`). |
| `getRatings(mproductID)` | `int` → `ProductRating` | A **blank** rating for the Rating Page; nothing is saved. |
| `saveReview(muserID, mproductID, mrating, mreview, mtimestamp)` | `int, int, int, string, DateTime` → `void` | Inserts the review and marks the product as rated by this customer (one transaction). |
| `getReviews(mproductID)` | `int` → `ReviewList` | All ratings of a product, newest first. |
| `updateRating(mproductID, maverage)` | `int, double` → `void` | Stores the product's overall rating. |
| private helpers | – | `openConnection`, `runNonQuery`, `readProducts`, `insertSampleData`, `insertAccount`, `insertSampleProduct`, `hashPassword`, `readString`, `toDb`, `formatTimestamp`, `parseTimestamp`. |

### `StartupControl : Controller` – Startup use case
| Member | Description |
|---|---|
| `configFile` (field) | `config.txt` next to the `.exe`. |
| `settings` (field) | Helper: `key=value` lines read from `config.txt` (not used yet). |
| `initiate()` | `loadConfiguration()` → `db.initializeDB()` → `new LoginForm().display()`. Does not catch errors (`StartupForm` shows them). |
| `loadConfiguration()` (private) | Reads `config.txt` if it exists; a missing/broken file is ignored. |

### `LoginControl : Controller` – Login use case
| Member | Description |
|---|---|
| `loginForm` (field) | The form that created it (used to show errors and open the menu). |
| `LoginControl()`, `LoginControl(mloginForm)` | Constructors. |
| `login(musername, mpassword)` → `UserAccount` | Checks both fields are filled, hashes the password, calls `getAccount`. **Failure:** logs `FAILED_LOGIN`, shows an error, returns `null`. **Success:** logs `LOGIN`, calls `loginForm.openMenu(account)`, returns the account. |
| `loginError(mmessage)` (private) | Shows the message on the form and returns `null`. |

The hash must be exactly: `Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)))`.

### `LogoutControl : Controller` – Logout use case
| Member | Description |
|---|---|
| `logout(muserID)` | Logs `LOGOUT` and shows a new `LoginForm`. |
| `logout()` | Shows a new `LoginForm` only (not used by the menus). |

### `AddProductControl : Controller` – Add Product use case
| Member | Description |
|---|---|
| Fields | `userID`, `addProductForm`, `showProducts` (callback), `errorMessage`; constant `maxImageBytes` = 5 MB. |
| `AddProductControl(mshowProducts)` | Constructor. The callback receives the refreshed product list. |
| `addProduct(muserID)` | Remembers the seller and opens `AddProductForm`. |
| `submit(mproduct)` | Validates; copies the picture; saves with `db.saveProduct`; closes the form; reloads `db.getProducts(userID)` and calls the callback. On error shows the message and keeps the form open. |
| `validate(mproduct)` (private) | Title 1–100 chars; a picture chosen; description 1–1000 chars; price > 0, ≤ 1,000,000, at most 2 decimals. Sets `errorMessage` naming the field. |
| `isImageFile(mpath)` (private) | File must be `.png/.jpg/.jpeg/.bmp/.gif`, exist, be ≤ 5 MB and open as a picture. |
| `storeImage(mpath)` (private) | Copies the picture to `Images/Products/<random>.<ext>` next to the `.exe`; returns the relative path saved in the database. |

### `RateProductControl : Controller` – Rate Product use case
| Member | Description |
|---|---|
| Fields | `userID`, `productID`, `ratingForm`, `showProducts` (callback), `errorMessage`; constant `maxReviewLength` = 1000. |
| `RateProductControl(mshowProducts)` | Constructor. |
| `rateProduct(muserID, mproductID)` | Gets the blank rating (`db.getRatings`), finds the product in the customer's unrated list, opens `RatingForm`. If the product is no longer available, shows a message. |
| `submit(mrating, mreview)` | Validates; `db.saveReview`; `db.getReviews` → `calculateAverage` → `db.updateRating`; closes the form; reloads the customer's list and calls the callback. |
| `validate(mrating, mreview)` (private) | Stars 1–5; review not blank, ≤ 1000 chars, no strange control characters. |
| `calculateAverage(mreviewList)` (private) | Average of all valid ratings, rounded to 2 decimals (0 if none). |
| `findProduct(mproductList, mproductID)` (private) | Looks a product up by ID in a list. |

---

## 7. Boundary classes (`Boundary/`)

### Shared by all screens

**`ApplicationForm : Form`** (abstract) – base of every window. Its constructor sets the default
font and colours and the **standard window**: client size **600 × 780**, fixed border (no
resizing), no maximize button, centered on screen, 96-DPI scaling. A new form only has to inherit
from `ApplicationForm`; it must not set its own size.

**`UiTheme`** (static) – the look of the whole program.

| Member | Description |
|---|---|
| Colours | `WindowBackground` (light grey page), `Surface` (white), `Text`, `MutedText`, `Primary` (blue), `HeaderBackground` (light grey `Gainsboro`), `ButtonBorder` (dark slate), `Divider`, `HeaderDivider`, `PrimaryHover`, `PrimaryPressed`. |
| Fonts | `BodyFont` (Segoe UI 9.5), `HeadingFont` (Segoe UI Semibold 16), `UsernameFont` (Semibold 15), `CountFont` (Segoe UI 11), `ButtonFont` (Semibold 10). |
| `FormClientSize` | 600 × 780, used by `ApplicationForm`. |
| `StyleSecondaryButton(mbutton)` | **The** button look: white rectangle, thin dark border, blue text, hand cursor. It also repaints the border at 1 px when the button has focus (Windows would draw it thicker). |
| `StylePrimaryButton(mbutton)` | Same look (kept so older calls still work). |

### `StartupForm : ApplicationForm` – first page
Title "PRODUCT RATING / SYSTEM" (Times New Roman Bold 40), subtitle, three showcase product cards
(fixed pictures `Images/product1-3.png` and stars 4, 3, 5 – not from the database) and the
**Startup** button.

| Method | Description |
|---|---|
| `StartupForm()` | Builds the page and fills the three cards. |
| `display()` / `close()` | `Show()` / `Close()`. |
| `startup()` (private) | Disables the button, calls `new StartupControl().initiate()`, then `close()`. On an error: message box, page stays open, button enabled again. |
| `showProduct(...)`, `loadImage(...)` (private) | Fill a card; load an image (grey placeholder if the file is missing). |
| `startupButton_Click`, `startupForm_FormClosed` (private) | Event handlers (the second frees the pictures). |

### `LoginForm : ApplicationForm` – login page
Big title, a blue user symbol, **Username**, **Password**, error text, **Login** button. `Enter`
also logs in.

| Method | Description |
|---|---|
| `LoginForm()` | Builds the page, creates its `LoginControl(this)`. |
| `display()` / `close()` | `Show()` / `Close()`. |
| `login()` | Clears the error, disables the button, calls `loginControl.login(...)`. |
| `displayError(mmessage)` | Shows the error text and puts the cursor in the right box. |
| `openMenu(maccount)` | Loads the user's products and opens `SellerMenu` or `CustomerMenu` (passing `userID` and `username`), then closes the login page. |
| `userIconPanel_Paint`, `loginButton_Click`, `passwordTextBox_KeyDown` (private) | Draws the user symbol; button and Enter-key events. |

### `MainMenu : ApplicationForm` (abstract) – shared part of the two menus
Fields: `userID`, `username`, `userLabel` (shows the name), `countLabel` (shows "Count: n").

| Method | Description |
|---|---|
| `logout()` | `new LogoutControl().logout(userID)`, then closes this menu. |
| `createHeader(params Button[] mbuttons)` | Top **grey box** (thin border, space around it): user name on the left; the given buttons and **Logout** on the right. |
| `createHeading(mtext)` | Second **white box**: page title on the left, product count on the right. |

### `SellerMenu : MainMenu` – Seller page
Header `[Add Product] [Logout]`, heading "My Products", a scrolling list of `ProductCard`s.

| Method | Description |
|---|---|
| `SellerMenu()` | Builds the page. |
| `display(mproductList, musername)` | Shows the name, draws one card per product (with its reviews from `getReviews`), updates the count. Called again after a product is added. |
| `addProduct()` | `new AddProductControl(list => display(list, username)).addProduct(userID)`. |

### `CustomerMenu : MainMenu` – Customer page
Header `[Logout]`, heading "Available Products", list of cards with **Rate Product** buttons.

| Method | Description |
|---|---|
| `CustomerMenu()` | Builds the page. |
| `display(mproductList)` | Draws one card per unrated product, updates the count. Called again after a rating. |
| `selectProduct(mproductID)` | Remembers the chosen product. |
| `rateProduct()` | `new RateProductControl(list => display(list)).rateProduct(userID, selectedProductID)`. |

### `ProductCard : UserControl` – one product as a card
A reusable control (picture, title, description, boxed price) used by both menus. It never reads
the database itself.

| Member | Description |
|---|---|
| `displaySeller(mproduct, mreviews)` | Card for sellers: adds the **Overall Rating** box (text left, stars right) and the **Reviews (n)** button that opens/closes the list of reviews. |
| `displayCustomer(mproduct)` | Card for customers: adds the **Rate Product** button. |
| `rateProductClicked` (event) | Raised when **Rate Product** is pressed. |
| `getProductID()` | ID of the shown product. |
| Static helpers | `stars(mrating)` ("★★★☆☆"), `formatPrice(mprice)` ("$44.30"), `formatRating(mrating)` ("3.7"), `loadImage(mpath)` (absolute or relative-to-exe path; grey placeholder if missing), `keepCentered(mpanel, mmaximumWidth)` / `arrangeCards(...)` (cards fill and center in the list). |
| Private | `showProduct`, `fillReviews`, `makeReviewLabel`, `setReviewsOpen`, and event handlers. |

### `AddProductForm : ApplicationForm` – Add Product page (modal)
Heading, **Title**, picture preview + **Choose Image…**, **Description** (with a character
counter), **Price**, **Submit**.

| Method | Description |
|---|---|
| `AddProductForm(mcontrol)` | Builds the page for the given control. |
| `display()` | Shows it as a dialog (waits until it is closed). |
| `submit()` | Reads the fields, builds a `Product`, calls `addProductControl.submit(product)`. |
| `close()` | Allows closing and closes (called by the control after saving). |
| `displayError(mmessage)` | Message box + cursor in the field the message is about. |
| Private | `parsePrice` (accepts `44.30`, `$44.30`, `1,044.30`), `focusField`, `chooseImage` (file dialog), `updateCharacterCount`, `centerContent`, and event handlers (`…_Load` shrinks the window only if the screen is too small; `…_FormClosing` blocks cancelling). |

### `RatingForm : ApplicationForm` – Rate Product page (modal)
Heading, product title/picture/description/price, a **Rating box** with five star buttons
(`☆`→`★`; keys 1–5 also work), the **review** box with a counter, **Submit**.

| Method | Description |
|---|---|
| `RatingForm(mcontrol, mproduct)` | Builds the page for one product. |
| `display(mproductRating)` | Shows the page (modal) with the blank rating from the database. |
| `submit()` | Calls `rateProductControl.submit(rating, review)`. |
| `close()` | Allows closing and closes. |
| `displayError(mmessage)` | Message box + cursor in the star row or the review box. |
| Private | `showProduct`, `showStars`, `selectRating`, `updateCharacterCount`, `centerContent`, and event handlers (`starButton_Click`, `starButton_KeyPress`, `…_Load`, `…_FormClosing`). |

### Program start
**`RatingSystem`** (`RatingSystem.cs`, static class) – `Main()` initializes Windows Forms, creates
an `ApplicationContext` without a main form, hooks `Application.Idle` so the program **ends when
no visible form is left** (and not when one window is replaced by another), shows `StartupForm`
and runs the loop. Helper `hasVisibleForm()` checks `Application.OpenForms`.

---

## 8. The database

Created by `DBConnectorControl.initializeDB()`. Timestamps are stored as text
(`2026-11-20T14:05:09`). PK = primary key, FK = foreign key.

| Table | Columns | Written by | Read by |
|---|---|---|---|
| `USERACCOUNT` | `userID` PK auto, `username` unique, `passwordHash`, `role` (`Customer`/`Seller`) | `initializeDB` (sample users) | `getAccount`, `getProducts(muserID)`, `logSession(int…)` |
| `PRODUCT` | `productID` PK auto, `title`, `image`, `description`, `price`, `overallRating` (default 0), `sellerID` FK→USERACCOUNT | `initializeDB`, `saveProduct`, `updateRating` | `getProducts()` / `getProducts(muserID)` |
| `PRODUCTRATING` | `ratingID` PK auto, `rating`, `review`, `timestamp`, `buyerID` FK→USERACCOUNT, `productID` FK→PRODUCT | `saveReview` | `getReviews` |
| `PURCHASE` | `buyerID` FK, `productID` FK, `rated` (0/1); PK (`buyerID`,`productID`) | `saveReview` | `getProducts(muserID)` for customers |
| `SESSIONLOG` | `sessionID` PK auto, `username`, `eventType` (`LOGIN`/`LOGOUT`/`FAILED_LOGIN`), `timestamp`, `userID` FK (NULL for failed logins) | both `logSession` methods | – (log only) |

**Mapping to Entity classes:** `USERACCOUNT` → `UserAccount`; `PRODUCT` → `Product` (`sellerID` →
`getUserID()`); `PRODUCTRATING` → `ProductRating` (`buyerID` → `getUserID()`). Lists of rows become
`ProductList` / `ReviewList`.

**Pictures** are not stored in the database, only their path as text: sample products use
`images/headphones.png` etc. (files in `Images/`); products added by sellers use
`Images/Products/<random>.<ext>`. Paths are relative to the `.exe` folder.

---

## 9. Use cases – who calls what

**Login – valid**
`LoginForm.login()` → `LoginControl.login()` → `db.getAccount()` → `db.logSession(userID,"LOGIN")`
→ `LoginForm.openMenu()` → `db.getProducts(userID)` → `SellerMenu/CustomerMenu.display(...)`.

**Login – invalid**
`LoginControl.login()` → `db.getAccount()` returns `null` → `db.logSession(username,"FAILED_LOGIN")`
→ `LoginForm.displayError("Invalid username or password.")`.

**Logout**
`MainMenu.logout()` → `LogoutControl.logout(userID)` → `db.logSession(userID,"LOGOUT")` →
`new LoginForm().display()`.

**Add Product**
`SellerMenu.addProduct()` → `AddProductControl.addProduct()` → `AddProductForm.display()` →
user presses Submit → `AddProductForm.submit()` → `AddProductControl.submit()` → `validate` →
`storeImage` → `db.saveProduct()` → `AddProductForm.close()` → `db.getProducts(userID)` →
`SellerMenu.display()`.

**Rate Product**
`CustomerMenu.rateProduct()` → `RateProductControl.rateProduct()` → `db.getRatings()` +
`db.getProducts(userID)` → `RatingForm.display()` → Submit → `RatingForm.submit()` →
`RateProductControl.submit()` → `validate` → `db.saveReview()` → `db.getReviews()` →
`calculateAverage` → `db.updateRating()` → `RatingForm.close()` → `db.getProducts(userID)` →
`CustomerMenu.display()`.

---

## 10. Look and feel (all pages)

- **One window size:** 600 × 780 client area, fixed border, centered – set once in `ApplicationForm`.
- **Colours:** light-grey page, white boxes with thin black borders, light-grey top bars
  (`HeaderBackground`), blue text for actions.
- **Buttons:** white rectangle, dark thin border, blue Segoe UI Semibold text (`UiTheme`).
- **Title font:** "PRODUCT RATING SYSTEM" is Times New Roman Bold 40 pt on both the Startup
  and Login pages.
- **Adding a new form:** inherit from `ApplicationForm`, call
  `UiTheme.StyleSecondaryButton(button)` for each button, do not set `Size`/`ClientSize`.

---

## 11. Known limits and ideas

- `SellerMenu.display` and `LoginForm.openMenu` call `DBConnectorControl` directly instead of
  going through a control class.
- `config.txt` is read but no setting uses it yet.
- `UiTheme.HeaderDivider`, `PrimaryHover`, `PrimaryPressed` and `LogoutControl.logout()` (no
  argument) are currently unused.
- Only `.png` files in `Images/` are copied to the output folder (add a `.jpg` rule to the
  `.csproj` to use JPEGs).
- A customer can only rate a product once through the app (it leaves their list); the database
  itself does not forbid a second row.
