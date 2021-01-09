namespace bubuntoid.EasyDialog
{
    public class ItemOptionsBuilder<TDialogItem>
        where TDialogItem : BaseDialogItem
    {
        internal BaseDialogItem Item { get; set; }

        internal ItemOptionsBuilder(BaseDialogItem item)
        {
            Item = item;
        }

        public ItemOptionsBuilder<TDialogItem> HasName(string name)
        {
            Item.Name = name;
            return this;
        }

        public ItemOptionsBuilder<TDialogItem> HasHeight(int height)
        {
            Item.ControlHeight = height;
            return this;
        }

        public ItemOptionsBuilder<TDialogItem> IsDisabled()
        {
            Item.Enabled = false;
            return this;
        }

        public ItemOptionsBuilder<TDialogItem> Ignore()
        {
            Item.Ignore = true;
            return this;
        }

        public ItemOptionsBuilder<TDialogItem> AsFullRow()
        {
            Item.FullRow = true;
            return this;
        }
    }
}
