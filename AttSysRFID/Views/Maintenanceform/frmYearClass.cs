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
namespace AttSysRFID.Views.Maintenanceform
{
    public partial class frmYearClass : Form
    {
        private bool isAdd;
        private string MsgReturned;
       
        public frmYearClass()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            LoadSemester();
            ObjEnable(false);
            GetYearClass();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgYearClass.CellClick += new DataGridViewCellEventHandler(dgYearClass_CellClick);
            cmbSemester.KeyDown += new KeyEventHandler(cmbSemester_KeyDown);
            cmbSemester.KeyPress += new KeyPressEventHandler(cmbSemester_KeyPress);
        }

        void cmbSemester_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }

        void cmbSemester_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void GetYearClass()
        {
            int i = 1;
            dgYearClass.Rows.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetActiveSemester().OrderBy(o => o.Semester).ToList().ForEach(x =>
                {
                    dgYearClass.Rows.Add(x.ID, i, x.YearSemester,x.Semester,x.DateStart,x.DateEnd, x.Active);
                    i++;
                });
            }
            ObjEnable(false);

        }
        void LoadSemester()
        {
            cmbSemester.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetSemester().OrderBy(o=> o.Semester).ToList().ForEach(x => 
                {
                    cmbSemester.Items.Add(x.Semester);
                });
            }
        }
        private T_ActiveSemester SetSemester()
        {
            T_ActiveSemester valueRet = new T_ActiveSemester();
            valueRet.ID = isAdd ? 0 : Convert.ToInt64(dgYearClass.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.DateEnd = dtDateEnd.Value;
            valueRet.DateStart = dtDateStart.Value;
            valueRet.Semester = cmbSemester.Text;
            valueRet.YearSemester = txtYearClass.Text;
            valueRet.Active = CheckActiveSemester()>=1?false: cbActive.Checked;
            return valueRet;
        }
        private bool CheckEmptyField()
        {
            if (!string.IsNullOrWhiteSpace(cmbSemester.Text) && !string.IsNullOrWhiteSpace(txtYearClass.Text))
                return true;
            else
                return false;
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Year class") == DialogResult.Yes && dgYearClass.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = SetSemester();
                    value.ID = Convert.ToInt64(dgYearClass.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Year class");
                        GetYearClass();
                    }

                }
            }
        }        
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Year class") == DialogResult.Yes)
            {
                if (CheckEmptyField())
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetSemester(), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Year class");
                        SystemProperties.Cleared(this, false, true, true);
                        GetYearClass();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Semester" + Environment.NewLine + "Year class", "Year class");
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
        }
        private int CheckActiveSemester()
        {
            using (Maintenance maintain = new Maintenance())
            {
                return maintain.GetActiveSemester().Where(x => x.Active == true).ToList().Count;
            }
        }
        void dgYearClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgYearClass.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetActiveSemester().Where(x => x.ID == Convert.ToInt64(dgYearClass.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        txtYearClass.Text = value.YearSemester;
                        dtDateStart.Value = value.DateStart.Value;
                        dtDateEnd.Value = value.DateEnd.Value;
                        cmbSemester.Text = value.Semester;
                        cbActive.Checked = value.Active.Value;
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                        btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                    }
                }
            }

        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
            GetYearClass();
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

    }
}
