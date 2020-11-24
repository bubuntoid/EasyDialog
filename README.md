# EasyDialog
EasyDialog is a framework that automatically creates UI dialogs with easy control extendability and Entity Framework's DbContext declaration style.
```csharp
using bubuntoid.EasyDialog;

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
```

## Dependencies
- System.Windows.Forms 4.0.0.0
- [MetroFramework](https://github.com/thielj/MetroFramework) 1.2.0.3
- [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) 0.2.1
