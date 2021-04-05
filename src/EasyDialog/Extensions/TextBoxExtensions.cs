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
            var control = builder.Set.Control as TextBox;
            control.PasswordChar = passwordChar;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> HasTextAlign
           (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, HorizontalAlignment textAlign)
        {
            var control = builder.Set.Control as TextBox;
            control.TextAlign = textAlign;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> IsMultiline
         (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, int size = 100)
        {
            var control = builder.Set.Control as TextBox;
            control.Multiline = true;
            builder.Set.ControlHeight = size;
            return builder;
        }
    }
}
