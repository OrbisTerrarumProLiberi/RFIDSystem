namespace AttSysRFID.Views.Attendance
{
    partial class frmAttendanceLogs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtTimeIN = new System.Windows.Forms.DateTimePicker();
            this.dtTimeOUT = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTimeINOUT = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDateStart = new System.Windows.Forms.DateTimePicker();
            this.dtDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDStart = new System.Windows.Forms.CheckBox();
            this.cbSC = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubCode = new System.Windows.Forms.ComboBox();
            this.cbRC = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRoomCode = new System.Windows.Forms.ComboBox();
            this.cbDay = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.dgAttendanceLogs = new System.Windows.Forms.DataGridView();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.PrintDoc = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAttendanceLogs)).BeginInit();
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
            this.label12.Size = new System.Drawing.Size(1215, 36);
            this.label12.TabIndex = 55;
            this.label12.Text = "     Attendance logs";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cbSC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbSubCode);
            this.panel1.Controls.Add(this.cbRC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbRoomCode);
            this.panel1.Controls.Add(this.cbDay);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cmbDays);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(850, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 479);
            this.panel1.TabIndex = 84;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtTimeIN);
            this.groupBox2.Controls.Add(this.dtTimeOUT);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbTimeINOUT);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(20, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 76);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    Time";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(182, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 69;
            this.label6.Text = "OUT:";
            // 
            // dtTimeIN
            // 
            this.dtTimeIN.CustomFormat = "HH:mm:ss tt";
            this.dtTimeIN.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtTimeIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeIN.Location = new System.Drawing.Point(22, 42);
            this.dtTimeIN.Name = "dtTimeIN";
            this.dtTimeIN.ShowUpDown = true;
            this.dtTimeIN.Size = new System.Drawing.Size(137, 25);
            this.dtTimeIN.TabIndex = 66;
            this.dtTimeIN.ValueChanged += new System.EventHandler(this.cmbDays_SelectedValueChanged);
            // 
            // dtTimeOUT
            // 
            this.dtTimeOUT.CustomFormat = "HH:mm:ss tt";
            this.dtTimeOUT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtTimeOUT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeOUT.Location = new System.Drawing.Point(179, 42);
            this.dtTimeOUT.Name = "dtTimeOUT";
            this.dtTimeOUT.ShowUpDown = true;
            this.dtTimeOUT.Size = new System.Drawing.Size(137, 25);
            this.dtTimeOUT.TabIndex = 67;
            this.dtTimeOUT.ValueChanged += new System.EventHandler(this.cmbDays_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(24, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 65;
            this.label5.Text = "IN:";
            // 
            // cbTimeINOUT
            // 
            this.cbTimeINOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTimeINOUT.AutoSize = true;
            this.cbTimeINOUT.Location = new System.Drawing.Point(5, 1);
            this.cbTimeINOUT.Name = "cbTimeINOUT";
            this.cbTimeINOUT.Size = new System.Drawing.Size(15, 14);
            this.cbTimeINOUT.TabIndex = 68;
            this.cbTimeINOUT.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtDateStart);
            this.groupBox1.Controls.Add(this.dtDateEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbDStart);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 75);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    Date";
            // 
            // dtDateStart
            // 
            this.dtDateStart.CustomFormat = "MMM. dd, yyyy";
            this.dtDateStart.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateStart.Location = new System.Drawing.Point(22, 41);
            this.dtDateStart.Name = "dtDateStart";
            this.dtDateStart.Size = new System.Drawing.Size(137, 25);
            this.dtDateStart.TabIndex = 59;
            this.dtDateStart.ValueChanged += new System.EventHandler(this.cmbDays_SelectedValueChanged);
            // 
            // dtDateEnd
            // 
            this.dtDateEnd.CustomFormat = "MMM. dd, yyyy";
            this.dtDateEnd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateEnd.Location = new System.Drawing.Point(179, 41);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.Size = new System.Drawing.Size(137, 25);
            this.dtDateEnd.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(182, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 62;
            this.label4.Text = "End:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Start:";
            // 
            // cbDStart
            // 
            this.cbDStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDStart.AutoSize = true;
            this.cbDStart.Location = new System.Drawing.Point(6, 3);
            this.cbDStart.Name = "cbDStart";
            this.cbDStart.Size = new System.Drawing.Size(15, 14);
            this.cbDStart.TabIndex = 64;
            this.cbDStart.UseVisualStyleBackColor = true;
            // 
            // cbSC
            // 
            this.cbSC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSC.AutoSize = true;
            this.cbSC.Location = new System.Drawing.Point(199, 210);
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
            this.label3.Location = new System.Drawing.Point(218, 207);
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
            this.cmbSubCode.Location = new System.Drawing.Point(194, 228);
            this.cmbSubCode.Name = "cmbSubCode";
            this.cmbSubCode.Size = new System.Drawing.Size(159, 25);
            this.cmbSubCode.TabIndex = 56;
            this.cmbSubCode.SelectedValueChanged += new System.EventHandler(this.cmbDays_SelectedValueChanged);
            this.cmbSubCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDays_KeyDown);
            this.cmbSubCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDays_KeyPress);
            // 
            // cbRC
            // 
            this.cbRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRC.AutoSize = true;
            this.cbRC.Location = new System.Drawing.Point(25, 267);
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
            this.label2.Location = new System.Drawing.Point(44, 264);
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
            this.cmbRoomCode.Location = new System.Drawing.Point(20, 285);
            this.cmbRoomCode.Name = "cmbRoomCode";
            this.cmbRoomCode.Size = new System.Drawing.Size(159, 25);
            this.cmbRoomCode.TabIndex = 53;
            this.cmbRoomCode.SelectedValueChanged += new System.EventHandler(this.cmbDays_SelectedValueChanged);
            this.cmbRoomCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDays_KeyDown);
            this.cmbRoomCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDays_KeyPress);
            // 
            // cbDay
            // 
            this.cbDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDay.AutoSize = true;
            this.cbDay.Location = new System.Drawing.Point(25, 210);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(15, 14);
            this.cbDay.TabIndex = 49;
            this.cbDay.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(44, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 48;
            this.label16.Text = "Day:";
            // 
            // cmbDays
            // 
            this.cmbDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDays.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDays.ForeColor = System.Drawing.Color.DimGray;
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Location = new System.Drawing.Point(20, 228);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(159, 25);
            this.cmbDays.TabIndex = 47;
            this.cmbDays.SelectedValueChanged += new System.EventHandler(this.cmbDays_SelectedValueChanged);
            this.cmbDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDays_KeyDown);
            this.cmbDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDays_KeyPress);
            // 
            // dgAttendanceLogs
            // 
            this.dgAttendanceLogs.AllowUserToAddRows = false;
            this.dgAttendanceLogs.AllowUserToDeleteRows = false;
            this.dgAttendanceLogs.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAttendanceLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAttendanceLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAttendanceLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStudentID,
            this.Column1,
            this.Column6,
            this.Column7,
            this.ColStudent,
            this.ColStudentName,
            this.Column4,
            this.Column3,
            this.Column2});
            this.dgAttendanceLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgAttendanceLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAttendanceLogs.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgAttendanceLogs.Location = new System.Drawing.Point(0, 36);
            this.dgAttendanceLogs.Name = "dgAttendanceLogs";
            this.dgAttendanceLogs.ReadOnly = true;
            this.dgAttendanceLogs.RowHeadersVisible = false;
            this.dgAttendanceLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAttendanceLogs.Size = new System.Drawing.Size(850, 479);
            this.dgAttendanceLogs.TabIndex = 85;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.HeaderText = "Name";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // ColStudent
            // 
            this.ColStudent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColStudent.HeaderText = "Subject";
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
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "Day";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "IN";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Format = "G";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "OUT";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.DimGray;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1139, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 26);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.Tag = "13";
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // frmAttendanceLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 515);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgAttendanceLogs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Name = "frmAttendanceLogs";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAttendanceLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbSC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubCode;
        private System.Windows.Forms.CheckBox cbRC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRoomCode;
        private System.Windows.Forms.CheckBox cbDay;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbDays;
        private System.Windows.Forms.DataGridView dgAttendanceLogs;
        private System.Windows.Forms.CheckBox cbDStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDateEnd;
        private System.Windows.Forms.DateTimePicker dtDateStart;
        private System.Windows.Forms.CheckBox cbTimeINOUT;
        private System.Windows.Forms.DateTimePicker dtTimeOUT;
        private System.Windows.Forms.DateTimePicker dtTimeIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument PrintDoc;
    }
}