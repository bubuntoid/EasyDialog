using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class NumericUpDownItemBuilderExtensions
    {
        public static ItemOptionsBuilder<NumericUpDownItem> HasValue(this ItemOptionsBuilder<NumericUpDownItem> builder, decimal value)
        {
            var control = GetControl(builder);
            control.Value = value;

            return builder;
        }

        public static ItemOptionsBuilder<NumericUpDownItem> HasMaximum(this ItemOptionsBuilder<NumericUpDownItem> builder, decimal value)
        {
            var control = GetControl(builder);
            control.Maximum = value;

            return builder;
        }

        public static ItemOptionsBuilder<NumericUpDownItem> HasMinimum(this ItemOptionsBuilder<NumericUpDownItem> builder, decimal value)
        {
            var control = GetControl(builder);
            control.Minimum = value;

            return builder;
        }

        private static NumericUpDown GetControl(ItemOptionsBuilder<NumericUpDownItem> builder) => (NumericUpDown)builder.Item.BaseControl;
    }
}
