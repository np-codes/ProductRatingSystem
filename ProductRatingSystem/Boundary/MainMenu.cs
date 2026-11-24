using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;

namespace ProductRatingSystem.Boundary
{
    // Shared base for role-specific main menus.
    public abstract class MainMenu : ApplicationForm
    {
        public int userID;
        public string username;

        // Shows the logged-in user's name in the header box.
        protected Label userLabel;

        // Count shown at the right end of the heading box ("Count: 3").
        protected Label countLabel;

        protected MainMenu()
        {
            userID = 0;
            username = "";
        }

        public void logout()
        {
            new LogoutControl().logout(userID);
            Close();
        }

        // Space around the two top boxes. The right side also leaves room for the
        // scroll bar, so the boxes line up with the product cards below them.
        private static Padding boxMargin(int mtop)
        {
            // 17 = standard scroll bar width at 96 DPI; the form scales it with everything else.
            return new Padding(10, mtop, 10 + 17, 0);
        }

        // Builds the header box shared by the Customer and Seller menus: a light
        // grey box with a thin border and space around it. The user's name is on
        // the left; on the right are the given buttons (in order) followed by the
        // Logout button at the far right.
        protected Panel createHeader(params Button[] mbuttons)
        {
            Panel outer = new Panel
            {
                Dock = DockStyle.Top,
                Height = 10 + 64,
                Padding = boxMargin(10)
            };

            Panel box = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UiTheme.HeaderBackground,
                BorderStyle = BorderStyle.FixedSingle
            };

            userLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = UiTheme.UsernameFont,
                ForeColor = UiTheme.Text,
                AutoEllipsis = true,
                Padding = new Padding(14, 0, 0, 0)
            };

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = Padding.Empty,
                Padding = new Padding(0, 0, 10, 0)
            };
            foreach (Button button in mbuttons)
            {
                button.Size = new Size(120, 38);
                button.AutoSize = true;
                button.AutoSizeMode = AutoSizeMode.GrowOnly;
                button.MinimumSize = new Size(120, 38);
                button.Margin = new Padding(0, 11, 10, 11);
                button.Font = UiTheme.ButtonFont;
                buttonPanel.Controls.Add(button);
            }

            Button logoutButton = new Button
            {
                Text = "Logout",
                Size = new Size(96, 38),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                MinimumSize = new Size(96, 38),
                Margin = new Padding(0, 11, 0, 11)
            };
            UiTheme.StyleSecondaryButton(logoutButton);
            logoutButton.Font = UiTheme.ButtonFont;
            logoutButton.Click += (sender, e) => logout();
            buttonPanel.Controls.Add(logoutButton);

            // Fill first, then the docked edge (docking is applied from the last added).
            box.Controls.Add(userLabel);
            box.Controls.Add(buttonPanel);
            outer.Controls.Add(box);
            return outer;
        }

        // Heading box under the header: a white box with a thin border. The page
        // title is on the left ("My Products", "Available Products") and the
        // product count on the right.
        protected Panel createHeading(string mtext)
        {
            Panel outer = new Panel
            {
                Dock = DockStyle.Top,
                Height = 8 + 52,
                Padding = boxMargin(8)
            };

            Panel box = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UiTheme.Surface,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label headingLabel = new Label
            {
                Text = mtext,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = UiTheme.HeadingFont,
                ForeColor = UiTheme.Text,
                Padding = new Padding(14, 0, 0, 0)
            };

            countLabel = new Label
            {
                Text = "Count: 0",
                Dock = DockStyle.Right,
                Width = 140,
                TextAlign = ContentAlignment.MiddleRight,
                Font = UiTheme.CountFont,
                ForeColor = UiTheme.MutedText,
                Padding = new Padding(0, 0, 14, 0)
            };

            box.Controls.Add(headingLabel);
            box.Controls.Add(countLabel);
            outer.Controls.Add(box);
            return outer;
        }
    }
}
