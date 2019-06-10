using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
using System.Security.Cryptography;
using System.Windows.Forms;
using AttSysRFID.ViewModel;
namespace AttSysRFID.ViewModel
{
    public class UserDetail:IDisposable
    {
        public static DateTime CurrDate()
        {
            
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.ExecuteQuery<DateTime>("SELECT GETDATE()").FirstOrDefault();
            }
        }
        public static void ONNotification()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                var ONNotify=dc.T_OnNotifications.FirstOrDefault().OnMessage.Value;
                OnMessage.SendingNotification = ONNotify;
            }
        }
        public void SaveLog(bool TimeIN)
        {
            T_SystemUserLog value = new T_SystemUserLog();
            T_SystemUserLog valueupdate = new T_SystemUserLog();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                if (TimeIN)
                {
                    value.UserID = UserInfo.UserID;
                    value.UserPassword = UserInfo.Password;
                    value.TimeIN = UserInfo.TimeIn;
                    dc.T_SystemUserLogs.InsertOnSubmit(value);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(UserInfo.UserID))
                    {
                        valueupdate = dc.T_SystemUserLogs.Where(x => x.TimeIN == UserInfo.TimeIn && x.UserID == UserInfo.UserID).FirstOrDefault();
                        if (valueupdate != null)
                            valueupdate.TimeOUT = CurrDate();
                    }
                }
                dc.SubmitChanges();
            }
        }
        public bool Login(T_SystemUser Users,ref string msg)
        {
            T_SystemUser _users = new T_SystemUser();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                _users = dc.T_SystemUsers.Where(x => x.Active == true && x.EncryptedPassword == Users.EncryptedPassword && x.Username == Users.Username && x.Active==true).FirstOrDefault();
                if (_users != null)
                {
                    
                    UserInfo.UserID = _users.UserID;
                    UserInfo.UserName = _users.Username;
                    UserInfo.Password = _users.Password;
                    UserInfo.EncryptedPassword = _users.EncryptedPassword;
                    UserInfo.PositionID = _users.PositionID;
                    //UserInfo.UserTheme=_users.us
                    UserInfo.FirstName = _users.FirstName;
                    UserInfo.LastName = _users.LastName;
                    UserInfo.CompleteName = string.Format("{0}, {1}",_users.LastName,_users.FirstName);
                    UserInfo.DisplayName = _users.DisplayName;
                    UserInfo.TimeIn =CurrDate();
                    var accessRight = GetAccessRight().Where(x => x.Active == true && x.PositionID == _users.PositionID).FirstOrDefault();
                    SystemSetup.SystemName = "Attendance Monitoring System with RFID and Message Notification";
                    UserInfo.JobTitle = accessRight.JobTitle;
                    SystemProperties.AccessRight.Application = accessRight.Application.Value;
                    SystemProperties.AccessRight.Student = accessRight.Student.Value;
                    SystemProperties.AccessRight.Instructor = accessRight.Instructor.Value;
                    SystemProperties.AccessRight.Position = accessRight.Position.Value;
                    SystemProperties.AccessRight.User = accessRight.Users.Value;
                    SystemProperties.AccessRight.YearLevel = accessRight.YearLevel.Value;
                    SystemProperties.AccessRight.Course = accessRight.Course.Value;
                    SystemProperties.AccessRight.Subject = accessRight.Course.Value;
                    SystemProperties.AccessRight.Room = accessRight.Room.Value;
                    SystemProperties.AccessRight.Time = accessRight.Time.Value;
                    SystemProperties.AccessRight.Display = accessRight.Display.Value;
                    SystemProperties.AccessRight.Report = accessRight.Report.Value;
                    SystemProperties.AccessRight.CivilStatus = accessRight.CivilStatus.Value;
                    SystemProperties.AccessRight.DeviceConfiguration = accessRight.DeviceConfiguration.Value;
                    SystemProperties.AccessRight.RoomType = accessRight.RoomType.Value;
                    SystemProperties.AccessRight.Building = accessRight.Building.Value;
                    SystemProperties.AccessRight.ViewRoom = accessRight.ViewRoom.Value;
                    SystemProperties.AccessRight.ViewCourse = accessRight.ViewCourse.Value;
                    SystemProperties.AccessRight.ViewInstructor = accessRight.ViewInstructor.Value;
                    SystemProperties.AccessRight.NotifyStudent = accessRight.NotifyStudent.Value ;
                    SystemProperties.AccessRight.MaintenanceMessage = accessRight.MaintenanceMessage.Value;
                    SystemProperties.AccessRight.SMSSettings = accessRight.SMSSettings.Value;
                    SystemProperties.AccessRight.Semester = accessRight.Semester.Value;
                    SystemProperties.AccessRight.YearClass = accessRight.YearClass.Value;
                    SaveLog(true);
                    msg =string.Format("Welcome for {0} "+Environment.NewLine+"{1}"+Environment.NewLine+"{2}",SystemSetup.SystemName, UserInfo.CompleteName,UserInfo.JobTitle);
                    return true;
                }
                else
                {
                    msg = string.Format("Your input is invalid {0}", SystemSetup.SystemName);
                    return false;
                }
            }
        }
        public List<T_AccessRight> GetAccessRight()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_AccessRights.ToList();
            }
        }
        public static string encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data).Replace("==","");
            }
        }
        public void Dispose()
        {
            
        } 
    }
 
    public class SystemSetup
    {
        public static string ImagePath { get; set; }
        public static string SystemName { get; set; }   
     
    }
    public class UserInfo
    {

        public static string DisplayName { get; set; }
        public static string UserID { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string EncryptedPassword { get; set; }
        public static string PositionID { get; set; }
        public static string JobTitle { get; set; }
        public static string UserTheme { get; set; }
        public static DateTime TimeIn { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string MiddleName { get; set; }
        public static string CompleteName { get; set; }
        public static string LabelForeColor { get; set; }
        public static string LabelFontStyle { get; set; }
        public static string TextBoxForeColor { get; set; }
        public static string TextBoxFontStyle { get; set; }
        public static string ButtonForeColor { get; set; }
        public static string ButtonBackColor { get; set; }
        public static string ButtonFontStyle { get; set; }
        //public static string ButtonFontStyle { get; set; }
    }
  
    public enum Imagename
    {
        Add,_add,Edit,_edit,Delete,_delete,Save,_save,Cancel,_cancel,Search
    }
}
