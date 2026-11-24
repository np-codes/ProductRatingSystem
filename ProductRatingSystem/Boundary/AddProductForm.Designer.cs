namespace ProductRatingSystem.Boundary
{
    partial class AddProductForm
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
            titleCaptionLabel = new System.Windows.Forms.Label();
            titleTextBox = new System.Windows.Forms.TextBox();
            imageCaptionLabel = new System.Windows.Forms.Label();
            previewPicture = new System.Windows.Forms.PictureBox();
            chooseImageButton = new System.Windows.Forms.Button();
            imageNameLabel = new System.Windows.Forms.Label();
            descriptionCaptionLabel = new System.Windows.Forms.Label();
            descriptionTextBox = new System.Windows.Forms.TextBox();
            descriptionCountLabel = new System.Windows.Forms.Label();
            priceCaptionLabel = new System.Windows.Forms.Label();
            priceTextBox = new System.Windows.Forms.TextBox();
            submitButton = new System.Windows.Forms.Button();
            contentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)previewPicture).BeginInit();
            contentPanel.SuspendLayout();
            SuspendLayout();
            //
            // headerLabel
            //
            headerLabel.BackColor = System.Drawing.Color.Gainsboro;
            headerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            headerLabel.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            headerLabel.ForeColor = System.Drawing.Color.Black;
            headerLabel.Location = new System.Drawing.Point(20, 16);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new System.Drawing.Size(560, 54);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Add Product";
            headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // titleCaptionLabel
            //
            titleCaptionLabel.AutoSize = true;
            titleCaptionLabel.BackColor = System.Drawing.Color.White;
            titleCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            titleCaptionLabel.ForeColor = System.Drawing.Color.Black;
            titleCaptionLabel.Location = new System.Drawing.Point(60, 84);
            titleCaptionLabel.Name = "titleCaptionLabel";
            titleCaptionLabel.TabIndex = 1;
            titleCaptionLabel.Text = "Title";
            //
            // titleTextBox
            //
            titleTextBox.BackColor = System.Drawing.Color.White;
            titleTextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleTextBox.ForeColor = System.Drawing.Color.Black;
            titleTextBox.Location = new System.Drawing.Point(60, 106);
            titleTextBox.MaxLength = 100;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new System.Drawing.Size(480, 31);
            titleTextBox.TabIndex = 2;
            titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // imageCaptionLabel
            //
            imageCaptionLabel.AutoSize = true;
            imageCaptionLabel.BackColor = System.Drawing.Color.White;
            imageCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            imageCaptionLabel.ForeColor = System.Drawing.Color.Black;
            imageCaptionLabel.Location = new System.Drawing.Point(60, 150);
            imageCaptionLabel.Name = "imageCaptionLabel";
            imageCaptionLabel.TabIndex = 3;
            imageCaptionLabel.Text = "Image";
            //
            // previewPicture
            //
            previewPicture.BackColor = System.Drawing.Color.White;
            previewPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            previewPicture.Location = new System.Drawing.Point(210, 150);
            previewPicture.Name = "previewPicture";
            previewPicture.Size = new System.Drawing.Size(180, 180);
            previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            previewPicture.TabIndex = 4;
            previewPicture.TabStop = false;
            //
            // chooseImageButton
            //
            chooseImageButton.BackColor = System.Drawing.Color.White;
            chooseImageButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chooseImageButton.ForeColor = System.Drawing.Color.Black;
            chooseImageButton.Location = new System.Drawing.Point(225, 338);
            chooseImageButton.Name = "chooseImageButton";
            chooseImageButton.Size = new System.Drawing.Size(150, 30);
            chooseImageButton.TabIndex = 5;
            chooseImageButton.Text = "Choose Image...";
            chooseImageButton.UseVisualStyleBackColor = false;
            chooseImageButton.Click += chooseImageButton_Click;
            //
            // imageNameLabel
            //
            imageNameLabel.AutoEllipsis = true;
            imageNameLabel.BackColor = System.Drawing.Color.White;
            imageNameLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            imageNameLabel.ForeColor = System.Drawing.Color.Black;
            imageNameLabel.Location = new System.Drawing.Point(60, 372);
            imageNameLabel.Name = "imageNameLabel";
            imageNameLabel.Size = new System.Drawing.Size(480, 18);
            imageNameLabel.TabIndex = 6;
            imageNameLabel.Text = "No picture chosen";
            imageNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // descriptionCaptionLabel
            //
            descriptionCaptionLabel.AutoSize = true;
            descriptionCaptionLabel.BackColor = System.Drawing.Color.White;
            descriptionCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionCaptionLabel.ForeColor = System.Drawing.Color.Black;
            descriptionCaptionLabel.Location = new System.Drawing.Point(60, 398);
            descriptionCaptionLabel.Name = "descriptionCaptionLabel";
            descriptionCaptionLabel.TabIndex = 7;
            descriptionCaptionLabel.Text = "Description";
            //
            // descriptionTextBox
            //
            descriptionTextBox.AcceptsReturn = true;
            descriptionTextBox.BackColor = System.Drawing.Color.White;
            descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            descriptionTextBox.Location = new System.Drawing.Point(60, 420);
            descriptionTextBox.MaxLength = 1000;
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            descriptionTextBox.Size = new System.Drawing.Size(480, 150);
            descriptionTextBox.TabIndex = 8;
            descriptionTextBox.TextChanged += descriptionTextBox_TextChanged;
            //
            // descriptionCountLabel
            //
            descriptionCountLabel.BackColor = System.Drawing.Color.White;
            descriptionCountLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionCountLabel.ForeColor = System.Drawing.Color.Black;
            descriptionCountLabel.Location = new System.Drawing.Point(340, 574);
            descriptionCountLabel.Name = "descriptionCountLabel";
            descriptionCountLabel.Size = new System.Drawing.Size(200, 18);
            descriptionCountLabel.TabIndex = 9;
            descriptionCountLabel.Text = "0 / 1000 characters";
            descriptionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // priceCaptionLabel
            //
            priceCaptionLabel.AutoSize = true;
            priceCaptionLabel.BackColor = System.Drawing.Color.White;
            priceCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceCaptionLabel.ForeColor = System.Drawing.Color.Black;
            priceCaptionLabel.Location = new System.Drawing.Point(200, 600);
            priceCaptionLabel.Name = "priceCaptionLabel";
            priceCaptionLabel.TabIndex = 10;
            priceCaptionLabel.Text = "Price ($)";
            //
            // priceTextBox
            //
            priceTextBox.BackColor = System.Drawing.Color.White;
            priceTextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceTextBox.ForeColor = System.Drawing.Color.Black;
            priceTextBox.Location = new System.Drawing.Point(200, 622);
            priceTextBox.MaxLength = 13;
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new System.Drawing.Size(200, 31);
            priceTextBox.TabIndex = 11;
            priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // submitButton
            //
            submitButton.BackColor = System.Drawing.Color.White;
            submitButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            submitButton.ForeColor = System.Drawing.Color.Black;
            submitButton.Location = new System.Drawing.Point(225, 688);
            submitButton.Name = "submitButton";
            submitButton.Size = new System.Drawing.Size(150, 44);
            submitButton.TabIndex = 12;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            //
            // contentPanel
            //
            contentPanel.BackColor = System.Drawing.Color.White;
            contentPanel.Controls.Add(submitButton);
            contentPanel.Controls.Add(priceTextBox);
            contentPanel.Controls.Add(priceCaptionLabel);
            contentPanel.Controls.Add(descriptionCountLabel);
            contentPanel.Controls.Add(descriptionTextBox);
            contentPanel.Controls.Add(descriptionCaptionLabel);
            contentPanel.Controls.Add(imageNameLabel);
            contentPanel.Controls.Add(chooseImageButton);
            contentPanel.Controls.Add(previewPicture);
            contentPanel.Controls.Add(imageCaptionLabel);
            contentPanel.Controls.Add(titleTextBox);
            contentPanel.Controls.Add(titleCaptionLabel);
            contentPanel.Controls.Add(headerLabel);
            contentPanel.Location = new System.Drawing.Point(0, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new System.Drawing.Size(600, 780);
            contentPanel.TabIndex = 0;
            //
            // AddProductForm
            //
            AcceptButton = submitButton;
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
            Name = "AddProductForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Product Rating System - Add Product";
            FormClosing += addProductForm_FormClosing;
            Load += addProductForm_Load;
            Resize += addProductForm_Resize;
            FormClosed += addProductForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)previewPicture).EndInit();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label titleCaptionLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label imageCaptionLabel;
        private System.Windows.Forms.PictureBox previewPicture;
        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.Label imageNameLabel;
        private System.Windows.Forms.Label descriptionCaptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionCountLabel;
        private System.Windows.Forms.Label priceCaptionLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Button submitButton;
    }
}
