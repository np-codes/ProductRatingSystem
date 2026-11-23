using System.Drawing;
using System.Windows.Forms;

namespace ProductRatingSystem.Boundary
{
    public static class UiTheme
    {
        public static readonly Color WindowBackground = Color.FromArgb(245, 247, 250);
        public static readonly Color Surface = Color.White;
        public static readonly Color Text = Color.FromArgb(31, 41, 55);
        public static readonly Color MutedText = Color.FromArgb(100, 116, 139);
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);
        public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
        public static readonly Color PrimaryPressed = Color.FromArgb(30, 64, 175);
        public static readonly Font BodyFont = new Font("Segoe UI", 9.5F);

        public static void StylePrimaryButton(Button mbutton)
        {
            mbutton.BackColor = Primary;
            mbutton.ForeColor = Color.White;
            mbutton.FlatStyle = FlatStyle.Flat;
            mbutton.FlatAppearance.BorderSize = 0;
            mbutton.FlatAppearance.MouseOverBackColor = PrimaryHover;
            mbutton.FlatAppearance.MouseDownBackColor = PrimaryPressed;
            mbutton.Font = new Font(BodyFont, FontStyle.Bold);
            mbutton.Cursor = Cursors.Hand;
            mbutton.UseVisualStyleBackColor = false;
        }

        public static void StyleSecondaryButton(Button mbutton)
        {
            mbutton.BackColor = Surface;
            mbutton.ForeColor = Primary;
            mbutton.FlatStyle = FlatStyle.Flat;
            mbutton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            mbutton.FlatAppearance.BorderSize = 1;
            mbutton.FlatAppearance.MouseOverBackColor = WindowBackground;
            mbutton.Cursor = Cursors.Hand;
            mbutton.UseVisualStyleBackColor = false;
        }
    }
}
