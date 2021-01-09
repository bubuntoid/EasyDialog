using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class CheckBoxItemBuilderExtensions
    {
        public static ItemOptionsBuilder<CheckBoxItem> HasValue(this ItemOptionsBuilder<CheckBoxItem> builder, bool value)
        {
            var control = GetControl(builder);
            control.Checked = value;

            return builder;
        }

        private static CheckBox GetControl(ItemOptionsBuilder<CheckBoxItem> builder) => (CheckBox)builder.Item.BaseControl;
    }
}
