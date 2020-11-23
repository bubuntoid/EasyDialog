using System.Collections.Generic;

namespace EasyDialog.Internal.Forms.Interfaces
{
    internal interface IDialogForm
    {
        DialogContext Context { get; set; }

        string Title { get; set; }
        string ButtonText { get; set; }

        void Show();
        void Close();

        void SetItems(IEnumerable<BaseDialogItem> items);
    }
}
