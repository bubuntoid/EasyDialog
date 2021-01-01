using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace bubuntoid.EasyDialog.Internal.Providers
{
    internal class MaterialFormProvider : IFormProvider
    {
        public int InitialTopPadding { get; set; } = 80;
        public int SecondColumnXCoord { get; set; } = 150;
        public int BottomSpace { get; set; } = -60;
        public int ButtonRightPadding { get; set; } = 15;
        public int ButtonBottomPadding { get; set; } = 10;

        public string Title
        {
            get => form.Text;
            set => form.Text = value;
        }

        public int Width
        {
            get => form.Width;
            set => form.Width = value;
        }

        public int Height
        {
            get => form.Height;
            set => form.Height = value;
        }

        private readonly MaterialForm form;

        public MaterialFormProvider(MaterialTheme theme, MaterialColorScheme colorScheme)
        {
            form = new MaterialForm()
            {
                Width = 320,

                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterParent,
                Sizable = false
            };

            var defaultLabel = new Label();
            var defaultFontFamilyName = defaultLabel.Font.FontFamily.Name;
            var defaultLabelSize = defaultLabel.Font.Size;
            defaultLabel.Dispose();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ROBOTO_REGULAR_11 = new System.Drawing.Font(defaultFontFamilyName, defaultLabelSize);
            materialSkinManager.AddFormToManage(form);
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
            form.ShowDialog();
        }

        public void Close()
        {
            form.Close();
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
            if (control is Button button)
            {
                control = new MaterialRaisedButton()
                {
                    Text = button.Text,
                    Size = button.Size,
                    Location = button.Location,
                };

                var buttonControl = control as MaterialRaisedButton;
                buttonControl.Click += (s, e) =>
                {
                    button.PerformClick();
                };
            }

            form.Controls.Add(control);
        }
    }
}
