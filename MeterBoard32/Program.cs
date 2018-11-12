using MeterBoard32.Forms;
using System;
using System.Windows.Forms;

namespace MeterBoard32
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
            Application.Run(new MeterBoard32Form());
        }
    }
}
