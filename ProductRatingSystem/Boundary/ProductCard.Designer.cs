namespace ProductRatingSystem.Boundary
{
    partial class ProductCard
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

        #region Component Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new System.Windows.Forms.PictureBox();
            titleLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            ratingPanel = new System.Windows.Forms.Panel();
            ratingLabel = new System.Windows.Forms.Label();
            starsLabel = new System.Windows.Forms.Label();
            rateButton = new System.Windows.Forms.Button();
            reviewsButton = new System.Windows.Forms.Button();
            reviewsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ratingPanel.SuspendLayout();
            SuspendLayout();
            //
            // pictureBox
            //
            pictureBox.BackColor = System.Drawing.Color.White;
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox.Location = new System.Drawing.Point(10, 10);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(120, 120);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            //
            // titleLabel
            //
            titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            titleLabel.AutoEllipsis = true;
            titleLabel.BackColor = System.Drawing.Color.White;
            titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleLabel.ForeColor = System.Drawing.Color.Black;
            titleLabel.Location = new System.Drawing.Point(140, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(390, 30);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Product Title";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // descriptionLabel
            //
            descriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            descriptionLabel.AutoEllipsis = true;
            descriptionLabel.BackColor = System.Drawing.Color.White;
            descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionLabel.ForeColor = System.Drawing.Color.Black;
            descriptionLabel.Location = new System.Drawing.Point(140, 44);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Padding = new System.Windows.Forms.Padding(4);
            descriptionLabel.Size = new System.Drawing.Size(390, 54);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Product Description";
            //
            // priceLabel
            //
            priceLabel.BackColor = System.Drawing.Color.White;
            priceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            priceLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceLabel.ForeColor = System.Drawing.Color.Black;
            priceLabel.Location = new System.Drawing.Point(140, 102);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(110, 28);
            priceLabel.TabIndex = 3;
            priceLabel.Text = "$0.00";
            priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ratingPanel
            //
            ratingPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ratingPanel.BackColor = System.Drawing.Color.White;
            ratingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ratingPanel.Controls.Add(ratingLabel);
            ratingPanel.Controls.Add(starsLabel);
            ratingPanel.Location = new System.Drawing.Point(260, 102);
            ratingPanel.Name = "ratingPanel";
            ratingPanel.Size = new System.Drawing.Size(270, 28);
            ratingPanel.TabIndex = 4;
            //
            // ratingLabel (text, left side with space on the left)
            //
            ratingLabel.BackColor = System.Drawing.Color.White;
            ratingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            ratingLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ratingLabel.ForeColor = System.Drawing.Color.Black;
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            ratingLabel.TabIndex = 0;
            ratingLabel.Text = "Overall Rating: 0.0";
            ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // starsLabel (stars, right side with space on the right)
            //
            starsLabel.BackColor = System.Drawing.Color.White;
            starsLabel.Dock = System.Windows.Forms.DockStyle.Right;
            starsLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            starsLabel.ForeColor = System.Drawing.Color.Black;
            starsLabel.Name = "starsLabel";
            starsLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            starsLabel.Size = new System.Drawing.Size(110, 26);
            starsLabel.TabIndex = 1;
            starsLabel.Text = "☆☆☆☆☆";
            starsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // rateButton
            //
            rateButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rateButton.BackColor = System.Drawing.Color.White;
            rateButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            rateButton.ForeColor = System.Drawing.Color.Black;
            rateButton.Location = new System.Drawing.Point(380, 102);
            rateButton.Name = "rateButton";
            rateButton.Size = new System.Drawing.Size(150, 30);
            rateButton.TabIndex = 5;
            rateButton.Text = "Rate Product";
            rateButton.UseVisualStyleBackColor = false;
            rateButton.Visible = false;
            rateButton.Click += rateButton_Click;
            //
            // reviewsButton
            //
            reviewsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            reviewsButton.BackColor = System.Drawing.Color.White;
            reviewsButton.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewsButton.ForeColor = System.Drawing.Color.Black;
            reviewsButton.Location = new System.Drawing.Point(10, 140);
            reviewsButton.Name = "reviewsButton";
            reviewsButton.Size = new System.Drawing.Size(520, 30);
            reviewsButton.TabIndex = 6;
            reviewsButton.Text = "Reviews (0)   ▼";
            reviewsButton.UseVisualStyleBackColor = false;
            reviewsButton.Click += reviewsButton_Click;
            //
            // reviewsPanel
            //
            reviewsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            reviewsPanel.AutoScroll = true;
            reviewsPanel.BackColor = System.Drawing.Color.White;
            reviewsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            reviewsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            reviewsPanel.Location = new System.Drawing.Point(10, 170);
            reviewsPanel.Name = "reviewsPanel";
            reviewsPanel.Padding = new System.Windows.Forms.Padding(4);
            reviewsPanel.Size = new System.Drawing.Size(520, 80);
            reviewsPanel.TabIndex = 7;
            reviewsPanel.Visible = false;
            reviewsPanel.WrapContents = false;
            //
            // ProductCard
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.White;
            Controls.Add(reviewsPanel);
            Controls.Add(reviewsButton);
            Controls.Add(rateButton);
            Controls.Add(ratingPanel);
            Controls.Add(priceLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(titleLabel);
            Controls.Add(pictureBox);
            ForeColor = System.Drawing.Color.Black;
            Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            Name = "ProductCard";
            Size = new System.Drawing.Size(540, 182);
            Disposed += productCard_Disposed;
            Resize += productCard_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ratingPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Panel ratingPanel;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.Label starsLabel;
        private System.Windows.Forms.Button rateButton;
        private System.Windows.Forms.Button reviewsButton;
        private System.Windows.Forms.FlowLayoutPanel reviewsPanel;
    }
}
