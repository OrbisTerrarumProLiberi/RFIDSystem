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
    public partial class frmApplication : Form
    {
        private bool isAdd;
        private string MsgReturned;
        public frmApplication()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            ObjEnable(false);
            GetApplication();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgApplication.CellClick += new DataGridViewCellEventHandler(dgApplication_CellClick);
        }

        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Application type") == DialogResult.Yes && dgApplication.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = SetApplication();
                    value.ID = Convert.ToInt64(dgApplication.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Application type");
                        GetApplication();
                    }

                }
            }    
        }
        private T_Application SetApplication()
        {
            T_Application valueRet = new T_Application();
            valueRet.ID=isAdd?0:Convert.ToInt64(dgApplication.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.Application = txtApplication.Text;
            valueRet.Description = txtDescription.Text;
            valueRet.Active = cbActive.Checked;
            return valueRet;
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Application type") == DialogResult.Yes)
            {
                if (CheckEmptyField())
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetApplication(), ref MsgReturned);

                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Application type");
                        SystemProperties.Cleared(this, false, true, true);     
                        GetApplication();         
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Application type"+Environment.NewLine+ "Description","Application type");           
                }
                
            }
        }
        private bool CheckEmptyField()
        {
            if (!string.IsNullOrWhiteSpace(txtApplication.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                return true;
            else
                return false;
        }
        void GetApplication()
        {
            dgApplication.Rows.Clear();
            int i=1;
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetApplication().ForEach(x => 
                {
                    dgApplication.Rows.Add(x.ID,i,x.Application,x.Description,x.Active);
                    i++;
                });
            }

            ObjEnable(false);
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, !enable, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }
        void dgApplication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgApplication.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetApplication().Where(x => x.ID == Convert.ToInt64(dgApplication.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        txtApplication.Text = value.Application;
                        txtDescription.Text = value.Description;
                        cbActive.Checked = value.Active.Value;
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());

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
            GetApplication();
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
            isAdd = true;
            SystemProperties.Cleared(this, true, true, true);
            MsgReturned = "";
        }
    }
}
