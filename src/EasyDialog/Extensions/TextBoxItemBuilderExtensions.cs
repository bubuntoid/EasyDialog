using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class TextBoxItemBuilderExtensions
    {
        public static ItemOptionsBuilder<TextBoxItem> HasValue(this ItemOptionsBuilder<TextBoxItem> builder, string value)
        {
            var control = GetControl(builder);
            control.Text = value;

            return builder;
        }

        public static ItemOptionsBuilder<TextBoxItem> IsMultiline(this ItemOptionsBuilder<TextBoxItem> builder)
        {
            var control = GetControl(builder);
            control.Multiline = true;

            return builder;
        }

        public static ItemOptionsBuilder<TextBoxItem> UsePasswordChar(this ItemOptionsBuilder<TextBoxItem> builder, char passwordChar = '*')
        {
            var control = GetControl(builder);
            control.PasswordChar = passwordChar;

            return builder;
        }

        private static TextBox GetControl(ItemOptionsBuilder<TextBoxItem> builder) => (TextBox)builder.Item.BaseControl;
    }
}
