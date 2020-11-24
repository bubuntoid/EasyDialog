using System.Windows.Forms;
using EasyDialog.Internal.Forms.Interfaces;

namespace EasyDialog.Internal.Forms.Implementations
{
    internal class DefaultFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 20;
        public int SecondColumnXCoord { get; set; } = 150;
        public int BottomSpace { get; set; } = 70;
        public int ButtonRightPadding { get; set; } = 35;
        public int ButtonBottomPadding { get; set; } = 50;

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

        private readonly Form form;

        public DefaultFormProvider()
        {
            form = new Form()
            {
                Width = 335,

                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle
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
