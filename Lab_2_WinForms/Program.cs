using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            /*            MainForm form = new MainForm();
                        form.ShowDialog();*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}
