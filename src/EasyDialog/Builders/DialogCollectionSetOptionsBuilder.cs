using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog
{
    public class DialogCollectionSetOptionsBuilder<TValue> : DialogSetOptionsBuilderBase<DialogCollectionSetOptionsBuilder<TValue>, TValue>
    {
        internal IDialogCollectionSet CollectionSet => (IDialogCollectionSet)Item;

        internal DialogCollectionSetOptionsBuilder(IDialogCollectionSet set) : base(set)
        {

        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>(TControl control) where TControl : Control
        {
            Item.Data.ControlSpecifiedFromBuilder = true;
            Item.Data.Control = control;
            return new DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue>(CollectionSet);
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>() where TControl : Control, new() => AsControl(new TControl());

        public DialogCollectionSetOptionsBuilder<TValue> HasDataSource(IEnumerable<TValue> value)
        {
            CollectionSet.DataSource = value.Cast<object>();
            return this;
        }
    }
}
