# EasyDialog
EasyDialog is a framework that automatically creates UI dialogs with easy control extendability and Entity Framework's DbContext declaration style.

<p align="center">
  <img src="https://github.com/bubuntoid/EasyDialog/raw/main/assets/5.0.3 preview.png" alt="Sublime's custom image"/>
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
```

More samples [here](https://github.com/bubuntoid/EasyDialog/tree/main/src/EasyDialog.Samples).

## Items
### Basics
There are 2 types of items you may set for your dialog - `DialogSet<TValue>` and `DialogCollectionSet<TValue>`. 
Both of theme has 2 properties: `TValue Value` and `Control control`.

Difference between them is that `DialogCollectionSet<TValue>` besides `TValue Value` property has another one - `IEnumerable<TValue> DataSource` intended for interact collection with control or vice versa and one more action `Action<Control, IEnumearble<TValue>> UpdateItemsEvent` (encapsulated, but may be configured through option builders)

Supported types that are available out of the box:
- `DialogSet<string>` -> TextBox
- `DialogSet<int>` -> NumericUpDown (also work with `decimal`, `float` and `double`)
- `DialogSet<bool>` -> CheckBox
- `DialogSet<DateTime>` -> DateTimePicker
- `DialogCollectionSet<string>` -> ComboBox or ListBox

### Configuration
For specifying custom control or type for your DialogSet<TValue> you have to configure **control**, **getter**, **setter**, and **update items event** in case that you using **DialogCollectionSet**. There a little sample for **TimeSpan** type (which actually could be easier to get by using `.AsDateTimePicker()`):
```csharp
public DialogSet<TimeSpan> Time { get; set; }

protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<YourDialogContext> builder)
{
    builder.Item(x => x.Time)
        .AsControl<TextBox>()
        .ConfigureGetter((control) => TimeSpan.Parse(control.Text))
        .ConfigureSetter((control, value) => control.Text = value.ToString())
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

## Some "Features"
If your control's height is not "one row" default size, you have to configure it explicitically by using `HasHeight(int value)` method:

```csharp
protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<YourDialogContext> builder)
{
    builder.Item(x => x.PropertyName)
        .HasHeight(value);
}
```

For editing state of `IEnumearble<TValue>` (`DialogCollectionSet<TValue>`) you have to override it itself. There a little sample that could change LINQ's `.ToList().Add()` method.

From this:
```csharp
protected override void OnButtonClick()
{
    MyDialogSet.DataSource.ToList().Add(DateTime.Now.TimeOfDay);
}
```
To this:
```csharp
protected override void OnButtonClick()
{
    MyDialogSet.DataSource = MyDialogSet.DataSource.Append(DateTime.Now.TimeOfDay);
}
```

## Dependencies
- net5.0-windows7.0
- [MetroFramework](https://github.com/thielj/MetroFramework) 1.2.0.3
- [MaterialSkin.NET5](https://github.com/bubuntoid/MaterialSkin.NET5) 1.0.0
