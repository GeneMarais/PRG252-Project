using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/* PRG282 Project - 2019/07/24
 * Team members:
 *      Etienne Pieterse
 *      James Williams
 *      Gene Marais
*/

namespace Project2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
