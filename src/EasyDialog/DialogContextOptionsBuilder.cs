using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogContextOptionsBuilder<TContext>
    {
        internal readonly IEnumerable<BaseDialogItem> items;
        
        internal FormStartPosition StartPosition { get; set; }
        internal DialogStyle Style { get; set; }
        internal MetroTheme MetroTheme { get; set; }
        internal MaterialTheme MaterialTheme { get; set; }
        internal MaterialColorScheme MaterialColorScheme { get; set; }
        internal string Title { get; set; }
        internal string ButtonText { get; set; }

        internal DialogContextOptionsBuilder(IEnumerable<BaseDialogItem> items)
        {
            this.items = items;

            StartPosition = FormStartPosition.CenterScreen;
            Style = DialogStyle.Default;
            MetroTheme = MetroTheme.Default;
            MaterialTheme = MaterialTheme.Light;
            MaterialColorScheme = MaterialColorScheme.Default;
            
            Title = "Dialog";
            ButtonText = "Ok";
        }

        /// <summary>
        /// Material skin using some statics inside, so you may use only one dialog with that style at once.
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public DialogContextOptionsBuilder<TContext> UseMaterialStyle(MaterialTheme theme)
        {
            Style = DialogStyle.Material;

            MaterialTheme = theme;
            return this;
        }
        /// <summary>
        /// Material skin using some statics inside, so you may use only one dialog with that style at once.
        /// Uses Light theme by default.
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public DialogContextOptionsBuilder<TContext> UseMaterialStyle() => UseMaterialStyle(MaterialTheme.Light);

        /// <summary>
        /// Material skin using some statics inside, so you may use only one dialog with that style at once.
        /// Default values are: Light, BlueGrey800, BlueGrey900, BlueGrey500, LightBlue200, White
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public DialogContextOptionsBuilder<TContext> UseMaterialStyle(MaterialTheme theme, MaterialColorScheme colorScheme)
        {
            MaterialColorScheme = colorScheme;
            return UseMaterialStyle(theme);
        }

        public DialogContextOptionsBuilder<TContext> UseMetroStyle(MetroTheme theme)
        {
            Style = DialogStyle.Metro;
            MetroTheme = theme;
            return this;
        }
        public DialogContextOptionsBuilder<TContext> UseMetroStyle() => UseMetroStyle(MetroTheme.Default);

        public DialogContextOptionsBuilder<TContext> UseDefaultStyle()
        {
            Style = DialogStyle.Default;
            return this;
        }

        public DialogContextOptionsBuilder<TContext> WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public DialogContextOptionsBuilder<TContext> WithButton(string text)
        {
            ButtonText = text;
            return this;
        }

        public DialogContextOptionsBuilder<TContext> WithStartPosition(FormStartPosition startPosition)
        {
            StartPosition = startPosition;
            return this;
        }

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

            return items.FirstOrDefault(x => x.DialogContextPropertyName == prop.Name);
        }
    }
}
