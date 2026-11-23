using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProductRatingSystem.Control;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // Associations: StartupForm calls StartupControl.initiate() when the
    //               Startup button is clicked.
    public partial class StartupForm : ApplicationForm
    {
        // Showcase content: fixed on purpose, the database is not
        // initialized until the Startup button is clicked.
        private const int showcaseRating1 = 4;
        private const int showcaseRating2 = 3;
        private const int showcaseRating3 = 5;

        public StartupForm()
        {
            InitializeComponent();
            UiTheme.StylePrimaryButton(startupButton);

            showProduct(product1Picture, product1Stars, "product1.png", showcaseRating1);
            showProduct(product2Picture, product2Stars, "product2.png", showcaseRating2);
            showProduct(product3Picture, product3Stars, "product3.png", showcaseRating3);

            FormClosed += startupForm_FormClosed;
        }

        public void display()
        {
            Show();
        }

        public void close()
        {
            Close();
        }

        // Startup button: initialize the system and open the next form.
        // On an error the message is shown and this page stays open.
        private void startup()
        {
            startupButton.Enabled = false;
            try
            {
                new StartupControl().initiate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The system could not be started:\n" + ex.Message,
                    "Product Rating System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startupButton.Enabled = true;
                return;
            }
            close();
        }

        private void startupButton_Click(object sender, EventArgs e)
        {
            startup();
        }

        // Puts the picture and the star text ("★★★☆☆") on one product card.
        private void showProduct(PictureBox mpicture, Label mstars, string mfileName, int mrating)
        {
            mpicture.Image = loadImage(mfileName);
            mstars.Text = new string('★', mrating) + new string('☆', 5 - mrating);
        }

        // Loads Images/<file> next to the .exe. A missing or broken file
        // gives a light-grey placeholder instead of an error.
        private Image loadImage(string mfileName)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Images", mfileName);
                using (Image original = Image.FromFile(path))
                {
                    return new Bitmap(original);
                }
            }
            catch (Exception)
            {
                Bitmap placeholder = new Bitmap(400, 400);
                using (Graphics graphics = Graphics.FromImage(placeholder))
                {
                    graphics.Clear(Color.LightGray);
                }
                return placeholder;
            }
        }

        private void startupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            product1Picture.Image?.Dispose();
            product2Picture.Image?.Dispose();
            product3Picture.Image?.Dispose();
        }
    }
}
