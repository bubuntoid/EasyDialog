using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

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
                item.Data.PropertyName = item.Data.Name = property.Name;
                
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

            if (item.SupportedTypesSetups.ContainsKey(type))
            {
                var setup = item.SupportedTypesSetups.GetValueOrDefault(type);
                item.Data.Control = setup.ControlFactory.Invoke();
                item.Data.Getter = setup.Getter;
                item.Data.Setter = setup.Setter;

                if (item is IDialogCollectionSet collectionSet)
                    collectionSet.OnUpdateItemsAction = setup.UpdateItemsEvent;
            }
        }
    }
}
