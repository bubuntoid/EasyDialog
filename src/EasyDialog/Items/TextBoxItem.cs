using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class TextBoxItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new TextBox();

        public string Value
        {
            get => Control.Text;
            set => Control.Text = value;
        }
    }
}
