using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class ListBoxItemBuilderExtensions
    {
        public static ItemOptionsBuilder<ListBoxItem> HasValue(this ItemOptionsBuilder<ListBoxItem> builder, string value)
        {
            var control = GetControl(builder);
            control.SelectedItem = value;

            return builder;
        }

        public static ItemOptionsBuilder<ListBoxItem> HasDataSource(this ItemOptionsBuilder<ListBoxItem> builder, IEnumerable<string> source, bool autoSize = true)
        {
            var control = GetControl(builder);
            control.Items.Clear();

            foreach (var item in source)
            {
                control.Items.Add(item);
            }

            if (autoSize)
            {
                builder.Item.ControlHeight = source.Count() * 20 + 30;
            }

            return builder;
        }

        private static ListBox GetControl(ItemOptionsBuilder<ListBoxItem> builder) => (ListBox)builder.Item.BaseControl;
    }
}
