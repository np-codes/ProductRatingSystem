using System;
using System.Security.Cryptography;
using System.Text;
using ProductRatingSystem.Boundary;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Associates LoginForm with DBConnectorControl and the role-specific menu.
    public class LoginControl : Controller
    {
        private LoginForm loginForm;

        public LoginControl()
        {
        }

        public LoginControl(LoginForm mloginForm) : this()
        {
            loginForm = mloginForm;
        }

        // Returns the account on success and null on failure. The form uses
        // the returned account to open the correct menu.
        public UserAccount login(string musername, string mpassword)
        {
            string username = (musername ?? "").Trim();
            string password = mpassword ?? "";

            if (username.Length == 0)
            {
                return loginError("Please enter a username.");
            }
            if (password.Length == 0)
            {
                return loginError("Please enter a password.");
            }

            string passwordHash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(password)));

            UserAccount account = db.getAccount(username, passwordHash);
            if (account == null)
            {
                db.logSession(username, "FAILED_LOGIN", DateTime.Now);
                return loginError("Invalid username or password.");
            }

            db.logSession(account.getUserID(), "LOGIN", DateTime.Now);

            if (loginForm != null)
            {
                loginForm.openMenu(account);
            }
            return account;
        }

        private UserAccount loginError(string mmessage)
        {
            if (loginForm != null)
            {
                loginForm.displayError(mmessage);
            }
            return null;
        }
    }
}
