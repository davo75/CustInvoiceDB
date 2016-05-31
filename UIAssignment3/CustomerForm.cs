/// <summary>
/// Displays the customer form for editing an existing customer details or
/// for adding a new customer
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
    public partial class CustomerForm : Form
    {
        /// <summary>
        /// The purpose of customer form; either edit or add
        /// </summary>
        public string purpose; 
        /// <summary>
        /// Reference to parent form
        /// </summary>
        public MainForm parent;

        private BindingSource formDataSource = null;

        /// <summary>
        /// Constructor initialises the UI components for the customer form
        /// </summary>
        public CustomerForm(BindingSource formDataSource)
        {
            InitializeComponent();
            //disable automatic validation. This will be handled by an errorProvider class instead.
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.formDataSource = formDataSource;
        }

        /// <summary>
        /// Closes the form when the cancel button is clicked
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Even arguments</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Called when customer form first loads.
        /// </summary>
        /// <remarks>
        /// If adding a new customer all fields except customer number are empty ready for input. 
        /// If editing an existing customer all fields are populated ready for modification except customer number.</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            //set form theme
            showTheme(parent.theme);

            //if adding a new customer
            if (purpose.Equals("Add"))
            {
                //set a new customer number
                //txtBoxCustNum.Text = parent.getNewCustNum();
            }
            //if editing an existing customer
            else if (purpose.Equals("Edit"))
            {
                //get the customer number
                //txtBoxCustNum.Text = parent.currentSelectedCustomer.CustNum;

                bindCustDetails();

                //hide the all fields reqd label
                lblAllReqd.Visible = false;
                //populate form fields with customer details
                //fillCustomerDetails();
            }
            //make the first editable text input active (company)
            this.ActiveControl = txtBoxCompany;
        }


        public void bindCustDetails()
        {
            txtBoxCustNum.DataBindings.Add("Text", formDataSource, "CustNum", true);
            txtBoxFirstName.DataBindings.Add("Text", formDataSource, "FirstName", true);
            txtBoxLastName.DataBindings.Add("Text", formDataSource, "LastName", true);
            txtBoxCompany.DataBindings.Add("Text", formDataSource, "Company", true);
            txtBoxStreet.DataBindings.Add("Text", formDataSource, "StreetName", true);
            txtBoxSuburb.DataBindings.Add("Text", formDataSource, "Suburb", true);
            cboxState.DataBindings.Add("Text", formDataSource, "AddressState", true);
            txtBoxPostCode.DataBindings.Add("Text", formDataSource, "PostCode", true);
            txtBoxPhone.DataBindings.Add("Text", formDataSource, "ContactPhone", true);
        }

        /// <summary>
        /// Changes the interface baground image to the selected theme
        /// </summary>
        /// <param name="theTheme">The name of the theme</param>
        private void showTheme(string theTheme)
        {

            switch (theTheme)
            {
                case "Light":
                    //set background image
                    Image lightImage = new Bitmap(UIAssignment3.Properties.Resources.light);
                    this.BackgroundImage = lightImage;
                    //Customer Details Box text colours
                    gBoxCustFormDetails.ForeColor = Color.White;
                    gBoxCustFormDetails.BackColor = Color.Transparent;
                    break;
                case "Dark":
                    //set background image
                    Image darkImage = new Bitmap(UIAssignment3.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //Customer Details Box text colours
                    gBoxCustFormDetails.ForeColor = Color.White;
                    gBoxCustFormDetails.BackColor = Color.Transparent;
                    break;
                default:
                    //remove background image
                    this.BackgroundImage = null;
                    ///Customer Details Box text colours
                    gBoxCustFormDetails.ForeColor = SystemColors.ControlText;
                    gBoxCustFormDetails.BackColor = SystemColors.Control;
                    break;
            }
        }

        /// <summary>
        /// Saves the customer details 
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnCustSave_Click(object sender, EventArgs e)
        {
            //if saving a new customer
            if (purpose.Equals("Add"))
            {
                //check all fields ahve been filled in
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    //if no erros then create the customer
                    //createNewCustomer();
                    saveCust();
                    //close the form
                    this.Dispose();
                }
            }
            //if editing a customer
            else if (purpose.Equals("Edit"))
            {
                //check all fields have been filled in
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    //if no errors then update the customer's details
                    //updateCustomerDetails();
                    formDataSource.EndEdit();
                    parent.saveCustToDB();
                    //close the form
                    this.Dispose();
                }
            }
        }

        

        /// <summary>
        /// Create a new customer from details entered into the customer form
        /// </summary>
        /// 
        private void saveCust()
        {

            DataRow newRow = parent.ds.Tables["Customers"].NewRow();
            newRow["Company"] = txtBoxCompany.Text;
            newRow["FirstName"] = txtBoxFirstName.Text;
            newRow["LastName"] = txtBoxLastName.Text;
            newRow["StreetName"] = txtBoxStreet.Text;
            newRow["Suburb"] = txtBoxSuburb.Text;
            newRow["AddressState"] = cboxState.Text;
            newRow["PostCode"] = txtBoxPostCode.Text;
            newRow["ContactPhone"] = txtBoxPhone.Text;

            parent.ds.Tables["Customers"].Rows.Add(newRow);
            parent.saveCustToDB();
        }
       
        /// <summary>
        /// Displays error message if company name field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxCompany_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxCompany.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxCompany, "Please enter a company name");
            }

            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if first name field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxFirstName_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (string.IsNullOrEmpty(this.txtBoxFirstName.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxFirstName, "Please enter a first name");
            }
            
            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if last name field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxLastName_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxLastName.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxLastName, "Please enter a last name");
            }
           
            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if street name field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxStreet_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxStreet.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxStreet, "Please enter a street name");
            }
           
            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if suburb field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxSuburb_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxSuburb.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxSuburb, "Please enter a suburb");
            }
           
            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if state field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void cboxState_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.cboxState.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(cboxState, "Please select a state");
            }
           
            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if post code field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxPostCode_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxPostCode.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxPostCode, "Please enter a post code");
            }
            
            e.Cancel = cancel;
        }

        /// <summary>
        /// Displays error message if contact number field is empty
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxPhone.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxPhone, "Please enter a contact number");
            }
           
            e.Cancel = cancel;
        }

        /// <summary>
        /// Clears company field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxCompany_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxCompany, string.Empty);
        }

        /// <summary>
        /// Clears first name field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxFirstName_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxFirstName, string.Empty);
        }

        /// <summary>
        /// Clears last name field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxLastName_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxLastName, string.Empty);
        }

        /// <summary>
        /// Clears street address field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxStreet_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxStreet, string.Empty);
        }

        /// <summary>
        /// Clears suburb field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxSuburb_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxSuburb, string.Empty);
        }

        /// <summary>
        /// Clears state field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void cboxState_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.cboxState, string.Empty);
        }

        /// <summary>
        /// Clears post code field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxPostCode_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxPostCode, string.Empty);
        }

        /// <summary>
        /// Clears contact phone field error message
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void txtBoxPhone_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxPhone, string.Empty);
        }
    }
}
