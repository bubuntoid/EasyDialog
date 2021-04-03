using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogCollectionSetOptionsBuilder<TValue>
    {
        internal readonly IDialogCollectionSet Set;

        public DialogCollectionSetOptionsBuilder(IDialogCollectionSet set)
        {
            Set = set;
        }

        public DialogCollectionSetOptionsBuilder<TValue> Ignore()
        {
            Set.Ignore = true;
            return this;
        }

        public DialogCollectionSetOptionsBuilder<TValue> HasValue(TValue value)
        {
            Set.PreValue = value;
            return this;
        }

        public DialogCollectionSetOptionsBuilder<TValue> HasName(string name)
        {
            Set.Name = name;
            return this;
        }

        public DialogCollectionSetOptionsBuilder<TValue> AsFullRow()
        {
            Set.FullRow = true;
            return this;
        }

        public DialogCollectionSetOptionsBuilder<TValue> Disabled()
        {
            Set.Enabled = false;
            return this;
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>(TControl control) where TControl : Control
        {
            Set.ControlSpecifiedFromBuilder = true;
            Set.Control = control;
            return new DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue>(Set);
        }

        public DialogCollectionSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>() where TControl : Control, new() => AsControl(new TControl());

        public DialogCollectionSetOptionsBuilder<TValue> HasDataSource(IEnumerable<TValue> value)
        {
            Set.DataSource = (IEnumerable<object>)value;
            return this;
        }
    }
}
