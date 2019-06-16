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
namespace AttSysRFID.Views.Maintenanceform
{
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private bool isAdd;
        private string MsgReturned;
       
        void SetProperties()
        {
            ObjEnable(false);
            LoadCourseProgram();
            LoadYearLevel();
            SystemProperties.Cleared(this, false, true, true);
            txtFromTo.ReadOnly = true;
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgCourseProgram.CellClick += new DataGridViewCellEventHandler(dgCourseProgram_CellClick);
            cmbMin.SelectedValueChanged += new EventHandler(cmbMin_SelectedValueChanged);
            cmbMax.SelectedValueChanged += new EventHandler(cmbMax_SelectedValueChanged);
            cmbMin.KeyPress += new KeyPressEventHandler(cmbMin_KeyPress);
            cmbMax.KeyPress += new KeyPressEventHandler(cmbMax_KeyPress);
            cmbMax.KeyDown += new KeyEventHandler(cmbMax_KeyDown);
            cmbMin.KeyDown += new KeyEventHandler(cmbMin_KeyDown);
        }

        void cmbMin_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbMax_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbMax_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbMin.Text) && !string.IsNullOrWhiteSpace(cmbMax.Text))
                txtFromTo.Text = GetYearLevelFromAndTo(Convert.ToInt32(cmbMin.Text), Convert.ToInt32(cmbMax.Text));
        
        }
        void cmbMin_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbMin.Text) && !string.IsNullOrWhiteSpace(cmbMax.Text))
                txtFromTo.Text = GetYearLevelFromAndTo(Convert.ToInt32(cmbMin.Text), Convert.ToInt32(cmbMax.Text));
        }    
        void dgCourseProgram_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgCourseProgram.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetCourse().Where(x => x.ID == Convert.ToInt64(dgCourseProgram.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {

                        cmbMin.Text = value.YearMinimum.Value.ToString();
                        cmbMax.Text = value.YearMaximum.Value.ToString();
                        txtFromTo.Text = value.YearLevelFromTo;
                        txtCode.Text = value.CourseCode;
                        txtCourse.Text = value.Description;                        
                        txtDescription.Text = value.Description;
                        cbActive.Checked = value.Active.Value;
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                        btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                    }
                }
            }
          
       
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtFromTo.Text) && !string.IsNullOrWhiteSpace(txtCourse.Text))
                Delete();
            else
                SystemProperties.ShowMessage.MessageError("Empty record","Course / progra");
            MsgReturned = "";
            SystemProperties.Cleared(this, false, true, true);
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            MsgReturned = "";
            Save();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            LoadCourseProgram();
            SystemProperties.Cleared(this, false, true, true);
            MsgReturned = "";

        }
        void btnEdit_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            isAdd = false;
            SystemProperties.Cleared(this, true, false, false);
            MsgReturned = "";
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            btnDelete = SystemProperties.BtnProperties(btnDelete, false, Imagename.Delete.ToString(), Imagename._delete.ToString());
            isAdd = true;
            SystemProperties.Cleared(this, true, true, true);
            MsgReturned = "";
        }
        private T_Course SetCourse()
        {
            T_Course valueRet = new T_Course();
            valueRet.ID = isAdd ? 0 : Convert.ToInt64(dgCourseProgram.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.YearMinimum = Convert.ToInt32(cmbMin.Text);
            valueRet.YearMaximum = Convert.ToInt32(cmbMax.Text);
            valueRet.Course = txtCourse.Text;
            valueRet.CourseCode = txtCode.Text;
            valueRet.YearLevelFromTo= txtFromTo.Text;
            valueRet.Description = txtDescription.Text;
            valueRet.Active = cbActive.Checked;
            return valueRet;
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "course") == DialogResult.Yes && dgCourseProgram.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = SetCourse();
                    value.ID = Convert.ToInt64(dgCourseProgram.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Course / Program");
                        LoadCourseProgram();
                    }

                }
            }
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Course / Program") == DialogResult.Yes)
            {
                if (CheckEmptyField() && CheckInvalidYearLevel(cmbMin.Text,cmbMax.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetCourse(), ref MsgReturned);

                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Course / Program");
                        SystemProperties.Cleared(this, false, true, true);
                        LoadCourseProgram();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Year level" + Environment.NewLine + "Course", "Course / Program");
                }

            }
        }
        void LoadCourseProgram()
        {
            dgCourseProgram.Rows.Clear();
            int i = 1;

            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetCourse().OrderBy(y => y.CourseCode).ToList().ForEach(x => 
                {
                    dgCourseProgram.Rows.Add(x.ID,i,x.CourseCode,x.Course,x.YearLevelFromTo,x.Active);
                    i++;
                });
            }
            
            ObjEnable(false);
            txtFromTo.ReadOnly = true;
        }
        void LoadYearLevel()
        {
            cmbMin.Items.Clear();
            cmbMax.Items.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetYearLevel().OrderBy(x => x.Count).ToList().ForEach(y =>
                {
                    cmbMin.Items.Add(y.Count);
                    cmbMax.Items.Add(y.Count);
                    cmbMin.SelectedIndex = 0;
                    cmbMax.SelectedIndex = 0;
                });
            }
        }
        private bool CheckInvalidYearLevel(string txt1,string txt2)
        {
            int i=0;
            int b = 0;
            i = Convert.ToInt32(txt1);
            b = Convert.ToInt32(txt2);
            return i > b ? false : true;
        }
        private bool CheckEmptyField()
        {
            if (!string.IsNullOrWhiteSpace(cmbMin.Text) && !string.IsNullOrWhiteSpace(cmbMax.Text) && !string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtCourse.Text)  )
                return true;
            else
                return false;
        }
        public string GetYearLevelFromAndTo(int yearMin,int yearMax)
        {
            using (Maintenance _maintain = new Maintenance())
            {
                var txtMin = _maintain.GetYearLevel().Where(x => x.Active == true && x.Count == yearMin).FirstOrDefault().YearLevel;
                string txtMax = _maintain.GetYearLevel().Where(x => x.Active == true && x.Count == yearMax).FirstOrDefault().YearLevel;
               return txtMin +" to " +txtMax;
            }
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
            txtFromTo.ReadOnly = true;
        }
        
       
    }
}
