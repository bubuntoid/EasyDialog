using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class CheckBoxItemOptionsBuilder : DialogItemOptionsBuilder
    {
        public CheckBoxItemOptionsBuilder(BaseDialogItem item) : base(item) { }

        public CheckBoxItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public CheckBoxItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }

        public CheckBoxItemOptionsBuilder HasValue(bool value)
        {
            var control = (item.BaseControl as CheckBox);
            control.Checked = value;
            return this;
        }

        public CheckBoxItemOptionsBuilder Ignore()
        {
            item.Ignore = true;
            return this;
        }
        
        public CheckBoxItemOptionsBuilder AsFullRow()
        {
            item.FullRow = true;
            return this;
        }
    }
}
