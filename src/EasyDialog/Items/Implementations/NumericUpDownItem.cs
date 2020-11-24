using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class NumericUpDownItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new NumericUpDown();

        public decimal Value
        {
            get => ((NumericUpDown) Control).Value;
            set => ((NumericUpDown) Control).Value = value;
        }
    }
}
