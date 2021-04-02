using bubuntoid.EasyDialog;
using System.Windows.Forms;

namespace EasyDialog.Samples.Authorization
{
    public class AuthDialogContext : DialogContext<AuthDialogContext>
    {
        public DialogSet<string> Username { get; set; }
        public DialogSet<string> Password { get; set; }

        protected override void OnConfigure(DialogContextConfigureOptionsBuilder<AuthDialogContext> builder)
        {
            builder.UseMetroStyle()
                .HasTitle("Authorization")
                .HasButton("Sign In", ButtonAlign.Right);

            builder.Item(x => x.Password)
                .AsTextBox()
                .UsePasswordChar('*');
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($"Username: {Username.Value}, Password: {Password.Value}");
        }
    }
}
