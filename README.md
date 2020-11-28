# EasyDialog
EasyDialog is a framework that automatically creates UI dialogs with easy control extendability and Entity Framework's DbContext declaration style.

<p align="center">
  <img src="https://github.com/bubuntoid/EasyDialog/raw/master/assets/Screenshot_0.png" alt="Sublime's custom image"/>
</p>

## Nuget
https://www.nuget.org/packages/bubuntoid.EasyDialog

## Sample
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
        this.Close();
    }
}
```

Dialogs that was used in preview:
- [File dialog](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog.Tests/Implementation/UploadFileDialog.cs)
- [Client dialog](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog.Tests/Implementation/ClientDialog.cs)
- [Auth dialog](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog.Tests/Implementation/AuthentificationDialog.cs)

## Items
Base items that available "out of the box":
- TextBoxItem (string)
- NumericUpDownItem (decimal/int)
- CheckBoxItem (bool)
- ComboBoxItem (Collection)
- DateTimePickerItem (DateTime)

You can use your own control as dialog item by inerhiting from BaseDialogItem:
```csharp
public class DialogButtonItem : BaseDialogItem
{
    public override Control Control { get; set; } = new Button() { Text = "Click on me!" };
}
```
There is just a little thing you should know: if your control's height is not "one row" default size, you have to override **ControlHeight** property or configure it in your **DialogContext**:

```csharp
protected override void OnConfiguring(DialogContextOptionsBuilder builder)
{
    builder.ConfigureItems<YourDialog>(options =>
    {
        options.Property(x => x.YourDialogProperty)
            .HasHeight(value);
    });
}
```

## Dependencies
- System.Windows.Forms 4.0.0.0
- [MetroFramework](https://github.com/thielj/MetroFramework) 1.2.0.3
- [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) 0.2.1
