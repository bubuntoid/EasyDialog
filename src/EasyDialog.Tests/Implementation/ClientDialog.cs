using System;
using System.Collections.Generic;
using bubuntoid.EasyDialog.Tests.Models;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class ClientDialog : DialogContext<ClientDialog>
    {
        public TextBoxItem ClientId { get; set; }
        public TextBoxItem FirstName { get; set; }
        public TextBoxItem LastName { get; set; }
        public TextBoxItem MiddleName { get; set; }
        public ListBoxItem Sex { get; set; }
        public DateTimePickerItem BirthDate { get; set; }
        public CheckBoxItem PerformanceArtist { get; set; }
        public CheckBoxItem FuckingSlave { get; set; }
        public CheckBoxItem Boss { get; set; }
        public NumericUpDownItem HighLoadsCount { get; set; }

        private readonly Client client;
        private readonly MetroTheme theme;

        public ClientDialog(Client client, MetroTheme theme = MetroTheme.Default)
        {
            this.client = client;
            this.theme = theme;
        }

        protected override void OnConfiguring(DialogContextOptionsBuilder<ClientDialog> builder)
        {
            var title = client == null ? "Create a new client" : $"Edit client #{client.Id}";
            var button = client == null ? "Add" : "Save";

            builder.UseMetroStyle(theme)
                .WithTitle(title)
                .WithButton(button);

            builder.Property(x => x.ClientId)
                .HasName("Client id")
                .HasValue(client?.Id.ToString() ?? string.Empty)
                .IsEnabled(false);

            builder.Property(x => x.FirstName)
                .HasName("First name")
                .HasValue(client?.FirstName);

            builder.Property(x => x.LastName)
                .HasName("Second name")
                .HasValue(client?.LastName);

            builder.Property(x => x.MiddleName)
                .HasName("Middle name")
                .HasValue(client?.MiddleName);

            builder.Property(x => x.BirthDate)
                .HasName("Birth date")
                .HasValue(client?.BirthDate ?? DateTime.Today);

            builder.Property(x => x.PerformanceArtist)
                .HasName("Performance artist")
                .HasValue(client?.IsPerformanceArtist ?? false);

            builder.Property(x => x.FuckingSlave)
                .HasName("Fucking slave")
                .HasValue(client?.Slave ?? false);

            builder.Property(x => x.Boss)
                .HasName("Boss of the gym")
                .HasValue(client?.Boss ?? false);

            builder.Property(x => x.HighLoadsCount)
                .HasName("High loads count")
                .HasValue(client?.HighLoadsCount ?? 0)
                .Ignore();

            var genders = new List<string> { Models.Sex.Male.ToString(), Models.Sex.Female.ToString() };
            builder.Property(x => x.Sex)
                .HasDataSource(genders)
                .HasValue(genders[0]);
        }

        protected override void OnButtonClick()
        {
            Close();
        }
    }
}
