using System;
using System.Linq;
using System.Collections.Generic;

namespace bubuntoid.EasyDialog.Internal
{
    internal class DialogContextItemsLoader<TContext>
        where TContext : DialogContext<TContext>
    {
        private readonly DialogContext<TContext> context;

        public DialogContextItemsLoader(DialogContext<TContext> context)
        {
            this.context = context;
        }

        public IEnumerable<BaseDialogItem> GetFromProperties()
        {
            var properties = context.GetType()
                .GetProperties()
                    .Where(x => x.PropertyType.BaseType?.BaseType == typeof(BaseDialogItem)); // todo: refactoring

            var result = new HashSet<BaseDialogItem>();

            foreach (var property in properties)
            {
                var item = Activator.CreateInstance(property.PropertyType) as BaseDialogItem;

                item.DialogContextPropertyName = property.Name;
                item.Name = property.Name;

                result.Add(item);

                property.SetValue(context, item);
            }

            return result;
        }
    }
}
