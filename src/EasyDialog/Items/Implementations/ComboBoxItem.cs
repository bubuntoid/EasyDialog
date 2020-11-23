using System.Windows.Forms;

namespace EasyDialog
{
    public class ComboBoxItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new ComboBox();

        public string Value
        {
            get => (string) ((ComboBox) Control).SelectedItem;
            set => ((ComboBox) Control).SelectedItem = value;
        }
    }
}
