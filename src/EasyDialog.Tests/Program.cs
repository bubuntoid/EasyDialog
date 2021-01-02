using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using bubuntoid.EasyDialog.Tests.Implementation;
using bubuntoid.EasyDialog.Tests.Models;
using MaterialSkin.Controls;

namespace bubuntoid.EasyDialog.Tests
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var taskA = Task.Factory.StartNew(() => new AuthentificationDialog().ShowDialog());
            var taskB = Task.Factory.StartNew(() => new ClientDialog(Client.Get()).ShowDialog());
            var taskC = Task.Factory.StartNew(() => new UploadFileDialog().ShowDialog());
            var taskD = Task.Factory.StartNew(() => new ClientDialog(null, MetroTheme.Green).ShowDialog());
            
            Task.WaitAll(new[] { taskA, taskB, taskC, taskD });
        }
    }
}
