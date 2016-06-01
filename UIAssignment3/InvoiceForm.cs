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
    /// <summary>
    /// Displays the invoice form for editing an existing invoice details or
    /// for adding a new invoice
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 25/4/2016
    /// </remarks>
    public partial class InvoiceForm : Form
    {
        /// <summary>
        /// Reference to parent form
        /// </summary>
        public MainForm parent;
        /// <summary>
        /// The purpose of invoice form; either edit or add
        /// </summary>
        public string purpose;

        /// <summary>
        /// List of items that have been selected when adding or editing an invoice
        /// </summary>
        List<string> selectedItems = new List<string>();

        /// <summary>
        /// Data view for filtering the list of available items to select
        /// </summary>
        DataView comboView;

        /// <summary>
        /// Binding source for invoice data
        /// </summary>
        private BindingSource formDataSource;

        /// <summary>
        /// The customer number for the invoice
        /// </summary>
        private int currentCustNum;

        /// <summary>
        /// Constructor initialises the UI components for the invoice form
        /// </summary>
        public InvoiceForm(BindingSource formDataSource, int currentCustNum)
        {
            InitializeComponent();
            
            //add a form closing handler
            this.FormClosing += new FormClosingEventHandler(addInvoiceForm_FormClosing); 

            //set the format for the date pickers
            paymentDueDatePicker.CustomFormat = "dd/MM/yyyy";
            paymentDueDatePicker.Format = DateTimePickerFormat.Custom;
            paymentDatePicker.CustomFormat = "dd/MM/yyyy";
            paymentDatePicker.Format = DateTimePickerFormat.Custom;

            //set the binding source
            this.formDataSource = formDataSource;
            //set the customer number that the invoice belongs to
            this.currentCustNum = currentCustNum;
        }

        /// <summary>
        /// Cancels any edits if the user closes the dialog using the red x
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void addInvoiceForm_FormClosing(Object sender, FormClosingEventArgs e)
        { 
            //closing the dialog using the red x results in a DialogResult.Cancel
            if (this.DialogResult == DialogResult.Cancel)
            {
                //cancel edits to the data grid and dataset
                dgAddInvoiceItems.CancelEdit();
                //reject any changes to the dataset
                parent.ds.RejectChanges();
            }           
        }


        /// <summary>
        /// Closes the invoice form and cancels any edits
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            //cancel edits to the data grid and dataset
            dgAddInvoiceItems.CancelEdit();
            //reject any changes to the dataset
            parent.ds.RejectChanges();
            //close the form
            this.Dispose();
        }

        /// <summary>
        /// Called when invoice form first loads.
        /// </summary>
        /// <remarks>
        /// If adding a new invoice all fields except invoice number are empty ready for input. 
        /// If editing an existing invoice all fields are populated ready for modification except invoice number.</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            //set the theme
            showTheme(parent.theme);

            //if editing an invoice
            if (purpose.Equals("Edit"))
            {
                //set form title
                this.Text = "Edit Invoice";                 
               
                //bind the existing invoice data to the controls
                bindInvoiceDetails();
                //update the invoice total
                updateInvoiceTotal();
                
                //if the invoice has been paid show the payment datepicker
                if (cboxPaidStatus.Checked)
                {
                    lblDatePaid.Visible = true;
                    paymentDatePicker.Visible = true;

                }
                //if unpaid then hide the payment datepicker
                else
                {
                    lblDatePaid.Visible = false;
                    paymentDatePicker.Visible = false;  
                }             

            }
            //if adding a new invoice
            else if (purpose.Equals("Add"))
            {
                
                //set form title
                this.Text = "Add Invoice";
                //add the data grid columns
                addColumnstoTable();                

                //hide the payment date picker
                lblDatePaid.Visible = false;
                paymentDatePicker.Visible = false;        
                               
                //disbable the save button until items have been added
                btnSave.Enabled = false;                
            }

            //add the datagridview listeners - triggered when a row is edited or when a row is deleted
            dgAddInvoiceItems.CellValueChanged += new DataGridViewCellEventHandler(dgAddInvoiceItems_CellValueChanged);
            dgAddInvoiceItems.CurrentCellDirtyStateChanged += new EventHandler(dgAddInvoiceItems_CurrentCellDirtyStateChanged);
            dgAddInvoiceItems.UserDeletedRow += new DataGridViewRowEventHandler(dgAddInvoiceItems_UserDeletedRow);

        }

       /// <summary>
       /// Binds the existing invoice data with the controls on the edit invoice form
       /// </summary>
        public void bindInvoiceDetails()
        {
            //invoice number
            tbInvoiceNum.DataBindings.Add("Text", formDataSource, "InvoiceNum");
            //payment date
            paymentDatePicker.DataBindings.Add("Value", formDataSource, "PaymentDate");
            //payment due date
            paymentDueDatePicker.DataBindings.Add("Value", formDataSource, "PaymentDueDate");
            //payment status
            cboxPaidStatus.DataBindings.Add("Checked", formDataSource, "PaymentStatus");

            //turn off auto generate columns as we'll add our own ones
            dgAddInvoiceItems.AutoGenerateColumns = false;
            //set the datasource for the items grid to the invoice items
            dgAddInvoiceItems.DataSource = parent.invItemBS;
            //add our columsn to the items data grid
            addColumnstoTable();            

            //add existing items to the item filter list so they can't be selected again
            for (int i=0; i<dgAddInvoiceItems.Rows.Count-1; i++) {
                selectedItems.Add(dgAddInvoiceItems.Rows[i].Cells[0].Value.ToString());
            }
            //apply filter to items list
            filterItemList();
        }

        /// <summary>
        /// Filters the combobox of items so previously added items are not available
        /// </summary>
        private void filterItemList()
        {
            //if the list isn't empty
            if (selectedItems.Count > 0)
            {
                //create the new data view
                comboView = new DataView();
                //set the source for the view
                comboView.Table = parent.ds.Tables["Items"];
                //set up the filter
                string itemFilter = "ItemNum NOT IN (" + String.Join(",", selectedItems) + ")";
                //apply the filter
                comboView.RowFilter = itemFilter;

                //get the combox for the new row
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[dgAddInvoiceItems.Rows.Count - 1].Cells[0];
                //set the datasource as the filtered item list
                cb.DataSource = comboView;
            }
            else
            {
                //if there is only 1 row it means that the grid is empty of items so re-populate the combobox 
                //with all items again               
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[0].Cells[0];
                cb.DataSource = parent.ds.Tables["Items"];
            }
        }

        /// <summary>
        /// Adds columns to the item data view grid
        /// </summary>
        private void addColumnstoTable()
        {
            //combo box of items
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = parent.ds.Tables["Items"].DefaultView;
            combo.DataPropertyName = "ItemNum";
            combo.DisplayMember = "ItemName";
            combo.ValueMember = "ItemNum";
            combo.Name = "Item";
            dgAddInvoiceItems.Columns.Add(combo);

            //add item description column
            DataGridViewTextBoxColumn itemDescCol = new DataGridViewTextBoxColumn();
            itemDescCol.ReadOnly = true;
            itemDescCol.HeaderText = "Description";
            itemDescCol.Name = "Description";
            itemDescCol.DataPropertyName = "Description";
            itemDescCol.Width = 140;
            dgAddInvoiceItems.Columns.Add(itemDescCol);

            //add item cost column
            DataGridViewTextBoxColumn itemCostCol = new DataGridViewTextBoxColumn();
            itemCostCol.ReadOnly = true;
            itemCostCol.HeaderText = "Cost";
            itemCostCol.Name = "Cost";
            itemCostCol.DataPropertyName = "Cost";
            itemCostCol.Width = 80;
            itemCostCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemCostCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemCostCol);

            //add item quantity column
            DataGridViewTextBoxColumn itemQtyCol = new DataGridViewTextBoxColumn();
            itemQtyCol.HeaderText = "Quantity";
            itemQtyCol.Name = "Qty";
            itemQtyCol.DataPropertyName = "Qty";
            itemQtyCol.Width = 60;
            itemQtyCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemQtyCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemQtyCol);

            //add total cost column
            DataGridViewTextBoxColumn itemTotalCostCol = new DataGridViewTextBoxColumn();
            itemTotalCostCol.ReadOnly = true;
            itemTotalCostCol.HeaderText = "Total Cost";
            itemTotalCostCol.Name = "Total Cost";
            itemTotalCostCol.DataPropertyName = "Total Cost";
            itemTotalCostCol.Width = 87;
            itemTotalCostCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemTotalCostCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemTotalCostCol);

            //clear any default selection
            dgAddInvoiceItems.ClearSelection();
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
                    gbInvoice.ForeColor = Color.White;
                    gbInvoice.BackColor = Color.Transparent;
                    dgAddInvoiceItems.ForeColor = Color.Black;
                    break;
                case "Dark":
                    //set background image
                    Image darkImage = new Bitmap(UIAssignment3.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //Customer Details Box text colours
                    gbInvoice.ForeColor = Color.White;
                    gbInvoice.BackColor = Color.Transparent;
                    dgAddInvoiceItems.ForeColor = Color.Black;
                    break;

                default:
                    //remove background image
                    this.BackgroundImage = null;
                    //Customer Details Box text colours
                    gbInvoice.ForeColor = SystemColors.ControlText;
                    gbInvoice.BackColor = SystemColors.Control;
                    dgAddInvoiceItems.ForeColor = Color.Black;
                    break;
            }
        }


        /// <summary>
        /// Called when an row is deleted in the item's table
        /// </summary>
        /// <remarks>
        /// Update the invoice total after detletion. If all item table is empty after deletion then disable the save button. </remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        void dgAddInvoiceItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            
            //filter the items list now that a row has been deleted. i.e. add the item that was removed back
            //into the list of available items
            filterItemList();           

            //if all items deleted from the table then disable the save button
            if (dgAddInvoiceItems.Rows.Count == 1)
            {
                //disable save button
                btnSave.Enabled = false;
            }
            //update invoice total
            updateInvoiceTotal();
        }

        /// <summary>
        /// This event handler manually raises the CellValueChanged event by calling the CommitEdit method.
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>         
        void dgAddInvoiceItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgAddInvoiceItems.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dgAddInvoiceItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }            
        }

        /// <summary>
        /// Handles when a user chooses a new item or changes the quantity for an item 
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param> 
        private void dgAddInvoiceItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the item is added or changed
                if (e.ColumnIndex == 0)
                {
                    //get the item selected
                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[e.RowIndex].Cells[0];
                                               
                    //check its not null
                    if (cb.Value != null)
                    {
                        //something has been added so enable the save button
                        btnSave.Enabled = true;
                        //add the item to the data table
                        addItemRow(Int16.Parse((cb.Value).ToString()), e);                        
                    }
                }

                //if the quantity has changed
                if (e.ColumnIndex == 3)
                {
                    //get the quantity entered by the user
                    object qty = dgAddInvoiceItems.Rows[e.RowIndex].Cells[3].Value;
                    //get the item's cost
                    object itemCost = dgAddInvoiceItems.Rows[e.RowIndex].Cells[2].Value;
                    //calcualte the item's total cost (item cost * quantity)
                    decimal total = Convert.ToDecimal(itemCost) * Convert.ToInt16(qty);
                    //set the item total in the data table
                    dgAddInvoiceItems.Rows[e.RowIndex].Cells[4].Value = total;
                }
                //update the invoice total
                updateInvoiceTotal();
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Updates the invoice total cost by adding up all the item costs on the invoice
        /// </summary>
        private void updateInvoiceTotal()
        {            
            //initialise invoice total
            decimal invTotalCost = 0;
            
            //if there are no items clear the invoice total. Row count is 1 when grid is empty as an empty combobox is created. 
            if (dgAddInvoiceItems.Rows.Count == 1)
            {
                txtBoxInvoiceTotal.Text = string.Empty;
            }
            else
            {
                //for each item add the cost to the total
                foreach (DataGridViewRow row in dgAddInvoiceItems.Rows)
                {
                    //add cost to total
                    invTotalCost += Convert.ToDecimal(row.Cells["Total Cost"].Value);
                }
                //display the total
                txtBoxInvoiceTotal.Text = "$" + invTotalCost.ToString("#.00");
            }            
        }
       
        /// <summary>
        /// Adds an item and its details to the invoice item data table
        /// </summary>
        /// <param name="itemNum">Item number of item to add</param>
        /// <param name="e">Event arguments of the DataGridViewCellEventArgs</param>
        private void addItemRow(int itemNum, DataGridViewCellEventArgs e)
        {
            //search for the item number in the items table
            DataRow[] result = parent.ds.Tables["Items"].Select("ItemNum = " + itemNum);
         
            //add the item details to the data view grid
            foreach (DataRow row in result)
            {
                //add the item name
                dgAddInvoiceItems.Rows[e.RowIndex].Cells[1].Value = row[2];
                //add the item description
                dgAddInvoiceItems.Rows[e.RowIndex].Cells[2].Value = row[3];
                //set the default quantity to 1
                dgAddInvoiceItems.Rows[e.RowIndex].Cells[3].Value = 1;
                //add the item cost
                dgAddInvoiceItems.Rows[e.RowIndex].Cells[4].Value = row[3];
            }

            //add the new item to the selectedItems list so the user can't select it again
            selectedItems.Add(itemNum.ToString());
            //update the filtered item list
            filterItemList();           
        }

        /// <summary>
        /// Saves the invoice details
        /// </summary>
        /// <remarks>If adding an invoice a new invoice is created. If editing an invoice the details are updated.</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //if adding a new invoice
            if (purpose.Equals("Add"))
            {
                //add the invoice
                createInvoice();
            }
            //if editing an invoice
            else if (purpose.Equals("Edit"))
            {
                //update the existing invoice
                formDataSource.EndEdit();
                updateInvoice();
            }
            //close the form
            this.Dispose();
        }


        /// <summary>
        /// Create a new invoice from the details entered into the invoice form
        /// </summary>
        private void createInvoice()
        {
            //save invoice main details to data table
            DataRow newRow = parent.ds.Tables["Invoices"].NewRow();
            newRow["PaymentDate"] = paymentDatePicker.Value;
            newRow["PaymentDueDate"] = paymentDueDatePicker.Value;
            newRow["PaymentStatus"] = cboxPaidStatus.Checked;
            newRow["CustNum"] = currentCustNum;
            //add the row to the data tabel
            parent.ds.Tables["Invoices"].Rows.Add(newRow);
                
            //update the dataset and database and get the new invoice number returned by the database
            int newInvoiceNum = parent.addInvToDB();

            //save the invoice items to the database
            parent.saveInvToDB(dgAddInvoiceItems, newInvoiceNum);
        }

        /// <summary>
        /// Update an existing invoice with details entered into the invoice form
        /// </summary>
        private void updateInvoice()
        {
            //get the existing details for the invoice from the data tabel
            DataRow[] Rows = parent.ds.Tables["Invoices"].Select("InvoiceNum='" + tbInvoiceNum.Text + "'");

            //get the due date and payment date from the form
            DateTime paymentDueDate = paymentDueDatePicker.Value;
            DateTime paymentDate = paymentDatePicker.Value;

            //update the paid status
            Rows[0]["PaymentStatus"] = cboxPaidStatus.Checked;
            //update the payment date
            Rows[0]["PaymentDate"] = paymentDate.Date;
            //update the payment due date
            Rows[0]["PaymentDueDate"] = paymentDueDate.Date;

            //save the updates to the database
            parent.updateInvInDB(dgAddInvoiceItems, Int16.Parse(tbInvoiceNum.Text));            
        }        

        /// <summary>
        /// Makes the Date Paid label and Date Paid date picker UI components visible if Paid checkbox checked 
        /// otherwise it hides them
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void cboxPaidStatus_CheckedChanged(object sender, EventArgs e)
        {
            //if the Paid checkbox is checked
            if (cboxPaidStatus.Checked)
            {
                //show the Date Paid label and date picker
                lblDatePaid.Visible = true;
                paymentDatePicker.Visible = true;
            }
            //hide the lable and date picker
            else
            {
                lblDatePaid.Visible = false;
                paymentDatePicker.Visible = false;
            }
        }

        /// <summary>
        /// Updates the selected items list just before the row is deleted
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="e">Event arguments</param>
        private void dgAddInvoiceItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //get item that is being deleted
            DataGridViewRow theRow = e.Row;
            object value = theRow.Cells[0].Value;
            //remove it from the selected items list so it's available again for selection
            selectedItems.Remove(Convert.ToString(value));
        }
    }
}
