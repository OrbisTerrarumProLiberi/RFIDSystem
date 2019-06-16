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
    public partial class frmRoom : Form
    {
        public frmRoom()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        private string MsgReturned = "";
        private bool isAdd;
        private string COMSerial = "";
        private string DeviceName = "";
        void SetProperties()
        {
            ObjEnable(false);
            loadRoom();
            LoadTime();
            LoadType();
            GetBuildingCode();
            SystemProperties.Cleared(this, false, true, true);
            pnlDevice.Hide();
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgRoom.CellClick += new DataGridViewCellEventHandler(dgRoom_CellClick);
            dgTime.CellClick += new DataGridViewCellEventHandler(dgTime_CellClick);
            cmbBuildingCode.SelectedValueChanged += new EventHandler(cmbBuildingCode_SelectedValueChanged);
            cmbBuildingCode.KeyPress += new KeyPressEventHandler(cmbBuildingCode_KeyPress);
            cmbBuildingCode.KeyDown += new KeyEventHandler(cmbBuildingCode_KeyDown);
            cmbRoomType.KeyPress += new KeyPressEventHandler(cmbRoomType_KeyPress);
            cmbRoomType.KeyDown += new KeyEventHandler(cmbRoomType_KeyDown);
            btnDevice.Click += new EventHandler(btnDevice_Click);
            btnClose.Click += new EventHandler(btnClose_Click);
            dgDeviceRecord.CellClick += new DataGridViewCellEventHandler(dgDeviceRecord_CellClick);
        }

        void dgDeviceRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==1 && dgDeviceRecord.Rows.Count>0 )
            {
                COMSerial = dgDeviceRecord.SelectedRows[0].Cells[2].Value.ToString();
                DeviceName = dgDeviceRecord.SelectedRows[0].Cells[1].Value.ToString();
                txtDeviceDescription.Text = string.Format("{0}, {1}", DeviceName, COMSerial);
                pnlDevice.Hide();
            }
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            pnlDevice.Hide();
        }

        void btnDevice_Click(object sender, EventArgs e)
        {
            pnlDevice.Show();
            LoadDeviceAvailable();
        }

        void cmbRoomType_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbBuildingCode_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbBuildingCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbBuildingCode_SelectedValueChanged(object sender, EventArgs e)
        {
            using(Maintenance maintain=new Maintenance())
            {
                var value = maintain.GetBuildingCode().Where(x => x.Active == true && x.BuildingCode == cmbBuildingCode.Text).FirstOrDefault();
                if(value!=null)
                    txtLocationAddress.Text = value.BuildingName;              

            }
        }
        void dgTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dgTime.SelectedRows[0].Cells[3].Value = Convert.ToBoolean(dgTime.SelectedRows[0].Cells[3].Value)?false:true;
            }
        }
        void dgRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            SystemProperties.Cleared(this, false, true, true);

            if (dgRoom.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    var value = _maintain.GetRoom().Where(x => x.ID == Convert.ToInt64(dgRoom.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                    if (value != null)
                    {
                        cmbRoomType.Text = value.RoomType;
                        txtRoomCode.Text = value.RoomCode;
                        txtDescription.Text = value.Description;
                        cmbBuildingCode.Text = value.BuildingCode;
                        txtLocationAddress.Text= _maintain.GetBuildingCode().Where(x => x.BuildingCode == value.BuildingCode).FirstOrDefault().BuildingName;
                        txtCapacity.Value = value.Capacity.Value;
                        cbActive.Checked = value.Active.Value;
                        LoadTime(value.RoomCode);
                        btnDelete = SystemProperties.BtnProperties(btnDelete, true, Imagename.Delete.ToString(), Imagename._delete.ToString());
                        btnEdit = SystemProperties.BtnProperties(btnEdit, true, Imagename.Edit.ToString(), Imagename._edit.ToString());
                        GetRoomDevice(value.RoomCode);
                    }
                }
            }

        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRoomCode.Text) && !string.IsNullOrWhiteSpace(txtRoomCode.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                Delete();
            else
                SystemProperties.ShowMessage.MessageError("Empty text field", "Subject");
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
            loadRoom();
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
            //dgRoom.Enabled = true;
            dgTime.Enabled = true;
            txtDeviceDescription.ReadOnly = true;
            dgDeviceRecord.Enabled = true;

        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            ObjEnable(true);
            btnDelete = SystemProperties.BtnProperties(btnDelete, false, Imagename.Delete.ToString(), Imagename._delete.ToString());
            isAdd = true;
            SystemProperties.Cleared(this, true, true, true);
            MsgReturned = "";
            //dgRoom.Enabled = true;
            dgTime.Enabled = true;
            LoadTime();
            txtDeviceDescription.ReadOnly = true;
            dgDeviceRecord.Enabled = true;
        }
        void GetRoomDevice(string RoomCodes)
        {
            using (DeviceModule DM = new DeviceModule())
            {
                var value= DM.GetDeviceAvailable().Where(x => x.RoomCode == RoomCodes).FirstOrDefault();
                if (value != null)
                {
                    COMSerial = value.SerialPort;
                    DeviceName = value.DeviceName;
                    txtDeviceDescription.Text = value.DeviceCode;

                }
            }
        }
        void loadRoom()
        {
            int i = 1;
            dgRoom.Rows.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetRoom().OrderBy(o => o.RoomCode).ToList().ForEach(x => 
                {
                    dgRoom.Rows.Add(x.ID, i, x.RoomCode, x.Description, x.RoomType, x.BuildingCode, x.Capacity, x.Active);
                    i++;
                });
            }
            ObjEnable(false);
            dgTime.Enabled = false;
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Room") == DialogResult.Yes && dgRoom.Rows.Count > 0)
            {
                using (Maintenance _maintain = new Maintenance())
                {
                    T_Room value = new T_Room();
                    value.ID = Convert.ToInt64(dgRoom.SelectedRows[0].Cells[0].Value);
                    if (value != null)
                    {
                        _maintain.Delete(value, ref MsgReturned);
                        DeleteRoomDevice(value.RoomCode);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Room");
                        loadRoom();
                        LoadTime();
                        DeleteTime();
                    }

                }
            }
        }
        void DeleteRoomDevice(string RoomCodes)
        {
            T_RoomDevie RD = new T_RoomDevie();
            RD.RoomCode = RoomCodes;
            using (DeviceModule DM = new DeviceModule())
            {
                DM.Delete(RD);
            }
        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Room") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(cmbRoomType.Text) && !string.IsNullOrWhiteSpace(txtRoomCode.Text) &&!string.IsNullOrWhiteSpace(cmbBuildingCode.Text) && !string.IsNullOrWhiteSpace(txtCapacity.Value.ToString()))
                {
                    using (Maintenance _maintain = new Maintenance())
                    {

                        _maintain.Save(SetRoom(), ref MsgReturned);
                        SaveTime();
                        SaveRoomDevice();
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Room");
                        SystemProperties.Cleared(this, false, true, true);
                        loadRoom();
                        LoadTime();
                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Code" + Environment.NewLine + "Type" + Environment.NewLine + "Building Code" + Environment.NewLine + "Capacity", "Room");
                }

            }
        }
        void SaveRoomDevice()
        {
            T_RoomDevie RD=new T_RoomDevie();
            RD.RoomCode = txtRoomCode.Text;
            RD.RoomType = txtDescription.Text;
            RD.DeviceCode = txtDeviceDescription.Text;
            RD.DeviceName = DeviceName;
            RD.SerialPort = COMSerial;
            using (DeviceModule device = new DeviceModule())
            {
                if(device.Save(RD,ref MsgReturned))
                    SystemProperties.ShowMessage.MessageError(MsgReturned,"Room and device");
            }
        }
        void SaveTime()
        {
            T_RoomTime value = new T_RoomTime();
            using (Maintenance maintain = new Maintenance())
            {
                for (int i = 0; i <= dgTime.Rows.Count - 1; i++)
                {
                    value.ID = Convert.ToInt64(dgTime.Rows[0].Cells[0].Value.ToString());
                    value.RoomCode=txtRoomCode.Text;
                    value.Status=Convert.ToBoolean(dgTime.Rows[i].Cells[3].Value.ToString());
                    value.TimeCode=dgTime.Rows[i].Cells[4].Value.ToString();
                    maintain.Save(value);
                }
                    
            }
        }
        void DeleteTime()
        {
            using (Maintenance maintain = new Maintenance())
            {
                T_RoomTime value=new T_RoomTime();
                value.RoomCode=txtRoomCode.Text;
                maintain.Delete(value);
            }
        }
        public T_Room SetRoom()
        {
            T_Room valueret = new T_Room();

            valueret.ID=isAdd?0:Convert.ToInt64(dgRoom.SelectedRows[0].Cells[0].Value.ToString());
            valueret.RoomCode = txtRoomCode.Text;
            valueret.RoomType = cmbRoomType.Text;
            valueret.Description = txtDescription.Text;
            valueret .Capacity=Convert.ToInt32(txtCapacity.Value.ToString());
            valueret.Active=cbActive.Checked;
            valueret.BuildingCode=cmbBuildingCode.Text;
            return valueret;

        }
        void GetBuildingCode()
        {
            cmbBuildingCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetBuildingCode().Where(x => x.Active == true).ToList().ForEach(xx =>
                {
                    cmbBuildingCode.Items.Add(xx.BuildingCode);
                });
            }
        }
        void LoadType()
        {
            cmbRoomType.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                maintain.GetType().OrderBy(o => o.Type).ToList().ForEach(x => 
                {
                    cmbRoomType.Items.Add(x.Type);
                });
            }
        }
        void LoadTime(string RoomCode)
        {
            int i = 1;
            dgTime.Rows.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                var valueGetTime=_maintain.GetTime();
                valueGetTime.ForEach(x => 
                {
                    var valueRoomAndTime = _maintain.GetRoomTime().Where(xx => xx.RoomCode == RoomCode && xx.TimeCode == x.TimeCode).FirstOrDefault();
                    dgTime.Rows.Add(valueRoomAndTime != null ? valueRoomAndTime.ID : x.ID, i, x.TimeStart.Value.ToString("HH:mm:ss tt") + " to " + x.TimeEnd.Value.ToString("HH:mm:ss tt"), valueRoomAndTime != null ? valueRoomAndTime.Status : false, valueRoomAndTime != null ? valueRoomAndTime.TimeCode : x.TimeCode);
                    i++;                    
                });                          
            }
        }
        void LoadTime()
        {
            int i=1;
            dgTime.Rows.Clear();
            using (Maintenance _maintain = new Maintenance())
            {
                _maintain.GetTime().OrderBy(o => o.TimeCode).ToList().ForEach(x => 
                {
                    
                     dgTime.Rows.Add(x.ID, i,string.Format("{0} to {1}",x.TimeStart.Value.ToLongTimeString(),x.TimeEnd.Value.ToLongTimeString()),false,x.TimeCode);
                    i++;
                });
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
        void LoadDeviceAvailable()
        {
            dgDeviceRecord.Rows.Clear();
            int i = 1;
            using (DeviceModule device = new DeviceModule())
            {
                device.GetRFIDDevice().ForEach(x => 
                {
                    var yy=device.GetDeviceAvailable().Where(A=> A.SerialPort==x.Port).FirstOrDefault();
                    if (yy == null)
                    {
                        dgDeviceRecord.Rows.Add(i,x.DeviceName,x.Port);
                        i++;
                    }
                });
            }
        }
    }
}
