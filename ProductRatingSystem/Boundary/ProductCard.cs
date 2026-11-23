using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // A product "card" for the Seller Page and the Customer Page (RAD Figures
    // 3.2.1 and 3.3.1): picture, title, description and price.
    //   displaySeller(...)   also shows the overall rating and a "Reviews"
    //                        button that opens/closes the list of reviews.
    //   displayCustomer(...) shows a "Rate Product" button instead and raises
    //                        rateProductClicked when it is pressed.
    // Helper class (not in the class diagram): it only shows data it is given
    // and never reads the database itself.
    public partial class ProductCard : UserControl
    {
        private Product product;
        private ReviewList reviewList;
        private bool reviewsOpen;
        private bool resizing;

        // Narrowest and (default) widest a card is drawn by keepCentered().
        public const int minimumCardWidth = 540;
        public const int defaultMaximumCardWidth = 1800;

        // Raised when the customer presses "Rate Product" on this card.
        public event EventHandler rateProductClicked;

        public ProductCard()
        {
            InitializeComponent();
            product = null;
            reviewList = new ReviewList(new ProductRating[0]);
            reviewsOpen = false;
            resizing = false;
        }

        // Seller Page: product with its overall rating and its reviews.
        public void displaySeller(Product mproduct, ReviewList mreviews)
        {
            showProduct(mproduct);
            UiTheme.StyleSecondaryButton(reviewsButton);
            reviewList = mreviews != null ? mreviews : new ReviewList(new ProductRating[0]);

            ratingLabel.Text = "Overall Rating: " + formatRating(product.getOverallRating())
                + "   " + stars(product.getOverallRating());
            ratingLabel.Visible = true;
            rateButton.Visible = false;
            reviewsButton.Visible = true;

            fillReviews();
            setReviewsOpen(false);
        }

        // Customer Page: product with a "Rate Product" button.
        public void displayCustomer(Product mproduct)
        {
            showProduct(mproduct);
            UiTheme.StylePrimaryButton(rateButton);

            ratingLabel.Visible = false;
            rateButton.Visible = true;
            reviewsButton.Visible = false;
            reviewsPanel.Visible = false;
            Height = rateButton.Bottom + 12;
        }

        // ID of the product shown on this card (0 if none).
        public int getProductID()
        {
            return product != null ? product.getProductID() : 0;
        }

        // ---- shared helpers, also used by AddProductForm and RatingForm ----

        // Five-star text for a rating from 0 to 5, e.g. 3.6 -> "★★★★☆".
        public static string stars(double mrating)
        {
            int full = (int)Math.Round(mrating, MidpointRounding.AwayFromZero);
            if (full < 0)
            {
                full = 0;
            }
            if (full > 5)
            {
                full = 5;
            }
            return new string('★', full) + new string('☆', 5 - full);
        }

        // Loads a product picture. The path may be absolute or relative to the
        // folder of the .exe (e.g. "Images/Products/abc.png"). A missing or
        // broken file gives a light-grey placeholder instead of an error.
        // The caller owns the returned Image and should Dispose it.
        public static Image loadImage(string mpath)
        {
            if (!string.IsNullOrWhiteSpace(mpath))
            {
                try
                {
                    string fullPath = Path.IsPathRooted(mpath)
                        ? mpath
                        : Path.Combine(AppContext.BaseDirectory, mpath);
                    if (File.Exists(fullPath))
                    {
                        // Copy into memory so the file is not kept locked.
                        using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(fullPath)))
                        using (Image picture = Image.FromStream(stream))
                        {
                            return new Bitmap(picture);
                        }
                    }
                }
                catch (Exception)
                {
                    // fall through to the placeholder
                }
            }

            Bitmap placeholder = new Bitmap(200, 200);
            using (Graphics graphics = Graphics.FromImage(placeholder))
            {
                graphics.Clear(Color.Gainsboro);
            }
            return placeholder;
        }

        // Price as text, e.g. 44.3 -> "$44.30".
        public static string formatPrice(double mprice)
        {
            return mprice.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
        }

        // Overall rating as text with one decimal, e.g. 3.67 -> "3.7".
        public static string formatRating(double mrating)
        {
            return mrating.ToString("0.0", CultureInfo.InvariantCulture);
        }

        // Makes the cards in a product list stretch with the window, from
        // minimumCardWidth up to mmaximumWidth, and keeps them centered.
        // Call it once after creating the panel (a FlowLayoutPanel with
        // FlowDirection = TopDown, WrapContents = false, AutoScroll = true);
        // it re-arranges the cards whenever the panel is resized or a card is
        // added. Example (Seller/Customer page):
        //     ProductCard.keepCentered(productPanel, ProductCard.defaultMaximumCardWidth);
        public static void keepCentered(FlowLayoutPanel mpanel, int mmaximumWidth)
        {
            mpanel.Resize += (sender, e) => arrangeCards(mpanel, mmaximumWidth);
            mpanel.ControlAdded += (sender, e) => arrangeCards(mpanel, mmaximumWidth);
            arrangeCards(mpanel, mmaximumWidth);
        }

        // Sets the width and left margin of every card in the panel once.
        public static void arrangeCards(FlowLayoutPanel mpanel, int mmaximumWidth)
        {
            // Room is always left for the vertical scroll bar, so the cards do
            // not jump when it appears or disappears.
            int available = mpanel.ClientSize.Width - mpanel.Padding.Horizontal;
            if (!mpanel.VerticalScroll.Visible)
            {
                available -= SystemInformation.VerticalScrollBarWidth;
            }
            int width = Math.Max(minimumCardWidth, Math.Min(mmaximumWidth, available - 20));
            int left = Math.Max(0, (available - width) / 2);

            mpanel.SuspendLayout();
            foreach (System.Windows.Forms.Control card in mpanel.Controls)
            {
                card.Width = width;
                card.Margin = new Padding(left, 10, 0, 0);
            }
            mpanel.ResumeLayout(true);
        }

        // ---- private ----

        private void showProduct(Product mproduct)
        {
            if (mproduct == null)
            {
                throw new ArgumentNullException(nameof(mproduct));
            }
            product = mproduct;

            titleLabel.Text = product.getTitle();
            descriptionLabel.Text = product.getDescription();
            priceLabel.Text = formatPrice(product.getPrice());

            Image oldImage = pictureBox.Image;
            pictureBox.Image = loadImage(product.getImage());
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        // Builds one label per review: "Review 1 - ★★★★☆ - text (Nov 20, 2026)".
        private void fillReviews()
        {
            reviewsPanel.SuspendLayout();
            while (reviewsPanel.Controls.Count > 0)
            {
                System.Windows.Forms.Control old = reviewsPanel.Controls[0];
                reviewsPanel.Controls.RemoveAt(0);
                old.Dispose();
            }

            if (reviewList.getCount() == 0)
            {
                reviewsPanel.Controls.Add(makeReviewLabel("No reviews yet."));
            }
            for (int i = 0; i < reviewList.getCount(); i++)
            {
                ProductRating review = reviewList.getReview(i);
                if (review == null)
                {
                    continue;
                }
                string text = "Review " + (i + 1) + " - " + stars(review.getRating()) + " - "
                    + (review.getReview() ?? "") + "  ("
                    + review.getTimestamp().ToString("MMM d, yyyy", CultureInfo.GetCultureInfo("en-US")) + ")";
                reviewsPanel.Controls.Add(makeReviewLabel(text));
            }
            reviewsPanel.ResumeLayout(true);

            reviewsButton.Text = "Reviews (" + reviewList.getCount() + ")   " + (reviewsOpen ? "▲" : "▼");
        }

        private Label makeReviewLabel(string mtext)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.MaximumSize = new Size(Math.Max(100, reviewsButton.Width - 24), 0);
            label.Margin = new Padding(4, 4, 4, 4);
            label.Font = new Font("Segoe UI", 9F);
            label.BackColor = Color.White;
            label.ForeColor = Color.Black;
            label.Text = mtext;
            return label;
        }

        private void setReviewsOpen(bool mopen)
        {
            reviewsOpen = mopen;
            reviewsPanel.Visible = mopen;
            reviewsButton.Text = "Reviews (" + reviewList.getCount() + ")   " + (mopen ? "▲" : "▼");

            if (mopen)
            {
                int contentHeight = reviewsPanel.Padding.Vertical;
                foreach (System.Windows.Forms.Control child in reviewsPanel.Controls)
                {
                    contentHeight += child.Height + child.Margin.Vertical;
                }
                reviewsPanel.Height = Math.Min(Math.Max(contentHeight, 30), 200);
                Height = reviewsPanel.Bottom + 12;
            }
            else
            {
                Height = reviewsButton.Bottom + 12;
            }
        }

        // When the card gets wider or narrower, the review lines wrap again,
        // so the open review list is measured again.
        private void productCard_Resize(object sender, EventArgs e)
        {
            if (resizing)
            {
                return;
            }
            resizing = true;
            reviewsPanel.Width = reviewsButton.Width;
            foreach (System.Windows.Forms.Control child in reviewsPanel.Controls)
            {
                child.MaximumSize = new Size(Math.Max(100, reviewsPanel.Width - 24), 0);
            }
            if (reviewsOpen)
            {
                setReviewsOpen(true);
            }
            resizing = false;
        }

        private void reviewsButton_Click(object sender, EventArgs e)
        {
            setReviewsOpen(!reviewsOpen);
        }

        private void rateButton_Click(object sender, EventArgs e)
        {
            if (rateProductClicked != null)
            {
                rateProductClicked(this, EventArgs.Empty);
            }
        }

        private void productCard_Disposed(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
        }
    }
}
