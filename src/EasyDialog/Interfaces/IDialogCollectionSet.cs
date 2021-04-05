using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog
{
    public interface IDialogCollectionSet : IDialogSet
    {
        internal IEnumerable<object> DataSource { get; set; }

        internal Action<Control, IEnumerable<object>> UpdateItemsEvent { get; set; }
        internal bool UpdateItemsEventSpecifiedFromBuilder { get; set; }
    }
}
