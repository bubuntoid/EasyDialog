namespace bubuntoid.EasyDialog;

public interface IDialogContext
{
    void ShowDialog();
    void Close();

    internal void OnButtonClick();
}