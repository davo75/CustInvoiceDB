namespace UIAssignment3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.txtBoxPostCode = new System.Windows.Forms.TextBox();
            this.txtBoxSuburb = new System.Windows.Forms.TextBox();
            this.txtBoxStreet = new System.Windows.Forms.TextBox();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.txtBoxCustNum = new System.Windows.Forms.TextBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblSuburb = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblCustNum = new System.Windows.Forms.Label();
            this.gBoxCustomerDetails = new System.Windows.Forms.GroupBox();
            this.txtBoxCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtBoxState = new System.Windows.Forms.TextBox();
            this.gBoxInvoices = new System.Windows.Forms.GroupBox();
            this.lbInvoiceNum = new System.Windows.Forms.ListBox();
            this.gBoxCustomers = new System.Windows.Forms.GroupBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbSearchCust = new System.Windows.Forms.TextBox();
            this.lbCustomers = new System.Windows.Forms.ListBox();
            this.gbInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.tbTotalInvoiceCost = new System.Windows.Forms.TextBox();
            this.lblTotalInvoiceCost = new System.Windows.Forms.Label();
            this.dgInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.msFile = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnAddCust = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.txtBoxInvSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tsLblInvoices = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboxTheme = new System.Windows.Forms.ToolStripComboBox();
            this.tslblTheme = new System.Windows.Forms.ToolStripLabel();
            this.btnEditCust = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteCust = new System.Windows.Forms.ToolStripButton();
            this.gBoxCustomerDetails.SuspendLayout();
            this.gBoxInvoices.SuspendLayout();
            this.gBoxCustomers.SuspendLayout();
            this.gbInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceDetails)).BeginInit();
            this.msFile.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Location = new System.Drawing.Point(153, 283);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.ReadOnly = true;
            this.txtBoxPhone.Size = new System.Drawing.Size(150, 20);
            this.txtBoxPhone.TabIndex = 33;
            // 
            // txtBoxPostCode
            // 
            this.txtBoxPostCode.Location = new System.Drawing.Point(153, 251);
            this.txtBoxPostCode.Name = "txtBoxPostCode";
            this.txtBoxPostCode.ReadOnly = true;
            this.txtBoxPostCode.Size = new System.Drawing.Size(150, 20);
            this.txtBoxPostCode.TabIndex = 32;
            // 
            // txtBoxSuburb
            // 
            this.txtBoxSuburb.Location = new System.Drawing.Point(153, 187);
            this.txtBoxSuburb.Name = "txtBoxSuburb";
            this.txtBoxSuburb.ReadOnly = true;
            this.txtBoxSuburb.Size = new System.Drawing.Size(150, 20);
            this.txtBoxSuburb.TabIndex = 30;
            // 
            // txtBoxStreet
            // 
            this.txtBoxStreet.Location = new System.Drawing.Point(153, 155);
            this.txtBoxStreet.Name = "txtBoxStreet";
            this.txtBoxStreet.ReadOnly = true;
            this.txtBoxStreet.Size = new System.Drawing.Size(150, 20);
            this.txtBoxStreet.TabIndex = 29;
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Location = new System.Drawing.Point(153, 123);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.ReadOnly = true;
            this.txtBoxLastName.Size = new System.Drawing.Size(150, 20);
            this.txtBoxLastName.TabIndex = 28;
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Location = new System.Drawing.Point(153, 91);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.ReadOnly = true;
            this.txtBoxFirstName.Size = new System.Drawing.Size(150, 20);
            this.txtBoxFirstName.TabIndex = 27;
            // 
            // txtBoxCustNum
            // 
            this.txtBoxCustNum.Location = new System.Drawing.Point(153, 29);
            this.txtBoxCustNum.Name = "txtBoxCustNum";
            this.txtBoxCustNum.ReadOnly = true;
            this.txtBoxCustNum.Size = new System.Drawing.Size(150, 20);
            this.txtBoxCustNum.TabIndex = 25;
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(22, 255);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(56, 13);
            this.lblPostCode.TabIndex = 24;
            this.lblPostCode.Text = "Post Code";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(22, 223);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 23;
            this.lblState.Text = "State";
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(22, 191);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(41, 13);
            this.lblSuburb.TabIndex = 22;
            this.lblSuburb.Text = "Suburb";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(22, 287);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(78, 13);
            this.lblPhone.TabIndex = 21;
            this.lblPhone.Text = "Contact Phone";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(22, 159);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(76, 13);
            this.lblStreet.TabIndex = 20;
            this.lblStreet.Text = "Street Address";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(22, 127);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 19;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(22, 95);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 18;
            this.lblFirstName.Text = "First Name";
            // 
            // lblCustNum
            // 
            this.lblCustNum.AutoSize = true;
            this.lblCustNum.Location = new System.Drawing.Point(22, 33);
            this.lblCustNum.Name = "lblCustNum";
            this.lblCustNum.Size = new System.Drawing.Size(91, 13);
            this.lblCustNum.TabIndex = 17;
            this.lblCustNum.Text = "Customer Number";
            // 
            // gBoxCustomerDetails
            // 
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxCompany);
            this.gBoxCustomerDetails.Controls.Add(this.lblCompany);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxState);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxPhone);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxPostCode);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxSuburb);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxStreet);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxLastName);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxFirstName);
            this.gBoxCustomerDetails.Controls.Add(this.txtBoxCustNum);
            this.gBoxCustomerDetails.Controls.Add(this.lblPostCode);
            this.gBoxCustomerDetails.Controls.Add(this.lblState);
            this.gBoxCustomerDetails.Controls.Add(this.lblSuburb);
            this.gBoxCustomerDetails.Controls.Add(this.lblPhone);
            this.gBoxCustomerDetails.Controls.Add(this.lblStreet);
            this.gBoxCustomerDetails.Controls.Add(this.lblLastName);
            this.gBoxCustomerDetails.Controls.Add(this.lblFirstName);
            this.gBoxCustomerDetails.Controls.Add(this.lblCustNum);
            this.gBoxCustomerDetails.Location = new System.Drawing.Point(198, 59);
            this.gBoxCustomerDetails.Name = "gBoxCustomerDetails";
            this.gBoxCustomerDetails.Size = new System.Drawing.Size(345, 321);
            this.gBoxCustomerDetails.TabIndex = 35;
            this.gBoxCustomerDetails.TabStop = false;
            this.gBoxCustomerDetails.Text = "Customer Details";
            // 
            // txtBoxCompany
            // 
            this.txtBoxCompany.Location = new System.Drawing.Point(153, 60);
            this.txtBoxCompany.Name = "txtBoxCompany";
            this.txtBoxCompany.ReadOnly = true;
            this.txtBoxCompany.Size = new System.Drawing.Size(150, 20);
            this.txtBoxCompany.TabIndex = 26;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(22, 64);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 33;
            this.lblCompany.Text = "Company";
            // 
            // txtBoxState
            // 
            this.txtBoxState.Location = new System.Drawing.Point(153, 220);
            this.txtBoxState.Name = "txtBoxState";
            this.txtBoxState.ReadOnly = true;
            this.txtBoxState.Size = new System.Drawing.Size(150, 20);
            this.txtBoxState.TabIndex = 31;
            // 
            // gBoxInvoices
            // 
            this.gBoxInvoices.Controls.Add(this.lbInvoiceNum);
            this.gBoxInvoices.Location = new System.Drawing.Point(568, 59);
            this.gBoxInvoices.Name = "gBoxInvoices";
            this.gBoxInvoices.Size = new System.Drawing.Size(133, 321);
            this.gBoxInvoices.TabIndex = 36;
            this.gBoxInvoices.TabStop = false;
            this.gBoxInvoices.Text = "Invoices";
            // 
            // lbInvoiceNum
            // 
            this.lbInvoiceNum.FormattingEnabled = true;
            this.lbInvoiceNum.Location = new System.Drawing.Point(23, 29);
            this.lbInvoiceNum.Name = "lbInvoiceNum";
            this.lbInvoiceNum.Size = new System.Drawing.Size(87, 277);
            this.lbInvoiceNum.TabIndex = 1;
            this.lbInvoiceNum.SelectedIndexChanged += new System.EventHandler(this.lbInvoiceNum_SelectedIndexChanged);
            // 
            // gBoxCustomers
            // 
            this.gBoxCustomers.Controls.Add(this.lblFilter);
            this.gBoxCustomers.Controls.Add(this.tbSearchCust);
            this.gBoxCustomers.Controls.Add(this.lbCustomers);
            this.gBoxCustomers.Location = new System.Drawing.Point(17, 59);
            this.gBoxCustomers.Name = "gBoxCustomers";
            this.gBoxCustomers.Size = new System.Drawing.Size(156, 321);
            this.gBoxCustomers.TabIndex = 37;
            this.gBoxCustomers.TabStop = false;
            this.gBoxCustomers.Text = "Customers";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(21, 33);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 2;
            this.lblFilter.Text = "Filter";
            // 
            // tbSearchCust
            // 
            this.tbSearchCust.Location = new System.Drawing.Point(21, 52);
            this.tbSearchCust.Name = "tbSearchCust";
            this.tbSearchCust.Size = new System.Drawing.Size(115, 20);
            this.tbSearchCust.TabIndex = 1;
            this.tbSearchCust.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbCustomers
            // 
            this.lbCustomers.FormattingEnabled = true;
            this.lbCustomers.Location = new System.Drawing.Point(21, 81);
            this.lbCustomers.Name = "lbCustomers";
            this.lbCustomers.Size = new System.Drawing.Size(115, 225);
            this.lbCustomers.TabIndex = 0;
            this.lbCustomers.SelectedIndexChanged += new System.EventHandler(this.lbCustomers_SelectedIndexChanged);
            // 
            // gbInvoiceDetails
            // 
            this.gbInvoiceDetails.Controls.Add(this.lblStatus);
            this.gbInvoiceDetails.Controls.Add(this.lblPaymentStatus);
            this.gbInvoiceDetails.Controls.Add(this.tbTotalInvoiceCost);
            this.gbInvoiceDetails.Controls.Add(this.lblTotalInvoiceCost);
            this.gbInvoiceDetails.Controls.Add(this.dgInvoiceDetails);
            this.gbInvoiceDetails.Location = new System.Drawing.Point(17, 430);
            this.gbInvoiceDetails.Name = "gbInvoiceDetails";
            this.gbInvoiceDetails.Size = new System.Drawing.Size(684, 257);
            this.gbInvoiceDetails.TabIndex = 38;
            this.gbInvoiceDetails.TabStop = false;
            this.gbInvoiceDetails.Text = "Invoice Details";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(117, 227);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 45;
            this.lblStatus.Text = "lblStatus";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.Location = new System.Drawing.Point(21, 227);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(99, 13);
            this.lblPaymentStatus.TabIndex = 44;
            this.lblPaymentStatus.Text = "Payment Status:";
            // 
            // tbTotalInvoiceCost
            // 
            this.tbTotalInvoiceCost.Location = new System.Drawing.Point(571, 223);
            this.tbTotalInvoiceCost.Name = "tbTotalInvoiceCost";
            this.tbTotalInvoiceCost.ReadOnly = true;
            this.tbTotalInvoiceCost.Size = new System.Drawing.Size(89, 20);
            this.tbTotalInvoiceCost.TabIndex = 43;
            this.tbTotalInvoiceCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalInvoiceCost
            // 
            this.lblTotalInvoiceCost.AutoSize = true;
            this.lblTotalInvoiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvoiceCost.Location = new System.Drawing.Point(453, 227);
            this.lblTotalInvoiceCost.Name = "lblTotalInvoiceCost";
            this.lblTotalInvoiceCost.Size = new System.Drawing.Size(115, 13);
            this.lblTotalInvoiceCost.TabIndex = 42;
            this.lblTotalInvoiceCost.Text = "Total Invoice Cost:";
            // 
            // dgInvoiceDetails
            // 
            this.dgInvoiceDetails.AllowUserToAddRows = false;
            this.dgInvoiceDetails.AllowUserToDeleteRows = false;
            this.dgInvoiceDetails.AllowUserToResizeColumns = false;
            this.dgInvoiceDetails.AllowUserToResizeRows = false;
            this.dgInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceDetails.Location = new System.Drawing.Point(21, 27);
            this.dgInvoiceDetails.Name = "dgInvoiceDetails";
            this.dgInvoiceDetails.ReadOnly = true;
            this.dgInvoiceDetails.Size = new System.Drawing.Size(640, 173);
            this.dgInvoiceDetails.TabIndex = 42;
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(455, 398);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnAddInvoice.TabIndex = 39;
            this.btnAddInvoice.Text = "Add Invoice";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Location = new System.Drawing.Point(536, 398);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnEditInvoice.TabIndex = 40;
            this.btnEditInvoice.Text = "Edit Invoice";
            this.btnEditInvoice.UseVisualStyleBackColor = true;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(617, 398);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteInvoice.TabIndex = 41;
            this.btnDeleteInvoice.Text = "Delete Invoice";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // msFile
            // 
            this.msFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.msFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msFile.Location = new System.Drawing.Point(0, 0);
            this.msFile.Name = "msFile";
            this.msFile.Size = new System.Drawing.Size(724, 24);
            this.msFile.TabIndex = 42;
            this.msFile.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.editCustomerToolStripMenuItem,
            this.deleteCustomerToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.addCustomerToolStripMenuItem.Text = "Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // editCustomerToolStripMenuItem
            // 
            this.editCustomerToolStripMenuItem.Name = "editCustomerToolStripMenuItem";
            this.editCustomerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editCustomerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.editCustomerToolStripMenuItem.Text = "Edit Customer";
            this.editCustomerToolStripMenuItem.Click += new System.EventHandler(this.editCustomerToolStripMenuItem_Click);
            // 
            // deleteCustomerToolStripMenuItem
            // 
            this.deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
            this.deleteCustomerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteCustomerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteCustomerToolStripMenuItem.Text = "Delete Customer";
            this.deleteCustomerToolStripMenuItem.Click += new System.EventHandler(this.deleteCustomerToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.Gainsboro;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddCust,
            this.toolStripSeparator2,
            this.btnSearch,
            this.txtBoxInvSearch,
            this.tsLblInvoices,
            this.toolStripSeparator1,
            this.cboxTheme,
            this.tslblTheme,
            this.btnEditCust,
            this.toolStripSeparator3,
            this.btnDeleteCust});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tsMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsMain.Size = new System.Drawing.Size(724, 25);
            this.tsMain.TabIndex = 43;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnAddCust
            // 
            this.btnAddCust.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCust.Image = global::UIAssignment3.Properties.Resources.add;
            this.btnAddCust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddCust.Size = new System.Drawing.Size(23, 22);
            this.btnAddCust.Text = "Add Customer";
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSearch.Size = new System.Drawing.Size(46, 22);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxInvSearch
            // 
            this.txtBoxInvSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtBoxInvSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBoxInvSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBoxInvSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxInvSearch.Name = "txtBoxInvSearch";
            this.txtBoxInvSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxInvSearch.Size = new System.Drawing.Size(70, 25);
            this.txtBoxInvSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInvSearch_KeyPress);
            // 
            // tsLblInvoices
            // 
            this.tsLblInvoices.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsLblInvoices.Name = "tsLblInvoices";
            this.tsLblInvoices.Size = new System.Drawing.Size(75, 22);
            this.tsLblInvoices.Text = "Invoice Num";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cboxTheme
            // 
            this.cboxTheme.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboxTheme.Items.AddRange(new object[] {
            "Default",
            "Dark",
            "Light"});
            this.cboxTheme.Name = "cboxTheme";
            this.cboxTheme.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboxTheme.Size = new System.Drawing.Size(75, 25);
            this.cboxTheme.SelectedIndexChanged += new System.EventHandler(this.cboxTheme_SelectedIndexChanged);
            // 
            // tslblTheme
            // 
            this.tslblTheme.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslblTheme.Name = "tslblTheme";
            this.tslblTheme.Size = new System.Drawing.Size(44, 22);
            this.tslblTheme.Text = "Theme";
            // 
            // btnEditCust
            // 
            this.btnEditCust.BackColor = System.Drawing.Color.Transparent;
            this.btnEditCust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditCust.Image = global::UIAssignment3.Properties.Resources.edit;
            this.btnEditCust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCust.Name = "btnEditCust";
            this.btnEditCust.Size = new System.Drawing.Size(23, 22);
            this.btnEditCust.Text = "toolStripButton1";
            this.btnEditCust.ToolTipText = "Edit Customer";
            this.btnEditCust.Click += new System.EventHandler(this.btnEditCust_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteCust
            // 
            this.btnDeleteCust.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteCust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteCust.Image = global::UIAssignment3.Properties.Resources.delete;
            this.btnDeleteCust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCust.Name = "btnDeleteCust";
            this.btnDeleteCust.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteCust.Text = "toolStripButton2";
            this.btnDeleteCust.ToolTipText = "Delete Customer";
            this.btnDeleteCust.Click += new System.EventHandler(this.btnDeleteCust_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 708);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.btnDeleteInvoice);
            this.Controls.Add(this.btnEditInvoice);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.gbInvoiceDetails);
            this.Controls.Add(this.gBoxCustomers);
            this.Controls.Add(this.gBoxInvoices);
            this.Controls.Add(this.gBoxCustomerDetails);
            this.Controls.Add(this.msFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msFile;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABC Invoice Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gBoxCustomerDetails.ResumeLayout(false);
            this.gBoxCustomerDetails.PerformLayout();
            this.gBoxInvoices.ResumeLayout(false);
            this.gBoxCustomers.ResumeLayout(false);
            this.gBoxCustomers.PerformLayout();
            this.gbInvoiceDetails.ResumeLayout(false);
            this.gbInvoiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceDetails)).EndInit();
            this.msFile.ResumeLayout(false);
            this.msFile.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.TextBox txtBoxPostCode;
        private System.Windows.Forms.TextBox txtBoxSuburb;
        private System.Windows.Forms.TextBox txtBoxStreet;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.TextBox txtBoxCustNum;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblCustNum;
        private System.Windows.Forms.GroupBox gBoxCustomerDetails;
        private System.Windows.Forms.GroupBox gBoxInvoices;
        private System.Windows.Forms.GroupBox gBoxCustomers;
        private System.Windows.Forms.GroupBox gbInvoiceDetails;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.ListBox lbInvoiceNum;
        private System.Windows.Forms.ListBox lbCustomers;
        private System.Windows.Forms.DataGridView dgInvoiceDetails;
        private System.Windows.Forms.TextBox tbTotalInvoiceCost;
        private System.Windows.Forms.Label lblTotalInvoiceCost;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbSearchCust;
        private System.Windows.Forms.TextBox txtBoxState;
        private System.Windows.Forms.TextBox txtBoxCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.MenuStrip msFile;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripLabel tsLblInvoices;
        private System.Windows.Forms.ToolStripTextBox txtBoxInvSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cboxTheme;
        private System.Windows.Forms.ToolStripLabel tslblTheme;
        private System.Windows.Forms.ToolStripButton btnAddCust;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEditCust;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDeleteCust;
    }
}

