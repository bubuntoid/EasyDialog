using System.Windows.Forms;

using bubuntoid.EasyDialog.Enums;
using bubuntoid.EasyDialog.Internal.Forms.Interfaces;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Drawing;

namespace bubuntoid.EasyDialog.Internal.Forms.Implementations
{
    internal class MetroFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 80;
        public int SecondColumnXCoord { get; set; } = 165;
        public int BottomSpace { get; set; } = -40;
        public int ButtonRightPadding { get; set; } = 15;
        public int ButtonBottomPadding { get; set; } = 10;

        public string Title
        {
            get => form.Text;
            set => form.Text = value;
        }

        public int Width
        {
            get => form.Width;
            set => form.Width = value;
        }

        public int Height
        {
            get => form.Height;
            set => form.Height = value;
        }

        private readonly MetroForm form;

        public MetroFormProvider(MetroTheme theme)
        {
            form = new MetroForm()
            {
                Width = 335,

                Style = (MetroColorStyle)theme,
                MaximizeBox = false,
                Resizable = false,
                StartPosition = FormStartPosition.CenterParent,
                BorderStyle = MetroBorderStyle.FixedSingle
            };
        }

        public void ShowDialog()
        {
            form.ShowDialog();
        }

        public void Close()
        {
            form.Close();
        }

        public void AddControl(Control control)
        {
            form.Controls.Add(control);
        }
    }
}
