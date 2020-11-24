using System.Drawing;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Forms.Templates
{
    public static class LabelTemplate
    {
        public static Label DefaultLabel(string name, int currentHeight)
        {
            return new Label()
            {
                Text = name,
                BackColor = Color.Transparent,
                Location = new Point()
                {
                    X = 25,
                    Y = currentHeight
                }
            };
        }
    }
}
