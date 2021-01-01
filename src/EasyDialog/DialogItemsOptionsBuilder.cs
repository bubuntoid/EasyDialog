using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace bubuntoid.EasyDialog
{
    public class DialogItemsOptionsBuilder<TContext>
        where TContext : DialogContext
    {
        internal DialogContextOptionsBuilder DialogContextOptionsBuilder;

        // todo: move to extensions?
        public DialogItemOptionsBuilder Property(Expression<Func<TContext, object>> property) => new DialogItemOptionsBuilder(GetItemFromExpression(property));
        public TextBoxItemOptionsBuilder Property(Expression<Func<TContext, TextBoxItem>> property) => new TextBoxItemOptionsBuilder(GetItemFromExpression(property));
        public NumericUpDownItemOptionsBuilder Property(Expression<Func<TContext, NumericUpDownItem>> property) => new NumericUpDownItemOptionsBuilder(GetItemFromExpression(property));
        public CheckBoxItemOptionsBuilder Property(Expression<Func<TContext, CheckBoxItem>> property) => new CheckBoxItemOptionsBuilder(GetItemFromExpression(property));
        public DateTimePickerItemOptionsBuilder Property(Expression<Func<TContext, DateTimePickerItem>> property) => new DateTimePickerItemOptionsBuilder(GetItemFromExpression(property));
        public ComboBoxItemOptionsBuilder Property(Expression<Func<TContext, ComboBoxItem>> property) => new ComboBoxItemOptionsBuilder(GetItemFromExpression(property));
        public ListBoxItemOptionsBuilder Property(Expression<Func<TContext, ListBoxItem>> property) => new ListBoxItemOptionsBuilder(GetItemFromExpression(property));

        private BaseDialogItem GetItemFromExpression<TProperty>(Expression<Func<TContext, TProperty>> property)
        {
            var expr = property.Body is MemberExpression ?
                (MemberExpression)property.Body :
                (MemberExpression)((UnaryExpression)property.Body).Operand;

            var prop = (PropertyInfo)expr.Member;

            return DialogContextOptionsBuilder.items.FirstOrDefault(x => x.DialogContextPropertyName == prop.Name);
        }
    }
}
