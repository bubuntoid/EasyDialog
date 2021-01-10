using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class AuthentificationDialog : DialogContext<AuthentificationDialog>
    {
        public TextBoxItem Username { get; set; }
        public TextBoxItem Password { get; set; }
        public CheckBoxItem Robot { get; set; }

        protected override void OnConfiguring(DialogContextOptionsBuilder<AuthentificationDialog> builder)
        {
            builder.UseMaterialStyle(MaterialTheme.Light, MaterialColorScheme.Default)
                .WithTitle("Authentification")
                .WithButton("Sign in", ButtonAlign.FullRow);

            builder.Item(x => x.Password)
                .UsePasswordChar();

            builder.Item(x => x.Robot)
                .HasName("I`m not a robot");
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($@"Login: {Username.Value} Password: {Password.Value}");
        }

        protected override void OnClose()
        {
            MessageBox.Show("Closing!");
        }
    }
}
