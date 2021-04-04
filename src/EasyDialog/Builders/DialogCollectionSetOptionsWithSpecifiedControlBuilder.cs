using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> : DialogCollectionSetOptionsBuilder<TValue>
        where TControl : Control
    {
        public DialogCollectionSetOptionsWithSpecifiedControlBuilder(IDialogCollectionSet set) : base(set)
        {

        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureUpdateItemsEvent(Action<TControl, IEnumerable<TValue>> cfg)
        {
            CollectionSet.UpdateItemsEventSpecifiedFromBuilder = true;
            CollectionSet.UpdateItemsEvent = (control, items) => cfg.Invoke((TControl)Set.Control, (IEnumerable<TValue>)items);
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureGetter(Func<TControl, TValue> cfg)
        {
            Set.GetterSpecifiedFromBuilder = true;
            Set.Getter = (control) => cfg.Invoke((TControl)Set.Control);
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureSetter(Action<TControl, TValue> cfg)
        {
            Set.SetterSpecifiedFromBuilder = true;
            Set.Setter = (control, value) => cfg.Invoke((TControl)Set.Control, (TValue)value);
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> UseTemplate(TControl control)
        {
            Set.Control = control;
            return this;
        }
    }
}
