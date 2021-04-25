using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Collections.Generic;
using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog
{
    public class DialogContextConfigureOptionsBuilder<TContext> : IDialogContextConfigureOptionsBuilder
    {
        InternalDialogContextConfigureOptionsBuilderData IDialogContextConfigureOptionsBuilder.Data { get; } = 
            new InternalDialogContextConfigureOptionsBuilderData();

        internal DialogContextConfigureOptionsBuilder(IEnumerable<IDialogSet> items)
        {
            Base.Data.Items = items;
        }

        public DialogContextConfigureOptionsBuilder<TContext> OnShown(Action action)
        {
            Base.Data.OnShownEvent = action;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasTitle(string title)
        {
            Base.Data.Title = title;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasButton(string buttonText)
        {
            Base.Data.ButtonText = buttonText;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasButton(string buttonText, ButtonAlign buttonAlign)
        {
            Base.Data.ButtonAlign = buttonAlign;
            return HasButton(buttonText);
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseDefaultStyle()
        {
            Base.Data.DialogStyle = DialogStyle.Default;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle()
        {
            Base.Data.DialogStyle = DialogStyle.Metro;
            Base.Data.MetroTheme = MetroTheme.Default;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle(MetroTheme theme)
        {
            Base.Data.DialogStyle = DialogStyle.Metro;
            Base.Data.MetroTheme = theme;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle()
        {
            return UseMaterialStyle(MaterialTheme.Light);
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle(MaterialTheme theme)
        {
            return UseMaterialStyle(theme, MaterialColorScheme.Default);
        }

        public DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle(MaterialTheme theme, MaterialColorScheme scheme)
        {
            Base.Data.DialogStyle = DialogStyle.Material;
            Base.Data.MaterialTheme = theme;
            Base.Data.MaterialColorScheme = scheme;
            return this;
        }

        public DialogContextConfigureOptionsBuilder<TContext> HasStartPosition(FormStartPosition startPosition)
        {
            Base.Data.StartPosition = startPosition;
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

            return Base.Data.Items.FirstOrDefault(x => x.Data.PropertyName == prop.Name);
        }

        private IDialogContextConfigureOptionsBuilder Base => this;
    }
}