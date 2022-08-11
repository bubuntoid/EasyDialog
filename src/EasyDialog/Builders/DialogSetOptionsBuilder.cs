using System.Windows.Forms;

namespace bubuntoid.EasyDialog;

public class DialogSetOptionsBuilder<TValue> : DialogSetOptionsBuilderBase<DialogSetOptionsBuilder<TValue>, TValue>
{
    internal DialogSetOptionsBuilder(IDialogSet set) : base(set)
    {

    }

    /// <summary>
    /// Specifying control for current DialogSet by using TControl template
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    /// <param name="control"></param>
    /// <returns></returns>
    public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>(TControl control) where TControl : Control
    {
        Item.Data.ControlSpecifiedFromBuilder = true;
        Item.Data.Control = control;
        return new DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue>(Item);
    }

    /// <summary>
    /// Specifying control for current DialogSet by using TControl generics.
    /// </summary>
    /// <typeparam name="TControl"></typeparam>
    /// <returns></returns>
    public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>() where TControl : Control, new() => AsControl(new TControl());
}