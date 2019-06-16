using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
namespace AttSysRFID.ViewModel
{
    public class Students : IDisposable
    {
        public List<T_StudentInformation> GetStudentInfo()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_StudentInformations.ToList();
            }
        }
        public bool Compare(T_StudentInformation value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_StudentInformations.Where(x => x.YearLevel==value.YearLevel &&  x.Active == value.Active && x.Address.ToLower() == value.Address.ToLower() && x.Application.ToLower() == value.Application.ToLower() && x.Bday == value.Bday && x.CompletedStatus == value.CompletedStatus && x.ContactNo == value.ContactNo && x.ContactNoStatus == value.ContactNoStatus && x.Course.ToLower() == value.Course.ToLower() && x.EnrolledStatus == value.EnrolledStatus && x.FatherID == value.FatherID && x.FirstName == value.FirstName && x.GraduateStatus == value.GraduateStatus && x.LastName == value.LastName && x.MiddleName == value.MiddleName && x.MotherID == value.MotherID && x.RFIDNo == value.RFIDNo && x.RFIDStatus == value.RFIDStatus && x.StudentID == value.StudentID).FirstOrDefault()==null?true:false;
            }
        }
        public void Save(T_StudentInformation value, ref string msg)
        {
            T_StudentInformation valueupdate = new T_StudentInformation();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString)) 
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_StudentInformations.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Student ID: {1}" + Environment.NewLine + "Last Name: {2}" + Environment.NewLine + "Firs Name: {3}"+ Environment.NewLine + "RFID No.: {4}", SystemProperties.MessageNotification.Saved, value.StudentID, value.LastName,value.FirstName,value.RFIDNo);       
                 
                    }
                    else
                    {
                        valueupdate = dc.T_StudentInformations.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.StudentID = value.StudentID;
                        valueupdate.MotherID = value.MotherID;
                        valueupdate.FatherID = value.FatherID;
                        valueupdate.Application = value.Application;
                        valueupdate.LastName = value.LastName;
                        valueupdate.FirstName = value.FirstName;
                        valueupdate.MiddleName = value.MiddleName;
                        valueupdate.ContactNo = value.ContactNo;
                        valueupdate.Bday = value.Bday;
                        valueupdate.Gender = value.Gender;
                        valueupdate.RFIDNo = value.RFIDNo.Replace("\r","");
                        valueupdate.Course = value.Course;
                        valueupdate.Address = value.Address;
                        valueupdate.CompletedStatus = value.CompletedStatus;
                        valueupdate.GraduateStatus = value.GraduateStatus;
                        valueupdate.EnrolledStatus = value.EnrolledStatus;
                        valueupdate.RFIDStatus = value.RFIDStatus;
                        valueupdate.ContactNoStatus = value.ContactNoStatus;
                        valueupdate.Active = value.Active;
                        valueupdate.YearLevel = value.YearLevel;
                        //valueupdate.DateRegistered = value.DateRegistered;
                        //valueupdate.DisplayName = value.DisplayName;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Student ID: {1}" + Environment.NewLine + "Last Name: {2}" + Environment.NewLine + "Firs Name: {3}" + Environment.NewLine + "RFID No.: {4}", SystemProperties.MessageNotification.Updated, valueupdate.StudentID, valueupdate.LastName, valueupdate.FirstName, valueupdate.RFIDNo);       
                 
                    }
                }
                else
                {
                    msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Student ID: {1}" + Environment.NewLine + "Last Name: {2}" + Environment.NewLine + "Firs Name: {3}" + Environment.NewLine + "RFID No.: {4}", SystemProperties.MessageNotification.Exist, value.StudentID, value.LastName, value.FirstName, value.RFIDNo);                        
                }


                dc.SubmitChanges();
            }

        }
        public void Delete(T_StudentInformation value, ref string msg)
        {
            T_StudentInformation valuedelete = new T_StudentInformation();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_StudentInformations.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_StudentInformations.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Student ID: {1}" + Environment.NewLine + "Last Name: {2}" + Environment.NewLine + "Firs Name: {3}" + Environment.NewLine + "RFID No.: {4}", SystemProperties.MessageNotification.Deleted, valuedelete.StudentID, valuedelete.LastName, valuedelete.FirstName, valuedelete.RFIDNo);                       
            }
        }
        public void Dispose()
        {
            
        }
    }

    public class Parents : IDisposable
    {
        public List<T_ParenstInfo> GetParentsInfo()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_ParenstInfos.ToList();
            }
        }
        public bool Compare(T_ParenstInfo value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_ParenstInfos.Where(x => x.DadAddress == value.DadAddress && x.DadCivilStatus==value.DadCivilStatus && x.DadContactNo==value.DadContactNo && x.DadFistName==value.DadFistName && x.DadLastName==value.DadLastName && x.DadMiddleName==value.DadMiddleName && x.DadRFIDNo==value.DadRFIDNo && x.FActive==value.FActive && x.FatherID==value.FatherID && x.FContactNo==value.FContactNo && x.FRFIDNo==value.FRFIDNo && x.MActive==value.MActive && x.MContactNo==value.MContactNo && x.MomAddress==value.MomAddress && x.MomCivilStatus==value.MomCivilStatus && x.MomContactNo==value.MomContactNo && x.MomFirstName==value.MomFirstName && x.MomLastName==value.MomLastName && x.MomMiddleName==value.MomMiddleName && x.MomRFIDNo==value.MomRFIDNo && x.MotherID==value.MotherID && x.MRFIDNo==value.MRFIDNo).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_ParenstInfo value)
        {
            T_ParenstInfo valueupdate = new T_ParenstInfo();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_ParenstInfos.InsertOnSubmit(value);
                    }
                    else
                    {
                        valueupdate = dc.T_ParenstInfos.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.MotherID = value.MotherID;
                        valueupdate.FatherID = value.FatherID;
                        valueupdate.MomLastName = value.MomLastName;
                        valueupdate.MomFirstName = value.MomFirstName;
                        valueupdate.MomMiddleName = value.MomMiddleName;
                        valueupdate.MomContactNo = value.MomContactNo;
                        valueupdate.MomRFIDNo = value.MomRFIDNo;
                        valueupdate.MomCivilStatus = value.MomCivilStatus;
                        valueupdate.MomAddress = value.MomAddress;
                        valueupdate.MRFIDNo = value.MRFIDNo;
                        valueupdate.MContactNo = value.MContactNo;
                        valueupdate.MActive = value.MActive;
                        valueupdate.DadLastName = value.DadLastName;
                        valueupdate.DadFistName = value.DadFistName;
                        valueupdate.DadMiddleName = value.DadMiddleName;
                        valueupdate.DadContactNo = value.DadContactNo;
                        valueupdate.DadRFIDNo = value.DadRFIDNo;
                        valueupdate.DadCivilStatus = value.DadCivilStatus;
                        valueupdate.DadAddress = value.DadAddress;
                        valueupdate.FRFIDNo = value.FRFIDNo;
                        valueupdate.FContactNo = value.FContactNo;
                        valueupdate.FActive = value.FActive;

                    }
                }


                dc.SubmitChanges();
            }
        }
        public void Delete(T_ParenstInfo value)
        {
            T_ParenstInfo valuedelete = new T_ParenstInfo();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_ParenstInfos.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_ParenstInfos.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
            }

        }
        public void Dispose()
        {
            
        }
    }
}
