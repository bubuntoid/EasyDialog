using System.Windows.Forms;

using bubuntoid.EasyDialog.Internal;

namespace bubuntoid.EasyDialog
{
    public abstract class DialogContext<TContext> : IDialogContext
        where TContext : DialogContext<TContext>
    {
        void IDialogContext.OnButtonClick() => OnButtonClick();

        private readonly IEasyDialogForm dialogForm;
        private bool isInitialized;

        public Form Form => dialogForm.Form;

        public DialogContext()
        {
            dialogForm = new EasyDialogForm(this);
            isInitialized = false;
        }

        public void ShowDialog()
        {
            if (isInitialized == false)
            {
                var items = new DialogContextItemsLoader(this)
                   .GetFromProperties();

                var options = new DialogContextConfigureOptionsBuilder<TContext>(items);
                OnConfiguring(options);

                dialogForm.Initialize(options);

                isInitialized = true;
            }

            dialogForm.ShowDialog();
        }

        public void Close()
        {
            dialogForm.Close();
        }

        protected abstract void OnConfiguring(DialogContextConfigureOptionsBuilder<TContext> builder);
        protected internal abstract void OnButtonClick();
    }
}