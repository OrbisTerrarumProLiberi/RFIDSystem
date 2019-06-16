namespace AttSysRFID.Views.Main
{
    partial class frmMain
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this._Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsOffline = new System.Windows.Forms.ToolStripStatusLabel();
            this._Space = new System.Windows.Forms.ToolStripStatusLabel();
            this._User = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.@__Space = new System.Windows.Forms.ToolStripStatusLabel();
            this._Position = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this._______Space = new System.Windows.Forms.ToolStripStatusLabel();
            this._TimeIN = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTimeIN = new System.Windows.Forms.ToolStripStatusLabel();
            this.___Space = new System.Windows.Forms.ToolStripStatusLabel();
            this._DateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.______Space = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mtLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mtExit = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.mtInstructor = new System.Windows.Forms.ToolStripMenuItem();
            this.maintainanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.mtUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mtApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.mtYearLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mtCivilStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mtCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.mtSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.mtRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mtTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mtRoomType = new System.Windows.Forms.ToolStripMenuItem();
            this.mtBuilding = new System.Windows.Forms.ToolStripMenuItem();
            this.mtMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.mtSemester = new System.Windows.Forms.ToolStripMenuItem();
            this.viewingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtViewRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mtViewCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.mtViewAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.mtReport = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtSMSStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.manualSendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtDeviceConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mtTimeScan = new System.Windows.Forms.ToolStripMenuItem();
            this.mtNotificationSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mtYearClass = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInternetStatus = new System.Windows.Forms.Label();
            this.wifiPic = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wifiPic)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Status,
            this.tsOffline,
            this._Space,
            this._User,
            this.tsUser,
            this.@__Space,
            this._Position,
            this.tsPosition,
            this._______Space,
            this._TimeIN,
            this.tsTimeIN,
            this.___Space,
            this._DateTime,
            this.tsDateTime,
            this.______Space});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(1266, 20);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // _Status
            // 
            this._Status.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Status.Name = "_Status";
            this._Status.Size = new System.Drawing.Size(69, 15);
            this._Status.Text = "     Status:";
            // 
            // tsOffline
            // 
            this.tsOffline.ForeColor = System.Drawing.Color.Red;
            this.tsOffline.Name = "tsOffline";
            this.tsOffline.Size = new System.Drawing.Size(43, 15);
            this.tsOffline.Text = "Offline";
            // 
            // _Space
            // 
            this._Space.Name = "_Space";
            this._Space.Size = new System.Drawing.Size(88, 15);
            this._Space.Text = "                           ";
            // 
            // _User
            // 
            this._User.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._User.Name = "_User";
            this._User.Size = new System.Drawing.Size(55, 15);
            this._User.Text = "User:    ";
            // 
            // tsUser
            // 
            this.tsUser.Name = "tsUser";
            this.tsUser.Size = new System.Drawing.Size(87, 15);
            this.tsUser.Text = "Dela Cruz, Juan";
            // 
            // __Space
            // 
            this.@__Space.Name = "__Space";
            this.@__Space.Size = new System.Drawing.Size(133, 15);
            this.@__Space.Text = "                                          ";
            // 
            // _Position
            // 
            this._Position.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this._Position.Name = "_Position";
            this._Position.Size = new System.Drawing.Size(60, 15);
            this._Position.Text = "Position:";
            // 
            // tsPosition
            // 
            this.tsPosition.Name = "tsPosition";
            this.tsPosition.Size = new System.Drawing.Size(0, 15);
            // 
            // _______Space
            // 
            this._______Space.Name = "_______Space";
            this._______Space.Size = new System.Drawing.Size(82, 15);
            this._______Space.Text = "                         ";
            // 
            // _TimeIN
            // 
            this._TimeIN.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TimeIN.Name = "_TimeIN";
            this._TimeIN.Size = new System.Drawing.Size(54, 15);
            this._TimeIN.Text = "TimeIN:";
            // 
            // tsTimeIN
            // 
            this.tsTimeIN.Name = "tsTimeIN";
            this.tsTimeIN.Size = new System.Drawing.Size(132, 15);
            this.tsTimeIN.Text = "Jan. 07, 2019 |  19:50 PM";
            // 
            // ___Space
            // 
            this.___Space.Name = "___Space";
            this.___Space.Size = new System.Drawing.Size(103, 15);
            this.___Space.Text = "                                ";
            // 
            // _DateTime
            // 
            this._DateTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._DateTime.Name = "_DateTime";
            this._DateTime.Size = new System.Drawing.Size(81, 15);
            this._DateTime.Text = "Date / Time:";
            // 
            // tsDateTime
            // 
            this.tsDateTime.Name = "tsDateTime";
            this.tsDateTime.Size = new System.Drawing.Size(111, 15);
            this.tsDateTime.Text = "Jan. 07, 2019  | 8:pm";
            // 
            // ______Space
            // 
            this.______Space.Name = "______Space";
            this.______Space.Size = new System.Drawing.Size(94, 15);
            this.______Space.Text = "                             ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.maintainanceToolStripMenuItem,
            this.viewingToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.notificationToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1266, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtLogin,
            this.mtLogout,
            this.mtExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mtLogin
            // 
            this.mtLogin.BackColor = System.Drawing.Color.White;
            this.mtLogin.ForeColor = System.Drawing.Color.Black;
            this.mtLogin.Name = "mtLogin";
            this.mtLogin.Size = new System.Drawing.Size(117, 22);
            this.mtLogin.Text = "Log In";
            // 
            // mtLogout
            // 
            this.mtLogout.BackColor = System.Drawing.Color.White;
            this.mtLogout.ForeColor = System.Drawing.Color.Black;
            this.mtLogout.Name = "mtLogout";
            this.mtLogout.Size = new System.Drawing.Size(117, 22);
            this.mtLogout.Text = "Log Out";
            // 
            // mtExit
            // 
            this.mtExit.BackColor = System.Drawing.Color.White;
            this.mtExit.ForeColor = System.Drawing.Color.Black;
            this.mtExit.Name = "mtExit";
            this.mtExit.Size = new System.Drawing.Size(117, 22);
            this.mtExit.Text = "Exit";
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtStudent,
            this.mtInstructor});
            this.transactionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.transactionToolStripMenuItem.Text = "Registration";
            // 
            // mtStudent
            // 
            this.mtStudent.BackColor = System.Drawing.Color.White;
            this.mtStudent.ForeColor = System.Drawing.Color.Black;
            this.mtStudent.Name = "mtStudent";
            this.mtStudent.Size = new System.Drawing.Size(121, 22);
            this.mtStudent.Text = "Student";
            // 
            // mtInstructor
            // 
            this.mtInstructor.BackColor = System.Drawing.Color.White;
            this.mtInstructor.ForeColor = System.Drawing.Color.Black;
            this.mtInstructor.Name = "mtInstructor";
            this.mtInstructor.Size = new System.Drawing.Size(121, 22);
            this.mtInstructor.Text = "Instuctor";
            // 
            // maintainanceToolStripMenuItem
            // 
            this.maintainanceToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.maintainanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtPosition,
            this.mtUser,
            this.mtApplication,
            this.mtYearLevel,
            this.mtCivilStatus,
            this.mtCourse,
            this.mtSubject,
            this.mtRoom,
            this.mtTime,
            this.mtRoomType,
            this.mtBuilding,
            this.mtMessages,
            this.mtSemester});
            this.maintainanceToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.maintainanceToolStripMenuItem.Name = "maintainanceToolStripMenuItem";
            this.maintainanceToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.maintainanceToolStripMenuItem.Text = "Maintainance";
            // 
            // mtPosition
            // 
            this.mtPosition.BackColor = System.Drawing.Color.White;
            this.mtPosition.ForeColor = System.Drawing.Color.Black;
            this.mtPosition.Name = "mtPosition";
            this.mtPosition.Size = new System.Drawing.Size(135, 22);
            this.mtPosition.Text = "Position";
            // 
            // mtUser
            // 
            this.mtUser.BackColor = System.Drawing.Color.White;
            this.mtUser.ForeColor = System.Drawing.Color.Black;
            this.mtUser.Name = "mtUser";
            this.mtUser.Size = new System.Drawing.Size(135, 22);
            this.mtUser.Text = "User";
            // 
            // mtApplication
            // 
            this.mtApplication.Name = "mtApplication";
            this.mtApplication.Size = new System.Drawing.Size(135, 22);
            this.mtApplication.Text = "Application";
            // 
            // mtYearLevel
            // 
            this.mtYearLevel.Name = "mtYearLevel";
            this.mtYearLevel.Size = new System.Drawing.Size(135, 22);
            this.mtYearLevel.Text = "Year Level";
            // 
            // mtCivilStatus
            // 
            this.mtCivilStatus.Name = "mtCivilStatus";
            this.mtCivilStatus.Size = new System.Drawing.Size(135, 22);
            this.mtCivilStatus.Text = "Civil Status";
            // 
            // mtCourse
            // 
            this.mtCourse.Name = "mtCourse";
            this.mtCourse.Size = new System.Drawing.Size(135, 22);
            this.mtCourse.Text = "Course";
            // 
            // mtSubject
            // 
            this.mtSubject.Name = "mtSubject";
            this.mtSubject.Size = new System.Drawing.Size(135, 22);
            this.mtSubject.Text = "Subject";
            // 
            // mtRoom
            // 
            this.mtRoom.Name = "mtRoom";
            this.mtRoom.Size = new System.Drawing.Size(135, 22);
            this.mtRoom.Text = "Room";
            // 
            // mtTime
            // 
            this.mtTime.Name = "mtTime";
            this.mtTime.Size = new System.Drawing.Size(135, 22);
            this.mtTime.Text = "Time";
            // 
            // mtRoomType
            // 
            this.mtRoomType.Name = "mtRoomType";
            this.mtRoomType.Size = new System.Drawing.Size(135, 22);
            this.mtRoomType.Text = "Room Type";
            // 
            // mtBuilding
            // 
            this.mtBuilding.Name = "mtBuilding";
            this.mtBuilding.Size = new System.Drawing.Size(135, 22);
            this.mtBuilding.Text = "Building";
            // 
            // mtMessages
            // 
            this.mtMessages.Name = "mtMessages";
            this.mtMessages.Size = new System.Drawing.Size(135, 22);
            this.mtMessages.Text = "Message";
            // 
            // mtSemester
            // 
            this.mtSemester.Name = "mtSemester";
            this.mtSemester.Size = new System.Drawing.Size(135, 22);
            this.mtSemester.Text = "Semester";
            // 
            // viewingToolStripMenuItem
            // 
            this.viewingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtViewRoom,
            this.mtViewCourse,
            this.mtViewAttendance});
            this.viewingToolStripMenuItem.Name = "viewingToolStripMenuItem";
            this.viewingToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.viewingToolStripMenuItem.Text = "Viewing Record";
            // 
            // mtViewRoom
            // 
            this.mtViewRoom.Name = "mtViewRoom";
            this.mtViewRoom.Size = new System.Drawing.Size(135, 22);
            this.mtViewRoom.Text = "Room";
            // 
            // mtViewCourse
            // 
            this.mtViewCourse.Name = "mtViewCourse";
            this.mtViewCourse.Size = new System.Drawing.Size(135, 22);
            this.mtViewCourse.Text = "Course";
            this.mtViewCourse.Visible = false;
            // 
            // mtViewAttendance
            // 
            this.mtViewAttendance.Name = "mtViewAttendance";
            this.mtViewAttendance.Size = new System.Drawing.Size(135, 22);
            this.mtViewAttendance.Text = "Attendance";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtDisplay,
            this.mtReport});
            this.windowsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // mtDisplay
            // 
            this.mtDisplay.BackColor = System.Drawing.Color.White;
            this.mtDisplay.ForeColor = System.Drawing.Color.Black;
            this.mtDisplay.Name = "mtDisplay";
            this.mtDisplay.Size = new System.Drawing.Size(180, 22);
            this.mtDisplay.Text = "Display";
            // 
            // mtReport
            // 
            this.mtReport.BackColor = System.Drawing.Color.White;
            this.mtReport.ForeColor = System.Drawing.Color.Black;
            this.mtReport.Name = "mtReport";
            this.mtReport.Size = new System.Drawing.Size(180, 22);
            this.mtReport.Text = "Report";
            this.mtReport.Visible = false;
            // 
            // notificationToolStripMenuItem
            // 
            this.notificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtSMSStudent,
            this.manualSendingToolStripMenuItem});
            this.notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
            this.notificationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.notificationToolStripMenuItem.Text = "Notification";
            // 
            // mtSMSStudent
            // 
            this.mtSMSStudent.Name = "mtSMSStudent";
            this.mtSMSStudent.Size = new System.Drawing.Size(160, 22);
            this.mtSMSStudent.Text = "Student";
            // 
            // manualSendingToolStripMenuItem
            // 
            this.manualSendingToolStripMenuItem.Name = "manualSendingToolStripMenuItem";
            this.manualSendingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.manualSendingToolStripMenuItem.Text = "Manual Sending";
            this.manualSendingToolStripMenuItem.Visible = false;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtDeviceConfiguration,
            this.mtTimeScan,
            this.mtNotificationSettings,
            this.mtYearClass});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mtDeviceConfiguration
            // 
            this.mtDeviceConfiguration.BackColor = System.Drawing.Color.White;
            this.mtDeviceConfiguration.ForeColor = System.Drawing.Color.Black;
            this.mtDeviceConfiguration.Name = "mtDeviceConfiguration";
            this.mtDeviceConfiguration.Size = new System.Drawing.Size(186, 22);
            this.mtDeviceConfiguration.Text = "Device Configuration";
            // 
            // mtTimeScan
            // 
            this.mtTimeScan.Name = "mtTimeScan";
            this.mtTimeScan.Size = new System.Drawing.Size(186, 22);
            this.mtTimeScan.Text = "Time Scanning";
            this.mtTimeScan.Visible = false;
            // 
            // mtNotificationSettings
            // 
            this.mtNotificationSettings.Name = "mtNotificationSettings";
            this.mtNotificationSettings.Size = new System.Drawing.Size(186, 22);
            this.mtNotificationSettings.Text = "SMS Settings";
            // 
            // mtYearClass
            // 
            this.mtYearClass.Name = "mtYearClass";
            this.mtYearClass.Size = new System.Drawing.Size(186, 22);
            this.mtYearClass.Text = "Year Class";
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLogin.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(511, 176);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(302, 192);
            this.pnlLogin.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Salmon;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(173, 145);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SkyBlue;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(29, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.Location = new System.Drawing.Point(29, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(247, 25);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(32, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtUsername.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsername.Location = new System.Drawing.Point(29, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(247, 25);
            this.txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(32, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "    Login your account..";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInternetStatus);
            this.panel1.Controls.Add(this.wifiPic);
            this.panel1.Controls.Add(this.statusStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 493);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1266, 20);
            this.panel1.TabIndex = 8;
            // 
            // lblInternetStatus
            // 
            this.lblInternetStatus.AutoSize = true;
            this.lblInternetStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInternetStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternetStatus.Location = new System.Drawing.Point(1098, 0);
            this.lblInternetStatus.Name = "lblInternetStatus";
            this.lblInternetStatus.Size = new System.Drawing.Size(137, 17);
            this.lblInternetStatus.TabIndex = 1;
            this.lblInternetStatus.Text = "Internet Connection :";
            this.lblInternetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // wifiPic
            // 
            this.wifiPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.wifiPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.wifiPic.Location = new System.Drawing.Point(1235, 0);
            this.wifiPic.Name = "wifiPic";
            this.wifiPic.Size = new System.Drawing.Size(31, 20);
            this.wifiPic.TabIndex = 0;
            this.wifiPic.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1266, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wifiPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _Status;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripStatusLabel tsOffline;
        private System.Windows.Forms.ToolStripStatusLabel _Space;
        private System.Windows.Forms.ToolStripStatusLabel _User;
        private System.Windows.Forms.ToolStripStatusLabel tsUser;
        private System.Windows.Forms.ToolStripStatusLabel __Space;
        private System.Windows.Forms.ToolStripStatusLabel _TimeIN;
        private System.Windows.Forms.ToolStripStatusLabel tsTimeIN;
        private System.Windows.Forms.ToolStripStatusLabel ___Space;
        private System.Windows.Forms.ToolStripStatusLabel _DateTime;
        private System.Windows.Forms.ToolStripStatusLabel tsDateTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtLogin;
        private System.Windows.Forms.ToolStripMenuItem mtLogout;
        private System.Windows.Forms.ToolStripMenuItem mtExit;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtStudent;
        private System.Windows.Forms.ToolStripMenuItem mtInstructor;
        private System.Windows.Forms.ToolStripMenuItem maintainanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtPosition;
        private System.Windows.Forms.ToolStripMenuItem mtUser;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtDisplay;
        private System.Windows.Forms.ToolStripMenuItem mtReport;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtDeviceConfiguration;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem mtYearLevel;
        private System.Windows.Forms.ToolStripMenuItem mtCivilStatus;
        private System.Windows.Forms.ToolStripMenuItem mtCourse;
        private System.Windows.Forms.ToolStripMenuItem mtSubject;
        private System.Windows.Forms.ToolStripMenuItem mtRoom;
        private System.Windows.Forms.ToolStripMenuItem mtTime;
        private System.Windows.Forms.ToolStripMenuItem mtApplication;
        private System.Windows.Forms.ToolStripStatusLabel _Position;
        private System.Windows.Forms.ToolStripStatusLabel tsPosition;
        private System.Windows.Forms.ToolStripStatusLabel _______Space;
        private System.Windows.Forms.ToolStripStatusLabel ______Space;
        private System.Windows.Forms.ToolStripMenuItem mtRoomType;
        private System.Windows.Forms.ToolStripMenuItem mtBuilding;
        private System.Windows.Forms.ToolStripMenuItem notificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtSMSStudent;
        private System.Windows.Forms.ToolStripMenuItem mtTimeScan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInternetStatus;
        private System.Windows.Forms.PictureBox wifiPic;
        private System.Windows.Forms.ToolStripMenuItem mtMessages;
        private System.Windows.Forms.ToolStripMenuItem manualSendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtViewRoom;
        private System.Windows.Forms.ToolStripMenuItem mtViewCourse;
        private System.Windows.Forms.ToolStripMenuItem mtViewAttendance;
        private System.Windows.Forms.ToolStripMenuItem mtNotificationSettings;
        private System.Windows.Forms.ToolStripMenuItem mtSemester;
        private System.Windows.Forms.ToolStripMenuItem mtYearClass;
    }
}



