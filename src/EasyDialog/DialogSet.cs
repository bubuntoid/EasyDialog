using bubuntoid.EasyDialog.Internal;
using bubuntoid.EasyDialog.Internal.Models;
using System;
using System.Collections.Generic;
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
                    throw ExceptionBuilder.GetterIsNotConfiguredException(Base);

                return (TValue)Base.Getter(Base.Control);
            }
            set
            {
                if (Base.Setter == null)
                    throw ExceptionBuilder.SetterIsNotConfiguredException(Base);

                Base.Setter(Base.Control, value);
            }
        }
        public Control Control => Base.Control;

        private IDialogSet Base => this;

        Dictionary<Type, SupportedTypeSetup> IDialogSet.SupportedTypesSetups => new()
        {
            [typeof(string)] = new SupportedTypeSetup(control: () => new TextBox(),
                                getter: (control) => control.Text,
                                setter: (control, value) => control.Text = (string)value),

            [typeof(int)] = new SupportedTypeSetup(control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue },
                             getter: (control) => Convert.ToInt32((control as NumericUpDown).Value),
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(double)] = new SupportedTypeSetup(control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue, DecimalPlaces = 2 },
                             getter: (control) => Convert.ToDouble((control as NumericUpDown).Value),
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(float)] = new SupportedTypeSetup(control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue, DecimalPlaces = 2 },
                             getter: (control) => (float)(control as NumericUpDown).Value,
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(decimal)] = new SupportedTypeSetup(control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue, DecimalPlaces = 2 },
                             getter: (control) => (control as NumericUpDown).Value,
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(bool)] = new SupportedTypeSetup(control: () => new CheckBox(),
                                getter: (control) => ((CheckBox)control).Checked,
                                setter: (control, value) => ((CheckBox)control).Checked = (bool)value),

            [typeof(DateTime)] = new SupportedTypeSetup(control: () => new DateTimePicker { Format = DateTimePickerFormat.Short },
                                getter: (control) => ((DateTimePicker)control).Value,
                                setter: (control, value) => ((DateTimePicker)control).Value = (DateTime)value),
        };
    }
}
