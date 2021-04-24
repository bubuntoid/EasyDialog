using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> : DialogCollectionSetOptionsBuilder<TValue>
        where TControl : Control
    {
        public DialogCollectionSetOptionsWithSpecifiedControlBuilder(IDialogCollectionSet set) : base(set)
        {

        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureOnUpdateItemsAction(Action<TControl, IEnumerable<TValue>> cfg)
        {
            CollectionSet.OnUpdateItemsActionSpecifiedFromBuilder = true;
            CollectionSet.OnUpdateItemsAction = (control, items) => 
            {
                cfg.Invoke((TControl)Item.Data.Control, items.Cast<TValue>());
            };
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureGetter(Func<TControl, TValue> cfg)
        {
            Item.Data.GetterSpecifiedFromBuilder = true;
            Item.Data.Getter = (control) => cfg.Invoke((TControl)Item.Data.Control);
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> ConfigureSetter(Action<TControl, TValue> cfg)
        {
            Item.Data.SetterSpecifiedFromBuilder = true;
            Item.Data.Setter = (control, value) => cfg.Invoke((TControl)Item.Data.Control, (TValue)value);
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> UseTemplate(TControl control)
        {
            Item.Data.Control = control;
            return this;
        }
    }
}
