using System;
using System.Drawing;
using System.Windows.Forms;
using ProductRatingSystem.Control;
using ProductRatingSystem.Entity;

namespace ProductRatingSystem.Boundary
{
    public partial class LoginForm : ApplicationForm
    {
        private LoginControl loginControl;

        public LoginForm()
        {
            InitializeComponent();
            UiTheme.StylePrimaryButton(loginButton);
            loginControl = new LoginControl(this);
            AcceptButton = loginButton;
            ActiveControl = usernameTextBox;
        }

        public void display()
        {
            Show();
        }

        public void close()
        {
            Close();
        }

        public void login()
        {
            errorLabel.Text = "";
            loginButton.Enabled = false;
            try
            {
                loginControl.login(usernameTextBox.Text, passwordTextBox.Text);
            }
            finally
            {
                if (!IsDisposed)
                {
                    loginButton.Enabled = true;
                }
            }
        }

        public void displayError(string mmessage)
        {
            errorLabel.Text = mmessage ?? "";
            if (string.Equals(errorLabel.Text, "Please enter a username.", StringComparison.Ordinal))
            {
                usernameTextBox.Focus();
                usernameTextBox.SelectAll();
            }
            else if (string.Equals(errorLabel.Text, "Please enter a password.", StringComparison.Ordinal))
            {
                passwordTextBox.Focus();
                passwordTextBox.SelectAll();
            }
            else
            {
                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
            }
        }

        public void openMenu(UserAccount maccount)
        {
            if (maccount == null)
            {
                return;
            }

            DBConnectorControl db = new DBConnectorControl();
            ProductList products = db.getProducts(maccount.getUserID());

            if (maccount.getRole() == "Seller")
            {
                SellerMenu menu = new SellerMenu();
                menu.userID = maccount.getUserID();
                menu.username = maccount.getUsername();
                menu.display(products, maccount.getUsername());
            }
            else
            {
                CustomerMenu menu = new CustomerMenu();
                menu.userID = maccount.getUserID();
                menu.display(products);
            }

            close();
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
