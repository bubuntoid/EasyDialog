using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public abstract class BaseDialogItem
    {
        private const int DEFAULT_CONTROL_HEIGHT = 23;

        internal string DialogContextPropertyName { get; set; }
        internal string Name { get; set; }
        internal bool Enabled { get; set; } = true;
        internal bool Ignore { get; set; } = false;
        internal bool FullRow { get; set; } = false;

        public virtual Control BaseControl { get; set; }
        public virtual int ControlHeight { get; set; } = DEFAULT_CONTROL_HEIGHT;
    }
}
