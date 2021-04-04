using bubuntoid.EasyDialog.Internal.Providers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Internal
{
    // todo: fix magic numbers

    internal class EasyDialogForm : IEasyDialogForm
    {
        private const int DEFAULT_VALUE_CONTROL_HEIGHT = 20;
        private const int DEFAULT_VALUE_CONTROL_WIDTH = 150;
        private const int DEFAULT_BUTTON_HEIGHT = 40;
        private const int DEFAULT_BUTTON_WIDTH = 120;
        private const int PADDING = 25;

        private readonly IDialogContext context;
        
        private IFormProvider formProvider;
        private Action onShownEvent;

        public Form Form => formProvider.Form; 

        public EasyDialogForm(IDialogContext context)
        {
            this.context = context;
        }

        public void Initialize(IDialogContextConfigureOptionsBuilder options)
        {
            formProvider = options.DialogStyle switch
            {
                DialogStyle.Default => new DefaultFormProvider(),
                DialogStyle.Metro => new MetroFormProvider(options.MetroTheme),
                DialogStyle.Material => new MaterialFormProvider(options.MaterialTheme, options.MaterialColorScheme),

                _ => throw new NotImplementedException()
            };
            formProvider.Form.Text = options.Title ?? context.GetType().Name;
            formProvider.SetStartPosition(options.StartPosition);
            onShownEvent = options.OnShownEvent;

            var currentHeight = formProvider.InitialTopPadding;
            var count = options.Items.Count();

            for (int i = 0; i < count; i++)
            {
                var currentItem = options.Items.ElementAt(i);
                var control = currentItem.Control;

                if (currentItem.Ignore == true)
                    continue;

                if (control == null)
                    throw ExceptionBuilder.ControlIsNotSpecifiedException(currentItem);

                if (currentItem.ControlSpecifiedFromBuilder && (currentItem.GetterSpecifiedFromBuilder || currentItem.SetterSpecifiedFromBuilder) == false)
                    throw currentItem.GetterSpecifiedFromBuilder == false
                        ? ExceptionBuilder.GetterIsNotConfiguredException(currentItem)
                        : ExceptionBuilder.SetterIsNotConfiguredException(currentItem);

                control.Enabled = currentItem.Enabled;
                control.AutoSize = false;

                if (currentItem.FullRow == false)
                {
                    var label = new Label
                    {
                        Text = currentItem.Name,
                        Location = new Point(25, currentHeight + 3)
                    };

                    formProvider.AddControl(label);
                }

                if (currentItem is IDialogCollectionSet collectionSet)
                {
                    if (collectionSet.ControlSpecifiedFromBuilder && collectionSet.UpdateItemsEventSpecifiedFromBuilder == false)
                        throw ExceptionBuilder.UpdateItemsEventNotSpecifiedException(currentItem);
                    
                    collectionSet.ControlHeight = collectionSet.DataSource?.Count() * 20 + 30;
                    collectionSet.UpdateItemsEvent(collectionSet.Control, collectionSet.DataSource);
                }

                if (currentItem.PreValue != null)
                    currentItem.Setter.Invoke(currentItem.Control, currentItem.PreValue);

                control.Size = new Size
                {
                    Width = currentItem.FullRow ? formProvider.Width + formProvider.ExtraPaddingForFullRow - 45 : DEFAULT_VALUE_CONTROL_WIDTH,
                    Height = currentItem.ControlHeight ?? DEFAULT_VALUE_CONTROL_HEIGHT
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

            var buttonControl = ResolveButton(options);
            formProvider.AddControl(buttonControl);
            buttonControl.Select();
        }

        private Button ResolveButton(IDialogContextConfigureOptionsBuilder options)
        {
            var result = new Button()
            {
                Text = options.ButtonText,
                Height = DEFAULT_BUTTON_HEIGHT,
                Width = DEFAULT_BUTTON_WIDTH,
            };

            int alignExtraPadding = 0;
            switch (options.ButtonAlign)
            {
                case ButtonAlign.Right:
                    alignExtraPadding = 0;
                    break;

                case ButtonAlign.Left:
                    alignExtraPadding = formProvider.Width - DEFAULT_BUTTON_WIDTH - formProvider.ButtonRightPadding - 10;
                    break;

                case ButtonAlign.Center:
                    alignExtraPadding = formProvider.Width / 2 - DEFAULT_BUTTON_WIDTH + 30;
                    break;
            }

            result.Location = new Point
            {
                X = formProvider.Width - (DEFAULT_BUTTON_WIDTH + formProvider.ButtonRightPadding) - alignExtraPadding,
                Y = formProvider.Height - (DEFAULT_BUTTON_HEIGHT + formProvider.ButtonBottomPadding)
            };

            if (options.ButtonAlign == ButtonAlign.FullRow)
            {
                result.Location = new Point(10, result.Location.Y);
                result.Width = formProvider.Width - formProvider.ButtonRightPadding;
            }

            result.Click += (o, e) => { context.OnButtonClick(); };

            return result;
        }

        public void ShowDialog()
        {
            onShownEvent?.Invoke();
            formProvider.ShowDialog();
        }

        public void Close()
        {
            formProvider.Close();
        }
    }
}
