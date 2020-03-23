namespace RealEstate
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.removeItemAtPropertyButton = new System.Windows.Forms.Button();
            this.updateItemAtPropertyButton = new System.Windows.Forms.Button();
            this.addItemToPropertyButton = new System.Windows.Forms.Button();
            this.Properties = new System.Windows.Forms.DataGridView();
            this.ItemsAtProperty = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) (this.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ItemsAtProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(82, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Property:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(674, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Items at property:";
            // 
            // removeItemAtPropertyButton
            // 
            this.removeItemAtPropertyButton.Location = new System.Drawing.Point(832, 494);
            this.removeItemAtPropertyButton.Name = "removeItemAtPropertyButton";
            this.removeItemAtPropertyButton.Size = new System.Drawing.Size(145, 27);
            this.removeItemAtPropertyButton.TabIndex = 4;
            this.removeItemAtPropertyButton.Text = "Remove selected";
            this.removeItemAtPropertyButton.UseVisualStyleBackColor = true;
            this.removeItemAtPropertyButton.Click += new System.EventHandler(this.removeItemAtPropertyButton_Click);
            // 
            // updateItemAtPropertyButton
            // 
            this.updateItemAtPropertyButton.Location = new System.Drawing.Point(680, 494);
            this.updateItemAtPropertyButton.Name = "updateItemAtPropertyButton";
            this.updateItemAtPropertyButton.Size = new System.Drawing.Size(145, 27);
            this.updateItemAtPropertyButton.TabIndex = 5;
            this.updateItemAtPropertyButton.Text = "Update selected";
            this.updateItemAtPropertyButton.UseVisualStyleBackColor = true;
            this.updateItemAtPropertyButton.Click += new System.EventHandler(this.updateItemAtPropertyButton_Click);
            // 
            // addItemToPropertyButton
            // 
            this.addItemToPropertyButton.Location = new System.Drawing.Point(115, 507);
            this.addItemToPropertyButton.Name = "addItemToPropertyButton";
            this.addItemToPropertyButton.Size = new System.Drawing.Size(145, 27);
            this.addItemToPropertyButton.TabIndex = 6;
            this.addItemToPropertyButton.Text = "Add to selected";
            this.addItemToPropertyButton.UseVisualStyleBackColor = true;
            this.addItemToPropertyButton.Click += new System.EventHandler(this.addItemToPropertyButton_Click);
            // 
            // Properties
            // 
            this.Properties.AccessibleName = "Properties";
            this.Properties.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Properties.Location = new System.Drawing.Point(28, 85);
            this.Properties.Name = "Properties";
            this.Properties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Properties.Size = new System.Drawing.Size(376, 388);
            this.Properties.TabIndex = 1;
            this.Properties.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.Properties_CellContentClick);
            // 
            // ItemsAtProperty
            // 
            this.ItemsAtProperty.AccessibleName = "ItemsAtProperty";
            this.ItemsAtProperty.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsAtProperty.Location = new System.Drawing.Point(644, 95);
            this.ItemsAtProperty.Name = "ItemsAtProperty";
            this.ItemsAtProperty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsAtProperty.Size = new System.Drawing.Size(355, 378);
            this.ItemsAtProperty.TabIndex = 0;
            this.ItemsAtProperty.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsAtProperty_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 702);
            this.Controls.Add(this.addItemToPropertyButton);
            this.Controls.Add(this.updateItemAtPropertyButton);
            this.Controls.Add(this.removeItemAtPropertyButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Properties);
            this.Controls.Add(this.ItemsAtProperty);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ItemsAtProperty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeItemAtPropertyButton;
        private System.Windows.Forms.Button updateItemAtPropertyButton;
        private System.Windows.Forms.Button addItemToPropertyButton;
        private System.Windows.Forms.DataGridView Properties;
        private System.Windows.Forms.DataGridView ItemsAtProperty;
    }
}

