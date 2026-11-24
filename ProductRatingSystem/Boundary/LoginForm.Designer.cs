namespace ProductRatingSystem.Boundary
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel layoutTable;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel userIconPanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label errorLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // All sizes and margins below are 96-DPI (100%) values. The labels and the
        // button size themselves to their text (AutoSize) and the rows of the table
        // grow with them, so nothing overlaps or is cut off at any display scale.
        private void InitializeComponent()
        {
            layoutTable = new System.Windows.Forms.TableLayoutPanel();
            titleLabel = new System.Windows.Forms.Label();
            userIconPanel = new System.Windows.Forms.Panel();
            usernameLabel = new System.Windows.Forms.Label();
            usernameTextBox = new System.Windows.Forms.TextBox();
            passwordLabel = new System.Windows.Forms.Label();
            passwordTextBox = new System.Windows.Forms.TextBox();
            loginButton = new System.Windows.Forms.Button();
            errorLabel = new System.Windows.Forms.Label();
            layoutTable.SuspendLayout();
            SuspendLayout();

            layoutTable.AutoSize = true;
            layoutTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            layoutTable.ColumnCount = 3;
            layoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            layoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layoutTable.Controls.Add(titleLabel, 0, 0);
            layoutTable.Controls.Add(userIconPanel, 0, 1);
            layoutTable.Controls.Add(usernameLabel, 1, 2);
            layoutTable.Controls.Add(usernameTextBox, 1, 3);
            layoutTable.Controls.Add(passwordLabel, 1, 4);
            layoutTable.Controls.Add(passwordTextBox, 1, 5);
            layoutTable.Controls.Add(errorLabel, 1, 6);
            layoutTable.Controls.Add(loginButton, 1, 7);
            layoutTable.Dock = System.Windows.Forms.DockStyle.Top;
            layoutTable.Name = "layoutTable";
            layoutTable.RowCount = 8;
            for (int row = 0; row < 8; row++)
            {
                layoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            }
            layoutTable.TabIndex = 0;

            titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            titleLabel.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.Black;
            titleLabel.Margin = new System.Windows.Forms.Padding(0, 70, 0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(600, 140);
            titleLabel.Text = "PRODUCT RATING\r\nSYSTEM";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            layoutTable.SetColumnSpan(titleLabel, 3);

            userIconPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            userIconPanel.Margin = new System.Windows.Forms.Padding(0, 45, 0, 0);
            userIconPanel.Name = "userIconPanel";
            userIconPanel.Size = new System.Drawing.Size(96, 96);
            userIconPanel.Paint += userIconPanel_Paint;
            layoutTable.SetColumnSpan(userIconPanel, 3);

            usernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            usernameLabel.AutoSize = true;
            usernameLabel.Margin = new System.Windows.Forms.Padding(0, 49, 0, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Text = "Username";

            usernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            usernameTextBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.TabIndex = 0;

            passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            passwordLabel.AutoSize = true;
            passwordLabel.Margin = new System.Windows.Forms.Padding(0, 18, 0, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Text = "Password";

            passwordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            passwordTextBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.KeyDown += passwordTextBox_KeyDown;

            errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            errorLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            errorLabel.MaximumSize = new System.Drawing.Size(300, 0);
            errorLabel.MinimumSize = new System.Drawing.Size(0, 40);
            errorLabel.Name = "errorLabel";
            errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            loginButton.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loginButton.AutoSize = true;
            loginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            loginButton.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            loginButton.MinimumSize = new System.Drawing.Size(0, 38);
            loginButton.Name = "loginButton";
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.Click += loginButton_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(600, 780);
            Controls.Add(layoutTable);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Login";
            layoutTable.ResumeLayout(false);
            layoutTable.PerformLayout();
            ResumeLayout(false);
        }
    }
}
