using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public static class DateTimePickerItemBuilderExtensions
    {
        public static ItemOptionsBuilder<DateTimePickerItem> HasValue(this ItemOptionsBuilder<DateTimePickerItem> builder, DateTime value)
        {
            var control = GetControl(builder);
            control.Value = value;

            return builder;
        }

        public static ItemOptionsBuilder<DateTimePickerItem> HasMaximumDate(this ItemOptionsBuilder<DateTimePickerItem> builder, DateTime value)
        {
            var control = GetControl(builder);
            control.MaxDate = value;

            return builder;
        }

        public static ItemOptionsBuilder<DateTimePickerItem> HasMinimumDate(this ItemOptionsBuilder<DateTimePickerItem> builder, DateTime value)
        {
            var control = GetControl(builder);
            control.MinDate = value;

            return builder;
        }

        private static DateTimePicker GetControl(ItemOptionsBuilder<DateTimePickerItem> builder) => (DateTimePicker)builder.Item.BaseControl;
    }
}
