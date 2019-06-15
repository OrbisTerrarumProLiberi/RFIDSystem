using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
namespace AttSysRFID.ViewModel
{
    public class Instructor:IDisposable
    {

        public List<T_InstructorInformation> GetInstructor()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_InstructorInformations.ToList();
            }
        }

        public void Save(T_InstructorInformation value,ref string msg)
        {
            //T_InstructorInformation valueupdate = new T_InstructorInformation();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_InstructorInformations.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Employee ID: {1}" + Environment.NewLine + "Name: {2}" + Environment.NewLine + "Contact No: {3}", SystemProperties.MessageNotification.Saved, value.EmployeeID, value.LastName + ", " + value.FirstName, value.ContactNo);           
              
                    }
                    else
                    {
                       // valueupdate = dc.T_InstructorInformations.Where(x => x.ID == value.ID).FirstOrDefault();
                        var valueupdate = dc.T_InstructorInformations.FirstOrDefault(x => x.ID == value.ID);
                        valueupdate.EmployeeID = value.EmployeeID;
                        valueupdate.LastName = value.LastName;
                        valueupdate.FirstName = value.FirstName;
                        valueupdate.MiddleName = value.MiddleName;
                        valueupdate.ContactNo = value.ContactNo;
                        valueupdate.BDay = value.BDay;
                        valueupdate.Gender = value.Gender;
                        valueupdate.Address = value.Address;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Employee ID: {1}" + Environment.NewLine + "Name: {2}" + Environment.NewLine + "Contact No: {3}", SystemProperties.MessageNotification.Updated, valueupdate.EmployeeID,valueupdate.LastName+", "+valueupdate.FirstName, valueupdate.ContactNo);           
              
                    }

                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }
                dc.SubmitChanges();
            }
        }

        public void Delete(T_InstructorInformation value,ref string msg)
        {
            //T_InstructorInformation valuedelete = new T_InstructorInformation();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                //valuedelete = dc.T_InstructorInformations.Where(x => x.ID == value.ID).FirstOrDefault();
                var valuedelete = dc.T_InstructorInformations.FirstOrDefault(x => x.ID == value.ID);
                dc.T_InstructorInformations.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Employee ID: {1}" + Environment.NewLine + "Name: {2}" + Environment.NewLine + "Contact No: {3}", SystemProperties.MessageNotification.Deleted, valuedelete.EmployeeID, valuedelete.LastName + ", " + valuedelete.FirstName, valuedelete.ContactNo);           
              
            }
        }

        public bool Compare(T_InstructorInformation value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                return dc.T_InstructorInformations
                    .Where(x => x.Address == value.Address &&
                        x.BDay == value.BDay && 
                        x.ContactNo == value.ContactNo && 
                        x.EmployeeID == value.EmployeeID && 
                        x.FirstName == value.FirstName && 
                        x.Gender == value.Gender && 
                        x.LastName == value.LastName)
                     .Any();
            
            }
        }

        public void Dispose()
        {
            
        }
    }
}
