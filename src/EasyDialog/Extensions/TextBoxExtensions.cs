using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class TextBoxExtensions
    {
        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> AsTextBox(this DialogSetOptionsBuilder<string> builder) =>
            new DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string>(builder.Set)
                .ConfigureGetter((control) => control.Text)
                .ConfigureSetter((control, value) => control.Text = value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> UsePasswordChar
            (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, char passwordChar = '*')
        {
            var textBox = builder.Set.Control as TextBox;
            textBox.PasswordChar = passwordChar;
            return builder;
        }
    }
}
