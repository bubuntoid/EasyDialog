using System.Windows.Forms;
using EasyDialog.Internal.Forms.Interfaces;
using MaterialSkin.Controls;

namespace EasyDialog.Internal.Forms.Implementations
{
    internal class MaterialFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 80;
        public int SecondColumnXCoord { get; set; } = 150;
        public int BottomSpace { get; set; } = 0;
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

        private readonly MaterialForm form;

        public MaterialFormProvider()
        {
            form = new MaterialForm()
            {
                Width = 320,

                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterParent,
                Sizable = false
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
