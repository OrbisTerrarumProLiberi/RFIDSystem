namespace AttSysRFID.Views.Student
{
    partial class frmStudent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlStudentRegistration = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbActiveStd = new System.Windows.Forms.CheckBox();
            this.cbContactNoStd = new System.Windows.Forms.CheckBox();
            this.cbRFIDstd = new System.Windows.Forms.CheckBox();
            this.cbEnrolled = new System.Windows.Forms.CheckBox();
            this.cbGraduated = new System.Windows.Forms.CheckBox();
            this.cbCompleted = new System.Windows.Forms.CheckBox();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbStudentCourse = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tcMotherFather = new System.Windows.Forms.TabControl();
            this.Mother = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbContactMoms = new System.Windows.Forms.CheckBox();
            this.cbRFIDMoms = new System.Windows.Forms.CheckBox();
            this.cbActiveMoms = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cmbMotherCivilStatus = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMotherAddress = new System.Windows.Forms.TextBox();
            this.txtMotherRFIDNo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtMotherContactNo = new System.Windows.Forms.MaskedTextBox();
            this.txtMotherMiddleName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtMotherFirstName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMotherLastName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.Father = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbContactDads = new System.Windows.Forms.CheckBox();
            this.cbRFIDDads = new System.Windows.Forms.CheckBox();
            this.cbActiveDads = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbFatherCivilStatus = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFatherAddress = new System.Windows.Forms.TextBox();
            this.txtFatherRFIDNo = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFatherContactNo = new System.Windows.Forms.MaskedTextBox();
            this.txtFatherMiddleName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtFatherFirstName = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFatherLastName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtStudentBday = new System.Windows.Forms.DateTimePicker();
            this.txtStudentAddress = new System.Windows.Forms.TextBox();
            this.txtStudentRFIDNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbStudentFemale = new System.Windows.Forms.RadioButton();
            this.rbStudentMale = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStudentContactNo = new System.Windows.Forms.MaskedTextBox();
            this.txtStudentMiddleName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStudentFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbApplication = new System.Windows.Forms.ComboBox();
            this.txtStudentLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlRecordList = new System.Windows.Forms.Panel();
            this.dgStudentRecord = new System.Windows.Forms.DataGridView();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.ComSerial = new System.IO.Ports.SerialPort(this.components);
            this.AutoScanTimer = new System.Windows.Forms.Timer(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlStudentRegistration.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.tcMotherFather.SuspendLayout();
            this.Mother.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Father.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlRecordList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStudentRegistration
            // 
            this.pnlStudentRegistration.AutoScroll = true;
            this.pnlStudentRegistration.BackColor = System.Drawing.Color.White;
            this.pnlStudentRegistration.Controls.Add(this.groupBox2);
            this.pnlStudentRegistration.Controls.Add(this.picStudent);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentID);
            this.pnlStudentRegistration.Controls.Add(this.label17);
            this.pnlStudentRegistration.Controls.Add(this.label16);
            this.pnlStudentRegistration.Controls.Add(this.cmbYearLevel);
            this.pnlStudentRegistration.Controls.Add(this.label15);
            this.pnlStudentRegistration.Controls.Add(this.cmbStudentCourse);
            this.pnlStudentRegistration.Controls.Add(this.label13);
            this.pnlStudentRegistration.Controls.Add(this.label14);
            this.pnlStudentRegistration.Controls.Add(this.label11);
            this.pnlStudentRegistration.Controls.Add(this.label1);
            this.pnlStudentRegistration.Controls.Add(this.label10);
            this.pnlStudentRegistration.Controls.Add(this.tcMotherFather);
            this.pnlStudentRegistration.Controls.Add(this.label9);
            this.pnlStudentRegistration.Controls.Add(this.label8);
            this.pnlStudentRegistration.Controls.Add(this.dtStudentBday);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentAddress);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentRFIDNo);
            this.pnlStudentRegistration.Controls.Add(this.label7);
            this.pnlStudentRegistration.Controls.Add(this.groupBox1);
            this.pnlStudentRegistration.Controls.Add(this.label6);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentContactNo);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentMiddleName);
            this.pnlStudentRegistration.Controls.Add(this.label5);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentFirstName);
            this.pnlStudentRegistration.Controls.Add(this.label4);
            this.pnlStudentRegistration.Controls.Add(this.label3);
            this.pnlStudentRegistration.Controls.Add(this.cmbApplication);
            this.pnlStudentRegistration.Controls.Add(this.txtStudentLastName);
            this.pnlStudentRegistration.Controls.Add(this.label2);
            this.pnlStudentRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStudentRegistration.Location = new System.Drawing.Point(0, 36);
            this.pnlStudentRegistration.Name = "pnlStudentRegistration";
            this.pnlStudentRegistration.Size = new System.Drawing.Size(838, 500);
            this.pnlStudentRegistration.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.cbActiveStd);
            this.groupBox2.Controls.Add(this.cbContactNoStd);
            this.groupBox2.Controls.Add(this.cbRFIDstd);
            this.groupBox2.Controls.Add(this.cbEnrolled);
            this.groupBox2.Controls.Add(this.cbGraduated);
            this.groupBox2.Controls.Add(this.cbCompleted);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(54, 499);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 56);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other status";
            // 
            // cbActiveStd
            // 
            this.cbActiveStd.AutoSize = true;
            this.cbActiveStd.Location = new System.Drawing.Point(619, 24);
            this.cbActiveStd.Name = "cbActiveStd";
            this.cbActiveStd.Size = new System.Drawing.Size(61, 21);
            this.cbActiveStd.TabIndex = 17;
            this.cbActiveStd.Text = "Active";
            this.cbActiveStd.UseVisualStyleBackColor = true;
            // 
            // cbContactNoStd
            // 
            this.cbContactNoStd.AutoSize = true;
            this.cbContactNoStd.Location = new System.Drawing.Point(494, 24);
            this.cbContactNoStd.Name = "cbContactNoStd";
            this.cbContactNoStd.Size = new System.Drawing.Size(96, 21);
            this.cbContactNoStd.TabIndex = 16;
            this.cbContactNoStd.Text = "Contact No.";
            this.cbContactNoStd.UseVisualStyleBackColor = true;
            // 
            // cbRFIDstd
            // 
            this.cbRFIDstd.AutoSize = true;
            this.cbRFIDstd.Location = new System.Drawing.Point(375, 24);
            this.cbRFIDstd.Name = "cbRFIDstd";
            this.cbRFIDstd.Size = new System.Drawing.Size(78, 21);
            this.cbRFIDstd.TabIndex = 15;
            this.cbRFIDstd.Text = "RFID No.";
            this.cbRFIDstd.UseVisualStyleBackColor = true;
            // 
            // cbEnrolled
            // 
            this.cbEnrolled.AutoSize = true;
            this.cbEnrolled.Location = new System.Drawing.Point(257, 24);
            this.cbEnrolled.Name = "cbEnrolled";
            this.cbEnrolled.Size = new System.Drawing.Size(75, 21);
            this.cbEnrolled.TabIndex = 14;
            this.cbEnrolled.Text = "Enrolled";
            this.cbEnrolled.UseVisualStyleBackColor = true;
            // 
            // cbGraduated
            // 
            this.cbGraduated.AutoSize = true;
            this.cbGraduated.Location = new System.Drawing.Point(26, 24);
            this.cbGraduated.Name = "cbGraduated";
            this.cbGraduated.Size = new System.Drawing.Size(89, 21);
            this.cbGraduated.TabIndex = 12;
            this.cbGraduated.Text = "Graduated";
            this.cbGraduated.UseVisualStyleBackColor = true;
            // 
            // cbCompleted
            // 
            this.cbCompleted.AutoSize = true;
            this.cbCompleted.Location = new System.Drawing.Point(139, 24);
            this.cbCompleted.Name = "cbCompleted";
            this.cbCompleted.Size = new System.Drawing.Size(91, 21);
            this.cbCompleted.TabIndex = 13;
            this.cbCompleted.Text = "Completed";
            this.cbCompleted.UseVisualStyleBackColor = true;
            // 
            // picStudent
            // 
            this.picStudent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStudent.Location = new System.Drawing.Point(562, 46);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(183, 155);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudent.TabIndex = 49;
            this.picStudent.TabStop = false;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStudentID.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentID.Location = new System.Drawing.Point(54, 176);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(213, 25);
            this.txtStudentID.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(57, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 17);
            this.label17.TabIndex = 47;
            this.label17.Text = "Student ID:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(306, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 17);
            this.label16.TabIndex = 46;
            this.label16.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbYearLevel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYearLevel.ForeColor = System.Drawing.Color.DimGray;
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Location = new System.Drawing.Point(303, 176);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(213, 25);
            this.cmbYearLevel.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(306, 345);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 44;
            this.label15.Text = "Course:";
            // 
            // cmbStudentCourse
            // 
            this.cmbStudentCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbStudentCourse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStudentCourse.ForeColor = System.Drawing.Color.DimGray;
            this.cmbStudentCourse.FormattingEnabled = true;
            this.cmbStudentCourse.Location = new System.Drawing.Point(303, 365);
            this.cmbStudentCourse.Name = "cmbStudentCourse";
            this.cmbStudentCourse.Size = new System.Drawing.Size(458, 25);
            this.cmbStudentCourse.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(2, 587);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 17);
            this.label13.TabIndex = 42;
            this.label13.Text = "Parent(s) Information";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.BackColor = System.Drawing.Color.DimGray;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(-1, 608);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(816, 1);
            this.label14.TabIndex = 41;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(7, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 17);
            this.label11.TabIndex = 40;
            this.label11.Text = "Student Information";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 1);
            this.label1.TabIndex = 39;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(-5, 916);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 17);
            this.label10.TabIndex = 38;
            // 
            // tcMotherFather
            // 
            this.tcMotherFather.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tcMotherFather.Controls.Add(this.Mother);
            this.tcMotherFather.Controls.Add(this.Father);
            this.tcMotherFather.ItemSize = new System.Drawing.Size(140, 25);
            this.tcMotherFather.Location = new System.Drawing.Point(6, 628);
            this.tcMotherFather.Name = "tcMotherFather";
            this.tcMotherFather.SelectedIndex = 0;
            this.tcMotherFather.Size = new System.Drawing.Size(811, 381);
            this.tcMotherFather.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMotherFather.TabIndex = 37;
            // 
            // Mother
            // 
            this.Mother.Controls.Add(this.groupBox4);
            this.Mother.Controls.Add(this.label31);
            this.Mother.Controls.Add(this.cmbMotherCivilStatus);
            this.Mother.Controls.Add(this.label18);
            this.Mother.Controls.Add(this.txtMotherAddress);
            this.Mother.Controls.Add(this.txtMotherRFIDNo);
            this.Mother.Controls.Add(this.label19);
            this.Mother.Controls.Add(this.label20);
            this.Mother.Controls.Add(this.txtMotherContactNo);
            this.Mother.Controls.Add(this.txtMotherMiddleName);
            this.Mother.Controls.Add(this.label21);
            this.Mother.Controls.Add(this.txtMotherFirstName);
            this.Mother.Controls.Add(this.label22);
            this.Mother.Controls.Add(this.txtMotherLastName);
            this.Mother.Controls.Add(this.label23);
            this.Mother.Location = new System.Drawing.Point(4, 29);
            this.Mother.Name = "Mother";
            this.Mother.Padding = new System.Windows.Forms.Padding(3);
            this.Mother.Size = new System.Drawing.Size(803, 348);
            this.Mother.TabIndex = 0;
            this.Mother.Text = "Mother Details";
            this.Mother.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Controls.Add(this.cbContactMoms);
            this.groupBox4.Controls.Add(this.cbRFIDMoms);
            this.groupBox4.Controls.Add(this.cbActiveMoms);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox4.Location = new System.Drawing.Point(47, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(707, 56);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other status";
            // 
            // cbContactMoms
            // 
            this.cbContactMoms.AutoSize = true;
            this.cbContactMoms.Location = new System.Drawing.Point(132, 24);
            this.cbContactMoms.Name = "cbContactMoms";
            this.cbContactMoms.Size = new System.Drawing.Size(96, 21);
            this.cbContactMoms.TabIndex = 55;
            this.cbContactMoms.Text = "Contact No.";
            this.cbContactMoms.UseVisualStyleBackColor = true;
            // 
            // cbRFIDMoms
            // 
            this.cbRFIDMoms.AutoSize = true;
            this.cbRFIDMoms.Location = new System.Drawing.Point(23, 24);
            this.cbRFIDMoms.Name = "cbRFIDMoms";
            this.cbRFIDMoms.Size = new System.Drawing.Size(78, 21);
            this.cbRFIDMoms.TabIndex = 54;
            this.cbRFIDMoms.Text = "RFID No.";
            this.cbRFIDMoms.UseVisualStyleBackColor = true;
            // 
            // cbActiveMoms
            // 
            this.cbActiveMoms.AutoSize = true;
            this.cbActiveMoms.Location = new System.Drawing.Point(260, 24);
            this.cbActiveMoms.Name = "cbActiveMoms";
            this.cbActiveMoms.Size = new System.Drawing.Size(61, 21);
            this.cbActiveMoms.TabIndex = 53;
            this.cbActiveMoms.Text = "Active";
            this.cbActiveMoms.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.DimGray;
            this.label31.Location = new System.Drawing.Point(544, 112);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 17);
            this.label31.TabIndex = 64;
            this.label31.Text = "Status:";
            // 
            // cmbMotherCivilStatus
            // 
            this.cmbMotherCivilStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbMotherCivilStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMotherCivilStatus.ForeColor = System.Drawing.Color.DimGray;
            this.cmbMotherCivilStatus.FormattingEnabled = true;
            this.cmbMotherCivilStatus.Location = new System.Drawing.Point(541, 132);
            this.cmbMotherCivilStatus.Name = "cmbMotherCivilStatus";
            this.cmbMotherCivilStatus.Size = new System.Drawing.Size(213, 25);
            this.cmbMotherCivilStatus.TabIndex = 63;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(50, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 17);
            this.label18.TabIndex = 48;
            this.label18.Text = "Address:";
            // 
            // txtMotherAddress
            // 
            this.txtMotherAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMotherAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMotherAddress.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotherAddress.Location = new System.Drawing.Point(47, 204);
            this.txtMotherAddress.Multiline = true;
            this.txtMotherAddress.Name = "txtMotherAddress";
            this.txtMotherAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotherAddress.Size = new System.Drawing.Size(707, 52);
            this.txtMotherAddress.TabIndex = 47;
            // 
            // txtMotherRFIDNo
            // 
            this.txtMotherRFIDNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMotherRFIDNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMotherRFIDNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotherRFIDNo.Location = new System.Drawing.Point(296, 132);
            this.txtMotherRFIDNo.Name = "txtMotherRFIDNo";
            this.txtMotherRFIDNo.Size = new System.Drawing.Size(213, 25);
            this.txtMotherRFIDNo.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(299, 111);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 17);
            this.label19.TabIndex = 45;
            this.label19.Text = "RFID No.:";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(50, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 17);
            this.label20.TabIndex = 44;
            this.label20.Text = "Contact No.:";
            // 
            // txtMotherContactNo
            // 
            this.txtMotherContactNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMotherContactNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherContactNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotherContactNo.Location = new System.Drawing.Point(47, 132);
            this.txtMotherContactNo.Mask = "63900-000-0000";
            this.txtMotherContactNo.Name = "txtMotherContactNo";
            this.txtMotherContactNo.Size = new System.Drawing.Size(213, 25);
            this.txtMotherContactNo.TabIndex = 43;
            // 
            // txtMotherMiddleName
            // 
            this.txtMotherMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMotherMiddleName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMotherMiddleName.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotherMiddleName.Location = new System.Drawing.Point(541, 69);
            this.txtMotherMiddleName.Name = "txtMotherMiddleName";
            this.txtMotherMiddleName.Size = new System.Drawing.Size(213, 25);
            this.txtMotherMiddleName.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(544, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 17);
            this.label21.TabIndex = 41;
            this.label21.Text = "Middle Name:";
            // 
            // txtMotherFirstName
            // 
            this.txtMotherFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMotherFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMotherFirstName.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotherFirstName.Location = new System.Drawing.Point(296, 69);
            this.txtMotherFirstName.Name = "txtMotherFirstName";
            this.txtMotherFirstName.Size = new System.Drawing.Size(213, 25);
            this.txtMotherFirstName.TabIndex = 40;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(299, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 17);
            this.label22.TabIndex = 39;
            this.label22.Text = "First Name:";
            // 
            // txtMotherLastName
            // 
            this.txtMotherLastName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMotherLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMotherLastName.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotherLastName.Location = new System.Drawing.Point(47, 69);
            this.txtMotherLastName.Name = "txtMotherLastName";
            this.txtMotherLastName.Size = new System.Drawing.Size(213, 25);
            this.txtMotherLastName.TabIndex = 38;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DimGray;
            this.label23.Location = new System.Drawing.Point(50, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 17);
            this.label23.TabIndex = 37;
            this.label23.Text = "Last Name:";
            // 
            // Father
            // 
            this.Father.Controls.Add(this.groupBox3);
            this.Father.Controls.Add(this.label30);
            this.Father.Controls.Add(this.cmbFatherCivilStatus);
            this.Father.Controls.Add(this.label24);
            this.Father.Controls.Add(this.txtFatherAddress);
            this.Father.Controls.Add(this.txtFatherRFIDNo);
            this.Father.Controls.Add(this.label25);
            this.Father.Controls.Add(this.label26);
            this.Father.Controls.Add(this.txtFatherContactNo);
            this.Father.Controls.Add(this.txtFatherMiddleName);
            this.Father.Controls.Add(this.label27);
            this.Father.Controls.Add(this.txtFatherFirstName);
            this.Father.Controls.Add(this.label28);
            this.Father.Controls.Add(this.txtFatherLastName);
            this.Father.Controls.Add(this.label29);
            this.Father.Location = new System.Drawing.Point(4, 29);
            this.Father.Name = "Father";
            this.Father.Padding = new System.Windows.Forms.Padding(3);
            this.Father.Size = new System.Drawing.Size(803, 348);
            this.Father.TabIndex = 1;
            this.Father.Text = "Father Details";
            this.Father.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.cbContactDads);
            this.groupBox3.Controls.Add(this.cbRFIDDads);
            this.groupBox3.Controls.Add(this.cbActiveDads);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox3.Location = new System.Drawing.Point(47, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(707, 56);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other status";
            // 
            // cbContactDads
            // 
            this.cbContactDads.AutoSize = true;
            this.cbContactDads.Location = new System.Drawing.Point(132, 24);
            this.cbContactDads.Name = "cbContactDads";
            this.cbContactDads.Size = new System.Drawing.Size(96, 21);
            this.cbContactDads.TabIndex = 55;
            this.cbContactDads.Text = "Contact No.";
            this.cbContactDads.UseVisualStyleBackColor = true;
            // 
            // cbRFIDDads
            // 
            this.cbRFIDDads.AutoSize = true;
            this.cbRFIDDads.Location = new System.Drawing.Point(23, 24);
            this.cbRFIDDads.Name = "cbRFIDDads";
            this.cbRFIDDads.Size = new System.Drawing.Size(78, 21);
            this.cbRFIDDads.TabIndex = 54;
            this.cbRFIDDads.Text = "RFID No.";
            this.cbRFIDDads.UseVisualStyleBackColor = true;
            // 
            // cbActiveDads
            // 
            this.cbActiveDads.AutoSize = true;
            this.cbActiveDads.Location = new System.Drawing.Point(260, 24);
            this.cbActiveDads.Name = "cbActiveDads";
            this.cbActiveDads.Size = new System.Drawing.Size(61, 21);
            this.cbActiveDads.TabIndex = 53;
            this.cbActiveDads.Text = "Active";
            this.cbActiveDads.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.DimGray;
            this.label30.Location = new System.Drawing.Point(544, 112);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 17);
            this.label30.TabIndex = 62;
            this.label30.Text = "Status:";
            // 
            // cmbFatherCivilStatus
            // 
            this.cmbFatherCivilStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbFatherCivilStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFatherCivilStatus.ForeColor = System.Drawing.Color.DimGray;
            this.cmbFatherCivilStatus.FormattingEnabled = true;
            this.cmbFatherCivilStatus.Location = new System.Drawing.Point(541, 132);
            this.cmbFatherCivilStatus.Name = "cmbFatherCivilStatus";
            this.cmbFatherCivilStatus.Size = new System.Drawing.Size(213, 25);
            this.cmbFatherCivilStatus.TabIndex = 61;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DimGray;
            this.label24.Location = new System.Drawing.Point(50, 184);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 17);
            this.label24.TabIndex = 60;
            this.label24.Text = "Address:";
            // 
            // txtFatherAddress
            // 
            this.txtFatherAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFatherAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFatherAddress.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherAddress.Location = new System.Drawing.Point(47, 204);
            this.txtFatherAddress.Multiline = true;
            this.txtFatherAddress.Name = "txtFatherAddress";
            this.txtFatherAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFatherAddress.Size = new System.Drawing.Size(707, 52);
            this.txtFatherAddress.TabIndex = 59;
            // 
            // txtFatherRFIDNo
            // 
            this.txtFatherRFIDNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFatherRFIDNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFatherRFIDNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherRFIDNo.Location = new System.Drawing.Point(296, 132);
            this.txtFatherRFIDNo.Name = "txtFatherRFIDNo";
            this.txtFatherRFIDNo.Size = new System.Drawing.Size(213, 25);
            this.txtFatherRFIDNo.TabIndex = 58;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DimGray;
            this.label25.Location = new System.Drawing.Point(299, 111);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 17);
            this.label25.TabIndex = 57;
            this.label25.Text = "RFID No.:";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.DimGray;
            this.label26.Location = new System.Drawing.Point(50, 112);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 17);
            this.label26.TabIndex = 56;
            this.label26.Text = "Contact No.:";
            // 
            // txtFatherContactNo
            // 
            this.txtFatherContactNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFatherContactNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherContactNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherContactNo.Location = new System.Drawing.Point(47, 132);
            this.txtFatherContactNo.Mask = "63900-000-0000";
            this.txtFatherContactNo.Name = "txtFatherContactNo";
            this.txtFatherContactNo.Size = new System.Drawing.Size(213, 25);
            this.txtFatherContactNo.TabIndex = 55;
            // 
            // txtFatherMiddleName
            // 
            this.txtFatherMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFatherMiddleName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFatherMiddleName.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherMiddleName.Location = new System.Drawing.Point(541, 69);
            this.txtFatherMiddleName.Name = "txtFatherMiddleName";
            this.txtFatherMiddleName.Size = new System.Drawing.Size(213, 25);
            this.txtFatherMiddleName.TabIndex = 54;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.DimGray;
            this.label27.Location = new System.Drawing.Point(544, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(92, 17);
            this.label27.TabIndex = 53;
            this.label27.Text = "Middle Name:";
            // 
            // txtFatherFirstName
            // 
            this.txtFatherFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFatherFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFatherFirstName.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherFirstName.Location = new System.Drawing.Point(296, 69);
            this.txtFatherFirstName.Name = "txtFatherFirstName";
            this.txtFatherFirstName.Size = new System.Drawing.Size(213, 25);
            this.txtFatherFirstName.TabIndex = 52;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.DimGray;
            this.label28.Location = new System.Drawing.Point(299, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 17);
            this.label28.TabIndex = 51;
            this.label28.Text = "First Name:";
            // 
            // txtFatherLastName
            // 
            this.txtFatherLastName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFatherLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFatherLastName.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherLastName.Location = new System.Drawing.Point(47, 69);
            this.txtFatherLastName.Name = "txtFatherLastName";
            this.txtFatherLastName.Size = new System.Drawing.Size(213, 25);
            this.txtFatherLastName.TabIndex = 50;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.DimGray;
            this.label29.Location = new System.Drawing.Point(50, 48);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(75, 17);
            this.label29.TabIndex = 49;
            this.label29.Text = "Last Name:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(57, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Address:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(306, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "Birth Day:";
            // 
            // dtStudentBday
            // 
            this.dtStudentBday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtStudentBday.CustomFormat = "MMM. dd, yyyy";
            this.dtStudentBday.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStudentBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStudentBday.Location = new System.Drawing.Point(303, 299);
            this.dtStudentBday.Name = "dtStudentBday";
            this.dtStudentBday.Size = new System.Drawing.Size(213, 25);
            this.dtStudentBday.TabIndex = 7;
            // 
            // txtStudentAddress
            // 
            this.txtStudentAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStudentAddress.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentAddress.Location = new System.Drawing.Point(54, 426);
            this.txtStudentAddress.Multiline = true;
            this.txtStudentAddress.Name = "txtStudentAddress";
            this.txtStudentAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStudentAddress.Size = new System.Drawing.Size(707, 52);
            this.txtStudentAddress.TabIndex = 11;
            // 
            // txtStudentRFIDNo
            // 
            this.txtStudentRFIDNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentRFIDNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStudentRFIDNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentRFIDNo.Location = new System.Drawing.Point(54, 365);
            this.txtStudentRFIDNo.MaxLength = 12;
            this.txtStudentRFIDNo.Name = "txtStudentRFIDNo";
            this.txtStudentRFIDNo.Size = new System.Drawing.Size(213, 25);
            this.txtStudentRFIDNo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(57, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "RFID No.:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.rbStudentFemale);
            this.groupBox1.Controls.Add(this.rbStudentMale);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(548, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gender:";
            // 
            // rbStudentFemale
            // 
            this.rbStudentFemale.AutoSize = true;
            this.rbStudentFemale.Location = new System.Drawing.Point(119, 19);
            this.rbStudentFemale.Name = "rbStudentFemale";
            this.rbStudentFemale.Size = new System.Drawing.Size(67, 21);
            this.rbStudentFemale.TabIndex = 1;
            this.rbStudentFemale.TabStop = true;
            this.rbStudentFemale.Text = "Female";
            this.rbStudentFemale.UseVisualStyleBackColor = true;
            // 
            // rbStudentMale
            // 
            this.rbStudentMale.AutoSize = true;
            this.rbStudentMale.Location = new System.Drawing.Point(33, 19);
            this.rbStudentMale.Name = "rbStudentMale";
            this.rbStudentMale.Size = new System.Drawing.Size(55, 21);
            this.rbStudentMale.TabIndex = 0;
            this.rbStudentMale.TabStop = true;
            this.rbStudentMale.Text = "Male";
            this.rbStudentMale.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(57, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Contact No.:";
            // 
            // txtStudentContactNo
            // 
            this.txtStudentContactNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentContactNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentContactNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentContactNo.Location = new System.Drawing.Point(54, 299);
            this.txtStudentContactNo.Mask = "63900-000-0000";
            this.txtStudentContactNo.Name = "txtStudentContactNo";
            this.txtStudentContactNo.Size = new System.Drawing.Size(213, 25);
            this.txtStudentContactNo.TabIndex = 6;
            // 
            // txtStudentMiddleName
            // 
            this.txtStudentMiddleName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentMiddleName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStudentMiddleName.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentMiddleName.Location = new System.Drawing.Point(548, 236);
            this.txtStudentMiddleName.Name = "txtStudentMiddleName";
            this.txtStudentMiddleName.Size = new System.Drawing.Size(213, 25);
            this.txtStudentMiddleName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(551, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Middle Name:";
            // 
            // txtStudentFirstName
            // 
            this.txtStudentFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStudentFirstName.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentFirstName.Location = new System.Drawing.Point(303, 236);
            this.txtStudentFirstName.Name = "txtStudentFirstName";
            this.txtStudentFirstName.Size = new System.Drawing.Size(213, 25);
            this.txtStudentFirstName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(306, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(57, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Application:";
            // 
            // cmbApplication
            // 
            this.cmbApplication.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbApplication.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApplication.ForeColor = System.Drawing.Color.DimGray;
            this.cmbApplication.FormattingEnabled = true;
            this.cmbApplication.Location = new System.Drawing.Point(54, 112);
            this.cmbApplication.Name = "cmbApplication";
            this.cmbApplication.Size = new System.Drawing.Size(213, 25);
            this.cmbApplication.TabIndex = 0;
            // 
            // txtStudentLastName
            // 
            this.txtStudentLastName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStudentLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStudentLastName.ForeColor = System.Drawing.Color.DimGray;
            this.txtStudentLastName.Location = new System.Drawing.Point(54, 236);
            this.txtStudentLastName.Name = "txtStudentLastName";
            this.txtStudentLastName.Size = new System.Drawing.Size(213, 25);
            this.txtStudentLastName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(57, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Last Name:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DimGray;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1239, 36);
            this.label12.TabIndex = 40;
            this.label12.Text = "   Student Registration";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.DimGray;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(870, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 26);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1020, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 26);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.DimGray;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(1095, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 26);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1169, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 26);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlRecordList
            // 
            this.pnlRecordList.Controls.Add(this.dgStudentRecord);
            this.pnlRecordList.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRecordList.Location = new System.Drawing.Point(838, 36);
            this.pnlRecordList.Name = "pnlRecordList";
            this.pnlRecordList.Size = new System.Drawing.Size(401, 500);
            this.pnlRecordList.TabIndex = 47;
            // 
            // dgStudentRecord
            // 
            this.dgStudentRecord.AllowUserToAddRows = false;
            this.dgStudentRecord.AllowUserToDeleteRows = false;
            this.dgStudentRecord.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStudentRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgStudentRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStudentID,
            this.Column1,
            this.ColStudent,
            this.ColStudentName});
            this.dgStudentRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStudentRecord.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgStudentRecord.Location = new System.Drawing.Point(0, 0);
            this.dgStudentRecord.Name = "dgStudentRecord";
            this.dgStudentRecord.ReadOnly = true;
            this.dgStudentRecord.RowHeadersVisible = false;
            this.dgStudentRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStudentRecord.Size = new System.Drawing.Size(401, 500);
            this.dgStudentRecord.TabIndex = 0;
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
            // ColStudent
            // 
            this.ColStudent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColStudent.HeaderText = "Student ID";
            this.ColStudent.Name = "ColStudent";
            this.ColStudent.ReadOnly = true;
            this.ColStudent.Width = 120;
            // 
            // ColStudentName
            // 
            this.ColStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentName.HeaderText = "Name";
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.DimGray;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(945, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 26);
            this.btnEdit.TabIndex = 48;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // AutoScanTimer
            // 
            this.AutoScanTimer.Interval = 1000;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(509, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(256, 25);
            this.txtSearch.TabIndex = 51;
            this.toolTip1.SetToolTip(this.txtSearch, "\t\t\r\n");
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.DimGray;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(772, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 26);
            this.btnSearch.TabIndex = 52;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DimGray;
            this.label32.Location = new System.Drawing.Point(856, 3);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(2, 31);
            this.label32.TabIndex = 51;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.White;
            this.toolTip1.ForeColor = System.Drawing.Color.Red;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1239, 536);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pnlStudentRegistration);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlRecordList);
            this.Controls.Add(this.label12);
            this.Name = "frmStudent";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmStudent_Load);
            this.pnlStudentRegistration.ResumeLayout(false);
            this.pnlStudentRegistration.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.tcMotherFather.ResumeLayout(false);
            this.Mother.ResumeLayout(false);
            this.Mother.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Father.ResumeLayout(false);
            this.Father.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlRecordList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlStudentRegistration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtStudentBday;
        private System.Windows.Forms.TextBox txtStudentAddress;
        private System.Windows.Forms.TextBox txtStudentRFIDNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbStudentFemale;
        private System.Windows.Forms.RadioButton rbStudentMale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtStudentContactNo;
        private System.Windows.Forms.TextBox txtStudentMiddleName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStudentFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbApplication;
        private System.Windows.Forms.TextBox txtStudentLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcMotherFather;
        private System.Windows.Forms.TabPage Mother;
        private System.Windows.Forms.TabPage Father;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbStudentCourse;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMotherAddress;
        private System.Windows.Forms.TextBox txtMotherRFIDNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox txtMotherContactNo;
        private System.Windows.Forms.TextBox txtMotherMiddleName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtMotherFirstName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtMotherLastName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFatherAddress;
        private System.Windows.Forms.TextBox txtFatherRFIDNo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.MaskedTextBox txtFatherContactNo;
        private System.Windows.Forms.TextBox txtFatherMiddleName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtFatherFirstName;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtFatherLastName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbMotherCivilStatus;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbFatherCivilStatus;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlRecordList;
        private System.Windows.Forms.DataGridView dgStudentRecord;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbContactNoStd;
        private System.Windows.Forms.CheckBox cbRFIDstd;
        private System.Windows.Forms.CheckBox cbEnrolled;
        private System.Windows.Forms.CheckBox cbGraduated;
        private System.Windows.Forms.CheckBox cbCompleted;
        private System.Windows.Forms.CheckBox cbActiveStd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbContactDads;
        private System.Windows.Forms.CheckBox cbRFIDDads;
        private System.Windows.Forms.CheckBox cbActiveDads;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbContactMoms;
        private System.Windows.Forms.CheckBox cbRFIDMoms;
        private System.Windows.Forms.CheckBox cbActiveMoms;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.IO.Ports.SerialPort ComSerial;
        private System.Windows.Forms.Timer AutoScanTimer;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}