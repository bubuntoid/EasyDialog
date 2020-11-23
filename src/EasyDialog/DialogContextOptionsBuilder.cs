using System;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

using EasyDialog.Enums;

namespace EasyDialog
{
    public class DialogContextOptionsBuilder
    {
        private readonly IEnumerable<BaseDialogItem> items;

        internal DialogStyle Style { get; set; } = DialogStyle.Default;
        internal MetroTheme MetroTheme { get; set; } = MetroTheme.Default;
        internal string Title { get; set; } = "Dialog";
        internal string ButtonText { get; set; } = "Ok";

        internal DialogContextOptionsBuilder(IEnumerable<BaseDialogItem> items)
        {
            this.items = items;
        }

        public DialogContextOptionsBuilder UseStyle(DialogStyle style)
        {
            Style = style;
            return this;
        }

        public DialogContextOptionsBuilder UseMetroTheme(MetroTheme theme)
        {
            MetroTheme = theme;
            return this;
        }

        public DialogContextOptionsBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public DialogContextOptionsBuilder WithButton(string text)
        {
            ButtonText = text;
            return this;
        }

        public DialogItemOptionsBuilder PropertyOf<T>(Expression<Func<T, object>> property) => new DialogItemOptionsBuilder(GetItemFromExpression(property));
        public TextBoxItemOptionsBuilder PropertyOf<T>(Expression<Func<T, TextBoxItem>> property) => new TextBoxItemOptionsBuilder(GetItemFromExpression(property));
        public NumericUpDownItemOptionsBuilder PropertyOf<T>(Expression<Func<T, NumericUpDownItem>> property) => new NumericUpDownItemOptionsBuilder(GetItemFromExpression(property));
        public CheckBoxItemOptionsBuilder PropertyOf<T>(Expression<Func<T, CheckBoxItem>> property) => new CheckBoxItemOptionsBuilder(GetItemFromExpression(property));
        public DateTimePickerItemOptionsBuilder PropertyOf<T>(Expression<Func<T, DateTimePickerItem>> property) => new DateTimePickerItemOptionsBuilder(GetItemFromExpression(property));
        public ComboBoxItemOptionsBuilder PropertyOf<T>(Expression<Func<T, ComboBoxItem>> property) => new ComboBoxItemOptionsBuilder(GetItemFromExpression(property));

        private BaseDialogItem GetItemFromExpression<T, TProperty>(Expression<Func<T, TProperty>> property)
        {
            var expr = property.Body is MemberExpression ?
                (MemberExpression)property.Body :
                (MemberExpression)((UnaryExpression)property.Body).Operand;

            var prop = (PropertyInfo)expr.Member;

            return items.FirstOrDefault(x => x.DialogContextPropertyName == prop.Name);
        }
    }
}
