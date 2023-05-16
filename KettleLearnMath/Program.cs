using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSLib.App;

namespace KettleLearnMath
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var updater = FSLib.App.SimpleUpdater.Updater.Instance;
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple("http://scm.name:8888/klm/update_c.xml");
            Application.Run(new MainForm());
        }
    }
}
