using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogContextConfigureOptionsBuilder<TContext> : IDialogContextConfigureOptionsBuilder
    {
        IEnumerable<IDialogSet> IDialogContextConfigureOptionsBuilder.Items { get; set; }
        string IDialogContextConfigureOptionsBuilder.Title { get; set; }
        string IDialogContextConfigureOptionsBuilder.ButtonText { get; set; }
        ButtonAlign IDialogContextConfigureOptionsBuilder.ButtonAlign { get; set; }
        FormStartPosition IDialogContextConfigureOptionsBuilder.StartPosition { get; set; }
        DialogStyle IDialogContextConfigureOptionsBuilder.DialogStyle { get; set; }
        MetroTheme IDialogContextConfigureOptionsBuilder.MetroTheme{ get; set; }
        Action IDialogContextConfigureOptionsBuilder.OnShownEvent { get; set; }

        internal DialogContextConfigureOptionsBuilder(IEnumerable<IDialogSet> items)
        {
            Base.Items = items;

            // Defaults
            Base.ButtonText = "Submit";
            Base.ButtonAlign = ButtonAlign.Right;
            Base.StartPosition = FormStartPosition.CenterScreen;
        }

        public DialogContextConfigureOptionsBuilder<TContext> OnShown(Action action)
        {
            Base.OnShownEvent = action;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasTitle(string title)
        {
            Base.Title = title;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasButton(string buttonText)
        {
            Base.ButtonText = buttonText;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasButton(string buttonText, ButtonAlign buttonAlign)
        {
            Base.ButtonAlign = buttonAlign;
            return HasButton(buttonText);
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseDefaultStyle()
        {
            Base.DialogStyle = DialogStyle.Default;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle()
        {
            Base.DialogStyle = DialogStyle.Metro;
            Base.MetroTheme = MetroTheme.Default;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle(MetroTheme theme)
        {
            Base.DialogStyle = DialogStyle.Metro;
            Base.MetroTheme = theme;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasStartPosition(FormStartPosition startPosition)
        {
            Base.StartPosition = startPosition;
            return this;
        }


        public DialogSetOptionsBuilder<TValue> Item<TValue>(Expression<Func<TContext, DialogSet<TValue>>> property)
        {
            return new DialogSetOptionsBuilder<TValue>(GetDialogSetFromExpression(property));
        }

        public DialogCollectionSetOptionsBuilder<TValue> Item<TValue>(Expression<Func<TContext, DialogCollectionSet<TValue>>> property)
        {
            return new DialogCollectionSetOptionsBuilder<TValue>(GetDialogSetFromExpression(property) as IDialogCollectionSet);
        }

        private IDialogSet GetDialogSetFromExpression<TProperty>(Expression<Func<TContext, TProperty>> property)
        {
            var expr = property.Body is MemberExpression ?
                (MemberExpression)property.Body :
                (MemberExpression)((UnaryExpression)property.Body).Operand;

            var prop = (PropertyInfo)expr.Member;

            return Base.Items.FirstOrDefault(x => x.PropertyName == prop.Name);
        }

        private IDialogContextConfigureOptionsBuilder Base => this;
    }
}