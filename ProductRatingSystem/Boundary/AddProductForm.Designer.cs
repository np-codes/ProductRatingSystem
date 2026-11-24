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
            // All sizes and margins are 96-DPI (100%) values. The page is a table whose rows
            // size themselves to their content, so text never overlaps or is cut off at any
            // display scale; the form scrolls if the content is ever taller than the window.
            headerLabel = new System.Windows.Forms.Label();
            titleCaptionLabel = new System.Windows.Forms.Label();
            titleTextBox = new System.Windows.Forms.TextBox();
            imageRowTable = new System.Windows.Forms.TableLayoutPanel();
            imageCaptionLabel = new System.Windows.Forms.Label();
            previewPicture = new System.Windows.Forms.PictureBox();
            chooseImageButton = new System.Windows.Forms.Button();
            imageNameLabel = new System.Windows.Forms.Label();
            descriptionCaptionLabel = new System.Windows.Forms.Label();
            descriptionTextBox = new System.Windows.Forms.TextBox();
            descriptionCountLabel = new System.Windows.Forms.Label();
            priceTable = new System.Windows.Forms.TableLayoutPanel();
            priceCaptionLabel = new System.Windows.Forms.Label();
            priceTextBox = new System.Windows.Forms.TextBox();
            submitButton = new System.Windows.Forms.Button();
            contentPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)previewPicture).BeginInit();
            imageRowTable.SuspendLayout();
            priceTable.SuspendLayout();
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
            headerLabel.Text = "Add Product";
            headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // titleCaptionLabel
            //
            titleCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            titleCaptionLabel.AutoSize = true;
            titleCaptionLabel.BackColor = System.Drawing.Color.White;
            titleCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            titleCaptionLabel.ForeColor = System.Drawing.Color.Black;
            titleCaptionLabel.Margin = new System.Windows.Forms.Padding(0, 14, 0, 0);
            titleCaptionLabel.Name = "titleCaptionLabel";
            titleCaptionLabel.TabIndex = 1;
            titleCaptionLabel.Text = "Title";
            //
            // titleTextBox
            //
            titleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            titleTextBox.BackColor = System.Drawing.Color.White;
            titleTextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            titleTextBox.ForeColor = System.Drawing.Color.Black;
            titleTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            titleTextBox.MaxLength = 100;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.TabIndex = 2;
            titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // imageRowTable (caption "Image" on the left, the picture centered)
            //
            imageRowTable.AutoSize = true;
            imageRowTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            imageRowTable.ColumnCount = 3;
            imageRowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            imageRowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            imageRowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            imageRowTable.Controls.Add(imageCaptionLabel, 0, 0);
            imageRowTable.Controls.Add(previewPicture, 1, 0);
            imageRowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            imageRowTable.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            imageRowTable.Name = "imageRowTable";
            imageRowTable.RowCount = 1;
            imageRowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            imageRowTable.TabIndex = 3;
            //
            // imageCaptionLabel
            //
            imageCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            imageCaptionLabel.AutoSize = true;
            imageCaptionLabel.BackColor = System.Drawing.Color.White;
            imageCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            imageCaptionLabel.ForeColor = System.Drawing.Color.Black;
            imageCaptionLabel.Margin = new System.Windows.Forms.Padding(0);
            imageCaptionLabel.Name = "imageCaptionLabel";
            imageCaptionLabel.TabIndex = 0;
            imageCaptionLabel.Text = "Image";
            //
            // previewPicture
            //
            previewPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            previewPicture.BackColor = System.Drawing.Color.White;
            previewPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            previewPicture.Margin = new System.Windows.Forms.Padding(0);
            previewPicture.Name = "previewPicture";
            previewPicture.Size = new System.Drawing.Size(180, 180);
            previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            previewPicture.TabIndex = 1;
            previewPicture.TabStop = false;
            //
            // chooseImageButton
            //
            chooseImageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            chooseImageButton.AutoSize = true;
            chooseImageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            chooseImageButton.BackColor = System.Drawing.Color.White;
            chooseImageButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            chooseImageButton.ForeColor = System.Drawing.Color.Black;
            chooseImageButton.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            chooseImageButton.MinimumSize = new System.Drawing.Size(150, 30);
            chooseImageButton.Name = "chooseImageButton";
            chooseImageButton.TabIndex = 5;
            chooseImageButton.Text = "Choose Image...";
            chooseImageButton.UseVisualStyleBackColor = false;
            chooseImageButton.Click += chooseImageButton_Click;
            //
            // imageNameLabel
            //
            imageNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            imageNameLabel.AutoEllipsis = true;
            imageNameLabel.AutoSize = true;
            imageNameLabel.BackColor = System.Drawing.Color.White;
            imageNameLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            imageNameLabel.ForeColor = System.Drawing.Color.Black;
            imageNameLabel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            imageNameLabel.MaximumSize = new System.Drawing.Size(480, 0);
            imageNameLabel.Name = "imageNameLabel";
            imageNameLabel.TabIndex = 6;
            imageNameLabel.Text = "No picture chosen";
            imageNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // descriptionCaptionLabel
            //
            descriptionCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            descriptionCaptionLabel.AutoSize = true;
            descriptionCaptionLabel.BackColor = System.Drawing.Color.White;
            descriptionCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionCaptionLabel.ForeColor = System.Drawing.Color.Black;
            descriptionCaptionLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            descriptionCaptionLabel.Name = "descriptionCaptionLabel";
            descriptionCaptionLabel.TabIndex = 7;
            descriptionCaptionLabel.Text = "Description";
            //
            // descriptionTextBox
            //
            descriptionTextBox.AcceptsReturn = true;
            descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            descriptionTextBox.BackColor = System.Drawing.Color.White;
            descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionTextBox.ForeColor = System.Drawing.Color.Black;
            descriptionTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
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
            descriptionCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            descriptionCountLabel.AutoSize = true;
            descriptionCountLabel.BackColor = System.Drawing.Color.White;
            descriptionCountLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            descriptionCountLabel.ForeColor = System.Drawing.Color.Black;
            descriptionCountLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            descriptionCountLabel.Name = "descriptionCountLabel";
            descriptionCountLabel.TabIndex = 9;
            descriptionCountLabel.Text = "0 / 1000 characters";
            descriptionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // priceTable (caption "Price ($)" above the price box, both centered on the page)
            //
            priceTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            priceTable.AutoSize = true;
            priceTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            priceTable.ColumnCount = 1;
            priceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            priceTable.Controls.Add(priceCaptionLabel, 0, 0);
            priceTable.Controls.Add(priceTextBox, 0, 1);
            priceTable.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            priceTable.Name = "priceTable";
            priceTable.RowCount = 2;
            priceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            priceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            priceTable.TabIndex = 10;
            //
            // priceCaptionLabel
            //
            priceCaptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            priceCaptionLabel.AutoSize = true;
            priceCaptionLabel.BackColor = System.Drawing.Color.White;
            priceCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceCaptionLabel.ForeColor = System.Drawing.Color.Black;
            priceCaptionLabel.Margin = new System.Windows.Forms.Padding(0);
            priceCaptionLabel.Name = "priceCaptionLabel";
            priceCaptionLabel.TabIndex = 0;
            priceCaptionLabel.Text = "Price ($)";
            //
            // priceTextBox
            //
            priceTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            priceTextBox.BackColor = System.Drawing.Color.White;
            priceTextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            priceTextBox.ForeColor = System.Drawing.Color.Black;
            priceTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            priceTextBox.MaxLength = 13;
            priceTextBox.Name = "priceTextBox";
            priceTextBox.TabIndex = 1;
            priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // submitButton
            //
            submitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            submitButton.AutoSize = true;
            submitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            submitButton.BackColor = System.Drawing.Color.White;
            submitButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            submitButton.ForeColor = System.Drawing.Color.Black;
            submitButton.Margin = new System.Windows.Forms.Padding(0, 30, 0, 20);
            submitButton.MinimumSize = new System.Drawing.Size(150, 44);
            submitButton.Name = "submitButton";
            submitButton.TabIndex = 12;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            //
            // contentPanel (the page: 20 | 480 | 20 columns, rows grow with their content)
            //
            contentPanel.AutoSize = true;
            contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            contentPanel.BackColor = System.Drawing.Color.White;
            contentPanel.ColumnCount = 3;
            contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            contentPanel.Controls.Add(headerLabel, 0, 0);
            contentPanel.Controls.Add(titleCaptionLabel, 1, 1);
            contentPanel.Controls.Add(titleTextBox, 1, 2);
            contentPanel.Controls.Add(imageRowTable, 1, 3);
            contentPanel.Controls.Add(chooseImageButton, 1, 4);
            contentPanel.Controls.Add(imageNameLabel, 1, 5);
            contentPanel.Controls.Add(descriptionCaptionLabel, 1, 6);
            contentPanel.Controls.Add(descriptionTextBox, 1, 7);
            contentPanel.Controls.Add(descriptionCountLabel, 1, 8);
            contentPanel.Controls.Add(priceTable, 0, 9);
            contentPanel.Controls.Add(submitButton, 0, 10);
            contentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            contentPanel.Name = "contentPanel";
            contentPanel.RowCount = 11;
            for (int row = 0; row < 11; row++)
            {
                contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            }
            contentPanel.TabIndex = 0;
            contentPanel.SetColumnSpan(headerLabel, 3);
            contentPanel.SetColumnSpan(priceTable, 3);
            contentPanel.SetColumnSpan(submitButton, 3);
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
            imageRowTable.ResumeLayout(false);
            imageRowTable.PerformLayout();
            priceTable.ResumeLayout(false);
            priceTable.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.TableLayoutPanel imageRowTable;
        private System.Windows.Forms.TableLayoutPanel priceTable;
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
