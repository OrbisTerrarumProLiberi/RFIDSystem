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
namespace AttSysRFID.Views.ViewRecord
{
    public partial class frmCourseAndSubject : Form
    {
        public frmCourseAndSubject()
        {
            InitializeComponent();
            SetHandler();
            SetProperties();
        }
        void SetProperties()
        {
            LoadSubject();
            LoadCourse();
        }
        void SetHandler()
        {
            cmbCourseCode.KeyDown += new KeyEventHandler(cmbCourseCode_KeyDown);
            cmbCourseCode.KeyPress += new KeyPressEventHandler(cmbCourseCode_KeyPress);
            cmbCourseCode.SelectedValueChanged += new EventHandler(cmbCourseCode_SelectedValueChanged);
            cmbCourseCode.TextChanged += new EventHandler(cmbCourseCode_TextChanged);


            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            //MsgReturned = "";
            //Save();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            //LoadCourseProgram();
            SystemProperties.Cleared(this, false, true, true);
            //MsgReturned = "";

        }
        void cmbCourseCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbCourseCode.SelectedItem.ToString()))
                LoadCourse(cmbCourseCode.Text);
        }

        void cmbCourseCode_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        void cmbCourseCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyPress(e);
        }
        void cmbCourseCode_KeyDown(object sender, KeyEventArgs e)
        {
            SystemProperties.CmbKeyEventCtrl.KeyDown(e);
        }
        void LoadCourse(string Code)
        {
            //cmbCourseCode.Items.Clear();
            using (Maintenance maintain = new Maintenance())
            {
                var value=maintain.GetCourse().Where(x => x.Active == true && x.CourseCode == Code).OrderBy(o => o.Course).FirstOrDefault().Course;
                txtDescription.Text = value;
            }
            txtDescription.ReadOnly = true;
        }
        
        void LoadCourse()
        {
            cmbCourseCode.Items.Clear();            
            using(Maintenance maintain=new Maintenance())
            {
                var value=maintain.GetCourse().Where(x => x.Active == true).OrderBy(o => o.CourseCode).ToList();
                value.ForEach(x => 
                {
                    cmbCourseCode.Items.Add(x.CourseCode);
                });
            }
            txtDescription.ReadOnly = true;
        }

        void LoadSubject()
        {
            int i = 1;
            dgSubject.Rows.Clear();
            using (Maintenance maintain = new Maintenance()) 
            {
                var value=maintain.GetSubject().Where(x => x.Active == true).OrderBy(o => o.Code).ToList();
                value.ForEach(x => 
                {
                    dgSubject.Rows.Add(x.ID,i,x.Code,x.Description,x.Unit,false);
                    i++;
                });
            
            }
            txtDescription.ReadOnly = true;
        }
    }
}
