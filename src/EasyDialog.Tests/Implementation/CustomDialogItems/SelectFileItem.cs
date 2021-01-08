using System;
using System.Threading;
using System.Windows.Forms;

namespace bubuntoid.EasyDialog.Tests.Implementation.CustomDialogItems
{
    public class SelectFileItem : DialogItem<Button, string>
    {
        public override Button Control { get; set; }

        /// <summary>
        /// Returns path of selected file
        /// </summary>
        public override string Value { get; set; }

        public SelectFileItem()
        {
            Control = GenerateButton();
        }

        private Button GenerateButton()
        {
            var result = new Button
            {
                Text = "Select"
            };

            result.Click += (s, e) =>
            {
                void OpenFileDialog()
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        RestoreDirectory = true
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFileName = openFileDialog.FileName;
                        Value = selectedFileName;
                    }
                }

                var thread = new Thread(OpenFileDialog);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            };

            return result;
        }
    }
}
