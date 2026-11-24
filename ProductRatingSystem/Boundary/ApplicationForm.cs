using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProductRatingSystem.Boundary
{
    public abstract class ApplicationForm : Form
    {
        protected ApplicationForm()
        {
            Font = UiTheme.BodyFont;
            BackColor = UiTheme.WindowBackground;
            ForeColor = UiTheme.Text;

            // Same window for every form: 600 x 780 client area, fixed border,
            // centered on screen. 96 DPI is the design size, so Windows display
            // scaling enlarges every form by the same amount.
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = UiTheme.FormClientSize;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            fitToScreen();
            base.OnLoad(e);
        }

        // With Windows display scaling (125%, 150%, ...) every form is enlarged, and
        // the 600 x 780 page can become taller (or wider) than the screen, which hides
        // the bottom of the page. Then the window is shrunk to fit the screen, gets
        // scroll bars so the whole page can still be reached, and stays centered.
        // At 100% scaling, or when the window already fits, nothing changes.
        private void fitToScreen()
        {
            Rectangle screen = Screen.FromControl(this).WorkingArea;
            if (Width <= screen.Width && Height <= screen.Height)
            {
                return;
            }

            AutoScroll = true;
            int height = Math.Min(Height, screen.Height);
            int width = Width;
            if (height < Height)
            {
                // room for the vertical scroll bar, so no sideways scrolling is needed
                width += SystemInformation.VerticalScrollBarWidth + 4;
            }
            width = Math.Min(width, screen.Width);

            Size = new Size(width, height);
            Location = new Point(screen.Left + (screen.Width - width) / 2,
                screen.Top + (screen.Height - height) / 2);
        }
    }
}
