using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog;

public interface IDialogCollectionSet : IDialogSet
{
    internal IEnumerable<object> DataSource { get; set; }

    internal Action<Control, IEnumerable<object>> OnUpdateItemsAction { get; set; }
    internal bool OnUpdateItemsActionSpecifiedFromBuilder { get; set; }
}