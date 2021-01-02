using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal;

namespace bubuntoid.EasyDialog
{
    public abstract class DialogContext<TContext> 
        where TContext : DialogContext<TContext>
    {
        private IEasyDialogForm<TContext> dialogForm;
        private IEnumerable<BaseDialogItem> dialogItems;

        private bool isInitialized;

        public DialogContext()
        {
            isInitialized = false;
        }

        public void ShowDialog()
        {
            if (isInitialized == false)
            {
                dialogItems = new DialogContextItemsLoader<TContext>(this).GetFromProperties();

                var options = new DialogContextOptionsBuilder<TContext>(dialogItems);
                OnConfiguring(options);

                dialogForm = new DialogContextFormLoader<TContext>(this).Load(options, dialogItems);

                isInitialized = true;
            }

            dialogForm.ShowDialog();
        }

        public void Close()
        {
            dialogForm.Close();
        }

        protected internal virtual void OnClose() { }

        protected internal abstract void OnButtonClick();

        protected abstract void OnConfiguring(DialogContextOptionsBuilder<TContext> builder);
    }
}