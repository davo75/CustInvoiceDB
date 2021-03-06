﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace UIAssignment3
{
    /// <summary>
    /// Displays the main form used for viewing customers and invoices.
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 25/4/2016
    /// </remarks>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Current name of selected theme
        /// </summary>
        internal string theme;

        /// <summary>
        /// Main dataset to hold database table data
        /// </summary>
        internal DataSet ds;
        /// <summary>
        /// Binding source for the customer table
        /// </summary>
        private BindingSource custBS;
        /// <summary>
        /// Binding source for the invoice table
        /// </summary>
        internal BindingSource invBS;
        /// <summary>
        /// Binding source for the invoice items table
        /// </summary>
        internal BindingSource invItemBS;
        /// <summary>
        /// Data object that links to the database and performs queries
        /// </summary>
        private DataConnect theData;
        /// <summary>
        /// Connection string for db connection
        /// </summary>
        private string connStr;

        /// <summary>
        /// Constructor initialises the UI components of the main form and sets db connection string
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //connStr = "server=223.27.22.124;User Id=davep001;password=Davo001;database=041110777_invoice";
            connStr = "server=127.0.0.1;User Id=root;password=dave;database=041110777_invoice";
        }

        /// <summary>
        /// Connects to the database and sets up initial state of the main interac
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //create a new DataConnect object and connect to the database
            theData = new DataConnect(connStr);

            //set up the data adapters and query commands
            theData.initialiseCommands();

            //setup the dataset and fill with data from the database
            ds = theData.loadData();

            //setup starting state of main form
            setupInitialState();

            //bind controls to the data
            bindControlsToData();
        }

        /// <summary>
        /// Sets the inital state of the main form once loaded
        /// </summary>
        /// <remarks>
        /// Sets up the customer and invoice list boxes with the first item selected in each list.
        /// Fills in the customer and invoice details and initialises the theme to default.</remarks>
        /// 
        private void setupInitialState()
        {

            //create binding source for customers and sort by First Name
            custBS = new BindingSource();
            custBS.DataSource = ds.Tables["Customers"];
            custBS.Sort = "FirstName";

            //show customer first names in the listbox
            lbCustomers.DataSource = custBS;
            lbCustomers.DisplayMember = "FirstName";
            lbCustomers.ValueMember = "CustNum";

            //set the binding source for the invoice numbers to the main customer binding source. 
            //This sets up a master-details relationship.
            invBS = new BindingSource();
            invBS.DataSource = custBS;
            //point to the relation data
            invBS.DataMember = "RelCustInv";

            //set the list box to the same data source but only display the invoice numbers
            lbInvoiceNum.DataSource = invBS;
            lbInvoiceNum.DisplayMember = "InvoiceNum";
            lbInvoiceNum.ValueMember = "InvoiceNum";

            //set the binding source for the invoice numbers to the main customer binding source. 
            //This sets up a master-details relationship.
            invItemBS = new BindingSource();
            invItemBS.DataSource = invBS;
            //point to the relation data
            invItemBS.DataMember = "RelInvItems";

            //set payment status message font to bold
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);

            //set the theme selection to Default
            cboxTheme.SelectedIndex = 0;
        }

        /// <summary>
        /// Binds the various controls and text fields to their binding sources
        /// </summary>
        private void bindControlsToData()
        {
            //bind customer details to the text fields
            bindCustDetails();

            //fill up dataviewgrid with invoice items      
            dgInvoiceDetails.DataSource = invItemBS;

            //remove the invoice number and item number columns
            dgInvoiceDetails.Columns.RemoveAt(0);
            dgInvoiceDetails.Columns.RemoveAt(0);

            //set custom width for item name column
            dgInvoiceDetails.Columns[0].Width = 147;
            //set custom width for description column
            dgInvoiceDetails.Columns[1].Width = 190;
            //set custom width for total cost column
            dgInvoiceDetails.Columns[4].Width = 100;

            //set up quantity column
            dgInvoiceDetails.Columns[2].HeaderText = "Quantity";
            dgInvoiceDetails.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //set up description column
            dgInvoiceDetails.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //set up cost column
            dgInvoiceDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //set up grid properties - basically make it so the grid is read only. User can't add or delete
            //rows or edit cells. Remove any row header columns.
            dgInvoiceDetails.AllowUserToAddRows = false;
            dgInvoiceDetails.AllowUserToDeleteRows = false;
            dgInvoiceDetails.RowHeadersVisible = false;
            dgInvoiceDetails.ReadOnly = true;
            dgInvoiceDetails.AutoGenerateColumns = false;
            dgInvoiceDetails.RowHeadersVisible = false;

            //bind Invoice Details groupbox title to invoice number. Also add some custom text to the binding.
            var binding = new Binding("Text", invBS, "InvoiceNum");
            binding.Format += delegate(object sentFrom, ConvertEventArgs convertEventArgs)
            {
                convertEventArgs.Value = "Items for Invoice Number: " + convertEventArgs.Value;
            };
            //add the binding to the groupbox title
            gbInvoiceDetails.DataBindings.Add(binding);

            //clear any default grid selections when it loads
            dgInvoiceDetails.ClearSelection();

            //set payment status for the selected invocie
            setPaymentStatus();

            //update the total invoice cost
            updateInvoiceTotalCost();
        }

        /// <summary>
        /// Updates the invoice total on the main form
        /// </summary>
        private void updateInvoiceTotalCost()
        {
            decimal invTotalCost = 0;

            //disable the edit and delete invoice buttons and set total cost to empty if no invoices to show
            if (dgInvoiceDetails.Rows.Count == 0)
            {
                tbTotalInvoiceCost.Text = string.Empty;
                btnEditInvoice.Enabled = false;
                btnDeleteInvoice.Enabled = false;
            }
            else
            {
                //enable the edit and delete invocie buttons
                btnEditInvoice.Enabled = true;
                btnDeleteInvoice.Enabled = true;

                //for each invoice item in the grid add up the costs
                foreach (DataGridViewRow row in dgInvoiceDetails.Rows)
                {
                    invTotalCost += Convert.ToDecimal(row.Cells["Total Cost"].Value);
                }

                //display the total cost as currency
                tbTotalInvoiceCost.Text = "$" + invTotalCost.ToString("#.00");
            }
        }

        /// <summary>
        /// Binds the customer data to their respective field
        /// </summary>
        private void bindCustDetails()
        {
            txtBoxCustNum.DataBindings.Add("Text", custBS, "CustNum");
            txtBoxFirstName.DataBindings.Add("Text", custBS, "FirstName");
            txtBoxLastName.DataBindings.Add("Text", custBS, "LastName");
            txtBoxCompany.DataBindings.Add("Text", custBS, "Company");
            txtBoxStreet.DataBindings.Add("Text", custBS, "StreetName");
            txtBoxSuburb.DataBindings.Add("Text", custBS, "Suburb");
            txtBoxState.DataBindings.Add("Text", custBS, "AddressState");
            txtBoxPostCode.DataBindings.Add("Text", custBS, "PostCode");
            txtBoxPhone.DataBindings.Add("Text", custBS, "ContactPhone");
        }

        /// <summary>
        /// Saves a customer record to the database
        /// </summary>
        public void saveCustToDB(string purpose)
        {
            //run the insert command on the data adapter
            theData.custDA.Update(ds, "Customers");
            //update the dataset
            ds.AcceptChanges();
            //clear any default selection on the data grid view
            dgInvoiceDetails.ClearSelection();

            //if the customer is a new customer then select the customer name in the listbox
            if (purpose.Equals("Add"))
            {
                //set the selection in the customer name listbox to the new customer number i.e. the last row
                DataRow lastRow = ds.Tables["Customers"].Rows[ds.Tables["Customers"].Rows.Count - 1];
                lbCustomers.SelectedValue = lastRow["CustNum"].ToString();
            }
        }

        /// <summary>
        /// Updates the edited invoice.
        /// Updating an existing invoice in the database is a two part process. Firstly the invoice table is updated
        /// with the main invoice details like payment status, payment date and due dates. Next the invoice items for 
        /// the invoice are inserted into the invoice items table. To avoid duplicates and complex updating any 
        /// existing invoice items are first deleted and then re-added.       
        /// </summary>
        /// <param name="dg">DataGridView of invoice items</param>
        /// <param name="currentInvoiceNum">The invoice number that is currently being edited</param>
        public void updateInvInDB(DataGridView dg, int currentInvoiceNum)
        {
            //update the main invoice details
            theData.invDA.Update(ds, "Invoices");
            ds.AcceptChanges();

            //update invoice items into db
            theData.updateInvoice(dg, currentInvoiceNum);
            ds.AcceptChanges();
            //refresh the data so the new items are displayed from the database onto the grid
            theData.refreshData(ds, "InvoiceItems");

            //clear any default selection on the data grid view
            dgInvoiceDetails.ClearSelection();
        }

        /// <summary>
        /// Adds a new invoice to the database.
        /// The main details of the new invoice are added to the database. The invoice  number is returned from 
        /// the database by a stored procedure.
        /// </summary>
        /// <returns>The new invoice number that was inserted into the database.</returns>
        public int addInvToDB()
        {
            //insert new invoice into the database
            theData.invDA.Update(ds, "Invoices");
            //update the dataset
            ds.AcceptChanges();

            //get the new invoice number from the database via a stored procedure
            int newInvoiceNum = Convert.ToInt32(theData.invDA.InsertCommand.Parameters["@InvoiceNum"].Value.ToString());
            //return the new invoice number 
            return newInvoiceNum;
        }

        /// <summary>
        /// Adds a new invoice's items to the database.
        /// </summary>
        /// <param name="dg">DataGridView of invoice items</param>
        /// <param name="newInvoiceNum">The invoice number of the invoice to update</param>
        public void saveInvToDB(DataGridView dg, int newInvoiceNum)
        {
            //save the invoice items to the database
            theData.saveInvoice(dg, newInvoiceNum);
            //update the dataset
            ds.AcceptChanges();
            //manually refresh to invoice items data table - this refresh would happen automatically if it was
            //bound to a binding source but since we're using custom select and insert commands we need to do it
            //manually
            theData.refreshData(ds, "InvoiceItems");
            //update the invoice total cost to reflect any changes
            updateInvoiceTotalCost();

            //clear any default selection on the data grid view
            dgInvoiceDetails.ClearSelection();
            //set the selection in the invoice numbers listbox to the new invoice number
            lbInvoiceNum.SelectedIndex = lbInvoiceNum.Items.Count - 1;
        }

        /// <summary>
        /// Add column headers to Invoice details table
        /// </summary>
        private void addColumnstoTable()
        {
            //add Item number column
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Item Num";
            col1.DataPropertyName = "ItemNum";
            col1.Width = 80;
            col1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col1);

            //add item name column
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Item";
            col2.DataPropertyName = "ItemName";
            col2.Width = 117;
            dgInvoiceDetails.Columns.Add(col2);

            //add item description column
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Description";
            col3.DataPropertyName = "ItemDesc";
            col3.Width = 200;
            dgInvoiceDetails.Columns.Add(col3);

            //add item cost column
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Cost";
            col4.DataPropertyName = "ItemCost";
            col4.Width = 90;
            col4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col4);

            //add item quantity column
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Qty";
            col5.DataPropertyName = "ItemQty";
            col5.Width = 60;
            col5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col5);

            //add item total cost colum
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Total Cost";
            col6.DataPropertyName = "TotalCost";
            col6.Width = 90;
            col6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col6);

            //clear any default table selections
            dgInvoiceDetails.ClearSelection();
        }


        /// <summary>
        /// Set the payment status of an invoice
        /// </summary>
        private void setPaymentStatus()
        {
            //status message
            string status = string.Empty;

            try
            {
                //check that an invoice number has been selected
                if (lbInvoiceNum.GetItemText(lbInvoiceNum.SelectedItem) != "")
                {
                    //get the current selected row in the binding source
                    DataRowView current = (DataRowView)invBS.Current;
                    //extract the invoice number from the selected data row
                    int currentInvoiceNum = Int16.Parse(current["InvoiceNum"].ToString());

                    //if the invoice has been paid display a paid message on the main form
                    if (current["PaymentStatus"].ToString().Equals("True"))
                    {
                        DateTime paidDate = (DateTime)current["PaymentDate"];
                        status = "Paid on " + paidDate.ToString("dd/MM/yyy");
                        lblStatus.ForeColor = System.Drawing.Color.Green;

                    }
                    //if unpaid then check if the invoice is overdue
                    else
                    {
                        DateTime dueDate = (DateTime)current["PaymentDueDate"];

                        if (DateTime.Compare(DateTime.Today, dueDate) > 0)
                        {
                            status = "Overdue. Payment was due on " + dueDate.ToString("dd/MM/yyyy");
                            lblStatus.ForeColor = System.Drawing.Color.Red;

                        }
                        //if not overdue just display when it's due for payment
                        else
                        {
                            status = "Unpaid. Payment due on " + dueDate.ToString("dd/MM/yyyy");
                            lblStatus.ForeColor = System.Drawing.Color.Orange;

                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                //return the payment status message
                lblStatus.Text = status;
            }

        }

        /// <summary>
        /// Displays the Add Invoice form.
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //get the current selected row in the binding source
            DataRowView current = (DataRowView)custBS.Current;
            //get the customer number from the selected row
            int currentCustNum = Int16.Parse(current["CustNum"].ToString());

            //create an instance of the invoice form
            InvoiceForm addInvoiceForm = new InvoiceForm(invBS, currentCustNum);
            //set reference to the parent form
            addInvoiceForm.parent = this;
            //set the purpose of the form - either add or edit
            addInvoiceForm.purpose = "Add";
            //show the invoice form
            addInvoiceForm.ShowDialog();
        }

        /// <summary>
        /// Clears any text in the customer filter search input
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void lbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear any searches in the invoice search text box
            txtBoxInvSearch.Text = string.Empty;
            //updates the payment status for any selected invoice number
            setPaymentStatus();
            //update invoice total cost
            updateInvoiceTotalCost();
        }

        /// <summary>
        /// Clears any text in the invoices search field
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void lbInvoiceNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear any searches in the invoice search text box
            txtBoxInvSearch.Text = string.Empty;
            //updates the payment status for any selected invoice number
            setPaymentStatus();
            //update invoice total cost
            updateInvoiceTotalCost();
            //clear any default grid selections
            dgInvoiceDetails.ClearSelection();
        }

        /// <summary>
        /// Filters the customer list based on the text enterted into the filter search field
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //set the view
            DataView dvCustomers = ds.Tables["Customers"].DefaultView;
            //filter the customer list
            dvCustomers.RowFilter = "FirstName LIKE '" + tbSearchCust.Text + "%'";
        }

        /// <summary>
        /// Displays the Edit Invoice form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            //get the currently selected row in the customer binding source
            DataRowView current = (DataRowView)custBS.Current;
            //get the customer number from the selected row
            int currentCustNum = Int16.Parse(current["CustNum"].ToString());
            //create new instance of invoice form
            InvoiceForm editInvoiceForm = new InvoiceForm(invBS, currentCustNum);
            //set reference to parent form
            editInvoiceForm.parent = this;
            //set the purpose of the form - either add or edit
            editInvoiceForm.purpose = "Edit";
            //show the invoice form for editing
            editInvoiceForm.ShowDialog();
        }

        /// <summary>
        /// Deletes an invoice
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            //confirmation delete message dialog
            DialogResult deleteConfirm = MessageBox.Show("Are you sure you want to delete invoice " + lbInvoiceNum.GetItemText(lbInvoiceNum.SelectedItem) + "?",
                                                    "Delete Confirmation",
                                                    MessageBoxButtons.YesNo);
            //if deletion confirmed
            if (deleteConfirm == DialogResult.Yes)
            {
                //delete the invoice from the dataset and then update the database
                DataRow[] targetRow = ds.Tables["Invoices"].Select("InvoiceNum = " + (lbInvoiceNum.SelectedItem as DataRowView)["InvoiceNum"].ToString());
                targetRow[0].Delete();
                theData.invDA.Update(ds, "Invoices");
                ds.AcceptChanges();
            }
        }

        /// <summary>
        /// Handles the add customer menu item click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //display a customer form for adding a new customer
            showNewCustomerForm();
        }

        /// <summary>
        /// Displays a blank customer form
        /// </summary>
        private void showNewCustomerForm()
        {
            //create instance of customer form
            CustomerForm addCustForm = new CustomerForm(custBS);
            //set refrence back to this form
            addCustForm.parent = this;
            //set the pupose
            addCustForm.purpose = "Add";
            //show the form
            addCustForm.ShowDialog();
        }

        /// <summary>
        /// Handles delete customer menu item click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //initiates a customer delete
            deleteCustomer();
        }

        /// <summary>
        /// Deletes a customer
        /// </summary>
        private void deleteCustomer()
        {
            //get a reference to the customer from the data table
            DataRow[] targetRow = ds.Tables["Customers"].Select("CustNum = " + (lbCustomers.SelectedItem as DataRowView)["CustNum"].ToString());
            //check if the customer has any invoices
            DataRow[] childRows;
            childRows = targetRow[0].GetChildRows(theData.relCustInv);
            int numInvoices = childRows.Length;
            string deleteMsg = "Are you sure you want to delete customer " +
                            lbCustomers.GetItemText(lbCustomers.SelectedItem) +
                            "?";

            //if the customer also has invoices inform the user that they will also be deleted along with the customer
            if (numInvoices > 0)
            {
                deleteMsg = "Are you sure you want to delete customer " +
                            lbCustomers.GetItemText(lbCustomers.SelectedItem) +
                            "? \nThe customer has " + numInvoices + " invoice(s) that will also be deleted.";
            }

            //if the customer has no invoices then just display a delete confirmation dialog for the customer
            DialogResult deleteConfirm = MessageBox.Show(deleteMsg, "Delete Confirmation", MessageBoxButtons.YesNo);

            //if deletion confirmed
            if (deleteConfirm == DialogResult.Yes)
            {
                //delete customer from dataset then database
                targetRow[0].Delete();
                theData.custDA.Update(ds, "Customers");
                ds.AcceptChanges();
            }
        }


        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles edit customer menu item  click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //initiates an edit customer
            showEditCustomerForm();
        }

        /// <summary>
        /// Displays edit customer form
        /// </summary>
        private void showEditCustomerForm()
        {
            //create a new instance of the customer form
            CustomerForm editCustForm = new CustomerForm(custBS);
            //set reference to parent form
            editCustForm.parent = this;
            //set purpose of form to edit
            editCustForm.purpose = "Edit";
            //show the form
            editCustForm.ShowDialog();
        }

        /// <summary>
        /// Handles invoice search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if search box not empty
            if (!txtBoxInvSearch.Text.Equals(string.Empty))
            {
                //search for the invoice number entered into the search box
                findInvoice(Int16.Parse(txtBoxInvSearch.Text));
            }
        }

        /// <summary>
        /// Finds an invoice by invoice number and sets selection on customer and invoice lists.
        /// If not found a message box is displayed informing user of no search results.
        /// </summary>
        /// <param name="invoiceNum">The invoice number to search for</param>
        private void findInvoice(int invoiceNum)
        {
            //clear the customer filter first otherwise customer may not be displayed when searching for invoice
            tbSearchCust.Text = string.Empty;

            try
            {
                //find the invoice number
                DataRow[] result = ds.Tables["Invoices"].Select("InvoiceNum = " + invoiceNum);
                //if found
                if (result.Length > 0)
                {
                    //get the customer assosciated with the invoice
                    DataRow parentRow = result[0].GetParentRow(theData.relCustInv);
                    //get the customer number and select it in the customer listbox
                    int customerNum = Int16.Parse(parentRow[0].ToString());
                    lbCustomers.SelectedValue = customerNum;
                    //select the invoice in the invoice listbox
                    lbInvoiceNum.SelectedValue = invoiceNum;
                }
                else
                {
                    //display invoice not found message
                    MessageBox.Show("No results for invoice number: " + invoiceNum, "Search Results");
                    //clear any searches in the invoice search text box
                    txtBoxInvSearch.Text = string.Empty;
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Can't find it! " + ex.Message);
            }
        }

        /// <summary>
        /// Displays pop-up list of invoice numbers when searching for invoices
        /// </summary>
        private void fillSearchAutoComplete()
        {
            //create new collection for invoice numbers
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            foreach (DataRow row in ds.Tables["Invoices"].Rows)
            {
                collection.Add(row[0].ToString());

            }
            //add the pop-up list to the search field so it is displayed when a search is performed
            txtBoxInvSearch.AutoCompleteCustomSource = collection;
        }

        /// <summary>
        /// Changes the interface theme
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void cboxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

            //name of theme currently selected
            theme = cboxTheme.ComboBox.GetItemText(cboxTheme.ComboBox.SelectedItem);

            switch (theme)
            {
                case "Light":
                    //settings for light theme
                    Image lightImage = new Bitmap(UIAssignment3.Properties.Resources.light);
                    this.BackgroundImage = lightImage;
                    //Customer List Box
                    gBoxCustomers.ForeColor = Color.White;
                    gBoxCustomers.BackColor = Color.Transparent;
                    //Customer Details Box
                    gBoxCustomerDetails.ForeColor = Color.White;
                    gBoxCustomerDetails.BackColor = Color.Transparent;
                    //Invoice List Box
                    gBoxInvoices.ForeColor = Color.White;
                    gBoxInvoices.BackColor = Color.Transparent;
                    //Invoice Details Box
                    gbInvoiceDetails.ForeColor = Color.White;
                    gbInvoiceDetails.BackColor = Color.Transparent;

                    dgInvoiceDetails.ForeColor = Color.Black;
                    //Menu Strip
                    msFile.ForeColor = Color.White;
                    msFile.BackColor = Color.Transparent;
                    break;
                case "Dark":
                    //settings for dark theme
                    Image darkImage = new Bitmap(UIAssignment3.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //Customer List Box
                    gBoxCustomers.ForeColor = Color.White;
                    gBoxCustomers.BackColor = Color.Transparent;
                    //Customer Details Box
                    gBoxCustomerDetails.ForeColor = Color.White;
                    gBoxCustomerDetails.BackColor = Color.Transparent;
                    //Invoice List Box
                    gBoxInvoices.ForeColor = Color.White;
                    gBoxInvoices.BackColor = Color.Transparent;
                    //Invoice Details Box
                    gbInvoiceDetails.ForeColor = Color.White;
                    gbInvoiceDetails.BackColor = Color.Transparent;

                    dgInvoiceDetails.ForeColor = Color.Black;
                    //Menu Strip
                    msFile.ForeColor = Color.White;
                    msFile.BackColor = Color.Transparent;
                    break;

                default:
                    //settings for default theme
                    this.BackgroundImage = null;
                    //Customer List Box
                    gBoxCustomers.ForeColor = SystemColors.ControlText;
                    gBoxCustomers.BackColor = SystemColors.Control;
                    //Customer Details Box
                    gBoxCustomerDetails.ForeColor = SystemColors.ControlText;
                    gBoxCustomerDetails.BackColor = SystemColors.Control;
                    //Invoice List Box
                    gBoxInvoices.ForeColor = SystemColors.ControlText;
                    gBoxInvoices.BackColor = SystemColors.Control;
                    //Invoice Details Box
                    gbInvoiceDetails.ForeColor = SystemColors.ControlText;
                    gbInvoiceDetails.BackColor = SystemColors.Control;
                    //Menu Strip
                    msFile.ForeColor = SystemColors.ControlText;
                    msFile.BackColor = SystemColors.Control;
                    //Tool Strip
                    tsMain.ForeColor = SystemColors.ControlText;
                    tsMain.BackColor = Color.Gainsboro;
                    //search button on tool strip
                    btnSearch.ForeColor = SystemColors.ControlText;
                    btnSearch.BackColor = SystemColors.Control;
                    break;
            }
        }

        /// <summary>
        /// Handles add new customer button click by opening blank customer form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            showNewCustomerForm();
        }

        /// <summary>
        /// Handles edit customer button click by opening customer form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnEditCust_Click(object sender, EventArgs e)
        {
            showEditCustomerForm();
        }

        /// <summary>
        /// Handles delete customer button click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnDeleteCust_Click(object sender, EventArgs e)
        {
            deleteCustomer();
        }

        /// <summary>
        /// Prevents the user from entering non-numerical characters into the invoice search box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInvSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only accept numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}