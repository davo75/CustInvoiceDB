using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace UIAssignment3
{
    /// <summary>
    /// Handles the data connection, data adapters and queries to the database
    /// </summary>
    /// <remarks>
    /// author: David Pyle 041110777
    /// version: 1.0
    /// date: 01/06/2016
    /// </remarks>
    class DataConnect
    {
        /// <summary>
        /// Main database connection
        /// </summary>
        private MySqlConnection gConn;
        /// <summary>
        /// Customer table adapater
        /// </summary>
        internal MySqlDataAdapter custDA;
        /// <summary>
        /// Invoice table adapter
        /// </summary>
        internal MySqlDataAdapter invDA;
        /// <summary>
        /// Item table adpater
        /// </summary>
        private MySqlDataAdapter itemDA;
        /// <summary>
        /// Invoice Items table adapter
        /// </summary>
        private MySqlDataAdapter invItemDA;
        /// <summary>
        /// Data relation for Customer and Invoice tables
        /// </summary>
        internal DataRelation relCustInv;
        /// <summary>
        /// Database connection string
        /// </summary>
        private string connStr;

        /// <summary>
        /// Constructor - initiates a connection to the database
        /// </summary>
        /// <param name="connStr"></param>
        public DataConnect(string connStr)
        {
            try
            {
                this.connStr = connStr;
                gConn = openTheConnection();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                MessageBox.Show("Unable to connect to the database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        /// Eastablishes database connection
        /// </summary>
        /// <returns>DB connection</returns>
        public MySqlConnection openTheConnection()
        {
            //open a connection to the database and return it            
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Sets up the data adapters and query commands for the customer, invoice, item and invoice item tables
        /// </summary>
        public void initialiseCommands()
        {
            ///////////////////////////
            //CUSTOMER TABLE COMMANDS//
            ///////////////////////////

            //setup adapter for customer table
            custDA = new MySqlDataAdapter();
            custDA.SelectCommand = new MySqlCommand("SELECT * FROM Customer", gConn);
            custDA.TableMappings.Add("Table", "Customers");

            //setup Insert commands for customer adapter and parameters
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

            //setup Update command for customer adapter and parameters
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

            //setup Delete command for customer adapter and parameters
            custDA.DeleteCommand = new MySqlCommand("DELETE FROM Customer WHERE CustNum = @CustNum", gConn);
            custDA.DeleteCommand.Parameters.Add("@CustNum", MySqlDbType.Int16, 5, "CustNum");

            //////////////////////////
            //INVOICE TABLE COMMANDS//
            //////////////////////////

            //setup adapter for invoice table
            invDA = new MySqlDataAdapter();
            invDA.SelectCommand = new MySqlCommand("SELECT * FROM Invoice", gConn);
            invDA.TableMappings.Add("Table", "Invoices");

            //setup Insert commands for invoice adapte and parameters
            invDA.InsertCommand = new MySqlCommand("InsertInv", gConn);
            invDA.InsertCommand.CommandType = CommandType.StoredProcedure;
            invDA.InsertCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5, "InvoiceNum").Direction = ParameterDirection.Output;
            invDA.InsertCommand.Parameters.Add("@PaymentStatus", MySqlDbType.Int16, 2, "PaymentStatus");
            invDA.InsertCommand.Parameters.Add("@PaymentDate", MySqlDbType.Date).SourceColumn = "PaymentDate";
            invDA.InsertCommand.Parameters.Add("@PaymentDueDate", MySqlDbType.Date).SourceColumn = "PaymentDueDate";
            invDA.InsertCommand.Parameters.Add("@CustNum", MySqlDbType.Int16, 5, "CustNum");

            //setup Update command for invoice adapter and parameters
            invDA.UpdateCommand = new MySqlCommand(@"   UPDATE Invoice 
                                                        SET PaymentStatus = @PaymentStatus, PaymentDate = @PaymentDate, PaymentDueDate = @PaymentDueDate 
                                                        WHERE InvoiceNum = @InvoiceNum", gConn);
            invDA.UpdateCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5, "InvoiceNum");
            invDA.UpdateCommand.Parameters.Add("@PaymentStatus", MySqlDbType.Int16, 2, "PaymentStatus");
            invDA.UpdateCommand.Parameters.Add("@PaymentDate", MySqlDbType.Date).SourceColumn = "PaymentDate";
            invDA.UpdateCommand.Parameters.Add("@PaymentDueDate", MySqlDbType.Date).SourceColumn = "PaymentDueDate";

            //setup Delete command for invoice adapter and parameters
            invDA.DeleteCommand = new MySqlCommand("DELETE FROM Invoice WHERE InvoiceNum = @InvoiceNum", gConn);
            invDA.DeleteCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5, "InvoiceNum");

            ////////////////////////////////
            //INVOICE ITEMS TABLE COMMANDS//
            ////////////////////////////////

            //setup adapter for invoice items table
            invItemDA = new MySqlDataAdapter();
            invItemDA.SelectCommand = new MySqlCommand(@"SELECT invoiceitem.InvoiceNum, item.ItemNum, item.ItemName AS 'Item', item.Description, invoiceitem.Qty, item.Cost, (invoiceitem.qty*item.cost) AS 'Total Cost' 
                                                            FROM invoiceitem, item WHERE item.ItemNum = invoiceitem.ItemNum", gConn);
            invItemDA.TableMappings.Add("Table", "InvoiceItems");

            //setup Insert command for invoice items adapter
            invItemDA.InsertCommand = new MySqlCommand("INSERT INTO InvoiceItem (InvoiceNum, ItemNum, Qty) VALUES (@InvoiceNum, @ItemNum, @Qty)");
            invItemDA.InsertCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5);
            invItemDA.InsertCommand.Parameters.Add("@ItemNum", MySqlDbType.Int16, 5);
            invItemDA.InsertCommand.Parameters.Add("@Qty", MySqlDbType.Int16, 5);

            //setup Delete command for invoice item adapater and parameters
            invItemDA.DeleteCommand = new MySqlCommand("DELETE FROM InvoiceItem WHERE InvoiceNum = @InvoiceNum");
            invItemDA.DeleteCommand.Parameters.Add("@InvoiceNum", MySqlDbType.Int16, 5);

            ////////////////////////
            //ITEMS TABLE COMMANDS//
            ////////////////////////

            //setup adapter for items table
            itemDA = new MySqlDataAdapter();
            itemDA.SelectCommand = new MySqlCommand("Select * FROM Item ORDER BY ItemName", gConn);
            itemDA.TableMappings.Add("Table", "Items");
        }

        /// <summary>
        /// Refreshes the dataset table with database data
        /// </summary>
        /// <param name="ds">DatesSet that contains the data table</param>
        /// <param name="tableName">Table name to refresh</param>
        public void refreshData(DataSet ds, string tableName)
        {
            //clear any data from the data table
            ds.Tables[tableName].Clear();
            //refill the data table from the database
            invItemDA.Fill(ds, tableName);
        }

        /// <summary>
        /// Saves invoice items to the database from a datagridview for a new invoice
        /// </summary>
        /// <param name="dg">The datagridview that contains the items to insert</param>
        /// <param name="newInvoiceNum">The invoice number the invoice items belong to</param>
        public void saveInvoice(DataGridView dg, int newInvoiceNum)
        {
            //as we're running our manual query commands we have to open the database connection manually
            gConn = openTheConnection();

            //insert each of the items on the data grid view into the database
            for (int rows = 0; rows < dg.Rows.Count - 1; rows++)
            {
                invItemDA.InsertCommand.Parameters["@InvoiceNum"].Value = newInvoiceNum;
                invItemDA.InsertCommand.Parameters["@ItemNum"].Value = dg.Rows[rows].Cells["Item"].Value;
                invItemDA.InsertCommand.Parameters["@Qty"].Value = dg.Rows[rows].Cells["Qty"].Value;
                invItemDA.InsertCommand.Connection = gConn;
                invItemDA.InsertCommand.ExecuteNonQuery();
            }
            //close the db connection
            gConn.Close();
        }

        /// <summary>
        /// Saves invoice items to the database from a datagridview for an existing invoice.
        /// </summary>
        /// <remarks>Exisiting invoice items for the invoice are first deleted and then the 
        /// new ones are added. This makes it easier to update otherwise you need to search and update
        /// existing invoice item records.
        /// </remarks>
        /// <param name="dg">The datagridview that contains the items to insert</param>
        /// <param name="currentInvoiceNum">The invoice number the invoice items belong to</param>
        public void updateInvoice(DataGridView dg, int currentInvoiceNum)
        {
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
            //close the connection
            gConn.Close();
        }

        /// <summary>
        /// Loads the data from the database into the tables contained in the dataset and creates the 
        /// data relationships between the tables
        /// </summary>
        /// <returns>DataSet loaded with data</returns>
        public DataSet loadData()
        {
            //create the dataset
            DataSet ds = new DataSet("CustInvoices");
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
            
            //return the fully loaded dataset
            return ds;
        }
    }
}


