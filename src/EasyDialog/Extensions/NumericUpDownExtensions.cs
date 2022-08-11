using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog;

public static class NumericUpDownExtensions
{
    /// <summary>
    /// Sets DialogSet<int> control as NumericUpDown
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, int> AsNumericUpDown(this DialogSetOptionsBuilder<int> builder) =>
        builder.AsControl<NumericUpDown>()
            .ConfigureGetter((control) => Convert.ToInt32(control.Value))
            .ConfigureSetter((control, value) => control.Value = value);

    /// <summary>
    /// Sets DialogSet<decimal> control as NumericUpDown
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, decimal> AsNumericUpDown(this DialogSetOptionsBuilder<decimal> builder) =>
        builder.AsControl<NumericUpDown>()
            .ConfigureGetter((control) => control.Value)
            .ConfigureSetter((control, value) => control.Value = value);

    /// <summary>
    /// Sets DialogSet<float> control as NumericUpDown
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, float> AsNumericUpDown(this DialogSetOptionsBuilder<float> builder) =>
        builder.AsControl<NumericUpDown>()
            .ConfigureGetter((control) => (float)control.Value)
            .ConfigureSetter((control, value) => control.Value = (decimal)value);

    /// <summary>
    /// Sets DialogSet<double> control as NumericUpDown
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, double> AsNumericUpDown(this DialogSetOptionsBuilder<double> builder) =>
        builder.AsControl<NumericUpDown>()
            .ConfigureGetter((control) => Convert.ToDouble(control.Value))
            .ConfigureSetter((control, value) => control.Value = (decimal)value);

    /// <summary>
    /// Sets Maximum value of NumericUpDown control
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> HasMaximum<TValue>
        (this DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> builder, decimal value)
    {
        var control = builder.Item.Data.Control as NumericUpDown;
        control!.Maximum = value;
        return builder;
    }

    /// <summary>
    /// Sets Minimum value of NumericUpDown control
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> HasMinimum<TValue>
        (this DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> builder, decimal value)
    {
        var control = builder.Item.Data.Control as NumericUpDown;
        control!.Minimum = value;
        return builder;
    }

    /// <summary>
    /// Sets DecimalPlaces value of NumericUpDown control
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="builder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> HasDecimalPlaces<TValue>
        (this DialogSetOptionsWithSpecifiedControlBuilder<NumericUpDown, TValue> builder, int value)
    {
        var control = builder.Item.Data.Control as NumericUpDown;
        control!.DecimalPlaces = value;
        return builder;
    }
}