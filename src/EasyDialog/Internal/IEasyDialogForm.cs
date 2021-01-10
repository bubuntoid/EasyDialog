using System.Collections.Generic;

namespace bubuntoid.EasyDialog.Internal
{
    internal interface IEasyDialogForm<TContext> 
        where TContext : DialogContext<TContext>
    {
        DialogContext<TContext> Context { get; set; }
        ButtonAlign ButtonAlign { get; set; }

        string Title { get; set; }
        string ButtonText { get; set; }

        void ShowDialog();
        void Close();

        void SetItems(IEnumerable<BaseDialogItem> items);
    }
}
