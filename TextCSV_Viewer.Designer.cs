namespace FileProcessing
{
	partial class frmTextView
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.tabcMain = new System.Windows.Forms.TabControl();
            this.tabpText = new System.Windows.Forms.TabPage();
            this.rtbShow = new System.Windows.Forms.RichTextBox();
            this.btRead = new System.Windows.Forms.Button();
            this.tabpCSV = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndLine = new System.Windows.Forms.TextBox();
            this.txtStartLine = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHA256_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MD5_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHA1_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btReadCSV = new System.Windows.Forms.Button();
            this.tabcMain.SuspendLayout();
            this.tabpText.SuspendLayout();
            this.tabpCSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(105, 13);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(910, 26);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.Text = "D:\\YutData\\DistributedHome\\cdti.Code\\FileProcessing\\data\\malware_500.csv";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(1053, 8);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(113, 33);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // tabcMain
            // 
            this.tabcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcMain.Controls.Add(this.tabpText);
            this.tabcMain.Controls.Add(this.tabpCSV);
            this.tabcMain.Location = new System.Drawing.Point(12, 48);
            this.tabcMain.Name = "tabcMain";
            this.tabcMain.SelectedIndex = 0;
            this.tabcMain.Size = new System.Drawing.Size(1188, 1111);
            this.tabcMain.TabIndex = 3;
            // 
            // tabpText
            // 
            this.tabpText.Controls.Add(this.rtbShow);
            this.tabpText.Controls.Add(this.btRead);
            this.tabpText.Location = new System.Drawing.Point(4, 29);
            this.tabpText.Name = "tabpText";
            this.tabpText.Padding = new System.Windows.Forms.Padding(3);
            this.tabpText.Size = new System.Drawing.Size(1180, 1078);
            this.tabpText.TabIndex = 0;
            this.tabpText.Text = "Text";
            this.tabpText.UseVisualStyleBackColor = true;
            // 
            // rtbShow
            // 
            this.rtbShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbShow.Location = new System.Drawing.Point(17, 61);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.Size = new System.Drawing.Size(1158, 1004);
            this.rtbShow.TabIndex = 1;
            this.rtbShow.Text = "";
            this.rtbShow.WordWrap = false;
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(17, 16);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(115, 38);
            this.btRead.TabIndex = 0;
            this.btRead.Text = "read as text file";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // tabpCSV
            // 
            this.tabpCSV.Controls.Add(this.label5);
            this.tabpCSV.Controls.Add(this.txtFilter);
            this.tabpCSV.Controls.Add(this.label6);
            this.tabpCSV.Controls.Add(this.label7);
            this.tabpCSV.Controls.Add(this.txtEndLine);
            this.tabpCSV.Controls.Add(this.txtStartLine);
            this.tabpCSV.Controls.Add(this.dataGridView1);
            this.tabpCSV.Controls.Add(this.btReadCSV);
            this.tabpCSV.Location = new System.Drawing.Point(4, 29);
            this.tabpCSV.Name = "tabpCSV";
            this.tabpCSV.Padding = new System.Windows.Forms.Padding(3);
            this.tabpCSV.Size = new System.Drawing.Size(1180, 1078);
            this.tabpCSV.TabIndex = 1;
            this.tabpCSV.Text = "CSV";
            this.tabpCSV.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(871, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "Filter Ext";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFilter.Location = new System.Drawing.Point(986, 13);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(138, 38);
            this.txtFilter.TabIndex = 13;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(471, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "End Line";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(151, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 26);
            this.label7.TabIndex = 11;
            this.label7.Text = "Start Line";
            // 
            // txtEndLine
            // 
            this.txtEndLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEndLine.Location = new System.Drawing.Point(616, 13);
            this.txtEndLine.Multiline = true;
            this.txtEndLine.Name = "txtEndLine";
            this.txtEndLine.Size = new System.Drawing.Size(138, 38);
            this.txtEndLine.TabIndex = 10;
            this.txtEndLine.TextChanged += new System.EventHandler(this.txtEndLine_TextChanged);
            // 
            // txtStartLine
            // 
            this.txtStartLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtStartLine.Location = new System.Drawing.Point(262, 13);
            this.txtStartLine.Multiline = true;
            this.txtStartLine.Name = "txtStartLine";
            this.txtStartLine.Size = new System.Drawing.Size(138, 38);
            this.txtStartLine.TabIndex = 9;
            this.txtStartLine.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegisterDate,
            this.SHA256_Hash,
            this.MD5_Hash,
            this.SHA1_Hash});
            this.dataGridView1.Location = new System.Drawing.Point(25, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1133, 1003);
            this.dataGridView1.TabIndex = 1;
            // 
            // RegisterDate
            // 
            this.RegisterDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RegisterDate.HeaderText = "Date";
            this.RegisterDate.MinimumWidth = 8;
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.Width = 80;
            // 
            // SHA256_Hash
            // 
            this.SHA256_Hash.HeaderText = "SHA256 Hash";
            this.SHA256_Hash.MinimumWidth = 8;
            this.SHA256_Hash.Name = "SHA256_Hash";
            this.SHA256_Hash.Width = 150;
            // 
            // MD5_Hash
            // 
            this.MD5_Hash.HeaderText = "MD5Hash";
            this.MD5_Hash.MinimumWidth = 8;
            this.MD5_Hash.Name = "MD5_Hash";
            this.MD5_Hash.Width = 150;
            // 
            // SHA1_Hash
            // 
            this.SHA1_Hash.HeaderText = "SHA1 Hash";
            this.SHA1_Hash.MinimumWidth = 8;
            this.SHA1_Hash.Name = "SHA1_Hash";
            this.SHA1_Hash.Width = 150;
            // 
            // btReadCSV
            // 
            this.btReadCSV.Location = new System.Drawing.Point(23, 7);
            this.btReadCSV.Name = "btReadCSV";
            this.btReadCSV.Size = new System.Drawing.Size(107, 36);
            this.btReadCSV.TabIndex = 0;
            this.btReadCSV.Text = "read as csv";
            this.btReadCSV.UseVisualStyleBackColor = true;
            this.btReadCSV.Click += new System.EventHandler(this.btReadCSV_Click);
            // 
            // frmTextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 1169);
            this.Controls.Add(this.tabcMain);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Name = "frmTextView";
            this.Text = "Text/CSV viewer";
            this.tabcMain.ResumeLayout(false);
            this.tabpText.ResumeLayout(false);
            this.tabpCSV.ResumeLayout(false);
            this.tabpCSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbFileName;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.TabControl tabcMain;
		private System.Windows.Forms.TabPage tabpText;
		private System.Windows.Forms.TabPage tabpCSV;
		private System.Windows.Forms.Button btRead;
		private System.Windows.Forms.RichTextBox rtbShow;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btReadCSV;
		private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn SHA256_Hash;
		private System.Windows.Forms.DataGridViewTextBoxColumn MD5_Hash;
		private System.Windows.Forms.DataGridViewTextBoxColumn SHA1_Hash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEndLine;
        private System.Windows.Forms.TextBox txtStartLine;
    }
}

