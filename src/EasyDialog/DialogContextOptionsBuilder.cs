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
        internal readonly IEnumerable<BaseDialogItem> items;

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

        public DialogContextOptionsBuilder ConfigureItems<TContext>(Action<DialogItemsOptionsBuilder<TContext>> options)
        {
            var arg = new DialogItemsOptionsBuilder<TContext>
            {
                DialogContextOptionsBuilder = this

            };
            options.Invoke(arg);
            return this;
        }
    }
}
