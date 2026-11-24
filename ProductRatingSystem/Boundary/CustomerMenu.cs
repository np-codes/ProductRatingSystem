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
        private FlowLayoutPanel productPanel;

        public CustomerMenu()
        {
            selectedProductID = 0;
            Text = "Customer Menu";

            productPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };

            // Header: user name on the left, [Logout] on the right.
            Panel header = createHeader();
            Panel heading = createHeading("Available Products");

            // Docking is applied from the last added control: header first (top),
            // then the heading bar (title left, count right); the list fills the rest.
            Controls.Add(productPanel);
            Controls.Add(heading);
            Controls.Add(header);
            ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);
        }

        public void display(ProductList mproductList)
        {
            userLabel.Text = username;
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
