using System;
using System.Windows.Forms;
using bubuntoid.EasyDialog.Internal.Providers;

using MaterialSkin;
using MaterialSkin.Controls;

namespace bubuntoid.EasyDialog.Internal.Providers
{
    internal class MaterialFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 80;
        public int BottomSpace { get; set; } = -60;
        public int ButtonRightPadding { get; set; } = 15;
        public int ButtonBottomPadding { get; set; } = 10;
        public int ExtraPaddingForFullRow { get; set; } = 0;

        public Action OnCloseHandler { get; set; }

        public int Width
        {
            get => Form.Width;
            set => Form.Width = value;
        }

        public int Height
        {
            get => Form.Height;
            set => Form.Height = value;
        }

        public Form Form { get; set; }

        public MaterialFormProvider(MaterialTheme theme, MaterialColorScheme colorScheme)
        {
            Form = new MaterialForm()
            {
                Width = 320,

                MaximizeBox = false,
                Sizable = false
            };

            Form.FormClosed += (s, e) =>
            {
                OnCloseHandler?.Invoke();
            };

            var defaultLabel = new Label();
            var defaultFontFamilyName = defaultLabel.Font.FontFamily.Name;
            var defaultLabelSize = defaultLabel.Font.Size;
            defaultLabel.Dispose();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ROBOTO_REGULAR_11 = new System.Drawing.Font(defaultFontFamilyName, defaultLabelSize);
            materialSkinManager.AddFormToManage((MaterialForm)Form);
            materialSkinManager.Theme = (MaterialSkinManager.Themes)theme;
            materialSkinManager.ColorScheme = new ColorScheme(
                primary: (Primary)colorScheme.Primary,
                darkPrimary: (Primary)colorScheme.DarkPrimary,
                lightPrimary: (Primary)colorScheme.LightPrimary,
                accent: (Accent)colorScheme.Accent,
                textShade: (TextShade)colorScheme.TextShade);
        }

        public void ShowDialog()
        {
            Form.ShowDialog();
        }

        public void Close()
        {
            Form.Close();
        }

        public void AddControl(Control control)
        {
            // todo: refactoring
            if (control is Label label)
            {
                control = new MaterialLabel()
                {
                    Text = label.Text,
                    Size = label.Size,
                    Location = label.Location,

                };
            }
            else if (control is Button button)
            {
                control = new MaterialRaisedButton()
                {
                    Text = button.Text,
                    Size = button.Size,
                    Location = button.Location,
                    AutoSize = false,
                };

                var buttonControl = control as MaterialRaisedButton;
                buttonControl.Click += (s, e) =>
                {
                    button.PerformClick();
                };
            }

            Form.Controls.Add(control);
        }

        public void SetStartPosition(FormStartPosition startPosition)
        {
            Form.StartPosition = startPosition;
        }
    }
}
