using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using bubuntoid.EasyDialog.Tests.Implementation.CustomDialogItems;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class UploadFileDialog : DialogContext
    {
        public DialogButtonItem File { get; set; }
        public TextBoxItem Filename { get; set; }

        protected override void OnConfiguring(DialogContextOptionsBuilder builder)
        {
            builder.UseStyle(DialogStyle.Default)
                .WithTitle("Uploading...")
                .WithButton("Upload");

            builder.ConfigureItems<UploadFileDialog>(options =>
            {
                File.Control.Text = "Select";
            });
        }
    }
}
