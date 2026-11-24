namespace ProductRatingSystem.Boundary
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
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

        private void InitializeComponent()
        {
            titleLabel = new System.Windows.Forms.Label();
            userIconPanel = new System.Windows.Forms.Panel();
            usernameLabel = new System.Windows.Forms.Label();
            usernameTextBox = new System.Windows.Forms.TextBox();
            passwordLabel = new System.Windows.Forms.Label();
            passwordTextBox = new System.Windows.Forms.TextBox();
            loginButton = new System.Windows.Forms.Button();
            errorLabel = new System.Windows.Forms.Label();
            SuspendLayout();

            titleLabel.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Bold);
            titleLabel.Text = "PRODUCT RATING\r\nSYSTEM";
            titleLabel.ForeColor = System.Drawing.Color.Black;
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            titleLabel.Location = new System.Drawing.Point(0, 70);
            titleLabel.Size = new System.Drawing.Size(600, 140);

            userIconPanel.Location = new System.Drawing.Point(252, 255);
            userIconPanel.Size = new System.Drawing.Size(96, 96);
            userIconPanel.Paint += userIconPanel_Paint;

            usernameLabel.Text = "Username";
            usernameLabel.Location = new System.Drawing.Point(150, 400);
            usernameLabel.Size = new System.Drawing.Size(300, 20);

            usernameTextBox.Location = new System.Drawing.Point(150, 423);
            usernameTextBox.Size = new System.Drawing.Size(300, 27);
            usernameTextBox.TabIndex = 0;

            passwordLabel.Text = "Password";
            passwordLabel.Location = new System.Drawing.Point(150, 465);
            passwordLabel.Size = new System.Drawing.Size(300, 20);

            passwordTextBox.Location = new System.Drawing.Point(150, 488);
            passwordTextBox.Size = new System.Drawing.Size(300, 27);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.KeyDown += passwordTextBox_KeyDown;

            errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            errorLabel.Location = new System.Drawing.Point(150, 529);
            errorLabel.Size = new System.Drawing.Size(300, 40);
            errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            loginButton.Text = "Login";
            loginButton.Location = new System.Drawing.Point(150, 575);
            loginButton.Size = new System.Drawing.Size(300, 38);
            loginButton.TabIndex = 2;
            loginButton.Click += loginButton_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(600, 780);
            Controls.Add(titleLabel);
            Controls.Add(userIconPanel);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(errorLabel);
            Controls.Add(loginButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
