using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class ItemForm : Form
    {
        public string ItemName { get; set; }
        public string ItemId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public string Property { get; set; }

        public List<StringStringObject> ComboBoxStrings = new List<StringStringObject>();

        public ItemForm()
        {
            InitializeComponent();
        }

        private void UpdateItemForm_Load(object sender, EventArgs e)
        {
            this.nameTextBox.Text = this.ItemName;
            this.valueTextBox.Text = this.Value.ToString();
            this.descriptionTextBox.Text = this.Description;
            this.idTextBox.Text = this.ItemId;
            this.propertyComboBox.DisplayMember = "String2";
            this.ComboBoxStrings.ForEach(stringString =>
                this.propertyComboBox.Items.Add(stringString));
            this.ComboBoxStrings.ForEach(stringString =>
            {
                if (stringString.String1 == this.Property)
                    propertyComboBox.SelectedItem = stringString;
            });

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.ItemName = this.nameTextBox.Text;
            this.Value = Int32.Parse(this.valueTextBox.Text);
            this.Property = ((StringStringObject)this.propertyComboBox.SelectedItem).String1;
            this.Description = this.descriptionTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}