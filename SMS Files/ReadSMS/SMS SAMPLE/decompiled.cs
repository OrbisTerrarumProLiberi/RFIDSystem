// Decompiled with JetBrains decompiler
// Type: SMS_Recieve_New.Form1
// Assembly: SMS Recieve New, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30E53246-1829-4C3C-9E6E-1E57E13E156A
// Assembly location: C:\Users\alfre\Downloads\Compressed\SMS SAMPLE\SAMPLE\SMS Recieve New.exe

using DevComponents.DotNetBar;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SMS_Recieve_New.My;
using SMS_Recieve_New.ReadSMS_AT_CS20;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SMS_Recieve_New
{
  [DesignerGenerated]
  public class Form1 : Office2007Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("Panel2")]
    private Panel _Panel2;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("rtb")]
    private RichTextBox _rtb;
    [AccessedThroughProperty("Timer1")]
    private System.Windows.Forms.Timer _Timer1;
    [AccessedThroughProperty("ButtonX2")]
    private ButtonX _ButtonX2;
    [AccessedThroughProperty("ButtonX1")]
    private ButtonX _ButtonX1;
    [AccessedThroughProperty("ButtonX4")]
    private ButtonX _ButtonX4;
    [AccessedThroughProperty("Panel5")]
    private Panel _Panel5;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("TabControl1")]
    private DevComponents.DotNetBar.TabControl _TabControl1;
    [AccessedThroughProperty("TabControlPanel1")]
    private TabControlPanel _TabControlPanel1;
    [AccessedThroughProperty("TabItem1")]
    private TabItem _TabItem1;
    [AccessedThroughProperty("lvwMessages")]
    private ListView _lvwMessages;
    [AccessedThroughProperty("ColumnHeader1")]
    private ColumnHeader _ColumnHeader1;
    [AccessedThroughProperty("ColumnHeader2")]
    private ColumnHeader _ColumnHeader2;
    [AccessedThroughProperty("ColumnHeader3")]
    private ColumnHeader _ColumnHeader3;
    [AccessedThroughProperty("ColumnHeader4")]
    private ColumnHeader _ColumnHeader4;
    [AccessedThroughProperty("Panel4")]
    private Panel _Panel4;
    [AccessedThroughProperty("ButtonX5")]
    private ButtonX _ButtonX5;
    [AccessedThroughProperty("ComboBox1")]
    private ComboBox _ComboBox1;
    [AccessedThroughProperty("lblSenderDate")]
    private Label _lblSenderDate;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    private string cmport;
    private AutoResetEvent receiveNow;
    private SerialPort port;
    public string modem;
    public string selected;
    private string sCurrMessage;
    private Thread thread;
    private bool bStopRead;
    [AccessedThroughProperty("serialport")]
    private SerialPort _serialport;

    [DebuggerNonUserCode]
    static Form1()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (Form1.__ENCList)
      {
        if (Form1.__ENCList.Count == Form1.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (Form1.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (Form1.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                Form1.__ENCList[index1] = Form1.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          Form1.__ENCList.RemoveRange(index1, checked (Form1.__ENCList.Count - index1));
          Form1.__ENCList.Capacity = Form1.__ENCList.Count;
        }
        Form1.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
      }
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.rtb = new RichTextBox();
      this.ButtonX2 = new ButtonX();
      this.ButtonX1 = new ButtonX();
      this.Panel2 = new Panel();
      this.lblSenderDate = new Label();
      this.Label5 = new Label();
      this.ComboBox1 = new ComboBox();
      this.ButtonX4 = new ButtonX();
      this.Label1 = new Label();
      this.Timer1 = new System.Windows.Forms.Timer(this.components);
      this.Panel5 = new Panel();
      this.Label4 = new Label();
      this.TabControl1 = new DevComponents.DotNetBar.TabControl();
      this.TabControlPanel1 = new TabControlPanel();
      this.lvwMessages = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.Panel4 = new Panel();
      this.ButtonX5 = new ButtonX();
      this.TabItem1 = new TabItem(this.components);
      this.Panel2.SuspendLayout();
      this.Panel5.SuspendLayout();
      ((ISupportInitialize) this.TabControl1).BeginInit();
      this.TabControl1.SuspendLayout();
      this.TabControlPanel1.SuspendLayout();
      this.Panel4.SuspendLayout();
      this.SuspendLayout();
      this.rtb.Dock = DockStyle.Bottom;
      RichTextBox rtb1 = this.rtb;
      Point point1 = new Point(1, 336);
      Point point2 = point1;
      rtb1.Location = point2;
      this.rtb.Name = "rtb";
      RichTextBox rtb2 = this.rtb;
      Size size1 = new Size(481, 94);
      Size size2 = size1;
      rtb2.Size = size2;
      this.rtb.TabIndex = 17;
      this.rtb.Text = "";
      this.ButtonX2.AccessibleRole = AccessibleRole.PushButton;
      this.ButtonX2.ColorTable = eButtonColor.OrangeWithBackground;
      this.ButtonX2.Dock = DockStyle.Right;
      this.ButtonX2.FocusCuesEnabled = false;
      ButtonX buttonX2_1 = this.ButtonX2;
      point1 = new Point(360, 0);
      Point point3 = point1;
      buttonX2_1.Location = point3;
      this.ButtonX2.Name = "ButtonX2";
      ButtonX buttonX2_2 = this.ButtonX2;
      size1 = new Size(119, 45);
      Size size3 = size1;
      buttonX2_2.Size = size3;
      this.ButtonX2.TabIndex = 19;
      this.ButtonX2.Text = "Delete ALL";
      this.ButtonX1.AccessibleRole = AccessibleRole.PushButton;
      this.ButtonX1.ColorTable = eButtonColor.OrangeWithBackground;
      this.ButtonX1.Dock = DockStyle.Right;
      this.ButtonX1.FocusCuesEnabled = false;
      ButtonX buttonX1_1 = this.ButtonX1;
      point1 = new Point(241, 0);
      Point point4 = point1;
      buttonX1_1.Location = point4;
      this.ButtonX1.Name = "ButtonX1";
      ButtonX buttonX1_2 = this.ButtonX1;
      size1 = new Size(119, 45);
      Size size4 = size1;
      buttonX1_2.Size = size4;
      this.ButtonX1.TabIndex = 17;
      this.ButtonX1.Text = "Delete";
      this.Panel2.Controls.Add((Control) this.lblSenderDate);
      this.Panel2.Controls.Add((Control) this.Label5);
      this.Panel2.Controls.Add((Control) this.ComboBox1);
      this.Panel2.Controls.Add((Control) this.ButtonX4);
      this.Panel2.Controls.Add((Control) this.Label1);
      this.Panel2.Dock = DockStyle.Left;
      Panel panel2_1 = this.Panel2;
      point1 = new Point(0, 40);
      Point point5 = point1;
      panel2_1.Location = point5;
      this.Panel2.Name = "Panel2";
      Panel panel2_2 = this.Panel2;
      size1 = new Size(198, 457);
      Size size5 = size1;
      panel2_2.Size = size5;
      this.Panel2.TabIndex = 17;
      this.lblSenderDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblSenderDate.BorderStyle = BorderStyle.FixedSingle;
      Label lblSenderDate1 = this.lblSenderDate;
      point1 = new Point(12, 435);
      Point point6 = point1;
      lblSenderDate1.Location = point6;
      this.lblSenderDate.Name = "lblSenderDate";
      Label lblSenderDate2 = this.lblSenderDate;
      size1 = new Size(158, 13);
      Size size6 = size1;
      lblSenderDate2.Size = size6;
      this.lblSenderDate.TabIndex = 10;
      this.Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Label5.BackColor = Color.Transparent;
      this.Label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label5.ForeColor = Color.DodgerBlue;
      Label label5_1 = this.Label5;
      point1 = new Point(9, 405);
      Point point7 = point1;
      label5_1.Location = point7;
      this.Label5.Name = "Label5";
      Label label5_2 = this.Label5;
      size1 = new Size(100, 15);
      Size size7 = size1;
      label5_2.Size = size7;
      this.Label5.TabIndex = 8;
      this.Label5.Text = "INCOMMING SMS LOG";
      this.ComboBox1.FormattingEnabled = true;
      ComboBox comboBox1_1 = this.ComboBox1;
      point1 = new Point(12, 39);
      Point point8 = point1;
      comboBox1_1.Location = point8;
      this.ComboBox1.Name = "ComboBox1";
      ComboBox comboBox1_2 = this.ComboBox1;
      size1 = new Size(170, 21);
      Size size8 = size1;
      comboBox1_2.Size = size8;
      this.ComboBox1.TabIndex = 0;
      this.ButtonX4.AccessibleRole = AccessibleRole.PushButton;
      this.ButtonX4.ColorTable = eButtonColor.OrangeWithBackground;
      this.ButtonX4.FocusCuesEnabled = false;
      ButtonX buttonX4_1 = this.ButtonX4;
      point1 = new Point(107, 66);
      Point point9 = point1;
      buttonX4_1.Location = point9;
      this.ButtonX4.Name = "ButtonX4";
      ButtonX buttonX4_2 = this.ButtonX4;
      size1 = new Size(75, 23);
      Size size9 = size1;
      buttonX4_2.Size = size9;
      this.ButtonX4.TabIndex = 7;
      this.ButtonX4.Text = "Connect";
      this.Label1.BackColor = Color.Transparent;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DodgerBlue;
      Label label1_1 = this.Label1;
      point1 = new Point(9, 13);
      Point point10 = point1;
      label1_1.Location = point10;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(100, 23);
      Size size10 = size1;
      label1_2.Size = size10;
      this.Label1.TabIndex = 1;
      this.Label1.Text = "MODEM INFORMATION";
      this.Timer1.Interval = 2000;
      this.Panel5.BorderStyle = BorderStyle.Fixed3D;
      this.Panel5.Controls.Add((Control) this.Label4);
      this.Panel5.Dock = DockStyle.Top;
      Panel panel5_1 = this.Panel5;
      point1 = new Point(0, 0);
      Point point11 = point1;
      panel5_1.Location = point11;
      this.Panel5.Name = "Panel5";
      Panel panel5_2 = this.Panel5;
      size1 = new Size(681, 40);
      Size size11 = size1;
      panel5_2.Size = size11;
      this.Panel5.TabIndex = 19;
      this.Label4.Dock = DockStyle.Fill;
      this.Label4.Font = new Font("Verdana", 11.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label4.ForeColor = SystemColors.GradientActiveCaption;
      Label label4_1 = this.Label4;
      point1 = new Point(0, 0);
      Point point12 = point1;
      label4_1.Location = point12;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(677, 36);
      Size size12 = size1;
      label4_2.Size = size12;
      this.Label4.TabIndex = 0;
      this.Label4.Text = "SMS [VB.net]";
      this.Label4.TextAlign = ContentAlignment.MiddleCenter;
      this.TabControl1.BackColor = Color.FromArgb(194, 217, 247);
      this.TabControl1.CanReorderTabs = true;
      this.TabControl1.Controls.Add((Control) this.TabControlPanel1);
      this.TabControl1.Dock = DockStyle.Fill;
      DevComponents.DotNetBar.TabControl tabControl1_1 = this.TabControl1;
      point1 = new Point(198, 40);
      Point point13 = point1;
      tabControl1_1.Location = point13;
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedTabFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.TabControl1.SelectedTabIndex = 0;
      DevComponents.DotNetBar.TabControl tabControl1_2 = this.TabControl1;
      size1 = new Size(483, 457);
      Size size13 = size1;
      tabControl1_2.Size = size13;
      this.TabControl1.TabIndex = 20;
      this.TabControl1.TabLayoutType = eTabLayoutType.FixedWithNavigationBox;
      this.TabControl1.Tabs.Add(this.TabItem1);
      this.TabControl1.Text = "Sent Items";
      this.TabControlPanel1.Controls.Add((Control) this.lvwMessages);
      this.TabControlPanel1.Controls.Add((Control) this.Panel4);
      this.TabControlPanel1.Controls.Add((Control) this.rtb);
      this.TabControlPanel1.Dock = DockStyle.Fill;
      TabControlPanel tabControlPanel1_1 = this.TabControlPanel1;
      point1 = new Point(0, 26);
      Point point14 = point1;
      tabControlPanel1_1.Location = point14;
      this.TabControlPanel1.Name = "TabControlPanel1";
      this.TabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
      TabControlPanel tabControlPanel1_2 = this.TabControlPanel1;
      size1 = new Size(483, 431);
      Size size14 = size1;
      tabControlPanel1_2.Size = size14;
      this.TabControlPanel1.Style.BackColor1.Color = Color.FromArgb(142, 179, 231);
      this.TabControlPanel1.Style.BackColor2.Color = Color.FromArgb(223, 237, 254);
      this.TabControlPanel1.Style.Border = eBorderType.SingleLine;
      this.TabControlPanel1.Style.BorderColor.Color = Color.FromArgb(59, 97, 156);
      this.TabControlPanel1.Style.BorderSide = eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom;
      this.TabControlPanel1.Style.GradientAngle = 90;
      this.TabControlPanel1.TabIndex = 1;
      this.TabControlPanel1.TabItem = this.TabItem1;
      this.lvwMessages.Columns.AddRange(new ColumnHeader[4]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4
      });
      this.lvwMessages.Dock = DockStyle.Fill;
      this.lvwMessages.FullRowSelect = true;
      this.lvwMessages.GridLines = true;
      this.lvwMessages.HideSelection = false;
      ListView lvwMessages1 = this.lvwMessages;
      point1 = new Point(1, 1);
      Point point15 = point1;
      lvwMessages1.Location = point15;
      this.lvwMessages.MultiSelect = false;
      this.lvwMessages.Name = "lvwMessages";
      ListView lvwMessages2 = this.lvwMessages;
      size1 = new Size(481, 288);
      Size size15 = size1;
      lvwMessages2.Size = size15;
      this.lvwMessages.TabIndex = 19;
      this.lvwMessages.UseCompatibleStateImageBehavior = false;
      this.lvwMessages.View = View.Details;
      this.ColumnHeader1.Text = "Index";
      this.ColumnHeader2.Text = "Sender";
      this.ColumnHeader3.Text = "Message";
      this.ColumnHeader3.Width = 280;
      this.ColumnHeader4.Text = "Date";
      this.Panel4.BorderStyle = BorderStyle.FixedSingle;
      this.Panel4.Controls.Add((Control) this.ButtonX5);
      this.Panel4.Controls.Add((Control) this.ButtonX1);
      this.Panel4.Controls.Add((Control) this.ButtonX2);
      this.Panel4.Dock = DockStyle.Bottom;
      Panel panel4_1 = this.Panel4;
      point1 = new Point(1, 289);
      Point point16 = point1;
      panel4_1.Location = point16;
      this.Panel4.Name = "Panel4";
      Panel panel4_2 = this.Panel4;
      size1 = new Size(481, 47);
      Size size16 = size1;
      panel4_2.Size = size16;
      this.Panel4.TabIndex = 19;
      this.ButtonX5.AccessibleRole = AccessibleRole.PushButton;
      this.ButtonX5.ColorTable = eButtonColor.Flat;
      this.ButtonX5.Dock = DockStyle.Left;
      this.ButtonX5.FocusCuesEnabled = false;
      this.ButtonX5.Image = (Image) SMS_Recieve_New.My.Resources.Resources.refresh;
      ButtonX buttonX5_1 = this.ButtonX5;
      size1 = new Size(32, 32);
      Size size17 = size1;
      buttonX5_1.ImageFixedSize = size17;
      ButtonX buttonX5_2 = this.ButtonX5;
      point1 = new Point(0, 0);
      Point point17 = point1;
      buttonX5_2.Location = point17;
      this.ButtonX5.Name = "ButtonX5";
      ButtonX buttonX5_3 = this.ButtonX5;
      size1 = new Size(80, 45);
      Size size18 = size1;
      buttonX5_3.Size = size18;
      this.ButtonX5.TabIndex = 18;
      this.ButtonX5.Text = "Refresh";
      this.TabItem1.AttachedControl = (Control) this.TabControlPanel1;
      this.TabItem1.Name = "TabItem1";
      this.TabItem1.Text = "Inbox";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(681, 497);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.TabControl1);
      this.Controls.Add((Control) this.Panel2);
      this.Controls.Add((Control) this.Panel5);
      this.DoubleBuffered = true;
      this.Name = nameof (Form1);
      this.Text = "SMS";
      this.Panel2.ResumeLayout(false);
      this.Panel5.ResumeLayout(false);
      ((ISupportInitialize) this.TabControl1).EndInit();
      this.TabControl1.ResumeLayout(false);
      this.TabControlPanel1.ResumeLayout(false);
      this.Panel4.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual Panel Panel2
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel2 = value;
      }
    }

    internal virtual Label Label1
    {
      [DebuggerNonUserCode] get
      {
        return this._Label1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    internal virtual RichTextBox rtb
    {
      [DebuggerNonUserCode] get
      {
        return this._rtb;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._rtb = value;
      }
    }

    internal virtual System.Windows.Forms.Timer Timer1
    {
      [DebuggerNonUserCode] get
      {
        return this._Timer1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Timer1 = value;
      }
    }

    private virtual ButtonX ButtonX2
    {
      [DebuggerNonUserCode] get
      {
        return this._ButtonX2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonX2_Click_1);
        if (this._ButtonX2 != null)
          this._ButtonX2.Click -= eventHandler;
        this._ButtonX2 = value;
        if (this._ButtonX2 == null)
          return;
        this._ButtonX2.Click += eventHandler;
      }
    }

    private virtual ButtonX ButtonX1
    {
      [DebuggerNonUserCode] get
      {
        return this._ButtonX1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonX1_Click_1);
        if (this._ButtonX1 != null)
          this._ButtonX1.Click -= eventHandler;
        this._ButtonX1 = value;
        if (this._ButtonX1 == null)
          return;
        this._ButtonX1.Click += eventHandler;
      }
    }

    private virtual ButtonX ButtonX4
    {
      [DebuggerNonUserCode] get
      {
        return this._ButtonX4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonX4_Click);
        if (this._ButtonX4 != null)
          this._ButtonX4.Click -= eventHandler;
        this._ButtonX4 = value;
        if (this._ButtonX4 == null)
          return;
        this._ButtonX4.Click += eventHandler;
      }
    }

    internal virtual Panel Panel5
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel5;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel5 = value;
      }
    }

    internal virtual Label Label4
    {
      [DebuggerNonUserCode] get
      {
        return this._Label4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label4 = value;
      }
    }

    internal virtual DevComponents.DotNetBar.TabControl TabControl1
    {
      [DebuggerNonUserCode] get
      {
        return this._TabControl1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TabControl1 = value;
      }
    }

    internal virtual TabControlPanel TabControlPanel1
    {
      [DebuggerNonUserCode] get
      {
        return this._TabControlPanel1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TabControlPanel1 = value;
      }
    }

    internal virtual TabItem TabItem1
    {
      [DebuggerNonUserCode] get
      {
        return this._TabItem1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TabItem1 = value;
      }
    }

    internal virtual ListView lvwMessages
    {
      [DebuggerNonUserCode] get
      {
        return this._lvwMessages;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvwMessages_SelectedIndexChanged_1);
        if (this._lvwMessages != null)
          this._lvwMessages.SelectedIndexChanged -= eventHandler;
        this._lvwMessages = value;
        if (this._lvwMessages == null)
          return;
        this._lvwMessages.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ColumnHeader ColumnHeader1
    {
      [DebuggerNonUserCode] get
      {
        return this._ColumnHeader1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader1 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader2
    {
      [DebuggerNonUserCode] get
      {
        return this._ColumnHeader2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader2 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader3
    {
      [DebuggerNonUserCode] get
      {
        return this._ColumnHeader3;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader3 = value;
      }
    }

    internal virtual ColumnHeader ColumnHeader4
    {
      [DebuggerNonUserCode] get
      {
        return this._ColumnHeader4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader4 = value;
      }
    }

    internal virtual Panel Panel4
    {
      [DebuggerNonUserCode] get
      {
        return this._Panel4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Panel4 = value;
      }
    }

    private virtual ButtonX ButtonX5
    {
      [DebuggerNonUserCode] get
      {
        return this._ButtonX5;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ButtonX5_Click_1);
        if (this._ButtonX5 != null)
          this._ButtonX5.Click -= eventHandler;
        this._ButtonX5 = value;
        if (this._ButtonX5 == null)
          return;
        this._ButtonX5.Click += eventHandler;
      }
    }

    internal virtual ComboBox ComboBox1
    {
      [DebuggerNonUserCode] get
      {
        return this._ComboBox1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboBox1_SelectedIndexChanged);
        if (this._ComboBox1 != null)
          this._ComboBox1.SelectedIndexChanged -= eventHandler;
        this._ComboBox1 = value;
        if (this._ComboBox1 == null)
          return;
        this._ComboBox1.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblSenderDate
    {
      [DebuggerNonUserCode] get
      {
        return this._lblSenderDate;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lblSenderDate_TextChanged);
        if (this._lblSenderDate != null)
          this._lblSenderDate.TextChanged -= eventHandler;
        this._lblSenderDate = value;
        if (this._lblSenderDate == null)
          return;
        this._lblSenderDate.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label5
    {
      [DebuggerNonUserCode] get
      {
        return this._Label5;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label5 = value;
      }
    }

    public Form1()
    {
      this.Load += new EventHandler(this.Form1_Load);
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
      this.TextChanged += new EventHandler(this.Form1_TextChanged);
      Form1.__ENCAddToList((object) this);
      this.bStopRead = false;
      this.serialport = new SerialPort();
      this.InitializeComponent();
      this.port = (SerialPort) null;
      this.receiveNow = new AutoResetEvent(false);
    }

    private virtual SerialPort serialport
    {
      [DebuggerNonUserCode] get
      {
        return this._serialport;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._serialport = value;
      }
    }

    private void DisplayMessages(ShortMessageCollection messages, int opt)
    {
      this.lvwMessages.BeginUpdate();
      List<ShortMessage>.Enumerator enumerator;
      try
      {
        enumerator = messages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          ShortMessage current = enumerator.Current;
          ListViewItem listViewItem = new ListViewItem(new string[5]
          {
            Conversions.ToString(current.Index),
            current.Sender,
            current.Message,
            current.Sent,
            current.Status
          });
          listViewItem.Tag = (object) current;
          if (opt == 1)
            this.lvwMessages.Items.Add(listViewItem);
          else if (!this.msgExist(current.Index))
            this.lblSenderDate.Text = current.Sent;
        }
      }
      finally
      {
        enumerator.Dispose();
      }
      this.lvwMessages.EndUpdate();
    }

    private void ReadSMS()
    {
      while (!this.bStopRead)
      {
        this.display1();
        Thread.Sleep(3000);
      }
    }

    private ShortMessageCollection ParseMessages(string input)
    {
      ShortMessageCollection messageCollection = new ShortMessageCollection();
      for (Match match = new Regex("\\+CMGL: (\\d+),\"(.+)\",\"(.+)\",(.*),\"(.+)\"\\r\\n(.+)\\r\\n").Match(input); match.Success; match = match.NextMatch())
        messageCollection.Add(new ShortMessage()
        {
          Index = int.Parse(match.Groups[1].Value),
          Status = match.Groups[2].Value,
          Sender = match.Groups[3].Value,
          Alphabet = match.Groups[4].Value,
          Sent = match.Groups[5].Value,
          Message = match.Groups[6].Value
        });
      return messageCollection;
    }

    private SerialPort OpenPort(string portName)
    {
      SerialPort serialPort = new SerialPort();
      serialPort.PortName = portName;
      serialPort.BaudRate = 19200;
      serialPort.DataBits = 8;
      serialPort.StopBits = StopBits.One;
      serialPort.Parity = Parity.None;
      serialPort.ReadTimeout = 300;
      serialPort.WriteTimeout = 300;
      serialPort.Encoding = Encoding.GetEncoding("iso-8859-1");
      serialPort.DataReceived += new SerialDataReceivedEventHandler(this.port_DataReceived);
      serialPort.Open();
      serialPort.DtrEnable = true;
      serialPort.RtsEnable = true;
      return serialPort;
    }

    private void ClosePort(SerialPort port)
    {
      try
      {
        port.Close();
        port.DataReceived -= new SerialDataReceivedEventHandler(this.port_DataReceived);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (e.EventType != SerialData.Chars)
        return;
      this.receiveNow.Set();
    }

    private string ReadResponse(int timeout)
    {
      string empty = string.Empty;
      while (this.receiveNow.WaitOne(timeout, false))
      {
        string str = this.port.ReadExisting();
        empty += str;
        if (empty.EndsWith("\r\nOK\r\n") || empty.EndsWith("\r\nERROR\r\n"))
          return empty;
      }
      if (empty.Length > 0)
        throw new ApplicationException("Response received is incomplete.");
      throw new ApplicationException("No data received from phone.");
    }

    private string ExecCommand(string command, int responseTimeout, string errorMessage)
    {
      try
      {
        this.port.DiscardOutBuffer();
        this.port.DiscardInBuffer();
        this.receiveNow.Reset();
        this.port.Write(command + "\r");
        string str = this.ReadResponse(responseTimeout);
        if (str.Length == 0 || !str.EndsWith("\r\nOK\r\n"))
          throw new ApplicationException("No success message was received.");
        return str;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception innerException = ex;
        throw new ApplicationException(errorMessage, innerException);
      }
    }

    private void displayAllMessage()
    {
      string cmport = this.cmport;
      if (cmport.Length == 0)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, "You must enter a port name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        this.lvwMessages.Items.Clear();
        this.Update();
        ShortMessageCollection messages = (ShortMessageCollection) null;
        try
        {
          this.port = this.OpenPort(cmport);
          Cursor.Current = Cursors.WaitCursor;
          this.ExecCommand("AT", 300, "No phone connected at " + cmport + ".");
          this.ExecCommand("AT+CMGF=1", 300, "Failed to set message format.");
          this.ExecCommand("AT+CSCS=\"IRA\"", 300, "Failed to set character set.");
          this.ExecCommand("AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
          messages = this.ParseMessages(this.ExecCommand("AT+CMGL=\"ALL\"", 5000, "Failed to read the messages."));
          Cursor.Current = Cursors.Default;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Cursor.Current = Cursors.Default;
          ProjectData.ClearProjectError();
          return;
        }
        finally
        {
          if (this.port != null)
          {
            this.ClosePort(this.port);
            this.port = (SerialPort) null;
          }
        }
        if (messages != null)
          this.DisplayMessages(messages, 1);
      }
    }

    private void display1()
    {
      string cmport = this.cmport;
      if (cmport.Length == 0)
      {
        int num = (int) MessageBox.Show((IWin32Window) this, "You must enter a port name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        this.Update();
        ShortMessageCollection messages = (ShortMessageCollection) null;
        try
        {
          this.port = this.OpenPort(cmport);
          Cursor.Current = Cursors.WaitCursor;
          this.ExecCommand("AT", 300, "No phone connected at " + cmport + ".");
          this.ExecCommand("AT+CMGF=1", 300, "Failed to set message format.");
          this.ExecCommand("AT+CSCS=\"IRA\"", 300, "Failed to set character set.");
          this.ExecCommand("AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
          messages = this.ParseMessages(this.ExecCommand("AT+CMGL=\"REC UNREAD\"", 5000, "Failed to read the messages."));
          Cursor.Current = Cursors.Default;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Cursor.Current = Cursors.Default;
          ProjectData.ClearProjectError();
          return;
        }
        finally
        {
          if (this.port != null)
          {
            this.ClosePort(this.port);
            this.port = (SerialPort) null;
          }
        }
        if (messages != null)
          this.DisplayMessages(messages, 0);
      }
    }

    public void GetSerialPortNames()
    {
      IEnumerator<string> enumerator;
      try
      {
        enumerator = MyProject.Computer.Ports.SerialPortNames.GetEnumerator();
        while (enumerator.MoveNext())
          this.ComboBox1.Items.Add((object) enumerator.Current);
      }
      finally
      {
        enumerator?.Dispose();
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Control.CheckForIllegalCrossThreadCalls = false;
      this.GetSerialPortNames();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        this.bStopRead = true;
        this.thread.Abort();
        this.serialport.Close();
        this.serialport.Dispose();
        this.Dispose();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void Form1_TextChanged(object sender, EventArgs e)
    {
      try
      {
        Process[] processesByName = Process.GetProcessesByName("VISUALSTYLES");
        int index = 0;
        while (index < processesByName.Length)
        {
          processesByName[index].Kill();
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void ButtonX5_Click(object sender, EventArgs e)
    {
    }

    private void ButtonX1_Click_1(object sender, EventArgs e)
    {
      if (this.lvwMessages.Items.Count != 0)
      {
        string cmport = this.cmport;
        if (cmport.Length == 0)
        {
          int num1 = (int) MessageBox.Show((IWin32Window) this, "You must enter a port name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          ShortMessageCollection messageCollection = (ShortMessageCollection) null;
          try
          {
            this.port = this.OpenPort(cmport);
            Cursor.Current = Cursors.WaitCursor;
            this.ExecCommand("AT", 300, "No phone connected at " + cmport + ".");
            this.ExecCommand("AT+CMGD=" + this.selected, 300, "No phone connected at " + cmport + ".");
            this.ExecCommand("AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
            messageCollection = this.ParseMessages(this.ExecCommand("AT+CMGL=\"ALL\"", 5000, "Failed to read the messages."));
            Cursor.Current = Cursors.Default;
            try
            {
              foreach (ListViewItem selectedItem in this.lvwMessages.SelectedItems)
                this.lvwMessages.Items.Remove(selectedItem);
            }
            finally
            {
              IEnumerator enumerator;
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            Cursor.Current = Cursors.Default;
            int num2 = (int) MessageBox.Show((IWin32Window) this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            return;
          }
          finally
          {
            if (this.port != null)
            {
              this.ClosePort(this.port);
              this.port = (SerialPort) null;
            }
          }
          this.display1();
        }
      }
    }

    private void ButtonX2_Click_1(object sender, EventArgs e)
    {
      if (this.lvwMessages.Items.Count != 0)
      {
        string cmport = this.cmport;
        if (cmport.Length == 0)
        {
          int num = (int) MessageBox.Show((IWin32Window) this, "You must enter a port name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          ShortMessageCollection messageCollection = (ShortMessageCollection) null;
          try
          {
            this.port = this.OpenPort(cmport);
            Cursor.Current = Cursors.WaitCursor;
            this.ExecCommand("AT", 300, "No phone connected at " + cmport + ".");
            try
            {
              try
              {
                foreach (ListViewItem listViewItem in this.lvwMessages.Items)
                {
                  this.ExecCommand("AT+CMGD=" + listViewItem.Text.ToString(), 300, "No phone connected at " + cmport + ".");
                  this.lvwMessages.Items.Remove(listViewItem);
                }
              }
              finally
              {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              ProjectData.ClearProjectError();
            }
            this.ExecCommand("AT+CPMS=\"SM\"", 300, "Failed to select message storage.");
            messageCollection = this.ParseMessages(this.ExecCommand("AT+CMGL=\"ALL\"", 5000, "Failed to read the messages."));
            Cursor.Current = Cursors.Default;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Cursor.Current = Cursors.Default;
            ProjectData.ClearProjectError();
            return;
          }
          finally
          {
            if (this.port != null)
            {
              this.ClosePort(this.port);
              this.port = (SerialPort) null;
            }
          }
          this.display1();
        }
      }
    }

    private void ButtonX4_Click(object sender, EventArgs e)
    {
      if (Operators.CompareString(this.ButtonX4.Text, "Connect", false) == 0)
      {
        if (Operators.CompareString(this.ComboBox1.Text, "", false) != 0)
        {
          this.displayAllMessage();
          this.ButtonX4.Text = "Disconnect";
          this.thread = new Thread(new ThreadStart(this.ReadSMS));
          this.thread.Start();
        }
        else
        {
          int num = (int) Interaction.MsgBox((object) "Invalid Comport", MsgBoxStyle.OkOnly, (object) null);
        }
      }
      else
      {
        this.bStopRead = true;
        this.ClosePort(this.port);
        this.Close();
      }
    }

    private void lvwMessages_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      if (this.lvwMessages.SelectedItems.Count != 0)
      {
        ListViewItem selectedItem = this.lvwMessages.SelectedItems[0];
        this.selected = selectedItem.SubItems[0].Text;
        this.rtb.Text = "FROM: " + selectedItem.SubItems[1].Text + "\r\nMessage: " + selectedItem.SubItems[2].Text;
      }
      else
        this.selected = "";
    }

    private void ButtonX5_Click_1(object sender, EventArgs e)
    {
      this.display1();
    }

    private bool msgExist(int iIndex)
    {
      bool flag = false;
      try
      {
        try
        {
          foreach (ListViewItem listViewItem in this.lvwMessages.Items)
          {
            if (Conversions.ToInteger(listViewItem.Text) == iIndex)
              return true;
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.cmport = Conversions.ToString(this.ComboBox1.SelectedItem);
    }

    private void lblSenderDate_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(this.sCurrMessage, this.lblSenderDate.Text, false) != 0)
      {
        this.displayAllMessage();
        this.PlayBackgroundSoundFile();
      }
      this.sCurrMessage = this.lblSenderDate.Text;
    }

    public void PlayBackgroundSoundFile()
    {
      MyProject.Computer.Audio.Play("correct.wav", AudioPlayMode.Background);
    }
  }
}
