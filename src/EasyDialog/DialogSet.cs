using System;
using System.Windows.Forms;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal;
using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog
{
    public class DialogSet<TValue> : IDialogSet
    {
        public TValue Value
        {
            get 
            {
                if (Base.Data.Getter == null)
                    throw ExceptionBuilder.GetterIsNotConfiguredException(Base);

                return (TValue)Base.Data.Getter(Base.Data.Control);
            }
            set
            {
                if (Base.Data.Setter == null)
                    throw ExceptionBuilder.SetterIsNotConfiguredException(Base);

                Base.Data.Setter(Base.Data.Control, value);
            }
        }
        
        public Control Control => Base.Data.Control;
        
        private IDialogSet Base => this;

        InternalDialogSetData IDialogSet.Data { get; } = new InternalDialogSetData();
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

            [typeof(TimeSpan)] = new SupportedTypeSetup(control: () => new DateTimePicker { Format = DateTimePickerFormat.Time },
                              getter: (control) => ((DateTimePicker)control).Value,
                              setter: (control, value) => ((DateTimePicker)control).Value = (DateTime)value),
        };
    }
}
