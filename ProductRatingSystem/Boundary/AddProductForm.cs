using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // The AddProduct Page (RAD Figure 3.2.2). The seller enters title, image,
    // description and price and presses Submit. The page cannot be closed or
    // cancelled until a valid product has been submitted (RAD 1.1).
    // Associations: created and controlled by AddProductControl; creates the
    //               Product that is passed to AddProductControl.submit().
    public partial class AddProductForm : ApplicationForm
    {
        private string title;
        private string image;
        private string description;
        private double price;

        // Extra helper fields (not in the class diagram).
        private AddProductControl addProductControl;
        private bool allowClose;

        public AddProductForm(AddProductControl mcontrol)
        {
            InitializeComponent();
            ApplicationForm.StylePrimaryButton(submitButton);
            ApplicationForm.StyleSecondaryButton(chooseImageButton);
            addProductControl = mcontrol;
            title = "";
            image = "";
            description = "";
            price = 0.0;
            allowClose = false;

            previewPicture.Image = ProductCard.loadImage(null);
            updateCharacterCount();
        }

        // Shows the page. It is modal: the Seller Page cannot be used while
        // it is open. Returns after close() has been called.
        public override void display()
        {
            ShowDialog();
            Dispose();
        }

        // Reads the entered values, builds a Product and hands it to the control,
        // which validates and saves it (RAD Figure 2.5.5).
        public void submit()
        {
            title = titleTextBox.Text.Trim();
            description = descriptionTextBox.Text.Trim();
            price = parsePrice(priceTextBox.Text);

            Product product = new Product(0, 0, title, image, description, price, 0.0);

            submitButton.Enabled = false;
            try
            {
                addProductControl.submit(product);
            }
            finally
            {
                if (!IsDisposed)
                {
                    submitButton.Enabled = true;
                }
            }
        }

        // Called by AddProductControl after the product has been saved.
        public override void close()
        {
            allowClose = true;
            Close();
        }

        // Shows a validation or save error. The message names the field.
        public void displayError(string mmessage)
        {
            MessageBox.Show(this, mmessage, "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusField(mmessage);
        }

        // ---- private ----

        // "44.30", "$44.30" and "1,044.30" are accepted. Anything else gives -1,
        // which the Product keeps as 0 and the control reports as a price error.
        private double parsePrice(string mtext)
        {
            string text = (mtext ?? "").Trim().Replace("$", "").Replace(",", "").Trim();
            double value;
            if (text.Length > 0 && double.TryParse(text, NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture, out value))
            {
                return value;
            }
            return -1.0;
        }

        // Puts the cursor in the field that the error message is about.
        private void focusField(string mmessage)
        {
            if (mmessage.StartsWith("Title"))
            {
                titleTextBox.Focus();
            }
            else if (mmessage.StartsWith("Image"))
            {
                chooseImageButton.Focus();
            }
            else if (mmessage.StartsWith("Description"))
            {
                descriptionTextBox.Focus();
            }
            else if (mmessage.StartsWith("Price"))
            {
                priceTextBox.Focus();
                priceTextBox.SelectAll();
            }
        }

        private void chooseImage()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose a picture of the product";
                dialog.Filter = "Pictures (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                image = dialog.FileName;
                Image oldImage = previewPicture.Image;
                previewPicture.Image = ProductCard.loadImage(image);
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
                imageNameLabel.Text = System.IO.Path.GetFileName(image);
            }
        }

        private void updateCharacterCount()
        {
            descriptionCountLabel.Text = descriptionTextBox.Text.Length + " / " + descriptionTextBox.MaxLength + " characters";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            chooseImage();
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            updateCharacterCount();
        }

        // If the page is taller or wider than the screen (for example on a laptop
        // with Windows display scaling at 125% or 150%), shrink the window to fit
        // the screen; the scroll bars then reach the rest of the page.
        private void addProductForm_Load(object sender, EventArgs e)
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

        private void addProductForm_Resize(object sender, EventArgs e)
        {
            centerContent();
        }

        // Keeps the page centered when the window is wider than the page.
        // When it is narrower, the page starts at the left and scrolls.
        private void centerContent()
        {
            int left = (ClientSize.Width - contentPanel.Width) / 2;
            if (VerticalScroll.Visible)
            {
                // never let the page reach under the vertical scroll bar
                left = Math.Min(left, ClientSize.Width - contentPanel.Width
                    - SystemInformation.VerticalScrollBarWidth);
            }
            contentPanel.Left = Math.Max(0, left) + AutoScrollPosition.X;
        }

        // The page cannot be cancelled: closing by the user is blocked until
        // the product has been submitted successfully.
        private void addProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MessageBox.Show(this, "Please complete the form and press Submit.", "Add Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (previewPicture.Image != null)
            {
                previewPicture.Image.Dispose();
                previewPicture.Image = null;
            }
        }
    }
}
