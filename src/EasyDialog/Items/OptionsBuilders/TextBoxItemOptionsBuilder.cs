using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public class TextBoxItemOptionsBuilder : DialogItemOptionsBuilder
    {
        private readonly TextBox control;

        public TextBoxItemOptionsBuilder(BaseDialogItem item) : base(item)
        {
            control = base.item.Control as TextBox;
        }

        public TextBoxItemOptionsBuilder HasName(string name)
        {
            item.Name = name;
            return this;
        }

        public TextBoxItemOptionsBuilder HasHeight(int height)
        {
            item.ControlHeight = height;
            return this;
        }

        public DialogItemOptionsBuilder IsEnabled(bool value)
        {
            item.Enabled = value;
            return this;
        }

        public TextBoxItemOptionsBuilder IsMultiline(bool value)
        {
            control.Multiline = value;
            return this;
        }

        public TextBoxItemOptionsBuilder UsePasswordChar(char passwordChar = '*')
        {
            control.PasswordChar = passwordChar;
            return this;
        }

        public TextBoxItemOptionsBuilder HasValue(string value)
        {
            control.Text = value;
            return this;
        }

        public TextBoxItemOptionsBuilder Ignore()
        {
            item.Ignore = true;
            return this;
        }
        
        public TextBoxItemOptionsBuilder AsFullRow()
        {
            item.FullRow = true;
            return this;
        }
    }
}
