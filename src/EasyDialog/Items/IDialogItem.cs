using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public interface IDialogItem<TControl, TValue> where TControl : Control
    {
        TControl Control { get; set; }
        TValue Value { get; set; }
    }
}
