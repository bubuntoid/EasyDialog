using bubuntoid.EasyDialog.Internal.Models;

namespace bubuntoid.EasyDialog
{
    public abstract class DialogSetOptionsBuilderBase<TBuilder, TValue> 
        where TBuilder : DialogSetOptionsBuilderBase<TBuilder, TValue>
    {
        internal readonly IDialogSet Item;

        internal DialogSetOptionsBuilderBase(IDialogSet item)
        {
            Item = item;
        }

        /// <summary>
        /// Makes control disabled
        /// </summary>
        /// <returns></returns>
        public TBuilder Disabled()
        {
            Item.Data.Enabled = false;
            return (TBuilder)this;
        }

        /// <summary>
        /// Makes control ignored (it wont be generated at all)
        /// </summary>
        /// <returns></returns>
        public TBuilder Ignore()
        {
            Item.Data.Ignore = true;
            return (TBuilder)this;
        }

        /// <summary>
        /// Makes control take the all row space (label wont be generated)
        /// </summary>
        /// <returns></returns>
        public TBuilder AsFullRow()
        {
            Item.Data.FullRow = true;
            return (TBuilder)this;
        }

        /// <summary>
        /// Sets control height. Required to specify when control is not default one-row height
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TBuilder HasHeight(int value)
        {
            Item.Data.ControlHeight = value;
            return (TBuilder)this;
        }

        /// <summary>
        /// Sets default value that will be configured before dialog will shown
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TBuilder HasValue(TValue value)
        {
            Item.Data.PreValue = value;
            return (TBuilder)this;
        }

        /// <summary>
        /// Sets label text value (left part of row)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TBuilder HasName(string name)
        {
            Item.Data.Name = name;
            return (TBuilder)this;
        }

        /// <summary>
        /// Place separator line (or empty space) before control
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public TBuilder PlaceSeparatorBefore(SeparatorStyle style = SeparatorStyle.Line)
        {
            Item.Data.SeparatorBefore = new Separator(style);
            return (TBuilder)this;
        }

        /// <summary>
        /// Place separator line (or empty space) after control
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public TBuilder PlaceSeparatorAfter(SeparatorStyle style = SeparatorStyle.Line)
        {
            Item.Data.SeparatorAfter = new Separator(style);
            return (TBuilder)this;
        }
    }
}
