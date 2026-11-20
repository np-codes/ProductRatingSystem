using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // The Rating Page (RAD Figure 3.3.2). Shows the selected product's title,
    // image, description and price, a five-star rating control and a review
    // box. The page cannot be closed or cancelled until a valid rating has
    // been submitted (RAD 1.1).
    // Associations: created and controlled by RateProductControl; shows the
    //               ProductRating it receives in display().
    public partial class RatingForm : Form
    {
        private ProductRating productRating;
        private int rating;
        private string review;

        // Extra helper fields (not in the class diagram).
        private RateProductControl rateProductControl;
        private Product product;
        private Button[] starButtons;
        private bool allowClose;

        public RatingForm(RateProductControl mcontrol, Product mproduct)
        {
            InitializeComponent();
            rateProductControl = mcontrol;
            product = mproduct;
            productRating = null;
            rating = 0;
            review = "";
            allowClose = false;

            starButtons = new Button[] { star1Button, star2Button, star3Button, star4Button, star5Button };
            reviewTextBox.MaxLength = RateProductControl.maxReviewLength;

            showProduct();
            showStars();
            updateCharacterCount();
        }

        // Shows the page for the given (blank) ProductRating. It is modal: the
        // Customer Page cannot be used while it is open. Returns after close().
        public void display(ProductRating mproductRating)
        {
            productRating = mproductRating;
            rating = productRating != null ? productRating.getRating() : 0;
            review = productRating != null && productRating.getReview() != null ? productRating.getReview() : "";
            reviewTextBox.Text = review;
            showStars();

            ShowDialog();
            Dispose();
        }

        // Hands the chosen stars and the review to the control, which validates
        // and saves them (RAD Figure 2.5.6).
        public void submit()
        {
            review = reviewTextBox.Text;

            submitButton.Enabled = false;
            try
            {
                rateProductControl.submit(rating, review);
            }
            finally
            {
                if (!IsDisposed)
                {
                    submitButton.Enabled = true;
                }
            }
        }

        // Called by RateProductControl after the rating has been saved.
        public void close()
        {
            allowClose = true;
            Close();
        }

        // Shows a validation or save error. The message names the field.
        public void displayError(string mmessage)
        {
            MessageBox.Show(this, mmessage, "Rate Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (mmessage.StartsWith("Rating"))
            {
                star1Button.Focus();
            }
            else if (mmessage.StartsWith("Review"))
            {
                reviewTextBox.Focus();
            }
        }

        // ---- private ----

        private void showProduct()
        {
            titleLabel.Text = product.getTitle();
            descriptionTextBox.Text = product.getDescription();
            priceLabel.Text = ProductCard.formatPrice(product.getPrice());
            productPicture.Image = ProductCard.loadImage(product.getImage());
        }

        // Filled stars up to the chosen rating, empty stars after it.
        private void showStars()
        {
            for (int i = 0; i < starButtons.Length; i++)
            {
                starButtons[i].Text = i < rating ? "★" : "☆";
            }
            ratingValueLabel.Text = rating == 0 ? "(not selected)" : rating + " of 5";
        }

        private void selectRating(int mrating)
        {
            rating = mrating;
            showStars();
        }

        private void updateCharacterCount()
        {
            reviewCountLabel.Text = reviewTextBox.Text.Length + " / " + reviewTextBox.MaxLength + " characters";
        }

        private void starButton_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(starButtons, sender);
            if (index >= 0)
            {
                selectRating(index + 1);
            }
        }

        // Keys 1 to 5 also choose the rating while a star has the focus.
        private void starButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '1' && e.KeyChar <= '5')
            {
                selectRating(e.KeyChar - '0');
                e.Handled = true;
            }
        }

        private void reviewTextBox_TextChanged(object sender, EventArgs e)
        {
            updateCharacterCount();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            submit();
        }

        // If the page is taller or wider than the screen (for example on a laptop
        // with Windows display scaling at 125% or 150%), shrink the window to fit
        // the screen; the scroll bars then reach the rest of the page.
        private void ratingForm_Load(object sender, EventArgs e)
        {
            Rectangle screen = Screen.FromControl(this).WorkingArea;
            int height = Math.Min(Height, screen.Height);
            int width = Width;
            if (height < Height)
            {
                // room for the vertical scroll bar, so no sideways scrolling is needed
                width += SystemInformation.VerticalScrollBarWidth + 4;
            }
            width = Math.Min(width, screen.Width);
            if (width != Width || height != Height)
            {
                Size = new Size(width, height);
                Location = new Point(screen.Left + (screen.Width - width) / 2,
                    screen.Top + (screen.Height - height) / 2);
            }
            centerContent();
        }

        private void ratingForm_Resize(object sender, EventArgs e)
        {
            centerContent();
        }

        // Keeps the page centered when the window is wider than the page.
        // When it is narrower, the page starts at the left and scrolls.
        private void centerContent()
        {
            int left = Math.Max(0, (ClientSize.Width - contentPanel.Width) / 2);
            contentPanel.Left = left + AutoScrollPosition.X;
        }

        // The page cannot be cancelled: closing by the user is blocked until
        // the rating has been submitted successfully.
        private void ratingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MessageBox.Show(this, "Please choose a rating, write a review and press Submit.", "Rate Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ratingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (productPicture.Image != null)
            {
                productPicture.Image.Dispose();
                productPicture.Image = null;
            }
        }
    }
}
