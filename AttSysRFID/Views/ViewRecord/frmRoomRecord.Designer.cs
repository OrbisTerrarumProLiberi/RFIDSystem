namespace AttSysRFID.Views.ViewRecord
{
    partial class frmRoomRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgRoomRecord = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbYearClass = new System.Windows.Forms.ComboBox();
            this.cbYC = new System.Windows.Forms.CheckBox();
            this.cbS = new System.Windows.Forms.CheckBox();
            this.labscbS = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.cbRC = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRoomCode = new System.Windows.Forms.ComboBox();
            this.cbSC = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubCode = new System.Windows.Forms.ComboBox();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoomRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DimGray;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1153, 36);
            this.label12.TabIndex = 61;
            this.label12.Text = "   Room Record";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cbSC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbSubCode);
            this.panel1.Controls.Add(this.cbRC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbRoomCode);
            this.panel1.Controls.Add(this.cbS);
            this.panel1.Controls.Add(this.labscbS);
            this.panel1.Controls.Add(this.cmbSemester);
            this.panel1.Controls.Add(this.cbYC);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cmbYearClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(782, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 493);
            this.panel1.TabIndex = 67;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.dgRoomRecord);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 493);
            this.panel2.TabIndex = 68;
            // 
            // dgRoomRecord
            // 
            this.dgRoomRecord.AllowUserToAddRows = false;
            this.dgRoomRecord.AllowUserToDeleteRows = false;
            this.dgRoomRecord.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRoomRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgRoomRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoomRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStudentID,
            this.Column1,
            this.Column6,
            this.Column7,
            this.Column2,
            this.ColStudent,
            this.ColStudentName,
            this.Column4,
            this.Column3,
            this.Column5});
            this.dgRoomRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgRoomRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRoomRecord.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgRoomRecord.Location = new System.Drawing.Point(0, 0);
            this.dgRoomRecord.Name = "dgRoomRecord";
            this.dgRoomRecord.ReadOnly = true;
            this.dgRoomRecord.RowHeadersVisible = false;
            this.dgRoomRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRoomRecord.Size = new System.Drawing.Size(782, 493);
            this.dgRoomRecord.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(46, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 17);
            this.label16.TabIndex = 48;
            this.label16.Text = "Year Class:";
            // 
            // cmbYearClass
            // 
            this.cmbYearClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYearClass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYearClass.ForeColor = System.Drawing.Color.DimGray;
            this.cmbYearClass.FormattingEnabled = true;
            this.cmbYearClass.Location = new System.Drawing.Point(22, 64);
            this.cmbYearClass.Name = "cmbYearClass";
            this.cmbYearClass.Size = new System.Drawing.Size(159, 25);
            this.cmbYearClass.TabIndex = 47;
            this.cmbYearClass.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedValueChanged);
            // 
            // cbYC
            // 
            this.cbYC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYC.AutoSize = true;
            this.cbYC.Location = new System.Drawing.Point(27, 46);
            this.cbYC.Name = "cbYC";
            this.cbYC.Size = new System.Drawing.Size(15, 14);
            this.cbYC.TabIndex = 49;
            this.cbYC.UseVisualStyleBackColor = true;
            // 
            // cbS
            // 
            this.cbS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbS.AutoSize = true;
            this.cbS.Location = new System.Drawing.Point(199, 46);
            this.cbS.Name = "cbS";
            this.cbS.Size = new System.Drawing.Size(15, 14);
            this.cbS.TabIndex = 52;
            this.cbS.UseVisualStyleBackColor = true;
            // 
            // labscbS
            // 
            this.labscbS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labscbS.AutoSize = true;
            this.labscbS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labscbS.ForeColor = System.Drawing.Color.DimGray;
            this.labscbS.Location = new System.Drawing.Point(218, 43);
            this.labscbS.Name = "labscbS";
            this.labscbS.Size = new System.Drawing.Size(67, 17);
            this.labscbS.TabIndex = 51;
            this.labscbS.Text = "Semester:";
            // 
            // cmbSemester
            // 
            this.cmbSemester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSemester.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSemester.ForeColor = System.Drawing.Color.DimGray;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(194, 64);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(159, 25);
            this.cmbSemester.TabIndex = 50;
            this.cmbSemester.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbYearClass_KeyDown);
            this.cmbSemester.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbYearClass_KeyPress);
            // 
            // cbRC
            // 
            this.cbRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRC.AutoSize = true;
            this.cbRC.Location = new System.Drawing.Point(30, 105);
            this.cbRC.Name = "cbRC";
            this.cbRC.Size = new System.Drawing.Size(15, 14);
            this.cbRC.TabIndex = 55;
            this.cbRC.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(49, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Room Code:";
            // 
            // cmbRoomCode
            // 
            this.cmbRoomCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRoomCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoomCode.ForeColor = System.Drawing.Color.DimGray;
            this.cmbRoomCode.FormattingEnabled = true;
            this.cmbRoomCode.Location = new System.Drawing.Point(25, 123);
            this.cmbRoomCode.Name = "cmbRoomCode";
            this.cmbRoomCode.Size = new System.Drawing.Size(159, 25);
            this.cmbRoomCode.TabIndex = 53;
            this.cmbRoomCode.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedValueChanged);
            this.cmbRoomCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbYearClass_KeyDown);
            this.cmbRoomCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbYearClass_KeyPress);
            // 
            // cbSC
            // 
            this.cbSC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSC.AutoSize = true;
            this.cbSC.Location = new System.Drawing.Point(199, 105);
            this.cbSC.Name = "cbSC";
            this.cbSC.Size = new System.Drawing.Size(15, 14);
            this.cbSC.TabIndex = 58;
            this.cbSC.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(218, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Subject Code:";
            // 
            // cmbSubCode
            // 
            this.cmbSubCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSubCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubCode.ForeColor = System.Drawing.Color.DimGray;
            this.cmbSubCode.FormattingEnabled = true;
            this.cmbSubCode.Location = new System.Drawing.Point(194, 123);
            this.cmbSubCode.Name = "cmbSubCode";
            this.cmbSubCode.Size = new System.Drawing.Size(159, 25);
            this.cmbSubCode.TabIndex = 56;
            this.cmbSubCode.SelectedIndexChanged += new System.EventHandler(this.cmbSemester_SelectedValueChanged);
            this.cmbSubCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbYearClass_KeyDown);
            this.cmbSubCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbYearClass_KeyPress);
            // 
            // ColStudentID
            // 
            this.ColStudentID.HeaderText = "ID";
            this.ColStudentID.Name = "ColStudentID";
            this.ColStudentID.ReadOnly = true;
            this.ColStudentID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 51;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "Student ID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column7.HeaderText = "Name";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "Semester";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColStudent
            // 
            this.ColStudent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColStudent.HeaderText = "Building";
            this.ColStudent.Name = "ColStudent";
            this.ColStudent.ReadOnly = true;
            this.ColStudent.Width = 80;
            // 
            // ColStudentName
            // 
            this.ColStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColStudentName.HeaderText = "Room Code";
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            this.ColStudentName.Width = 80;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Room Description";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Time";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Wingdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.NullValue = "ý";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column5.HeaderText = "Delete";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Text = "ý";
            this.Column5.Width = 50;
            // 
            // frmRoomRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1153, 529);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Name = "frmRoomRecord";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRoomRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgRoomRecord;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbYearClass;
        private System.Windows.Forms.CheckBox cbSC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubCode;
        private System.Windows.Forms.CheckBox cbRC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRoomCode;
        private System.Windows.Forms.CheckBox cbS;
        private System.Windows.Forms.Label labscbS;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.CheckBox cbYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}