using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog;

public class DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> : DialogSetOptionsBuilder<TValue> 
    where TControl : Control
{
    internal DialogSetOptionsWithSpecifiedControlBuilder(IDialogSet set) : base(set)
    {

    }

    /// <summary>
    /// Specifying action that will be invoked when user trying to get value from DialogSet.Value
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureGetter(Func<TControl, TValue> cfg)
    {
        Item.Data.GetterSpecifiedFromBuilder = true;
        Item.Data.Getter = (control) => cfg.Invoke((TControl)Item.Data.Control);
        return this;   
    }

    /// <summary>
    /// Specifying action that will be invoked when user trying to set value to DialogSet.Value
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureSetter(Action<TControl, TValue> cfg)
    {
        Item.Data.SetterSpecifiedFromBuilder = true;
        Item.Data.Setter = (control, value) => cfg.Invoke((TControl)Item.Data.Control, (TValue)value);
        return this;
    }

    /// <summary>
    /// Specifying template that will used for control
    /// </summary>
    /// <param name="control"></param>
    /// <returns></returns>
    public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> UseTemplate(TControl control)
    {
        Item.Data.Control = control;
        return this;
    }
}