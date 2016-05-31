namespace UIAssignment3
{
    partial class InvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.gbInvoice = new System.Windows.Forms.GroupBox();
            this.paymentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDatePaid = new System.Windows.Forms.Label();
            this.txtBoxInvoiceTotal = new System.Windows.Forms.TextBox();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.dgAddInvoiceItems = new System.Windows.Forms.DataGridView();
            this.cboxPaidStatus = new System.Windows.Forms.CheckBox();
            this.lblPayStatus = new System.Windows.Forms.Label();
            this.paymentDueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.lblPayDue = new System.Windows.Forms.Label();
            this.tbInvoiceNum = new System.Windows.Forms.TextBox();
            this.lblInvoiceNum = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddInvoiceItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInvoice
            // 
            this.gbInvoice.Controls.Add(this.paymentDatePicker);
            this.gbInvoice.Controls.Add(this.lblDatePaid);
            this.gbInvoice.Controls.Add(this.txtBoxInvoiceTotal);
            this.gbInvoice.Controls.Add(this.lblInvoiceTotal);
            this.gbInvoice.Controls.Add(this.dgAddInvoiceItems);
            this.gbInvoice.Controls.Add(this.cboxPaidStatus);
            this.gbInvoice.Controls.Add(this.lblPayStatus);
            this.gbInvoice.Controls.Add(this.paymentDueDatePicker);
            this.gbInvoice.Controls.Add(this.lblPayDue);
            this.gbInvoice.Controls.Add(this.tbInvoiceNum);
            this.gbInvoice.Controls.Add(this.lblInvoiceNum);
            this.gbInvoice.Location = new System.Drawing.Point(12, 12);
            this.gbInvoice.Name = "gbInvoice";
            this.gbInvoice.Size = new System.Drawing.Size(556, 418);
            this.gbInvoice.TabIndex = 0;
            this.gbInvoice.TabStop = false;
            this.gbInvoice.Text = "Invoice";
            // 
            // paymentDatePicker
            // 
            this.paymentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.paymentDatePicker.Location = new System.Drawing.Point(264, 112);
            this.paymentDatePicker.Name = "paymentDatePicker";
            this.paymentDatePicker.Size = new System.Drawing.Size(100, 20);
            this.paymentDatePicker.TabIndex = 10;
            // 
            // lblDatePaid
            // 
            this.lblDatePaid.AutoSize = true;
            this.lblDatePaid.Location = new System.Drawing.Point(192, 114);
            this.lblDatePaid.Name = "lblDatePaid";
            this.lblDatePaid.Size = new System.Drawing.Size(54, 13);
            this.lblDatePaid.TabIndex = 9;
            this.lblDatePaid.Text = "Date Paid";
            // 
            // txtBoxInvoiceTotal
            // 
            this.txtBoxInvoiceTotal.Location = new System.Drawing.Point(462, 380);
            this.txtBoxInvoiceTotal.Name = "txtBoxInvoiceTotal";
            this.txtBoxInvoiceTotal.ReadOnly = true;
            this.txtBoxInvoiceTotal.Size = new System.Drawing.Size(70, 20);
            this.txtBoxInvoiceTotal.TabIndex = 8;
            this.txtBoxInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.Location = new System.Drawing.Point(370, 383);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(86, 13);
            this.lblInvoiceTotal.TabIndex = 7;
            this.lblInvoiceTotal.Text = "Invoice Total:";
            // 
            // dgAddInvoiceItems
            // 
            this.dgAddInvoiceItems.AllowUserToResizeColumns = false;
            this.dgAddInvoiceItems.AllowUserToResizeRows = false;
            this.dgAddInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddInvoiceItems.Location = new System.Drawing.Point(22, 167);
            this.dgAddInvoiceItems.Name = "dgAddInvoiceItems";
            this.dgAddInvoiceItems.Size = new System.Drawing.Size(510, 197);
            this.dgAddInvoiceItems.TabIndex = 6;
            this.dgAddInvoiceItems.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgAddInvoiceItems_UserDeletingRow);
            // 
            // cboxPaidStatus
            // 
            this.cboxPaidStatus.AutoSize = true;
            this.cboxPaidStatus.Location = new System.Drawing.Point(128, 112);
            this.cboxPaidStatus.Name = "cboxPaidStatus";
            this.cboxPaidStatus.Size = new System.Drawing.Size(47, 17);
            this.cboxPaidStatus.TabIndex = 5;
            this.cboxPaidStatus.Text = "Paid";
            this.cboxPaidStatus.UseVisualStyleBackColor = true;
            this.cboxPaidStatus.CheckedChanged += new System.EventHandler(this.cboxPaidStatus_CheckedChanged);
            // 
            // lblPayStatus
            // 
            this.lblPayStatus.AutoSize = true;
            this.lblPayStatus.Location = new System.Drawing.Point(19, 114);
            this.lblPayStatus.Name = "lblPayStatus";
            this.lblPayStatus.Size = new System.Drawing.Size(81, 13);
            this.lblPayStatus.TabIndex = 4;
            this.lblPayStatus.Text = "Payment Status";
            // 
            // paymentDueDatePicker
            // 
            this.paymentDueDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.paymentDueDatePicker.Location = new System.Drawing.Point(128, 71);
            this.paymentDueDatePicker.Name = "paymentDueDatePicker";
            this.paymentDueDatePicker.Size = new System.Drawing.Size(100, 20);
            this.paymentDueDatePicker.TabIndex = 3;
            // 
            // lblPayDue
            // 
            this.lblPayDue.AutoSize = true;
            this.lblPayDue.Location = new System.Drawing.Point(19, 73);
            this.lblPayDue.Name = "lblPayDue";
            this.lblPayDue.Size = new System.Drawing.Size(97, 13);
            this.lblPayDue.TabIndex = 2;
            this.lblPayDue.Text = "Payment Due Date";
            // 
            // tbInvoiceNum
            // 
            this.tbInvoiceNum.Location = new System.Drawing.Point(128, 28);
            this.tbInvoiceNum.Name = "tbInvoiceNum";
            this.tbInvoiceNum.ReadOnly = true;
            this.tbInvoiceNum.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceNum.TabIndex = 1;
            // 
            // lblInvoiceNum
            // 
            this.lblInvoiceNum.AutoSize = true;
            this.lblInvoiceNum.Location = new System.Drawing.Point(19, 32);
            this.lblInvoiceNum.Name = "lblInvoiceNum";
            this.lblInvoiceNum.Size = new System.Drawing.Size(82, 13);
            this.lblInvoiceNum.TabIndex = 0;
            this.lblInvoiceNum.Text = "Invoice Number";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(412, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(493, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 481);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.gbInvoice.ResumeLayout(false);
            this.gbInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddInvoiceItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInvoice;
        private System.Windows.Forms.DataGridView dgAddInvoiceItems;
        private System.Windows.Forms.CheckBox cboxPaidStatus;
        private System.Windows.Forms.Label lblPayStatus;
        private System.Windows.Forms.DateTimePicker paymentDueDatePicker;
        private System.Windows.Forms.Label lblPayDue;
        private System.Windows.Forms.TextBox tbInvoiceNum;
        private System.Windows.Forms.Label lblInvoiceNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBoxInvoiceTotal;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.DateTimePicker paymentDatePicker;
        private System.Windows.Forms.Label lblDatePaid;
    }
}