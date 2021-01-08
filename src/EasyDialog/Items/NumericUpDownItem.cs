using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class NumericUpDownItem : DialogItem<NumericUpDown, decimal>
    {
        public override NumericUpDown Control { get; set; } = new NumericUpDown();

        public override decimal Value
        {
            get => Control.Value;
            set => Control.Value = value;
        }
    }
}
