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
            Item.Data.ControlSpecifiedFromBuilder = true;
            Item.Data.Control = control;
            return new DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue>(Item);
        }

        public DialogSetOptionsWithSpecifiedControlBuilder<TControl, TValue> AsControl<TControl>() where TControl : Control, new() => AsControl(new TControl());
    }
}
