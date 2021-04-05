using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog
{
    public interface IDialogContextConfigureOptionsBuilder
    {
        internal IEnumerable<IDialogSet> Items { get; set; }
        
        internal string Title { get; set; }
        internal string ButtonText { get; set; }

        internal DialogStyle DialogStyle { get; set; }
        internal FormStartPosition StartPosition { get; set; }
        internal ButtonAlign ButtonAlign { get; set; }
        internal MetroTheme MetroTheme { get; set; }

        internal Action OnShownEvent { get; set; }

        internal MaterialTheme MaterialTheme { get; set; }
        internal MaterialColorScheme MaterialColorScheme { get; set; }
    }
}
