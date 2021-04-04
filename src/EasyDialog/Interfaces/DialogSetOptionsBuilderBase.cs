namespace bubuntoid.EasyDialog
{
    public abstract class DialogSetOptionsBuilderBase<TBuilder, TValue> 
        where TBuilder : DialogSetOptionsBuilderBase<TBuilder, TValue>
    {
        internal readonly IDialogSet Set;

        internal DialogSetOptionsBuilderBase(IDialogSet set)
        {
            Set = set;
        }

        public TBuilder Disabled()
        {
            Set.Enabled = false;
            return (TBuilder)this;
        }

        public TBuilder Ignore()
        {
            Set.Ignore = true;
            return (TBuilder)this;
        }

        public TBuilder AsFullRow()
        {
            Set.FullRow = true;
            return (TBuilder)this;
        }

        public TBuilder HasHeight(int value)
        {
            Set.ControlHeight = value;
            return (TBuilder)this;
        }

        public TBuilder HasValue(TValue value)
        {
            Set.PreValue = value;
            return (TBuilder)this;
        }

        public TBuilder HasName(string name)
        {
            Set.Name = name;
            return (TBuilder)this;
        }
    }
}
