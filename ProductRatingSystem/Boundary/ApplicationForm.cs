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

        // At a high display scale 600 x 780 (design size) can be taller than the screen.
        // Keep the whole window on screen; the content then scrolls instead of being cut off.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Rectangle area = Screen.FromControl(this).WorkingArea;
            if (Height > area.Height)
            {
                Height = area.Height;
                Top = area.Top;
            }
            if (Width > area.Width)
            {
                Width = area.Width;
                Left = area.Left;
            }
        }
    }
}
