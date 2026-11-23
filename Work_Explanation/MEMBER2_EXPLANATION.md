# Member 2 – Login, Logout and Main Menus (explanation)

## 1. Overview

Member 2's part covers login and logout, plus the two role-specific main menus:

- **Login:** `LoginForm` collects the username and password. `LoginControl` validates the
  required fields, hashes the password, looks up the account and opens the correct menu.
- **Logout:** `MainMenu` provides the shared logout action. `LogoutControl` records the logout
  and returns the user to a new login screen.
- **Customer menu:** `CustomerMenu` displays products that are available for the customer to
  rate and starts the Rate Product use case for a selected card.
- **Seller menu:** `SellerMenu` displays the seller's products and their reviews, and starts the
  Add Product use case.
- **Shared GUI setup:** `ApplicationForm` and `UiTheme` provide common form defaults and button
  styles used throughout the Windows Forms interface.

The menus and login form use the shared `MainMenu`, `ApplicationForm`, `Controller` and
`DBConnectorControl` infrastructure. `RatingSystem` and the startup screen are described in
`MEMBER1_EXPLANATION.md`; adding and rating products are described in
`MEMBER3_EXPLANATION.md`.

---

## 2. Files

| File | Purpose |
|---|---|
| `Control/LoginControl.cs` | Validates credentials, authenticates the account and records login events. |
| `Control/LogoutControl.cs` | Records logout and opens a new login form. |
| `Control/Controller.cs` | Shared abstract control base that creates the database connector. |
| `Boundary/LoginForm.cs` + `.Designer.cs` | Login screen, input handling and role-based menu navigation. |
| `Boundary/MainMenu.cs` | Shared base for the customer and seller menus, including logout. |
| `Boundary/CustomerMenu.cs` | Customer product list and entry point to Rate Product. |
| `Boundary/SellerMenu.cs` | Seller product list, reviews and entry point to Add Product. |
| `Boundary/ApplicationForm.cs` | Shared base form with common font, colors and DPI scaling. |
| `Boundary/UiTheme.cs` | Central theme colors and reusable primary/secondary button styles. |

---

## 3. Login

### 3.1 `LoginForm` (Boundary)

The login screen has username and password fields, a **Login** button, and an error label.
The password field masks its text. Pressing Enter in the password field submits the form;
the Login button is also the form's `AcceptButton`.

| Member | What it does |
|---|---|
| `LoginForm()` | Builds the form, applies the primary button style, creates `LoginControl`, and focuses the username field. |
| `display()` | Shows the form. |
| `close()` | Closes the login form after a menu has been opened. |
| `login()` | Clears the previous error, disables the button during authentication, and passes the entered values to `LoginControl.login`. The button is re-enabled if the form is still open. |
| `displayError(string)` | Displays the error and focuses the field that needs attention. |
| `openMenu(UserAccount)` | Loads the account's product list, creates the menu matching the account role, displays it, then closes the login form. |

The form is a fixed-size, centered dialog-style window. The common application font and
background are supplied by `ApplicationForm`; the Login button is styled by `UiTheme`.

### 3.2 `LoginControl` (Control)

| Member | What it does |
|---|---|
| `LoginControl()` | Initializes the shared database connector through `Controller`. |
| `LoginControl(LoginForm)` | Retains the form so it can display errors and open a menu. |
| `login(string, string)` | Trims the username, checks that both values are present, hashes the password using SHA-256, and calls `db.getAccount(username, passwordHash)`. |
| `loginError(string)` | Displays a field or authentication error through the form and returns `null`. |

On an invalid username/password combination, the control records a `FAILED_LOGIN` event and
shows the same generic **Invalid username or password.** message. On success, it records a
`LOGIN` event and passes the `UserAccount` to `LoginForm.openMenu`.

The password is hashed as the uppercase hexadecimal representation of the SHA-256 digest of
the UTF-8 password. The raw password is not stored or logged by this use case; its hash is
passed to the parameterized account lookup in `DBConnectorControl`. Session log writes also
use parameterized database operations.

---

## 4. Logout

### 4.1 `LogoutControl` (Control)

| Method | What it does |
|---|---|
| `logout(int muserID)` | Records a `LOGOUT` event for the account and displays a new `LoginForm`. |
| `logout()` | Displays a new `LoginForm` without a user-specific session record. |

### 4.2 `MainMenu` (Boundary base class)

`MainMenu` is an abstract base class for the role-specific menus. It stores the logged-in
`userID` and implements `logout()`: call `LogoutControl.logout(userID)`, then close the current
menu. `CustomerMenu` and `SellerMenu` inherit this behavior instead of duplicating it.

---

## 5. Role-specific menus

### 5.1 `CustomerMenu`

The Customer Menu displays a scrollable list of products. Each product is shown through
`ProductCard.displayCustomer`, which includes a **Rate Product** button.

| Method | What it does |
|---|---|
| `display(ProductList)` | Rebuilds the product cards, updates the count, shows the menu if needed and activates it. |
| `selectProduct(int mproductID)` | Stores a product ID for the rate action. |
| `rateProduct()` | Creates `RateProductControl` and opens the rating page for the selected product and logged-in customer. |
| `logout()` | Inherited from `MainMenu`. |

The product card's `rateProductClicked` event selects its product ID and starts the rating
workflow. After a successful rating, `RateProductControl` calls the menu's display callback
with the refreshed customer product list.

### 5.2 `SellerMenu`

The Seller Menu displays the seller's products, the seller's username, a product count, an
**Add Product** button and a **Logout** button. Each card is shown through
`ProductCard.displaySeller`, with the product's reviews loaded through `DBConnectorControl`.

| Method | What it does |
|---|---|
| `display(ProductList, string musername)` | Updates the username and title, rebuilds product cards with their reviews, updates the count, and shows/activates the menu. |
| `addProduct()` | Creates `AddProductControl` with a callback to redisplay the refreshed seller list, then opens the Add Product page for the logged-in seller. |
| `logout()` | Inherited from `MainMenu`. |

Both menus use a vertically flowing, scrollable product panel. `ProductCard.keepCentered`
keeps cards centered and resizes them with the panel.

---

## 6. Shared GUI framework and styling

### 6.1 `ApplicationForm`

`ApplicationForm` is the abstract base for the application's forms. Its constructor supplies
the common body font, window background, text color and DPI-aware autoscaling. `MainMenu`
inherits from it, so both role menus receive the same defaults.

The login form, startup form, Add Product form and Rating form also inherit from
`ApplicationForm`, giving the screens consistent defaults while preserving their existing
layouts and form-specific behavior.

### 6.2 `UiTheme`

`UiTheme` centralizes the palette and reusable button styles:

| Style | Use |
|---|---|
| `StylePrimaryButton(Button)` | Blue button with white bold text; used for primary actions such as Login, Startup, Add Product, Submit and Rate Product. |
| `StyleSecondaryButton(Button)` | White button with blue text and a subtle border; used for secondary actions such as Logout and Choose Image. |

The shared palette includes the light window background, white surfaces, dark text, muted
text, and blue primary/hover/pressed states. The theme is applied in the form code after
`InitializeComponent()`, so designer-generated layouts remain separate from styling logic.

---

## 7. Application flow

```text
LoginForm
  └─ LoginControl.login(username, password)
       ├─ invalid credentials → record FAILED_LOGIN → display error
       └─ valid credentials → record LOGIN
            └─ LoginForm.openMenu(account)
                 ├─ Seller → SellerMenu.display(products, username)
                 └─ Customer → CustomerMenu.display(products)

CustomerMenu
  ├─ Rate Product → RateProductControl → refreshed CustomerMenu
  └─ Logout → LogoutControl → LoginForm

SellerMenu
  ├─ Add Product → AddProductControl → refreshed SellerMenu
  └─ Logout → LogoutControl → LoginForm
```

---

## 8. Shared controller base

`Control/Controller.cs` is an abstract base class for controllers that need database access.
It creates one protected, read-only `DBConnectorControl` instance per controller. Both
`LoginControl` and `LogoutControl` inherit from it, as do the other application controllers,
so database setup is not repeated in each use-case control.

---

## 9. Build and verification

The project targets `net9.0-windows` and uses Windows Forms. Build it from the solution folder
with:

```text
dotnet build
```

The GUI framework and Member 2 changes have been built successfully with no compilation
errors.