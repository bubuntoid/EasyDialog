using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class DateTimePickerExtensions
    {
        /// <summary>
        /// Configures DialogSet<DateTime> as DateTimePicker
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> AsDateTimePicker(this DialogSetOptionsBuilder<DateTime> builder) =>
            builder.AsControl<DateTimePicker>()
                .ConfigureGetter((control) => control.Value)
                .ConfigureSetter((control, value) => control.Value = value);

        /// <summary>
        /// Configures DialogSet<TimeSpan> as DateTimePicker with Format = DateTimePickerFormat.Time
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, TimeSpan> AsDateTimePicker(this DialogSetOptionsBuilder<TimeSpan> builder) =>
          builder.AsControl<DateTimePicker>()
              .UseTemplate(new DateTimePicker { Format = DateTimePickerFormat.Time })
              .ConfigureGetter((control) => control.Value.TimeOfDay)
              .ConfigureSetter((control, value) => control.Value = new DateTime() + value);

        /// <summary>
        /// Sets MaxDate of DateTimePicker control
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> HasMaximumDate
            (this DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> builder, DateTime value)
        {
            var control = builder.Item.Data.Control as DateTimePicker;
            control.MaxDate = value;
            return builder;
        }

        /// <summary>
        /// Sets MinDate of DateTimePicker control
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> HasMinimumDate
          (this DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> builder, DateTime value)
        {
            var control = builder.Item.Data.Control as DateTimePicker;
            control.MinDate = value;
            return builder;
        }

        /// <summary>
        /// Sets Format of DateTimePicker control
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> HasFormat
         (this DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> builder, DateTimePickerFormat format)
        {
            var control = builder.Item.Data.Control as DateTimePicker;
            control.Format = format;
            return builder;
        }
    }
}
