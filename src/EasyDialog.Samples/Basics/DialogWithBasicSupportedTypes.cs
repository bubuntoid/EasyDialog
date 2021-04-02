using System;
using System.Collections;
using System.Windows.Forms;
using bubuntoid.EasyDialog;

namespace EasyDialog.Samples.Basics
{
    public class DialogWithBasicSupportedTypes : DialogContext<DialogWithBasicSupportedTypes>
    {
        public DialogSet<string> String { get; set; }

        public DialogSet<int> Int { get; set; }
        public DialogSet<decimal> Decimal { get; set; }
        public DialogSet<float> Float { get; set; }
        public DialogSet<double> Double { get; set; }

        public DialogSet<bool> Bool { get; set; }
        public DialogSet<DateTime> DateTime { get; set; }
        
        public DialogSet<string> ComboBox { get; set; }
        public DialogSet<string> ListBox { get; set; }

        protected override void OnButtonClick()
        {

        }

        protected override void OnConfigure(DialogContextConfigureOptionsBuilder<DialogWithBasicSupportedTypes> builder)
        {
            builder.HasTitle("Supported types");

            builder.Item(x => x.ComboBox).AsComboBox();
            builder.Item(x => x.ComboBox).AsTextBox();
        }
    }
}
