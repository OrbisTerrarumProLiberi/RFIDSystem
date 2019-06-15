using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AttSysRFID.ViewModel;
using System.IO.Ports;
namespace AttSysRFID.ViewModel
{
    public class SystemProperties:IDisposable
    {
        //SerialPort ComSerial = new SerialPort();
        //TextBox txt = new TextBox();
        //public string Disp;
        public static Button BtnProperties(Button btn,bool enable,string EnableImageName,string DisableImage)
        {
            //Button btn = new Button();
            btn.Enabled = enable;
            btn.Image = System.Drawing.Image.FromFile(string.Format(@"{0}\{1}.png", SystemSetup.ImagePath, enable ? EnableImageName : DisableImage).Replace("\\", @"\"));
            btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btn.BackColor = System.Drawing.Color.DimGray;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font(UserInfo.ButtonFontStyle, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = System.Drawing.Color.White;
            btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            return btn;
            
        }
        public static void  Cleared(Control me, bool enable,bool isCancel,bool isAdd)
        {
            foreach (Control ctr in me.Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox txt = (TextBox)ctr;
                    txt.ReadOnly = !enable;
                    txt.Text = isAdd ? "" : txt.Text;
                    if (isCancel)
                        txt.Text = "";
                }
                else if (ctr.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = (CheckBox)ctr;
                    chk.Enabled = enable;
                    chk.Checked = isAdd ? false : chk.Checked;
                    if (isCancel)
                        chk.Checked = false;
                }
                else if (ctr.GetType() == typeof(RadioButton))
                {
                    RadioButton chk = (RadioButton)ctr;
                    chk.Enabled = enable;
                    chk.Checked = isAdd ? false : chk.Checked;
                    if (isCancel)
                        chk.Checked = false;
                }
                else if (ctr.GetType() == typeof(PictureBox))
                {
                    PictureBox pic = (PictureBox)ctr;
                    pic.Enabled = enable;
                    pic.Image = isAdd ? null : pic.Image;
                    if (isCancel)
                        pic.Image = null;
                }
                else if (ctr.GetType() == typeof(DataGridView))
                {
                    DataGridView dg = (DataGridView)ctr;
                    dg.Enabled = !enable;
                }               
                else if(ctr.GetType()==typeof(ComboBox))
                {
                    ComboBox cmb = (ComboBox)ctr;
                    cmb.Enabled = enable;
                    cmb.Text = isAdd ? "" : cmb.Text;
                }
                else if(ctr.GetType()==typeof(NumericUpDown))
                {
                    NumericUpDown txt = (NumericUpDown)ctr;
                    txt.ReadOnly = !enable;
                    txt.Value = isAdd ? 1 : txt.Value;
                    txt.Enabled = enable;
                    if (isCancel)
                        txt.Value= 1;           
                }
                else if (ctr.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker dt = (DateTimePicker)ctr;
                    dt.Enabled = enable;
                    dt.Value = isAdd ? UserDetail.CurrDate() : dt.Value;
                }
                else if (ctr.GetType() == typeof(MaskedTextBox))
                {
                    MaskedTextBox mtxtBox = (MaskedTextBox)ctr;
                    mtxtBox.Enabled = enable;
                    mtxtBox.Text = isAdd ? "" : mtxtBox.Text;   
                }

                else if (ctr.GetType() == typeof(Panel) || ctr.GetType() == typeof(GroupBox))
                {
                    Cleared(ctr, enable, isCancel, isAdd);
                }
            }
           
        }
       
        public class CmbKeyEventCtrl
        {
            public static KeyEventArgs KeyDown(KeyEventArgs e)
            {
                if (e.KeyData == Keys.Delete || e.KeyData == Keys.Space)
                    e.SuppressKeyPress = true;
                return e;
            }
            public static KeyPressEventArgs KeyPress(KeyPressEventArgs e)
            {
                e.Handled = !char.IsWhiteSpace(e.KeyChar) || char.IsNumber(e.KeyChar);
                return e;
            }
        }
        public static string SystemBackground()
        {
            StreamReader sr = new StreamReader("Background.txt");            
            return sr.ReadToEnd().ToString();
        }
        public static string ReadButtonImage()
        {
            //string StrStarImgPath = Application.StartupPath + @"\ButtonImage";
            return Application.StartupPath + @"\ButtonImage";
        }
        public static string ReadStudentImage()
        {
            //string StrStarImgPath = Application.StartupPath + @"\StudentImage\";
            return Application.StartupPath + @"\StudentImage\";
        }
        public static string ReadInstructorImage()
        {
            //string StrStarImgPath = Application.StartupPath + @"\InstructorImage\";
            return Application.StartupPath + @"\InstructorImage\";
        }
        public class MessageNotification
        {
            public static string Saved ="Successfully saved.";
            public static string Deleted = "Successfully deleted.";
            public static string Updated = "Successfully updated.";
            public static string Exist = "Your data is already exists.";
            public static string PasswordNotMatch = "Your password are not match";
            public static string CheckInput = "Please check your input";
            public static string UserNameExists = "Your username is already exist";
            public static string YouWantToSave = "Do you want to save?";
            public static string YouWantToDelete = "Do you want to delete?";
            public static string SelectFirst = "Please select first, if do you want to";
            public static string AlreadyUsed = "Cannot delete data , already used ";
            public static string ExistRFID = "Your RFID number is already exists.";
        
        }
        public class AccessRight
        {

            public static bool Application { get; set; }
            public static bool Student { get; set; }
            public static bool Instructor { get; set; }
            public static bool Position { get; set; }
            public static bool User { get; set; }
            public static bool YearLevel { get; set; }
            public static bool CivilStatus { get; set; }
            public static bool Course { get; set; }
            public static bool Subject { get; set; }
            public static bool Room { get; set; }
            public static bool Time { get; set; }
            public static bool Display { get; set; }
            public static bool Report { get; set; }
            public static bool DeviceConfiguration { get; set; }
            public static bool RoomType { get; set; }
            public static bool Building { get; set; }
            public static bool ViewRoom { get; set; }
            public static bool ViewCourse { get; set; }
            public static bool ViewInstructor { get; set; }
            public static bool NotifyStudent { get; set; }
            public static bool MaintenanceMessage { get; set; }
            public static bool SMSSettings { get; set; }
            public static bool Semester { get; set; }
            public static bool YearClass { get; set; }
            
        }
        public class SemesterActive
        {
            public static string  YearSemester { get; set; }
            public static string  Semester { get; set; }
            public static DateTime Start { get; set; }
            public static DateTime End { get; set; }
        }
        public static class SendingMessage
        {
            public static string ApiLink { get; set; }
            public static string Number { get; set; }
            public static string Message { get; set; }
            public static int SendingCount { get; set; }
            public static string NameFrom { get; set; }
            public static string SendingBy { get; set; }
            public static string IPaddress { get; set; }
            public static string Site { get; set; }
            public static string Page { get; set; }
            public static string ParamNumber { get; set; }
            public static string ParamMessage { get; set; }

        }
        public static class ShowMessage
        {
            public static DialogResult MessageInformation(string Caption, string Header)
            {
                return MessageBox.Show(Caption, Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            public static DialogResult MessageError(string Caption, string Header)
            {
                return MessageBox.Show(Caption, Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            public static DialogResult MessageWarning(string Caption, string Header)
            {
                return MessageBox.Show(Caption, Header, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            public static DialogResult MessageQuestion(string Caption, string Header)
            {
                return MessageBox.Show(Caption, Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
        public void Dispose()
        {
            
        }
        public class SetUpPort
        {
            public string Port { get; set; }
            public int ReadTimeOut { get; set; }
            public string BaundRate { get; set; }
            public Parity Parity { get; set; }
            public StopBits StopBit { get; set; }
            public string DataBit { get; set; }
        }
        //public void  ComSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    //return  ComSerial.ReadExisting();
        //    //this.Invoke(new EventHandler(_dis));
        //}
        //public TextBox _dis(object sender, EventArgs e)
        //{
        //    TextBox txt;
        //    return txt.AppendText((ComSerial.DataReceived += new SerialDataReceivedEventHandler(ComSerial_DataReceived)));
        //    //return txt.AppendText(ComSerial.DataReceived+=new SerialDataReceivedEventHandler(ComSerial_DataReceived(sender,SerialDataReceivedEventHandler)));
        //    //retrun txt.appe  ;
        //}
        public static Parity Getparity(string cmb)
        {
            if (cmb.ToLower() == Parity.Even.ToString().ToLower())
                return Parity.Even;
            else if (cmb.ToLower() == Parity.Mark.ToString().ToLower())
                return Parity.Mark;
            else if (cmb.ToLower() == Parity.None.ToString().ToLower())
                return Parity.None;
            else if (cmb.ToLower() == Parity.Odd.ToString().ToLower())
                return Parity.Odd;
            else
                return Parity.Space;
        }
        public static StopBits GetStopBit(string cmb)
        {

            if (cmb.ToLower() == StopBits.None.ToString().ToLower())
                return StopBits.None;
            else if (cmb.ToLower() == StopBits.One.ToString().ToLower())
                return StopBits.One;
            else if (cmb.ToLower() == StopBits.OnePointFive.ToString().ToLower())
                return StopBits.OnePointFive;
            else
                return StopBits.Two;
        }
        public static string Database { get; set; }
        public static string Server { get; set; }
        public static string UserID { get; set; }
        public static string Password { get; set; }   
    }
    
}
