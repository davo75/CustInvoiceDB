/// <summary>
/// Displays the login form and authenticates the user
/// <sumary>
/// <remarks>
/// author: David Pyle 041110777
/// version: 1.0
/// date: 25/4/2016
/// </remarks>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment3
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Login username
        /// </summary>
        private const string USERNAME = "";
        /// <summary>
        /// Login password
        /// </summary>
        private const string PASSWORD = "";

        /// <summary>
        /// Constructor initialise the UI components on the login form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks the login details entered by the user
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments arguments</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check if the username and password entered matches the correct username and password
            if (txtBoxUser.Text.Equals(USERNAME) && txtBoxPassword.Text.Equals(PASSWORD))
            {
                //login ok                            
                DialogResult = DialogResult.OK;
            }
            else
            {
                //display login error
                lblLoginError.Text = "Invalid username or password";                
            }
        }

        /// <summary>
        /// Clears any error messages on the login form
        /// </summary>
        /// <remarks>
        /// The error message is cleared once the user begins entering text into either the 
        /// username or password field</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxUser_TextChanged(object sender, EventArgs e)
        {
            //clear the error
            lblLoginError.Text = string.Empty;
        }
    }
}
