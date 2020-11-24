using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class NumericUpDownItemOptionsBuilder : DialogItemOptionsBuilder
    {
        public NumericUpDownItemOptionsBuilder(BaseDialogItem item) : base(item) { }

        public NumericUpDownItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public NumericUpDownItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }

        public NumericUpDownItemOptionsBuilder HasMinimum(decimal value)
        {
            var control = (item.Control as NumericUpDown);
            control.Minimum = value;
            return this;
        }

        public NumericUpDownItemOptionsBuilder HasMaximum(decimal value)
        {
            var control = (item.Control as NumericUpDown);
            control.Maximum = value;
            return this;
        }

        public NumericUpDownItemOptionsBuilder HasValue(decimal value)
        {
            var control = (item.Control as NumericUpDown);
            control.Value = value;
            return this;
        }
    }
}
