namespace UIAssignment3
{
    partial class CustomerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.gBoxCustFormDetails = new System.Windows.Forms.GroupBox();
            this.cboxState = new System.Windows.Forms.ComboBox();
            this.txtBoxCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
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
            this.lblCustNumber = new System.Windows.Forms.Label();
            this.btnCustSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAllReqd = new System.Windows.Forms.Label();
            this.gBoxCustFormDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxCustFormDetails
            // 
            this.gBoxCustFormDetails.Controls.Add(this.cboxState);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxCompany);
            this.gBoxCustFormDetails.Controls.Add(this.lblCompany);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxPhone);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxPostCode);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxSuburb);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxStreet);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxLastName);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxFirstName);
            this.gBoxCustFormDetails.Controls.Add(this.txtBoxCustNum);
            this.gBoxCustFormDetails.Controls.Add(this.lblPostCode);
            this.gBoxCustFormDetails.Controls.Add(this.lblState);
            this.gBoxCustFormDetails.Controls.Add(this.lblSuburb);
            this.gBoxCustFormDetails.Controls.Add(this.lblPhone);
            this.gBoxCustFormDetails.Controls.Add(this.lblStreet);
            this.gBoxCustFormDetails.Controls.Add(this.lblLastName);
            this.gBoxCustFormDetails.Controls.Add(this.lblFirstName);
            this.gBoxCustFormDetails.Controls.Add(this.lblCustNumber);
            this.gBoxCustFormDetails.Location = new System.Drawing.Point(23, 25);
            this.gBoxCustFormDetails.Name = "gBoxCustFormDetails";
            this.gBoxCustFormDetails.Size = new System.Drawing.Size(345, 321);
            this.gBoxCustFormDetails.TabIndex = 36;
            this.gBoxCustFormDetails.TabStop = false;
            this.gBoxCustFormDetails.Text = "Customer Details";
            // 
            // cboxState
            // 
            this.cboxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxState.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cboxState, 38);
            this.cboxState.Items.AddRange(new object[] {
            "ACT",
            "NSW",
            "NT",
            "QLD",
            "SA",
            "TAS",
            "VIC",
            "WA"});
            this.cboxState.Location = new System.Drawing.Point(153, 218);
            this.cboxState.Name = "cboxState";
            this.cboxState.Size = new System.Drawing.Size(67, 21);
            this.cboxState.TabIndex = 6;
            this.cboxState.Validating += new System.ComponentModel.CancelEventHandler(this.cboxState_Validating);
            this.cboxState.Validated += new System.EventHandler(this.cboxState_Validated);
            // 
            // txtBoxCompany
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxCompany, 5);
            this.txtBoxCompany.Location = new System.Drawing.Point(153, 60);
            this.txtBoxCompany.Name = "txtBoxCompany";
            this.txtBoxCompany.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCompany.TabIndex = 1;
            this.txtBoxCompany.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxCompany_Validating);
            this.txtBoxCompany.Validated += new System.EventHandler(this.txtBoxCompany_Validated);
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
            // txtBoxPhone
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxPhone, 5);
            this.txtBoxPhone.Location = new System.Drawing.Point(153, 283);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPhone.TabIndex = 8;
            this.txtBoxPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPhone_Validating);
            this.txtBoxPhone.Validated += new System.EventHandler(this.txtBoxPhone_Validated);
            // 
            // txtBoxPostCode
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxPostCode, 5);
            this.txtBoxPostCode.Location = new System.Drawing.Point(153, 251);
            this.txtBoxPostCode.Name = "txtBoxPostCode";
            this.txtBoxPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPostCode.TabIndex = 7;
            this.txtBoxPostCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPostCode_Validating);
            this.txtBoxPostCode.Validated += new System.EventHandler(this.txtBoxPostCode_Validated);
            // 
            // txtBoxSuburb
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxSuburb, 5);
            this.txtBoxSuburb.Location = new System.Drawing.Point(153, 187);
            this.txtBoxSuburb.Name = "txtBoxSuburb";
            this.txtBoxSuburb.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSuburb.TabIndex = 5;
            this.txtBoxSuburb.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxSuburb_Validating);
            this.txtBoxSuburb.Validated += new System.EventHandler(this.txtBoxSuburb_Validated);
            // 
            // txtBoxStreet
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxStreet, 5);
            this.txtBoxStreet.Location = new System.Drawing.Point(153, 155);
            this.txtBoxStreet.Name = "txtBoxStreet";
            this.txtBoxStreet.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStreet.TabIndex = 4;
            this.txtBoxStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxStreet_Validating);
            this.txtBoxStreet.Validated += new System.EventHandler(this.txtBoxStreet_Validated);
            // 
            // txtBoxLastName
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxLastName, 5);
            this.txtBoxLastName.Location = new System.Drawing.Point(153, 123);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLastName.TabIndex = 3;
            this.txtBoxLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxLastName_Validating);
            this.txtBoxLastName.Validated += new System.EventHandler(this.txtBoxLastName_Validated);
            // 
            // txtBoxFirstName
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxFirstName, 5);
            this.txtBoxFirstName.Location = new System.Drawing.Point(153, 91);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFirstName.TabIndex = 2;
            this.txtBoxFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxFirstName_Validating);
            this.txtBoxFirstName.Validated += new System.EventHandler(this.txtBoxFirstName_Validated);
            // 
            // txtBoxCustNum
            // 
            this.txtBoxCustNum.Location = new System.Drawing.Point(153, 29);
            this.txtBoxCustNum.Name = "txtBoxCustNum";
            this.txtBoxCustNum.ReadOnly = true;
            this.txtBoxCustNum.Size = new System.Drawing.Size(100, 20);
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
            // lblCustNumber
            // 
            this.lblCustNumber.AutoSize = true;
            this.lblCustNumber.Location = new System.Drawing.Point(22, 33);
            this.lblCustNumber.Name = "lblCustNumber";
            this.lblCustNumber.Size = new System.Drawing.Size(91, 13);
            this.lblCustNumber.TabIndex = 17;
            this.lblCustNumber.Text = "Customer Number";
            // 
            // btnCustSave
            // 
            this.btnCustSave.Location = new System.Drawing.Point(212, 363);
            this.btnCustSave.Name = "btnCustSave";
            this.btnCustSave.Size = new System.Drawing.Size(75, 23);
            this.btnCustSave.TabIndex = 9;
            this.btnCustSave.Text = "Save";
            this.btnCustSave.UseVisualStyleBackColor = true;
            this.btnCustSave.Click += new System.EventHandler(this.btnCustSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // lblAllReqd
            // 
            this.lblAllReqd.AutoSize = true;
            this.lblAllReqd.BackColor = System.Drawing.Color.Transparent;
            this.lblAllReqd.ForeColor = System.Drawing.Color.Red;
            this.lblAllReqd.Location = new System.Drawing.Point(20, 368);
            this.lblAllReqd.Name = "lblAllReqd";
            this.lblAllReqd.Size = new System.Drawing.Size(92, 13);
            this.lblAllReqd.TabIndex = 37;
            this.lblAllReqd.Text = "* all fields required";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 402);
            this.Controls.Add(this.lblAllReqd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCustSave);
            this.Controls.Add(this.gBoxCustFormDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.gBoxCustFormDetails.ResumeLayout(false);
            this.gBoxCustFormDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxCustFormDetails;
        private System.Windows.Forms.ComboBox cboxState;
        private System.Windows.Forms.TextBox txtBoxCompany;
        private System.Windows.Forms.Label lblCompany;
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
        private System.Windows.Forms.Label lblCustNumber;
        private System.Windows.Forms.Button btnCustSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblAllReqd;
    }
}