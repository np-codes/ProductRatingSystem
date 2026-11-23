using System;
using ProductRatingSystem.Boundary;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Logs the user out and returns to a new LoginForm.
    public class LogoutControl : Controller
    {

        public void logout(int muserID)
        {
            db.logSession(muserID, "LOGOUT", DateTime.Now);
            LoginForm loginForm = new LoginForm();
            loginForm.display();
        }

        public void logout()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.display();
        }
    }
}
