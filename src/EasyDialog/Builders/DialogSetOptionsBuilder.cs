using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogSetOptionsBuilder<TValue> : DialogSetOptionsBuilderBase<DialogSetOptionsBuilder<TValue>, TValue>
    {
        internal DialogSetOptionsBuilder(IDialogSet set) : base(set)
        {

        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>(TControl control) where TControl : Control
        {
            Set.ControlSpecifiedFromBuilder = true;
            Set.Control = control;
            return new DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue>(Set);
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>() where TControl : Control, new() => AsControl(new TControl());
    }
}
