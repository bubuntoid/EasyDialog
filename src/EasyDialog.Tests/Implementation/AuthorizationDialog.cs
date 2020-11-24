using System.Windows.Forms;

namespace EasyDialog.Tests.Implementation
{
    public class AuthorizationDialog : DialogContext
    {
        public TextBoxItem Username { get; set; }
        public TextBoxItem Password { get; set; }

        protected override void OnConfiguring(DialogContextOptionsBuilder builder)
        {
            builder.UseStyle(DialogStyle.Metro)
                .WithTitle("Authorization")
                .WithButton("Sign in");

            builder.ConfigureItems<AuthorizationDialog>(options =>
            {
                options.Property(x => x.Password)
                    .UsePasswordChar();
            });
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($@"Login: {Username.Value} Password: {Password.Value}");
        }
    }
}
