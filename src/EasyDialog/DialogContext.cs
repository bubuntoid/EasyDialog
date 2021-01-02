using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal;

namespace bubuntoid.EasyDialog
{
    public abstract class DialogContext
    {
        private IEasyDialogForm dialogForm;
        private IEnumerable<BaseDialogItem> dialogItems;

        private bool isInitialized;

        public DialogContext()
        {
            isInitialized = false;
        }

        public void ShowDialog()
        {
            if (!isInitialized)
                OnConfiguringInternal();

            dialogForm.ShowDialog();
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