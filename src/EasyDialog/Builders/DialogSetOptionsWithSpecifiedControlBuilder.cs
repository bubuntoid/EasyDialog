using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> : DialogSetOptionsBuilder<TValue> 
        where TControl : Control
    {
        public DialogSetOptionsWithSpecifiedControlBuilder(IDialogSet set) : base(set)
        {

        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureGetter(Func<TControl, TValue> cfg)
        {
            Item.Data.GetterSpecifiedFromBuilder = true;
            Item.Data.Getter = (control) => cfg.Invoke((TControl)Item.Data.Control);
            return this;   
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureSetter(Action<TControl, TValue> cfg)
        {
            Item.Data.SetterSpecifiedFromBuilder = true;
            Item.Data.Setter = (control, value) => cfg.Invoke((TControl)Item.Data.Control, (TValue)value);
            return this;
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> UseTemplate(TControl control)
        {
            Item.Data.Control = control;
            return this;
        }
    }
}
