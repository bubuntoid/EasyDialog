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

        public TBuilder Disabled()
        {
            Item.Data.Enabled = false;
            return (TBuilder)this;
        }

        public TBuilder Ignore()
        {
            Item.Data.Ignore = true;
            return (TBuilder)this;
        }

        public TBuilder AsFullRow()
        {
            Item.Data.FullRow = true;
            return (TBuilder)this;
        }

        public TBuilder HasHeight(int value)
        {
            Item.Data.ControlHeight = value;
            return (TBuilder)this;
        }

        public TBuilder HasValue(TValue value)
        {
            Item.Data.PreValue = value;
            return (TBuilder)this;
        }

        public TBuilder HasName(string name)
        {
            Item.Data.Name = name;
            return (TBuilder)this;
        }
    }
}
