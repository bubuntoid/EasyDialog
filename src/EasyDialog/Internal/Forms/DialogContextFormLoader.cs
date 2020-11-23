using System;
using System.Collections.Generic;

using EasyDialog.Internal.Forms.Interfaces;
using EasyDialog.Internal.Forms.Implementations;

namespace EasyDialog.Internal.Forms
{
    internal class DialogContextFormLoader
    {
        private readonly DialogContext context;

        public DialogContextFormLoader(DialogContext context)
        {
            this.context = context;
        }

        public IDialogForm Load(DialogContextOptionsBuilder builder, IEnumerable<BaseDialogItem> items)
        {
            IDialogForm result;

            switch (builder.Style)
            {
                case DialogStyle.Default: 
                    result = new DefaultDialogForm();
                    break;

                case DialogStyle.Metro:
                    result = new MetroDialogForm(builder.MetroTheme);
                    break;

                case DialogStyle.Material:
                    result = new MaterialDialogForm();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(builder.Style), builder.Style, null);
            }

            result.Context = context;
            result.ButtonText = builder.ButtonText;
            result.Title = builder.Title;
            result.SetItems(items);

            return result;
        }
    }
}
