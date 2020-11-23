using System.Windows.Forms;

namespace EasyDialog
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
