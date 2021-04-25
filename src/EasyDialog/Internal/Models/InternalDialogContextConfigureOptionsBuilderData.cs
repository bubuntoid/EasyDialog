using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog.Internal.Models
{
    internal class InternalDialogContextConfigureOptionsBuilderData
    {
        public IEnumerable<IDialogSet> Items { get; set; }

        public string Title { get; set; }
        public string ButtonText { get; set; }
        
        public DialogStyle DialogStyle { get; set; }
        public FormStartPosition StartPosition { get; set; }
        public ButtonAlign ButtonAlign { get; set; }
        public MetroTheme MetroTheme { get; set; }
        
        public Action OnShownEvent { get; set; }
        
        public MaterialTheme MaterialTheme { get; set; }
        public MaterialColorScheme MaterialColorScheme { get; set; }

        public InternalDialogContextConfigureOptionsBuilderData()
        {
            // Defaults

            ButtonText = "Submit";
            ButtonAlign = ButtonAlign.Right;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
