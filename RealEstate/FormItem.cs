using System.Windows.Forms;

namespace RealEstate
{
    public class FormItem
    {
        public Label label { get; set; }
        public TextBox textBox { get; set; }

        public FormItem()
        {
        }

        public FormItem(Label label, TextBox textBox)
        {
            this.label = label;
            this.textBox = textBox;
        }
    }
}