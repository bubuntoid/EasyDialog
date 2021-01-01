using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class ListBoxItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new ListBox();

        public string Value
        {
            get => (string) ((ListBox) Control).SelectedItem;
            set => ((ListBox) Control).SelectedItem = value;
        }
    }
}
