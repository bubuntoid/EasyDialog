using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class TextBoxExtensions
    {
        /// <summary>
        /// Sets DialogSet<string> control as TextBox
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> AsTextBox(this DialogSetOptionsBuilder<string> builder) =>
            builder.AsControl<TextBox>()
                .ConfigureGetter((control) => control.Text)
                .ConfigureSetter((control, value) => control.Text = value);

        /// <summary>
        /// Sets PasswordChar value of TextBox control
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="passwordChar"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> UsePasswordChar
            (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, char passwordChar = '*')
        {
            var control = builder.Item.Data.Control as TextBox;
            control.PasswordChar = passwordChar;
            return builder;
        }

        /// <summary>
        /// Sets TextAlign value of TextBox control
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textAlign"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> HasTextAlign
           (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, HorizontalAlignment textAlign)
        {
            var control = builder.Item.Data.Control as TextBox;
            control.TextAlign = textAlign;
            return builder;
        }

        /// <summary>
        /// Sets Multiline value of TextBox control
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> IsMultiline
         (this DialogSetOptionsWithSpecifiedControlBuilder<TextBox, string> builder, int size = 100)
        {
            var control = builder.Item.Data.Control as TextBox;
            control.Multiline = true;
            builder.Item.Data.ControlHeight = size;
            return builder;
        }
    }
}
