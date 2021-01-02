using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class DialogContextOptionsBuilder
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
        public DialogContextOptionsBuilder UseMaterialStyle(MaterialTheme theme)
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
        public DialogContextOptionsBuilder UseMaterialStyle() => UseMaterialStyle(MaterialTheme.Light);

        /// <summary>
        /// Material skin using some statics inside, so you may use only one dialog with that style at once.
        /// Default values are: Light, BlueGrey800, BlueGrey900, BlueGrey500, LightBlue200, White
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public DialogContextOptionsBuilder UseMaterialStyle(MaterialTheme theme, MaterialColorScheme colorScheme)
        {
            MaterialColorScheme = colorScheme;
            return UseMaterialStyle(theme);
        }

        public DialogContextOptionsBuilder UseMetroStyle(MetroTheme theme)
        {
            Style = DialogStyle.Metro;
            MetroTheme = theme;
            return this;
        }
        public DialogContextOptionsBuilder UseMetroStyle() => UseMetroStyle(MetroTheme.Default);

        public DialogContextOptionsBuilder UseDefaultStyle()
        {
            Style = DialogStyle.Default;
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

        public DialogContextOptionsBuilder WithStartPosition(FormStartPosition startPosition)
        {
            StartPosition = startPosition;
            return this;
        }

        public DialogContextOptionsBuilder ConfigureItems<TContext>(Action<DialogItemsOptionsBuilder<TContext>> options)
            where TContext : DialogContext
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
