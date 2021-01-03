using System;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal.Providers;

namespace bubuntoid.EasyDialog.Internal
{
    internal class DialogContextFormLoader<TContext>
        where TContext : DialogContext<TContext>
    {
        private readonly DialogContext<TContext> context;

        public DialogContextFormLoader(DialogContext<TContext> context)
        {
            this.context = context;
        }

        public IEasyDialogForm<TContext> Load(DialogContextOptionsBuilder<TContext> builder, IEnumerable<BaseDialogItem> items)
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
                    formProvider = new MaterialFormProvider(builder.MaterialTheme, builder.MaterialColorScheme);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(builder.Style), builder.Style, null);
            }
            
            formProvider.OnCloseHandler += context.OnClose;
            formProvider.SetStartPosition(builder.StartPosition);

            var form = new EasyDialogForm<TContext>(formProvider)
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
