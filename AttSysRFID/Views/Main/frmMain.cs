using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttSysRFID.Views.Student;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
using AttSysRFID.Views.Maintenanceform;
using AttSysRFID.Views.Main;
using AttSysRFID.Views.Student;
using AttSysRFID.Views.Device;
using AttSysRFID.Views.Display;
using AttSysRFID.Views.Notification;
using AttSysRFID.Views.ViewRecord;
using AttSysRFID.Views.Attendance;
using System.Threading.Tasks;

namespace AttSysRFID.Views.Main
{
    public partial class frmMain : Form
    {
     
        public frmMain()
        {
            InitializeComponent();
            Sethandler();
            Setproperties();
        }
        void Setproperties()
        {
            GetAccessRight(false);
            pnlLogin.Show();
            mtLogout.Enabled = false;
            tsOffline.Text = "Offline";
            tsUser.Text = "";
            tsTimeIN.Text = "";
            tsPosition.Text = "";
            timer1.Enabled = true;
            timer1.Start();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        void Sethandler()
        {
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
            timer1.Tick += new EventHandler(timer1_Tick);
            mtStudent.Click += new EventHandler(mtStudent_Click);
            mtApplication.Click += new EventHandler(mtApplication_Click);
            mtLogout.Click += new EventHandler(mtLogout_Click);
            mtCivilStatus.Click += new EventHandler(mtCivilStatus_Click);
            mtYearLevel.Click += new EventHandler(mtYearLevel_Click);
            mtCourse.Click += new EventHandler(mtCourse_Click);
            mtSubject.Click += new EventHandler(mtSubject_Click);
            mtRoom.Click += new EventHandler(mtRoom_Click);
            mtRoomType.Click += new EventHandler(mtRoomType_Click);
            mtBuilding.Click += new EventHandler(mtBuilding_Click);
            mtDeviceConfiguration.Click += new EventHandler(mtDeviceConfiguration_Click);
            mtNotificationSettings.Click += new EventHandler(mtNotificationSettings_Click);
            mtInstructor.Click += new EventHandler(mtInstructor_Click);
            mtSMSStudent.Click += new EventHandler(mtSMS_Click);
            mtMessages.Click += new EventHandler(mtMessages_Click);
            mtTime.Click += new EventHandler(mtTime_Click);
            mtLogin.Click += new EventHandler(mtLogin_Click);
            mtDisplay.Click += new EventHandler(mtDisplay_Click);
            mtExit.Click += new EventHandler(mtExit_Click);
            mtUser.Click += new EventHandler(mtUser_Click);
            btnExit.Click += new EventHandler(btnExit_Click);
            mtPosition.Click += new EventHandler(mtPosition_Click);
            btnLogin.Click += new EventHandler(btnLogin_Click);
            txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
            txtPassword.KeyUp += new KeyEventHandler(txtPassword_KeyUp);

            mtViewRoom.Click += new EventHandler(mtViewRoom_Click);
            mtSemester.Click += new EventHandler(mtSemester_Click);
            mtYearClass.Click += new EventHandler(mtYearClass_Click);
            mtViewCourse.Click += new EventHandler(mtViewCourse_Click);
            mtViewAttendance.Click += new EventHandler(mtViewAttendance_Click);

        }

        void mtViewAttendance_Click(object sender, EventArgs e)
        {
            OpenForm(new frmAttendanceLogs(), true);
        }
        void mtViewCourse_Click(object sender, EventArgs e)
        {
            OpenForm(new frmCourseAndSubject(), true);
        }
        void mtYearClass_Click(object sender, EventArgs e)
        {
            OpenForm(new frmYearClass(), true);
        }
        void mtSemester_Click(object sender, EventArgs e)
        {
            OpenForm(new frmSemester(), true);
        }
        void mtViewRoom_Click(object sender, EventArgs e)
        {
            OpenForm(new frmRoomRecord(), true);
        }
        void mtInstructor_Click(object sender, EventArgs e)
        {
            OpenForm(new frmInstructorRegistration(), true);
        }
        void mtLogout_Click(object sender, EventArgs e)
        {
            using (UserDetail UD = new UserDetail())
            {
                UD.SaveLog(false);
                GetAccessRight(false);
                pnlLogin.Show();
                mtLogout.Enabled = false;
                mtLogin.Enabled = true;
                tsOffline.Text = "Offline";
                tsOffline.ForeColor = Color.Red;
                tsUser.Text = "";
                tsTimeIN.Text = "";
                tsPosition.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                timer1.Enabled = true;
                timer1.Start();
         
            }

        }
        void mtNotificationSettings_Click(object sender, EventArgs e)
        {
            OpenForm(new frmAPISite(), true);
        }
        void mtMessages_Click(object sender, EventArgs e)
        {
            OpenForm(new frmSMSSettings(), true);
        }
        void mtSMS_Click(object sender, EventArgs e)
        {
            OpenForm(new frmApplySMSForStudent(), true);
        }
        void mtDisplay_Click(object sender, EventArgs e)
        {
            frmDisplayGate frm = new frmDisplayGate();
            frm.Show();
        }
        void mtDeviceConfiguration_Click(object sender, EventArgs e)
        {
            OpenForm(new frmDeviceConfig(), true);
        }
        void mtBuilding_Click(object sender, EventArgs e)
        {
            OpenForm(new frmBuilding(), true);
        }
        void mtRoomType_Click(object sender, EventArgs e)
        {
            OpenForm(new frmTypeofRoom(), true);
        }
        void mtTime_Click(object sender, EventArgs e)
        {
            OpenForm(new frmTime(), true);
        }
        void mtRoom_Click(object sender, EventArgs e)
        {
            OpenForm(new frmRoom(), true);
    
        }
        void mtSubject_Click(object sender, EventArgs e)
        {
            OpenForm(new frmSubject(),true);
        }
        void mtCourse_Click(object sender, EventArgs e)
        {
            OpenForm(new frmCourse(), true);
        }
        void mtYearLevel_Click(object sender, EventArgs e)
        {
            OpenForm(new frmYearLevel(), true); 

        }
        void mtCivilStatus_Click(object sender, EventArgs e)
        {
            OpenForm(new frmCivilStatus(), true);
        }
        void mtApplication_Click(object sender, EventArgs e)
        {
            OpenForm(new frmApplication(), true);
        }
        void mtPosition_Click(object sender, EventArgs e)
        {
            OpenForm(new frmPositionAccessRight(), true);
        }
        void mtUser_Click(object sender, EventArgs e)
        {
            OpenForm(new frmUserRegistration(),true);
        }

        private string EncryptedPassword;
        private string ReturnMsg;
        void GetActiveSemester()
        {
            using (Maintenance maintain = new Maintenance())
            {
                var value=  maintain.GetActiveSemester().Where(x => x.Active == true).FirstOrDefault();
                if (value != null)
                {
                    SystemProperties.SemesterActive.YearSemester = value.YearSemester;
                    SystemProperties.SemesterActive.Start = value.DateStart.Value;
                    SystemProperties.SemesterActive.End = value.DateEnd.Value;
                    SystemProperties.SemesterActive.Semester = value.Semester;

                }
            }
        }

        public void Login()
        {
            T_SystemUser user = new T_SystemUser();
            using (UserDetail _userdetails = new UserDetail())
            {
                if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    user.Username = txtUsername.Text;
                    user.EncryptedPassword = EncryptedPassword;
                    if (_userdetails.Login(user, ref ReturnMsg))
                    {
                        pnlLogin.Hide();
                        SystemProperties.ShowMessage.MessageInformation(ReturnMsg, "Login");
                        GetAccessRight(true);
                        tsOffline.Text = "Online";
                        tsOffline.ForeColor = Color.Green;
                        tsUser.Text = !string.IsNullOrWhiteSpace(UserInfo.DisplayName)?UserInfo.DisplayName:UserInfo.CompleteName;
                        tsTimeIN.Text = UserInfo.TimeIn.ToString("MMM. dd, yyyy  |  HH:mm:ss tt");
                        tsPosition.Text = UserInfo.JobTitle;
                        mtLogin.Enabled = !(mtLogout.Enabled = true);
                        using (GetAPI getapi = new GetAPI())
                        {
                            getapi.CheckInternetConnection();
                        }
                        GetActiveSemester();
                        
                    }
                    else
                    {

                        foreach (Form frm in this.MdiChildren)
                        {
                            if (!frm.Focused)
                            {
                                frm.Close();
                            }

                        }
                        tsOffline.ForeColor = Color.Red;
                        tsOffline.Text = "Offline";
                        tsUser.Text = "";
                        tsTimeIN.Text = "";
                        tsPosition.Text = "";
                        pnlLogin.Show();
                        GetAccessRight(false);
                        mtLogin.Enabled = !(mtLogout.Enabled = false);
                        SystemProperties.ShowMessage.MessageError(ReturnMsg, "Login");
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(string.Format("Please check your input below " + Environment.NewLine  +Environment.NewLine + "Username" + Environment.NewLine + "Password"), SystemSetup.SystemName);
                }
            }
        }
        
        void GetAccessRight(bool enable)
        {
            if (enable)
            {
                mtStudent.Enabled = SystemProperties.AccessRight.Student;
                mtInstructor.Enabled = SystemProperties.AccessRight.Instructor;
                mtPosition.Enabled = SystemProperties.AccessRight.Position;
                mtUser.Enabled = SystemProperties.AccessRight.User;
                mtApplication.Enabled = SystemProperties.AccessRight.Application;
                mtYearLevel.Enabled = SystemProperties.AccessRight.YearLevel;
                mtCivilStatus.Enabled = SystemProperties.AccessRight.CivilStatus;
                mtCourse.Enabled = SystemProperties.AccessRight.Course;
                mtSubject.Enabled = SystemProperties.AccessRight.Subject;
                mtRoom.Enabled = SystemProperties.AccessRight.Room;
                mtTime.Enabled = SystemProperties.AccessRight.Time;
                mtDisplay.Enabled = SystemProperties.AccessRight.Display;
                mtReport.Enabled = SystemProperties.AccessRight.Report;
                mtDeviceConfiguration.Enabled = SystemProperties.AccessRight.DeviceConfiguration;
                mtRoomType.Enabled = SystemProperties.AccessRight.RoomType;
                mtBuilding.Enabled = SystemProperties.AccessRight.Building;
                mtViewRoom.Enabled = SystemProperties.AccessRight.ViewRoom;
                mtViewCourse.Enabled=SystemProperties.AccessRight.ViewCourse;
                mtViewAttendance.Enabled=SystemProperties.AccessRight.ViewInstructor;
                mtSMSStudent.Enabled=SystemProperties.AccessRight.NotifyStudent;
                mtMessages.Enabled=SystemProperties.AccessRight.MaintenanceMessage;
                mtNotificationSettings.Enabled=SystemProperties.AccessRight.SMSSettings;
                mtSemester.Enabled = SystemProperties.AccessRight.Semester;
                mtYearClass.Enabled = SystemProperties.AccessRight.YearClass;
                
               
            }
            else
            {
                mtStudent.Enabled = enable;
                mtInstructor.Enabled = enable;
                mtPosition.Enabled = enable;
                mtUser.Enabled = enable;
                mtApplication.Enabled = enable;
                mtYearLevel.Enabled = enable;
                mtCivilStatus.Enabled = enable;
                mtCourse.Enabled = enable;
                mtSubject.Enabled = enable;
                mtRoom.Enabled = enable;
                mtTime.Enabled = enable;
                mtDisplay.Enabled = enable;
                mtReport.Enabled = enable;
                mtDeviceConfiguration.Enabled = enable;
                mtRoomType.Enabled = enable;
                mtBuilding.Enabled = enable;

                mtViewRoom.Enabled = enable;
                mtViewCourse.Enabled = enable;
                mtViewAttendance.Enabled = enable;
                mtSMSStudent.Enabled = enable;
                mtMessages.Enabled = enable;
                mtNotificationSettings.Enabled = enable;

                mtSemester.Enabled = enable;
                mtYearClass.Enabled = enable;
            }
        }

        void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
                Login();
        }

        void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                EncryptedPassword = UserDetail.encrypt(txtPassword.Text);
        } 
        
        void mtLogin_Click(object sender, EventArgs e)
        {
            pnlLogin.Show();
        }   
        
        void mtExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        void Exit()
        {

            if (!string.IsNullOrWhiteSpace(UserInfo.UserID))
            {
                if (SystemProperties.ShowMessage.MessageQuestion("Do you want to logout your account and exit application?", "Login") == DialogResult.Yes)
                {
                    using (UserDetail UD = new UserDetail())
                    {
                        UD.SaveLog(false);
                        foreach (Form frm in this.MdiChildren)
                        {
                            if(!frm.Focused)
                            {
                                frm.Close();
                            }

                        }
                    }                   
                }
            }
            else
            {
                Application.Exit();
            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            pnlLogin.Hide();
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        void mtStudent_Click(object sender, EventArgs e)
        {
            OpenForm(new frmStudent(), true);
        }

        void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserInfo.UserID))
            {
                e.Cancel = !(SystemProperties.ShowMessage.MessageQuestion("Do you want to logout your account and exit application?", "Login") == DialogResult.Yes);
                if (!e.Cancel)
                {
                    using (UserDetail UD = new UserDetail())
                    {
                        UD.SaveLog(false);
                        foreach (Form frm in this.MdiChildren)
                        {
                            if (!frm.Focused)
                            {
                                frm.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        }

        void OpenForm(Form ToOpenForm, bool Maximixed)
        {

            bool _contain = this.MdiChildren.AsEnumerable().Where(x=> x.GetType()==ToOpenForm.GetType()).Any();
            if (!_contain)
            {
                ToOpenForm.MdiParent = this;
                ToOpenForm.WindowState = FormWindowState.Maximized;
                ToOpenForm.Show();
            }
            else
            {
                bool clfrm = true;
                var current = this.MdiChildren.AsEnumerable().Where(x => x.GetType() == ToOpenForm.GetType()).FirstOrDefault();
                if(clfrm)
                {
                    current.Close();
                    OpenForm(ToOpenForm, Maximixed);                
                }
            }

            
        }

        async void timer1_Tick(object sender, EventArgs e)
        {
            tsDateTime.Text = UserDetail.CurrDate().ToString("MMM. dd, yyyy |  HH:mm:ss tt");
            await Task.Run(() =>
            {
                string Internet = string.Format(@"{0}\WifiInternetAccess.png", SystemSetup.ImagePath).Replace("\\", @"\");
                string NoInternet = string.Format(@"{0}\WifiNoInternetAccess.png", SystemSetup.ImagePath).Replace("\\", @"\");

                using (GetAPI getapi = new GetAPI())
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            wifiPic.Image = getapi.CheckInternetConnection() ? Image.FromFile(Internet) : Image.FromFile(NoInternet);//"Internet access":"No internet access";
                            lblInternetStatus.Text = getapi.CheckInternetConnection() ? "Internet access" : "No internet access";
                            lblInternetStatus.ForeColor = getapi.CheckInternetConnection() ? Color.ForestGreen : Color.Red;
                        });
                    }
                  
                }
            });
        }
            
    }
}
