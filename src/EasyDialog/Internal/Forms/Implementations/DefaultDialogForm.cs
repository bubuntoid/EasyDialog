using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using EasyDialog.Internal.Forms.Templates;
using EasyDialog.Internal.Forms.Interfaces;

namespace EasyDialog.Internal.Forms.Implementations
{
    internal class DefaultDialogForm : IDialogForm
    {
        private const int SECOND_COLUMN_X_COORD = 150;

        private const int INITIAL_TOP_PADDING = 20;

        private const int VALUE_CONTROL_WIDTH = 150;

        private const int BUTTON_HEIGHT = 40;
        private const int BUTTON_WIDTH = 120;

        private const int BOTTOM_SPACE = BUTTON_HEIGHT + 35;

        public DialogContext Context { get; set; }

        private readonly Form form;

        public string Title
        {
            get => form.Text;
            set => form.Text = value;
        }
        public string ButtonText { get; set; }

        public DefaultDialogForm()
        {
            form = new Form()
            {
                Width = 335,

                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
        }

        public void Show()
        {
            form.ShowDialog();
        }

        public void Close()
        {
            form.Close();
        }

        public void SetItems(IEnumerable<BaseDialogItem> items)
        {
            var currentHeight = INITIAL_TOP_PADDING;
            var count = items.Count();

            for (int i = 0; i < count; i++)
            {
                var currentItem = items.ElementAt(i);
                var control = currentItem.Control;

                control.Enabled = currentItem.Enabled;
                control.AutoSize = false;
                control.Size = new Size(VALUE_CONTROL_WIDTH, currentItem.ControlHeight);
                control.Location = new Point
                {
                    X = SECOND_COLUMN_X_COORD,
                    Y = currentHeight
                };

                form.Controls.Add(LabelTemplate.DefaultLabel(currentItem.Name, currentHeight + 3));
                form.Controls.Add(control);

                currentHeight += control.Size.Height + 10;
            }

            form.Height = INITIAL_TOP_PADDING + currentHeight + BOTTOM_SPACE + 50;

            var buttonControl = new Button()
            {
                Text = ButtonText,
                Height = BUTTON_HEIGHT,
                Width = BUTTON_WIDTH,

                Location = new Point
                {
                    X = form.Width - 150,
                    Y = form.Height - BUTTON_HEIGHT - 46
                }
            };
            buttonControl.Click += (o, e) => { Context.OnButtonClick(); };
            form.Controls.Add(buttonControl);
            buttonControl.Select();
        }
    }
}
