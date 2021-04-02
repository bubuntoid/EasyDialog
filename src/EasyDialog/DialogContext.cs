using bubuntoid.EasyDialog.Internal;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public abstract class DialogContext<TContext> : IDialogContext
        where TContext : DialogContext<TContext>
    {
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
                OnConfigure(options);

                dialogForm.Initialize(options);

                isInitialized = true;
            }

            dialogForm.ShowDialog();
        }

        public void Close()
        {
            dialogForm.Close();
        }

        protected abstract void OnConfigure(DialogContextConfigureOptionsBuilder<TContext> builder);

        void IDialogContext.OnButtonClick() => OnButtonClick();
        protected internal abstract void OnButtonClick();
    }
}