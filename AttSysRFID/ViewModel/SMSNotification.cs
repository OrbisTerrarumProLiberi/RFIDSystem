using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
namespace AttSysRFID.ViewModel
{
    public class SMSNotification:IDisposable
    {
        public List<T_ScanUserLog> GetUserTime()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_ScanUserLogs.ToList();
            }
        }
        public void Save(T_ScanUserLog value,bool TimeIN)
        {
            T_ScanUserLog valueupdate = new T_ScanUserLog();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                
                T_RegisteredStudentSemester values = new T_RegisteredStudentSemester();
                values = dc.T_RegisteredStudentSemesters.Where(x => x.StudentID == value.StudentID && x.Day.Replace(" ","").Replace("  ","").Replace("   ","").Replace("    ","") == value.Day && x.TimeStart.Hour == UserDetail.CurrDate().Hour && x.Semester == SystemProperties.SemesterActive.Semester && x.YearClass == SystemProperties.SemesterActive.YearSemester).FirstOrDefault();
                    
                if (TimeIN)
                {
                   values.AlreadyIN = true;
                   dc.T_ScanUserLogs.InsertOnSubmit(value);
                }
                else
                {
                    //Where(x => x.RoomCode == RoomCode && x.StudentID == StudID && x.TImeEnd == null && x.Day.ToLower() == Days().ToLower()).FirstOrDefault();
                    //valueupdate = dc.T_ScanUserLogs.Where(x => x.StudentID == value.StudentID && x.TimeIN.Value.ToShortDateString() == UserDetail.CurrDate().ToShortDateString() && x.TimeOUT==null).FirstOrDefault();
                    valueupdate = dc.T_ScanUserLogs.Where(x => x.RoomCode ==value.RoomCode && x.StudentID ==value.StudentID && x.TimeOUT == null && x.Day.ToLower() == Days().ToLower()).FirstOrDefault();
                    valueupdate.TimeOUT = UserDetail.CurrDate();

                    values.AlreadyIN = false;
                }
                
                dc.SubmitChanges();
            }
        }
        string Days()
        {
            DayOfWeek days = UserDetail.CurrDate().DayOfWeek;
            return days.ToString();
        }
        public List<T_Message> GetSMS()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_Messages.ToList();
            }
        }
        public void Delete(T_Message value,ref string msg)
        {
            T_Message valuedelete = new T_Message();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                valuedelete = dc.T_Messages.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_Messages.DeleteOnSubmit(valuedelete);
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine +"Code: {1}"+Environment.NewLine+ "Message: {2}" + Environment.NewLine + "Active: {3}", SystemProperties.MessageNotification.Deleted,valuedelete.Code, valuedelete.MessageAlert, valuedelete.Active);
                dc.SubmitChanges();
            }
        }
        public bool CheckSMSCode(string Code)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_Messages.Where(x => x.Code == Code).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_Message value, ref string msg)
        {
            T_Message valueupdate = new T_Message();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_Messages.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Code: {1}" + Environment.NewLine + "Message: {2}" + Environment.NewLine + "Active: {3}", SystemProperties.MessageNotification.Saved, value.Code, value.MessageAlert, value.Active);
                
                    }
                    else
                    {
                        valueupdate = dc.T_Messages.Where(x => x.ID==value.ID).FirstOrDefault();
                        valueupdate.MessageAlert = value.MessageAlert;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Message: {1}" + Environment.NewLine + "Active: {2}", SystemProperties.MessageNotification.Updated,valueupdate.MessageAlert,valueupdate.Active);
                       
                    }
                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }
                dc.SubmitChanges();
            }

        }
        public bool Compare(T_Message value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_Messages.Where(x => x.Active == value.Active && x.Code == value.Code && x.MessageAlert == value.MessageAlert).FirstOrDefault() == null ? true : false;
            }
        }
        public bool Compare(T_RegisteredStudentSemester value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_RegisteredStudentSemesters.Where(x => x.Day == value.Day && x.RoomCode == value.RoomCode && x.SemEndDate == value.SemEndDate && x.Semester == value.Semester && x.SemStartDate == value.SemStartDate && x.StudentID == value.StudentID && x.SubjectCode == value.SubjectCode && x.TImeEnd == value.TImeEnd && x.TimeStart == value.TimeStart && x.YearClass == value.YearClass).FirstOrDefault() == null ? true : false;
            }
        }
        public List<T_RegisteredStudentSemester> GetRegisterStudent()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_RegisteredStudentSemesters.ToList();
            }
        }
        public void Save(T_RegisteredStudentSemester value,ref string msg)
        {
            T_RegisteredStudentSemester valueupdate = new T_RegisteredStudentSemester();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                if (Compare(value))
                {
                    value.AlreadyIN = false;
                    dc.T_RegisteredStudentSemesters.InsertOnSubmit(value);
                    msg =string.Format("{0} : {1},{2},{3} to {4}, {5}   ", SystemProperties.MessageNotification.Saved,value.StudentID,value.SubjectCode,value.TimeStart.ToString("HH:mm:ss tt"),value.TImeEnd.ToString("HH:mm:ss tt"),value.Day);
                }
                else
                {
                    valueupdate = dc.T_RegisteredStudentSemesters.Where(x=> x.StudentID==value.StudentID && x.RoomCode==value.RoomCode && x.Day==value.Day && x.TimeStart==value.TimeStart && x.TImeEnd==value.TImeEnd && x.Semester==value.Semester && x.SemStartDate==value.SemStartDate && x.SemEndDate==value.SemEndDate && x.YearClass==value.YearClass).FirstOrDefault();
                    valueupdate.Active= value.Active;
                    value.AlreadyIN = false;
                    msg = string.Format("{0} : {1},{2},{3} to {4}, {5}   ", SystemProperties.MessageNotification.Updated, valueupdate.StudentID, valueupdate.SubjectCode, valueupdate.TimeStart.ToString("HH:mm:ss tt"), valueupdate.TImeEnd.ToString("HH:mm:ss tt"), valueupdate.Day);
                
                }
                dc.SubmitChanges();
            }
        }
        public void Delete(long ID,ref string msg)
        {
            T_RegisteredStudentSemester valuedelete = new T_RegisteredStudentSemester();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                valuedelete = dc.T_RegisteredStudentSemesters.Where(x => x.ID == ID).FirstOrDefault();
                dc.T_RegisteredStudentSemesters.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0} : {1},{2},{3} to {4}, {5}   ", SystemProperties.MessageNotification.Deleted, valuedelete.StudentID, valuedelete.SubjectCode, valuedelete.TimeStart.ToString("HH:mm:ss tt"), valuedelete.TImeEnd.ToString("HH:mm:ss tt"), valuedelete.Day);
                
            }
        }
        
        
        public void Dispose()
        {
        }
        
    }
    public class OnMessage
    {
        public static bool SendingNotification { get; set; }
    }

}
