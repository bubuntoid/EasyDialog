using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class TextBoxExtensions
    {
        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> AsTextBox(this DialogSetOptionsBuilder<string> builder) =>
            builder.AsControl<TextBox>()
                .ConfigureGetter((control) => control.Text)
                .ConfigureSetter((control, value) => control.Text = value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> UsePasswordChar
            (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, char passwordChar = '*')
        {
            var textBox = builder.Set.Control as TextBox;
            textBox.PasswordChar = passwordChar;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> HasTextAlign
           (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, HorizontalAlignment textAlign)
        {
            var textBox = builder.Set.Control as TextBox;
            textBox.TextAlign = textAlign;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> IsMultiline
         (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, int size = 100)
        {
            var textBox = builder.Set.Control as TextBox;
            textBox.Multiline = true;
            builder.Set.ControlHeight = size;
            return builder;
        }
    }
}
