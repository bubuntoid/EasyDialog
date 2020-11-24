using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Forms.Interfaces
{
    public interface IFormProvider
    {
        void ShowDialog();
        void Close();

        void AddControl(Control control);

        int InitialTopPadding { get; set; }
        int SecondColumnXCoord { get; set; }
        int BottomSpace { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int ButtonRightPadding { get; set; }
        int ButtonBottomPadding { get; set; }

        string Title { get; set; }
    }
}
