# EasyDialog
EasyDialog is a framework that automatically creates UI dialogs with easy control extendability and Entity Framework's DbContext declaration style.

<p align="center">
  <img src="https://github.com/bubuntoid/EasyDialog/raw/base-architecture/assets/Screenshot.png" alt="Sublime's custom image"/>
</p>

```csharp
using bubuntoid.EasyDialog;

public class AuthentificationDialog : DialogContext
{
    public TextBoxItem Username { get; set; }
    public TextBoxItem Password { get; set; }
    public CheckBoxItem Robot { get; set; }

    protected override void OnConfiguring(DialogContextOptionsBuilder builder)
    {
        builder.UseStyle(DialogStyle.Material)
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
```

## Dependencies
- System.Windows.Forms 4.0.0.0
- [MetroFramework](https://github.com/thielj/MetroFramework) 1.2.0.3
- [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) 0.2.1
