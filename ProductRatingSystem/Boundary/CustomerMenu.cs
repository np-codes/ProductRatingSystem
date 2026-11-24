using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // The Customer Page (RAD Figure 4.2.1).
    public class CustomerMenu : MainMenu
    {
        private int selectedProductID;
        private FlowLayoutPanel productPanel;

        // ID of the product whose "Rate Product" button was pressed last;
        // selectProduct() turns it into the selected product.
        private int clickedProductID;

        public CustomerMenu()
        {
            selectedProductID = 0;
            clickedProductID = 0;
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

        public override void display(ProductList mproductList, string musername)
        {
            setUsername(musername);
            display(mproductList);
        }

        public void display(ProductList mproductList)
        {
            setProductList(mproductList);
            userLabel.Text = getUsername();
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
                        clickedProductID = ((ProductCard)sender).getProductID();
                        selectProduct();
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

        // The customer chose a product (RAD Figure 2.5.6: selectProduct()).
        public void selectProduct()
        {
            selectedProductID = clickedProductID;
        }

        public void rateProduct()
        {
            RateProductControl control = new RateProductControl(productList => display(productList));
            control.rateProduct(userID, selectedProductID);
        }

    }
}
