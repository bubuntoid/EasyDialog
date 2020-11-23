using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EasyDialog.Tests.Implementation.CustomDialogItems;
using EasyDialog.Tests.Models;

namespace EasyDialog.Tests.Implementation
{
    public class EditClientDialog : DialogContext
    {
        public TextBoxItem ClientId { get; set; }
        public TextBoxItem FirstName { get; set; }
        public TextBoxItem LastName { get; set; }
        public ComboBoxItem Sex { get; set; }
        public DateTimePickerItem BirthDate { get; set; }
        public CheckBoxItem PerformanceArtist { get; set; }
        public NumericUpDownItem HighLoadsCount { get; set; }
        public DialogButtonItem File { get; set; }

        private readonly Client client;

        public EditClientDialog(Client client)
        {
            this.client = client;
        }

        protected override void OnConfiguring(DialogContextOptionsBuilder builder)
        {
            builder.UseStyle(DialogStyle.Material)
                .WithTitle($"Edit client #{client.Id}")
                .WithButton("Save");

            builder.PropertyOf<EditClientDialog>(x => x.ClientId)
                .HasName("Client id")
                .HasValue(client.Id.ToString())
                .IsEnabled(false);

            builder.PropertyOf<EditClientDialog>(x => x.FirstName)
                .HasName("First name")
                .HasValue(client.FirstName);

            builder.PropertyOf<EditClientDialog>(x => x.LastName)
                .HasName("Second name")
                .HasValue(client.LastName);

            builder.PropertyOf<EditClientDialog>(x => x.BirthDate)
                .HasName("Birth date")
                .HasValue(client.BirthDate);

            builder.PropertyOf<EditClientDialog>(x => x.PerformanceArtist)
                .HasName("Performance artist")
                .HasValue(client.IsPerformanceArtist);

            builder.PropertyOf<EditClientDialog>(x => x.HighLoadsCount)
                .HasName("High loads count")
                .HasValue(client.HighLoadsCount);

            var genders = new List<string> {Models.Sex.Male.ToString(), Models.Sex.Female.ToString()};

            builder.PropertyOf<EditClientDialog>(x => x.Sex)
                .HasDataSource(genders)
                .HasValue(genders[0]);
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($@"Client #{ClientId.Value} ({FirstName.Value} {LastName.Value}) successively saved!");
            Close();
        }
    }
}
