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
    public partial class frmBuilding : Form
    {
        private string MsgReturned = "";
        private bool isAdd;
      
        public frmBuilding()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }       
        void SetProperties()
        {
            ObjEnable(false);
            LoadBuiding();
            SystemProperties.Cleared(this, false, true, true);
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgBuilding.CellClick += new DataGridViewCellEventHandler(dgBuilding_CellClick);

        }


        void LoadBuiding()
        {
            dgBuilding.Rows.Clear();
            int i = 1;
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetBuildingCode().OrderBy(y => y.Branch).ToList().ForEach(x =>
                {
                    dgBuilding.Rows.Add(x.ID, i, x.Branch, x.BuildingCode,x.BuildingName, x.Active);
                    i++;
                });
            }
            ObjEnable(false);
            dgBuilding.Enabled = true;
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Branch building") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtBranch.Text) && !string.IsNullOrWhiteSpace(txtBuildingCode.Text) && !string.IsNullOrWhiteSpace(txtName.Text))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {
                        T_BranchBuilding value = new T_BranchBuilding();
                        value.ID = isAdd ? 0 : Convert.ToInt64(dgBuilding.SelectedRows[0].Cells[0].Value.ToString());
                        value.Branch = txtBranch.Text;
                        value.Active = cbActive.Checked;
                        value.BuildingCode = txtBuildingCode.Text;
                        value.BuildingName = txtName.Text;
                        _maintain.Save(value, ref MsgReturned);
                        
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Branch building");
                        SystemProperties.Cleared(this, false, true, true);
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Branch"+Environment.NewLine+"Code"+Environment.NewLine+"Name", "Branch building");
                }
            }
            LoadBuiding();

        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Branch building") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtBranch.Text) && !string.IsNullOrWhiteSpace(txtBuildingCode.Text) && !string.IsNullOrWhiteSpace(txtName.Text))
                {
                    T_BranchBuilding value = new T_BranchBuilding();
                    value.ID = Convert.ToInt64(dgBuilding.SelectedRows[0].Cells[0].Value.ToString());
                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Branch building");
                        
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Branch building");

                }
            }
            LoadBuiding();
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }


        void dgBuilding_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Maintenance _maintain = new Maintenance())
            {
                var value = _maintain.GetBuildingCode().Where(x => x.ID == Convert.ToInt64(dgBuilding.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                if (value != null)
                {
                    txtBranch.Text=value.Branch ;
                    cbActive.Checked= value.Active.Value;
                    txtBuildingCode.Text=value.BuildingCode;
                    txtName.Text=value.BuildingName ;
                    btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                    btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
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
            LoadBuiding();
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
