using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SkeggFallLevelDesigner
{
     class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod
().DeclaringType);

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
          [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            log.Debug("Application Starting");

        }
    }
}
