namespace MeterBoard32.Forms
{
    partial class MeterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxManufacturerId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBoxMeterType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxPrimaryAddress = new System.Windows.Forms.ComboBox();
            this.txtBoxMeterId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataRecordListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnSaveMeter = new System.Windows.Forms.Button();
            this.btnCancelMeter = new System.Windows.Forms.Button();
            this.btnAddDataRecord = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordListView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxManufacturerId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbBoxMeterType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbBoxPrimaryAddress);
            this.groupBox1.Controls.Add(this.txtBoxMeterId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meter Information";
            // 
            // txtBoxManufacturerId
            // 
            this.txtBoxManufacturerId.Location = new System.Drawing.Point(490, 44);
            this.txtBoxManufacturerId.MaxLength = 3;
            this.txtBoxManufacturerId.Name = "txtBoxManufacturerId";
            this.txtBoxManufacturerId.Size = new System.Drawing.Size(121, 20);
            this.txtBoxManufacturerId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Manufacturer Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Meter Type:";
            // 
            // cmbBoxMeterType
            // 
            this.cmbBoxMeterType.FormattingEnabled = true;
            this.cmbBoxMeterType.Location = new System.Drawing.Point(325, 44);
            this.cmbBoxMeterType.Name = "cmbBoxMeterType";
            this.cmbBoxMeterType.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxMeterType.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primary Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MeterId:";
            // 
            // cmbBoxPrimaryAddress
            // 
            this.cmbBoxPrimaryAddress.FormattingEnabled = true;
            this.cmbBoxPrimaryAddress.Location = new System.Drawing.Point(170, 44);
            this.cmbBoxPrimaryAddress.Name = "cmbBoxPrimaryAddress";
            this.cmbBoxPrimaryAddress.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxPrimaryAddress.TabIndex = 1;
            // 
            // txtBoxMeterId
            // 
            this.txtBoxMeterId.Location = new System.Drawing.Point(18, 44);
            this.txtBoxMeterId.MaxLength = 8;
            this.txtBoxMeterId.Name = "txtBoxMeterId";
            this.txtBoxMeterId.Size = new System.Drawing.Size(121, 20);
            this.txtBoxMeterId.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataRecordListView);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 271);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meter Data Records";
            // 
            // objectListView1
            // 
            this.dataRecordListView.AllColumns.Add(this.olvColumn6);
            this.dataRecordListView.AllColumns.Add(this.olvColumn1);
            this.dataRecordListView.AllColumns.Add(this.olvColumn2);
            this.dataRecordListView.AllColumns.Add(this.olvColumn3);
            this.dataRecordListView.AllColumns.Add(this.olvColumn4);
            this.dataRecordListView.AllColumns.Add(this.olvColumn7);
            this.dataRecordListView.AllColumns.Add(this.olvColumn8);
            this.dataRecordListView.AllColumns.Add(this.olvColumn9);
            this.dataRecordListView.AllColumns.Add(this.olvColumn10);
            this.dataRecordListView.AllColumns.Add(this.olvColumn5);
            this.dataRecordListView.CellEditUseWholeCell = false;
            this.dataRecordListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn6,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvColumn5});
            this.dataRecordListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataRecordListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dataRecordListView.Location = new System.Drawing.Point(6, 19);
            this.dataRecordListView.Name = "objectListView1";
            this.dataRecordListView.ShowGroups = false;
            this.dataRecordListView.Size = new System.Drawing.Size(884, 246);
            this.dataRecordListView.TabIndex = 1;
            this.dataRecordListView.UseCompatibleStateImageBehavior = false;
            this.dataRecordListView.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "DataType";
            this.olvColumn6.MaximumWidth = 100;
            this.olvColumn6.MinimumWidth = 100;
            this.olvColumn6.Text = "Data Type";
            this.olvColumn6.Width = 100;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "StorageNumber";
            this.olvColumn1.MaximumWidth = 60;
            this.olvColumn1.MinimumWidth = 60;
            this.olvColumn1.Text = "Storage No";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Tariff";
            this.olvColumn2.MaximumWidth = 50;
            this.olvColumn2.MinimumWidth = 50;
            this.olvColumn2.Text = "Tariff";
            this.olvColumn2.Width = 50;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Function";
            this.olvColumn3.MaximumWidth = 80;
            this.olvColumn3.MinimumWidth = 80;
            this.olvColumn3.Text = "Function";
            this.olvColumn3.Width = 80;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Subunit";
            this.olvColumn4.MaximumWidth = 70;
            this.olvColumn4.MinimumWidth = 70;
            this.olvColumn4.Text = "Subunit";
            this.olvColumn4.Width = 70;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "DIB";
            this.olvColumn7.MaximumWidth = 100;
            this.olvColumn7.MinimumWidth = 100;
            this.olvColumn7.Text = "DIB";
            this.olvColumn7.Width = 100;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "VIB";
            this.olvColumn8.MaximumWidth = 100;
            this.olvColumn8.MinimumWidth = 100;
            this.olvColumn8.Text = "VIB";
            this.olvColumn8.Width = 100;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "Data";
            this.olvColumn9.MaximumWidth = 100;
            this.olvColumn9.MinimumWidth = 100;
            this.olvColumn9.Text = "DATA";
            this.olvColumn9.Width = 100;
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "Delete";
            this.olvColumn10.ButtonMaxWidth = 100;
            this.olvColumn10.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn10.IsButton = true;
            this.olvColumn10.MinimumWidth = 100;
            this.olvColumn10.Text = "";
            this.olvColumn10.Width = 90;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Modify";
            this.olvColumn5.ButtonMaxWidth = 100;
            this.olvColumn5.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn5.EnableButtonWhenItemIsDisabled = true;
            this.olvColumn5.FillsFreeSpace = true;
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvColumn5.IsButton = true;
            this.olvColumn5.MinimumWidth = 100;
            this.olvColumn5.Text = "";
            this.olvColumn5.Width = 100;
            // 
            // btnSaveMeter
            // 
            this.btnSaveMeter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveMeter.Location = new System.Drawing.Point(834, 389);
            this.btnSaveMeter.Name = "btnSaveMeter";
            this.btnSaveMeter.Size = new System.Drawing.Size(75, 33);
            this.btnSaveMeter.TabIndex = 2;
            this.btnSaveMeter.Text = "&Save";
            this.btnSaveMeter.UseVisualStyleBackColor = true;
            this.btnSaveMeter.Click += new System.EventHandler(this.btnSaveMeter_Click);
            // 
            // btnCancelMeter
            // 
            this.btnCancelMeter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelMeter.Location = new System.Drawing.Point(753, 389);
            this.btnCancelMeter.Name = "btnCancelMeter";
            this.btnCancelMeter.Size = new System.Drawing.Size(75, 33);
            this.btnCancelMeter.TabIndex = 3;
            this.btnCancelMeter.Text = "&Cancel";
            this.btnCancelMeter.UseVisualStyleBackColor = true;
            this.btnCancelMeter.Click += new System.EventHandler(this.btnCancelMeter_Click);
            // 
            // btnAddDataRecord
            // 
            this.btnAddDataRecord.Location = new System.Drawing.Point(12, 389);
            this.btnAddDataRecord.Name = "btnAddDataRecord";
            this.btnAddDataRecord.Size = new System.Drawing.Size(75, 33);
            this.btnAddDataRecord.TabIndex = 4;
            this.btnAddDataRecord.Text = "&Add Record";
            this.btnAddDataRecord.UseVisualStyleBackColor = true;
            this.btnAddDataRecord.Click += new System.EventHandler(this.btnAddDataRecord_Click);
            // 
            // MeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 430);
            this.Controls.Add(this.btnAddDataRecord);
            this.Controls.Add(this.btnCancelMeter);
            this.Controls.Add(this.btnSaveMeter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Meter: ";
            this.Load += new System.EventHandler(this.MeterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveMeter;
        private System.Windows.Forms.Button btnCancelMeter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoxMeterType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxPrimaryAddress;
        private System.Windows.Forms.TextBox txtBoxMeterId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxManufacturerId;
        private System.Windows.Forms.Button btnAddDataRecord;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.ObjectListView dataRecordListView;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
    }
}