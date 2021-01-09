using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class ComboBoxItemBuilderExtensions
    {
        public static ItemOptionsBuilder<ComboBoxItem> HasValue(this ItemOptionsBuilder<ComboBoxItem> builder, string value)
        {
            var control = GetControl(builder);
            control.SelectedItem = value;

            return builder;
        }

        public static ItemOptionsBuilder<ComboBoxItem> HasDataSource(this ItemOptionsBuilder<ComboBoxItem> builder, IEnumerable<string> source)
        {
            var control = GetControl(builder);
            control.Items.Clear();

            foreach (var item in source)
            {
                control.Items.Add(item);
            }

            return builder;
        }

        private static ComboBox GetControl(ItemOptionsBuilder<ComboBoxItem> builder) => (ComboBox)builder.Item.BaseControl;
    }
}
