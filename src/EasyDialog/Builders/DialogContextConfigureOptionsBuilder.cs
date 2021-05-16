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

        /// <summary>
        /// Sets the action that will be invoked every time when you use .ShowDialog() method
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> OnShown(Action action)
        {
            Base.Data.OnShownEvent = action;
            return this;
        }

        /// <summary>
        /// Sets the title of form
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> HasTitle(string title)
        {
            Base.Data.Title = title;
            return this;
        }

        /// <summary>
        /// Sets button text
        /// </summary>
        /// <param name="buttonText"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> HasButton(string buttonText)
        {
            Base.Data.ButtonText = buttonText;
            return this;
        }

        /// <summary>
        /// Sets button text and align
        /// </summary>
        /// <param name="buttonText"></param>
        /// <param name="buttonAlign"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> HasButton(string buttonText, ButtonAlign buttonAlign)
        {
            Base.Data.ButtonAlign = buttonAlign;
            return HasButton(buttonText);
        }

        /// <summary>
        /// Uses default windows style
        /// </summary>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseDefaultStyle()
        {
            Base.Data.DialogStyle = DialogStyle.Default;
            return this;
        }

        /// <summary>
        /// Uses metro UI style
        /// </summary>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle()
        {
            Base.Data.DialogStyle = DialogStyle.Metro;
            Base.Data.MetroTheme = MetroTheme.Default;
            return this;
        }

        /// <summary>
        /// Uses metro UI style with specified theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseMetroStyle(MetroTheme theme)
        {
            Base.Data.DialogStyle = DialogStyle.Metro;
            Base.Data.MetroTheme = theme;
            return this;
        }

        /// <summary>
        /// Uses material style
        /// </summary>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle()
        {
            return UseMaterialStyle(MaterialTheme.Light);
        }

        /// <summary>
        /// Uses material style with specified theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle(MaterialTheme theme)
        {
            return UseMaterialStyle(theme, MaterialColorScheme.Default);
        }

        /// <summary>
        /// Uses material style with specified theme and color scheme
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="scheme"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseMaterialStyle(MaterialTheme theme, MaterialColorScheme scheme)
        {
            Base.Data.DialogStyle = DialogStyle.Material;
            Base.Data.MaterialTheme = theme;
            Base.Data.MaterialColorScheme = scheme;
            return this;
        }

        /// <summary>
        /// Sets FormStartPosition of form
        /// </summary>
        /// <param name="startPosition"></param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> HasStartPosition(FormStartPosition startPosition)
        {
            Base.Data.StartPosition = startPosition;
            return this;
        }

        /// <summary>
        /// Configures DialogSet<TValue>
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public DialogSetOptionsBuilder<TValue> Item<TValue>(Expression<Func<TContext, DialogSet<TValue>>> property)
        {
            return new DialogSetOptionsBuilder<TValue>(GetDialogSetFromExpression(property));
        }

        /// <summary>
        /// Configures DialogCollectionSet<TValue>
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
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