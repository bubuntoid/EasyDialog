using bubuntoid.EasyDialog;
using System.Windows.Forms;

namespace EasyDialog.Samples.CustomControl
{
    public class ButtonControlDialogContext : DialogContext<ButtonControlDialogContext>
    {
        public DialogSet<bool> Switcher { get; set; }

        protected override void OnButtonClick()
        {

        }

        protected override void OnConfigure(DialogContextConfigureOptionsBuilder<ButtonControlDialogContext> builder)
        {
            builder.HasTitle("Custom control sample");

            var template = GetButton();
            builder.Item(x => x.Switcher)
                .HasHeight(template.Height)
                .AsControl(template)
                .ConfigureGetter((control) => control.Text == "On")
                .ConfigureSetter((control, value) => control.Text = value ? "On" : "Off");
        }

        private Button GetButton()
        {
            var result = new Button
            {
                Text = "On",
                Height = 30,
            };

            result.Click += (c, e) =>
            {
                result.Text = result.Text == "On" ? "Off" : "On";
            };

            return result;
        }
    }
}
