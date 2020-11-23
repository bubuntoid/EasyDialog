using System;
using System.Windows.Forms;

namespace EasyDialog
{
    public class DateTimePickerItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new DateTimePicker();

        public DateTime Value
        {
            get => ((DateTimePicker) Control).Value;
            set => ((DateTimePicker) Control).Value = value;
        }
    }
}
