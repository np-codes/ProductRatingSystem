using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    public class SellerMenu : MainMenu
    {
        private FlowLayoutPanel productPanel;
        private Button addButton;

        public SellerMenu()
        {
            Text = "Seller Menu";

            productPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };
            addButton = new Button { Text = "Add Product" };
            UiTheme.StylePrimaryButton(addButton);
            addButton.Click += (sender, e) => addProduct();

            // Header: user name on the left, [Add Product] [Logout] on the right.
            Panel header = createHeader(addButton);
            Panel heading = createHeading("My Products");

            // Docking is applied from the last added control: header first (top),
            // then the heading bar (title left, count right); the list fills the rest.
            Controls.Add(productPanel);
            Controls.Add(heading);
            Controls.Add(header);
            ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);
        }

        public void display(ProductList mproductList, string musername)
        {
            username = musername ?? "";
            userLabel.Text = username;
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
