using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using bubuntoid.EasyDialog;

namespace EasyDialog.Samples.Basics
{
    public class DialogWithBasicSupportedTypes : DialogContext<DialogWithBasicSupportedTypes>
    {
        public DialogSet<string> String { get; set; }
        public DialogSet<string> Disabled { get; set; }
        public DialogSet<string> Multiline { get; set; }

        public DialogSet<int> Int { get; set; }
        public DialogSet<decimal> Decimal { get; set; }
        public DialogSet<float> Float { get; set; }
        public DialogSet<double> Double { get; set; }

        public DialogSet<bool> Bool { get; set; }
        public DialogSet<DateTime> DateTime { get; set; }
        
        public DialogCollectionSet<string> ComboBox { get; set; }
        public DialogCollectionSet<string> ListBox { get; set; }
        
        public DialogSet<string> FullRow { get; set; }

        protected override void OnButtonClick()
        {

        }

        protected override void OnConfigure(DialogContextConfigureOptionsBuilder<DialogWithBasicSupportedTypes> builder)
        {
            builder.HasTitle("Supported types sample");

            builder.Item(x => x.FullRow)
                .AsTextBox()
                .AsFullRow()
                .HasValue("Full row");

            builder.Item(x => x.Disabled)
                .Disabled();

            builder.Item(x => x.Multiline)
              .AsTextBox()
              .IsMultiline();

            builder.Item(x => x.ComboBox)
                .HasDataSource(new[] { "First", "Second", "Third" })
                .HasValue("First");

            builder.Item(x => x.ListBox)
                .AsListBox()
                .HasDataSource(new[] { "Third", "First", "Second" })
                .HasValue("Third");
        }
    }
}
