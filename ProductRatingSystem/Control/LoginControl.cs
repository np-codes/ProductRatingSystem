using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ProductRatingSystem.Boundary;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Use case: Login (RAD Tables 2.4.2 and 2.4.3, Figures 2.5.2 and 2.5.3)
    // Associations: LoginControl controls the LoginForm, uses DBConnectorControl
    //               to check the account and to log the event, and opens the
    //               role-specific main menu.
    public class LoginControl : Controller
    {
        // Longest username and password that are accepted.
        public const int maxUsernameLength = 50;
        public const int maxPasswordLength = 100;

        private DBConnectorControl db = new DBConnectorControl();

        // Extra helper fields (not in the class diagram).
        private LoginForm loginForm;
        private string errorMessage;

        public LoginControl()
        {
            errorMessage = "";
        }

        public LoginControl(LoginForm mloginForm) : this()
        {
            loginForm = mloginForm;
        }

        // Called by LoginForm.submit(). Same order as RAD Figures 2.5.2 and 2.5.3:
        // validate, getAccount, logSession, close the LoginForm, getProducts, then
        // create and display the main menu for the account's role.
        public void submit(string musername, string mpassword)
        {
            if (!validate(musername, mpassword))
            {
                if (loginForm != null)
                {
                    loginForm.displayError(errorMessage);
                }
                return;
            }

            string username = musername.Trim();
            string passwordHash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(mpassword)));

            UserAccount account = db.getAccount(username, passwordHash);
            if (account == null)
            {
                db.logSession(username, "FAILED_LOGIN", DateTime.Now);
                if (loginForm != null)
                {
                    // Does not say which of the two values was wrong.
                    loginForm.displayError("Invalid username or password.");
                }
                return;
            }

            db.logSession(account.getUserID(), "LOGIN", DateTime.Now);

            if (loginForm != null)
            {
                loginForm.close();
            }

            // Sellers get their own products, customers the products they have not rated yet.
            ProductList productList = db.getProducts(account.getUserID());

            MainMenu menu;
            if (account.getRole() == "Seller")
            {
                SellerMenu sellerMenu = new SellerMenu();
                sellerMenu.setReviews(loadReviews(productList));
                menu = sellerMenu;
            }
            else
            {
                menu = new CustomerMenu();
            }
            menu.userID = account.getUserID();
            menu.display(productList, account.getUsername());
        }

        // Checks the size of both values. On failure errorMessage names the
        // field that caused it (RAD 2.2 Usability). Nothing here says whether an
        // account exists.
        private bool validate(string musername, string mpassword)
        {
            errorMessage = "";

            string username = (musername ?? "").Trim();
            string password = mpassword ?? "";

            if (username.Length == 0)
            {
                errorMessage = "Please enter a username.";
                return false;
            }
            if (username.Length > maxUsernameLength)
            {
                errorMessage = "Username: please use at most " + maxUsernameLength + " characters.";
                return false;
            }
            if (password.Length == 0)
            {
                errorMessage = "Please enter a password.";
                return false;
            }
            if (password.Length > maxPasswordLength)
            {
                errorMessage = "Password: please use at most " + maxPasswordLength + " characters.";
                return false;
            }
            return true;
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
    }
}
