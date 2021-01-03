using bubuntoid.EasyDialog.Tests.Implementation.CustomDialogItems;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class UploadFileDialog : DialogContext<UploadFileDialog>
    {
        public DialogButtonItem File { get; set; }
        public TextBoxItem Filename { get; set; }

        protected override void OnButtonClick()
        {

        }

        protected override void OnConfiguring(DialogContextOptionsBuilder<UploadFileDialog> builder)
        {
            builder.UseDefaultStyle()
                .WithTitle("Uploading...")
                .WithButton("Upload");

            File.Control.Text = "Select";
        }
    }
}
