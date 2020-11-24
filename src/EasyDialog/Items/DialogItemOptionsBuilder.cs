namespace bubuntoid.EasyDialog
{
    public class DialogItemOptionsBuilder
    {
        protected readonly BaseDialogItem item;

        public DialogItemOptionsBuilder(BaseDialogItem item)
        {
            this.item = item;
        }

        public DialogItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public DialogItemOptionsBuilder HasHeight(int height)
        {
            item.ControlHeight = height;
            return this;
        }

        public DialogItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }
    }
}
