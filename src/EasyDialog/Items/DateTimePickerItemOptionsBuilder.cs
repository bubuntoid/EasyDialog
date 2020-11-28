using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DateTimePickerItemOptionsBuilder : DialogItemOptionsBuilder
    {
        public DateTimePickerItemOptionsBuilder(BaseDialogItem item) : base(item) { }

        public DateTimePickerItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public DateTimePickerItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }

        public DateTimePickerItemOptionsBuilder HasValue(DateTime value)
        {
            var control = (item.Control as DateTimePicker);
            control.Value = value;
            return this;
        }

        public DateTimePickerItemOptionsBuilder HasMinimum(DateTime value)
        {
            var control = (item.Control as DateTimePicker);
            control.MinDate = value;
            return this;
        }

        public DateTimePickerItemOptionsBuilder HasMaximum(DateTime value)
        {
            var control = (item.Control as DateTimePicker);
            control.MaxDate = value;
            return this;
        }

        public DateTimePickerItemOptionsBuilder Ignore()
        {
            item.Ignore = true;
            return this;
        }
    }
}
