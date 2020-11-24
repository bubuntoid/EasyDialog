using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bubuntoid.EasyDialog.Tests.Implementation.CustomDialogItems;
using bubuntoid.EasyDialog.Tests.Models;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class EditClientDialog : DialogContext
    {
        public TextBoxItem ClientId { get; set; }
        public TextBoxItem FirstName { get; set; }
        public TextBoxItem LastName { get; set; }
        public TextBoxItem MiddleName { get; set; }
        public ComboBoxItem Sex { get; set; }
        public DateTimePickerItem BirthDate { get; set; }
        public CheckBoxItem PerformanceArtist { get; set; }
        public CheckBoxItem FuckingSlave { get; set; }
        public CheckBoxItem Boss { get; set; }
        public NumericUpDownItem HighLoadsCount { get; set; }

        private readonly Client client;

        public EditClientDialog(Client client)
        {
            this.client = client;
        }

        protected override void OnConfiguring(DialogContextOptionsBuilder builder)
        {
            builder.UseStyle(DialogStyle.Metro)
                .WithTitle($"Edit client #{client.Id}")
                .WithButton("Save");

            builder.ConfigureItems<EditClientDialog>(options =>
            {
                options.Property(x => x.ClientId)
                    .HasName("Client id")
                    .HasValue(client.Id.ToString())
                    .IsEnabled(false);

                options.Property(x => x.FirstName)
                    .HasName("First name")
                    .HasValue(client.FirstName);

                options.Property(x => x.LastName)
                    .HasName("Second name")
                    .HasValue(client.LastName);

                options.Property(x => x.MiddleName)
                    .HasName("Middle name")
                    .HasValue(client.MiddleName);

                options.Property(x => x.BirthDate)
                    .HasName("Birth date")
                    .HasValue(client.BirthDate);

                options.Property(x => x.PerformanceArtist)
                    .HasName("Performance artist")
                    .HasValue(client.IsPerformanceArtist);

                options.Property(x => x.FuckingSlave)
                    .HasName("Fucking slave")
                    .HasValue(client.Slave);

                options.Property(x => x.Boss)
                    .HasName("Boss of the gym")
                    .HasValue(client.Boss);

                options.Property(x => x.HighLoadsCount)
                    .HasName("High loads count")
                    .HasValue(client.HighLoadsCount);

                var genders = new List<string> { Models.Sex.Male.ToString(), Models.Sex.Female.ToString() };
                options.Property(x => x.Sex)
                    .HasDataSource(genders)
                    .HasValue(genders[0]);
            });
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($@"Client #{ClientId.Value} ({FirstName.Value} {LastName.Value}) successively saved!");
            Close();
        }
    }
}
