using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ProductRatingSystem.Boundary;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Use case: AddProduct (RAD Table 2.4.5, Figure 2.5.5)
    // Associations: AddProductControl creates and controls the AddProductForm,
    //               validates the Product it receives, and uses DBConnectorControl
    //               to save it and to reload the seller's ProductList.
    public class AddProductControl : Controller
    {
        private int userID;
        private DBConnectorControl db = new DBConnectorControl();

        // Extra helper fields (not in the class diagram).
        private AddProductForm addProductForm;
        private Action<ProductList, Dictionary<int, ReviewList>> showProducts;
        private string errorMessage;

        // Maximum size of a product image file (5 MB).
        private const long maxImageBytes = 5L * 1024 * 1024;

        // mshowProducts is called with the refreshed product list and the reviews
        // of its products after the product has been saved. The SellerMenu passes
        // a method that shows the Seller Page again, e.g.
        //     new AddProductControl((list, reviews) => { setReviews(reviews); display(list, username); })
        public AddProductControl(Action<ProductList, Dictionary<int, ReviewList>> mshowProducts)
        {
            userID = 0;
            showProducts = mshowProducts;
            errorMessage = "";
        }

        // Called by SellerMenu.addProduct(). Opens the AddProduct Page.
        // The page cannot be cancelled: it stays open until a valid
        // product has been submitted (RAD 1.1).
        public void addProduct(int muserID)
        {
            userID = muserID;
            addProductForm = new AddProductForm(this);
            addProductForm.display();
        }

        // Called by AddProductForm.submit() with the product the seller entered.
        public void submit(Product mproduct)
        {
            if (!validate(mproduct))
            {
                addProductForm.displayError(errorMessage);
                return;
            }

            try
            {
                // Copy the chosen picture into the program's Images folder so the
                // product still has its picture if the original file is moved.
                string storedImage = storeImage(mproduct.getImage());
                Product product = new Product(0, userID, mproduct.getTitle(), storedImage,
                    mproduct.getDescription(), mproduct.getPrice(), 0.0);
                db.saveProduct(userID, product);
            }
            catch (Exception)
            {
                // The details of the error are not shown to the user.
                addProductForm.displayError("The product could not be saved. Please try again.");
                return;
            }

            addProductForm.close();

            ProductList productList = db.getProducts(userID);
            if (showProducts != null)
            {
                showProducts(productList, loadReviews(productList));
            }
        }

        // The Seller Page also shows the reviews of every product, so they are
        // read here and handed to the SellerMenu (the menu never touches the database).
        private Dictionary<int, ReviewList> loadReviews(ProductList mproductList)
        {
            Dictionary<int, ReviewList> reviews = new Dictionary<int, ReviewList>();
            for (int i = 0; i < mproductList.getCount(); i++)
            {
                Product product = mproductList.getProduct(i);
                reviews[product.getProductID()] = db.getReviews(product.getProductID());
            }
            return reviews;
        }

        // Checks every field. On failure errorMessage names the field that
        // caused it (RAD 2.2 Usability). All database access uses parameters,
        // so the text itself can never change the SQL (RAD 2.2 Security).
        private bool validate(Product mproduct)
        {
            errorMessage = "";

            if (mproduct == null)
            {
                errorMessage = "Please fill out the form.";
                return false;
            }

            // The Product constructor leaves a field null when the value was
            // blank or too long, so null means "missing or too long".
            if (mproduct.getTitle() == null)
            {
                errorMessage = "Title: please enter a title of 1 to 100 characters.";
                return false;
            }

            string image = mproduct.getImage();
            if (image == null)
            {
                errorMessage = "Image: please choose a picture of the product.";
                return false;
            }
            if (!isImageFile(image))
            {
                return false;
            }

            if (mproduct.getDescription() == null)
            {
                errorMessage = "Description: please enter a description of 1 to 1000 characters.";
                return false;
            }

            // The Product constructor keeps 0 when the price was not a valid number.
            double price = mproduct.getPrice();
            if (price <= 0.0 || price > 1000000.0)
            {
                errorMessage = "Price: please enter a number greater than 0 and at most 1,000,000 (for example 44.30).";
                return false;
            }
            if (Math.Round(price, 2) != price)
            {
                errorMessage = "Price: please use at most 2 digits after the decimal point (for example 44.30).";
                return false;
            }

            return true;
        }

        // Helper for validate(): the image must be an existing, readable picture.
        private bool isImageFile(string mpath)
        {
            string extension = Path.GetExtension(mpath).ToLowerInvariant();
            if (extension != ".png" && extension != ".jpg" && extension != ".jpeg"
                && extension != ".bmp" && extension != ".gif")
            {
                errorMessage = "Image: the picture must be a .png, .jpg, .jpeg, .bmp or .gif file.";
                return false;
            }

            if (!File.Exists(mpath))
            {
                errorMessage = "Image: the chosen file could not be found. Please choose it again.";
                return false;
            }

            if (new FileInfo(mpath).Length > maxImageBytes)
            {
                errorMessage = "Image: the picture must be 5 MB or smaller.";
                return false;
            }

            try
            {
                using (Image picture = Image.FromFile(mpath))
                {
                }
            }
            catch (Exception)
            {
                errorMessage = "Image: the chosen file is not a picture that can be opened.";
                return false;
            }

            return true;
        }

        // Copies the picture to Images/Products/ next to the .exe and returns
        // the path that is stored in the database (relative to the .exe folder).
        private string storeImage(string mpath)
        {
            string folder = Path.Combine(AppContext.BaseDirectory, "Images", "Products");
            Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(mpath).ToLowerInvariant();
            File.Copy(mpath, Path.Combine(folder, fileName));

            return "Images/Products/" + fileName;
        }
    }
}
