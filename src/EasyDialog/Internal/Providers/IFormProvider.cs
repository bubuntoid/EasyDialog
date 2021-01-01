using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Providers
{
    internal interface IFormProvider
    {
        void ShowDialog();
        void Close();

        void AddControl(Control control);

        int Height { get; set; }
        int Width { get; set; }

        int InitialTopPadding { get; set; }
        int SecondColumnXCoord { get; set; }
        int BottomSpace { get; set; }
        int ButtonRightPadding { get; set; }
        int ButtonBottomPadding { get; set; }

        string Title { get; set; }
    }
}
