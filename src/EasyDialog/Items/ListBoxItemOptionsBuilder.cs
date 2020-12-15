using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace bubuntoid.EasyDialog
{
    public class ListBoxItemOptionsBuilder : DialogItemOptionsBuilder
    {
        public ListBoxItemOptionsBuilder(BaseDialogItem item) : base(item) { }

        public ListBoxItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public ListBoxItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }

        public ListBoxItemOptionsBuilder HasDataSource(IEnumerable<string> source, bool autoSize = true)
        {
            var control = (item.Control as ListBox);
            control.Items.Clear();

            foreach (var item in source)
            {
                control.Items.Add(item);
            }

            if (autoSize)
                item.ControlHeight = source.Count() * 20 + 30;
            
            return this;
        }

        public ListBoxItemOptionsBuilder HasValue(string value)
        {
            var control = (item.Control as ListBox);
            control.SelectedItem = value;
            return this;
        }
    }
}
