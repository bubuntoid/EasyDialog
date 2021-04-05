using bubuntoid.EasyDialog;
using System.Windows.Forms;

namespace EasyDialog.Samples.Authorization
{
    public class AuthDialog : DialogContext<AuthDialog>
    {
        public DialogSet<string> Username { get; set; }
        public DialogSet<string> Password { get; set; }
        public DialogSet<bool> Robot { get; set; }

        protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<AuthDialog> builder)
        {
            builder.UseMaterialStyle()
                .HasTitle("Authentification")
                .HasButton("Sign in");

            builder.Item(x => x.Password)
                .AsTextBox()
                .UsePasswordChar();

            builder.Item(x => x.Robot)
                .HasName("I`m not a robot");
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($@"Login: {Username.Value} Password: {Password.Value}");
            this.Close();
        }
    }
}