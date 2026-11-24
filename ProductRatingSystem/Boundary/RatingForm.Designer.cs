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
            // All sizes and margins are 96-DPI (100%) values. The page is a table whose rows
            // size themselves to their content, so text never overlaps or is cut off at any
            // display scale; the form scrolls if the content is ever taller than the window.
            headerLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            productPicture = new System.Windows.Forms.PictureBox();
            descriptionTextBox = new System.Windows.Forms.TextBox();
            priceLabel = new System.Windows.Forms.Label();
            ratingBox = new System.Windows.Forms.FlowLayoutPanel();
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
            contentPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)productPicture).BeginInit();
            ratingBox.SuspendLayout();
            contentPanel.SuspendLayout();
            SuspendLayout();
            //
            // headerLabel
            //
            headerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerLabel.AutoSize = true;
            headerLabel.BackColor = System.Drawing.Color.Gainsboro;
            headerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            headerLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            headerLabel.ForeColor = System.Drawing.Color.Black;
            headerLabel.Margin = new System.Windows.Forms.Padding(20, 16, 20, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Rate The Product";
            headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // titleLabel
            //
            titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            titleLabel.AutoEllipsis = true;
            titleLabel.BackColor = System.Drawing.Color.White;
            titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleLabel.ForeColor = System.Drawing.Color.Black;
            titleLabel.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(480, 36);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Product Title";
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // productPicture
            //
            productPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            productPicture.BackColor = System.Drawing.Color.White;
            productPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            productPicture.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            productPicture.Name = "productPicture";
            productPicture.Size = new System.Drawing.Size(160, 160);
            productPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            productPicture.TabIndex = 2;
            productPicture.TabStop = false;
            //
            // descriptionTextBox
            //
            descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            descriptionTextBox.BackColor = System.Drawing.Color.White;
            descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            descriptionTextBox.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
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
            priceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            priceLabel.AutoSize = true;
            priceLabel.BackColor = System.Drawing.Color.White;
            priceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            priceLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceLabel.ForeColor = System.Drawing.Color.Black;
            priceLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            priceLabel.MinimumSize = new System.Drawing.Size(200, 32);
            priceLabel.Name = "priceLabel";
            priceLabel.TabIndex = 4;
            priceLabel.Text = "$0.00";
            priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ratingBox (box around the "Rating:" row; the row sizes itself to its content)
            //
            ratingBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            ratingBox.AutoSize = true;
            ratingBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ratingBox.BackColor = System.Drawing.Color.White;
            ratingBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ratingBox.Controls.Add(ratingCaptionLabel);
            ratingBox.Controls.Add(star1Button);
            ratingBox.Controls.Add(star2Button);
            ratingBox.Controls.Add(star3Button);
            ratingBox.Controls.Add(star4Button);
            ratingBox.Controls.Add(star5Button);
            ratingBox.Controls.Add(ratingValueLabel);
            ratingBox.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            ratingBox.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            ratingBox.MinimumSize = new System.Drawing.Size(460, 48);
            ratingBox.Name = "ratingBox";
            ratingBox.Padding = new System.Windows.Forms.Padding(10, 1, 10, 1);
            ratingBox.TabIndex = 6;
            ratingBox.WrapContents = false;
            //
            // ratingCaptionLabel
            //
            ratingCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ratingCaptionLabel.AutoSize = true;
            ratingCaptionLabel.BackColor = System.Drawing.Color.White;
            ratingCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ratingCaptionLabel.ForeColor = System.Drawing.Color.Black;
            ratingCaptionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            ratingCaptionLabel.MinimumSize = new System.Drawing.Size(90, 0);
            ratingCaptionLabel.Name = "ratingCaptionLabel";
            ratingCaptionLabel.TabIndex = 5;
            ratingCaptionLabel.Text = "Rating:";
            ratingCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // star1Button
            //
            star1Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            star1Button.BackColor = System.Drawing.Color.White;
            star1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star1Button.FlatAppearance.BorderSize = 0;
            star1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star1Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star1Button.ForeColor = System.Drawing.Color.Black;
            star1Button.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            star1Button.Padding = new System.Windows.Forms.Padding(0);
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
            star2Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            star2Button.BackColor = System.Drawing.Color.White;
            star2Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star2Button.FlatAppearance.BorderSize = 0;
            star2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star2Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star2Button.ForeColor = System.Drawing.Color.Black;
            star2Button.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            star2Button.Padding = new System.Windows.Forms.Padding(0);
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
            star3Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            star3Button.BackColor = System.Drawing.Color.White;
            star3Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star3Button.FlatAppearance.BorderSize = 0;
            star3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star3Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star3Button.ForeColor = System.Drawing.Color.Black;
            star3Button.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            star3Button.Padding = new System.Windows.Forms.Padding(0);
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
            star4Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            star4Button.BackColor = System.Drawing.Color.White;
            star4Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star4Button.FlatAppearance.BorderSize = 0;
            star4Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star4Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star4Button.ForeColor = System.Drawing.Color.Black;
            star4Button.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            star4Button.Padding = new System.Windows.Forms.Padding(0);
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
            star5Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            star5Button.BackColor = System.Drawing.Color.White;
            star5Button.Cursor = System.Windows.Forms.Cursors.Hand;
            star5Button.FlatAppearance.BorderSize = 0;
            star5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            star5Button.Font = new System.Drawing.Font("Segoe UI Symbol", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            star5Button.ForeColor = System.Drawing.Color.Black;
            star5Button.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            star5Button.Padding = new System.Windows.Forms.Padding(0);
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
            ratingValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ratingValueLabel.AutoSize = true;
            ratingValueLabel.BackColor = System.Drawing.Color.White;
            ratingValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ratingValueLabel.ForeColor = System.Drawing.Color.Black;
            ratingValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            ratingValueLabel.MinimumSize = new System.Drawing.Size(120, 0);
            ratingValueLabel.Name = "ratingValueLabel";
            ratingValueLabel.TabIndex = 11;
            ratingValueLabel.Text = "(not selected)";
            ratingValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // reviewCaptionLabel
            //
            reviewCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            reviewCaptionLabel.AutoSize = true;
            reviewCaptionLabel.BackColor = System.Drawing.Color.White;
            reviewCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewCaptionLabel.ForeColor = System.Drawing.Color.Black;
            reviewCaptionLabel.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            reviewCaptionLabel.Name = "reviewCaptionLabel";
            reviewCaptionLabel.TabIndex = 12;
            reviewCaptionLabel.Text = "Your review";
            //
            // reviewTextBox
            //
            reviewTextBox.AcceptsReturn = true;
            reviewTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            reviewTextBox.BackColor = System.Drawing.Color.White;
            reviewTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewTextBox.ForeColor = System.Drawing.Color.Black;
            reviewTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
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
            reviewCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            reviewCountLabel.AutoSize = true;
            reviewCountLabel.BackColor = System.Drawing.Color.White;
            reviewCountLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            reviewCountLabel.ForeColor = System.Drawing.Color.Black;
            reviewCountLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            reviewCountLabel.Name = "reviewCountLabel";
            reviewCountLabel.TabIndex = 14;
            reviewCountLabel.Text = "0 / 1000 characters";
            reviewCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // submitButton
            //
            submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            submitButton.AutoSize = true;
            submitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            submitButton.BackColor = System.Drawing.Color.White;
            submitButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            submitButton.ForeColor = System.Drawing.Color.Black;
            submitButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 6);
            submitButton.MinimumSize = new System.Drawing.Size(150, 44);
            submitButton.Name = "submitButton";
            submitButton.TabIndex = 15;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            //
            // contentPanel (the page: 60 | 480 | 60 columns, rows grow with their content)
            //
            contentPanel.AutoSize = true;
            contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            contentPanel.BackColor = System.Drawing.Color.White;
            contentPanel.ColumnCount = 3;
            contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            contentPanel.Controls.Add(headerLabel, 0, 0);
            contentPanel.Controls.Add(titleLabel, 1, 1);
            contentPanel.Controls.Add(productPicture, 0, 2);
            contentPanel.Controls.Add(descriptionTextBox, 1, 3);
            contentPanel.Controls.Add(priceLabel, 0, 4);
            contentPanel.Controls.Add(ratingBox, 0, 5);
            contentPanel.Controls.Add(reviewCaptionLabel, 1, 6);
            contentPanel.Controls.Add(reviewTextBox, 1, 7);
            contentPanel.Controls.Add(reviewCountLabel, 1, 8);
            contentPanel.Controls.Add(submitButton, 0, 9);
            contentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            contentPanel.Name = "contentPanel";
            contentPanel.RowCount = 10;
            for (int row = 0; row < 10; row++)
            {
                contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            }
            contentPanel.TabIndex = 0;
            contentPanel.SetColumnSpan(headerLabel, 3);
            contentPanel.SetColumnSpan(productPicture, 3);
            contentPanel.SetColumnSpan(priceLabel, 3);
            contentPanel.SetColumnSpan(ratingBox, 3);
            contentPanel.SetColumnSpan(submitButton, 3);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
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
            ratingBox.ResumeLayout(false);
            ratingBox.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.FlowLayoutPanel ratingBox;
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
