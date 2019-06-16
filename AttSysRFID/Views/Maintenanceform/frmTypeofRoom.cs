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
    public partial class frmTypeofRoom : Form
    {
        private bool isAdd;
        private string MsgReturned;
       
        public frmTypeofRoom()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            ObjEnable(false);
            GetRoomType();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgRoomType.CellClick += new DataGridViewCellEventHandler(dgRoomType_CellClick);
        }

        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }
        void dgRoomType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRoomType.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetRoomType().Where(x => x.ID == Convert.ToInt64(dgRoomType.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        txtCode.Text = value.Code;
                        txtRoomType.Text = value.Type;
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
            GetRoomType();
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

        void GetRoomType()
        {
            int i = 1;
            dgRoomType.Rows.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetRoomType().OrderBy(o => o.Code).ToList().ForEach(x => 
                {
                    dgRoomType.Rows.Add(x.ID, i, x.Code, x.Type,x.Active);
                    i++;                
                });
            }
            ObjEnable(false);

        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Room type") == DialogResult.Yes && dgRoomType.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = SetRoomType();
                    value.ID = Convert.ToInt64(dgRoomType.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Room type");
                        GetRoomType();
                    }

                }
            }
        }
        private T_Type SetRoomType()
        {
            T_Type valueRet = new T_Type();
            valueRet.ID = isAdd ? 0 : Convert.ToInt64(dgRoomType.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.Code = txtCode.Text;
            valueRet.Type = txtRoomType.Text;
            valueRet.Active = cbActive.Checked;
            return valueRet;
        }
        private bool CheckEmptyField()
        {
            if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtRoomType.Text))
                return true;
            else
                return false;
        }
     
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Room type") == DialogResult.Yes)
            {
                if (CheckEmptyField())
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(SetRoomType(), ref MsgReturned);

                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Room type");
                        SystemProperties.Cleared(this, false, true, true);
                        GetRoomType();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Code" + Environment.NewLine + "Room type", "Room type");
                }

            }
        }
      
    
    }
}
