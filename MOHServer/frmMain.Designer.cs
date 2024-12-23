using System;
using System.Drawing;
using System.Windows.Forms;

namespace MOHServer
{
	// Token: 0x0200000B RID: 11
	public partial class frmMain : global::System.Windows.Forms.Form
	{



		// Token: 0x06000064 RID: 100 RVA: 0x000052AC File Offset: 0x000042AC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			this.notifyIcon.Dispose();
			base.Dispose(disposing);
		}

        private UPnPPortMapper portMapper;



		// Token: 0x06000065 RID: 101 RVA: 0x000052E4 File Offset: 0x000042E4
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.cntxtMenuTxtLog = new System.Windows.Forms.ContextMenu();
            this.menuItemCntxtCopy = new System.Windows.Forms.MenuItem();
            this.menuItemCntxtClear = new System.Windows.Forms.MenuItem();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemSettings = new System.Windows.Forms.MenuItem();
            this.menuItemAcctSettings = new System.Windows.Forms.MenuItem();
            this.menuItemGameSettings = new System.Windows.Forms.MenuItem();
            this.menuItemMapList = new System.Windows.Forms.MenuItem();
            this.menuItemServerSettings = new System.Windows.Forms.MenuItem();
            this.menuItemAutoRestart = new System.Windows.Forms.MenuItem();
            this.menuItemEAServerMode = new System.Windows.Forms.MenuItem();
            this.menuItemUPNPAttempt = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemEditCopy = new System.Windows.Forms.MenuItem();
            this.menuItemEditClear = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemHelpAbout = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntxtMenuNotifyIcon = new System.Windows.Forms.ContextMenu();
            this.menuItemCntxtShow = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemCntxtExit = new System.Windows.Forms.MenuItem();
            this.tabCntrl = new System.Windows.Forms.TabControl();
            this.tabPgLog = new System.Windows.Forms.TabPage();
            this.tabPgStats = new System.Windows.Forms.TabPage();
            this.gridLeaderboard = new System.Windows.Forms.DataGrid();
            this.defaultGridStyle = new System.Windows.Forms.DataGridTableStyle();
            this.colName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colKills = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colDeaths = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabCntrl.SuspendLayout();
            this.tabPgLog.SuspendLayout();
            this.tabPgStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaderboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGo.Location = new System.Drawing.Point(8, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(256, 56);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "GO!";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStop.Location = new System.Drawing.Point(272, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(280, 56);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "STOP!";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtLog
            // 
            this.txtLog.ContextMenu = this.cntxtMenuTxtLog;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Lucida Console", 6.75F);
            this.txtLog.ForeColor = System.Drawing.Color.Silver;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.MaxLength = 0;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(536, 318);
            this.txtLog.TabIndex = 7;
            this.txtLog.Text = "";
            this.txtLog.WordWrap = false;
            // 
            // cntxtMenuTxtLog
            // 
            this.cntxtMenuTxtLog.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCntxtCopy,
            this.menuItemCntxtClear});
            // 
            // menuItemCntxtCopy
            // 
            this.menuItemCntxtCopy.Index = 0;
            this.menuItemCntxtCopy.Text = "$MNU_Copy";
            this.menuItemCntxtCopy.Click += new System.EventHandler(this.menuItemEditCopy_Click);
            // 
            // menuItemCntxtClear
            // 
            this.menuItemCntxtClear.Index = 1;
            this.menuItemCntxtClear.Text = "$MNU_Clear";
            this.menuItemCntxtClear.Click += new System.EventHandler(this.menuItemEditClear_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSettings,
            this.menuItemEdit,
            this.menuItemHelp});
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Index = 0;
            this.menuItemSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAcctSettings,
            this.menuItemGameSettings,
            this.menuItemMapList,
            this.menuItemServerSettings,
            this.menuItemAutoRestart,
            this.menuItemEAServerMode,
            this.menuItemUPNPAttempt});
            this.menuItemSettings.Text = "Settings";
            // 
            // menuItemAcctSettings
            // 
            this.menuItemAcctSettings.Index = 0;
            this.menuItemAcctSettings.Text = "Account Settings...";
            this.menuItemAcctSettings.Click += new System.EventHandler(this.menuItemAcctSettings_Click);
            // 
            // menuItemGameSettings
            // 
            this.menuItemGameSettings.Index = 1;
            this.menuItemGameSettings.Text = "Game Creation Settings...";
            this.menuItemGameSettings.Click += new System.EventHandler(this.menuItemGameSettings_Click);
            // 
            // menuItemMapList
            // 
            this.menuItemMapList.Index = 2;
            this.menuItemMapList.Text = "Map List..";
            this.menuItemMapList.Click += new System.EventHandler(this.menuItemMapList_Click);
            // 
            // menuItemServerSettings
            // 
            this.menuItemServerSettings.Index = 3;
            this.menuItemServerSettings.Text = "Server Settings...";
            this.menuItemServerSettings.Click += new System.EventHandler(this.menuItemServerSettings_Click);
            // 
            // menuItemAutoRestart
            // 
            this.menuItemAutoRestart.Index = 4;
            this.menuItemAutoRestart.Text = "Enable Autorestart";
            this.menuItemAutoRestart.Click += new System.EventHandler(this.AutorestartClick);
            // 
            // menuItemEAServerMode
            // 
            this.menuItemEAServerMode.Index = 5;
            this.menuItemEAServerMode.Text = "EA Server Mode";
            // 
            // menuItemUPNPAttempt
            // 
            this.menuItemUPNPAttempt.Index = 6;
            this.menuItemUPNPAttempt.Text = "UPnP Port-Forward";
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemEditCopy,
            this.menuItemEditClear});
            this.menuItemEdit.Text = "Edit";
            // 
            // menuItemEditCopy
            // 
            this.menuItemEditCopy.Index = 0;
            this.menuItemEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuItemEditCopy.Text = "Copy";
            this.menuItemEditCopy.Click += new System.EventHandler(this.menuItemEditCopy_Click);
            // 
            // menuItemEditClear
            // 
            this.menuItemEditClear.Index = 1;
            this.menuItemEditClear.Text = "Clear";
            this.menuItemEditClear.Click += new System.EventHandler(this.menuItemEditClear_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 2;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemHelpAbout});
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemHelpAbout
            // 
            this.menuItemHelpAbout.Index = 0;
            this.menuItemHelpAbout.Text = "About";
            this.menuItemHelpAbout.Click += new System.EventHandler(this.menuItemHelpAbout_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenu = this.cntxtMenuNotifyIcon;
            this.notifyIcon.Text = "$CMN_Title";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cntxtMenuNotifyIcon
            // 
            this.cntxtMenuNotifyIcon.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCntxtShow,
            this.menuItem4,
            this.menuItemCntxtExit});
            // 
            // menuItemCntxtShow
            // 
            this.menuItemCntxtShow.Index = 0;
            this.menuItemCntxtShow.Text = "$MNU_Show";
            this.menuItemCntxtShow.Click += new System.EventHandler(this.menuItemCntxtShow_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // menuItemCntxtExit
            // 
            this.menuItemCntxtExit.Index = 2;
            this.menuItemCntxtExit.Text = "$MNU_Exit";
            this.menuItemCntxtExit.Click += new System.EventHandler(this.menuItemCntxtExit_Click);
            // 
            // tabCntrl
            // 
            this.tabCntrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCntrl.Controls.Add(this.tabPgLog);
            this.tabCntrl.Controls.Add(this.tabPgStats);
            this.tabCntrl.ItemSize = new System.Drawing.Size(64, 18);
            this.tabCntrl.Location = new System.Drawing.Point(8, 72);
            this.tabCntrl.Name = "tabCntrl";
            this.tabCntrl.SelectedIndex = 0;
            this.tabCntrl.ShowToolTips = true;
            this.tabCntrl.Size = new System.Drawing.Size(544, 344);
            this.tabCntrl.TabIndex = 8;
            // 
            // tabPgLog
            // 
            this.tabPgLog.Controls.Add(this.txtLog);
            this.tabPgLog.Location = new System.Drawing.Point(4, 22);
            this.tabPgLog.Name = "tabPgLog";
            this.tabPgLog.Size = new System.Drawing.Size(536, 318);
            this.tabPgLog.TabIndex = 0;
            this.tabPgLog.Text = "$CMN_ServerLog";
            this.tabPgLog.ToolTipText = "$CMN_LogToolTip";
            // 
            // tabPgStats
            // 
            this.tabPgStats.Controls.Add(this.gridLeaderboard);
            this.tabPgStats.Location = new System.Drawing.Point(4, 22);
            this.tabPgStats.Name = "tabPgStats";
            this.tabPgStats.Size = new System.Drawing.Size(536, 318);
            this.tabPgStats.TabIndex = 1;
            this.tabPgStats.Text = "Leaderboard";
            this.tabPgStats.ToolTipText = "$CMN_StatsToolTip";
            // 
            // gridLeaderboard
            // 
            this.gridLeaderboard.AllowNavigation = false;
            this.gridLeaderboard.DataMember = "";
            this.gridLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeaderboard.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.gridLeaderboard.Name = "gridLeaderboard";
            this.gridLeaderboard.RowHeadersVisible = false;
            this.gridLeaderboard.Size = new System.Drawing.Size(536, 318);
            this.gridLeaderboard.TabIndex = 0;
            this.gridLeaderboard.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.defaultGridStyle});
            // 
            // defaultGridStyle
            // 
            this.defaultGridStyle.DataGrid = this.gridLeaderboard;
            this.defaultGridStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.colName,
            this.colKills,
            this.colDeaths,
            this.colScore});
            this.defaultGridStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.defaultGridStyle.MappingName = "player";
            // 
            // colName
            // 
            this.colName.Format = "";
            this.colName.FormatInfo = null;
            this.colName.HeaderText = "$CMN_Name";
            this.colName.MappingName = "name";
            this.colName.Width = 75;
            // 
            // colKills
            // 
            this.colKills.Format = "";
            this.colKills.FormatInfo = null;
            this.colKills.HeaderText = "$CMN_Kills";
            this.colKills.MappingName = "kills";
            this.colKills.Width = 75;
            // 
            // colDeaths
            // 
            this.colDeaths.Format = "";
            this.colDeaths.FormatInfo = null;
            this.colDeaths.HeaderText = "$CMN_Deaths";
            this.colDeaths.MappingName = "deaths";
            this.colDeaths.Width = 75;
            // 
            // colScore
            // 
            this.colScore.Format = "";
            this.colScore.FormatInfo = null;
            this.colScore.HeaderText = "$CMN_Score";
            this.colScore.MappingName = "score";
            this.colScore.Width = 75;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 421);
            this.Controls.Add(this.tabCntrl);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnGo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.Name = "frmMain";
            this.Text = " ";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabCntrl.ResumeLayout(false);
            this.tabPgLog.ResumeLayout(false);
            this.tabPgStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaderboard)).EndInit();
            this.ResumeLayout(false);

		}

        private void AttemptUPNP(object sender, EventArgs e)
        {
            if (portMapper == null)
            {
                portMapper = new UPnPPortMapper();
            }

            portMapper.Initialize();

            int second_port = this.m_port + 30;
            bool success1 = portMapper.AddPortMapping(this.m_port, this.m_port, "TCP", "MOHH Game Server");
            bool success2 = portMapper.AddPortMapping(second_port, this.m_port + 30, "TCP", "MOHH Game Server");

            WriteStreamInfo("Attempted to port forward " + this.m_port + " and " + second_port, Color.DarkOliveGreen, FontStyle.Bold);

            string portMappingList = "Current port mappings:\n";
            foreach (UPnPPortMapper.PortMapping portMapping in portMapper.GetPortMappings())
            {
                portMappingList += portMapping.ToString();
            }

            WriteStreamInfo(portMappingList, Color.DarkGreen, FontStyle.Regular);


        }

        private void MenuItemEAServerMode_Click(object sender, EventArgs e)
        {
            this.m_easerver = !m_easerver;
            this.menuItemEAServerMode.Checked = m_easerver;
        }

        private void AutorestartClick(object sender, EventArgs e)
        {
            this.menuItemAutoRestart.Checked = !this.menuItemAutoRestart.Checked;
            this.m_autoRestart = menuItemAutoRestart.Checked;
            this.SaveSettings();
        }

        // Token: 0x0400005D RID: 93
        private global::System.Windows.Forms.Button btnGo;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Button btnStop;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.RichTextBox txtLog;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.MainMenu mainMenu;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.MenuItem menuItemSettings;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.MenuItem menuItemAcctSettings;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.MenuItem menuItemGameSettings;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.MenuItem menuItemEdit;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.MenuItem menuItemEditCopy;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.MenuItem menuItemEditClear;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.ContextMenu cntxtMenuTxtLog;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.MenuItem menuItemCntxtClear;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.MenuItem menuItemCntxtCopy;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.MenuItem menuItemHelp;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.MenuItem menuItemHelpAbout;

		// Token: 0x0400006C RID: 108
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.NotifyIcon notifyIcon;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.ContextMenu cntxtMenuNotifyIcon;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.MenuItem menuItem4;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.MenuItem menuItemCntxtShow;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.MenuItem menuItemCntxtExit;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.MenuItem menuItemServerSettings;
        private MenuItem menuItemAutoRestart;
        private MenuItem menuItemEAServerMode;

        // Token: 0x04000073 RID: 115
        private global::System.Windows.Forms.TabControl tabCntrl;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.TabPage tabPgLog;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.TabPage tabPgStats;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.MenuItem menuItemMapList;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.DataGridTableStyle defaultGridStyle;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.DataGridTextBoxColumn colName;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.DataGridTextBoxColumn colKills;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.DataGridTextBoxColumn colDeaths;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.DataGridTextBoxColumn colScore;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.DataGrid gridLeaderboard;
        private MenuItem menuItemUPNPAttempt;
    }
}
