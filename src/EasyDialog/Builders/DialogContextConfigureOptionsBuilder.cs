using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Collections.Generic;
using bubuntoid.EasyDialog.Internal.Models;
using bubuntoid.EasyDialog.Internal.Providers;

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
        /// Sets width of form
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> HasWidth(int width)
        {
            Base.Data.Width = width;
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
            return UseFormProvider(new DefaultFormProvider());
        }

        /// <summary>
        /// Specifying FormProvider
        /// </summary>
        /// <returns></returns>
        public DialogContextConfigureOptionsBuilder<TContext> UseFormProvider(IFormProvider formProvider)
        {
            Base.Data.FormProvider = formProvider;
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