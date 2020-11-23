using System.Drawing;
using System.Windows.Forms;

namespace EasyDialog
{
    public class CheckBoxItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new CheckBox()
        {
            BackColor = Color.Transparent
        };

        public bool Value
        {
            get => ((CheckBox) Control).Checked;
            set => ((CheckBox) Control).Checked = value;
        }
    }
}
