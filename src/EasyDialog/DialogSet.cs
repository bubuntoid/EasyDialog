using System;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogSet<TValue> : IDialogSet
    {
        string IDialogSet.PropertyName { get; set; }
        Control IDialogSet.Control { get; set; }
        
        bool IDialogSet.ControlSpecifiedFromBuilder { get; set; }
        bool IDialogSet.GetterSpecifiedFromBuilder { get; set; }
        bool IDialogSet.SetterSpecifiedFromBuilder { get; set; }

        Func<Control, object> IDialogSet.Getter { get; set; }
        Action<Control, object> IDialogSet.Setter{ get; set; }

        bool IDialogSet.Ignore { get; set; } = false;
        bool IDialogSet.Enabled { get; set; } = true;
        bool IDialogSet.FullRow { get; set; } = false;
        string IDialogSet.Name { get; set; }
        int? IDialogSet.ControlHeight { get; set; }
        object IDialogSet.PreValue { get; set; }

        public TValue Value
        {
            get 
            {
                if (Base.Getter == null)
                {
                    throw new DialogContextConfigureException("Getter is not configured."); // todo fix message
                }

                return (TValue)Base.Getter(Base.Control);
            }

            set
            {
                if (Base.Setter == null)
                {
                    throw new DialogContextConfigureException("Setter is not configured."); // todo fix message
                }

                Base.Setter(Base.Control, value);
            }
        }

        private IDialogSet Base => this;
    }
}
