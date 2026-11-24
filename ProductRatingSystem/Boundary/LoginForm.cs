using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;

namespace ProductRatingSystem.Boundary
{
    // Subsystem: Boundary
    // The Login Page (RAD Figure 4.2.1). It only collects the username and password
    // and shows messages; LoginControl does everything else, including opening the
    // main menu.
    public partial class LoginForm : ApplicationForm
    {
        private string username;
        private string password;

        // Extra helper field (not in the class diagram).
        private LoginControl loginControl;

        public LoginForm()
        {
            InitializeComponent();
            StylePrimaryButton(loginButton);
            username = "";
            password = "";
            loginControl = new LoginControl(this);
            usernameTextBox.MaxLength = LoginControl.maxUsernameLength;
            passwordTextBox.MaxLength = LoginControl.maxPasswordLength;
            AcceptButton = loginButton;
            ActiveControl = usernameTextBox;
        }

        // Draws the user symbol: a large dot (head) above a half circle (shoulders).
        private void userIconPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int width = userIconPanel.ClientSize.Width;
            int height = userIconPanel.ClientSize.Height;
            int headSize = (int)(height * 0.46);
            int bodyWidth = (int)(width * 0.86);
            int bodyTop = (int)(height * 0.54);

            using (SolidBrush brush = new SolidBrush(TextColor))
            {
                e.Graphics.FillEllipse(brush, (width - headSize) / 2, 0, headSize, headSize);
                e.Graphics.FillPie(brush, (width - bodyWidth) / 2, bodyTop,
                    bodyWidth, (height - bodyTop) * 2, 180, 180);
            }
        }

        // Shows the page with a message under the password box (RAD Figure 2.5.4:
        // display(logoutMessage)). An empty message shows no text. display() and
        // close() are inherited from ApplicationForm.
        public void display(string mmessage)
        {
            errorLabel.Text = mmessage ?? "";
            Show();
        }

        // The Login button: reads the two textboxes and submits them.
        public void login()
        {
            errorLabel.Text = "";
            username = usernameTextBox.Text;
            password = passwordTextBox.Text;
            loginButton.Enabled = false;
            try
            {
                submit(username, password);
            }
            finally
            {
                password = "";
                if (!IsDisposed)
                {
                    loginButton.Enabled = true;
                }
            }
        }

        // Hands the entered values to the control (RAD Figure 2.5.2).
        public void submit(string musername, string mpassword)
        {
            loginControl.submit(musername, mpassword);
        }

        // Shows an error message that names the field, or the generic
        // "Invalid username or password." message.
        public void displayError(string mmessage)
        {
            errorLabel.Text = mmessage ?? "";
            if (errorLabel.Text.StartsWith("Please enter a username", StringComparison.Ordinal)
                || errorLabel.Text.StartsWith("Username", StringComparison.Ordinal))
            {
                usernameTextBox.Focus();
                usernameTextBox.SelectAll();
            }
            else
            {
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            login();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                login();
            }
        }
    }
}
