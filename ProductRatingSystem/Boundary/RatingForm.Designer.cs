namespace ProductRatingSystem.Boundary
{
    partial class RatingForm
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
            headerLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            productPicture = new System.Windows.Forms.PictureBox();
            descriptionTextBox = new System.Windows.Forms.TextBox();
            priceLabel = new System.Windows.Forms.Label();
            ratingCaptionLabel = new System.Windows.Forms.Label();
            star1Button = new System.Windows.Forms.Button();
            star2Button = new System.Windows.Forms.Button();
            star3Button = new System.Windows.Forms.Button();
            star4Button = new System.Windows.Forms.Button();
            star5Button = new System.Windows.Forms.Button();
            ratingValueLabel = new System.Windows.Forms.Label();
            reviewCaptionLabel = new System.Windows.Forms.Label();
            reviewTextBox = new System.Windows.Forms.TextBox();
            reviewCountLabel = new System.Windows.Forms.Label();
            submitButton = new System.Windows.Forms.Button();
            contentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)productPicture).BeginInit();
            contentPanel.SuspendLayout();
            SuspendLayout();
            //
            // headerLabel
            //
            headerLabel.BackColor = System.Drawing.Color.White;
            headerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            headerLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            headerLabel.ForeColor = System.Drawing.Color.Black;
            headerLabel.Location = new System.Drawing.Point(20, 16);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new System.Drawing.Size(560, 54);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Rate The Product";
            headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // titleLabel
            //
            titleLabel.AutoEllipsis = true;
            titleLabel.BackColor = System.Drawing.Color.White;
            titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleLabel.ForeColor = System.Drawing.Color.Black;
            titleLabel.Location = new System.Drawing.Point(60, 84);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(480, 36);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Product Title";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // productPicture
            //
            productPicture.BackColor = System.Drawing.Color.White;
            productPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            productPicture.Location = new System.Drawing.Point(220, 128);
            productPicture.Name = "productPicture";
            productPicture.Size = new System.Drawing.Size(160, 160);
            productPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            productPicture.TabIndex = 2;
            productPicture.TabStop = false;
            //
            // descriptionTextBox
            //
            descriptionTextBox.BackColor = System.Drawing.Color.White;
            descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            descriptionTextBox.Location = new System.Drawing.Point(60, 296);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ReadOnly = true;
            descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            descriptionTextBox.Size = new System.Drawing.Size(480, 110);
            descriptionTextBox.TabIndex = 3;
            descriptionTextBox.TabStop = false;
            //
            // priceLabel
            //
            priceLabel.BackColor = System.Drawing.Color.White;
            priceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            priceLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceLabel.ForeColor = System.Drawing.Color.Black;
            priceLabel.Location = new System.Drawing.Point(200, 414);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(200, 32);
            priceLabel.TabIndex = 4;
            priceLabel.Text = "$0.00";
            priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ratingCaptionLabel
            //
            ratingCaptionLabel.BackColor = System.Drawing.Color.White;
            ratingCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ratingCaptionLabel.ForeColor = System.Drawing.Color.Black;
            ratingCaptionLabel.Location = new System.Drawing.Point(100, 456);
            ratingCaptionLabel.Name = "ratingCaptionLabel";
            ratingCaptionLabel.Size = new System.Drawing.Size(90, 32);
            ratingCaptionLabel.TabIndex = 5;
            ratingCaptionLabel.Text = "Rating:";
            ratingCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // star1Button
            //
            star1Button.BackColor = System.Drawing.Color.White;
            star1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star1Button.FlatAppearance.BorderSize = 0;
            star1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star1Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star1Button.ForeColor = System.Drawing.Color.Black;
            star1Button.Location = new System.Drawing.Point(196, 450);
            star1Button.Name = "star1Button";
            star1Button.Size = new System.Drawing.Size(42, 44);
            star1Button.TabIndex = 6;
            star1Button.Text = "☆";
            star1Button.UseVisualStyleBackColor = false;
            star1Button.Click += starButton_Click;
            star1Button.KeyPress += starButton_KeyPress;
            //
            // star2Button
            //
            star2Button.BackColor = System.Drawing.Color.White;
            star2Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star2Button.FlatAppearance.BorderSize = 0;
            star2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star2Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star2Button.ForeColor = System.Drawing.Color.Black;
            star2Button.Location = new System.Drawing.Point(240, 450);
            star2Button.Name = "star2Button";
            star2Button.Size = new System.Drawing.Size(42, 44);
            star2Button.TabIndex = 7;
            star2Button.Text = "☆";
            star2Button.UseVisualStyleBackColor = false;
            star2Button.Click += starButton_Click;
            star2Button.KeyPress += starButton_KeyPress;
            //
            // star3Button
            //
            star3Button.BackColor = System.Drawing.Color.White;
            star3Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star3Button.FlatAppearance.BorderSize = 0;
            star3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star3Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star3Button.ForeColor = System.Drawing.Color.Black;
            star3Button.Location = new System.Drawing.Point(284, 450);
            star3Button.Name = "star3Button";
            star3Button.Size = new System.Drawing.Size(42, 44);
            star3Button.TabIndex = 8;
            star3Button.Text = "☆";
            star3Button.UseVisualStyleBackColor = false;
            star3Button.Click += starButton_Click;
            star3Button.KeyPress += starButton_KeyPress;
            //
            // star4Button
            //
            star4Button.BackColor = System.Drawing.Color.White;
            star4Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star4Button.FlatAppearance.BorderSize = 0;
            star4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star4Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star4Button.ForeColor = System.Drawing.Color.Black;
            star4Button.Location = new System.Drawing.Point(328, 450);
            star4Button.Name = "star4Button";
            star4Button.Size = new System.Drawing.Size(42, 44);
            star4Button.TabIndex = 9;
            star4Button.Text = "☆";
            star4Button.UseVisualStyleBackColor = false;
            star4Button.Click += starButton_Click;
            star4Button.KeyPress += starButton_KeyPress;
            //
            // star5Button
            //
            star5Button.BackColor = System.Drawing.Color.White;
            star5Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star5Button.FlatAppearance.BorderSize = 0;
            star5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star5Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star5Button.ForeColor = System.Drawing.Color.Black;
            star5Button.Location = new System.Drawing.Point(372, 450);
            star5Button.Name = "star5Button";
            star5Button.Size = new System.Drawing.Size(42, 44);
            star5Button.TabIndex = 10;
            star5Button.Text = "☆";
            star5Button.UseVisualStyleBackColor = false;
            star5Button.Click += starButton_Click;
            star5Button.KeyPress += starButton_KeyPress;
            //
            // ratingValueLabel
            //
            ratingValueLabel.BackColor = System.Drawing.Color.White;
            ratingValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ratingValueLabel.ForeColor = System.Drawing.Color.Black;
            ratingValueLabel.Location = new System.Drawing.Point(418, 462);
            ratingValueLabel.Name = "ratingValueLabel";
            ratingValueLabel.Size = new System.Drawing.Size(120, 22);
            ratingValueLabel.TabIndex = 11;
            ratingValueLabel.Text = "(not selected)";
            ratingValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // reviewCaptionLabel
            //
            reviewCaptionLabel.AutoSize = true;
            reviewCaptionLabel.BackColor = System.Drawing.Color.White;
            reviewCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewCaptionLabel.ForeColor = System.Drawing.Color.Black;
            reviewCaptionLabel.Location = new System.Drawing.Point(60, 502);
            reviewCaptionLabel.Name = "reviewCaptionLabel";
            reviewCaptionLabel.TabIndex = 12;
            reviewCaptionLabel.Text = "Your review";
            //
            // reviewTextBox
            //
            reviewTextBox.AcceptsReturn = true;
            reviewTextBox.BackColor = System.Drawing.Color.White;
            reviewTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewTextBox.ForeColor = System.Drawing.Color.Black;
            reviewTextBox.Location = new System.Drawing.Point(60, 524);
            reviewTextBox.MaxLength = 1000;
            reviewTextBox.Multiline = true;
            reviewTextBox.Name = "reviewTextBox";
            reviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            reviewTextBox.Size = new System.Drawing.Size(480, 150);
            reviewTextBox.TabIndex = 13;
            reviewTextBox.TextChanged += reviewTextBox_TextChanged;
            //
            // reviewCountLabel
            //
            reviewCountLabel.BackColor = System.Drawing.Color.White;
            reviewCountLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewCountLabel.ForeColor = System.Drawing.Color.Black;
            reviewCountLabel.Location = new System.Drawing.Point(340, 678);
            reviewCountLabel.Name = "reviewCountLabel";
            reviewCountLabel.Size = new System.Drawing.Size(200, 18);
            reviewCountLabel.TabIndex = 14;
            reviewCountLabel.Text = "0 / 1000 characters";
            reviewCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // submitButton
            //
            submitButton.BackColor = System.Drawing.Color.White;
            submitButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            submitButton.ForeColor = System.Drawing.Color.Black;
            submitButton.Location = new System.Drawing.Point(225, 708);
            submitButton.Name = "submitButton";
            submitButton.Size = new System.Drawing.Size(150, 44);
            submitButton.TabIndex = 15;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            //
            // contentPanel
            //
            contentPanel.BackColor = System.Drawing.Color.White;
            contentPanel.Controls.Add(submitButton);
            contentPanel.Controls.Add(reviewCountLabel);
            contentPanel.Controls.Add(reviewTextBox);
            contentPanel.Controls.Add(reviewCaptionLabel);
            contentPanel.Controls.Add(ratingValueLabel);
            contentPanel.Controls.Add(star5Button);
            contentPanel.Controls.Add(star4Button);
            contentPanel.Controls.Add(star3Button);
            contentPanel.Controls.Add(star2Button);
            contentPanel.Controls.Add(star1Button);
            contentPanel.Controls.Add(ratingCaptionLabel);
            contentPanel.Controls.Add(priceLabel);
            contentPanel.Controls.Add(descriptionTextBox);
            contentPanel.Controls.Add(productPicture);
            contentPanel.Controls.Add(titleLabel);
            contentPanel.Controls.Add(headerLabel);
            contentPanel.Location = new System.Drawing.Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new System.Drawing.Size(600, 780);
            contentPanel.TabIndex = 0;
            //
            // RatingForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(600, 780);
            Controls.Add(contentPanel);
            ForeColor = System.Drawing.Color.Black;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MinimumSize = new System.Drawing.Size(360, 300);
            MinimizeBox = false;
            Name = "RatingForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Product Rating System - Rate Product";
            FormClosing += ratingForm_FormClosing;
            Load += ratingForm_Load;
            Resize += ratingForm_Resize;
            FormClosed += ratingForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)productPicture).EndInit();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox productPicture;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label ratingCaptionLabel;
        private System.Windows.Forms.Button star1Button;
        private System.Windows.Forms.Button star2Button;
        private System.Windows.Forms.Button star3Button;
        private System.Windows.Forms.Button star4Button;
        private System.Windows.Forms.Button star5Button;
        private System.Windows.Forms.Label ratingValueLabel;
        private System.Windows.Forms.Label reviewCaptionLabel;
        private System.Windows.Forms.TextBox reviewTextBox;
        private System.Windows.Forms.Label reviewCountLabel;
        private System.Windows.Forms.Button submitButton;
    }
}
