namespace ProductRatingSystem.Boundary
{
    partial class StartupForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new System.Windows.Forms.Label();
            subtitleLabel = new System.Windows.Forms.Label();
            card1Border = new System.Windows.Forms.Panel();
            card1Body = new System.Windows.Forms.Panel();
            product1Stars = new System.Windows.Forms.Label();
            product1Picture = new System.Windows.Forms.PictureBox();
            card2Border = new System.Windows.Forms.Panel();
            card2Body = new System.Windows.Forms.Panel();
            product2Stars = new System.Windows.Forms.Label();
            product2Picture = new System.Windows.Forms.PictureBox();
            card3Border = new System.Windows.Forms.Panel();
            card3Body = new System.Windows.Forms.Panel();
            product3Stars = new System.Windows.Forms.Label();
            product3Picture = new System.Windows.Forms.PictureBox();
            startupButton = new System.Windows.Forms.Button();
            layoutTable = new System.Windows.Forms.TableLayoutPanel();
            cardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            card1Border.SuspendLayout();
            card1Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product1Picture).BeginInit();
            card2Border.SuspendLayout();
            card2Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product2Picture).BeginInit();
            card3Border.SuspendLayout();
            card3Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)product3Picture).BeginInit();
            layoutTable.SuspendLayout();
            cardsPanel.SuspendLayout();
            SuspendLayout();
            //
            // titleLabel
            //
            titleLabel.BackColor = System.Drawing.Color.White;
            titleLabel.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleLabel.ForeColor = System.Drawing.Color.Black;
            titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            titleLabel.Margin = new System.Windows.Forms.Padding(0, 55, 0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(600, 140);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "PRODUCT RATING\r\nSYSTEM";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // subtitleLabel
            //
            subtitleLabel.BackColor = System.Drawing.Color.White;
            subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            subtitleLabel.ForeColor = System.Drawing.Color.Black;
            subtitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            subtitleLabel.Margin = new System.Windows.Forms.Padding(0, 17, 0, 0);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new System.Drawing.Size(600, 85);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Discover products and\r\nview customer ratings";
            subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // card1Border
            //
            card1Border.BackColor = System.Drawing.Color.Gainsboro;
            card1Border.Controls.Add(card1Body);
            card1Border.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            card1Border.Name = "card1Border";
            card1Border.Padding = new System.Windows.Forms.Padding(1);
            card1Border.Size = new System.Drawing.Size(170, 225);
            card1Border.TabIndex = 2;
            //
            // card1Body
            //
            card1Body.BackColor = System.Drawing.Color.White;
            card1Body.Controls.Add(product1Stars);
            card1Body.Controls.Add(product1Picture);
            card1Body.Dock = System.Windows.Forms.DockStyle.Fill;
            card1Body.Location = new System.Drawing.Point(1, 1);
            card1Body.Name = "card1Body";
            card1Body.Size = new System.Drawing.Size(168, 223);
            card1Body.TabIndex = 0;
            //
            // product1Stars
            //
            product1Stars.BackColor = System.Drawing.Color.White;
            product1Stars.Dock = System.Windows.Forms.DockStyle.Fill;
            product1Stars.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            product1Stars.ForeColor = System.Drawing.Color.Black;
            product1Stars.Location = new System.Drawing.Point(0, 168);
            product1Stars.Name = "product1Stars";
            product1Stars.Size = new System.Drawing.Size(168, 55);
            product1Stars.TabIndex = 1;
            product1Stars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // product1Picture
            //
            product1Picture.BackColor = System.Drawing.Color.White;
            product1Picture.Dock = System.Windows.Forms.DockStyle.Top;
            product1Picture.Location = new System.Drawing.Point(0, 0);
            product1Picture.Name = "product1Picture";
            product1Picture.Size = new System.Drawing.Size(168, 168);
            product1Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            product1Picture.TabIndex = 0;
            product1Picture.TabStop = false;
            //
            // card2Border
            //
            card2Border.BackColor = System.Drawing.Color.Gainsboro;
            card2Border.Controls.Add(card2Body);
            card2Border.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            card2Border.Name = "card2Border";
            card2Border.Padding = new System.Windows.Forms.Padding(1);
            card2Border.Size = new System.Drawing.Size(170, 225);
            card2Border.TabIndex = 3;
            //
            // card2Body
            //
            card2Body.BackColor = System.Drawing.Color.White;
            card2Body.Controls.Add(product2Stars);
            card2Body.Controls.Add(product2Picture);
            card2Body.Dock = System.Windows.Forms.DockStyle.Fill;
            card2Body.Location = new System.Drawing.Point(1, 1);
            card2Body.Name = "card2Body";
            card2Body.Size = new System.Drawing.Size(168, 223);
            card2Body.TabIndex = 0;
            //
            // product2Stars
            //
            product2Stars.BackColor = System.Drawing.Color.White;
            product2Stars.Dock = System.Windows.Forms.DockStyle.Fill;
            product2Stars.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            product2Stars.ForeColor = System.Drawing.Color.Black;
            product2Stars.Location = new System.Drawing.Point(0, 168);
            product2Stars.Name = "product2Stars";
            product2Stars.Size = new System.Drawing.Size(168, 55);
            product2Stars.TabIndex = 1;
            product2Stars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // product2Picture
            //
            product2Picture.BackColor = System.Drawing.Color.White;
            product2Picture.Dock = System.Windows.Forms.DockStyle.Top;
            product2Picture.Location = new System.Drawing.Point(0, 0);
            product2Picture.Name = "product2Picture";
            product2Picture.Size = new System.Drawing.Size(168, 168);
            product2Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            product2Picture.TabIndex = 0;
            product2Picture.TabStop = false;
            //
            // card3Border
            //
            card3Border.BackColor = System.Drawing.Color.Gainsboro;
            card3Border.Controls.Add(card3Body);
            card3Border.Margin = new System.Windows.Forms.Padding(0);
            card3Border.Name = "card3Border";
            card3Border.Padding = new System.Windows.Forms.Padding(1);
            card3Border.Size = new System.Drawing.Size(170, 225);
            card3Border.TabIndex = 4;
            //
            // card3Body
            //
            card3Body.BackColor = System.Drawing.Color.White;
            card3Body.Controls.Add(product3Stars);
            card3Body.Controls.Add(product3Picture);
            card3Body.Dock = System.Windows.Forms.DockStyle.Fill;
            card3Body.Location = new System.Drawing.Point(1, 1);
            card3Body.Name = "card3Body";
            card3Body.Size = new System.Drawing.Size(168, 223);
            card3Body.TabIndex = 0;
            //
            // product3Stars
            //
            product3Stars.BackColor = System.Drawing.Color.White;
            product3Stars.Dock = System.Windows.Forms.DockStyle.Fill;
            product3Stars.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            product3Stars.ForeColor = System.Drawing.Color.Black;
            product3Stars.Location = new System.Drawing.Point(0, 168);
            product3Stars.Name = "product3Stars";
            product3Stars.Size = new System.Drawing.Size(168, 55);
            product3Stars.TabIndex = 1;
            product3Stars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // product3Picture
            //
            product3Picture.BackColor = System.Drawing.Color.White;
            product3Picture.Dock = System.Windows.Forms.DockStyle.Top;
            product3Picture.Location = new System.Drawing.Point(0, 0);
            product3Picture.Name = "product3Picture";
            product3Picture.Size = new System.Drawing.Size(168, 168);
            product3Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            product3Picture.TabIndex = 0;
            product3Picture.TabStop = false;
            //
            // startupButton
            //
            startupButton.BackColor = System.Drawing.Color.White;
            startupButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            startupButton.ForeColor = System.Drawing.Color.Black;
            startupButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            startupButton.AutoSize = true;
            startupButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            startupButton.Margin = new System.Windows.Forms.Padding(0, 65, 0, 0);
            startupButton.MinimumSize = new System.Drawing.Size(160, 50);
            startupButton.Name = "startupButton";
            startupButton.TabIndex = 5;
            startupButton.Text = "Startup";
            startupButton.UseVisualStyleBackColor = false;
            startupButton.Click += startupButton_Click;
            //
            // cardsPanel (the three showcase cards side by side)
            //
            cardsPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            cardsPanel.AutoSize = true;
            cardsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cardsPanel.Controls.Add(card1Border);
            cardsPanel.Controls.Add(card2Border);
            cardsPanel.Controls.Add(card3Border);
            cardsPanel.Margin = new System.Windows.Forms.Padding(0, 33, 0, 0);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.WrapContents = false;
            //
            // layoutTable (stacks title, subtitle, cards and button; rows grow with their content)
            //
            layoutTable.AutoSize = true;
            layoutTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            layoutTable.ColumnCount = 1;
            layoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutTable.Controls.Add(titleLabel, 0, 0);
            layoutTable.Controls.Add(subtitleLabel, 0, 1);
            layoutTable.Controls.Add(cardsPanel, 0, 2);
            layoutTable.Controls.Add(startupButton, 0, 3);
            layoutTable.Dock = System.Windows.Forms.DockStyle.Top;
            layoutTable.Name = "layoutTable";
            layoutTable.RowCount = 4;
            layoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layoutTable.TabIndex = 0;
            //
            // StartupForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(600, 780);
            Controls.Add(layoutTable);
            ForeColor = System.Drawing.Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StartupForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Product Rating System";
            card1Border.ResumeLayout(false);
            card1Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product1Picture).EndInit();
            card2Border.ResumeLayout(false);
            card2Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product2Picture).EndInit();
            card3Border.ResumeLayout(false);
            card3Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)product3Picture).EndInit();
            cardsPanel.ResumeLayout(false);
            layoutTable.ResumeLayout(false);
            layoutTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutTable;
        private System.Windows.Forms.FlowLayoutPanel cardsPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel card1Border;
        private System.Windows.Forms.Panel card1Body;
        private System.Windows.Forms.Label product1Stars;
        private System.Windows.Forms.PictureBox product1Picture;
        private System.Windows.Forms.Panel card2Border;
        private System.Windows.Forms.Panel card2Body;
        private System.Windows.Forms.Label product2Stars;
        private System.Windows.Forms.PictureBox product2Picture;
        private System.Windows.Forms.Panel card3Border;
        private System.Windows.Forms.Panel card3Body;
        private System.Windows.Forms.Label product3Stars;
        private System.Windows.Forms.PictureBox product3Picture;
        private System.Windows.Forms.Button startupButton;
    }
}
