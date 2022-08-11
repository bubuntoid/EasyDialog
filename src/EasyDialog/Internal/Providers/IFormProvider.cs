using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Providers;

/// <summary>
/// Docs: 
/// </summary>
public interface IFormProvider
{
    void ShowDialog();
    void Close();

    Form Form { get; }

    void SetStartPosition(FormStartPosition startPosition);
    void AddControl(Control control);

    int Height { get; set; }
    int Width { get; set; }

    int ExtraPaddingForFullRow { get; set; }

    /// <summary>
    /// Space between title bar and first control (DialogSet) that will be generated
    /// </summary>
    int InitialTopPadding { get; set; }

    /// <summary>
    /// Space between last control (DialogSet) and form height
    /// </summary>
    int BottomSpace { get; set; }

    int ButtonRightPadding { get; set; }

    int ButtonBottomPadding { get; set; }

    /// <summary>
    /// Action that should be invoked when form is closed
    /// </summary>
    Action OnCloseHandler { get; set; }
}