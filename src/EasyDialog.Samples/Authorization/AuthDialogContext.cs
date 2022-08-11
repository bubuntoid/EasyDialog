using bubuntoid.EasyDialog;
using System.Windows.Forms;

namespace EasyDialog.Samples.Authorization;

public class AuthDialogContext : DialogContext<AuthDialogContext>
{
    public DialogSet<string> Username { get; set; }
    public DialogSet<string> Password { get; set; }
    public DialogSet<bool> Robot { get; set; }

    protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<AuthDialogContext> builder)
    {
        builder.UseMetroStyle()
            .HasTitle("Authentification")
            .HasButton("Sign in")
            .HasWidth(400);

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