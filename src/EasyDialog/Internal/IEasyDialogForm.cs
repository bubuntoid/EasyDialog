using System.Collections.Generic;

namespace bubuntoid.EasyDialog.Internal
{
    internal interface IEasyDialogForm
    {
        DialogContext Context { get; set; }

        string Title { get; set; }
        string ButtonText { get; set; }

        void ShowDialog();
        void Close();

        void SetItems(IEnumerable<BaseDialogItem> items);
    }
}
