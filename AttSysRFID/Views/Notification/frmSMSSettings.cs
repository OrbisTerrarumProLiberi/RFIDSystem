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
namespace AttSysRFID.Views.Notification
{
    public partial class frmSMSSettings : Form
    {
        public frmSMSSettings()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string MsgReturned;
        private bool isAdd;
        void SetProperties()
        {
            LoadSMS();
            ObjEnable(false);          
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnTest.Click += new EventHandler(btnTest_Click);
            dgSMS.CellClick += new DataGridViewCellEventHandler(dgSMS_CellClick);

        }

        void btnTest_Click(object sender, EventArgs e)
        {
            GetAPI.SendMessage(txtMessage.Text,txtContactNo.Text);
        }

        void dgSMS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSMS.Rows.Count > 0)
            {
                using (SMSNotification notify = new SMSNotification())
                {
                    var value = notify.GetSMS().Where(x => x.ID == Convert.ToInt64(dgSMS.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        txtCode.Text = value.Code;
                        txtMessage.Text = value.MessageAlert;
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
            LoadSMS();
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

        void LoadSMS()
        {
            int i=1;
            dgSMS.Rows.Clear();
            using (SMSNotification notify = new SMSNotification())
            {
                notify.GetSMS().ForEach(x =>
                {
                    dgSMS.Rows.Add(x.ID,i,x.Code,x.MessageAlert,x.Active);
                    i++;
                });
                ObjEnable(false);
            }
        }
        private T_Message SetRoomType()
        {
            T_Message valueRet = new T_Message();
            valueRet.ID = isAdd ? 0 : Convert.ToInt64(dgSMS.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.Code = txtCode.Text;
            valueRet.MessageAlert = txtMessage.Text;
            valueRet.Active = cbActive.Checked;
            return valueRet;
        }
        
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Message notification") == DialogResult.Yes && dgSMS.Rows.Count > 0)
            {
                using (SMSNotification notify = new SMSNotification())
                {
                    var value = SetRoomType();
                    value.ID = Convert.ToInt64(dgSMS.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        notify.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Message notification");
                        LoadSMS();
                    }

                }
            }
        }
        private bool CheckEmptyField()
        {
            if (!string.IsNullOrWhiteSpace(txtCode.Text) && !string.IsNullOrWhiteSpace(txtMessage.Text))
                return true;
            else
                return false;
        }
     
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Message notification") == DialogResult.Yes)
            {
                if (CheckEmptyField())
                {
                    using (SMSNotification notify = new SMSNotification())
                    {
                        notify.Save(SetRoomType(), ref MsgReturned);

                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Message notification");
                        SystemProperties.Cleared(this, false, true, true);
                        LoadSMS();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Code" + Environment.NewLine + "Message", "Message notification");
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
        
    }
}
