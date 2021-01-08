using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DateTimePickerItem : DialogItem<DateTimePicker, DateTime>
    {
        public override DateTimePicker Control { get; set; } = new DateTimePicker();

        public override DateTime Value
        {
            get => Control.Value;
            set => Control.Value = value;
        }
    }
}
