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
using System.IO.Ports;


namespace AttSysRFID.Views.Display
{
    public partial class frmDisplayGate : Form
    {
        public frmDisplayGate()
        {
            InitializeComponent();
            SetHanlder();
            SetProperties();
        }
        string StudID="";
        private string RoomCode = "";
        private string Comport;
        List<string> getCard = new List<string>();
        private string[] ComPortList;
        private string Disp;  
        int RemainingTime = 6;
        void SetProperties()
        {
            //GetRemainder();
            timer1.Enabled = true;
            timer1.Start();
            AutoScanTimer.Enabled = true;
            AutoScanTimer.Start();
            Clear();
            txtCardNoDisplay.Hide();
            GetAPI.GetSendingDetails();

        }
        void SetHanlder()
        {
            lblRoomNameAssigned.Text = "";
            timer1.Tick += new EventHandler(timer1_Tick);
            AutoScanTimer.Tick += new EventHandler(AutoScanTimer_Tick);
            txtCardNoDisplay.TextChanged += new EventHandler(txtCardNoDisplay_TextChanged);
        }
        void Clear()
        {
            lblTimeIN.Text = "";
            lblTimeOut.Text="";
            lblStudentName.Text = "";
            lblStudentID.Text = "";
            picInfo.Image = null;
        }

        private T_ScanUserLog CheckToRoom()
        {
            using (SMSNotification notify = new SMSNotification())
            {
                using(Students stud=new Students())
                {
                    var studs=stud.GetStudentInfo().Where(x=> x.RFIDNo==txtCardNoDisplay.Text).FirstOrDefault();
                    return notify.GetUserTime().Where(x => x.Day.ToLower() == Days().ToLower() && x.RoomCode == RoomCode && x.StudentID == studs.StudentID).FirstOrDefault();
                }
            }
        }
        void SaveUpdateLogs()
        {
            if (CheckToRoom().TimeIN.Value.Hour==UserDetail.CurrDate().Hour)
            {
                if (!string.IsNullOrWhiteSpace(txtCardNoDisplay.Text))
                {
                    using (SMSNotification notify = new SMSNotification())
                    {
                        string cards = txtCardNoDisplay.Text;
                        string dayss = Days();

                        var value = notify.GetRegisterStudent().Where(x => x.RoomCode == RoomCode && x.RFID == cards && x.Semester.ToLower() == SystemProperties.SemesterActive.Semester.ToLower() && x.YearClass == SystemProperties.SemesterActive.YearSemester && GetTotalDays(x.SemEndDate, true) > 0 && (x.Day.Replace(" ", "").ToLower() == Days().ToLower() || x.Day.Replace("  ", "").ToLower() == Days().ToLower() || x.Day.Replace("   ", "").ToLower() == Days().ToLower() || x.Day.Replace("   ", "").ToLower() == Days().ToLower()) && x.TimeStart.Hour == UserDetail.CurrDate().Hour).FirstOrDefault();
                        
                        if (value != null)
                        {
                            T_ScanUserLog val = new T_ScanUserLog();
                            val.RoomCode = RoomCode;
                            val.MessageID = value.MessageID;

                            val.StudentID = value.StudentID;
                            val.SubjectCode = value.SubjectCode;
                            val.SubjectDescription = value.SubjectDescription;
                            val.TimeIN = UserDetail.CurrDate();
                            val.TotalHours = 0;
                            val.Day = Days();
                            val.SendingNo = value.ParentsNo;
                            using (Parents part = new Parents())
                            {
                                var valuepart = part.GetParentsInfo().Where(x => x.StudentID == value.StudentID).FirstOrDefault();
                                if (valuepart != null && !string.IsNullOrWhiteSpace(valuepart.MomLastName))
                                {
                                    val.SendingTo = string.Format("{0}, {1}", valuepart.MomLastName, valuepart.MomFirstName);
                                }
                            }
                            lblStudentID.Text = value.StudentID;
                            using (Students stud = new Students())
                            {
                                var valuestud = stud.GetStudentInfo().Where(x => x.StudentID == value.StudentID).FirstOrDefault();
                                lblStudentName.Text = string.Format("{0}, {1} {2}", valuestud.LastName, valuestud.FirstName, valuestud.MiddleName);
                                using (SMSNotification sms = new SMSNotification())
                                {
                                    var valueMSG = sms.GetSMS().Where(x => x.Code.ToLower() == val.MessageID.ToLower()).FirstOrDefault();
                                    string valuemsg = string.Format("Message: {0} %0A %0A Student ID: {1} %0A Name: {2} %0A Subject Code: {3} %0A Description: {4} %0A Time IN: {5} %0A Room: {6}", valueMSG.MessageAlert, value.StudentID, valuestud.LastName + ", " + valuestud.FirstName, value.SubjectCode, value.SubjectDescription, UserDetail.CurrDate(), RoomCode);
                                    if ((OnMessage.SendingNotification && !value.AlreadyIN.Value))//if you want to send a message to the parents
                                        GetAPI.SendMessage(valuemsg, value.ParentsNo);
                                }

                            }
                            lblTimeIN.Text = UserDetail.CurrDate().ToShortTimeString();
                            UserProfile(value.StudentID);
                            if (ChekingForAvailableTimeIN())
                                notify.Save(val, true);
                            //else
                            //{

                            //    notify.Save(val, false);
                            //    lblTimeOut.Text = UserDetail.CurrDate().ToShortTimeString();
                            //}
                        }

                    }
                }
            
            }
        }
        void txtCardNoDisplay_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCardNoDisplay.Text))
            {
                //var checks=(CheckToRoom().TimeIN.Value.Hour == UserDetail.CurrDate().Hour && !string.IsNullOrWhiteSpace((CheckToRoom().TimeIN.Value.ToShortDateString()==UserDetail.CurrDate().ToShortDateString()).ToString()))? false : true;
                //if (checks)
                //{
                //    CheckTimeIN(true);
                //}
                //else
                //{
                //    CheckTimeIN(false);
                //    lblTimeOut.Text = UserDetail.CurrDate().ToShortTimeString();
                //}
                CheckTimeIN();
            }// 
           
        }
        void UserProfile(string stdID)
        {
            string pathDirection = "";
            string ImageName = "";
            pathDirection = SystemProperties.ReadStudentImage();
            using (Students std = new Students())
            {
                var details=std.GetStudentInfo().Where(x => x.StudentID == stdID).FirstOrDefault();
                ImageName = string.Format("{0}{1}-{2}", details.LastName, details.FirstName, details.StudentID);
                picInfo.Image = Image.FromFile(pathDirection + ImageName + ".png");
            }
        }
        public int GetTotalDays(DateTime DateParam,bool Param)
        {
            return Param?(DateParam- UserDetail.CurrDate().Date).Days:(UserDetail.CurrDate().Date-DateParam).Days;
        }
        string Days()
        {
            DayOfWeek days=UserDetail.CurrDate().DayOfWeek;
            return days.ToString();
        }
        public string RemoveWhiteSpace(string txt)
        {
            if (txt == null)
            {
                return null;
            }
            else
            {
                return new string(txt.ToCharArray().Where(x=> !Char.IsWhiteSpace(x)).ToArray());
            }
        }
       
        bool ChekingForAvailableTimeIN()
        {
            string ID="";
            using (SMSNotification notify = new SMSNotification())
            {
                using (Students stud = new Students())
                {
                    var studentID= stud.GetStudentInfo().Where(x => x.RFIDNo == txtCardNoDisplay.Text).FirstOrDefault();
                    if(studentID!=null)
                    {
                        ID = studentID.StudentID;
                        StudID=studentID.StudentID;
                    }
                    return notify.GetRegisterStudent().Where(x => x.RoomCode == RoomCode && x.StudentID == ID && x.TImeEnd == null  && x.Day.ToLower() == Days().ToLower()).FirstOrDefault() == null ? true : false;
                }
            }
        }
        void CheckTimeOUT()
        {
            using (SMSNotification notify = new SMSNotification())
            {
                var value= notify.GetRegisterStudent().Where(x=> x.RoomCode == RoomCode && x.StudentID == StudID && x.TImeEnd == null  && x.Day.ToLower() == Days().ToLower()).FirstOrDefault();
                
            }
        }
        void CheckTimeIN()
        {
            if (!string.IsNullOrWhiteSpace(txtCardNoDisplay.Text))
            {
                using (SMSNotification notify = new SMSNotification())
                {
                    
                    string cards = txtCardNoDisplay.Text;
                    //cards = cards + "\r";
                    string dayss = Days();

                    var value = notify.GetRegisterStudent().Where(x => x.RoomCode == RoomCode && x.RFID == cards && x.Semester.ToLower() == SystemProperties.SemesterActive.Semester.ToLower() && x.YearClass == SystemProperties.SemesterActive.YearSemester && GetTotalDays(x.SemEndDate, true) > 0 &&
                        (x.Day.Replace(" ", "").ToLower() == Days().ToLower() || x.Day.Replace("  ", "").ToLower() == Days().ToLower() || x.Day.Replace("   ", "").ToLower() == Days().ToLower() || x.Day.Replace("   ", "").ToLower() == Days().ToLower()) && x.TimeStart.Hour == UserDetail.CurrDate().Hour).FirstOrDefault();
                   
                    if (value != null)
                    {
                        T_ScanUserLog val = new T_ScanUserLog();
                        val.RoomCode = RoomCode;
                        val.MessageID = value.MessageID;

                        val.StudentID = value.StudentID;
                        val.SubjectCode = value.SubjectCode;
                        val.SubjectDescription = value.SubjectDescription;
                        val.TimeIN = UserDetail.CurrDate();
                        val.TotalHours = 0;
                        val.Day = Days();
                        val.SendingNo = value.ParentsNo;
                        using (Parents part = new Parents())
                        {
                            var valuepart = part.GetParentsInfo().Where(x => x.StudentID == value.StudentID).FirstOrDefault();
                            if (valuepart != null && !string.IsNullOrWhiteSpace(valuepart.MomLastName))
                            {
                                val.SendingTo = string.Format("{0}, {1}", valuepart.MomLastName, valuepart.MomFirstName);
                            }
                        }
                        lblStudentID.Text = value.StudentID;
                        using (Students stud = new Students())
                        {
                            var valuestud = stud.GetStudentInfo().Where(x => x.StudentID == value.StudentID).FirstOrDefault();
                            lblStudentName.Text = string.Format("{0}, {1} {2}", valuestud.LastName, valuestud.FirstName, valuestud.MiddleName);
                            using (SMSNotification sms = new SMSNotification())
                            {
                                var valueMSG = sms.GetSMS().Where(x => x.Code.ToLower() == val.MessageID.ToLower()).FirstOrDefault();
                                string valuemsg = string.Format("Message: {0} %0A %0A Student ID: {1} %0A Name: {2} %0A Subject Code: {3} %0A Description: {4} %0A Time IN: {5} %0A Room: {6}", valueMSG.MessageAlert, value.StudentID, valuestud.LastName + ", " + valuestud.FirstName, value.SubjectCode, value.SubjectDescription, UserDetail.CurrDate(), RoomCode);
                                if (OnMessage.SendingNotification)//if you want to send a message to the parents
                                    GetAPI.SendMessage(valuemsg, value.ParentsNo);
                            }

                        }
                        if (value.AlreadyIN.Value)
                        {
                            lblTimeOut.Text = UserDetail.CurrDate().ToShortTimeString();
                        }
                        else
                        {
                            lblTimeIN.Text = UserDetail.CurrDate().ToShortTimeString();
                        }
                        //lblTimeIN.Text = UserDetail.CurrDate().ToShortTimeString();
                        UserProfile(value.StudentID);
                        //if (ChekingForAvailableTimeIN())
                        //    notify.Save(val, status);
                        //else
                        //{

                        notify.Save(val, value.AlreadyIN.Value?false:true);
                            
                       // }

                    }

                }
            }
            
        }
        void AutoScanTimer_Tick(object sender, EventArgs e)
        {
            Checking();
            AutoScan();
        }
        void Checking()
        {
            int until = 6;
            if (RemainingTime<=until)
            {
                this.Text =string.Format("Remaining Time: [{0}]",RemainingTime-=1);
            }
            if (RemainingTime == 0)
            {
                txtCardNoDisplay.Text = "";
                Clear();
                RemainingTime = 6;
                GetScheduleEveryDayTime();
            }
            

        }
        void ComSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Disp = ComSerial.ReadLine().Replace("\r",string.Empty);
                this.Invoke(new EventHandler(_dis));

            }
            catch (Exception ex)
            {
            }
        }
        void strings9()
        {

        }
        private void _dis(object sender, EventArgs e)
        {

            getCard.Add(Disp);
            txtCardNoDisplay.Text = getCard.LastOrDefault().ToString();//.Replace(" ","") ;

            //GetScheduleEveryDayTime();
            //if(txtCardNoDisplay.TextLength>8)
              //  txtCardNoDisplay.Text = txtCardNoDisplay.Text.Replace(" ","").Remove(8);            
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        }
        void GetRoomAssignment(string ComPort)
        {
            using (DeviceModule dm = new DeviceModule())
            {

                var RoomAvl=dm.GetDeviceAvailable().Where(x => x.SerialPort.ToLower() == Comport.ToLower()).FirstOrDefault();
                if (RoomAvl != null)
                {
                    RoomCode = RoomAvl.RoomCode;
                    lblRoomNameAssigned.Text = string.Format("Device is registered for room   [ {0} ]", RoomAvl.RoomType.ToUpper());
                }
            }
        }
        void AutoScan()
        {
            try
            {

                ComSerial.ReadTimeout = 100;
                ComPortList = SerialPort.GetPortNames();
                foreach (string port in ComPortList)
                {
                    ComSerial.PortName = port.ToString();
                }
                Comport = ComSerial.PortName;
                GetRoomAssignment(ComSerial.PortName);
                ComSerial.BaudRate = 9600;
                ComSerial.DataBits = 8;
                ComSerial.Parity = Parity.None;
                ComSerial.StopBits = StopBits.One;

                ComSerial.Close();
                ComSerial.Open();
                ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived);
            }
            catch (Exception ex)
            {
                ComSerial.Close();
            }


        }
        //void GetRemainder()
        //{
        //    txtDisplayRemainders.Text = Environment.NewLine + Environment.NewLine;
        //    using (DeviceModule device = new DeviceModule())
        //    {
        //        device.GetRemainders().ForEach(x => 
        //        {
        //            txtDisplayRemainders.Text +="      "+x.Remainders + Environment.NewLine;
        //        });
        //    }
        //}
        void GetScheduleEveryDayTime()
        {
            dgRecordSubjectEverDay.Rows.Clear();
            using (SMSNotification notify = new SMSNotification())
            {
                var ListSub = notify.GetRegisterStudent().Where(x => x.RoomCode == RoomCode && x.Day.Replace(" ", string.Empty).Replace(" ", "").Replace("  ", "").Replace("    ", "").ToLower() == Days().ToLower() && x.TimeStart.Hour == UserDetail.CurrDate().Hour && x.YearClass == SystemProperties.SemesterActive.YearSemester && x.Semester == SystemProperties.SemesterActive.Semester).ToList();
                ListSub.ForEach(x =>
                {
                    using(Students stud=new Students())
                    {

                        var studs=stud.GetStudentInfo().Where(y=> y.RFIDNo==x.RFID).FirstOrDefault();
                        dgRecordSubjectEverDay.Rows.Add(x.TimeStart,studs.StudentID,studs.LastName+", "+studs.FirstName,x.SubjectCode,x.Day,x.TimeStart,x.TImeEnd);
                    }
                });
            }
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format("{0}", UserDetail.CurrDate().ToString("dddd  MMM. dd,yyyy"));
            lblTime.Text = UserDetail.CurrDate().ToString("HH:mm:ss tt");
            
        }
       
    }
}
