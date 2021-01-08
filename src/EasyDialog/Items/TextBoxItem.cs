using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class TextBoxItem : DialogItem<TextBox, string>
    {
        public override TextBox Control { get; set; } = new TextBox();

        public override string Value
        {
            get => Control.Text;
            set => Control.Text = value;
        }
    }
}
