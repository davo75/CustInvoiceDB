/// <summary>
/// Displays the main form used for viewing customers and invoices.
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
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace UIAssignment3
{
    public partial class MainForm : Form
    {
       
        /// <summary>
        /// Current name of selected theme
        /// </summary>
        internal string theme;


        //Database stuff
        MySqlConnection gConn = null;
        MySqlDataAdapter custDA = null;
        MySqlDataAdapter invDA = null;
        MySqlDataAdapter itemDA = null;
        MySqlDataAdapter invItemDA = null;
        public DataSet ds = null; 
        DataRelation relCustInv;

        public BindingSource custBS;
        BindingSource invBS;
        public BindingSource invItemBS;

        /// <summary>
        /// Constructor initialises the UI components of the main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //get connection to database
                gConn = openTheConnection();

                //set up the data adapters and query commands
                initialiseCommands();
                //setup the dataset
                ds = new DataSet("CustInvoices");
                //fill dataset with data from database
                initialiseDataSet();
                //setup starting state of main form
                setupInitialState();
                //bind controls to the data
                bindControlsToData();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());

            }
            finally
            {
                //close the connection
                if (gConn != null)
                {
                    gConn.Close();
                }
            }
        }


        /// <summary>
        /// Sets up the data adapters and query commands for the customer, invoice, item and invoice item tables
        /// </summary>
        private void initialiseCommands()
        {

            //setup adapter for customer table
            custDA = new MySqlDataAdapter();
            custDA.SelectCommand = new MySqlCommand("SELECT * FROM Customer", gConn);
            custDA.TableMappings.Add("Table", "Customers");
            //setup custom commands for customer adapter
            custDA.InsertCommand = new MySqlCommand("InsertCust", gConn);
            custDA.InsertCommand.CommandType = CommandType.StoredProcedure;
            custDA.InsertCommand.Parameters.Add("@CustNum", MySqlDbType.Int16, 5, "CustNum").Direction = ParameterDirection.Output;
            custDA.InsertCommand.Parameters.Add("@FirstName", MySqlDbType.VarChar, 30, "FirstName");
            custDA.InsertCommand.Parameters.Add("@LastName", MySqlDbType.VarChar, 30, "LastName");
            custDA.InsertCommand.Parameters.Add("@StreetName", MySqlDbType.VarChar, 30, "StreetName");
            custDA.InsertCommand.Parameters.Add("@Suburb", MySqlDbType.VarChar, 20, "Suburb");
            custDA.InsertCommand.Parameters.Add("@AddressState", MySqlDbType.VarChar, 30, "AddressState");
            custDA.InsertCommand.Parameters.Add("@PostCode", MySqlDbType.VarChar, 10, "PostCode");
            custDA.InsertCommand.Parameters.Add("@ContactPhone", MySqlDbType.VarChar, 30, "ContactPhone");
            custDA.InsertCommand.Parameters.Add("@Company", MySqlDbType.VarChar, 30, "Company");

            //custom update command for customer table
            custDA.UpdateCommand = new MySqlCommand(@"  UPDATE Customer 
                                                        SET FirstName = @FirstName, LastName = @LastName, StreetName = @Street, Suburb = @Suburb, AddressState = @State, PostCode = @PostCode, ContactPhone = @Phone, Company = @Company
                                                        WHERE CustNum = @CustNum", gConn);

            custDA.UpdateCommand.Parameters.Add("@CustNum", MySqlDbType.Int16, 5, "CustNum");
            custDA.UpdateCommand.Parameters.Add("@FirstName", MySqlDbType.VarChar, 30, "FirstName");
            custDA.UpdateCommand.Parameters.Add("@LastName", MySqlDbType.VarChar, 30, "LastName");
            custDA.UpdateCommand.Parameters.Add("@Street", MySqlDbType.VarChar, 30, "StreetName");
            custDA.UpdateCommand.Parameters.Add("@Suburb", MySqlDbType.VarChar, 20, "Suburb");
            custDA.UpdateCommand.Parameters.Add("@State", MySqlDbType.VarChar, 30, "AddressState");
            custDA.UpdateCommand.Parameters.Add("@PostCode", MySqlDbType.VarChar, 10, "PostCode");
            custDA.UpdateCommand.Parameters.Add("@Phone", MySqlDbType.VarChar, 30, "ContactPhone");
            custDA.UpdateCommand.Parameters.Add("@Company", MySqlDbType.VarChar, 30, "Company");

            //custDA.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            custDA.DeleteCommand = new MySqlCommand("DELETE FROM Customer WHERE CustNum = @CustNum", gConn);
            custDA.DeleteCommand.Parameters.Add("@CustNum", MySqlDbType.Int16, 5, "CustNum");

            invDA = new MySqlDataAdapter();
            invDA.SelectCommand = new MySqlCommand("SELECT * FROM Invoice", gConn);
            invDA.TableMappings.Add("Table", "Invoices");



            invDA.UpdateCommand = new MySqlCommand(@"   UPDATE Invoice 
                                                        SET PaymentStatus = @PaymentStatus, PaymentDate = @PaymentDate, PaymentDueDate = @PaymentDueDate 
                                                        WHERE InvoiceNum = @InvoiceNum", gConn);
            invDA.UpdateCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5, "InvoiceNum");
            invDA.UpdateCommand.Parameters.Add("@PaymentStatus", MySqlDbType.Int16, 2, "PaymentStatus");
            invDA.UpdateCommand.Parameters.Add("@PaymentDate", MySqlDbType.Date).SourceColumn = "PaymentDate";
            invDA.UpdateCommand.Parameters.Add("@PaymentDueDate", MySqlDbType.Date).SourceColumn = "PaymentDueDate";

            //setup custom commands for invoice adapter
            invDA.InsertCommand = new MySqlCommand("InsertInv", gConn);
            invDA.InsertCommand.CommandType = CommandType.StoredProcedure;
            invDA.InsertCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5, "InvoiceNum").Direction = ParameterDirection.Output;
            invDA.InsertCommand.Parameters.Add("@PaymentStatus", MySqlDbType.Int16, 2, "PaymentStatus");
            invDA.InsertCommand.Parameters.Add("@PaymentDate", MySqlDbType.Date).SourceColumn = "PaymentDate";
            invDA.InsertCommand.Parameters.Add("@PaymentDueDate", MySqlDbType.Date).SourceColumn = "PaymentDueDate";
            invDA.InsertCommand.Parameters.Add("@CustNum", MySqlDbType.Int16, 5, "CustNum");

            invDA.DeleteCommand = new MySqlCommand("DELETE FROM Invoice WHERE InvoiceNum = @InvoiceNum", gConn);
            invDA.DeleteCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5, "InvoiceNum");

            //setup adapter for invoice items table
            invItemDA = new MySqlDataAdapter();
            invItemDA.SelectCommand = new MySqlCommand(@"SELECT invoiceitem.InvoiceNum, item.ItemNum, item.ItemName AS 'Item', item.Description, invoiceitem.Qty, item.Cost, (invoiceitem.qty*item.cost) AS 'Total Cost' 
                                                            FROM invoiceitem, item WHERE item.ItemNum = invoiceitem.ItemNum", gConn);
            invItemDA.TableMappings.Add("Table", "InvoiceItems");

            //setup custom commands for invoice items adapter
            //Insert Command
            invItemDA.InsertCommand = new MySqlCommand("INSERT INTO InvoiceItem (InvoiceNum, ItemNum, Qty) VALUES (@InvoiceNum, @ItemNum, @Qty)");
            invItemDA.InsertCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5);
            invItemDA.InsertCommand.Parameters.Add("@ItemNum", MySqlDbType.Int16, 5);
            invItemDA.InsertCommand.Parameters.Add("@Qty", MySqlDbType.Int16, 5);
            //Delete Command
            invItemDA.DeleteCommand = new MySqlCommand("DELETE FROM InvoiceItem WHERE InvoiceNum = @InvoiceNum");
            invItemDA.DeleteCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5);

            //setup adapter for items table
            itemDA = new MySqlDataAdapter();
            itemDA.SelectCommand = new MySqlCommand("Select * FROM Item ORDER BY ItemName", gConn);
            itemDA.TableMappings.Add("Table", "Items");
        }


        /// <summary>
        /// Sets up the main dataset with data from each of the database tables and sets up the relationships
        /// </summary>
        private void initialiseDataSet()
        {
            //fill dataset with customer data
            custDA.Fill(ds, "Customers");
            //fill dataset with invoice data
            invDA.Fill(ds, "Invoices");
            //fill dataset with invoice items data
            invItemDA.Fill(ds, "InvoiceItems");
            //fill dataset with  items data
            itemDA.Fill(ds, "Items");

            //create a dataset relationship between the Customer (Master) and Invoice (Detail) data tables            
            relCustInv = new DataRelation("RelCustInv", ds.Tables["Customers"].Columns["CustNum"], ds.Tables["Invoices"].Columns["CustNum"]);
            ds.Relations.Add(relCustInv);

            //create a dataset relationship between the Invoice (Master) and InvoiceItems (Detail) data tables            
            DataRelation relInvItems = new DataRelation("RelInvItems", ds.Tables["Invoices"].Columns["InvoiceNum"], ds.Tables["InvoiceItems"].Columns["InvoiceNum"]);
            ds.Relations.Add(relInvItems);
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

            //set the binding source for the invoice numbers to the main customer binding source. This sets up a master-details relationship.
            invBS = new BindingSource();
            invBS.DataSource = custBS;
            //point to the relation data
            invBS.DataMember = "RelCustInv";

            //set the list box to the same data source but only display the invoice numbers
            lbInvoiceNum.DataSource = invBS;
            lbInvoiceNum.DisplayMember = "InvoiceNum";
            lbInvoiceNum.ValueMember = "InvoiceNum";

            //set the binding source for the invoice numbers to the main customer binding source. This sets up a master-details relationship.
            invItemBS = new BindingSource();
            invItemBS.DataSource = invBS;
            //point to the relation data
            invItemBS.DataMember = "RelInvItems";

            //set payment status message font to bold
            lblStatus.Font = new Font(lblStatus.Font, FontStyle.Bold);

        }

        /// <summary>
        /// Binds the various controls and text fields to their binding sources
        /// </summary>
        private void bindControlsToData()
        {
            //bind customer details to the text fields
            bindCustDetails();

            //fill up dataviewgrid with invoice items
            ////stop table columns from generating automatically
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

            dgInvoiceDetails.Columns[2].HeaderText = "Quantity";
            dgInvoiceDetails.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgInvoiceDetails.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgInvoiceDetails.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgInvoiceDetails.AllowUserToAddRows = false;
            dgInvoiceDetails.AllowUserToDeleteRows = false;
            dgInvoiceDetails.RowHeadersVisible = false;
            dgInvoiceDetails.ReadOnly = true;
            dgInvoiceDetails.AutoGenerateColumns = false;
            dgInvoiceDetails.RowHeadersVisible = false;

            dgInvoiceDetails.ClearSelection();

            //set payment status
            setPaymentStatus();

            updateInvoiceTotalCost();

        }

        /// <summary>
        /// Updates the invoice total on the main form
        /// </summary>
        private void updateInvoiceTotalCost()
        {
            decimal invTotalCost = 0;

            if (dgInvoiceDetails.Rows.Count == 0)
            {
                tbTotalInvoiceCost.Text = string.Empty;
                btnEditInvoice.Enabled = false;
                btnDeleteInvoice.Enabled = false;
            }
            else
            {
                btnEditInvoice.Enabled = true;
                btnDeleteInvoice.Enabled = true;

                foreach (DataGridViewRow row in dgInvoiceDetails.Rows)
                {
                    //Console.WriteLine("Total Cost for row is: " + row.Cells["Total Cost"].Value);                    
                    invTotalCost += Convert.ToDecimal(row.Cells["Total Cost"].Value);
                }
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
        /// Eastablishes database connection
        /// </summary>
        /// <returns></returns>
        private MySqlConnection openTheConnection()
        {
            //open a connection to the database and return it
            string theConnString = "server=223.27.22.124;"
                  + "User Id=davep001;password=Davo001;"
                  + "database=041110777_invoice";
            //string theConnString = "server=127.0.0.1;"
            //      + "User Id=root;password=dave;"
            //      + "database=041110777_invoice";
            MySqlConnection conn = new MySqlConnection(theConnString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Saves a customer record to the database
        /// </summary>
        public void saveCustToDB()
        {
            //run the insert command on the data adapter
            custDA.Update(ds, "Customers");
            //update the dataset
            ds.AcceptChanges();
            //clear any default selection on the data grid view
            dgInvoiceDetails.ClearSelection();            
            //set the selection in the customer name listbox to the new customer number i.e. the last row
            DataRow lastRow = ds.Tables["Customers"].Rows[ds.Tables["Customers"].Rows.Count-1];            
            lbCustomers.SelectedValue = lastRow["CustNum"].ToString();
            
        }


        /// <summary>
        /// used when updating an existing invoice in the database
        /// this is a two part process. Firstly the invoice table is updated
        /// then the invoice items for the invoice are inserted into the invocie items table.
        /// To avoid duplicates and complex updating any existing invoice items are deleted and then re-added       
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="currentInvoiceNum"></param>
        public void updateInvInDB(DataGridView dg, int currentInvoiceNum)
        {
            //update the main invoice details
            invDA.Update(ds, "Invoices");
            ds.AcceptChanges();

            //now delete any existing items in the invoice items table for this invoice
            gConn = openTheConnection();
            invItemDA.DeleteCommand.Connection = gConn;
            invItemDA.DeleteCommand.Parameters["@InvoiceNum"].Value = currentInvoiceNum;
            invItemDA.DeleteCommand.ExecuteNonQuery();

            //now add the new items back into the invoice items table for the invoice
            for (int rows = 0; rows < dg.Rows.Count - 1; rows++)
            {
                invItemDA.InsertCommand.Parameters["@InvoiceNum"].Value = currentInvoiceNum;
                invItemDA.InsertCommand.Parameters["@ItemNum"].Value = dg.Rows[rows].Cells["Item"].Value;
                invItemDA.InsertCommand.Parameters["@Qty"].Value = dg.Rows[rows].Cells["Qty"].Value;
                invItemDA.InsertCommand.Connection = gConn;
                invItemDA.InsertCommand.ExecuteNonQuery();               
            }
            ds.AcceptChanges();
            //refresh
            ds.Tables["InvoiceItems"].Clear();
            invItemDA.Fill(ds, "InvoiceItems");
            //clear any default selection on the data grid view
            dgInvoiceDetails.ClearSelection();
        }

        
        
        /// <summary>
        /// used when adding a new invoice to the database
        /// </summary>
        /// <returns></returns>
        public int addInvToDB()
        {
            //insert new invoice into the database
            invDA.Update(ds, "Invoices");
            //update the dataset
            ds.AcceptChanges();

            //get the new invoice number from the database via a stored procedure
            int newInvoiceNum = Convert.ToInt32(invDA.InsertCommand.Parameters["@InvoiceNum"].Value.ToString());
            //return the new invoice number 
            return newInvoiceNum;
        }

        //private DataGridView checkForDuplicates(DataGridView dg)
        //{
        //    for (int rows = 0; rows < dg.Rows.Count - 1; rows++)
        //    {

        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="newInvoiceNum"></param>
        public void saveInvToDB(DataGridView dg, int newInvoiceNum)
        {
            //as we're running our manual query commands we have to open the database connection manually
            gConn = openTheConnection();

            //DataGridView checkedDG = checkForDuplicates(dg);

            //insert each of the items on the data grid view into the database
            for (int rows = 0; rows < dg.Rows.Count - 1; rows++)
            {

                invItemDA.InsertCommand.Parameters["@InvoiceNum"].Value = newInvoiceNum;
                invItemDA.InsertCommand.Parameters["@ItemNum"].Value = dg.Rows[rows].Cells["Item"].Value;
                invItemDA.InsertCommand.Parameters["@Qty"].Value = dg.Rows[rows].Cells["Qty"].Value;
                invItemDA.InsertCommand.Connection = gConn;
                invItemDA.InsertCommand.ExecuteNonQuery();
            }
            ds.AcceptChanges();
            //manually refresh to invice items data table - this refresh would happen automatically if it was
            //bound to a binding source but since we're using custom select and insert commands we need to do it
            //manually
            ds.Tables["InvoiceItems"].Clear();
            invItemDA.Fill(ds, "InvoiceItems");
            updateInvoiceTotalCost();
            //clear any default selection on the data grid view
            dgInvoiceDetails.ClearSelection();
            //set the selection in the invoice numbers listbox to the new invoice number
            lbInvoiceNum.SelectedIndex = lbInvoiceNum.Items.Count-1;

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
        /// Get the payment status of an invoice
        /// </summary>
        /// <param name="inv">The invoice to get the payment status for</param>
        /// <returns>Payment status message</returns>
        private void setPaymentStatus()
        {

            //status message
            string status = string.Empty;
            
           // Console.WriteLine("Inside setpaymentstatus");
            //Console.WriteLine("Selected invoice number form listbox is " + lbInvoiceNum.GetItemText(lbInvoiceNum.SelectedItem));
            try
            {

               
                if (lbInvoiceNum.GetItemText(lbInvoiceNum.SelectedItem) != "")
                {
                    DataRowView current = (DataRowView)invBS.Current;
                    int currentInvoiceNum = Int16.Parse(current["InvoiceNum"].ToString());                   

                    if (current["PaymentStatus"].ToString().Equals("True"))
                    {
                        DateTime paidDate = (DateTime)current["PaymentDate"];
                        status = "Paid on " + paidDate.ToString("dd/MM/yyy");
                        lblStatus.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        DateTime dueDate = (DateTime)current["PaymentDueDate"];

                        if (DateTime.Compare(DateTime.Today, dueDate) > 0)
                        {
                            status = "Overdue. Payment was due on " + dueDate.ToString("dd/MM/yyyy");
                            lblStatus.ForeColor = System.Drawing.Color.Red;

                        }
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
            DataRowView current = (DataRowView)custBS.Current;
            int currentCustNum = Int16.Parse(current["CustNum"].ToString());
            Console.WriteLine("Invoice for customer number: " + currentCustNum);
            //create an instance of the invoice form
            InvoiceForm addInvoiceForm = new InvoiceForm(invBS, currentCustNum);
            //add a form closed handler
            //addInvoiceForm.FormClosed += new FormClosedEventHandler(addInvoiceForm_FormClosed);


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
            ////refesh the customer detials
            //fillCustomerDetails();
            //Console.WriteLine("From Cust LB. Number of items in invoice list box is : " + lbInvoiceNum.Items.Count);
            setPaymentStatus();
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
            //    //refesh the invoice detials
            //    fillInvoiceDetails(currentSelectedCustomer);
            //set payment status
            //Console.WriteLine("From Invoice LB. Number of items in invoice list box is : " + lbInvoiceNum.Items.Count);
            setPaymentStatus();
            updateInvoiceTotalCost();
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
            ////refresh customer details
            //fillCustomerDetails();
        }

        /// <summary>
        /// Displays the Edit Invoice form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            DataRowView current = (DataRowView)custBS.Current;
            int currentCustNum = Int16.Parse(current["CustNum"].ToString());
            //create new instance of invoice form
            InvoiceForm editInvoiceForm = new InvoiceForm(invBS, currentCustNum);
            //add form closed handler
            //editInvoiceForm.FormClosed += new FormClosedEventHandler(editInvoiceForm_FormClosed);
            //set reference to parent form
            editInvoiceForm.parent = this;
            //set the purpose of the form - either add or edit
            editInvoiceForm.purpose = "Edit";
            //set the invoice number that will be edited
            //invoiceNumThatWasEdited = lbInvoiceNum.SelectedIndex;
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
                DataRow[] targetRow = ds.Tables["Invoices"].Select("InvoiceNum = " + (lbInvoiceNum.SelectedItem as DataRowView)["InvoiceNum"].ToString());
                targetRow[0].Delete();
                invDA.Update(ds, "Invoices");
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
            showNewCustomerForm();
        }

        private void showNewCustomerForm()
        {
            CustomerForm addCustForm = new CustomerForm(custBS);
            //addCustForm.FormClosed += new FormClosedEventHandler(addCustForm_FormClosed);
            addCustForm.parent = this;
            addCustForm.purpose = "Add";
            addCustForm.ShowDialog();
        }

        

        /// <summary>
        /// Handles delete customer menu item click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            childRows = targetRow[0].GetChildRows(relCustInv);
            int numInvoices = childRows.Length;
            string deleteMsg = "Are you sure you want to delete customer " +
                            lbCustomers.GetItemText(lbCustomers.SelectedItem) +
                            "?";

            if (numInvoices > 0)
            {
                deleteMsg = "Are you sure you want to delete customer " +
                            lbCustomers.GetItemText(lbCustomers.SelectedItem) +
                            "? \nThe customer has " + numInvoices + " invoice(s) that will also be deleted.";
            }


            //show confirmation delete message dialog
            DialogResult deleteConfirm = MessageBox.Show(deleteMsg, "Delete Confirmation", MessageBoxButtons.YesNo);



            //if deletion confirmed
            if (deleteConfirm == DialogResult.Yes)
            {

                targetRow[0].Delete();
                custDA.Update(ds, "Customers");
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
             showEditCustomerForm();
        }

        /// <summary>
        /// Displays edit customer form
        /// </summary>
        private void showEditCustomerForm()
        {
            //create a new instance of the customer form
            CustomerForm editCustForm = new CustomerForm(custBS);
            //add a form closed handler
            // editCustForm.FormClosed += new FormClosedEventHandler(editCustForm_FormClosed);
            //remember customer being edited
            //set the invoice number that will be edited
            //customerNumThatWasEdited = lbCustomers.SelectedValue.ToString();
            //set reference to parent form
            editCustForm.parent = this;
            //set purpose of form to edit
            editCustForm.purpose = "Edit";
            //show the form
            editCustForm.ShowDialog();
        }

       

        private void txtBoxInvSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Search clicked");
        }

        private void txtBoxInvSearch_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Search box changed");
        }

        /// <summary>
        /// Handles invoice search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtBoxInvSearch.Text.Equals(string.Empty))
            {
                findInvoice(Int16.Parse(txtBoxInvSearch.Text));
            }



        }

        /// <summary>
        /// Finds an invoice by invoice number and sets selection on customer and invoice lists.
        /// If not found a message box is displayed informain user of no search results.
        /// </summary>
        /// <param name="invoiceNum">The invoice number ot search for</param>
        private void findInvoice(int invoiceNum)
        {

            //clear the customer filter first otherwise customer may not be displayed when searching for invoice
            tbSearchCust.Text = string.Empty;

            

            try
            {
                //find the invoice number
                DataRow[] result = ds.Tables["Invoices"].Select("InvoiceNum = " + invoiceNum);
                if (result.Length > 0)
                {
                    DataRow parentRow = result[0].GetParentRow(relCustInv);
                    int customerNum = Int16.Parse(parentRow[0].ToString());
                    lbCustomers.SelectedValue = customerNum;
                    lbInvoiceNum.SelectedValue = invoiceNum;
                }
                else
                {
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

        private void txtBoxInvSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }




    }
}
