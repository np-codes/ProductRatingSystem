using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // Shared base for role-specific main menus (RAD Figure 4.2.1: MainMenu).
    public abstract class MainMenu : ApplicationForm
    {
        public int userID;

        // RAD Figure 4.2.1: -username and -productList are private.
        private string username;
        private ProductList productList;

        // Shows the logged-in user's name in the header box.
        protected Label userLabel;

        // Count shown at the right end of the heading box ("Count: 3").
        protected Label countLabel;

        // The two top boxes, kept so they can be scaled for the display (see scaleForDisplay).
        private Panel headerBox;
        private Panel headingBox;
        private bool scaledForDisplay;

        // Design heights (at 100% display scaling) of the two top boxes.
        private const int headerHeight = 10 + 64;
        private const int headingHeight = 8 + 52;

        protected MainMenu()
        {
            userID = 0;
            username = "";
        }

        // The user name shown in the header.
        public string getUsername()
        {
            return username;
        }

        public void setUsername(string musername)
        {
            username = musername ?? "";
        }

        // The products shown on the page; kept by display() in the subclasses.
        protected ProductList getProductList()
        {
            return productList;
        }

        protected void setProductList(ProductList mproductList)
        {
            productList = mproductList;
        }

        // Shows the page for the given products and user name (RAD Figure 4.2.1).
        // close() is inherited from ApplicationForm.
        public abstract void display(ProductList mproductList, string musername);

        // The Logout button (RAD Figure 2.5.4). LogoutControl closes this menu
        // and shows the Login page.
        public void logout()
        {
            new LogoutControl(this).logout(userID);
        }

        // Space around the two top boxes. The right side also leaves room for the
        // scroll bar, so the boxes line up with the product cards below them.
        private static Padding boxMargin(int mtop)
        {
            return new Padding(10, mtop, 10 + SystemInformation.VerticalScrollBarWidth, 0);
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
                Height = headerHeight,
                Padding = boxMargin(10)
            };

            Panel box = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ApplicationForm.HeaderBackground,
                BorderStyle = BorderStyle.FixedSingle
            };

            userLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = ApplicationForm.UsernameFont,
                ForeColor = ApplicationForm.TextColor,
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
                button.Margin = new Padding(0, 11, 10, 11);
                button.Font = ApplicationForm.ButtonFont;
                buttonPanel.Controls.Add(button);
            }

            Button logoutButton = new Button
            {
                Text = "Logout",
                Size = new Size(96, 38),
                Margin = new Padding(0, 11, 0, 11)
            };
            ApplicationForm.StyleSecondaryButton(logoutButton);
            logoutButton.Font = ApplicationForm.ButtonFont;
            logoutButton.Click += (sender, e) => logout();
            buttonPanel.Controls.Add(logoutButton);

            // Fill first, then the docked edge (docking is applied from the last added).
            box.Controls.Add(userLabel);
            box.Controls.Add(buttonPanel);
            outer.Controls.Add(box);
            headerBox = outer;
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
                Height = headingHeight,
                Padding = boxMargin(8)
            };

            Panel box = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ApplicationForm.Surface,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label headingLabel = new Label
            {
                Text = mtext,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = ApplicationForm.HeadingFont,
                ForeColor = ApplicationForm.TextColor,
                Padding = new Padding(14, 0, 0, 0)
            };

            countLabel = new Label
            {
                Text = "Count: 0",
                Dock = DockStyle.Right,
                Width = 140,
                TextAlign = ContentAlignment.MiddleRight,
                Font = ApplicationForm.CountFont,
                ForeColor = ApplicationForm.MutedTextColor,
                Padding = new Padding(0, 0, 14, 0)
            };

            box.Controls.Add(headingLabel);
            box.Controls.Add(countLabel);
            outer.Controls.Add(box);
            headingBox = outer;
            return outer;
        }

        protected override void OnLoad(EventArgs e)
        {
            scaleForDisplay();
            base.OnLoad(e);
        }

        // Windows display scaling (125%, 150%, ...). The menus are built in code, not
        // in the Visual Studio designer, so Windows does not enlarge them by itself
        // the way it does the designer-made forms: the text grows but the window and
        // the boxes stay at their 100% size. This scales the window and the two top
        // boxes once, by hand. The product cards scale themselves (ProductCard is
        // made in the designer), so the product list is not scaled again here.
        private void scaleForDisplay()
        {
            if (scaledForDisplay)
            {
                return;
            }
            scaledForDisplay = true;

            float dpi;
            using (Graphics graphics = CreateGraphics())
            {
                dpi = graphics.DpiX;
            }
            float factor = dpi / 96F;

            // Nothing to do at 100%, or if Windows already scaled the boxes.
            if (factor <= 1.01F || headerBox == null || headerBox.Height != headerHeight)
            {
                return;
            }

            SizeF scale = new SizeF(factor, factor);
            headerBox.Scale(scale);
            if (headingBox != null)
            {
                headingBox.Scale(scale);
            }
            ClientSize = new Size((int)Math.Round(ApplicationForm.FormClientSize.Width * factor),
                (int)Math.Round(ApplicationForm.FormClientSize.Height * factor));
            // ApplicationForm then shrinks the window to the screen if it is too big.
        }
    }
}
