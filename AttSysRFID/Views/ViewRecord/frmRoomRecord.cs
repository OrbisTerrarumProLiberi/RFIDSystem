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
namespace AttSysRFID.Views.ViewRecord
{
    public partial class frmRoomRecord : Form
    {
        public frmRoomRecord()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string MsgReturned;
        void SetProperties()
        {
            LoadRoomRecord();
            LoadRoom();
            LoadSemester();
            LoadSubjectCode();
            LoadYearClass();
        }
        void SetHandler()
        {
            dgRoomRecord.CellClick += new DataGridViewCellEventHandler(dgRoomRecord_CellClick);
            cmbSemester.SelectedValueChanged += new EventHandler(cmbSemester_SelectedValueChanged);
            cmbYearClass.KeyDown += new KeyEventHandler(cmbYearClass_KeyDown);
            cmbYearClass.KeyPress += new KeyPressEventHandler(cmbYearClass_KeyPress);
            cbRC.CheckedChanged += new EventHandler(cbRC_CheckedChanged);
            cbS.CheckedChanged += new EventHandler(cbS_CheckedChanged);
            cbYC.CheckedChanged += new EventHandler(cbYC_CheckedChanged);
            cbSC.CheckedChanged += new EventHandler(cbSC_CheckedChanged);
        }

        void cbSC_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbS.Checked)
                cmbSubCode.Text = "";
        }

        void cbYC_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbS.Checked)
                cmbYearClass.Text = "";
        }

        void cbS_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbS.Checked)
                cmbSemester.Text = "";
        }

        void cbRC_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbRC.Checked)
                cmbRoomCode.Text = "";
        }

        void cmbYearClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbYearClass_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }

        void cmbSemester_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSearch(cbYC.Checked, cbS.Checked, cbRC.Checked, cbSC.Checked);
        }
        void Delete(long ID)
        {
            if(SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete,"Room record")==DialogResult.Yes)
            {
                using (SMSNotification notify = new SMSNotification())
                {
                    notify.Delete(ID, ref MsgReturned);
                    SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Room record");
                    LoadRoomRecord();
                }
            }            
        }
        void dgRoomRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && dgRoomRecord.Rows.Count>0)
            {
                Delete(Convert.ToInt64(dgRoomRecord.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }
        void LoadRoomRecord()
        {
            int i = 1;
            dgRoomRecord.Rows.Clear();
            using (SMSNotification notify = new SMSNotification())
            {
                notify.GetRegisterStudent().OrderBy(o=> o.TimeStart).ToList().ForEach(x => 
                {
                    using(Maintenance maintain=new Maintenance())
                    {
                        using (Students stud = new Students())
                        {
                            var studs=stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                            var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                            dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName+","+studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                            i++;
                        }
                    }
                   
                });

            }
        }
        void LoadRoom()
        {
            cmbRoomCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetRoom().Where(x => x.Active == true).OrderBy(o => o.RoomCode).ToList().ForEach(f => 
                {
                    cmbRoomCode.Items.Add(f.RoomCode);
                });
            }
        }
        void LoadSemester()
        {
            cmbSemester.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetSemester().OrderBy(o => o.Semester).ToList().ForEach(x =>
                {
                    cmbSemester.Items.Add(x.Semester);
                    
                });
            }
        }
        void LoadYearClass() 
        {
            cmbYearClass.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetActiveSemester().OrderBy(o => o.YearSemester).ToList().ForEach(f=>
                {
                    cmbYearClass.Items.Add(f.YearSemester);
                });
            }
        }
        void LoadSubjectCode()
        {
            cmbSubCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetSubject().OrderBy(o => o.Code).ToList().ForEach(f => 
                {
                    cmbSubCode.Items.Add(f.Code);
                });
            }

        }


        void LoadSearch(bool Year, bool Semester, bool Room, bool Subject)
        {
            dgRoomRecord.Rows.Clear();
            int i = 1;
            using (SMSNotification notify = new SMSNotification())
            {
                using(Maintenance maintain=new Maintenance())
                {
                    using (Students stud = new Students())
                    {
                        if (!Year && !Semester && !Room && !Subject)
                            LoadRoomRecord();
                        if (Year && Semester && Room && Subject)//four
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text && x.Semester == cmbSemester.Text && x.RoomCode == cmbRoomCode.Text && x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x => 
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;
                                    
                                });
                            }
                        }
                        if (Year )//four
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Semester )//four
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x =>  x.Semester == cmbSemester.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if ( Room)//four
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x =>  x.RoomCode == cmbRoomCode.Text ).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Subject)//four
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x =>  x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Year && Semester && Room)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text && x.Semester == cmbSemester.Text && x.RoomCode == cmbRoomCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Year && Semester  && Subject)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text && x.Semester == cmbSemester.Text  && x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }

                        if ( Semester && Room && Subject)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x =>  x.Semester == cmbSemester.Text && x.RoomCode == cmbRoomCode.Text && x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Year  && Room && Subject)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text &&  x.RoomCode == cmbRoomCode.Text && x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }

                        if (Year && Semester)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text && x.Semester == cmbSemester.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Year  && Room )
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text && x.RoomCode == cmbRoomCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Year  && Subject)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.YearClass == cmbYearClass.Text &&  x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }

                        if ( Semester && Room )
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x =>  x.Semester == cmbSemester.Text && x.RoomCode == cmbRoomCode.Text ).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Semester  && Subject)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x =>  x.Semester == cmbSemester.Text && x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }
                        if (Room && Subject)
                        {
                            dgRoomRecord.Rows.Clear();
                            var value = notify.GetRegisterStudent().Where(x => x.RoomCode == cmbRoomCode.Text && x.SubjectCode == cmbSubCode.Text).OrderBy(o => o.TimeStart).ToList();
                            if (value.Count > 0)
                            {
                                value.ForEach(x =>
                                {
                                    var studs = stud.GetStudentInfo().Where(s => s.StudentID == x.StudentID).FirstOrDefault();
                                    var valueBldg = maintain.GetRoom().Where(xx => xx.RoomCode == x.RoomCode).FirstOrDefault();
                                    dgRoomRecord.Rows.Add(x.ID, i, x.StudentID, studs.LastName + "," + studs.FirstName, x.Semester, valueBldg.BuildingCode, x.RoomCode, valueBldg.Description, x.TimeStart.ToShortTimeString() + " to " + x.TImeEnd.ToShortTimeString());
                                    i++;

                                });
                            }
                        }

                    }
                }
            }
        }


    }
}
