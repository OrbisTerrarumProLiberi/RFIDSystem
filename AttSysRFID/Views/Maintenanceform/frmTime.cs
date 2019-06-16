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
    public partial class frmTime : Form
    {
        public frmTime()
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
            LoadTime();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgTime.CellClick += new DataGridViewCellEventHandler(dgTime_CellClick);
        }
        void dgTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTime.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetTime().Where(x => x.ID == Convert.ToInt64(dgTime.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        dtStart.Value = value.TimeStart.Value;
                        dtEnd.Value = value.TimeEnd.Value;
                        txtCode.Text = value.TimeCode;
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
            LoadTime();
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
        void LoadTime()
        {
            dgTime.Rows.Clear();
            int i = 1;
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetTime().OrderBy(y => y.TimeCode).ToList().ForEach(x =>
                {
                    dgTime.Rows.Add(x.ID, i,x.TimeCode, x.TimeStart,x.TimeEnd, x.Active);
                    i++;
                });
            }
            ObjEnable(false);
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Time duration") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        T_Time value = new T_Time();
                        value.ID = isAdd ? 0 : Convert.ToInt64(dgTime.SelectedRows[0].Cells[0].Value.ToString());
                        value.TimeStart = Convert.ToDateTime(dtStart.Value.ToString());
                        value.TimeEnd = Convert.ToDateTime(dtEnd.Value.ToString());
                        value.TimeCode = txtCode.Text;
                        value.Active = cbActive.Checked;
                        _maintain.Save(value, ref MsgReturned);
                        LoadTime();
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Time duration");
                        SystemProperties.Cleared(this, false, true, true);
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Code", SystemProperties.MessageNotification.CheckInput), "Time duration");

                }

            }
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Time duration") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    T_Time value = new T_Time();
                    value.ID = Convert.ToInt64(dgTime.SelectedRows[0].Cells[0].Value.ToString());
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Time duration");
                        LoadTime();
                    }
                }
                else
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + "delete", "ime duration");        
           
               
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
