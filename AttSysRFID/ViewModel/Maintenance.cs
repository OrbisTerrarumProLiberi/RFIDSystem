using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
namespace AttSysRFID.ViewModel
{
    public class Maintenance:IDisposable
    {
        public List<T_CourseAndSubject> GetCourseToSubject()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_CourseAndSubjects.ToList();
            }
        }
        public bool Compare(T_CourseAndSubject value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_CourseAndSubjects.Where(x => x.CourseCode == value.CourseCode && x.CourseDescription == value.CourseDescription && x.Description == value.Description && x.SubjectCode == value.SubjectCode && x.Unit == value.Unit).FirstOrDefault() == null ? true : false;
            }
        }
        public void Delete(T_CourseAndSubject value)
        {
            //T_CourseAndSubject valuedelete = new T_CourseAndSubject();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                var valuedelete = dc.T_CourseAndSubjects.Where(x => x.CourseCode == value.CourseCode && x.CourseDescription==value.CourseDescription).ToList();
                dc.T_CourseAndSubjects.DeleteAllOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }

        public void Save(T_CourseAndSubject value) 
        {
            T_CourseAndSubject valueupdate = new T_CourseAndSubject();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                dc.T_CourseAndSubjects.InsertOnSubmit(value);
                dc.SubmitChanges();
            }
        }


        public List<T_ActiveSemester> GetActiveSemester()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_ActiveSemesters.ToList();
            }
        }
        public void Save(T_ActiveSemester value, ref string msg)
        {
            T_ActiveSemester valueupdate = new T_ActiveSemester();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    dc.T_ActiveSemesters.InsertOnSubmit(value);
                    msg = string.Format("{0}"+Environment.NewLine+Environment.NewLine+"Semester:  {1}"+Environment.NewLine+"Year class:  {2}",SystemProperties.MessageNotification.Saved,value.Semester,value.YearSemester);
                }
                else
                {
                    valueupdate = dc.T_ActiveSemesters.Where(x => x.ID == value.ID).FirstOrDefault();
                    valueupdate.DateEnd = value.DateEnd;
                    valueupdate.DateStart = value.DateStart;
                    valueupdate.Semester = value.Semester;
                    valueupdate.YearSemester = value.YearSemester;
                    msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Semester:  {1}" + Environment.NewLine + "Year class:  {2}", SystemProperties.MessageNotification.Saved, valueupdate.Semester, valueupdate.YearSemester);
                
                }
                
                
                dc.SubmitChanges();                
            }
        }
        public bool Compare(T_ActiveSemester value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_ActiveSemesters.Where(x => x.Active == value.Active && x.DateEnd == value.DateEnd && x.DateStart == value.DateStart && x.Semester == value.Semester && x.YearSemester == value.YearSemester).FirstOrDefault() == null ? true : false;
            }
        }
        public void Delete(T_ActiveSemester value,ref string msg)
        {
            T_ActiveSemester valuedelete = new T_ActiveSemester();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString)) 
            {
                valuedelete = dc.T_ActiveSemesters.Where(x => x.ID == valuedelete.ID).FirstOrDefault();
                dc.T_ActiveSemesters.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Semester:  {1}" + Environment.NewLine + "Year class:  {2}", SystemProperties.MessageNotification.Deleted, valuedelete.Semester, valuedelete.YearSemester);
                
            }
        }
        
        
        public List<T_Semester> GetSemester()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Semesters.ToList();
            }
        }
        public void Save(T_Semester value, ref string msg)
        {
            T_Semester valueupdate = new T_Semester();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_Semesters.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Semester:  {1}", SystemProperties.MessageNotification.Saved, value.Semester);
                    }
                    else
                    {
                        valueupdate = dc.T_Semesters.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Semester = value.Semester;
                        msg = string.Format("{0}"+Environment.NewLine+Environment.NewLine+"Semester:  {1}",SystemProperties.MessageNotification.Updated,valueupdate.Semester);
                    }
                }
                else
                {
                    msg=SystemProperties.MessageNotification.Exist;
                }
                dc.SubmitChanges();
            }
        }
        public void Delete(T_Semester value, ref string msg)
        {
            T_Semester valuedelete = new T_Semester();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Semesters.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_Semesters.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Semester:  {1}", SystemProperties.MessageNotification.Deleted, valuedelete.Semester);
            }

        }
        public bool Compare(T_Semester value)
        {            
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Semesters.Where(x => x.Semester.ToLower() == value.Semester.ToLower()).FirstOrDefault() == null ? true : false;
            }
        }
        
        
        public List<T_Day> GetDay()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Days.ToList();
            }
        }

        public List<T_BranchBuilding> GetBuildingCode()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_BranchBuildings.ToList();
            }
        }
        public void Save(T_BranchBuilding value,ref string msg)
        {
            T_BranchBuilding valueupdate = new T_BranchBuilding();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_BranchBuildings.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Branch: {1}" + Environment.NewLine + "Code: {2}" + Environment.NewLine + "Name: {3}", SystemProperties.MessageNotification.Saved, value.Branch, value.BuildingCode, value.BuildingName);
                    }
                    else
                    {
                        valueupdate = dc.T_BranchBuildings.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.BuildingCode = value.BuildingCode;
                        valueupdate.Branch = value.Branch;
                        valueupdate.BuildingName = value.BuildingName;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Branch: {1}" + Environment.NewLine + "Code: {2}"+Environment.NewLine+"Name: {3}", SystemProperties.MessageNotification.Updated, valueupdate.Branch, valueupdate.BuildingCode,valueupdate.BuildingName);          
                  
                    }
                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }

                dc.SubmitChanges();
            }
        }
        public bool Compare(T_BranchBuilding value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_BranchBuildings.Where(x => x.Active == value.Active && x.Branch.ToLower() == value.Branch.ToLower() && x.BuildingCode.ToLower() == value.BuildingCode.ToLower() && x.BuildingName.ToLower() == value.BuildingName.ToLower()).FirstOrDefault() == null ? true : false; 
            }
        }
        public void Delete(T_BranchBuilding value,ref string msg)
        {
            T_BranchBuilding valuedelete = new T_BranchBuilding();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_BranchBuildings.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_BranchBuildings.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Branch: {1}" + Environment.NewLine + "Code: {2}" + Environment.NewLine + "Name: {3}", SystemProperties.MessageNotification.Updated, valuedelete.Branch, valuedelete.BuildingCode, valuedelete.BuildingName);
            }

        }


        //Registration of type of room

        public List<T_Type> GetRoomType()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Types.ToList();
            }
        }
        public bool Compare(T_Type value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Types.Where(x => x.Active == value.Active && x.Code.ToLower() == value.Code.ToLower() && x.Type.ToLower() == value.Type.ToLower()).FirstOrDefault() == null ? true : false;
            }
        }
        public void Delete(T_Type value,ref string msg)
        {
            T_Type valuedelete = new T_Type();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Types.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_Types.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}"+Environment.NewLine+Environment.NewLine+"Code: {1}"+Environment.NewLine+"Type of room: {2}",SystemProperties.MessageNotification.Deleted, valuedelete.Code, valuedelete.Type);
            }
        }
        public void Save(T_Type value, ref string msg)
        {
            T_Type valueupdate = new T_Type();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_Types.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Code: {1}" + Environment.NewLine + "Type of room: {2}", SystemProperties.MessageNotification.Saved, value.Code, value.Type);       
                    }
                    else
                    {
                        valueupdate = dc.T_Types.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Code = value.Code;
                        valueupdate.Type = value.Type;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Code: {1}" + Environment.NewLine + "Type of room: {2}", SystemProperties.MessageNotification.Updated, valueupdate.Code, valueupdate.Type);          
                    }
                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }
                dc.SubmitChanges();
            }
        }
        //get room and time
        public List<T_RoomTime> GetRoomTime()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_RoomTimes.ToList();
            }
        }
        public void Delete(T_RoomTime value)
        {
            List<T_RoomTime> valuedelete = new List<T_RoomTime>();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_RoomTimes.Where(x => x.RoomCode == value.RoomCode).ToList();
                dc.T_RoomTimes.DeleteAllOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }
        public bool Compare(T_RoomTime value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_RoomTimes.Where(x => x.RoomCode == value.RoomCode && x.TimeCode == value.TimeCode).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_RoomTime value)
        {
            T_RoomTime valueupdate = new T_RoomTime();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    dc.T_RoomTimes.InsertOnSubmit(value);
                }
                else
                {
                    valueupdate = dc.T_RoomTimes.Where(x => x.ID == value.ID).FirstOrDefault();
                    valueupdate.RoomCode = value.RoomCode;
                    valueupdate.TimeCode = value.TimeCode;
                    valueupdate.Status = value.Status;
                }
                dc.SubmitChanges();
            }
            
        }
        //get Type of Room
        public List<T_Type> GetType()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Types.ToList();
            }
        }

        //registration for room

        public List<T_Room> GetRoom()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Rooms.ToList();
            }
        }
        public bool Compare(T_Room value)
        {
            using(AttMonSysRFIDDataContext dc=new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {

                return dc.T_Rooms.Where(x => x.Active == value.Active && x.RoomCode.ToLower() == value.RoomCode.ToLower() && x.RoomType == value.RoomType && x.Description==value.Description && x.BuildingCode == value.BuildingCode && x.Capacity == value.Capacity).FirstOrDefault() == null ? true : false;
            } 
        }
        public void Save(T_Room value, ref string msg)
        {
            T_Room valueupdate = new T_Room();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_Rooms.InsertOnSubmit(value);
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Saved, value.RoomCode, value.Description, value.Capacity);
        
                    }
                    else
                    {
                        valueupdate = dc.T_Rooms.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.RoomCode = value.RoomCode;
                        valueupdate.RoomType = value.RoomType;
                        valueupdate.Description = value.Description;
                        valueupdate.Active = value.Active;
                        valueupdate.Capacity = value.Capacity;
                        valueupdate.TimeID = value.TimeID;
                        valueupdate.BuildingCode = value.BuildingCode;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Updated, valueupdate.RoomCode, valueupdate.Description, valueupdate.Capacity);
        
                    }
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Exist, value.RoomCode, value.RoomType, value.BuildingCode);
               

                }
                dc.SubmitChanges();
            }
        }
        public void Delete(T_Room value, ref string msg)
        {
            T_Room valuedelete = new T_Room();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Rooms.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_Rooms.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Deleted, valuedelete.RoomCode, valuedelete.Description, valuedelete.Capacity);
        
            }
        }
        //time registation
        public List<T_Time> GetTime()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Times.ToList();
            }
        }
        public bool Compare(T_Time value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Times.Where(x => x.TimeCode.ToLower()==value.TimeCode.ToLower() && x.Active == value.Active && x.TimeStart == value.TimeStart && x.TimeEnd == value.TimeEnd).FirstOrDefault() == null ? true : false;
            }
        }
        public void Delete(T_Time value,ref string msg)
        {
            T_Time valuedelete = new T_Time();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Times.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_Times.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Deleted,valuedelete.TimeCode, valuedelete.TimeStart, valuedelete.TimeEnd);
              
            }
        }
        public void Save(T_Time value, ref string msg)
        {
            T_Time valueupdate = new T_Time();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_Times.InsertOnSubmit(value);
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Saved, value.TimeCode, value.TimeStart, value.TimeEnd);

                    }
                    else
                    {
                        valueupdate = dc.T_Times.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.TimeStart = value.TimeStart;
                        valueupdate.TimeEnd = value.TimeEnd;
                        valueupdate.Active = value.Active;
                        valueupdate.TimeCode = value.TimeCode;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Updated, value.TimeCode, valueupdate.TimeStart, valueupdate.TimeEnd);

                    }

                    dc.SubmitChanges();
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Exist,value.TimeCode, value.TimeStart, value.TimeEnd);
                }
            }

        }

        //subject registration
        public List<T_Subject> GetSubject()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Subjects.ToList();
            }
        }
        public bool Compare(T_Subject value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Subjects.Where(x => x.Code.ToLower() == value.Code.ToLower() && x.Description.ToLower() == value.Description.ToLower() && x.Unit == value.Unit && x.Active == value.Active).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_Subject value, ref string msg)
        {
            T_Subject valueupdate = new T_Subject();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_Subjects.InsertOnSubmit(value);
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Saved, value.Unit, value.Code, value.Description);
               
                    }
                    else
                    {
                        valueupdate = dc.T_Subjects.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Code = value.Code;
                        valueupdate.Unit = value.Unit;
                        valueupdate.Description = value.Description;

                        valueupdate.Active = value.Active;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Updated, valueupdate.Unit, valueupdate.Code, valueupdate.Description);
               
                    }

                    dc.SubmitChanges();
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Exist,value.Unit,value.Code, value.Description);
                }
            }
        }
        public void Delete(T_Subject value, ref string msg)
        {
            T_Subject valuedelete = new T_Subject();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Subjects.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_Subjects.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}" + Environment.NewLine + " {3}", SystemProperties.MessageNotification.Deleted, valuedelete.Unit, valuedelete.Code, valuedelete.Description);
               
            }
        }
         
        //Application Like New Enrollment or Transferee
        public List<T_Application> GetApplication()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Applications.ToList();
            }
        }
        public bool Compare(T_Application value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Applications.Where(x => x.Active==value.Active &&   x.Application.ToLower() == value.Application.ToLower()).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_Application value,ref string msg)
        {
            T_Application valueupdate = new T_Application();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //check data is already exist
                if (Compare(value))
                {
                    //is Save New
                    if (value.ID == 0)
                    {
                        dc.T_Applications.InsertOnSubmit(value);
                        msg = string.Format("{0} "+Environment.NewLine+Environment.NewLine+"{1}"+Environment.NewLine+" {2}",SystemProperties.MessageNotification.Saved, value.Application, value.Active);
                    }
                    // Is Update    
                    else
                    {
                        valueupdate = dc.T_Applications.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Application = value.Application;
                        valueupdate.Description = value.Description;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Updated, valueupdate.Application, valueupdate.Active);
                    
                    }
                    dc.SubmitChanges();
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Exist, value.Application, value.Active);
                    
                }
               
            }
        }
        public void Delete(T_Application value,ref string msg)
        {
            T_Application valuedelete = new T_Application();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Applications.Where(x => x.ID == value.ID).FirstOrDefault();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Deleted, valuedelete.Application, valuedelete.Active);
                dc.T_Applications.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }
  
        //Civil Status Like Single Married
        public List<T_CivilStatus> GetCivilStatus()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_CivilStatus.ToList();
            }
        }
        public bool Compare(T_CivilStatus value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_CivilStatus.Where(x => x.Active == value.Active && x.Status.ToLower() == value.Status.ToLower()).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_CivilStatus value, ref string msg)
        {
            T_CivilStatus valueupdate = new T_CivilStatus();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //check data is already exist
                if (Compare(value))
                {
                    //is Save New
                    if (value.ID == 0)
                    {
                        dc.T_CivilStatus.InsertOnSubmit(value);
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Saved, value.Status, value.Active);
                    }
                    // Is Update    
                    else
                    {
                        valueupdate = dc.T_CivilStatus.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Status = value.Status;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Updated, valueupdate.Status, valueupdate.Active);

                    }
                    dc.SubmitChanges();
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Exist, value.Status, value.Active);

                }

            }
        }
        public void Delete(T_CivilStatus value, ref string msg)
        {
            T_CivilStatus valuedelete = new T_CivilStatus();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_CivilStatus.Where(x => x.ID == value.ID).FirstOrDefault();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Deleted, valuedelete.Status, valuedelete.Active);
                dc.T_CivilStatus.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }

        //Course Like Bachelor of Science in Informatation Technology
        public List<T_Course> GetCourse()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Courses.ToList();
            }
        }
        public bool Compare(T_Course value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Courses.Where(x => x.Active == value.Active && x.Course.ToLower() == value.Course.ToLower() && x.CourseCode.ToLower() == value.CourseCode.ToLower() && x.YearMinimum == value.YearMinimum && x.YearMaximum == value.YearMaximum && x.YearLevelFromTo==value.YearLevelFromTo).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_Course value, ref string msg)
        {
            T_Course valueupdate = new T_Course();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //check data is already exist
                if (Compare(value))
                {
                    //is Save New
                    if (value.ID == 0)
                    {
                        dc.T_Courses.InsertOnSubmit(value);
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine + "{5}", SystemProperties.MessageNotification.Saved, value.CourseCode, value.CourseCode, value.YearMinimum, value.YearMaximum, value.Active);
                    }
                    // Is Update    
                    else
                    {
                        valueupdate = dc.T_Courses.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Course = value.Course;
                        valueupdate.CourseCode = value.CourseCode;
                        valueupdate.Description = value.Description;
                        valueupdate.YearMinimum = value.YearMinimum;
                        valueupdate.YearMaximum = value.YearMaximum;
                        valueupdate.YearLevelFromTo = value.YearLevelFromTo;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine + "{5}", SystemProperties.MessageNotification.Updated, valueupdate.CourseCode, valueupdate.CourseCode, valueupdate.YearMinimum, valueupdate.YearMaximum, valueupdate.Active);

                    }
                    dc.SubmitChanges();
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine + "{5}", SystemProperties.MessageNotification.Exist, value.CourseCode, value.CourseCode, value.YearMinimum, value.YearMaximum, value.Active);

                }

            }
        }
        public void Delete(T_Course value, ref string msg)
        {
            T_Course valuedelete = new T_Course();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_Courses.Where(x => x.ID == value.ID).FirstOrDefault();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" + Environment.NewLine + "{5}", SystemProperties.MessageNotification.Deleted, value.CourseCode, value.CourseCode, value.YearMinimum, value.YearMaximum, value.Active);
                dc.T_Courses.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }

        //Year Level Like First Year or Second Year
        public List<T_YearLevel> GetYearLevel()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_YearLevels.ToList();
            }
        }
        public bool Compare(T_YearLevel value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_YearLevels.Where(x => x.Count==value.Count && x.Active == value.Active && x.YearLevel.ToLower() == value.YearLevel.ToLower()).FirstOrDefault() == null ? true : false;
            }
        }
        public void Save(T_YearLevel value, ref string msg)
        {
            T_YearLevel valueupdate = new T_YearLevel();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //check data is already exist
                if (Compare(value))
                {
                    //is Save New
                    if (value.ID == 0)
                    {
                        dc.T_YearLevels.InsertOnSubmit(value);
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Saved, value.YearLevel, value.Active);
                    }
                    // Is Update    
                    else
                    {
                        valueupdate = dc.T_YearLevels.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.YearLevel = value.YearLevel;
                        valueupdate.Active = value.Active;
                        valueupdate.Count = value.Count;
                        msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Updated, valueupdate.YearLevel, valueupdate.Active);

                    }
                    dc.SubmitChanges();
                }
                else
                {
                    msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Exist, value.YearLevel, value.Active);

                }

            }
        }
        public void Delete(T_YearLevel value, ref string msg)
        {
            T_YearLevel valuedelete = new T_YearLevel();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_YearLevels.Where(x => x.ID == value.ID).FirstOrDefault();
                msg = string.Format("{0} " + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine + " {2}", SystemProperties.MessageNotification.Deleted, valuedelete.YearLevel, valuedelete.Active);
                dc.T_YearLevels.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }
        
        //System user Like Admin1 or Admin2 
        public List<T_SystemUser> GetSystemUser()
        {
            using(AttMonSysRFIDDataContext dc=new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_SystemUsers.ToList();
            }
        }
        public void Save(T_SystemUser value,ref string msg)
        {
            T_SystemUser valueupdate = new T_SystemUser();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_SystemUsers.InsertOnSubmit(value);
                        msg =string.Format("{0}"+Environment.NewLine+Environment.NewLine+"USER ID: [{1}]"+Environment.NewLine+"POSITION ID;  [{2}]"+Environment.NewLine+"USERNAME:  [{3}]"+Environment.NewLine+"NAME:  [{4}, {5}]",SystemProperties.MessageNotification.Saved,value.UserID,value.PositionID,value.Username,value.LastName,value.FirstName);
                    }
                    else
                    {
                        valueupdate = dc.T_SystemUsers.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.Password = value.Password;
                        valueupdate.EncryptedPassword = value.EncryptedPassword;
                        valueupdate.DisplayName = value.DisplayName;
                        valueupdate.LastName = value.LastName;
                        valueupdate.FirstName = value.FirstName;
                        valueupdate.PathImage = value.PathImage;
                        valueupdate.Bday = value.Bday;
                        valueupdate.ContactNo = value.ContactNo;
                        valueupdate.PositionID = value.PositionID;
                        valueupdate.Theme = value.Theme;
                        valueupdate.Active = value.Active;
                        valueupdate.Username = value.Username;
                        valueupdate.RFIDStatus = value.RFIDStatus;
                        valueupdate.RFIDNo = value.RFIDNo;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "USER ID: [{1}]" + Environment.NewLine + "POSITION ID;  [{2}]" + Environment.NewLine + "USERNAME:  [{3}]" + Environment.NewLine + "NAME:  [{4}, {5}]", SystemProperties.MessageNotification.Updated, valueupdate.UserID, valueupdate.PositionID, valueupdate.Username, valueupdate.LastName, valueupdate.FirstName);
                    }
                    dc.SubmitChanges();
                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }
            }
        }
        public void Delete(T_SystemUser value,ref string msg)
        {
            T_SystemUser valuedelete = new T_SystemUser();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_SystemUsers.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_SystemUsers.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "USER ID: [{1}]" + Environment.NewLine + "POSITION ID;  [{2}]" + Environment.NewLine + "USERNAME:  [{3}]" + Environment.NewLine + "NAME:  [{4}, {5}]", SystemProperties.MessageNotification.Deleted, valuedelete.UserID, valuedelete.PositionID, valuedelete.Username, valuedelete.LastName, valuedelete.FirstName);
                    
            }
        }
        public bool Compare(T_SystemUser value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_SystemUsers.Where(x => x.UserID == value.UserID && x.Username == value.Username && x.Password == value.Password && x.EncryptedPassword == value.EncryptedPassword && x.FirstName == value.FirstName && x.LastName == value.LastName && x.ContactNo == value.ContactNo && x.RFIDNo == value.RFIDNo && x.RFIDStatus == value.RFIDStatus && x.Active == value.Active && x.PositionID==value.PositionID ).FirstOrDefault() == null ? true : false;
            }
        }
        
        //Access for the system Like Admin1 or Admin2         
        public List<T_AccessRight> GetAccessRight()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_AccessRights.ToList();
            }
        }
        public void Save(T_AccessRight value,ref string msg)
        {
            T_AccessRight valueupdate = new T_AccessRight();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_AccessRights.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "POSITION ID: [{1}]" + Environment.NewLine + "JOB TITLE;  [{2}]" + Environment.NewLine + "DESCRIPTION:  [{3}]", SystemProperties.MessageNotification.Saved, value.PositionID, value.JobTitle,value.Description);               
                    }
                    else
                    {
                        valueupdate = dc.T_AccessRights.Where(x => x.ID == value.ID).FirstOrDefault();
                        valueupdate.JobTitle = value.JobTitle;
                        valueupdate.Description = value.Description;
                        valueupdate.Student = value.Student;
                        valueupdate.Instructor = value.Instructor;
                        valueupdate.Position = value.Position;
                        valueupdate.Users = value.Users;
                        valueupdate.YearLevel = value.YearLevel;
                        valueupdate.CivilStatus = value.CivilStatus;
                        valueupdate.Application = value.Application;
                        valueupdate.Course = value.Course;
                        valueupdate.Subject = value.Subject;
                        valueupdate.Room = value.Room;
                        valueupdate.Time = value.Time;
                        valueupdate.Display = value.Display;
                        valueupdate.Report = value.Report;
                        valueupdate.DeviceConfiguration = value.DeviceConfiguration;
                        valueupdate.Active = value.Active;
                        valueupdate.Building = value.Building;
                        valueupdate.RoomType = value.RoomType;

                        valueupdate.ViewRoom = value.ViewRoom;
                        valueupdate.ViewCourse = value.ViewCourse;
                        valueupdate.ViewInstructor = value.ViewInstructor;
                        valueupdate.MaintenanceMessage = value.MaintenanceMessage;
                        valueupdate.NotifyStudent = value.NotifyStudent;
                        valueupdate.SMSSettings = value.SMSSettings;
                        valueupdate.Semester = value.Semester;
                        valueupdate.YearClass = value.YearClass;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "POSITION ID: [{1}]" + Environment.NewLine + "JOB TITLE;  [{2}]" + Environment.NewLine + "DESCRIPTION:  [{3}]", SystemProperties.MessageNotification.Updated, valueupdate.PositionID, valueupdate.JobTitle, valueupdate.Description);
                   
                    }
                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }
                dc.SubmitChanges();

            }
        }
        public void Delete(T_AccessRight value, ref string msg)
        {
            T_AccessRight valuedelete = new T_AccessRight();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                valuedelete = dc.T_AccessRights.Where(x => x.ID == value.ID).FirstOrDefault();
                dc.T_AccessRights.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "POSITION ID: [{1}]" + Environment.NewLine + "JOB TITLE;  [{2}]" + Environment.NewLine + "DESCRIPTION:  [{3}]", SystemProperties.MessageNotification.Deleted, valuedelete.PositionID, valuedelete.JobTitle, valuedelete.Description);               
                   
            }
        }
        public bool Compare(T_AccessRight value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_AccessRights.Where(x =>x.YearClass==value.YearClass && x.Semester==value.Semester && x.RoomType==value.RoomType && x.Building==value.Building && x.PositionID.ToLower() == value.PositionID.ToLower() && x.JobTitle.ToLower() == value.JobTitle.ToLower() && x.Description.ToLower() == value.Description.ToLower() && x.Active==value.Active && x.Student==value.Student && x.Instructor==value.Instructor && x.Position==value.Position && x.Users==value.Users && x.Application==value.Application && x.YearLevel==value.YearLevel && x.CivilStatus==value.CivilStatus && x.Course==value.Course && x.Subject==value.Subject && x.Room==value.Room && x.Time==value.Time && x.Display==value.Display && x.Report==value.Report && x.DeviceConfiguration==value.DeviceConfiguration).FirstOrDefault() == null ? true : false;
            }
        }
        public void Dispose()
        {
            
        }
    }
}
