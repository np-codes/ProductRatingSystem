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
        public static readonly Font HeadingFont = new Font("Segoe UI Semibold", 16F);
        public static readonly Font UsernameFont = new Font("Segoe UI Semibold", 15F);
        public static readonly Font CountFont = new Font("Segoe UI", 11F);
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 10F);
        public static readonly Color Divider = Color.FromArgb(226, 232, 240);

        // Light grey used for the top bar of every page (menu header, Add Product and
        // Rate Product headings) and the thin line under the menu header.
        public static readonly Color HeaderBackground = Color.Gainsboro;
        // Dark border for every button, so buttons stay visible on grey backgrounds.
        public static readonly Color ButtonBorder = Color.FromArgb(55, 65, 81);
        public static readonly Color HeaderDivider = Color.FromArgb(203, 213, 225);

        // Client size shared by every form, so the window never changes size
        // when one form replaces another (applied in ApplicationForm).
        public static readonly Size FormClientSize = new Size(600, 780);

        // Every button looks the same: a white rectangle with a thin grey border
        // and blue text (like the Logout button). StylePrimaryButton is kept so
        // existing calls still compile; it gives the same look.
        public static void StylePrimaryButton(Button mbutton)
        {
            StyleSecondaryButton(mbutton);
        }

        public static void StyleSecondaryButton(Button mbutton)
        {
            mbutton.BackColor = Surface;
            mbutton.ForeColor = Primary;
            mbutton.FlatStyle = FlatStyle.Flat;
            mbutton.FlatAppearance.BorderColor = ButtonBorder;
            mbutton.FlatAppearance.BorderSize = 1;
            mbutton.FlatAppearance.MouseOverBackColor = WindowBackground;
            mbutton.FlatAppearance.MouseDownBackColor = Divider;
            // A button that uses the symbol font (the arrow on "Reviews") keeps it.
            if (mbutton.Font.FontFamily.Name != "Segoe UI Symbol")
            {
                mbutton.Font = ButtonFont;
            }
            mbutton.Cursor = Cursors.Hand;
            mbutton.UseVisualStyleBackColor = false;

            // Windows draws a focused (or just clicked) flat button with a thicker
            // border. Repaint the border at its normal width so every button looks the same.
            mbutton.Paint -= keepNormalBorder;
            mbutton.Paint += keepNormalBorder;
        }

        private static void keepNormalBorder(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            if (!button.Enabled)
            {
                return;
            }

            // Colour of the thick border's second line = what the button shows inside.
            Color inside = button.BackColor;
            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)))
            {
                inside = Button.MouseButtons == MouseButtons.Left
                    ? button.FlatAppearance.MouseDownBackColor
                    : button.FlatAppearance.MouseOverBackColor;
            }

            using (Pen insidePen = new Pen(inside))
            using (Pen borderPen = new Pen(ButtonBorder))
            {
                e.Graphics.DrawRectangle(insidePen, 1, 1, button.Width - 3, button.Height - 3);
                e.Graphics.DrawRectangle(borderPen, 0, 0, button.Width - 1, button.Height - 1);
            }
        }
    }
}
