using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttSysRFID.Model;
using AttSysRFID.ViewModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
namespace AttSysRFID.ViewModel
{
    public class GetAPI:IDisposable
    {
        
        public static void SendMessage(string Message,string ContactNo)
        {
            //try
            //{
            //    string Html = string.Empty;
                SystemProperties.SendingMessage.ApiLink = string.Format(@"http://{0}/{1}?{2}={3}&{4}={5}", 
                        SystemProperties.SendingMessage.Site, 
                        SystemProperties.SendingMessage.Page.Replace("?", ""), 
                        SystemProperties.SendingMessage.ParamNumber, 
                        ContactNo, 
                        SystemProperties.SendingMessage.ParamMessage, 
                        Message);

            using (WebBrowser wb = new WebBrowser())
            {
                wb.ScrollBarsEnabled = false;
                wb.ScriptErrorsSuppressed = true;
                wb.Navigate(SystemProperties.SendingMessage.ApiLink);
            }
        }

        public bool CheckInternetConnection()
        {
            //bool Connection = NetworkInterface.GetIsNetworkAvailable();
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.OpenRead("http://clients3.google.com/generate_204");
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            //return NetworkInterface.GetIsNetworkAvailable();
           
        }

        public static void GetSendingDetails()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                //var value=dc.T_NotificationSettings.Where(x => x.Active==true).FirstOrDefault();
                var value=dc.T_NotificationSettings.FirstOrDefault(x => x.Active == true);
                if (value != null)
                {
                    
                    SystemProperties.SendingMessage.IPaddress = value.IPaddress;
                    SystemProperties.SendingMessage.Site = value.Site;
                    SystemProperties.SendingMessage.Page = value.Page;
                    SystemProperties.SendingMessage.ParamMessage = value.ParamMessageName;
                    SystemProperties.SendingMessage.ParamNumber = value.ParamMobileName;
                    SystemProperties.SendingMessage.NameFrom = string.Format("{0}, {1}", UserInfo.LastName, UserInfo.FirstName); // UserInfo.LastName + ", " + UserInfo.FirstName;
            
                }            
            }           
        }

        public List<T_NotificationSetting> GetAPIs()
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())            
            {
                return dc.T_NotificationSettings.ToList();
            }
        }

        public void Delete(T_NotificationSetting value,ref string msg)
        {
            //T_NotificationSetting valuedelete = new T_NotificationSetting();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                //var valuedelete = dc.T_NotificationSettings.Where(x => x.ID == value.ID).FirstOrDefault();
                var valuedelete = dc.T_NotificationSettings.FirstOrDefault(x => x.ID == value.ID);
                dc.T_NotificationSettings.DeleteOnSubmit(valuedelete);
                dc.SubmitChanges();
                msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + 
                                    "Site: {1}" + Environment.NewLine + 
                                    "Page: {2}" + Environment.NewLine + 
                                    "Mobile: {3}" + Environment.NewLine + 
                                    "Message:  {4}", 
                                        SystemProperties.MessageNotification.Deleted, 
                                        value.Site, 
                                        value.Page, 
                                        value.ParamMobileName, 
                                        value.ParamMessageName);   
            }
        }

        public void Save(T_NotificationSetting value, ref string msg)
        {
            //T_NotificationSetting valueupdate = new T_NotificationSetting();
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                if (Compare(value))
                {
                    if (value.ID == 0 && GetAPIs().ToList().Count==0)
                    {
                        dc.T_NotificationSettings.InsertOnSubmit(value);
                        msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + 
                                            "Site: {1}" + Environment.NewLine + 
                                            "Page: {2}" + Environment.NewLine + 
                                            "Mobile: {3}" + Environment.NewLine + 
                                            "Message:  {4}",
                                                SystemProperties.MessageNotification.Saved,
                                                value.Site,
                                                value.Page,
                                                value.ParamMobileName,
                                                value.ParamMessageName);
                    }
                    else
                    {
                        //var valueupdate = dc.T_NotificationSettings.Where(x => x.ID == value.ID).FirstOrDefault();
                        var valueupdate = dc.T_NotificationSettings.FirstOrDefault(x => x.ID == value.ID);
                        if (valueupdate != null)
                        {
                            valueupdate.Active = value.Active;
                            valueupdate.Page = value.Page;
                            valueupdate.ParamMessageName = value.ParamMessageName;
                            valueupdate.ParamMobileName = value.ParamMobileName;
                            valueupdate.Site = value.Site;
                            msg = string.Format("{0}" + Environment.NewLine + Environment.NewLine + 
                                                "Site: {1}" + Environment.NewLine + 
                                                "Page: {2}" + Environment.NewLine + 
                                                "Mobile: {3}" + Environment.NewLine + 
                                                "Message:  {4}", 
                                                    SystemProperties.MessageNotification.Updated, 
                                                    valueupdate.Site, 
                                                    valueupdate.Page, 
                                                    valueupdate.ParamMobileName,
                                                    valueupdate.ParamMessageName);
                        }
                        else
                        {
                            msg = "Not allow to add new, Please can remove site.";
                        }
                       
                    }
                }
                else
                {
                    msg = SystemProperties.MessageNotification.Exist;
                }
                dc.SubmitChanges();
            }
        }

        public bool Compare(T_NotificationSetting value)
        {
            using (AttMonSysRFIDDataContext dc = new AttMonSysRFIDDataContext())
            {
                //return dc.T_NotificationSettings.Where(x => x.Active == value.Active && x.Page == value.Page && x.Site == value.Site && x.ParamMessageName == value.ParamMessageName && x.ParamMobileName == value.ParamMobileName).FirstOrDefault() == null ? true : false;
                return dc.T_NotificationSettings
                    .Where(x => 
                        x.Active == value.Active && 
                        x.Page == value.Page && 
                        x.Site == value.Site && 
                        x.ParamMessageName == value.ParamMessageName && 
                        x.ParamMobileName == value.ParamMobileName)
                     .Any();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
