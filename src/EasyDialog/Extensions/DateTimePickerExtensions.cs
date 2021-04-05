using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class DateTimePickerExtensions
    {
        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> AsDateTimePicker(this DialogSetOptionsBuilder<DateTime> builder) =>
            builder.AsControl<DateTimePicker>()
                .ConfigureGetter((control) => control.Value)
                .ConfigureSetter((control, value) => control.Value = value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, TimeSpan> AsDateTimePicker(this DialogSetOptionsBuilder<TimeSpan> builder) =>
          builder.AsControl<DateTimePicker>()
              .UseTemplate(new DateTimePicker { Format = DateTimePickerFormat.Time })
              .ConfigureGetter((control) => control.Value.TimeOfDay)
              .ConfigureSetter((control, value) => control.Value = new DateTime() + value);

        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> HasMaximumDate
            (this DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> builder, DateTime value)
        {
            var control = builder.Set.Control as DateTimePicker;
            control.MaxDate = value;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> HasMinimumDate
          (this DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> builder, DateTime value)
        {
            var control = builder.Set.Control as DateTimePicker;
            control.MinDate = value;
            return builder;
        }

        public static DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> HasFormat
         (this DialogSetOptionsWithSpecifiedControlBuilder<DateTimePicker, DateTime> builder, DateTimePickerFormat format)
        {
            var control = builder.Set.Control as DateTimePicker;
            control.Format = format;
            return builder;
        }
    }
}
