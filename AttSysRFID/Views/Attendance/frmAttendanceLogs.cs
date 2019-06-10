using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttSysRFID.ViewModel;
using AttSysRFID.Model;
namespace AttSysRFID.Views.Attendance
{
    public partial class frmAttendanceLogs : Form
    {
        public frmAttendanceLogs()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            GetAttendanceLogs();
            LoadSubCode();
            LoadDay();
            LoadRoomCode();
        }
        void SetHandler()
        {
            cmbDays.KeyDown += new KeyEventHandler(cmbDays_KeyDown);
            cmbDays.KeyPress += new KeyPressEventHandler(cmbDays_KeyPress);
            cbDStart.CheckedChanged += new EventHandler(cbDStart_CheckedChanged);
            cmbDays.SelectedValueChanged += new EventHandler(cmbDays_SelectedValueChanged);
            cmbRoomCode.SelectedValueChanged += new EventHandler(cmbRoomCode_SelectedValueChanged);
            cmbSubCode.SelectedValueChanged += new EventHandler(cmbSubCode_SelectedValueChanged);
            dtDateEnd.ValueChanged += new EventHandler(dtDateEnd_ValueChanged);
            dtDateStart.ValueChanged += new EventHandler(dtDateStart_ValueChanged);
            dtTimeIN.ValueChanged += new EventHandler(dtTimeIN_ValueChanged);
            dtTimeOUT.ValueChanged += new EventHandler(dtTimeOUT_ValueChanged);

            cbDay.CheckedChanged += new EventHandler(cbDay_CheckedChanged);
            cbRC.CheckedChanged += new EventHandler(cbRC_CheckedChanged);
            cbSC.CheckedChanged += new EventHandler(cbSC_CheckedChanged);
            btnPrint.Click += new EventHandler(btnPrint_Click);
            PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
            PrintDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
        }

        void PrintDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


           
        
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintDoc.Print();
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Attandance report";
            //printer.SubTitle = string.Format("Date: ",UserDetail.CurrDate());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;

            //printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PorportionalColumns = false;

            printer.Footer = "";
            printer.FooterSpacing = 15;
            printer.PrintMargins.Left=0;
            printer.PrintMargins.Right = 0;

            printer.PrintDataGridView(dgAttendanceLogs);
        }

        void cbSC_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbSC.Checked)
                cmbSubCode.SelectedText = "";
        }

        void cbRC_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbRC.Checked)
                cmbRoomCode.Text = "";
        }

        void cbDay_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbDay.Checked)
                cmbDays.Text = "";
        }

        void dtTimeOUT_ValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void dtTimeIN_ValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void dtDateStart_ValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void dtDateEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void cmbSubCode_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void cmbRoomCode_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void cmbDays_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSelected(cbDStart.Checked, cbTimeINOUT.Checked, cbDay.Checked, cbSC.Checked, cbRC.Checked);
        }

        void cbDStart_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        void cmbDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbDays_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void LoadSelected(bool Date,bool Time,bool Day,bool SubCode,bool RoomCode)
        {
            int i = 1;
            dgAttendanceLogs.Rows.Clear();
            using (SMSNotification notify = new SMSNotification())
            {
                #region 1
                //Start 1
                if (Date && Time && Day && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) && x.Day == cmbDays.Text && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 
               

                #region 2
                //Start 1
                if (Time && Day && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x =>  (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) && x.Day == cmbDays.Text && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 3
                //Start 1
                if (Date  && Day && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value))  && x.Day == cmbDays.Text && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 


                #region 4
                //Start 1
                if (Date && Time  && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value))  && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 5
                //Start 1
                if (Date && Time && Day && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) && x.Day == cmbDays.Text && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 6
                //Start 1
                if (Date && Time && Day)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value))).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 


                #region 7
                //Start 1
                if ( Time && Day && SubCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x =>  (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) && x.Day == cmbDays.Text && x.SubjectCode == cmbSubCode.Text ).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 


                #region 8
                //Start 1
                if (Day && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => x.Day == cmbDays.Text && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 


                #region 9
                //Start 1
                if (Date && SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value))  && x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 10
                //Start 1
                if (Date && Time && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value))  && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 11
                //Start 1
                if (Date && Time )
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) ).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 12
                //Start 1
                if (Time && Day )
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) && x.Day == cmbDays.Text ).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 13
                //Start 1
                if (SubCode && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x =>  x.SubjectCode == cmbSubCode.Text && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 14
                //Start 1
                if (Date && RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) && x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 


                #region 15
                //Start 1
                if (Date)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => (ConvertDates(x.TimeIN.Value) >= ConvertDates(dtDateStart.Value) && (ConvertDates(x.TimeIN.Value)) <= ConvertDates(dtDateEnd.Value)) ).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 16
                //Start 1
                if (Time)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x =>  (ConvertTimes(x.TimeIN.Value) >= ConvertTimes(dtTimeIN.Value) && ConvertTimes(x.TimeIN.Value) <= ConvertTimes(dtTimeOUT.Value)) ).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 

                #region 17
                //Start 1
                if ( Day)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x => x.Day == cmbDays.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 
               
                #region 18
                //Start 1
                if (SubCode )
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x =>  x.SubjectCode == cmbSubCode.Text ).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 
               
                #region 19
                //Start 1
                if ( RoomCode)
                {
                    dgAttendanceLogs.Rows.Clear();
                    var value = notify.GetUserTime().Where(x =>  x.RoomCode == cmbRoomCode.Text).ToList();
                    if (value.Count > 0)
                    {

                        value.ForEach(x =>
                        {
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();

                                dgAttendanceLogs.Rows.Add(x.ID, i, x.StudentID, valueStud != null ? valueStud.LastName + ", " + valueStud.FirstName : "Student name are not found", x.SubjectCode, x.RoomCode, x.Day, x.TimeIN, x.TimeOUT);
                                i++;
                            }
                        });

                    }
                }
                //End
                #endregion 
               
            }
        }
        DateTime ConvertDates(DateTime dtp)
        {
            return Convert.ToDateTime(dtp.ToShortDateString());
        }
        DateTime ConvertTimes(DateTime dtp)
        {
            return Convert.ToDateTime(dtp.ToShortTimeString());
        }

        void LoadDay()
        {
            cmbDays.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetDay().ForEach(x => 
                {
                    cmbDays.Items.Add(x.Day);
                });
            }
        }
        void LoadRoomCode()
        {
            cmbRoomCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetRoom().ForEach(x =>
                {
                    cmbRoomCode.Items.Add(x.RoomCode);
                });
            }
        }
        void LoadSubCode()
        {
            cmbSubCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetSubject().ForEach(x =>
                {
                    cmbSubCode.Items.Add(x.Code);
                });
            }
        }
        void GetAttendanceLogs()
        {
            dgAttendanceLogs.Rows.Clear();
            int i = 1;
            using (SMSNotification notify = new SMSNotification())
            {
                var value = notify.GetUserTime();
                if(value.Count>0)
                    value.ForEach(x => 
                    {                        
                            using (Students stud = new Students())
                            {
                                var valueStud = stud.GetStudentInfo().Where(xx => xx.StudentID == x.StudentID).FirstOrDefault();      
                        
                                dgAttendanceLogs.Rows.Add(x.ID,i, x.StudentID,valueStud!=null?valueStud.LastName+", "+valueStud.FirstName:"Student name are not found",x.SubjectCode,x.RoomCode,x.Day,x.TimeIN,x.TimeOUT);
                            i++;
                            }                    
                    });
            }
        }

       
    }
}
