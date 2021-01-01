using System.Drawing;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal
{
    internal static class Templates
    {
        public static Button DefaultButton => new Button();
        public static Label DefaultLabel => new Label { BackColor = Color.Transparent };
    }
}
