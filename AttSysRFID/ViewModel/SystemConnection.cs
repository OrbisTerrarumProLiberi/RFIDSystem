using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace AttSysRFID.ViewModel
{
    public class SystemConnection
    {
        static string ListConnSetting(string[] value, string param)
        {
            string ret = "";
            ret = value.ToList().Where(x => x.Contains(param)).FirstOrDefault();
            ret = ret.Replace(param, "").Trim();
            return ret;            
        }
        
        public static void GetStringConnection()
        {
            var _read = File.ReadAllLines(Application.StartupPath+"\\Sys.txt");
            foreach(var reds in _read)
            {
                SystemProperties.Database = ListConnSetting(_read,"[DATABASE]");
                SystemProperties.Server = ListConnSetting(_read, "[SERVER]");
                SystemProperties.UserID = ListConnSetting(_read, "[USERID]");
                SystemProperties.Password = ListConnSetting(_read, "[PASSWORD]");
            }
        }

        public static string ConnectionString
        {
            get
            {
                return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password = {3}",
                    SystemProperties.Server,
                    SystemProperties.Database,
                    SystemProperties.UserID,
                    SystemProperties.Password);
            }
        }
    } 
}
