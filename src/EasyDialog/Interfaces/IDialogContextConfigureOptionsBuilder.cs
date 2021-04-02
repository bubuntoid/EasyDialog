using System.Collections.Generic;
using System.Windows.Forms;

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
    }
}
