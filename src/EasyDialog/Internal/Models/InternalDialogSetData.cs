using System;
using System.Drawing;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Models;

internal class InternalDialogSetData
{
    public string PropertyName { get; set; }
    public string Name { get; set; }

    public Control Control { get; set; }
    public Label Label { get; set; }
    public Action<Control, object> Setter { get; set; }
    public Func<Control, object> Getter { get; set; }

    public bool ControlSpecifiedFromBuilder { get; set; }
    public bool GetterSpecifiedFromBuilder { get; set; }
    public bool SetterSpecifiedFromBuilder { get; set; }

    public object PreValue { get; set; }
    public bool Ignore { get; set; }
    public bool Enabled { get; set; }
    public bool FullRow { get; set; }
    public int? ControlHeight { get; set; }

    public Separator SeparatorBefore { get; set; }
    public Separator SeparatorAfter { get; set; }
    public ContentAlignment NameTextAlign { get; set; }

    public InternalDialogSetData()
    {
        // Defaults

        Enabled = true;
        NameTextAlign = ContentAlignment.TopLeft;
    }
}