using System;
using System.Linq;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog.Internal
{
    internal class DialogContextItemsLoader
    {
        private readonly DialogContext context;

        public DialogContextItemsLoader(DialogContext context)
        {
            this.context = context;
        }

        public IEnumerable<BaseDialogItem> GetFromProperties()
        {
            var properties = context.GetType()
                .GetProperties()
                    .Where(x => x.PropertyType.BaseType == typeof(BaseDialogItem));

            var result = new HashSet<BaseDialogItem>();

            foreach (var property in properties)
            {
                var item = Activator.CreateInstance(property.PropertyType) as BaseDialogItem;

                item.Context = context;
                item.DialogContextPropertyName = property.Name;
                item.Name = property.Name;

                result.Add(item);

                property.SetValue(context, item);
            }

            return result;
        }
    }
}
