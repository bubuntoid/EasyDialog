using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Providers
{
    public class DefaultFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 20;
        public int BottomSpace { get; set; } = 50;
        public int ButtonRightPadding { get; set; } = 35;
        public int ButtonBottomPadding { get; set; } = 50;
        public int ExtraPaddingForFullRow { get; set; } = 0;

        public Action OnCloseHandler { get; set; }

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

        public DefaultFormProvider()
        {
            Form = new Form()
            {
                Width = 335,

                MaximizeBox = true,
                FormBorderStyle = FormBorderStyle.FixedSingle
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
