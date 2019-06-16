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
using System.IO.Ports;
using System.IO;
namespace AttSysRFID.Views.Student
{
    public partial class frmStudent : Form
    {
        List<string> getCard = new List<string>();
        private string[] ComPortList;
        private string Disp;        
        private bool isAdd;
        private string MsgReturned;
        private string MotherID;
        private string FaterID;
        private long ParentsID;
        private string StudentFileImage;
        private string Comport;

        public frmStudent()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
            
        }

        void SetProperties()
        {
            LoadApplication();
            LoadCourse();
            LoadYearLevel();
            LoadCivilStatus();
            LoadStudentInfo();

            ObjEnable(false);
            SystemProperties.Cleared(this, false, true, true);
            SystemProperties.Cleared(Mother, false, true, true);
            SystemProperties.Cleared(Father, false, true, true);
            txtSearch.ReadOnly = false;
            AutoScanTimer.Enabled = true;
            AutoScanTimer.Start();
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            dgStudentRecord.CellClick += new DataGridViewCellEventHandler(dgStudentRecord_CellClick);
            dgStudentRecord.RowsAdded += DgStudentRecord_RowsAdded;

            cmbApplication.KeyDown += new KeyEventHandler(cmbApplication_KeyDown);
            cmbFatherCivilStatus.KeyDown += new KeyEventHandler(cmbFatherCivilStatus_KeyDown);
            cmbMotherCivilStatus.KeyDown += new KeyEventHandler(cmbMotherCivilStatus_KeyDown);
            cmbStudentCourse.KeyDown += new KeyEventHandler(cmbStudentCourse_KeyDown);
            cmbYearLevel.KeyDown += new KeyEventHandler(cmbYearLevel_KeyDown);

            cmbApplication.KeyPress += new KeyPressEventHandler(cmbApplication_KeyPress);
            cmbFatherCivilStatus.KeyPress += new KeyPressEventHandler(cmbFatherCivilStatus_KeyPress);
            cmbMotherCivilStatus.KeyPress += new KeyPressEventHandler(cmbMotherCivilStatus_KeyPress);
            cmbStudentCourse.KeyPress += new KeyPressEventHandler(cmbStudentCourse_KeyPress);
            cmbYearLevel.KeyPress += new KeyPressEventHandler(cmbYearLevel_KeyPress);

            AutoScanTimer.Tick += new EventHandler(AutoScanTimer_Tick);
            ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived);
            txtStudentRFIDNo.TextChanged += new EventHandler(txtStudentRFIDNo_TextChanged);

            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            //txtSearch.KeyUp += new KeyEventHandler(txtSearch_KeyUp);
            txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            picStudent.Click += new EventHandler(picStudent_Click);
        }

        private void DgStudentRecord_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgStudentRecord[Column1.Index, e.RowIndex].Value = dgStudentRecord.RowCount;
        }

        void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadStudentInfo(txtSearch.Text);
            //else
            //    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + "for search box", "Student registration");
            
        }

        void picStudent_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Image File(*.bmp;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFile.FileName = "Student image";            
            if (openFile.ShowDialog() != DialogResult.Cancel)
            {
                picStudent.Image = Image.FromFile(openFile.FileName);
                StudentFileImage = openFile.FileName;
            }
        }        

        void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadStudentInfo(txtSearch.Text);
            else
                SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput +" for search box","Student registration");
        }
       
        void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadStudentInfo();           
        }

        void txtStudentRFIDNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentRFIDNo.Text))
            {
                AutoScanTimer.Enabled = true;
                AutoScanTimer.Start();                
            }
        }

        void cmbYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbStudentCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbMotherCivilStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbFatherCivilStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbApplication_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbYearLevel_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }

        void cmbStudentCourse_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }

        void cmbMotherCivilStatus_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }

        void cmbFatherCivilStatus_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }

        void cmbApplication_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }

        void dgStudentRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedOne(Convert.ToInt64(dgStudentRecord.SelectedRows[0].Cells[0].Value.ToString()));
        }

        void LoadSelectedOne(long ID)
        {
            using (Students std = new Students())
            {
                //Convert.ToInt64(dgStudentRecord.SelectedRows[0].Cells[0].Value.ToString())
                var value = std.GetStudentInfo().Where(x => x.ID == ID).FirstOrDefault();
                if (value != null)
                {

                    btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                    txtStudentID.Text = value.StudentID;
                    MotherID = value.MotherID;// = isAdd ? txtStudentID.Text + "-M" : MotherID;
                    FaterID = value.FatherID;// = isAdd ? txtStudentID.Text + "-F" : FaterID;
                    cmbApplication.Text = value.Application;
                    txtStudentLastName.Text = value.LastName;
                    txtStudentFirstName.Text = value.FirstName;
                    txtStudentMiddleName.Text = value.MiddleName;
                    txtStudentContactNo.Text = value.ContactNo;
                    dtStudentBday.Value = value.Bday;
                    cmbYearLevel.Text = value.YearLevel;
                    SaveImage(false);
                    if (value.Gender.ToLower() == "male")
                    {
                        rbStudentMale.Checked = true;
                        rbStudentFemale.Checked = false;
                    }
                    else
                    {

                        rbStudentMale.Checked = false;
                        rbStudentFemale.Checked = true;
                    }
                    txtStudentRFIDNo.Text = value.RFIDNo;
                    cmbStudentCourse.Text = value.Course;
                    txtStudentAddress.Text = value.Address;
                    cbCompleted.Checked = value.CompletedStatus.Value;
                    cbGraduated.Checked = value.GraduateStatus.Value;
                    cbEnrolled.Checked = value.EnrolledStatus.Value;
                    cbRFIDstd.Checked = value.RFIDStatus.Value;
                    cbContactNoStd.Checked = value.ContactNoStatus.Value;
                    cbActiveStd.Checked = value.Active.Value;

                }
            }
            using (Parents parent = new Parents())
            {
                var value = parent.GetParentsInfo().Where(x => x.StudentID == dgStudentRecord.SelectedRows[0].Cells[2].Value.ToString()).FirstOrDefault();
                if (value != null)
                {
                    ParentsID = value.ID;
                    txtFatherAddress.Text = value.DadAddress;
                    cmbFatherCivilStatus.Text = value.DadCivilStatus;
                    txtFatherContactNo.Text = value.DadContactNo;
                    txtFatherFirstName.Text = value.DadFistName;
                    txtFatherLastName.Text = value.DadLastName;
                    txtFatherMiddleName.Text = value.DadMiddleName;
                    txtFatherRFIDNo.Text = value.DadRFIDNo;
                    cbRFIDDads.Checked = value.FRFIDNo.Value;
                    cbContactDads.Checked = value.FContactNo.Value;
                    cbActiveDads.Checked = value.FActive.Value;

                    txtMotherLastName.Text = value.MomLastName;
                    txtMotherFirstName.Text = value.MomFirstName;
                    txtMotherMiddleName.Text = value.MomMiddleName;
                    txtMotherContactNo.Text = value.MomContactNo;
                    txtMotherRFIDNo.Text = value.MomRFIDNo;
                    cmbMotherCivilStatus.Text = value.MomCivilStatus;
                    txtMotherAddress.Text = value.MomAddress;
                    cbRFIDMoms.Checked = value.MRFIDNo.Value;
                    cbContactMoms.Checked = value.MContactNo.Value;
                    cbActiveMoms.Checked = value.MActive.Value;
                }
            }
        }

        void LoadApplication()
        {
            cmbApplication.Items.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetApplication().OrderBy(o=> o.Application).ToList().ForEach(x =>
                {
                    cmbApplication.Items.Add(x.Application);
                });
            }
        }

        void LoadCourse()
        {
            cmbStudentCourse.Items.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetCourse().OrderBy(o=> o.Course).ToList().ForEach(x => 
                {
                    cmbStudentCourse.Items.Add(x.Course);
                });
            }
        }

        void LoadYearLevel()
        {
            cmbYearLevel.Items.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetYearLevel().OrderBy(o => o.YearLevel).ToList().ForEach(x => 
                {
                    cmbYearLevel.Items.Add(x.YearLevel);
                });
            }
        }

        void LoadCivilStatus()
        {
            cmbFatherCivilStatus.Items.Clear();
            cmbMotherCivilStatus.Items.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetCivilStatus().OrderBy(o => o.Status).ToList().ForEach(x => 
                {
                    cmbFatherCivilStatus.Items.Add(x.Status);
                    cmbMotherCivilStatus.Items.Add(x.Status);
                });
            }
        }

        void LoadStudentInfo(string Search)
        {
            dgStudentRecord.Rows.Clear();
            //int i = 1;
            using (Students _std = new Students())
            {
                var value = _std.GetStudentInfo()
                            .Where(y=> 
                                y.StudentID.ToLower().Contains(Search.ToLower()) || 
                                y.RFIDNo.ToLower().Contains(Search.ToLower()) || 
                                y.LastName.ToLower().Contains(Search.ToLower()) || 
                                y.FirstName.ToLower().Contains(Search.ToLower()))
                            .ToList();
                //var value=  _std.GetStudentInfo().Where(y=> y.StudentID== Search || y.RFIDNo==Search || y.LastName==Search || y.FirstName==Search).OrderBy(o=> o.LastName).ToList();
                value.ForEach(x =>
                {
                    dgStudentRecord.Rows.Add(x.ID, 0, x.StudentID, string.Format("{0}, {1} {2}", x.LastName, x.FirstName, x.MiddleName));
                    //i++;
                });
                if (value.Count >= 1)
                    LoadSelectedOne(value.FirstOrDefault().ID);

                else
                {
                    SystemProperties.ShowMessage.MessageError("Record are not found","Student registration");
                    SystemProperties.Cleared(this, false, true, true);
                    SystemProperties.Cleared(Mother, false, true, true);
                    SystemProperties.Cleared(Father, false, true, true);
                }

            }

            ObjEnable(false);
            //dgStudentRecord.Enabled = false;
            txtSearch.ReadOnly = false;
        }

        void LoadStudentInfo()
        {
            dgStudentRecord.Rows.Clear();
            //int i = 1;
            using (Students _std = new Students())
            {
                _std.GetStudentInfo().ForEach(x =>
                {
                    dgStudentRecord.Rows.Add(x.ID,0,x.StudentID,string.Format("{0}, {1} {2}",x.LastName,x.FirstName,x.MiddleName));
                    //i++;
                });
            }

            ObjEnable(false);
            dgStudentRecord.Enabled = false;
            txtSearch.ReadOnly = false;
            dgStudentRecord.Enabled = true;
        }

        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Student registration") == DialogResult.Yes)
            {
                if (CheckEmpty())
                {
                    if (CheckRFIDNo())
                    {
                        using (Students _std = new Students())
                        {
                            _std.Save(SetupStudentInfo(false), ref MsgReturned);
                            SaveImage(true);
                        }
                        using (Parents parent = new Parents())
                        {
                            parent.Save(SetupParentInfo(false));
                        }
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Student registration");
                        SystemProperties.Cleared(this, false, true, true);
                        SystemProperties.Cleared(Mother, false, true, true);
                        SystemProperties.Cleared(Father, false, true, true);
                        LoadStudentInfo();
                    }
                    else
                        SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.ExistRFID, "Student registration");                   
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Student ID" + Environment.NewLine + "Student Last Name" + Environment.NewLine + "Student First Name" + Environment.NewLine + "Student RFID No." + Environment.NewLine + Environment.NewLine + "Mother Last Name, First Name, Contact No" + Environment.NewLine + "Father Last Name, First Name, Contact No", "Student registration");
                }
            }
            
        }

        private bool CheckEmpty()
        {
            if ((!string.IsNullOrWhiteSpace(txtFatherLastName.Text) && !string.IsNullOrWhiteSpace(txtFatherFirstName.Text) || (!string.IsNullOrWhiteSpace(txtMotherFirstName.Text) && !string.IsNullOrWhiteSpace(txtMotherLastName.Text))) && !string.IsNullOrWhiteSpace(txtStudentID.Text) && !string.IsNullOrWhiteSpace(txtStudentLastName.Text) && !string.IsNullOrWhiteSpace(txtStudentFirstName.Text) && !string.IsNullOrWhiteSpace(txtStudentRFIDNo.Text) && (!string.IsNullOrWhiteSpace(txtMotherContactNo.Text) || !string.IsNullOrWhiteSpace(txtFatherContactNo.Text)))
                return true;            
            else
                return false;
        }

        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Student registration") == DialogResult.Yes)
            {
                if (CheckEmpty())
                {
                    using (Students _std = new Students())
                    {
                        DeleteImage();
                        _std.Delete(SetupStudentInfo(true), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Student registration");                        
                    }
                    using (Parents parent = new Parents())
                    {
                        parent.Delete(SetupParentInfo(true));
                    }
                    LoadStudentInfo();
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Student registration");

                }
            }
        }

        void DeleteImage()
        {
            string pathDirection = "";
            string ImageName = "";
            pathDirection = SystemProperties.ReadStudentImage();

            ImageName = string.Format("{0}{1}-{2}", txtStudentLastName.Text, txtStudentFirstName.Text, txtStudentID.Text);          
            //picStudent.Image.d(@"" + pathDirection + ImageName + ".png");
            File.Delete(string.Format("{0}{1}", pathDirection, ImageName));
            
        }

        void SaveImage(bool IsSave)
        {
            picStudent.Image = null;
            string pathDirection = "";
            string ImageName = "";
            pathDirection= SystemProperties.ReadStudentImage();
            
            ImageName = string.Format("{0}",txtStudentID.Text);
            try
            {
                if (picStudent.Image != null)
                {
                    if (IsSave)
                    {
                        picStudent.Image.Save(@"" + pathDirection + ImageName + ".png");
                    }
                    else
                    {
                        picStudent.Image = Image.FromFile(pathDirection + ImageName + ".png");
                    }
                }
                else if (!IsSave)
                {
                    picStudent.Image = Image.FromFile(pathDirection + ImageName + ".png");
                }

            }
            catch (Exception ex)
            {

            }
        }

        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, !enable, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
            btnSearch = SystemProperties.BtnProperties(btnSearch, true, Imagename.Search.ToString(), Imagename.Search.ToString());
        }

        private T_StudentInformation SetupStudentInfo(bool IsDelete)
        {
            T_StudentInformation value = new T_StudentInformation();

            value.ID=isAdd?0:Convert.ToInt64(dgStudentRecord.SelectedRows[0].Cells[0].Value.ToString());
            if(IsDelete)
                value.ID = Convert.ToInt64(dgStudentRecord.SelectedRows[0].Cells[0].Value.ToString());
            value.StudentID = txtStudentID.Text;
            value.MotherID=isAdd?txtStudentID.Text +"-M":MotherID;
            value.FatherID = isAdd ? txtStudentID.Text + "-F" : FaterID;
            value.Application = cmbApplication.Text;
            value.LastName = txtStudentLastName.Text;
            value.FirstName = txtStudentFirstName.Text;
            value.MiddleName = txtStudentMiddleName.Text;
            value.ContactNo = txtStudentContactNo.Text.Replace("-","").Replace("\r","");
            value.Bday = dtStudentBday.Value;
            value.Gender = rbStudentFemale.Checked ? rbStudentFemale.Text : rbStudentMale.Text;
            value.RFIDNo = txtStudentRFIDNo.Text;//.Remove(8);
            value.Course = cmbStudentCourse.Text;
            value.Address = txtStudentAddress.Text;
            value.CompletedStatus = cbCompleted.Checked;
            value.GraduateStatus = cbGraduated.Checked;
            value.EnrolledStatus = cbEnrolled.Checked;
            value.RFIDStatus = cbRFIDstd.Checked;
            value.ContactNoStatus = cbContactNoStd.Checked;
            value.Active = cbActiveStd.Checked;
            value.DateRegistered = UserDetail.CurrDate();
            value.DisplayName = txtStudentFirstName.Text;
            value.YearLevel = cmbYearLevel.Text;
            return value;
        }

        private T_ParenstInfo SetupParentInfo(bool IsDelete)
        {
            T_ParenstInfo value = new T_ParenstInfo();
            value.StudentID = txtStudentID.Text; 
            value.ID=isAdd?0: ParentsID;
            value.DadAddress = txtFatherAddress.Text;
            value.DadCivilStatus = cmbFatherCivilStatus.Text;
            value.DadContactNo = txtFatherContactNo.Text.Replace("-", "");
            value.DadFistName = txtFatherFirstName.Text;
            value.DadLastName = txtFatherLastName.Text;
            value.DadMiddleName = txtFatherMiddleName.Text;
            value.DadRFIDNo = txtFatherRFIDNo.Text;
            value.FRFIDNo = cbRFIDDads.Checked;
            value.FContactNo = cbContactDads.Checked;
            value.FActive = cbActiveDads.Checked;

            value.MomLastName = txtMotherLastName.Text;
            value.MomFirstName = txtMotherFirstName.Text;
            value.MomMiddleName = txtMotherMiddleName.Text;
            value.MomContactNo = txtMotherContactNo.Text.Replace("-", "");
            value.MomRFIDNo = txtMotherRFIDNo.Text;
            value.MomCivilStatus = cmbMotherCivilStatus.Text;
            value.MomAddress = txtMotherAddress.Text;
            value.MRFIDNo = cbRFIDMoms.Checked;
            value.MContactNo = cbContactMoms.Checked;
            value.MActive = cbActiveMoms.Checked;
            if (IsDelete)
                value.ID = ParentsID;
            return value;
        }

        void ComSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {               
                Disp = ComSerial.ReadLine().Replace("\r",string.Empty);
                this.Invoke(new EventHandler(_dis));                
            }
            catch (Exception ex)
            {
               
            }
        }

        private void _dis(object sender, EventArgs e)
        {

            //getCard.Add(Disp);
            //if (!string.IsNullOrWhiteSpace(txtStudentRFIDNo.Text))
            //{
            //    txtStudentRFIDNo.Text = getCard.LastOrDefault().ToString().Replace(" ", "");
            //    //txtStudentRFIDNo.Text = txtStudentRFIDNo.Text.Remove(8);
                
            //}
            getCard.Add(Disp);

            txtStudentRFIDNo.Text = getCard.LastOrDefault();//.ToString();//.Replace(" ", "");
            //txtStudentRFIDNo.Text = txtStudentRFIDNo.Text.Replace(" ","").Remove(8);
            
        }

        void AutoScanTimer_Tick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtStudentRFIDNo.Text))
                AutoScan();
        
        }

        void AutoScan()
        {
            try
            {
                ComSerial.ReadTimeout = 100;
                //ComPortList = SerialPort.GetPortNames();

                //foreach (string port in ComPortList)
                //{
                //    ComSerial.PortName = port.ToString();
                //}

                ComSerial.PortName = SerialPort.GetPortNames().LastOrDefault();

                //Comport = ComSerial.PortName;
                
                //GetRoomAssignment(ComSerial.PortName);
                ComSerial.BaudRate = 9600;
                ComSerial.DataBits = 8;
                ComSerial.Parity = Parity.None;
                ComSerial.StopBits = StopBits.One;

                ComSerial.Close();
                ComSerial.Open();
                ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived);
            }
            catch (Exception ex)
            {
                ComSerial.Close();
            }
        
        }

        private bool CheckRFIDNo()
        {
            using (Students std = new Students())
            {
                //return std.GetStudentInfo().Where(x=> x.RFIDNo == txtStudentRFIDNo.Text).FirstOrDefault()==null?true:false;
                return std.GetStudentInfo().Where(x=> x.RFIDNo == txtStudentRFIDNo.Text).Any();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            ObjEnable(false);
            Delete();
            MsgReturned = "";
            SystemProperties.Cleared(this, false, true, true);
            SystemProperties.Cleared(Mother, false, true, true);
            SystemProperties.Cleared(Father, false, true, true);
            txtSearch.ReadOnly = false; 
           
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            Save();            
            MsgReturned = "";
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            LoadStudentInfo();
            SystemProperties.Cleared(this, false, true, true);
            SystemProperties.Cleared(Mother, false, true, true);
            SystemProperties.Cleared(Father, false, true, true);

            MsgReturned = "";
           
            txtSearch.ReadOnly = false;
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            isAdd = false;
            SystemProperties.Cleared(this, true, false, false);
            SystemProperties.Cleared(Mother, true, false, false);
            SystemProperties.Cleared(Father, true, false, false);
            MsgReturned = "";
            AutoScanTimer.Start();
            txtSearch.ReadOnly = false; 
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            isAdd = true;
            SystemProperties.Cleared(this, true, true, true);
            SystemProperties.Cleared(Mother,  true, true, true);
            SystemProperties.Cleared(Father,  true, true, true);
            MsgReturned = "";
            AutoScanTimer.Start();
            txtSearch.ReadOnly = false; 
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {

        }

       
    }
}
