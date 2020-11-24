using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Tests.Implementation.CustomDialogItems
{
    public class DialogButtonItem : BaseDialogItem
    {
        public override Control Control { get; set; } = new Button() {Text = "Upload"};
    }
}
