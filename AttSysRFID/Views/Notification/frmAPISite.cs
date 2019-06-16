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
    public partial class frmAPISite : Form
    {
        public frmAPISite()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string MsgReturned = "";
        private bool isAdd;
        void SetProperties()
        {
            ObjEnable(false);
            LoadURLLink();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgSMS.CellClick += new DataGridViewCellEventHandler(dgSMS_CellClick);
        }

        void dgSMS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (GetAPI api = new GetAPI())
            {
                var value = api.GetAPIs().Where(x => x.ID == Convert.ToInt64(dgSMS.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                if (value != null)
                {
                    txtSite.Text = value.Site;
                    txtPage.Text = value.Page;
                    txtMobile.Text = value.ParamMobileName;
                    txtMessage.Text = value.ParamMessageName;
                    cbActive.Checked = value.Active.Value;
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
            LoadURLLink();
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
    

        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "API URL") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtSite.Text) && !string.IsNullOrWhiteSpace(txtPage.Text) && !string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtMobile.Text))
                {
                    using (GetAPI api = new GetAPI())
                    {

                        api.Save(SetupURLLink(false), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "API URL");
                        SystemProperties.Cleared(this, false, true, true);
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Page"+Environment.NewLine+"Site"+Environment.NewLine+"Mobile"+Environment.NewLine+"Message", "API URL");
                }
            }
            LoadURLLink();
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "API URL") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtSite.Text) && !string.IsNullOrWhiteSpace(txtPage.Text) && !string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtMobile.Text))
                {
                    using (GetAPI api = new GetAPI())
                    {
                        api.Delete(SetupURLLink(true), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "API URL");
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "API URL");

                }
            }
            LoadURLLink();
        }
        void LoadURLLink()
        {
            int i=1;
            dgSMS.Rows.Clear();
            using (GetAPI api = new GetAPI())
            {
                api.GetAPIs().ForEach(x => 
                {
                    dgSMS.Rows.Add(x.ID,i,x.Site,x.Page,x.ParamMobileName,x.ParamMessageName,x.Active);
                    i++;
                });
            }

            ObjEnable(false);
            dgSMS.Enabled = true;
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }

        public T_NotificationSetting SetupURLLink(bool isDelete)
        {
            T_NotificationSetting Notify = new T_NotificationSetting();
            Notify.ID=isAdd?0:Convert.ToInt64(dgSMS.SelectedRows[0].Cells[0].Value.ToString());
            Notify.Site = txtSite.Text;
            Notify.Page = txtPage.Text;
            Notify.ParamMessageName = txtMessage.Text;
            Notify.ParamMobileName = txtMobile.Text;
            Notify.Active = cbActive.Checked;
            if(isDelete)
                Notify.ID = Convert.ToInt64(dgSMS.SelectedRows[0].Cells[0].Value.ToString());
            return Notify;
        }
    }
}
