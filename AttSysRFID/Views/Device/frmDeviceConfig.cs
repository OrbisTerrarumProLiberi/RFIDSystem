using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
namespace AttSysRFID.Views.Device
{
    public partial class frmDeviceConfig : Form
    {
        private string MsgReturned = "";
        private bool isAdd;
        private string Disp;
        string PortAvailable = "";
        List<string> getCard = new List<string>();
        private string[] ComPortList;
        public frmDeviceConfig()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            ObjEnable(false);
            LoadDevice();
            SystemProperties.Cleared(this, false, true, true);
            
        }
        void SetHandler()
        {
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            dgDevice.CellClick += new DataGridViewCellEventHandler(dgDevice_CellClick);
            AutoScanTimer.Tick += new EventHandler(AutoScanTimer_Tick);
            cmbParity.KeyDown += new KeyEventHandler(cmbParity_KeyDown);
            cmbParity.KeyPress += new KeyPressEventHandler(cmbParity_KeyPress);
            cmbStopBits.KeyDown += new KeyEventHandler(cmbStopBits_KeyDown);
            cmbStopBits.KeyPress += new KeyPressEventHandler(cmbStopBits_KeyPress);
            ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived);
            btnTest.Click += new EventHandler(btnTest_Click);
            btnClear.Click += new EventHandler(btnClear_Click);
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
        }

        void btnTest_Click(object sender, EventArgs e)
        {
            AutoScanTimer.Enabled = true;
            AutoScanTimer.Start();
        }

        void ComSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Disp = ComSerial.ReadExisting();
                this.Invoke(new EventHandler(_dis));
            }
            catch (Exception ex)
            {

            }
        }
        private void _dis(object sender, EventArgs e)
        {
            //getCard.Add(Disp);
            //txtStatus.Text = getCard.LastOrDefault().ToString().Replace(" ", "");
            txtStatus.AppendText(Disp);
        }
        void cmbStopBits_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbStopBits_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void cmbParity_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbParity_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void AutoScanTimer_Tick(object sender, EventArgs e)
        {
            AutoScan();
        }
        void dgDevice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (DeviceModule device = new DeviceModule())
            {
                var value = device.GetRFIDDevice().Where(x => x.ID == Convert.ToInt64(dgDevice.SelectedRows[0].Cells[0].Value)).FirstOrDefault();
                if (value != null)
                {
                    txtName.Text = value.DeviceName;
                    txtBaundRate.Text = value.BaundRate.ToString();
                    txtComPort.Text = value.Port;
                    txtDataBits.Text = value.DataBit.ToString();
                    cmbParity.Text = value.Parity;
                    cmbStopBits.Text = value.StopBit;
                    cbActive.Checked = value.Active.Value;
                    
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
            LoadDevice();
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
        void LoadDevice()
        {
            dgDevice.Rows.Clear();
            int i = 1;
            using (DeviceModule _maintain = new DeviceModule())
            {
                _maintain.GetRFIDDevice().OrderBy(y => y.DeviceName).ToList().ForEach(x =>
                {
                    dgDevice.Rows.Add(x.ID, i, x.DeviceName,x.Port,x.BaundRate,x.DataBit,x.Parity,x.StopBit, x.Active);
                    i++;
                });
            }
            ObjEnable(false);
            dgDevice.Enabled = true;
        }
        private T_DeviceSettingRFID SetDeviceConfig(bool isDelete)
        {
            T_DeviceSettingRFID value = new T_DeviceSettingRFID();
            value.Active = cbActive.Checked;
            value.BaundRate = Convert.ToInt32(txtBaundRate.Text);
            value.DataBit = Convert.ToInt32(txtDataBits.Text);
            value.Parity = cmbParity.Text;
            value.StopBit = cmbStopBits.Text;
            value.Port = txtComPort.Text;
            value.DeviceName = txtName.Text;
            value.ID=isAdd?0:Convert.ToInt64(dgDevice.SelectedRows[0].Cells[0].Value.ToString());
            if(isDelete)
                value.ID = Convert.ToInt64(dgDevice.SelectedRows[0].Cells[0].Value.ToString());
            return value;

        }
        void Save()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToSave, "Device Config") == DialogResult.Yes)
            {
                if (CheckSerialPort())
                {

                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtComPort.Text) && !string.IsNullOrWhiteSpace(txtBaundRate.Text) && !string.IsNullOrWhiteSpace(txtDataBits.Text) && !string.IsNullOrWhiteSpace(cmbParity.Text) && !string.IsNullOrWhiteSpace(cmbStopBits.Text))
                    {
                        using (DeviceModule device = new DeviceModule())
                        {
                            device.Save(SetDeviceConfig(false), ref MsgReturned);

                            SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Device Config");
                            SystemProperties.Cleared(this, false, true, true);
                        }
                    }
                    else
                    {
                        SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.CheckInput + Environment.NewLine + Environment.NewLine + "Devie Name" + Environment.NewLine + "Port" + Environment.NewLine + "Baund Rate" + Environment.NewLine + "Data Bits" + Environment.NewLine + "Stop Bits" + Environment.NewLine + "Parity", "Device Config");
                    }
                }
                else
                    SystemProperties.ShowMessage.MessageError("Device Serial port is already exists  "+ Environment.NewLine+"Serial port:  "+txtComPort.Text, "Device Config");
            }
            LoadDevice();
        }
        private bool CheckSerialPort()
        {
            using (DeviceModule device = new DeviceModule())
            {
                return device.GetRFIDDevice().Where(x => x.Port == txtComPort.Text).FirstOrDefault() == null ? true : false;
            }
        }
        void Delete()
        {
            if (SystemProperties.ShowMessage.MessageQuestion(SystemProperties.MessageNotification.YouWantToDelete, "Device Config") == DialogResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtComPort.Text) && !string.IsNullOrWhiteSpace(txtBaundRate.Text) && !string.IsNullOrWhiteSpace(txtDataBits.Text) && !string.IsNullOrWhiteSpace(cmbParity.Text) && !string.IsNullOrWhiteSpace(cmbStopBits.Text))
                {

                    using (DeviceModule device = new DeviceModule())
                    {
                        device.Delete(SetDeviceConfig(true), ref MsgReturned);
                        SystemProperties.ShowMessage.MessageInformation(MsgReturned, "Device Config");

                    }
                }
                else
                {
                    SystemProperties.ShowMessage.MessageError(SystemProperties.MessageNotification.SelectFirst + " delete", "Device Config");

                }
            }
            LoadDevice();
        }
        void ObjEnable(bool enable)
        {
            btnTest.Enabled = enable;
            btnClear.Enabled = enable;
            btnAdd = SystemProperties.BtnProperties(btnAdd, !enable, Imagename.Add.ToString(), Imagename._add.ToString());
            btnEdit = SystemProperties.BtnProperties(btnEdit, !enable, Imagename.Edit.ToString(), Imagename._edit.ToString());
            btnSave = SystemProperties.BtnProperties(btnSave, enable, Imagename.Save.ToString(), Imagename._save.ToString());
            btnDelete = SystemProperties.BtnProperties(btnDelete, enable, Imagename.Delete.ToString(), Imagename._delete.ToString());
            btnCancel = SystemProperties.BtnProperties(btnCancel, enable, Imagename.Cancel.ToString(), Imagename._cancel.ToString());
        }
        void AutoScan()
        {
            
            try
            {
                ComPortList = SerialPort.GetPortNames();
                foreach (string port in ComPortList)
                {
                    ComSerial.PortName = port.ToString();
                    PortAvailable = port.ToString();
                }
                ComSerial.PortName = txtComPort.Text;
                ComSerial.Open();
                if (!string.IsNullOrWhiteSpace(txtBaundRate.Text))
                    ComSerial.BaudRate = Convert.ToInt32(txtBaundRate.Text);
                if (!string.IsNullOrWhiteSpace(cmbParity.Text))
                    ComSerial.Parity =SystemProperties.Getparity(cmbParity.Text);
                if (!string.IsNullOrWhiteSpace(cmbStopBits.Text))
                    ComSerial.StopBits =SystemProperties.GetStopBit(cmbStopBits.Text);
                if (!string.IsNullOrWhiteSpace(txtDataBits.Text))
                    ComSerial.DataBits = Convert.ToInt32(txtDataBits.Text);
                //txtStatus.Text = "";
                ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived);
                //ComSerial.Close();
            }
            catch (Exception ex)
            {
                //ComSerial.Close();
                //ComSerial.ReadTimeout = 100;
                //ComSerial.PortName = PortAvailable;
                //ComSerial.Open();

                //ComSerial.BaudRate = 9600;
                //ComSerial.Parity = Parity.None;
                //ComSerial.StopBits = StopBits.One;
                //ComSerial.DataBits = 8;
                //ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived);

                txtStatus.Text = "Available serial port:  " + Environment.NewLine + PortAvailable + Environment.NewLine + Environment.NewLine + "Defaul settings:" + Environment.NewLine + " BoundRate: 9600, DataBits: 8,StopBits: One,Parity: None ";
                
                AutoScanTimer.Stop();
                AutoScanTimer.Enabled = false;
                ComSerial.Close();
             
            }
        }
        
    }
}
