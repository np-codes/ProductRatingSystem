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

Class and method names follow RAD Figures 4.2.1 and 4.2.2 exactly. Nothing in `Entity/`,
`DBConnectorControl` or anyone else's files was changed.

---

## 2. Files

| File | New/changed | What it is |
|---|---|---|
| `Control/AddProductControl.cs` | new | AddProduct use case logic |
| `Control/RateProductControl.cs` | new | RateProduct use case logic |
| `Boundary/AddProductForm.cs` + `.Designer.cs` + `.resx` | new | AddProduct Page |
| `Boundary/RatingForm.cs` + `.Designer.cs` + `.resx` | new | Rating Page |
| `Boundary/ProductCard.cs` + `.Designer.cs` + `.resx` | new | Product card for the Seller/Customer Pages (helper, not in the class diagram) |
| `MEMBER3_EXPLANATION.md` | new | this file |

The forms have normal `Designer.cs` files, so they open in the Visual Studio designer. Both pages
open at the team size (`ClientSize` 600 x 780), centered, white background, black text.
**One difference from the team form rules:** they can be resized and have scroll bars (see 3.7).

---

## 3. Classes

### 3.1 `AddProductControl` (Control)

| Member | In RAD? | What it does |
|---|---|---|
| `-userID:int` | yes | The logged-in seller. |
| `AddProductControl(Action<ProductList> mshowProducts)` | constructor | `mshowProducts` is called with the refreshed product list after saving. The SellerMenu uses it to show the Seller Page again (see section 5). |
| `+addProduct(int):void` | yes | Stores the seller's ID, creates the `AddProductForm` and calls `display()`. |
| `+submit(Product):void` | yes | Calls `validate`. If it fails: `displayError(...)` and the page stays open. If it passes: copies the picture (see below), `db.saveProduct(userID, product)`, `close()` the page, `db.getProducts(userID)`, then calls `mshowProducts(productList)`. |
| `-validate(Product):bool` | yes | Checks every field. Error messages start with the field name (RAD 2.2 Usability). |
| `-isImageFile`, `-storeImage` | helpers | Image checks; copying the picture. |

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
| `-calculateAverage(ReviewList):double` | yes | Average of all ratings, rounded to 2 decimals; 0 when there are none. |
| `-findProduct` | helper | Finds a product by ID in a `ProductList`. |
| `maxReviewLength` | constant | 1000; `RatingForm` uses it too. |

If saving the rating fails, the page stays open with the error. If the rating was saved but
updating the average fails, a warning is shown and the page closes anyway, so the same rating
can't be submitted twice.

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

A `UserControl` (540 px wide) with the picture, title, description and price.

| Member | What it does |
|---|---|
| `displaySeller(Product, ReviewList)` | Also shows "Overall Rating: 3.5 ★★★★☆" and a **Reviews (n) ▼** button that opens/closes the list ("Review 1 - ★★★★★ - text (Nov 20, 2026)"). |
| `displayCustomer(Product)` | Shows a **Rate Product** button instead. |
| `event rateProductClicked` | Raised when Rate Product is pressed. |
| `getProductID()` | ID of the product on the card. |
| `static stars(double)` | `3.6` → `★★★★☆` (rounded to whole stars). |
| `static loadImage(string)` | Loads a product picture (absolute, or relative to the `.exe`). Placeholder if missing. |
| `static formatPrice(double)` / `formatRating(double)` | `$44.30` / `3.7` |
| `static keepCentered(FlowLayoutPanel, int)` | Call once for a product list. The cards stretch with the window from 540 px up to the given width (use `defaultMaximumCardWidth` = 1800) and stay centered. Re-arranges on every resize and when cards are added. |
| `static arrangeCards(FlowLayoutPanel, int)` | Does the same arranging once (used by `keepCentered`). |

The title, description, rating line and Reviews list stretch with the card (`Anchor`), and the
open review list re-wraps its text when the card gets wider or narrower.

The card never reads the database. Whoever builds the page passes the data in.

### 3.7 Resizing and scroll bars

At 600 x 780 the pages can be taller than a laptop screen, especially with Windows display
scaling at 125% or 150%. Then the bottom of the page (the Submit button) was cut off. So both pages:
- put all their controls on one 600 x 780 panel (`contentPanel`) and have `AutoScroll = true`:
  when the window is smaller than the page, scroll bars appear;
- are resizable (`FormBorderStyle = Sizable`, maximize allowed, minimum 360 x 300);
- shrink to fit the screen when they open (`Load` event) if they would be taller or wider
  than it, and stay centered on the screen;
- keep the page centered horizontally when the window is made wider (`Resize` event,
  `centerContent()`).

In the Visual Studio designer, the controls are now inside `contentPanel`. To move one, select
it as usual; to add a new control, drop it onto the panel, not the form.

---

## 4. Call flow

```
AddProduct (Seller)
SellerMenu.addProduct()
  └─ new AddProductControl(list => display(list, username)).addProduct(userID)
       ├─ new AddProductForm(this).display()          (modal)
       │     Seller fills in, presses Submit
       │     AddProductForm.submit() → new Product(...) → control.submit(product)
       ├─ validate(product)   ── fails → form.displayError("Price: ...")  (page stays open)
       ├─ storeImage + db.saveProduct(userID, product)
       ├─ form.close()
       ├─ db.getProducts(userID)
       └─ showProducts(productList)  → SellerMenu.display(productList, username)

RateProduct (Customer)
CustomerMenu.selectProduct() + rateProduct()
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

## 5. For Member 2: connecting the menus

The RAD's sequence diagrams end with the control calling `SellerMenu.display(productList, username)`
or `CustomerMenu.display(productList)`. The menus don't exist yet, so the controls take a
method to call at that point (constructor parameter). That keeps the project building now, and
it means my classes never need to know which menu object is open. Suggested code:

**SellerMenu**
```csharp
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

public void addProduct()
{
    AddProductControl control = new AddProductControl(productList => display(productList, username));
    control.addProduct(userID);
}

public void display(ProductList mproductList, string musername)
{
    // productPanel: a FlowLayoutPanel (TopDown, AutoScroll, WrapContents = false) on the form.
    // Once, e.g. in the constructor:
    //     ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);
    productPanel.Controls.Clear();
    DBConnectorControl db = new DBConnectorControl();
    for (int i = 0; i < mproductList.getCount(); i++)
    {
        Product product = mproductList.getProduct(i);
        ProductCard card = new ProductCard();
        card.displaySeller(product, db.getReviews(product.getProductID()));
        productPanel.Controls.Add(card);
    }
    // ... set the username label, then Show() if not already visible
}
```

**CustomerMenu**
```csharp
public void display(ProductList mproductList)
{
    productPanel.Controls.Clear();
    for (int i = 0; i < mproductList.getCount(); i++)
    {
        ProductCard card = new ProductCard();
        card.displayCustomer(mproductList.getProduct(i));
        card.rateProductClicked += (sender, e) =>
        {
            selectedProductID = ((ProductCard)sender).getProductID();   // selectProduct()
            rateProduct();
        };
        productPanel.Controls.Add(card);
    }
    countLabel.Text = "Count: " + mproductList.getCount();
    // ... Show() if not already visible
}

public void rateProduct()
{
    RateProductControl control = new RateProductControl(productList => display(productList));
    control.rateProduct(userID, selectedProductID);
}
```

The menus need the logged-in `userID` (and the seller's `username`), passed in from login.
Call `ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);` once for
each page's product panel (both menus), so the cards stretch with the window up to 1800 px wide
and stay centered. Make the menu forms resizable for this to be useful.

---

## 6. How to test it

Build with **Ctrl+Shift+B**; it should say 0 errors (nullable warnings are normal).

Until the menus exist, test with a few **temporary** lines in `Control/StartupControl.cs`,
`initiate()`, right after `db.initializeDB();` (instead of the two `Form1` lines). With the
sample data, `customer1` is user 1 and `seller1` is user 2.

**Add Product**
```csharp
new AddProductControl(list => MessageBox.Show("seller1 now has " + list.getCount() + " products")).addProduct(2);
```
Try: Submit with an empty form (→ `Title:` error), a letter in the price (→ `Price:`),
`12.345` (→ `Price:`), then a valid product (message: "seller1 now has 4 products").
Check that the X button and Alt+F4 don't close the page.

**Rate Product**
```csharp
new RateProductControl(list => MessageBox.Show("Products left to rate: " + list.getCount())).rateProduct(1, 1);
```
Try: Submit with no stars (→ `Rating:` error), with no review (→ `Review:`), then a valid one
(message: "Products left to rate: 2"). Run it again with the same product: it says the product
is no longer available for rating, because customer1 already rated it. In **DB Browser for SQLite**
check `PRODUCTRATING` (new row), `PURCHASE` (`rated = 1`) and `PRODUCT.overallRating`.

**Remove these lines again before committing.** (After the test page closes, no window is left
open, so the app ends. That's expected.)

To reset the data, delete `bin/Debug/net9.0-windows/ProductRatingSystem.db` (and the
`Images/Products` folder next to it, if you like).
