using bubuntoid.EasyDialog;
using System;
using System.Windows.Forms;

namespace EasyDialog.Samples.CustomType
{
    public class TimeSpanTypeDialogContext : DialogContext<TimeSpanTypeDialogContext>
    {
        public DialogSet<TimeSpan> Time { get; set; }

        protected override void OnButtonClick()
        {

        }

        protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<TimeSpanTypeDialogContext> builder)
        {
            builder.HasTitle("Custom type sample");

            builder.Item(x => x.Time)
                .AsControl<TextBox>()
                .ConfigureGetter((control) => TimeSpan.Parse(control.Text))
                .ConfigureSetter((control, value) => control.Text = value.ToString());
        }
    }
}
