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
    public partial class frmSemester : Form
    {
        public frmSemester()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string MsgReturned;
        private bool isAdd;
        void SetProperties()
        {
            ObjEnable(false);
            LoadSemester();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgSemester.CellClick += new DataGridViewCellEventHandler(dgSemester_CellClick);
        }
        void dgSemester_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Maintenance _maintain = new Maintenance())
            {
                var value = _maintain.GetSemester().Where(x => x.ID == Convert.ToInt64(dgSemester.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                if (value != null)
                {
                    txtSemester.Text = value.Semester;
                    btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                    btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
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
            Save();
            MsgReturned = "";
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            LoadSemester();
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
                     
        void LoadSemester()
        {
            dgSemester.Rows.Clear();
            int i = 1;
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetSemester().OrderBy(y => y.Semester).ToList().ForEach(x =>
                {
                    dgSemester.Rows.Add(x.ID, i,x.Semester);
                    i++;
                });
            }
            ObjEnable(false);
            dgSemester.Enabled = true;
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Semester") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtSemester.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        T_Semester value = new T_Semester();
                        value.ID = isAdd ? 0 : Convert.ToInt64(dgSemester.SelectedRows[0].Cells[0].Value.ToString());
                        value.Semester = txtSemester.Text;
                        _maintain.Save(value, ref MsgReturned);

                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Semester");
                        SystemProperties.Cleared(this, false, true, true);
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Semester", "Semester");
                }
            }
            LoadSemester();
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Semester") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtSemester.Text))
                {
                    T_Semester value = new T_Semester();
                    value.ID = Convert.ToInt64(dgSemester.SelectedRows[0].Cells[0].Value.ToString());
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Semester");

                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Semester");

                }
            }
            LoadSemester();
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }



    }
}
