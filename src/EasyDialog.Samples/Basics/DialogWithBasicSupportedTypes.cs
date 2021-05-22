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
        public DialogSet<string> StringLabel { get; set; }
        public DialogSet<string> Multiline { get; set; }

        public DialogSet<int> Int { get; set; }
        public DialogSet<decimal> Decimal { get; set; }
        public DialogSet<float> Float { get; set; }
        public DialogSet<double> Double { get; set; }

        public DialogSet<bool> Bool { get; set; }
        public DialogSet<DateTime> DateTime { get; set; }
        public DialogSet<TimeSpan> TimeSpan { get; set; }

        public DialogCollectionSet<string> ComboBox { get; set; }
        public DialogCollectionSet<string> ListBox { get; set; }
        
        public DialogSet<string> FullRow { get; set; }

        protected override void OnButtonClick()
        {
            
        }

        protected override void OnConfiguring(DialogContextConfigureOptionsBuilder<DialogWithBasicSupportedTypes> builder)
        {
            builder.HasTitle("Supported types sample");

            builder.Item(x => x.FullRow)
                .PlaceSeparatorBefore(SeparatorStyle.Line)
                .AsTextBox()
                .AsFullRow()
                .HasValue("Full row");

            builder.Item(x => x.Disabled)
                .Disabled();

            builder.Item(x => x.Multiline)
                .AsTextBox()
                .IsMultiline();

            builder.Item(x => x.StringLabel)
                .AsLabel()
                .HasText("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod " +
                         "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, " +
                         "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ")
                .HasHeight(50);

            builder.Item(x => x.ComboBox)
                .PlaceSeparatorBefore(SeparatorStyle.Line)
                .HasDataSource(new[] { "First", "Second", "Third" })
                .HasValue("First");

            builder.Item(x => x.ListBox)
                .AsListBox()
                .HasDataSource(new[] { "Third", "First", "Second" })
                .HasValue("Third");

            builder.Item(x => x.Int)
                .PlaceSeparatorBefore(SeparatorStyle.Line)
                .AsNumericUpDown()
                .HasDecimalPlaces(0)
                .HasMaximum(int.MaxValue)
                .HasMinimum(int.MinValue)
                .HasValue(0);

            builder.Item(x => x.DateTime)
                .AsDateTimePicker()
                .HasFormat(DateTimePickerFormat.Long)
                .HasMaximumDate(System.DateTime.MaxValue)
                .HasMinimumDate(System.DateTime.MinValue);

            builder.Item(x => x.Bool)
                .PlaceSeparatorBefore(SeparatorStyle.Line);
        }
    }
}
