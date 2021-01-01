using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using bubuntoid.EasyDialog.Internal.Providers;

namespace bubuntoid.EasyDialog.Internal
{
    internal class EasyDialogForm : IEasyDialogForm
    {
        private const int DEFAULT_VALUE_CONTROL_WIDTH = 150;

        private const int DEFAULT_BUTTON_HEIGHT = 40;
        private const int DEFAULT_BUTTON_WIDTH = 120;

        private const int PADDING = 25;

        public DialogContext Context { get; set; }

        public string Title
        {
            get => formProvider.Title;
            set => formProvider.Title = value;
        }

        public string ButtonText
        {
            get => button.Text;
            set => button.Text = value;
        }

        private readonly IFormProvider formProvider;

        private Button button;

        public EasyDialogForm(IFormProvider formProvider)
        {
            button = Templates.DefaultButton;
            this.formProvider = formProvider;
        }

        public void Show()
        {
            formProvider.ShowDialog();
        }

        public void Close()
        {
            formProvider.Close();
        }

        public void SetItems(IEnumerable<BaseDialogItem> items)
        {
            var currentHeight = formProvider.InitialTopPadding;
            var count = items.Count();

            for (int i = 0; i < count; i++)
            {
                var currentItem = items.ElementAt(i);
                var control = currentItem.Control;
                control.Enabled = currentItem.Enabled;
                control.AutoSize = false;

                if (currentItem.Ignore == true)
                    continue;

                if (currentItem.FullRow == false)
                {
                    var label = Templates.DefaultLabel;
                    label.Text = currentItem.Name;
                    label.Location = new Point(25, currentHeight + 3);

                    formProvider.AddControl(label);
                }

                control.Size = new Size
                {
                    Width = currentItem.FullRow ? formProvider.Width - 45 : DEFAULT_VALUE_CONTROL_WIDTH,
                    Height = currentItem.ControlHeight
                };
                control.Location = new Point
                {
                    X = currentItem.FullRow ? PADDING : formProvider.SecondColumnXCoord,
                    Y = currentHeight,
                };

                formProvider.AddControl(control);
                currentHeight += control.Size.Height + 10;
            }

            formProvider.Height = formProvider.InitialTopPadding + currentHeight + DEFAULT_BUTTON_HEIGHT +
                                  formProvider.BottomSpace;

            var buttonControl = new Button
            {
                Text = ButtonText,
                Height = DEFAULT_BUTTON_HEIGHT,
                Width = DEFAULT_BUTTON_WIDTH,

                Location = new Point
                {
                    X = formProvider.Width - (DEFAULT_BUTTON_WIDTH + formProvider.ButtonRightPadding),
                    Y = formProvider.Height - (DEFAULT_BUTTON_HEIGHT + formProvider.ButtonBottomPadding)
                }
            };
            buttonControl.Click += (o, e) => { Context.OnButtonClick(); };
            formProvider.AddControl(buttonControl);
            buttonControl.Select();
        }
    }
}