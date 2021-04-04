﻿using bubuntoid.EasyDialog;
using System.Windows.Forms;

namespace EasyDialog.Samples.Authorization
{
    public class AuthDialogContext : DialogContext<AuthDialogContext>
    {
        public DialogSet<string> Username { get; set; }
        public DialogSet<string> Password { get; set; }
        public DialogSet<bool> IsRobot { get; set; }

        protected override void OnConfigure(DialogContextConfigureOptionsBuilder<AuthDialogContext> builder)
        {
            builder.UseMaterialStyle()
                .HasTitle("Authorization")
                .HasButton("Sign In", ButtonAlign.Center);

            builder.Item(x => x.Password)
                .AsTextBox()
                .UsePasswordChar('*');

            builder.Item(x => x.IsRobot)
                .HasName("I'm not a robot");
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show($"Username: {Username.Value}, Password: {Password.Value}");
        }
    }
}
