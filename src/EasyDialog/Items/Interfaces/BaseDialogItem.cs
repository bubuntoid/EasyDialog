using System.Windows.Forms;

namespace bubuntoid.EasyDialog
{
    public abstract class BaseDialogItem
    {
        private const int DEFAULT_CONTROL_HEIGHT = 23;

        internal DialogContext Context { get; set; }
        internal string DialogContextPropertyName { get; set; }
        internal string Name { get; set; }
        internal bool Enabled { get; set; } = true;

        public abstract Control Control { get; set; }
        public virtual int ControlHeight { get; set; } = DEFAULT_CONTROL_HEIGHT;
    }
}
