using System;
using ProductRatingSystem.Boundary;

namespace ProductRatingSystem.Control
{
    // Subsystem: Control
    // Use case: Logout (RAD Table 2.4.4, Figure 2.5.4)
    // Associations: LogoutControl closes the MainMenu, logs the event through
    //               DBConnectorControl and shows a new LoginForm.
    public class LogoutControl : Controller
    {
        private DBConnectorControl db = new DBConnectorControl();

        // Extra helper field (not in the class diagram).
        private MainMenu mainMenu;

        public LogoutControl(MainMenu mmainMenu)
        {
            mainMenu = mmainMenu;
        }

        // Same order as RAD Figure 2.5.4: logSession, close the MainMenu,
        // clearSession, create the LoginForm and display it with the logout message.
        public void logout(int muserID)
        {
            db.logSession(muserID, "LOGOUT", DateTime.Now);
            mainMenu.close();
            clearSession();
            LoginForm loginForm = new LoginForm();
            loginForm.display("You have been logged out.");
        }

        // Forgets the user: the menu's user data is cleared and the menu is released,
        // so nothing of the session is kept after logout.
        private void clearSession()
        {
            mainMenu.userID = 0;
            mainMenu.setUsername("");
            mainMenu = null;
        }
    }
}
