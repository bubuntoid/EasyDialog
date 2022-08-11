using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Controls;

internal class FolderBrowserDialogButton : Button
{
    internal string Path { get; set; }
   
    internal Action<string> OnFolderSelected { get; set; }
        
    internal static FolderBrowserDialogButton Template
    {
        get
        {
            var instance = new FolderBrowserDialogButton
            {
                Text = "Browse",
            };

            instance.Click += (sender, args) =>
            {
                using var dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = false;
                if (string.IsNullOrWhiteSpace(instance.Path) == false)
                {
                    dialog.InitialDirectory = instance.Path;
                } 

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    instance.Path = dialog.SelectedPath;
                    instance.OnFolderSelected?.Invoke(instance.Path);
                }
            };
                
            return instance;
        }
    }
}