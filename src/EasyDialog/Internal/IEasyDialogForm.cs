using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal;

internal interface IEasyDialogForm
{
    Form Form { get; }
    
    void Initialize(IDialogContextConfigureOptionsBuilder options);
        
    void ShowDialog();
    void Close();
}