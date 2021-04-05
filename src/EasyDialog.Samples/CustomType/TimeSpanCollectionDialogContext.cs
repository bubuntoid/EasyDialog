﻿using bubuntoid.EasyDialog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EasyDialog.Samples.CustomType
{
    public class TimeSpanCollectionDialogContext : DialogContext<TimeSpanCollectionDialogContext>
    {
        public DialogCollectionSet<TimeSpan> Times { get; set; }

        protected override void OnButtonClick()
        {
            Times.DataSource = Times.DataSource.Append(DateTime.Now.TimeOfDay);
        }

        protected override void OnConfigure(DialogContextConfigureOptionsBuilder<TimeSpanCollectionDialogContext> builder)
        {
            builder.HasTitle("Custom type collection sample");

            builder.Item(x => x.Times)
                .AsControl<ComboBox>()
                .ConfigureGetter((control) => TimeSpan.Parse(control.Text))
                .ConfigureSetter((control, value) => control.Text = value.ToString())
                .ConfigureUpdateItemsEvent((control, source) =>
                {
                    control.Items.Clear();
                    source.ToList().ForEach(x => control.Items.Add(x));
                })
                .HasDataSource(new[] { TimeSpan.FromHours(1), TimeSpan.FromHours(2), TimeSpan.FromHours(3) });
        }
    }
}