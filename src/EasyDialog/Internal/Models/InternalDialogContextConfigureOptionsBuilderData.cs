using System;
using System.Windows.Forms;
using System.Collections.Generic;
using bubuntoid.EasyDialog.Internal.Providers;

namespace bubuntoid.EasyDialog.Internal.Models
{
    internal class InternalDialogContextConfigureOptionsBuilderData
    {
        public IEnumerable<IDialogSet> Items { get; set; }

        public string Title { get; set; }
        public string ButtonText { get; set; }
        
        public FormStartPosition StartPosition { get; set; }
        public ButtonAlign ButtonAlign { get; set; }

        public Action OnShownEvent { get; set; }
        
        public IFormProvider FormProvider { get; set; }
        public int? Width { get; set; }

        internal InternalDialogContextConfigureOptionsBuilderData()
        {
            // Defaults

            ButtonText = "Submit";
            ButtonAlign = ButtonAlign.Right;
            
            StartPosition = FormStartPosition.CenterScreen;

            FormProvider = new DefaultFormProvider();
        }
    }
}
