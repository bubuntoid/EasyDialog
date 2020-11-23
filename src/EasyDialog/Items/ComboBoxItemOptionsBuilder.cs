using System.Windows.Forms;
using System.Collections.Generic;

namespace EasyDialog
{
    public class ComboBoxItemOptionsBuilder : DialogItemOptionsBuilder
    {
        public ComboBoxItemOptionsBuilder(BaseDialogItem item) : base(item) { }

        public ComboBoxItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public ComboBoxItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }

        public ComboBoxItemOptionsBuilder HasDataSource(IEnumerable<string> source)
        {
            var control = (item.Control as ComboBox);
            control.Items.Clear();

            foreach (var item in source)
            {
                control.Items.Add(item);
            }

            return this;
        }

        public ComboBoxItemOptionsBuilder HasValue(string value)
        {
            var control = (item.Control as ComboBox);
            control.SelectedItem = value;
            return this;
        }
    }
}
