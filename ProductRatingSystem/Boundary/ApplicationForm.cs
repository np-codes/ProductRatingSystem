using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // Base class of every form (the "Form" class of RAD Figure 4.2.1; it cannot be
    // named Form because System.Windows.Forms.Form already exists). It also holds
    // the colours, fonts and button style shared by all pages: black text on a white
    // background (RAD 2.2).
    public abstract class ApplicationForm : Form
    {
        // ---- look shared by all pages ----

        public static readonly Color WindowBackground = Color.White;
        public static readonly Color Surface = Color.White;
        public static readonly Color HeaderBackground = Color.White;
        public static readonly Color TextColor = Color.Black;
        public static readonly Color MutedTextColor = Color.Black;
        public static readonly Color ButtonTextColor = Color.Black;
        // Dark border for every button.
        public static readonly Color ButtonBorder = Color.FromArgb(55, 65, 81);
        public static readonly Color ButtonHoverBackground = Color.FromArgb(235, 235, 235);
        public static readonly Color ButtonPressedBackground = Color.FromArgb(215, 215, 215);

        public static readonly Font BodyFont = new Font("Segoe UI", 9.5F);
        public static readonly Font HeadingFont = new Font("Segoe UI Semibold", 16F);
        public static readonly Font UsernameFont = new Font("Segoe UI Semibold", 15F);
        public static readonly Font CountFont = new Font("Segoe UI", 11F);
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 10F);

        // Client size shared by every form, so the window never changes size
        // when one form replaces another.
        public static readonly Size FormClientSize = new Size(600, 780);

        protected ApplicationForm()
        {
            Font = BodyFont;
            BackColor = WindowBackground;
            ForeColor = TextColor;

            // Same window for every form: 600 x 780 client area, fixed border,
            // centered on screen. 96 DPI is the design size, so Windows display
            // scaling enlarges every form by the same amount.
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = FormClientSize;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Shows the form (RAD Figure 4.2.1: +display():void).
        public virtual void display()
        {
            Show();
        }

        // Closes the form (RAD Figure 4.2.1: +close():void).
        public virtual void close()
        {
            Close();
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

        // ---- button style ----

        // Every button looks the same: a white rectangle with a thin dark border and
        // black text. StylePrimaryButton is kept so existing calls still compile;
        // it gives the same look.
        public static void StylePrimaryButton(Button mbutton)
        {
            StyleSecondaryButton(mbutton);
        }

        public static void StyleSecondaryButton(Button mbutton)
        {
            mbutton.BackColor = Surface;
            mbutton.ForeColor = ButtonTextColor;
            mbutton.FlatStyle = FlatStyle.Flat;
            mbutton.FlatAppearance.BorderColor = ButtonBorder;
            mbutton.FlatAppearance.BorderSize = 1;
            mbutton.FlatAppearance.MouseOverBackColor = ButtonHoverBackground;
            mbutton.FlatAppearance.MouseDownBackColor = ButtonPressedBackground;
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
