using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
namespace AttSysRFID.ViewModel
{
    public class DeviceModule:IDisposable
    {
        public List<T_Remainder> GetRemainders()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_Remainders.ToList();
            }
        }

        public List<T_DeviceSettingRFID> GetRFIDDevice()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_DeviceSettingRFIDs.ToList();
            }
        }

        public bool Compare(T_DeviceSettingRFID value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //return dc.T_DeviceSettingRFIDs.Where(x => x.Active == value.Active && x.DeviceName.ToLower() == value.DeviceName.ToLower() && x.BaundRate == value.BaundRate && x.DataBit == value.DataBit && x.Parity == value.Parity && x.Port == value.Port && x.StopBit == value.StopBit).FirstOrDefault() == null ? true : false;
                return dc.T_DeviceSettingRFIDs
                    .Where(x => 
                        x.Active == value.Active &&
                        x.DeviceName.ToLower() == value.DeviceName.ToLower() &&
                        x.BaundRate == value.BaundRate && 
                        x.DataBit == value.DataBit && 
                        x.Parity == value.Parity && 
                        x.Port == value.Port && 
                        x.StopBit == value.StopBit)
                    .Any();
            }
        }

        public void Save(T_DeviceSettingRFID value, ref string msg)
        {
            //T_DeviceSettingRFID valueupdate = new T_DeviceSettingRFID();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (Compare(value))
                {
                    if (value.ID == 0)
                    {
                        dc.T_DeviceSettingRFIDs.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Device Name: {1}" + Environment.NewLine + "Port: {2}" + Environment.NewLine + "Baund Rate: {3}" + Environment.NewLine + "Data Bit: {4}" + Environment.NewLine + "Parity: {5}" + Environment.NewLine + "Stop Bit: {6}", SystemProperties.MessageNotification.Saved, value.DeviceName, value.Port, value.BaundRate, value.DataBit, value.Parity, value.StopBit);                 
                    }
                    else
                    {
                        //valueupdate = dc.T_DeviceSettingRFIDs.Where(x => x.ID == value.ID).FirstOrDefault();
                        var valueupdate = dc.T_DeviceSettingRFIDs.FirstOrDefault(x => x.ID == value.ID);
                        valueupdate.DeviceName = value.DeviceName;
                        valueupdate.BaundRate = value.BaundRate;
                        valueupdate.DataBit = value.DataBit;
                        valueupdate.Parity = value.Parity; ;
                        valueupdate.Port = value.Port;
                        valueupdate.StopBit = value.StopBit;
                        valueupdate.Active = value.Active;
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Device Name: {1}" + Environment.NewLine + "Port: {2}" + Environment.NewLine + "Baund Rate: {3}" + Environment.NewLine + "Data Bit: {4}" + Environment.NewLine + "Parity: {5}" + Environment.NewLine + "Stop Bit: {6}", SystemProperties.MessageNotification.Updated, value.DeviceName, value.Port, value.BaundRate, value.DataBit, value.Parity, value.StopBit);                 
                  
                    }
                }
                else
                {
                    msg=SystemProperties.MessageNotification.Exist;
                }

                dc.SubmitChanges();
            }
        
        }

        public void Delete(T_DeviceSettingRFID value, ref string msg)
        {
            //T_DeviceSettingRFID valuedelete = new T_DeviceSettingRFID();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //var valuedelete = dc.T_DeviceSettingRFIDs.Where(x => x.ID == value.ID).FirstOrDefault();
                var valuedelete = dc.T_DeviceSettingRFIDs.FirstOrDefault(x => x.ID == value.ID);
                dc.T_DeviceSettingRFIDs.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + "Device Name: {1}" + Environment.NewLine + "Port: {2}" + Environment.NewLine + "Baund Rate: {3}" + Environment.NewLine + "Data Bit: {4}" + Environment.NewLine + "Parity: {5}" + Environment.NewLine + "Stop Bit: {6}", SystemProperties.MessageNotification.Deleted, valuedelete.DeviceName, valuedelete.Port, valuedelete.BaundRate, valuedelete.DataBit, valuedelete.Parity, valuedelete.StopBit);
            }

        
        }

        public List<T_RoomDevie> GetDeviceAvailable()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_RoomDevies.ToList();
            }
        }

        public void Delete(T_RoomDevie value)
        {
            //T_RoomDevie valuedelete = new T_RoomDevie();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                //valuedelete = dc.T_RoomDevies.Where(x => x.RoomCode == value.RoomCode).FirstOrDefault();
                var valuedelete = dc.T_RoomDevies.FirstOrDefault(x => x.RoomCode == value.RoomCode);
                dc.T_RoomDevies.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
            }
        }

        public bool Compare(T_RoomDevie value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                return dc.T_RoomDevies
                    .Where(x => 
                        x.SerialPort == value.SerialPort || x.RoomCode == value.RoomCode)
                    .Any();
            }
        }

        public bool Save(T_RoomDevie value,ref string msg)
        {
            bool ret = false;
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext(SystemConnection.ConnectionString))
            {
                if (!string.IsNullOrWhiteSpace(value.DeviceCode))
                    if (Compare(value))
                    {
                        dc.T_RoomDevies.InsertOnSubmit(value);
                        dc.SubmitChanges();
                        //return false;
                    }
                    else
                    {
                        msg = SystemProperties.MessageNotification.Exist;
                        ret = true;
                        //return true;
                    }
                //dc.SubmitChanges();
                //return false;
                return ret;
            }
        }

        public void Dispose()
        {
           
        }
    }
}
