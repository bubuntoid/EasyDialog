using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class NumericUpDownExtensions
    {
        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, int> AsNumericUpDown(this DialogSetOptionsBuilder<int> builder) =>
            builder.AsControl<NumericUpDown>()
                .ConfigureGetter((control) => Convert.ToInt32(control.Value))
                .ConfigureSetter((control, value) => control.Value = value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, decimal> AsNumericUpDown(this DialogSetOptionsBuilder<decimal> builder) =>
            builder.AsControl<NumericUpDown>()
                .ConfigureGetter((control) => control.Value)
                .ConfigureSetter((control, value) => control.Value = value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, float> AsNumericUpDown(this DialogSetOptionsBuilder<float> builder) =>
          builder.AsControl<NumericUpDown>()
              .ConfigureGetter((control) => (float)control.Value)
              .ConfigureSetter((control, value) => control.Value = (decimal)value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, double> AsNumericUpDown(this DialogSetOptionsBuilder<double> builder) =>
        builder.AsControl<NumericUpDown>()
            .ConfigureGetter((control) => Convert.ToDouble(control.Value))
            .ConfigureSetter((control, value) => control.Value = (decimal)value);


        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> HasMaximum<TValue>
           (this DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> builder, decimal value)
        {
            var control = builder.Item.Data.Control as NumericUpDown;
            control.Maximum = value;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> HasMinimum<TValue>
          (this DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> builder, decimal value)
        {
            var control = builder.Item.Data.Control as NumericUpDown;
            control.Minimum = value;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> HasDecimalPlaces<TValue>
           (this DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> builder, int value)
        {
            var control = builder.Item.Data.Control as NumericUpDown;
            control.DecimalPlaces = value;
            return builder;
        }
    }
}
