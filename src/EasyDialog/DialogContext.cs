using System.Collections.Generic;

using EasyDialog.Internal.Forms;
using EasyDialog.Internal.Items;
using EasyDialog.Internal.Forms.Interfaces;

namespace EasyDialog
{
    public abstract class DialogContext
    {
        private IEnumerable<BaseDialogItem> dialogItems;
        private IDialogForm dialogForm;

        private bool isInitialized;

        public DialogContext()
        {
            isInitialized = false;
        }

        public void Show()
        {
            if (!isInitialized)
                OnConfiguringInternal();

            dialogForm.Show();
        }

        protected void Close()
        {
            dialogForm.Close();
        }

        private void OnConfiguringInternal()
        {
            dialogItems = new DialogContextItemsLoader(this).GetFromProperties();

            var options = new DialogContextOptionsBuilder(dialogItems);
            OnConfiguring(options);

            dialogForm = new DialogContextFormLoader(this).Load(options, dialogItems);

            isInitialized = true;
        }

        protected virtual void OnConfiguring(DialogContextOptionsBuilder builder)
        {

        }

        protected internal virtual void OnButtonClick()
        {

        }
    }
}