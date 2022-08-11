using System.Drawing;
using bubuntoid.EasyDialog;

namespace EasyDialog.Samples.Basics;

public class DialogWithBasicSupportedTypes2 : DialogContext<DialogWithBasicSupportedTypes2>
{
    public DialogSet<string> FolderBrowserDialog { get; set; }
      
    protected override void OnButtonClick()
    {
            
    }

    protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<DialogWithBasicSupportedTypes2> builder)
    {
        builder.HasTitle("Supported types sample #2")
            .HasNoButton();

        builder.Item(s => s.FolderBrowserDialog)
            .HasName("Path", ContentAlignment.MiddleCenter)
            .AsFolderBrowserDialog()
            .HasValue("C:\\")
            .OnFolderSelected(path =>
            {
                Close();
            })
            .AsFullRow();
    }
}