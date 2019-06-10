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
    public partial class frmUserRegistration : Form
    {
        public frmUserRegistration()
        {
            InitializeComponent();
            Sethandler();
            SetProperties();
        }
        private string MsgReturned;
        private string EncryptedPassword="";
        private bool isAdd;
        
        void Sethandler()
        {
            this.Load += new EventHandler(frmUserRegistration_Load);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            txtPassword.TextChanged += new EventHandler(txtPassword_TextChanged);
            cmbPositionID.KeyDown += new KeyEventHandler(cmbPositionID_KeyDown);
            cmbPositionID.KeyPress += new KeyPressEventHandler(cmbPositionID_KeyPress);
            cmbPositionID.SelectedValueChanged += new EventHandler(cmbPositionID_SelectedValueChanged);
            dgUserRecord.CellClick += new DataGridViewCellEventHandler(dgUserRecord_CellClick);
        }

        void dgUserRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgUserRecord.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetSystemUser().Where(x=> x.ID==Convert.ToInt64(dgUserRecord.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if(value!=null)
                    {
                        cmbPositionID.Text = value.PositionID;
                        txtUserID.Text = value.UserID;
                        txtJobTitle.Text = _maintain.GetAccessRight().Where(x => x.PositionID == value.PositionID).FirstOrDefault().JobTitle;
                        txtLastName.Text = value.LastName;
                        txtFirstName.Text = value.FirstName;
                        txtDisplayName.Text = value.DisplayName;
                        txtContactNo.Text = value.ContactNo;
                        dtStudentBday.Value = value.Bday.Value;
                        txtRFIDNo.Text = value.RFIDNo;
                        txtUserName.Text = value.Username;
                        txtPassword.Text = value.Password;
                        txtCoPassword.Text = value.Password;
                        cbActive.Checked = value.Active.Value;
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());

                    }
                }
            }
            
        }
        void cmbPositionID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbPositionID.Text))
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var jobtitle=_maintain.GetAccessRight().Where(x => x.PositionID == cmbPositionID.Text).FirstOrDefault();
                    txtJobTitle.Text = jobtitle.JobTitle;
                }
            }
        }       
        void SetProperties()
        {
            ObjEnable(false);
            GetUser();
            SystemProperties.Cleared(this, false, true, true);
        }             
        private bool ComparePassword(string Password,string CoPassowrd)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtCoPassword.Text))
                {
                    if (Password == CoPassowrd)
                    {

                        btnSave = SystemProperties.BtnProperties(btnSave, true, Imagename.Save.ToString(), Imagename._save.ToString());
                        lblMessage.ForeColor = Color.DimGray;
                        lblMessage.Text = "";
                        return true;
                    }
                    else
                    {

                        btnSave = SystemProperties.BtnProperties(btnSave, false, Imagename.Save.ToString(), Imagename._save.ToString());
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = SystemProperties.MessageNotification.PasswordNotMatch;
                        return false;
                    }
                }
                else
                {

                    btnSave = SystemProperties.BtnProperties(btnSave, false, Imagename.Save.ToString(), Imagename._save.ToString());
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = string.Format("{0} for Password or Co-Passoword", SystemProperties.MessageNotification.CheckInput);
                    
                    return false;
                }
            }
            else if (string.IsNullOrWhiteSpace(txtUserName.Text) && string.IsNullOrWhiteSpace(txtPassword.Text) && string.IsNullOrWhiteSpace(txtCoPassword.Text))
            {
                btnSave = SystemProperties.BtnProperties(btnSave, false, Imagename.Save.ToString(), Imagename._save.ToString());
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = string.Format("{0} for Username and Password or Co-Passoword", SystemProperties.MessageNotification.CheckInput);
                return false;  
            }
            else
            {
                btnSave = SystemProperties.BtnProperties(btnSave, false, Imagename.Save.ToString(), Imagename._save.ToString());
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = string.Format("{0} for Username", SystemProperties.MessageNotification.CheckInput);
                return false;
            }
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, !enable, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }
        
        void GetUser()
        {
            dgUserRecord.Rows.Clear();
            cmbPositionID.Items.Clear();
            int i=1;
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetSystemUser().OrderBy(o=> o.LastName).ToList().ForEach(x => 
                {
                    var yy= _maintain.GetAccessRight().Where(y=> y.PositionID==x.PositionID).FirstOrDefault();
                    dgUserRecord.Rows.Add(x.ID, i, x.UserID, string.Format("{0}, {1}", x.LastName, x.FirstName), yy.JobTitle, x.Active);
                        i++;
                }); 

                _maintain.GetAccessRight().OrderBy(o => o.PositionID).ToList().ForEach(x => 
                {
                    cmbPositionID.Items.Add(x.PositionID);
                });
            }
            ObjEnable(false);
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "User registration") == DialogResult.Yes)
            {
                if (CheckEmptyField())
                {
                    T_SystemUser user = new T_SystemUser();
                    user.ID = isAdd ? 0 : Convert.ToInt64(dgUserRecord.SelectedRows[0].Cells[0].Value.ToString());
                    user.UserID = txtUserID.Text;
                    user.Password = txtPassword.Text;
                    user.EncryptedPassword = EncryptedPassword;
                    user.DisplayName = txtDisplayName.Text;
                    user.LastName = txtLastName.Text;
                    user.FirstName = txtFirstName.Text;
                    user.PathImage = "";
                    user.Bday = dtStudentBday.Value;
                    user.ContactNo = txtContactNo.Text;
                    user.PositionID = cmbPositionID.Text;
                    user.Theme = "";
                    user.Active = cbActive.Checked;
                    user.Username = txtUserName.Text;
                    user.RFIDStatus = cbRFID.Checked;
                    user.RFIDNo = txtRFIDNo.Text;

                    using (Maintenance _maintain = new Maintenance())
                    {
                        _maintain.Save(user, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "User registration");
                        lblMessage.Text = "";
                    }
                    GetUser();
                    SystemProperties.Cleared(this, false, true, true);

                }
                else
                    SystemProperties.ShowMessage.MessageError(string.Format("{0}" + Environment.NewLine + Environment.NewLine + "POSITION ID" + Environment.NewLine + "USER ID" + Environment.NewLine + "LASTNAME" + Environment.NewLine + "FIRSTNAME" + Environment.NewLine + "USERNAME AND PASSWORD", SystemProperties.MessageNotification.CheckInput), "User registration");

            }
            
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "User registration") == DialogResult.Yes )
            {
                if (CheckEmptyField())
                {
                    T_SystemUser user = new T_SystemUser();
                    using (Maintenance _maintain = new Maintenance())
                    {
                        user.ID=Convert.ToInt64(dgUserRecord.SelectedRows[0].Cells[0].Value.ToString());
                        _maintain.Delete(user, ref MsgReturned);
                        SystemProperties.ShowMessage.MessageWarning(MsgReturned, "User registration");
                        GetUser();
                        SystemProperties.Cleared(this, false, true, true);
                        lblMessage.Text = "";
                    }
                }
                else
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + "delete", "User registration");        
            }
        }
        private bool CheckEmptyField()
        {
            if (!string.IsNullOrWhiteSpace(txtUserID.Text) && !string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(cmbPositionID.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text) && !string.IsNullOrWhiteSpace(txtFirstName.Text))
                return true;
            else
                return false;
        }
        void frmUserRegistration_Load(object sender, EventArgs e)
        {

        }
        void cmbPositionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbPositionID_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtPassword.Text))            
                EncryptedPassword = UserDetail.encrypt(txtPassword.Text);
            
            ComparePassword(txtPassword.Text, txtCoPassword.Text);
        }        
        void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            GetUser();
            SystemProperties.Cleared(this, false, true, true);
            txtJobTitle.ReadOnly = true;
            lblMessage.Text = "";
        }
        void btnEdit_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            isAdd = false;
            SystemProperties.Cleared(this, true, false, false);
            txtJobTitle.ReadOnly = true;
            lblMessage.Text = "";
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            isAdd = true;
            SystemProperties.Cleared(this, true, true, true);
            txtJobTitle.ReadOnly = true;
            lblMessage.Text = "";
        }
        
    }
}
