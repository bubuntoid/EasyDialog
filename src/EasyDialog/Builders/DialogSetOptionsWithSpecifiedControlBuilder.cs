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
            Set.GetterSpecifiedFromBuilder = true;
            Set.Getter = (control) => cfg.Invoke((TControl)Set.Control);
            return this;   
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureSetter(Action<TControl, TValue> cfg)
        {
            Set.SetterSpecifiedFromBuilder = true;
            Set.Setter = (control, value) => cfg.Invoke((TControl)Set.Control, (TValue)value);
            return this;
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> UseTemplate(TControl control)
        {
            Set.Control = control;
            return this;
        }
    }
}
