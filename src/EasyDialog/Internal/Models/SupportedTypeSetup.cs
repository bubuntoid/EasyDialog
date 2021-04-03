using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal.Models
{
    internal class SupportedTypeSetup
    {
        public Func<Control> ControlFactory { get; set; }
        public Func<Control, object> Getter { get; set; }
        public Action<Control, object> Setter { get; set; }

        /// <summary>
        /// IDialogCollectionSet
        /// </summary>
        public Action<Control, IEnumerable<object>> UpdateItemsEvent { get; set; }

        public SupportedTypeSetup(Func<Control> control, 
            Func<Control, object> getter, 
            Action<Control, object> setter)
        {
            ControlFactory = control;
            Getter = getter;
            Setter = setter;
        }

        public SupportedTypeSetup(Func<Control> control, 
            Func<Control, object> getter, 
            Action<Control, object> setter, 
            Action<Control, IEnumerable<object>> updateItemsEvent) 
            : this(control, getter, setter)
        {
            UpdateItemsEvent = updateItemsEvent;
        }
    }
}
