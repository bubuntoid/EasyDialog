using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class ComboBoxItem : DialogItem<ComboBox, string>
    {
        public override ComboBox Control { get; set; } = new ComboBox();

        public override string Value
        {
            get => (string) Control.SelectedItem;
            set => Control.SelectedItem = value;
        }
    }
}
