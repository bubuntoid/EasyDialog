using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public abstract class DialogItem<TControl, TValue> : BaseDialogItem, IDialogItem<TControl, TValue>
        where TControl : Control
    {
        public override Control BaseControl
        {
            get
            {
                return Control;
            }
            set
            {
                Control = (TControl)value;
            }
        }
        
        public abstract TControl Control { get; set; }
        public abstract TValue Value { get; set; }
    }
}
