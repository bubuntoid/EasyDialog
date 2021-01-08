using System.Drawing;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class CheckBoxItem : DialogItem<CheckBox, bool>
    {
        public override CheckBox Control { get; set; } = new CheckBox()
        {
            BackColor = Color.Transparent
        };

        public override bool Value
        {
            get => Control.Checked;
            set => Control.Checked = value;
        }
    }
}
