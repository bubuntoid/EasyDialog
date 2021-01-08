using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class ListBoxItem : DialogItem<ListBox, string>
    {
        public override ListBox Control { get; set; } = new ListBox();

        public override string Value
        {
            get => (string)Control.SelectedItem;
            set => Control.SelectedItem = value;
        }
    }
}
