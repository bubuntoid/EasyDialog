using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogSetOptionsBuilder<TValue>
    {
        internal readonly IDialogSet Set;

        public DialogSetOptionsBuilder(IDialogSet set)
        {
            Set = set;
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>(TControl control) where TControl : Control
        {
            Set.ControlSpecifiedFromBuilder = true;
            Set.Control = control;
            return new DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue>(Set);
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>() where TControl : Control, new() => AsControl(new TControl());

        public DialogSetOptionsBuilder<TValue> Ignore()
        {
            Set.Ignore = true;
            return this;
        }

        public DialogSetOptionsBuilder<TValue> HasValue(TValue value)
        {
            Set.PreValue = value;
            return this;
        }

        public DialogSetOptionsBuilder<TValue> AsListBox()
        {
            // todo: implement
            return this;
        }

        public DialogSetOptionsBuilder<TValue> AsComboBox()
        {
            // todo: implement
            return this;
        }
    }
}
