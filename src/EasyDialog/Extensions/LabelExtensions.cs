using System.Drawing;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog;

public static class LabelExtensions
{
    /// <summary>
    /// Sets DialogSet<string> control as Label
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<Label, string> AsLabel(this DialogSetOptionsBuilder<string> builder) =>
        builder.AsFullRow()
            .AsControl<Label>()
            .ConfigureGetter((control) => control.Text)
            .ConfigureSetter((control, value) => control.Text = value);

    /// <summary>
    /// Sets TextAlign value of TextBox control
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="textAlign"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<Label, string> HasTextAlign
        (this DialogSetOptionsWithSpecifiedControlBuilder<Label, string> builder, ContentAlignment textAlign)
    {
        var control = builder.Item.Data.Control as Label;
        control!.TextAlign = textAlign;
        return builder;
    }

    /// <summary>
    /// Sets Text value of TextBox control
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<Label, string> HasText
        (this DialogSetOptionsWithSpecifiedControlBuilder<Label, string> builder, string text)
    {
        var control = builder.Item.Data.Control as Label;
        control!.Text = text;
        return builder;
    }
}