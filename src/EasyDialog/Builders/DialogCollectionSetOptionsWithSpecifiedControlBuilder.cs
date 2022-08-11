using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog;

public class DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> : DialogCollectionSetOptionsBuilder<TValue>
    where TControl : Control
{
    internal DialogCollectionSetOptionsWithSpecifiedControlBuilder(IDialogCollectionSet set) : base(set)
    {

    }

    /// <summary>
    /// Specifying action that will be invoked when property DialogCollectionSet.DataSource is changed
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureOnUpdateItemsAction(Action<TControl, IEnumerable<TValue>> cfg)
    {
        CollectionSet.OnUpdateItemsActionSpecifiedFromBuilder = true;
        CollectionSet.OnUpdateItemsAction = (control, items) => 
        {
            cfg.Invoke((TControl)Item.Data.Control, items.Cast<TValue>());
        };
        return this;
    }

    /// <summary>
    /// Specifying action that will be invoked when user trying to get value from DialogCollectionSet.Value
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureGetter(Func<TControl, TValue> cfg)
    {
        Item.Data.GetterSpecifiedFromBuilder = true;
        Item.Data.Getter = (control) => cfg.Invoke((TControl)Item.Data.Control);
        return this;
    }

    /// <summary>
    /// Specifying action that will be invoked when user trying to set value to DialogCollectionSet.Value
    /// </summary>
    /// <param name="cfg"></param>
    /// <returns></returns>
    public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureSetter(Action<TControl, TValue> cfg)
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
    public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> UseTemplate(TControl control)
    {
        Item.Data.Control = control;
        return this;
    }
}