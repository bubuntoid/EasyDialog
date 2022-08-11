using System;
using bubuntoid.EasyDialog.Internal.Controls;

namespace bubuntoid.EasyDialog;

public static class FolderBrowserDialogExtensions
{
    /// <summary>
    /// Sets DialogSet<string> control as FolderBrowserDialog control. Returned value is a path to selected directory
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static DialogSetOptionsBuilder<string> AsFolderBrowserDialog(this DialogSetOptionsBuilder<string> builder) =>
        builder.AsControl<FolderBrowserDialogButton>()
            .UseTemplate(FolderBrowserDialogButton.Template)
            .ConfigureGetter((control) => control.Path)
            .ConfigureSetter((control, value) => control.Path = value)
            .HasHeight(35);

    /// <summary>
    /// Sets event that will be invoked after folder selection
    /// Works only on FolderBrowserDialog item (use AsFolderBrowserDialog() method)
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static DialogSetOptionsBuilder<string> OnFolderSelected(this DialogSetOptionsBuilder<string> builder, Action<string> action)
    {
        var control = builder.Item.Data.Control as FolderBrowserDialogButton;
        control!.OnFolderSelected = action;
        return builder;
    }
            
}