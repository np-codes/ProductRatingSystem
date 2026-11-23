using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    public class CustomerMenu : MainMenu
    {
        private int selectedProductID;
        private Label titleLabel;
        private Label countLabel;
        private FlowLayoutPanel productPanel;
        private Button logoutButton;

        public CustomerMenu()
        {
            selectedProductID = 0;
            Text = "Customer Menu";
            Size = new Size(900, 650);
            StartPosition = FormStartPosition.CenterScreen;

            titleLabel = new Label { Text = "Available Products", Dock = DockStyle.Top,
                Height = 55, TextAlign = ContentAlignment.MiddleCenter,
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
            logoutButton = new Button { Text = "Logout", Dock = DockStyle.Right,
                Width = 100, Height = 55, Margin = new Padding(0) };
            UiTheme.StyleSecondaryButton(logoutButton);
            logoutButton.Click += (sender, e) => logout();

            Panel header = new Panel { Dock = DockStyle.Top, Height = 55 };
            header.BackColor = UiTheme.Surface;
            titleLabel.Dock = DockStyle.Fill;
            header.Controls.Add(titleLabel);
            header.Controls.Add(logoutButton);
            logoutButton.Dock = DockStyle.Right;

            Controls.Add(productPanel);
            Controls.Add(countLabel);
            Controls.Add(header);
            ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);
        }

        public void display(ProductList mproductList)
        {
            productPanel.Controls.Clear();
            int count = mproductList == null ? 0 : mproductList.getCount();
            if (mproductList != null)
            {
                for (int i = 0; i < count; i++)
                {
                    ProductCard card = new ProductCard();
                    card.displayCustomer(mproductList.getProduct(i));
                    card.rateProductClicked += (sender, e) =>
                    {
                        selectedProductID = ((ProductCard)sender).getProductID();
                        rateProduct();
                    };
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

        public void selectProduct(int mproductID)
        {
            selectedProductID = mproductID;
        }

        public void rateProduct()
        {
            RateProductControl control = new RateProductControl(productList => display(productList));
            control.rateProduct(userID, selectedProductID);
        }

    }
}
