using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
namespace AttSysRFID.Views.Notification
{
    public partial class frmApplySMSForStudent : Form
    {
        public frmApplySMSForStudent()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string MsgReturned = "";
        private bool isAdd;
        void SetProperties()
        {
            GetDayAndTime();
            GetRoomSubjectMessage();
            LoadStudent();
            ObjEnable(false);
            SystemProperties.Cleared(this, false, true, true);
            dgDay.Enabled = dgTime.Enabled = dgStudentList.Enabled = false;

            txtRoomDesc.ReadOnly = true;
            txtSubjectDesc.ReadOnly = true;
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

            dgTime.CellClick += new DataGridViewCellEventHandler(dgTime_CellClick);
            dgDay.CellClick += new DataGridViewCellEventHandler(dgDay_CellClick);
            dgStudentList.CellClick += new DataGridViewCellEventHandler(dgStudentList_CellClick);


            cmbRoomCode.SelectedValueChanged += new EventHandler(cmbRoomCode_SelectedValueChanged);
            cmbRoomCode.KeyPress += new KeyPressEventHandler(cmbRoomCode_KeyPress);
            cmbRoomCode.KeyDown += new KeyEventHandler(cmbRoomCode_KeyDown);

            cmbSubjectCode.SelectedValueChanged += new EventHandler(cmbSubjectCode_SelectedValueChanged);
            cmbSubjectCode.KeyDown += new KeyEventHandler(cmbSubjectCode_KeyDown);
            cmbSubjectCode.KeyPress += new KeyPressEventHandler(cmbSubjectCode_KeyPress);

            cmbSearch.KeyDown += new KeyEventHandler(cmbSearch_KeyDown);
            cmbSearch.KeyPress += new KeyPressEventHandler(cmbSearch_KeyPress);
            cmbMessage.KeyDown += new KeyEventHandler(cmbMessage_KeyDown);
            cmbMessage.KeyPress += new KeyPressEventHandler(cmbMessage_KeyPress);


            rbyearlvl.CheckedChanged += new EventHandler(rbyearlvl_CheckedChanged);
            rbCourse.CheckedChanged += new EventHandler(rbCourse_CheckedChanged);
            cmbSearch.SelectedValueChanged += new EventHandler(cmbSearch_SelectedValueChanged);

            dgStudentList.CellValueChanged += new DataGridViewCellEventHandler(dgStudentList_CellValueChanged);

        }

        void dgStudentList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int b=0;
            for (int i = 0; i <= dgStudentList.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dgStudentList.Rows[i].Cells[6].Value))
                {
                    b++;
                    lblSelected.Text = string.Format("Selected: {0} ", b);
                    
                }
               
            }
        }

        void cmbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void rbCourse_CheckedChanged(object sender, EventArgs e)
        {
            cmbSearch.Text = "";
            LoadCourseYealvl(true);
        }
        void cmbSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            lblSelected.Text = string.Format("Selected: 0 ");
            LoadStudent(cmbSearch.Text);
        }
        void rbyearlvl_CheckedChanged(object sender, EventArgs e)
        {
            cmbSearch.Text = "";
            LoadCourseYealvl(false);
        }
        void LoadCourseYealvl(bool Course)
        {
            cmbSearch.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                if (Course)
                    maintain.GetCourse().Where(x => x.Active == true).OrderBy(o => o.Course).ToList().ForEach(y =>
                    {
                        cmbSearch.Items.Add(y.CourseCode);
                    });
                else
                    maintain.GetYearLevel().Where(x => x.Active == true).OrderBy(o => o.YearLevel).ToList().ForEach(y => 
                    {
                        cmbSearch.Items.Add(y.YearLevel);
                    });
            }
        }
        void LoadStudent( string Search)
        {
            int i = 1;
            dgStudentList.Rows.Clear();
            using (Students std = new Students())
            {
                using (Maintenance maintain = new Maintenance())
                {
                    if(rbCourse.Checked)
                        Search=maintain.GetCourse().Where(x => x.CourseCode == Search).FirstOrDefault().Course;                    
                    std.GetStudentInfo().Where(x => rbCourse.Checked ? x.Course == Search : x.YearLevel == Search && x.Active == true && x.CompletedStatus == true && x.EnrolledStatus == true && x.GraduateStatus == false).ToList().ForEach(f =>
                    {
                        dgStudentList.Rows.Add(f.ID, i, f.StudentID, string.Format("{0},{1} {2}", f.LastName, f.FirstName, f.MiddleName), f.Course, f.YearLevel, false);
                        i++;
                    });
                }
                
            }
        }
        void cmbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }        
        void cmbSubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbSubjectCode_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbSubjectCode_SelectedValueChanged(object sender, EventArgs e)
        {
            GEtSubjectDescription(cmbSubjectCode.Text);

        }
        void cmbRoomCode_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbRoomCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbRoomCode_SelectedValueChanged(object sender, EventArgs e)
        {
            GetRoomDescription(cmbRoomCode.Text);
            GetCapacity(cmbRoomCode.Text);
        }
        void dgStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                dgStudentList.SelectedRows[0].Cells[6].Value = !Convert.ToBoolean(dgStudentList.SelectedRows[0].Cells[6].Value);
                int b = 0;
                for (int i = 0; i <= dgStudentList.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dgStudentList.Rows[i].Cells[6].Value))
                    {
                        b++;
                        lblSelected.Text = string.Format("Selected: {0} ", b);
                        
                    }                    
                }
            }
        }
        void dgDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                dgDay.SelectedRows[0].Cells[1].Value = !Convert.ToBoolean(dgDay.SelectedRows[0].Cells[1].Value.ToString());
            }
        }
        void dgTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dgTime.SelectedRows[0].Cells[2].Value=!Convert.ToBoolean(dgTime.SelectedRows[0].Cells[2].Value.ToString());
            }
        }

        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());            
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            isAdd = true;
            SystemProperties.Cleared(this, true, true, true);
            dgDay.Enabled = dgTime.Enabled=dgStudentList.Enabled= true;
            GetDayAndTime();
            GetRoomSubjectMessage();
            MsgReturned = "";
            txtRoomDesc.ReadOnly = true;
            txtSubjectDesc.ReadOnly = true;
            
        }    
        void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "SMS for student") == DialogResult.Yes)
            {
                if (CheckEmpty())
                {
                    Save();
                    MsgReturned = "";
                    dgDay.Enabled = dgTime.Enabled = dgStudentList.Enabled = false;
                    txtRoomDesc.ReadOnly = true;
                    txtSubjectDesc.ReadOnly = true;
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput +Environment.NewLine+Environment.NewLine+"Room"+Environment.NewLine+"Subject"+Environment.NewLine+"Message alert", "SMS for student");
                }
            }
           
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            //LoadYearLevel();
            ObjEnable(false);
            SystemProperties.Cleared(this, false, true, true);
            dgDay.Enabled = dgTime.Enabled = dgStudentList.Enabled = false;
            GetDayAndTime();
            GetRoomSubjectMessage();
            MsgReturned = "";
            txtRoomDesc.ReadOnly = true;
            LoadStudent();
            txtSubjectDesc.ReadOnly = true;
        }
        bool CheckEmpty()
        {
            if (!string.IsNullOrWhiteSpace(cmbRoomCode.Text) && !string.IsNullOrWhiteSpace(cmbSubjectCode.Text) && !string.IsNullOrWhiteSpace(cmbMessage.Text))            
                return true;            
            else
                return false;
        }
        void Save()
        {
            
            T_RegisteredStudentSemester ret = new T_RegisteredStudentSemester();
            var StudentSelected= dgStudentList.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells[6].Value)).ToList();
            var DaySelected= dgDay.Rows.Cast<DataGridViewRow>().Where(d => Convert.ToBoolean(d.Cells[1].Value)).ToList();
            var TimeSelected = dgTime.Rows.Cast<DataGridViewRow>().Where(t => Convert.ToBoolean(t.Cells[2].Value)).ToList();
            if (StudentSelected.Count > 0)
            {
                StudentSelected.ForEach(s =>
                {
                    ret.StudentID = s.Cells[2].Value.ToString();
                    
                    using (Students std = new Students())
                    {
                        var stud = std.GetStudentInfo().Where(x => x.StudentID == s.Cells[2].Value.ToString()).FirstOrDefault();
                        ret.Active = true;
                        ret.RFID = stud.RFIDNo;
                        ret.RoomCode = cmbRoomCode.Text;
                        ret.MessageID = cmbMessage.Text;
                        ret.SubjectCode = cmbSubjectCode.Text;
                        ret.SubjectDescription = txtSubjectDesc.Text;
                        ret.Semester = SystemProperties.SemesterActive.Semester;
                        ret.SemStartDate = SystemProperties.SemesterActive.Start;
                        ret.SemEndDate = SystemProperties.SemesterActive.End;
                        ret.YearClass = SystemProperties.SemesterActive.YearSemester;
                        using (Parents parent = new Parents())
                        {
                            var part=parent.GetParentsInfo().Where(pp => pp.StudentID == stud.StudentID).FirstOrDefault();
                            ret.ParentsNo = !string.IsNullOrWhiteSpace(part.MomContactNo)?part.MomContactNo:part.DadContactNo;
                        }
                        if (DaySelected.Count > 0)
                        {
                            DaySelected.ForEach(dd =>
                            {
                                ret.Day = dd.Cells[0].Value.ToString();
                                if (TimeSelected.Count > 0)
                                {
                                    TimeSelected.ForEach(tt =>
                                    {
                                        var _tt = tt.Cells[3].Value.ToString();
                                        using (Maintenance maintain = new Maintenance())
                                        {
                                            var TimeStartEnd = maintain.GetTime().Where(ttt => ttt.TimeCode == _tt).FirstOrDefault();
                                            ret.TimeStart = TimeStartEnd.TimeStart.Value;
                                            ret.TImeEnd = TimeStartEnd.TimeEnd.Value;
                                            using (SMSNotification notify = new SMSNotification())
                                            {
                                                string msgRet = "";
                                                notify.Save(ret, ref msgRet);
                                                lblMessage.Text = msgRet;

                                                
                                            }
                                        }
                                    });
                                }
                                else
                                {
                                    SystemProperties.ShowMessage.MessageError("Select time first", "Time Error");
                                }

                            });
                            
                        }
                        else 
                        {
                            SystemProperties.ShowMessage.MessageError("Select day first", "Day Error");
                        }

                    }

                });

            }
            GetDayAndTime();
            GetRoomSubjectMessage();
            LoadStudent();
            ObjEnable(false);
            SystemProperties.Cleared(this, false, true, true);
            dgDay.Enabled = dgTime.Enabled = dgStudentList.Enabled = false;

            txtRoomDesc.ReadOnly = true;
            txtSubjectDesc.ReadOnly = true;
        }
        private bool CheckCapacity(T_RegisteredStudentSemester value)
        {
            using (SMSNotification nofity = new SMSNotification())
            {
                var cap=nofity.GetRegisterStudent().Where(x => x.Day == value.Day && x.TImeEnd.ToShortTimeString() == value.TImeEnd.ToShortTimeString() && x.TimeStart.ToShortTimeString() == value.TimeStart.ToShortTimeString() && x.Semester == value.Semester && x.SemEndDate.ToShortDateString() == value.SemEndDate.ToShortDateString() && x.SemStartDate.ToShortDateString() == value.SemStartDate.ToShortDateString() && x.YearClass == value.YearClass && x.Active==true).ToList().Count;
                //lblSelected.Text = string.Format("Selected",cap);
                return cap <= GetCapacity(value.RoomCode)?true:false;
            }
        }
        private int GetCapacity(string RoomCode) 
        {
            using (Maintenance maintain = new Maintenance())
            {
                int retCap = 0;
                retCap= maintain.GetRoom().Where(x => x.RoomCode == RoomCode).FirstOrDefault().Capacity.Value;
                lblMessageCheckRecord.Text =string.Format("Room capacity: {0} ",retCap);
                return retCap;
            }        
        }
        private T_RegisteredStudentSemester SetupRegistrationSubject()
        {
            T_RegisteredStudentSemester ret = new T_RegisteredStudentSemester();

            return ret;
        }
        void LoadStudent()
        {
            int i = 1;
            dgStudentList.Rows.Clear();
            using (Students std = new Students())
            {
                std.GetStudentInfo().Where(x=> x.Active==true && x.CompletedStatus==true && x.EnrolledStatus==true && x.GraduateStatus==false) .ToList().ForEach( f=>
                {
                    dgStudentList.Rows.Add(f.ID,i,f.StudentID,string.Format("{0},{1} {2}",f.LastName,f.FirstName,f.MiddleName),f.Course,f.YearLevel,false);
                    i++;
                });
            }
        }
        void GetRoomSubjectMessage()
        {
            cmbMessage.Items.Clear();
            cmbRoomCode.Items.Clear();
            cmbSubjectCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetRoom().Where(x => x.Active == true).OrderBy(o=> o.RoomCode).ToList().ForEach(y =>
                {
                    cmbRoomCode.Items.Add(y.RoomCode);
                });
                maintain.GetSubject().Where(x => x.Active == true).OrderBy(o => o.Code).ToList().ForEach(y => 
                {
                    cmbSubjectCode.Items.Add(y.Code);
                });
            }
            using (SMSNotification smsNotify = new SMSNotification())
            {
                smsNotify.GetSMS().Where(x => x.Active == true).ToList().ForEach(s => 
                {
                    cmbMessage.Items.Add(s.Code);
                });
            }
        }
        void GetDayAndTime()
        {
            dgDay.Rows.Clear();
            dgTime.Rows.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetDay().Where(y=> y.Active==true).ToList().ForEach(x =>
                {
                    dgDay.Rows.Add(x.Day,false );
                });
                maintain.GetTime().Where(y => y.Active == true).ToList().ForEach(t => 
                {
                    dgTime.Rows.Add(t.ID, string.Format("{0} to {1}",t.TimeStart.Value.ToShortTimeString(),t.TimeEnd.Value.ToShortTimeString()), false, t.TimeCode);
                });
            }
        }
        void GetRoomDescription(string RoomCode)
        {
            txtRoomDesc.Text = "";
            using (Maintenance maintain = new Maintenance())
            {
                txtRoomDesc.Text =maintain.GetRoom().Where(x => x.Active == true && x.RoomCode == RoomCode).FirstOrDefault().Description;
            }
        }
        void GEtSubjectDescription(string SubCode)
        {
            txtSubjectDesc.Text = "";
            using (Maintenance maintain = new Maintenance())
            {
                txtSubjectDesc.Text = maintain.GetSubject().Where(x=> x.Active==true && x.Code==SubCode).FirstOrDefault().Description;
            }
        }
    }
}
