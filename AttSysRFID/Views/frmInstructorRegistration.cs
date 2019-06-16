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
using System.IO;
namespace AttSysRFID.Views
{
    public partial class frmInstructorRegistration : Form
    {
        public frmInstructorRegistration()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string StudentFileImage;
        private string MsgReturned = "";
        private bool isAdd;
        void SetProperties()
        {
            LoadInstructor();
            ObjEnable(false);
            SystemProperties.Cleared(this, false, true, true);
            txtSearch.ReadOnly = false;
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgEmployeeRecord.CellClick += new DataGridViewCellEventHandler(dgEmployeeRecord_CellClick);
            picInstructor.Click+=new EventHandler(picInstructor_Click);
            txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            btnSearch.Click += new EventHandler(btnSearch_Click);
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadInstructor(txtSearch.Text);
            else
                SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + " for search box", "Student registration");
        }

        void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadInstructor(txtSearch.Text);
        }
        void picInstructor_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Image File(*.bmp;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFile.FileName = "Student image";
            if (openFile.ShowDialog() != DialogResult.Cancel)
            {
                picInstructor.Image = Image.FromFile(openFile.FileName);
                StudentFileImage = openFile.FileName;
            }
        }        

        void dgEmployeeRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadSelectedOne(Convert.ToInt64(dgEmployeeRecord.SelectedRows[0].Cells[0].Value.ToString()));
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
            LoadInstructor();
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

        void LoadSelectedOne(long ID)
        {
            if (dgEmployeeRecord.Rows.Count > 0)
            {
                using (Instructor prof = new Instructor())
                {
                    var value = prof.GetInstructor().Where(x => x.ID == ID).FirstOrDefault();
                    if (value != null)
                    {
                        txtEmployeeAddress.Text = value.Address;
                        txtEmployeeFirstName.Text = value.FirstName;
                        txtEmployeeID.Text = value.EmployeeID;
                        txtEmployeeLastName.Text = value.LastName;
                        txtEmployeeMiddleName.Text = value.MiddleName;
                        txtInstructorContactNo.Text = value.ContactNo;
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                        btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                        if (value.Gender.ToLower() == "male")
                        {
                            rbEmployeeMale.Checked = true;
                            rbEmployeeFemale.Checked = false;
                        }
                        else
                        {

                            rbEmployeeMale.Checked = false;
                            rbEmployeeFemale.Checked = true;
                        }
                        SaveImage(false);
                    }
                }
            }
        }
        void DeleteImage()
        {
            string pathDirection = "";
            string ImageName = "";
            pathDirection = SystemProperties.ReadInstructorImage();

            ImageName = string.Format("{0}{1}-{2}", txtEmployeeLastName.Text, txtEmployeeFirstName.Text, txtEmployeeID.Text);
            //picStudent.Image.d(@"" + pathDirection + ImageName + ".png");
            File.Delete(string.Format("{0}{1}", pathDirection, ImageName));

        }
        void SaveImage(bool IsSave)
        {
            string pathDirection = "";
            string ImageName = "";
            pathDirection = SystemProperties.ReadInstructorImage();

            ImageName = string.Format("{0}{1}-{2}", txtEmployeeLastName.Text, txtEmployeeFirstName.Text, txtEmployeeID.Text);
            if (IsSave)
                
                picInstructor.Image.Save(@"" + pathDirection + ImageName + ".png");
            else
                picInstructor.Image = Image.FromFile(pathDirection + ImageName + ".png");
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Instructor registration") == DialogResult.Yes)
            {
                if (checkEmpty())
                {
                    using (Instructor prof = new Instructor())
                    {

                        prof.Save(SetInstructor(false), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Instructor registration");
                        SaveImage(true);
                        SystemProperties.Cleared(this, false, true, true);
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Employee ID"+Environment.NewLine+"Name"+Environment.NewLine+"Profile picture", "Instructor registration");
                }
            }
            LoadInstructor();
            txtSearch.ReadOnly = false;
        }
        private T_InstructorInformation SetInstructor(bool isDelete)
        {
            T_InstructorInformation valueRet = new T_InstructorInformation();
            valueRet.ID = isAdd ? 0 : Convert.ToInt64(dgEmployeeRecord.SelectedRows[0].Cells[0].Value.ToString());
            valueRet.Address = txtEmployeeAddress.Text;
            valueRet.BDay = dtEmployeeBday.Value;
            valueRet.ContactNo = txtInstructorContactNo.Text;
            valueRet.EmployeeID = txtEmployeeID.Text;
            valueRet.FirstName = txtEmployeeFirstName.Text;
            valueRet.LastName = txtEmployeeLastName.Text;
            valueRet.MiddleName = txtEmployeeMiddleName.Text;
            valueRet.Gender = rbEmployeeFemale.Checked ? rbEmployeeFemale.Text : rbEmployeeMale.Text;
            if(isDelete)
                valueRet.ID= Convert.ToInt64(dgEmployeeRecord.SelectedRows[0].Cells[0].Value.ToString());
            return valueRet;
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Instructor registration") == DialogResult.Yes)
            {
                if (checkEmpty())
                {

                    using (Instructor prof = new Instructor())
                    {

                        DeleteImage();
                        prof.Delete(SetInstructor(true), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Instructor registration");
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Instructor registration");

                }
            }
            LoadInstructor();            
            txtSearch.ReadOnly = false;
        }

        bool checkEmpty()
        {
            return (!string.IsNullOrWhiteSpace(txtEmployeeID.Text) && !string.IsNullOrWhiteSpace(txtEmployeeLastName.Text) && !string.IsNullOrWhiteSpace(txtEmployeeFirstName.Text) && picInstructor.Image!=null) ? true : false;
        }
        void ObjEnable(bool enable)
        {
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, false, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
            btnSearch = SystemProperties.BtnProperties(btnSearch, true, Imagename.Search.ToString(), Imagename.Search.ToString());
        }
        void LoadInstructor(string search)
        {
            dgEmployeeRecord.Rows.Clear();
            int i = 1;
            using (Instructor prof = new Instructor())
            {
                var value=prof.GetInstructor().Where(x=> x.EmployeeID==search || x.LastName==search || x.FirstName==search).OrderBy(o=> o.LastName).ToList();
                value.ForEach(x =>
                {
                    dgEmployeeRecord.Rows.Add(x.ID, i, x.EmployeeID, x.LastName + ", " + x.FirstName);
                    i++;
                });
                if (value.Count == 1)
                    LoadSelectedOne(value.FirstOrDefault().ID);

                else
                {
                    SystemProperties.ShowMessage.MessageError("Record are not found", "Instructor registration");
                    LoadInstructor();
                }
            }
             
            ObjEnable(false);
            dgEmployeeRecord.Enabled = true;
            txtSearch.ReadOnly = false;
        }
        void LoadInstructor()
        {
            dgEmployeeRecord.Rows.Clear();
            int i = 1;
            using (Instructor prof = new Instructor())
            {
                prof.GetInstructor().ForEach(x => 
                {
                    dgEmployeeRecord.Rows.Add(x.ID,i,x.EmployeeID,x.LastName+", "+x.FirstName);
                    i++;
                });
            }

            ObjEnable(false);
            dgEmployeeRecord.Enabled = true;
            txtSearch.ReadOnly = false;
        }
    }
}
