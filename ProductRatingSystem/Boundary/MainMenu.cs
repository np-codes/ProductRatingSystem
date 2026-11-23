using System.Windows.Forms;
using ProductRatingSystem.Control;

namespace ProductRatingSystem.Boundary
{
    // Shared base for role-specific main menus.
    public abstract class MainMenu : ApplicationForm
    {
        public int userID;

        protected MainMenu()
        {
            userID = 0;
        }

        public void logout()
        {
            new LogoutControl().logout(userID);
            Close();
        }
    }
}
