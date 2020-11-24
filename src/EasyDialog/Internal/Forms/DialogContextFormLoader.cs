using System;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal.Forms.Interfaces;
using bubuntoid.EasyDialog.Internal.Forms.Implementations;

namespace bubuntoid.EasyDialog.Internal.Forms
{
    internal class DialogContextFormLoader
    {
        private readonly DialogContext context;

        public DialogContextFormLoader(DialogContext context)
        {
            this.context = context;
        }

        public IEasyDialogForm Load(DialogContextOptionsBuilder builder, IEnumerable<BaseDialogItem> items)
        {
            IFormProvider formProvider;

            switch (builder.Style)
            {
                case DialogStyle.Default: 
                    formProvider = new DefaultFormProvider();
                    break;

                case DialogStyle.Metro:
                    formProvider = new MetroFormProvider(builder.MetroTheme);
                    break;

                case DialogStyle.Material:
                    formProvider = new MaterialFormProvider();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(builder.Style), builder.Style, null);
            }

            var form = new EasyDialogForm(formProvider)
            {
                ButtonText = builder.ButtonText,
                Title = builder.Title,
                Context = context
            };
            form.SetItems(items);

            return form;
        }
    }
}
