using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using bubuntoid.EasyDialog.Enums;
using bubuntoid.EasyDialog.Tests.Implementation;
using bubuntoid.EasyDialog.Tests.Models;

namespace bubuntoid.EasyDialog.Tests
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var taskA = Task.Factory.StartNew(() => new AuthentificationDialog().Show());
            var taskB = Task.Factory.StartNew(() => new ClientDialog(Client.Get()).Show());
            var taskC = Task.Factory.StartNew(() => new UploadFileDialog().Show());
            var taskD = Task.Factory.StartNew(() => new ClientDialog(null, MetroTheme.Green).Show());

            Task.WaitAll(new[] { taskA, taskB, taskC, taskD });
        }
    }
}
