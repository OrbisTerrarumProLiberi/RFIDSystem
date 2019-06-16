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
using AttSysRFID.Views;
namespace AttSysRFID.Views.Maintenanceform
{
    public partial class frmPositionAccessRight : Form
    {
        public frmPositionAccessRight()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private bool isAdd;
        private bool isCancel;
        private string MsgReturned;
        void SetHandler()
        {
            //this.Load += new EventHandler(frmUserRegistration_Load);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgAccessRightPositionRecord.Click += new EventHandler(dgAccessRightPositionRecord_Click);
            txtPositionID.Leave += new EventHandler(txtPositionID_Leave);
            txtPositionID.TextChanged += new EventHandler(txtPositionID_TextChanged);
        }

        void txtPositionID_TextChanged(object sender, EventArgs e)
        {
           
        }

        void txtPositionID_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPositionID.Text) && isAdd)
            {
                if (GetAccessRight(txtPositionID.Text))
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.Exist, "Position access right");
                    btnSave = SystemProperties.BtnProperties(btnSave, false, Imagename.Save.ToString(), Imagename._save.ToString());
                }
                else
                {
                    btnSave = SystemProperties.BtnProperties(btnSave, true, Imagename.Save.ToString(), Imagename._save.ToString());
                }
            }
        }

        void SetProperties()
        {
            ObjEnable(false);
            Cleared(this,false);
            GetAccessRight();
        }
        void Cleared(Control me, bool enable)
        {
            foreach (Control ctr in me.Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)ctr;
                    txt.ReadOnly = !enable;
                    txt.Text = isAdd ? "" : txt.Text;
                    if (isCancel)
                        txt.Text = "";
                }
                else if (ctr.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Enabled = enable;
                    chk.Checked = isAdd? false:chk.Checked;
                    if (isCancel)
                        chk.Checked = false;
                }
                else if (ctr.GetType() == typeof(DataGridView)) 
                {
                    DataGridView dg = (DataGridView)ctr;
                    dg.Enabled = !enable;
                }
                else if (ctr.GetType() == typeof(Panel) || ctr.GetType() == typeof(GroupBox))
                {
                    Cleared(ctr, enable);
                }
            }

        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
            //dgAccessRightPositionRecord.Enabled = !enable;
        }
        bool GetAccessRight(string text)
        {
            int i = 1;
            dgAccessRightPositionRecord.Rows.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                var value= _maintain.GetAccessRight().Where(x=> x.PositionID==text).OrderBy(o => o.JobTitle).ToList();
                if (value.Count > 0)
                {
                    value.ForEach(x =>
                    {
                        dgAccessRightPositionRecord.Rows.Add(x.ID, i, x.PositionID, x.JobTitle, x.Description, x.Active);
                        i++;
                    });
                    return true;
                }
                else
                    return false;

            }

            isCancel = true;
            ObjEnable(false);
            Cleared(this, false);
            MsgReturned = "";
        }
        void GetAccessRight()
        {
            int i = 1;
            dgAccessRightPositionRecord.Rows.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetAccessRight().OrderBy(o => o.JobTitle).ToList().ForEach(x =>
                {
                    dgAccessRightPositionRecord.Rows.Add(x.ID, i, x.PositionID, x.JobTitle, x.Description, x.Active);
                    i++;
                });
            }

            isCancel = true;
            ObjEnable(false);
            Cleared(this, false);
            MsgReturned = "";
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Position access right") == DialogResult.Yes)
            {
                if (CheckEmpty())
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetAccessRights(), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation( MsgReturned, "Position access right");
                    }
                    GetAccessRight();
                }
                else
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput +Environment.NewLine+Environment.NewLine+"Position ID and Job Title", "Position access right");
            }

        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Position access right") == DialogResult.Yes && dgAccessRightPositionRecord.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = SetAccessRights();
                    value.ID = Convert.ToInt64(dgAccessRightPositionRecord.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        if (CheckAlreadyUser(value.PositionID))
                        {
                            _maintain.Delete(value, ref MsgReturned);
                            SystemProperties.ShowMessage.MessageInformation( MsgReturned, "Position access right");
                            GetAccessRight();
                        }
                        else
                        {
                            SystemProperties.ShowMessage.MessageInformation(SystemProperties.MessageNotification.AlreadyUsed, "Position access right");
                            
                        }
                    }
                   
                }
            }           
            
        }
        public bool CheckEmpty()
        {

            if (!string.IsNullOrWhiteSpace(txtJobTitle.Text) && !string.IsNullOrWhiteSpace(txtPositionID.Text))
                return true ;
            else
                return false ;
                        
        }
        public bool CheckAlreadyUser(string value)
        {
            using (Maintenance _maintain = new Maintenance())
            {
               return _maintain.GetSystemUser().Where(x => x.PositionID == value).FirstOrDefault() == null ? true : false;
            }
        }
        void dgAccessRightPositionRecord_Click(object sender, EventArgs e)
        {
            using (Maintenance _maintain = new Maintenance())
            {
                var value = _maintain.GetAccessRight().Where(x => x.ID == Convert.ToInt64(dgAccessRightPositionRecord.SelectedRows[0].Cells[0].Value.ToString())).FirstOrDefault();
                if (value != null)
                {
                    txtPositionID.Text = value.PositionID;
                    txtJobTitle.Text = value.JobTitle;
                    txtDescription.Text = value.Description;
                    cbActive.Checked = value.Active.Value;

                    cbReg_Student.Checked = value.Student.Value;
                    cbReg_Instructor.Checked = value.Instructor.Value;
                    cbMain_Position.Checked = value.Position.Value;
                    cbMain_User.Checked = value.Users.Value;
                    cbMain_YearLevel.Checked = value.YearLevel.Value;
                    cbMain_CivilStatus.Checked = value.CivilStatus.Value;
                    cbMain_Course.Checked = value.Course.Value;
                    cbMain_Subject.Checked = value.Subject.Value;
                    cbMain_Room.Checked = value.Room.Value;
                    cbMain_Time.Checked = value.Time.Value;
                    cbMain_Application.Checked = value.Application.Value;
                    cbWin_Display.Checked = value.Display.Value;
                    cbWin_Report.Checked = value.Display.Value;
                    cbSett_DeviceConfig.Checked = value.DeviceConfiguration.Value;
                    cbRoomType.Checked = value.RoomType.Value;
                    cbBuilding.Checked = value.Building.Value;
                    cbViewRoom.Checked = value.ViewRoom.Value;
                    cbViewCourse.Checked= value.ViewCourse.Value;
                    cbViewInstructor.Checked = value.ViewInstructor.Value;
                    cbMessage.Checked = value.MaintenanceMessage.Value;
                    cbStudent.Checked=value.NotifyStudent.Value;
                    cbSMSSettings.Checked=value.SMSSettings.Value;
                    cbSemester.Checked = value.Semester.Value;
                    cbYearClass.Checked = value.YearClass.Value;
                    btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                    btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());

                }
            }
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgAccessRightPositionRecord.Rows.Count>0)
                Delete();
        }      
        void btnSave_Click(object sender, EventArgs e)
        {
            isCancel = false;
            Save();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {

            MsgReturned = "";
            isCancel = true;
            ObjEnable(false);
            Cleared(this, false);
            GetAccessRight();
        }
        void btnEdit_Click(object sender, EventArgs e)
        {
            isCancel = false;
            ObjEnable(true);
            isAdd = false;
            Cleared(this,true);
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            isCancel = false ;
            ObjEnable(true);
            btnDelete = SystemProperties.BtnProperties(btnDelete, false, Imagename.Delete.ToString(), Imagename._delete.ToString());
            isAdd = true;
            Cleared(this, true);
        }

        private T_AccessRight SetAccessRights()
        {
            T_AccessRight value = new T_AccessRight();
            value.ID = isAdd ? 0 : Convert.ToInt64(dgAccessRightPositionRecord.SelectedRows[0].Cells[0].Value);
            value.JobTitle = txtJobTitle.Text;
            value.Description = txtDescription.Text;
            value.Student = cbReg_Student.Checked;
            value.Instructor = cbReg_Instructor.Checked;
            value.Position = cbMain_Position.Checked;
            value.Users = cbMain_User.Checked;
            value.YearLevel = cbMain_YearLevel.Checked;
            value.CivilStatus = cbMain_CivilStatus.Checked;
            value.Application = cbMain_Application.Checked;
            value.Course = cbMain_Course.Checked;
            value.Subject = cbMain_Subject.Checked;
            value.Room = cbMain_Room.Checked;
            value.Time = cbMain_Time.Checked;
            value.Display = cbWin_Display.Checked;
            value.Report = cbWin_Report.Checked;
            value.DeviceConfiguration = cbSett_DeviceConfig.Checked;
            value.Active = cbActive.Checked;
            value.PositionID = txtPositionID.Text;
            value.RoomType = cbRoomType.Checked;
            value.Building = cbBuilding.Checked;

            value.ViewRoom = cbViewRoom.Checked;
            value.ViewCourse = cbViewCourse.Checked;
            value.ViewInstructor = cbViewInstructor.Checked;
            value.MaintenanceMessage = cbMessage.Checked;
            value.NotifyStudent = cbStudent.Checked;
            value.SMSSettings = cbSMSSettings.Checked;

            value.Semester = cbSemester.Checked;
            value.YearClass = cbYearClass.Checked;
            return value;
        }

    }
}


