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
    public partial class frmYearLevel : Form
    {
        public frmYearLevel()
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
            LoadYearLevel();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgYearLevel.CellClick += new DataGridViewCellEventHandler(dgYearLevel_CellClick);
        }
        void dgYearLevel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Maintenance _maintain = new Maintenance())
            {
                var value = _maintain.GetYearLevel().Where(x => x.ID == Convert.ToInt64(dgYearLevel.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                if (value != null)
                {
                    txtYearLevel.Text = value.YearLevel;
                    cbActive.Checked = value.Active.Value;
                    txtCount.Value = value.Count.Value;
                    btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                }
            }
        }
        void LoadYearLevel()
        {
           dgYearLevel.Rows.Clear();
           int i = 1;
           using (Maintenance _maintain = new Maintenance())
           {
               _maintain.GetYearLevel().OrderBy(y => y.YearLevel).ToList().ForEach(x =>
               {
                   dgYearLevel.Rows.Add(x.ID, i, x.YearLevel, x.Count, x.Active);
                   i++;
               });
           }
           ObjEnable(false);
           dgYearLevel.Enabled = true;
        }        
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Year level") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtYearLevel.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        T_YearLevel value = new T_YearLevel();
                        value.ID = isAdd ? 0 : Convert.ToInt64(dgYearLevel.SelectedRows[0].Cells[0].Value.ToString());
                        value.YearLevel = txtYearLevel.Text;
                        value.Active = cbActive.Checked;
                        value.Count = Convert.ToInt32(txtCount.Value);
                        _maintain.Save(value, ref MsgReturned);
                        
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Year level");
                        SystemProperties.Cleared(this, false, true, true);
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Year level", "Year level");
                }
            } 
            LoadYearLevel();
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Year level") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtYearLevel.Text))
                {
                    T_YearLevel value =new T_YearLevel();
                    value.ID = Convert.ToInt64(dgYearLevel.SelectedRows[0].Cells[0].Value.ToString());
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Year level");
                        
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Year level");

                }
            }
            LoadYearLevel();
        }    
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, !enable, Imagename.Edit.ToString(), Imagename._edit.ToString());
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
            Save();
            MsgReturned = "";
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            LoadYearLevel();
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
