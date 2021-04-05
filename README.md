# EasyDialog
EasyDialog is a framework that automatically creates UI dialogs with easy control extendability and Entity Framework's DbContext declaration style.

<p align="center">
  <img src="https://github.com/bubuntoid/EasyDialog/raw/main/assets/Screenshot_0.png" alt="Sublime's custom image"/>
</p>

## Nuget
https://www.nuget.org/packages/bubuntoid.EasyDialog

## Sample
```csharp
using bubuntoid.EasyDialog;

public class AuthDialog : DialogContext<AuthDialog>
{
    public DialogSet<string> Username { get; set; }
    public DialogSet<string> Password { get; set; }
    public DialogSet<bool> Robot { get; set; }

    protected override void OnConfiguring(DialogContextOptionsBuilder<AuthDialog> builder)
    {
        builder.UseMaterialStyle()
            .WithTitle("Authentification")
            .WithButton("Sign in");

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
```

Dialogs that was used in preview:
- [File dialog](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog.Tests/Implementation/UploadFileDialog.cs)
- [Client dialog](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog.Tests/Implementation/ClientDialog.cs)
- [Auth dialog](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog.Tests/Implementation/AuthentificationDialog.cs)



## Items
Supported types that are available out of the box:
- `DialogSet<string>` -> TextBox
- `DialogSet<int>` -> NumericUpDown (also work with `decimal`, `float` and `double`)
- `DialogSet<bool>` -> CheckBox
- `DialogSet<DateTime>` -> DateTimePicker
- `DialogCollectionSet<string>` -> ComboBox or ListBox

### Configuration
For using your own control or type as set you have to specify **control**, **getter**, **setter**, and **update items event** in case that you using **DialogCollectionSet**. There a little sample for **TimeSpan** type (which actually could be easier to get by using `.AsDateTimePicker()`):
```csharp
public DialogSet<TimeSpan> Time { get; set; }

protected override void OnConfiguring(DialogContextOptionsBuilder<YourDialogContext> builder)
{
    builder.Item(x => x.Time)
        .AsControl<TextBox>()
        .ConfigureGetter((control) => TimeSpan.Parse(control.Text))
        .ConfigureSetter((control, value) => control.Text = value.ToString())
}
```

There is just a little thing you should know: if your control's height is not "one row" default size, you have to override **ControlHeight** property or configure it in your **DialogContext**:

```csharp
protected override void OnConfiguring(DialogContextOptionsBuilder<YourDialogContext> builder)
{
    builder.Item(x => x.PropertyName)
        .HasHeight(value);
}
```

## Themes
Material style has only two themes - Dark and Light, but it also supports color schemes, for using them you can use constant schemes from **MaterialColorScheme**:
```csharp
builder.UseMaterialStyle(MaterialTheme.Light, MaterialColorScheme.Indigo)
```
Or create your own, there is tons of available colors [here](https://github.com/bubuntoid/EasyDialog/blob/main/src/EasyDialog/Enums/MaterialThemePrimaryColor.cs):
```csharp
var scheme = new MaterialColorScheme()
{
    Primary = MaterialThemePrimaryColor.BlueGrey800,
    DarkPrimary = MaterialThemePrimaryColor.BlueGrey900,
    LightPrimary = MaterialThemePrimaryColor.BlueGrey500,
    Accent = MaterialThemeAccent.LightBlue200,
    TextShade = MaterialThemeTextShade.White,
};

builder.UseMaterialStyle(MaterialTheme.Dark, scheme)
```

## Dependencies
- System.Windows.Forms 4.0.0.0
- [MetroFramework](https://github.com/thielj/MetroFramework) 1.2.0.3
- [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) 0.2.1
