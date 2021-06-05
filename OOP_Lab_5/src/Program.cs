using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Lab_5.Core;

namespace OOP_Lab_5
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var left = new Matrix(new List<List<long>>
            {
                new List<long>{1, 1, 2},
                new List<long>{3, 5, 8},
                new List<long>{13, 21, 24}
            });
            var right = new Matrix(new List<List<long>>
            {
                new List<long>{2, 4, 5},
                new List<long>{3, 5, 8},
                new List<long>{13, 21, 24}
            });
            var facadeLeft = new MatrixFacade(left);
            var facadeRight = new MatrixFacade(right);
            try
            {
                //facadeLeft.SaveToDb("Test1");
                //facadeRight.SaveToDb("Test2");
                facadeLeft.LoadFromDb("Test2");
                facadeRight.LoadFromDb("Test1");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
