# Member 3 – Add Product and Rate Product (explanation)

## 1. Overview

Member 3's part covers two use cases from the RAD and the display of ratings and reviews:

- **AddProduct** (RAD Table 2.4.5, Figure 2.5.5): a Seller opens the **AddProduct Page**
  (`AddProductForm`), fills in title, image, description and price, and presses **Submit**.
  `AddProductControl` validates the product, saves it with an overall rating of 0, closes the
  page and gives the refreshed product list back to the Seller Page.
- **RateProduct** (RAD Table 2.4.6, Figure 2.5.6): a Customer picks a product and opens the
  **Rating Page** (`RatingForm`), chooses 1–5 stars, writes a review and presses **Submit**.
  `RateProductControl` validates and saves it, recalculates the product's overall rating as the
  average of all its ratings, closes the page and gives the refreshed list of unreviewed
  products back to the Customer Page.
- **Showing ratings and reviews**: `ProductCard` is a ready-made product "card" for the Seller
  Page and Customer Page mockups (RAD Figures 3.2.1 and 3.3.1). The seller version shows the
  overall rating with stars and an expandable **Reviews** list. The customer version shows a
  **Rate Product** button.

Class and method names follow RAD Figures 4.2.1 and 4.2.2 exactly. Nothing in `Entity/` or
`DBConnectorControl` was changed. The only changes to shared files are the display-scaling fixes
in section 3.8 (`ApplicationForm`, `MainMenu`, `LoginForm.Designer.cs`).

---

## 2. Files

| File | New/changed | What it is |
|---|---|---|
| `Control/AddProductControl.cs` | new | AddProduct use case logic |
| `Control/RateProductControl.cs` | new | RateProduct use case logic |
| `Boundary/AddProductForm.cs` + `.Designer.cs` + `.resx` | new | AddProduct Page |
| `Boundary/RatingForm.cs` + `.Designer.cs` + `.resx` | new | Rating Page |
| `Boundary/ProductCard.cs` + `.Designer.cs` + `.resx` | new | Product card for the Seller/Customer Pages (helper, not in the class diagram) |
| `Boundary/ApplicationForm.cs` | changed | every window fits on the screen (section 3.8) |
| `Boundary/MainMenu.cs` | changed | the Seller and Customer menus scale with Windows display scaling (section 3.8) |
| `Boundary/LoginForm.Designer.cs` | changed | the Login page scales with Windows display scaling (section 3.8) |
| `Work_Explanation/MEMBER3_EXPLANATION.md` | new | this file |

The forms have normal `Designer.cs` files, so they open in the Visual Studio designer. Both pages
follow the team window rules (set in `ApplicationForm`): `ClientSize` 600 x 780, fixed border,
no maximize button, centered on the screen. If the screen is too small for the page, they get a
scroll bar (see 3.7).

---

## 3. Classes

### 3.1 `AddProductControl` (Control)

| Member | In RAD? | What it does |
|---|---|---|
| `-userID:int` | yes | The logged-in seller. |
| `AddProductControl(Action<ProductList, Dictionary<int, ReviewList>> mshowProducts)` | constructor | `mshowProducts` is called with the refreshed product list and the reviews of those products after saving. The SellerMenu uses it to show the Seller Page again (see section 5). |
| `+addProduct(int):void` | yes | Stores the seller's ID, creates the `AddProductForm` and calls `display()`. |
| `+submit(Product):void` | yes | Calls `validate`. If it fails: `displayError(...)` and the page stays open. If it passes: copies the picture (see below), `db.saveProduct(userID, product)`, `close()` the page, `db.getProducts(userID)`, reads the reviews of those products (`loadReviews`), then calls `mshowProducts(productList, reviews)`. If saving fails, the page stays open with "The product could not be saved. Please try again." (no technical details). |
| `-validate(Product):bool` | yes | Checks every field. Error messages start with the field name (RAD 2.2 Usability). |
| `-isImageFile`, `-storeImage`, `-loadReviews` | helpers | Image checks; copying the picture; reading the reviews of every product for the Seller Page (the menu never reads the database). |

**Validation rules**

| Field | Rule | Message starts with |
|---|---|---|
| Title | 1–100 characters | `Title:` |
| Image | chosen; `.png .jpg .jpeg .bmp .gif`; file exists; ≤ 5 MB; opens as a picture | `Image:` |
| Description | 1–1000 characters | `Description:` |
| Price | a number > 0 and ≤ 1,000,000, at most 2 decimals (`44.30`, `$44.30` and `1,044.30` are accepted) | `Price:` |

**Pictures:** when a product is saved, the chosen picture is copied to
`Images/Products/<random name>.png` next to the `.exe` (in `bin/…`, like the database). That
relative path is what goes in `PRODUCT.image`, so the picture still shows if the seller later
moves or deletes the original file. The sample products' paths (`images/headphones.png` etc.)
don't exist, so they show a light-grey placeholder instead of an error.

### 3.2 `RateProductControl` (Control)

| Member | In RAD? | What it does |
|---|---|---|
| `-userID:int`, `-productID:int` | yes | The customer and the product being rated. |
| `RateProductControl(Action<ProductList> mshowProducts)` | constructor | `mshowProducts` is called with the refreshed list of unreviewed products. The CustomerMenu uses it to show the Customer Page again. |
| `+rateProduct(int, int):void` | yes | `db.getRatings(productID)` → blank `ProductRating`. Finds the `Product` in `db.getProducts(userID)` (the page has to show title, image, description and price). Creates the `RatingForm` and calls `display(productRating)`. |
| `+submit(int, string):void` | yes | `validate` → `db.saveReview(userID, productID, rating, review, DateTime.Now)` → `db.getReviews(productID)` → `calculateAverage` → `db.updateRating(productID, average)` → `close()` → `db.getProducts(userID)` → `mshowProducts(productList)`. This is the same order as Figure 2.5.6. |
| `-validate(int, string):bool` | yes | Rating 1–5 (`Rating:`); review not blank, at most 1000 characters, no control characters (`Review:`). |
| `-calculateAverage(ReviewList):double` | yes | The exact average of all ratings (not rounded); 0 when there are none. The pages show it with one decimal. |
| `-findProduct` | helper | Finds a product by ID in a `ProductList`. |
| `maxReviewLength` | constant | 1000; `RatingForm` uses it too. |

If saving the rating fails, the page stays open with "The rating could not be saved. Please try
again." If the rating was saved but updating the average fails, a warning is shown and the page
closes anyway, so the same rating can't be submitted twice. Technical error details are never
shown to the user.

### 3.3 `AddProductForm` (Boundary)

Fields `-title`, `-image`, `-description`, `-price` and methods `+display()`, `+submit()` and
`+close()`, as in Figure 4.2.1. Also `displayError(string)` (shows the message and puts the
cursor in that field).

- **Choose Image…** opens a file dialog and previews the picture.
- `submit()` reads the boxes, builds a `Product` (IDs 0) and calls `addProductControl.submit(product)`.
  A price that isn't a number is passed as -1, which the `Product` keeps as 0 and the control
  reports as a `Price:` error.
- Shows a live "0 / 1000 characters" counter under the description.

### 3.4 `RatingForm` (Boundary)

Fields `-productRating`, `-rating`, `-review` and methods `+display(ProductRating)`, `+submit()`
and `+close()`, as in Figure 4.2.1. Also `displayError(string)`.

- Shows the product's title, picture, description (read-only) and price.
- Five clickable star buttons (☆ → ★). The keys 1–5 also work when a star has focus.
  "3 of 5" is shown next to them.
- A review box with a "0 / 1000 characters" counter.

### 3.5 Pages can't be cancelled (RAD 1.1)

The RAD says the user can't cancel or leave the AddProduct Page or the Rating Page until the
form has been submitted successfully. That's why both forms:
- block the X button and Alt+F4 with a message ("Please complete the form…"), and have no minimize button;
- open with `ShowDialog()` (modal), so the Seller/Customer Page underneath can't be clicked,
  including its Logout button, while they are open. `display()` returns after `close()`.

### 3.6 `ProductCard` (Boundary, helper)

A `UserControl` (540 px wide at 100% display scaling) with the picture, title, description and price.

| Member | What it does |
|---|---|
| `displaySeller(Product, ReviewList)` | Also shows "Overall Rating: 3.5 ★★★★☆" and a **Reviews (n) ▼** button that opens/closes the list ("Review 1 - ★★★★★ - text (Nov 20, 2026)"). |
| `displayCustomer(Product)` | Shows a **Rate Product** button instead. |
| `event rateProductClicked` | Raised when Rate Product is pressed. |
| `getProductID()` | ID of the product on the card. |
| `static stars(double)` | `3.6` → `★★★★☆` (rounded to whole stars). |
| `static loadImage(string)` | Loads a product picture (absolute, or relative to the `.exe`). Placeholder if missing. |
| `static formatPrice(double)` / `formatRating(double)` | `$44.30` / `3.7` |
| `static keepCentered(FlowLayoutPanel, int)` | Call once for a product list. The cards stretch with the list from their minimum width up to the given width (use `defaultMaximumCardWidth` = 1800) and stay centered. The minimum is 540 px at 100% display scaling and grows with it (810 px at 150%), so a card's contents are never squeezed. Re-arranges on every resize and when cards are added. |
| `static arrangeCards(FlowLayoutPanel, int)` | Does the same arranging once (used by `keepCentered`). |

The title, description, rating line and Reviews list stretch with the card (`Anchor`), and the
open review list re-wraps its text when the card gets wider or narrower.

The card never reads the database. Whoever builds the page passes the data in.

### 3.7 Scroll bars when the screen is too small

At 600 x 780 a page can be taller than a laptop screen, especially with Windows display scaling
at 125% or 150% (at 150% the page is 1170 px tall). Without help the bottom of the page, with the
Submit button, would be cut off. So both pages:
- put all their controls on one 600 x 780 panel (`contentPanel`) and have `AutoScroll = true`,
  so a scroll bar appears when the window is smaller than the page;
- shrink to fit the screen when they open (`ApplicationForm` and their own `Load` event) and stay
  centered on the screen. The window size itself is fixed (team rule): the user can't drag it
  bigger or smaller;
- keep the page centered in the window and never under the scroll bar (`centerContent()`).

In the Visual Studio designer, the controls are inside `contentPanel`. To move one, select it as
usual; to add a new control, drop it onto the panel, not the form.

### 3.8 Display scaling (125%, 150%, ...) for every window

On a laptop with Windows display scaling above 100% (Settings → System → Display → Scale), the
text grows with the setting. Every window has to grow with it too, or the text gets cut off.
Teammates with 100% scaling never see the problem. These changes make every window scale and
fit on the screen:

| File | Change |
|---|---|
| `LoginForm.Designer.cs` | Added `AutoScaleDimensions = new SizeF(96F, 96F);` and `AutoScaleMode = AutoScaleMode.Dpi;` in `InitializeComponent()`, just above `ClientSize`. They tell Windows the page was designed at 100%, so it enlarges the page by the display scaling. Every designer-made form needs these two lines (the other forms already had them). |
| `MainMenu.cs` | The Seller and Customer menus are built in code, not in the designer, so Windows doesn't enlarge them by itself. `OnLoad` calls `scaleForDisplay()`, which scales the window and the two top boxes (header and heading) once by the display scaling. It does nothing at 100%, or if Windows already scaled the boxes, so nothing is ever scaled twice. The product cards scale themselves. |
| `ApplicationForm.cs` | `OnLoad` calls `fitToScreen()` for **every** window: if the window is taller or wider than the screen, it is shrunk to fit, gets a scroll bar (with room for it, so no sideways scrolling) and is centered. At 100%, or when the window fits, nothing changes. |
| `ProductCard.cs` | The minimum card width grows with the display scaling (see 3.6). |

Message boxes and the file dialog are drawn by Windows and scale by themselves.

---

## 4. Call flow

```
AddProduct (Seller)
SellerMenu.addProduct()
  └─ new AddProductControl((list, reviews) => { setReviews(reviews); display(list, username); })
         .addProduct(userID)
       ├─ new AddProductForm(this).display()          (modal)
       │     Seller fills in, presses Submit
       │     AddProductForm.submit() → new Product(...) → control.submit(product)
       ├─ validate(product)   ── fails → form.displayError("Price: ...")  (page stays open)
       ├─ storeImage + db.saveProduct(userID, product)
       ├─ form.close()
       ├─ db.getProducts(userID) + db.getReviews(...) for each product (loadReviews)
       └─ showProducts(productList, reviews)  → SellerMenu.setReviews + display(productList, username)

RateProduct (Customer)
CustomerMenu: Rate Product pressed → selectProduct() + rateProduct()
  └─ new RateProductControl(list => display(list)).rateProduct(userID, selectedProductID)
       ├─ db.getRatings(productID)        → blank ProductRating
       ├─ db.getProducts(userID)          → find the Product to show
       ├─ new RatingForm(this, product).display(productRating)   (modal)
       │     Customer picks stars, writes review, presses Submit
       │     RatingForm.submit() → control.submit(rating, review)
       ├─ validate(rating, review) ── fails → form.displayError("Review: ...")
       ├─ db.saveReview(userID, productID, rating, review, DateTime.Now)
       ├─ db.getReviews(productID) → calculateAverage(reviewList) → db.updateRating(productID, average)
       ├─ form.close()
       ├─ db.getProducts(userID)          → the rated product is gone from this list
       └─ showProducts(productList)  → CustomerMenu.display(productList)
```

---

## 5. How the menus use these classes

The RAD's sequence diagrams end with the control calling `SellerMenu.display(productList, username)`
or `CustomerMenu.display(productList)`. The controls take that method as a constructor parameter
instead of a menu object, so they never need to know which menu object is open (and the project
could be built before the menus existed). This is how the menus use them:

**SellerMenu**
```csharp
public void addProduct()
{
    AddProductControl control = new AddProductControl(
        (productList, productReviews) =>
        {
            setReviews(productReviews);
            display(productList, getUsername());
        });
    control.addProduct(userID);
}
```
`display(productList, username)` draws one `ProductCard` per product with
`card.displaySeller(product, reviews)`, using the reviews it was given with `setReviews()`. The
menu never reads the database itself: `LoginControl` (after login) and `AddProductControl` (after
a new product) read the reviews and hand them over.

**CustomerMenu**
```csharp
// in display(): one card per unreviewed product
ProductCard card = new ProductCard();
card.displayCustomer(mproductList.getProduct(i));
card.rateProductClicked += (sender, e) =>
{
    clickedProductID = ((ProductCard)sender).getProductID();
    selectProduct();      // RAD Figure 2.5.6: selectedProductID = clickedProductID
    rateProduct();
};

public void rateProduct()
{
    RateProductControl control = new RateProductControl(productList => display(productList));
    control.rateProduct(userID, selectedProductID);
}
```
The Customer Page heading is "Unreviewed Product List" with the count on the right (RAD Figure 3.3.1).

The menus get the logged-in `userID` (and the seller's `username`) from login. Both menus call
`ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);` once in their
constructor, so the cards fill the list (up to 1800 px wide) and stay centered.

---

## 6. How to test it

Build with **Ctrl+Shift+B**; it should say 0 errors (nullable warnings are normal). Press **F5**,
click **Startup**, then log in. The sample accounts are `seller1` and `customer1`, both with the
password `pass123`.

**Add Product** (log in as `seller1`, press **Add Product**)

Try: Submit with an empty form (→ `Title:` error), a letter in the price (→ `Price:`),
`12.345` (→ `Price:`), then a valid product. The page closes and the new product appears on the
Seller Page (Count goes up by 1). Check that the X button and Alt+F4 don't close the page.

**Rate Product** (log out, log in as `customer1`, press **Rate Product** on a card)

Try: Submit with no stars (→ `Rating:` error), with no review (→ `Review:`), then a valid one.
The page closes, the product is gone from the Customer Page and the Count goes down by 1. Log in
as `seller1` again: the product shows the new overall rating and, under **Reviews**, the review.
In **DB Browser for SQLite** check `PRODUCTRATING` (new row), `PURCHASE` (`rated = 1`) and
`PRODUCT.overallRating`.

**Display scaling** (only if your screen allows it)

In Windows **Settings → System → Display → Scale**, choose 125% or 150% and run the program again.
Every window (Startup, Login, both menus, Add Product, Rating) should be enlarged, fit on the
screen and show a scroll bar if the page is taller than the screen. Set the scale back afterwards.

To reset the data, delete `bin/Debug/net9.0-windows/ProductRatingSystem.db` (and the
`Images/Products` folder next to it, if you like).
