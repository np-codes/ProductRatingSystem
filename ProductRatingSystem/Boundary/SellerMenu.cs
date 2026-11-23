using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    public class SellerMenu : MainMenu
    {
        public string username;
        private Label titleLabel;
        private Label countLabel;
        private FlowLayoutPanel productPanel;
        private Button addButton;
        private Button logoutButton;

        public SellerMenu()
        {
            username = "";
            Text = "Seller Menu";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;

            titleLabel = new Label { Text = "My Products", Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold) };
            countLabel = new Label { Text = "Count: 0", Dock = DockStyle.Bottom,
                Height = 35, TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0) };
            productPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };
            addButton = new Button { Text = "Add Product", Dock = DockStyle.Left,
                Width = 120, Height = 55 };
            logoutButton = new Button { Text = "Logout", Dock = DockStyle.Right,
                Width = 100, Height = 55 };
            UiTheme.StylePrimaryButton(addButton);
            UiTheme.StyleSecondaryButton(logoutButton);
            addButton.Click += (sender, e) => addProduct();
            logoutButton.Click += (sender, e) => logout();

            Panel header = new Panel { Dock = DockStyle.Top, Height = 55 };
            header.BackColor = UiTheme.Surface;
            header.Controls.Add(titleLabel);
            header.Controls.Add(addButton);
            header.Controls.Add(logoutButton);

            Controls.Add(productPanel);
            Controls.Add(countLabel);
            Controls.Add(header);
            ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);
        }

        public void display(ProductList mproductList, string musername)
        {
            username = musername ?? "";
            titleLabel.Text = "Products for " + username;
            productPanel.Controls.Clear();

            DBConnectorControl db = new DBConnectorControl();
            int count = mproductList == null ? 0 : mproductList.getCount();
            if (mproductList != null)
            {
                for (int i = 0; i < count; i++)
                {
                    Product product = mproductList.getProduct(i);
                    ProductCard card = new ProductCard();
                    card.displaySeller(product, db.getReviews(product.getProductID()));
                    productPanel.Controls.Add(card);
                }
            }
            countLabel.Text = "Count: " + count;
            if (!Visible)
            {
                Show();
            }
            Activate();
        }

        public void addProduct()
        {
            AddProductControl control = new AddProductControl(
                productList => display(productList, username));
            control.addProduct(userID);
        }

    }
}
