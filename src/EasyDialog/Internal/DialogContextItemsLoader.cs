using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal
{
    internal class DialogContextItemsLoader
    {
        private readonly IDialogContext context;

        public DialogContextItemsLoader(IDialogContext context)
        {
            this.context = context;
        }

        public IEnumerable<IDialogSet> GetFromProperties()
        {
            var properties = context.GetType()
                .GetProperties()
                    .Where(x => x.PropertyType.GetInterfaces().Contains(typeof(IDialogSet)));

            var result = new HashSet<IDialogSet>();

            foreach (var property in properties)
            {
                var item = Activator.CreateInstance(property.PropertyType) as IDialogSet;
                item.PropertyName = item.Name = property.Name;
                
                TryResolveDefaultControl(item, property);
                
                result.Add(item);

                property.SetValue(context, item);
            }

            return result;
        }

        private void TryResolveDefaultControl(IDialogSet item, PropertyInfo property)
        {
            // If control was not configured by .AsControl<TControl>() or by another extensions methods,
            // then it should create some default controls for its value, in case that DialogSet is not configured as Ignored

            // string       -> TextBox
            // int, decimal -> NumericUpDown
            // DateTime     -> DateTimePicker
            // etc...

            var type = property.PropertyType.GenericTypeArguments.First();

            if (SupportedTypes.ContainsKey(type))
            {
                var setup = SupportedTypes.GetValueOrDefault(type);
                item.Control = setup.control.Invoke();
                item.Getter = setup.getter;
                item.Setter = setup.setter;
            }
        }

        private Dictionary<Type, (Func<Control> control, Func<Control, object> getter, Action<Control, object> setter)> SupportedTypes  = new()
        {
            [typeof(string)] = (control: () => new TextBox(),
                                getter: (control) => control.Text,
                                setter: (control, value) => control.Text = (string)value),

            [typeof(int)] = (control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue },
                             getter: (control) => Convert.ToInt32((control as NumericUpDown).Value), 
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(double)] = (control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue, DecimalPlaces = 2 },
                             getter: (control) => Convert.ToDouble((control as NumericUpDown).Value),
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(float)] = (control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue, DecimalPlaces = 2 },
                             getter: (control) => (float)(control as NumericUpDown).Value,
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(decimal)] = (control: () => new NumericUpDown { Minimum = int.MinValue, Maximum = int.MaxValue, DecimalPlaces = 2 },
                             getter: (control) => (control as NumericUpDown).Value,
                             setter: (control, value) => (control as NumericUpDown).Value = (decimal)value),

            [typeof(bool)] = (control: () => new CheckBox(),
                                getter: (control) => ((CheckBox)control).Checked,
                                setter: (control, value) => ((CheckBox)control).Checked = (bool)value),

            [typeof(DateTime)] = (control: () => new DateTimePicker(),
                                getter: (control) => ((DateTimePicker)control).Value,
                                setter: (control, value) => ((DateTimePicker)control).Value = (DateTime)value),
        };

    }
}
