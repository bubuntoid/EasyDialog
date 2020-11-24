using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EasyDialog
{
    public class DialogItemsOptionsBuilder<T>
    {
        internal DialogContextOptionsBuilder DialogContextOptionsBuilder;

        public DialogItemOptionsBuilder Property(Expression<Func<T, object>> property) => new DialogItemOptionsBuilder(GetItemFromExpression(property));
        public TextBoxItemOptionsBuilder Property(Expression<Func<T, TextBoxItem>> property) => new TextBoxItemOptionsBuilder(GetItemFromExpression(property));
        public NumericUpDownItemOptionsBuilder Property(Expression<Func<T, NumericUpDownItem>> property) => new NumericUpDownItemOptionsBuilder(GetItemFromExpression(property));
        public CheckBoxItemOptionsBuilder Property(Expression<Func<T, CheckBoxItem>> property) => new CheckBoxItemOptionsBuilder(GetItemFromExpression(property));
        public DateTimePickerItemOptionsBuilder Property(Expression<Func<T, DateTimePickerItem>> property) => new DateTimePickerItemOptionsBuilder(GetItemFromExpression(property));
        public ComboBoxItemOptionsBuilder Property(Expression<Func<T, ComboBoxItem>> property) => new ComboBoxItemOptionsBuilder(GetItemFromExpression(property));

        private BaseDialogItem GetItemFromExpression<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var expr = property.Body is MemberExpression ?
                (MemberExpression)property.Body :
                (MemberExpression)((UnaryExpression)property.Body).Operand;

            var prop = (PropertyInfo)expr.Member;

            return DialogContextOptionsBuilder.items.FirstOrDefault(x => x.DialogContextPropertyName == prop.Name);
        }
    }
}
