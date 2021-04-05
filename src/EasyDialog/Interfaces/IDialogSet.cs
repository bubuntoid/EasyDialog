using System;
using System.Windows.Forms;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog
{
    public interface IDialogSet
    {
        internal string PropertyName { get; set; }
        internal Control Control { get; set; }
        
        internal bool ControlSpecifiedFromBuilder { get; set; }
        internal bool GetterSpecifiedFromBuilder { get; set; }
        internal bool SetterSpecifiedFromBuilder { get; set; }

        internal Action<Control, object> Setter { get; set; }
        internal Func<Control, object> Getter { get; set; }

        internal object PreValue { get; set; }
        internal bool Ignore { get; set; }
        internal bool Enabled { get; set; }
        internal bool FullRow { get; set; }

        internal string Name { get; set; }
        internal int? ControlHeight { get; set; }

        internal Dictionary<Type, SupportedTypeSetup> SupportedTypesSetups { get; }
    }
}
