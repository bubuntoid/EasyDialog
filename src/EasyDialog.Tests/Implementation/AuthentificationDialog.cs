using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class AuthentificationDialog : DialogContext
    {
        public TextBoxItem Username { get; set; }
        public TextBoxItem Password { get; set; }
        public CheckBoxItem Robot { get; set; }

        protected override void OnConfiguring(DialogContextOptionsBuilder builder)
        {
            builder.UseMaterialStyle(MaterialTheme.Light, MaterialColorScheme.Default)
                .WithTitle("Authentification")
                .WithButton("Sign in");

            builder.ConfigureItems<AuthentificationDialog>(options =>
            {
                options.Property(x => x.Password)
                    .UsePasswordChar();

                options.Property(x => x.Robot)
                    .HasName("I`m not a robot");
            });
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($@"Login: {Username.Value} Password: {Password.Value}");
        }
    }
}
