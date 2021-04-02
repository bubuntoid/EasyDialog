using System;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Drawing;

namespace bubuntoid.EasyDialog.Internal.Providers
{
    internal class MetroFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 80;
        public int SecondColumnXCoord { get; set; } = 165;
        public int BottomSpace { get; set; } = -40;
        public int ButtonRightPadding { get; set; } = 15;
        public int ButtonBottomPadding { get; set; } = 10;

        public Action OnCloseHandler { get; set; }

        public string Title
        {
            get => Form.Text;
            set => Form.Text = value;
        }

        public int Width
        {
            get => Form.Width;
            set => Form.Width = value;
        }

        public int Height
        {
            get => Form.Height;
            set => Form.Height = value;
        }

        public Form Form { get; private set; }

        public MetroFormProvider(MetroTheme theme)
        {
            Form = new MetroForm()
            {
                Width = 335,
                
                Style = (MetroColorStyle)theme,
                MaximizeBox = false,
                Resizable = false,
                BorderStyle = MetroBorderStyle.FixedSingle,
            };

            Form.FormClosed += (s, e) =>
            {
                OnCloseHandler?.Invoke();
            };
        }

        public void ShowDialog()
        {
            Form.ShowDialog();
        }

        public void Close()
        {
            Form.Close();
        }

        public void AddControl(Control control)
        {
            Form.Controls.Add(control);
        }

        public void SetStartPosition(FormStartPosition startPosition)
        {
            Form.StartPosition = startPosition;
        }
    }
}
