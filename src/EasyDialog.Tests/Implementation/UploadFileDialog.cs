using bubuntoid.EasyDialog.Tests.Implementation.CustomDialogItems;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Tests.Implementation
{
    public class UploadFileDialog : DialogContext<UploadFileDialog>
    {
        public SelectFileItem File { get; set; }

        protected override void OnConfiguring(DialogContextOptionsBuilder<UploadFileDialog> builder)
        {
            builder.UseDefaultStyle()
                .WithTitle("Uploading...")
                .WithButton("Upload", ButtonAlign.Center);
        }

        protected override void OnButtonClick()
        {
            MessageBox.Show(File.Value);
        }
    }
}
