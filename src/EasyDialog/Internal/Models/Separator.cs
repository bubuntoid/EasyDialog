using System.Drawing;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Models;

internal class Separator
{
    private readonly SeparatorStyle style;

    public Separator(SeparatorStyle style)
    {
        this.style = style;
    }

    public Control BuildControl(int width)
    {
        switch (style)
        {
            case SeparatorStyle.Empty: return new Control { Size = new Size(width, 30) };
            case SeparatorStyle.Line:
                var control = new Control
                {
                    Size = new Size(width, 30),
                };
                var label = new Label
                {
                    Size = new Size(width, 30),
                    AutoSize = false,
                    Height = 2,
                    BorderStyle = BorderStyle.Fixed3D,
                };
                control.Controls.Add(label);
                label.Location = new Point(label.Location.X, label.Location.Y + 10);

                return control;

            default:
                throw new EasyDialogInternalException($"Separator style '{style}' not implemented.");
        }
    }
}