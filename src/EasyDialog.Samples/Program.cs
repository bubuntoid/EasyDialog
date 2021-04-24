using EasyDialog.Samples.Authorization;
using EasyDialog.Samples.Basics;
using EasyDialog.Samples.CustomControl;
using EasyDialog.Samples.CustomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDialog.Samples
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new AuthDialogContext().ShowDialog();
            new DialogWithBasicSupportedTypes().ShowDialog();
            new ButtonControlDialogContext().ShowDialog();
            new TimeSpanCollectionDialogContext().ShowDialog();
            new TimeSpanTypeDialogContext().ShowDialog();
        }
    }
}
