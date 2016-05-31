/// <summary>
/// The main class of the application. 
/// <sumary>
/// <remarks>
/// author: David Pyle 041110777
/// version: 1.0
/// date: 25/4/2016
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment3
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
            //create a new login form
            LoginForm fLogin = new LoginForm();
            //if login is successful then show the main form
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }           
        }
    }
}
