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
    public partial class frmCivilStatus : Form
    {
        public frmCivilStatus()
        {
            InitializeComponent();
            Sethanlder();
            SetProperties();
        }
        private string MsgReturned;
        private bool isAdd;
        void SetProperties()
        {
            ObjEnable(false);
            GetCivilStatus();
            SystemProperties.Cleared(this, false, true, true);
        }
        void Sethanlder()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgCivilStatus.CellClick += new DataGridViewCellEventHandler(dgCivilStatus_CellClick);   
        }

        void dgCivilStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Maintenance _maintain = new Maintenance())
            {
                var value= _maintain.GetCivilStatus().Where(x => x.ID == Convert.ToInt64(dgCivilStatus.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                if (value != null)
                {
                    txtCivilStatus.Text = value.Status;
                    cbActive.Checked = value.Active.Value;
                    btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                    btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                }
            }
        }
        public T_CivilStatus SetCivilStatus()
        {
            T_CivilStatus value = new T_CivilStatus();
            value.ID = isAdd ? 0 : Convert.ToInt64(dgCivilStatus.SelectedRows[0].Cells[0].Value.ToString());
            value.Status = txtCivilStatus.Text;
            value.Active = cbActive.Checked;
            return value;
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Civil status") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtCivilStatus.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetCivilStatus(), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Civil status");
                        SystemProperties.Cleared(this, false, true, true);
                        GetCivilStatus();         
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine +  "Civil status", "Civil status");
                }
            }
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Civil status") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtCivilStatus.Text))
                {
                    var value = SetCivilStatus();
                    value.ID=Convert.ToInt64(dgCivilStatus.SelectedRows[0].Cells[0].Value.ToString());
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Civil status");
                        GetCivilStatus();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Civil status");
                
                }
            }
        }
        void GetCivilStatus()
        {
            dgCivilStatus.Rows.Clear();
            int i = 1;
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetCivilStatus().ForEach(x => 
                {
                    dgCivilStatus.Rows.Add(x.ID,i, x.Status, x.Active);
                    i++;
                });
            }
            ObjEnable(false);
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
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
            GetCivilStatus();
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
