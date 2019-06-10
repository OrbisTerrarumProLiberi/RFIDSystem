using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AttSysRFID.Views.Main;
using AttSysRFID.Views.Device;
using AttSysRFID.ViewModel;
using AttSysRFID.Views.Student;
using AttSysRFID.Views.Notification;
using AttSysRFID.Views.Attendance;
namespace AttSysRFID
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemConnection.GetStringConnection();
            SystemSetup.ImagePath = SystemProperties.ReadButtonImage();
            //MessageBox.Show(SystemProperties.Database);
            UserInfo.ButtonFontStyle = "Segoe UI";
            //using (GetAPI api = new GetAPI())
            //{
            //        api.GetSendingDetails
            //}

            UserDetail.ONNotification();
            GetAPI.GetSendingDetails();
            Application.Run(new frmMain());
            //Application.Run(new frmAttendanceLogs());

        }
    }
}
