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
    public partial class frmSubject : Form
    {
        private bool isAdd;
        private string MsgReturned;
        public frmSubject()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            ObjEnable(false);
            LoadSubject();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgSubject.CellClick += new DataGridViewCellEventHandler(dgSubject_CellClick);
        }

        void dgSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSubject.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetSubject().Where(x => x.ID == Convert.ToInt64(dgSubject.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        txtCode.Text = value.Code;                        
                        txtDescription.Text = value.Description;
                        txtUnit.Value =Convert.ToDecimal(value.Unit.ToString());
                        cbActive.Checked = value.Active.Value;
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());

                    }
                }
            }
          
        }
        
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                Delete();
            else
                SystemProperties.ShowMessage.MessageError("Empty record", "Subject");
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
            LoadSubject();
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

        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, !enable, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());

        }
        public T_Subject SetSubject()
        {
            T_Subject valueRet = new T_Subject();
            valueRet.ID=isAdd?0:Convert.ToInt64(dgSubject.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.Active = cbActive.Checked;
            valueRet.Code = txtCode.Text;
            valueRet.Unit = Convert.ToInt32(txtUnit.Value.ToString());
            valueRet.Description = txtDescription.Text;
            return valueRet;
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Subject") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetSubject(), ref MsgReturned);

                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Subject");
                        SystemProperties.Cleared(this, false, true, true);
                        LoadSubject();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Code" + Environment.NewLine + "Description", "Subject");
                }

            }
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "course") == DialogResult.Yes && dgSubject.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = SetSubject();
                    value.ID = Convert.ToInt64(dgSubject.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Subject");
                        LoadSubject();
                    }

                }
            }
        }
        void LoadSubject()
        {
            dgSubject.Rows.Clear();
            int i=1;

            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetSubject().ForEach(x =>
                {
                    dgSubject.Rows.Add(x.ID,i,x.Code,x.Description,x.Active); 
                        i++;
                });
            }

            ObjEnable(false);
        }

    }
}
