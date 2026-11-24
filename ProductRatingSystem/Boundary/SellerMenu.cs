using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // The Seller Page (RAD Figure 4.2.1). It never reads the database: the control
    // that opens it (LoginControl or AddProductControl) hands over the reviews of
    // the seller's products with setReviews() before display().
    public class SellerMenu : MainMenu
    {
        private FlowLayoutPanel productPanel;
        private Button addButton;

        // Reviews of the shown products, by product ID.
        private Dictionary<int, ReviewList> reviews = new Dictionary<int, ReviewList>();

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
            StylePrimaryButton(addButton);
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

        // Sets the reviews that display() shows with each product.
        public void setReviews(Dictionary<int, ReviewList> mreviews)
        {
            reviews = mreviews ?? new Dictionary<int, ReviewList>();
        }

        public override void display(ProductList mproductList, string musername)
        {
            setUsername(musername);
            setProductList(mproductList);
            userLabel.Text = getUsername();
            productPanel.Controls.Clear();

            int count = mproductList == null ? 0 : mproductList.getCount();
            if (mproductList != null)
            {
                for (int i = 0; i < count; i++)
                {
                    Product product = mproductList.getProduct(i);
                    ReviewList productReviews;
                    if (!reviews.TryGetValue(product.getProductID(), out productReviews))
                    {
                        productReviews = new ReviewList(new ProductRating[0]);
                    }
                    ProductCard card = new ProductCard();
                    card.displaySeller(product, productReviews);
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
                (productList, productReviews) =>
                {
                    setReviews(productReviews);
                    display(productList, getUsername());
                });
            control.addProduct(userID);
        }

    }
}
