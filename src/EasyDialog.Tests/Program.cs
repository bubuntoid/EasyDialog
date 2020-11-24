using System;
using System.Windows.Forms;
using System.Threading.Tasks;

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

            var taskA = Task.Factory.StartNew(() => new AuthorizationDialog().Show());
            var taskB = Task.Factory.StartNew(() => new EditClientDialog(Client.Get()).Show());

            Task.WaitAll(new[] { taskA, taskB});
        }
    }
}
