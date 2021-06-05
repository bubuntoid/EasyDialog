using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using bubuntoid.EasyDialog.Internal.Models;
using bubuntoid.EasyDialog.Internal.Providers;

namespace bubuntoid.EasyDialog.Internal
{
    // todo: fix magic numbers

    internal class EasyDialogForm : IEasyDialogForm
    {
        private const int DEFAULT_VALUE_CONTROL_HEIGHT = 20;
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

        public void Initialize(IDialogContextConfigureOptionsBuilder optionsBuilder)
        {
            var options = optionsBuilder.Data;
            formProvider = options.FormProvider;
            formProvider.Width = options.Width ?? formProvider.Width;
            formProvider.Form.Text = options.Title ?? context.GetType().Name;
            formProvider.SetStartPosition(options.StartPosition);

            onShownEvent = options.OnShownEvent;

            var currentHeight = formProvider.InitialTopPadding;
            var count = options.Items.Count();

            for (int i = 0; i < count; i++)
            {
                var currentItem = options.Items.ElementAt(i);
                var currentItemData = currentItem.Data;
                var control = currentItemData.Control;
                var fullRowValueControlWidth = formProvider.Width + formProvider.ExtraPaddingForFullRow - 55;

                if (currentItemData.Ignore == true)
                    continue;

                if (control == null)
                    throw ExceptionBuilder.ControlIsNotSpecifiedException(currentItem);

                if (currentItemData.ControlSpecifiedFromBuilder && (currentItemData.GetterSpecifiedFromBuilder || currentItemData.SetterSpecifiedFromBuilder) == false)
                    throw currentItemData.GetterSpecifiedFromBuilder == false
                        ? ExceptionBuilder.GetterIsNotConfiguredException(currentItem)
                        : ExceptionBuilder.SetterIsNotConfiguredException(currentItem);

                control.Enabled = currentItemData.Enabled;
                control.AutoSize = false;

                if (currentItemData.SeparatorBefore != null)
                {
                    var seperatorControl = currentItemData.SeparatorBefore.BuildControl(fullRowValueControlWidth);
                    seperatorControl.Location = new Point(PADDING, currentHeight);
                    formProvider.AddControl(seperatorControl);
                    currentHeight += seperatorControl.Size.Height;
                }

                if (currentItemData.FullRow == false)
                {
                    var label = new Label
                    {
                        Text = currentItemData.Name,
                        Location = new Point(25, currentHeight + 3)
                    };

                    formProvider.AddControl(label);
                }

                if (currentItem is IDialogCollectionSet collectionSet)
                {
                    if (collectionSet.Data.ControlSpecifiedFromBuilder && collectionSet.OnUpdateItemsActionSpecifiedFromBuilder == false)
                        throw ExceptionBuilder.UpdateItemsEventNotSpecifiedException(currentItem);
                    
                    collectionSet.Data.ControlHeight = collectionSet.DataSource?.Count() * 20 + 30;
                    collectionSet.OnUpdateItemsAction(collectionSet.Data.Control, collectionSet.DataSource);
                }

                if (currentItemData.PreValue != null)
                    currentItemData.Setter.Invoke(currentItemData.Control, currentItemData.PreValue);

                control.Size = new Size
                {
                    Width = currentItemData.FullRow ? fullRowValueControlWidth : formProvider.Width / 2 - 30,
                    Height = currentItemData.ControlHeight ?? DEFAULT_VALUE_CONTROL_HEIGHT
                };
                control.Location = new Point
                {
                    X = currentItemData.FullRow ? PADDING : formProvider.Width / 2,
                    Y = currentHeight,
                };

                formProvider.AddControl(control);
                currentHeight += control.Size.Height + 10;

                if (currentItemData.SeparatorAfter != null)
                {
                    var seperatorControl = currentItemData.SeparatorAfter.BuildControl(fullRowValueControlWidth);
                    seperatorControl.Location = new Point(PADDING, currentHeight);
                    formProvider.AddControl(seperatorControl);
                    currentHeight += seperatorControl.Size.Height;
                }
            }

            formProvider.Height = formProvider.InitialTopPadding + currentHeight + DEFAULT_BUTTON_HEIGHT +
                                  formProvider.BottomSpace;
            
            var buttonControl = ResolveButton(options);
            formProvider.AddControl(buttonControl);
            buttonControl.Select();
        }

        private Button ResolveButton(InternalDialogContextConfigureOptionsBuilderData options)
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
