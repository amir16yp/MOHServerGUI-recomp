using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using MOHServer.Text;

namespace MOHServer
{



	// Token: 0x0200000B RID: 11
	public partial class frmMain : Form
	{
		public static ServerLogHandler m_logHandler = new ServerLogHandler();

		public frmMain()
		{
			this.InitializeComponent();
			Database.ScanAndReplaceStringIds(this);
			this.notifyIcon.Text = Database.GetString("CMN_Title");
			Database.ScanAndReplaceStringIds(this.cntxtMenuNotifyIcon);
			Database.ScanAndReplaceStringIds(this.cntxtMenuTxtLog);
			this.m_processStarter = null;
			this.m_statsFileWatcher = new FileSystemWatcher();
			this.m_statsFileWatcher.Path = this.ServerPath;
			this.m_statsFileWatcher.Filter = "stats.xml";
			this.m_statsFileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess;
			this.m_statsFileWatcher.Changed += this.StatsChanged;
			this.m_statsFileWatcher.EnableRaisingEvents = true;
			this.m_statsUpdateThreadExec = new ThreadStart(this.UpdateStats);
			this.m_statsUpdateInvoker = new frmMain.StatsUpdateDelegate(this.BindStatsToDataGrid);
			this.m_selectedMaps = new ArrayList();
			this.LoadSettings();
			this.m_startingGame = false;

		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && this.btnStop.Enabled)
			{
				// If server is running, minimize instead of close
				e.Cancel = true;
				this.WindowState = FormWindowState.Minimized;
				return;
			}

			// Original closing logic
			if (this.m_processStarter != null)
			{
				this.m_processStarter.CancelAndWait();
			}

			if (m_logHandler != null)
			{
				m_logHandler.Dispose();
			}

			this.SaveSettings();
		}



		// Token: 0x06000066 RID: 102 RVA: 0x00005F7C File Offset: 0x00004F7C
		[STAThread]
		private static void Main()
		{
			Application.Run(new frmMain());
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005F94 File Offset: 0x00004F94
		private void UpdateStats()
		{
			this.m_statsUpdateMutex.WaitOne();
			try
			{
				if (File.Exists(this.ServerPath + "stats.xml"))
				{
					DataSet dataSet = new DataSet();
					Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MOHServer.stats.xsd");
					dataSet.ReadXmlSchema(manifestResourceStream);
					dataSet.ReadXml(this.ServerPath + "stats.xml");
					DataView dataView = new DataView(dataSet.Tables[0]);
					dataView.Sort = "score DESC";
					dataView.AllowDelete = false;
					dataView.AllowEdit = false;
					dataView.AllowNew = false;
					base.BeginInvoke(this.m_statsUpdateInvoker, new object[] { dataSet, dataView });
				}
			}
			catch (IOException)
			{
			}
			catch (ConstraintException)
			{
			}
			finally
			{
				this.m_statsUpdateMutex.ReleaseMutex();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000060AC File Offset: 0x000050AC
		private void BindStatsToDataGrid(DataSet dataSet, DataView dataView)
		{
			this.gridLeaderboard.DataSource = dataView;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000060C8 File Offset: 0x000050C8
		private void StatsChanged(object source, FileSystemEventArgs e)
		{
			this.m_statsUpdateThread = new Thread(this.m_statsUpdateThreadExec);
			this.m_statsUpdateThread.Name = "Stats Update Thread";
			this.m_statsUpdateThread.IsBackground = true;
			this.m_statsUpdateThread.Start();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006110 File Offset: 0x00005110
		private Color GetTextColorFromText(string text)
		{
			Color color = Color.DarkGray;
			if (text.StartsWith("ERROR:"))
			{
				color = Color.Red;
			}
			else if (text.StartsWith("WARNING:"))
			{
				color = Color.OrangeRed;
			}
			else if (text.StartsWith("ADMIN:"))
			{
				color = Color.Purple;
			}
			else if (text.StartsWith("VOTE:"))
			{
				color = Color.Olive;
			}
			else if (text.StartsWith("SYSTEM:"))
			{
				color = Color.DarkGreen;
			}
			else if (text.StartsWith("PLAYER:"))
			{
				color = Color.Blue;
			}
			return color;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000061A0 File Offset: 0x000051A0
		private FontStyle GetTextStyleFromText(string text)
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (text.StartsWith("ERROR:") || text.StartsWith("WARNING:"))
			{
				fontStyle = FontStyle.Bold;
			}
			else if (text.StartsWith("SYSTEM:"))
			{
				fontStyle = FontStyle.Italic;
			}
			return fontStyle;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000061E0 File Offset: 0x000051E0
		private void WriteStreamInfo(string text, Color c, FontStyle style)
		{
			this.txtLog.Focus();
			this.txtLog.AppendText("[ " + DateTime.Now.ToString("T") + " ] ");
			this.txtLog.SelectionColor = c;
			this.txtLog.SelectionFont = new Font(this.txtLog.Font.FontFamily, this.txtLog.Font.Size, style);
			this.txtLog.AppendText(text + "\r\n");
			this.txtLog.ScrollToCaret();

			// Add file logging
			m_logHandler.LogMessage(text, c, style);
		}

        // Token: 0x0600006D RID: 109 RVA: 0x00006284 File Offset: 0x00005284
        private void WriteOutStreamInfo(object sender, DataReceivedEventArgs e)
        {
            Color textColorFromText = this.GetTextColorFromText(e.Text);
            FontStyle textStyleFromText = this.GetTextStyleFromText(e.Text);
            var match = System.Text.RegularExpressions.Regex.Match(e.Text, @"\b\d{3}\b");

            string text = e.Text;
            if (match.Success)
            {
                string mapName = Database.GetString("MAP_" + match.Value);
                if (!string.IsNullOrEmpty(mapName))
                {
                    text = e.Text + " (" + mapName + ")";
                }
            }

            this.WriteStreamInfo(text, textColorFromText, textStyleFromText);
        }

        // Token: 0x0600006E RID: 110 RVA: 0x000062BC File Offset: 0x000052BC
        private void WriteErrStreamInfo(object sender, DataReceivedEventArgs e)
		{
			if (e.Text.StartsWith("Press CTRL-C "))
			{
				this.btnStop_Click(sender, e);
				return;
			}
			this.WriteStreamInfo(e.Text, Color.Red, FontStyle.Bold);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000062F8 File Offset: 0x000052F8
		private void ProcessCompletedOrCancelled()
		{
			this.Cursor = Cursors.Default;
			this.btnGo.Enabled = true;
			this.btnStop.Enabled = false;
			this.menuItemSettings.Enabled = true;
			this.notifyIcon.Text = Database.GetString("CMN_Title");
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000634C File Offset: 0x0000534C
		private void ProcessCompleted(object sender, EventArgs e)
		{
			this.WriteStreamInfo(Database.GetString("CMN_ServerExited"), Color.Green, FontStyle.Italic);

			if (this.m_autoRestart)
			{
				this.WriteStreamInfo("AUTO_RESTART enabled - Restarting server...", Color.Green, FontStyle.Italic);
				// Small delay before restart to prevent rapid cycling if there's an immediate crash
				Thread.Sleep(5000);
				this.StartServer();
			}
			else
			{
				this.ProcessCompletedOrCancelled();
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00006378 File Offset: 0x00005378
		private void ProcessCancelled(object sender, EventArgs e)
		{
			this.WriteStreamInfo(Database.GetString("CMN_ServerStopped"), Color.Green, FontStyle.Italic);
			this.ProcessCompletedOrCancelled();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000063A4 File Offset: 0x000053A4
		private void ProcessFailed(object sender, ThreadExceptionEventArgs e)
		{
			this.WriteStreamInfo(string.Format(Database.GetString("CMN_FailedToStart"), e.Exception.Message), Color.DarkRed, FontStyle.Bold);
			this.ProcessCompletedOrCancelled();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000063E0 File Offset: 0x000053E0
		private void BuildArguments(out string args)
		{
			// Build the actual arguments
			args = "-name:" + this.m_accountName;
			args = args + " -pwd:" + this.m_accountPassword;
			args = args + " -port:" + this.m_port;
			args += " -logging";
			if (this.m_isAdministrated)
			{
				args = args + " -adminPwd:" + this.m_adminPassword;
			}
			args = args + " -gname:" + this.m_gameName;
			if (this.m_isRanked)
			{
				args += " -ranked";
			}
			if (this.m_isPasswordProtected)
			{
				args = args + " -gpwd:" + this.m_gamePassword;
			}
			string text = args;
			string text2 = " -ff:";
			int friendlyFire = (int)this.m_friendlyFire;
			args = text + text2 + friendlyFire.ToString();
			if (this.m_aimAssist == frmGameCreation.AimAssistType.Enabled)
			{
				args += " -aa";
			}
			args = args + " -maxPlayers:" + this.m_maxPlayers;
			args += " -mapList:";
			foreach (object obj in this.m_selectedMaps)
			{
				int num = (int)obj;
				args = args + num.ToString() + ",";
			}
			args = args + " -rounds:" + this.m_roundsPerMap;
			args = args + " -DMLimit:" + this.m_DMLimit;
			args = args + " -INFLimit:" + this.m_INFLimit;
			args = args + " -HTLLimit:" + this.m_HTLLimit;
			args = args + " -BLLimit:" + this.m_BLLimit;
			if (this.m_roundTime != -1)
			{
				args = args + " -timeLimit:" + this.m_roundTime;
			}
			args += " -skipporttest";
			if (this.m_easerver)
			{
				args += " -easerver";
			}

			// Create censored version for logging
			string censoredArgs = args;
			// Censor account password
			censoredArgs = censoredArgs.Replace("-pwd:" + this.m_accountPassword, "-pwd:****");
			// Censor admin password if present
			if (this.m_isAdministrated)
			{
				censoredArgs = censoredArgs.Replace("-adminPwd:" + this.m_adminPassword, "-adminPwd:****");
			}
			// Censor game password if present
			if (this.m_isPasswordProtected)
			{
				censoredArgs = censoredArgs.Replace("-gpwd:" + this.m_gamePassword, "-gpwd:****");
			}

			WriteStreamInfo("mohz.exe " + censoredArgs, Color.DarkGreen, FontStyle.Bold);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000065FC File Offset: 0x000055FC
		private void SaveSettings()
		{
			try
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(string.Format("{0}{1}", this.ServerPath, "settings.xml"), Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("settings");
				xmlTextWriter.WriteElementString("gamename", this.m_gameName);
				xmlTextWriter.WriteElementString("ranked", this.m_isRanked.ToString());
				xmlTextWriter.WriteElementString("passwordprotected", this.m_isPasswordProtected.ToString());
				xmlTextWriter.WriteElementString("gamepassword", this.m_gamePassword);
				xmlTextWriter.WriteElementString("friendlyfire", this.m_friendlyFire.ToString());
				xmlTextWriter.WriteElementString("aimassist", this.m_aimAssist.ToString());
				xmlTextWriter.WriteElementString("maxplayers", this.m_maxPlayers.ToString());
				xmlTextWriter.WriteElementString("roundspermap", this.m_roundsPerMap.ToString());
				xmlTextWriter.WriteElementString("roundtime", this.m_roundTime.ToString());
				xmlTextWriter.WriteElementString("dmlimit", this.m_DMLimit.ToString());
				xmlTextWriter.WriteElementString("inflimit", this.m_INFLimit.ToString());
				xmlTextWriter.WriteElementString("htllimit", this.m_HTLLimit.ToString());
				xmlTextWriter.WriteElementString("bllimit", this.m_BLLimit.ToString());
				string text = "";
				foreach (object obj in this.m_selectedMaps)
				{
					int num = (int)obj;
					text = text + num.ToString() + ",";
				}
				text = text.Trim(new char[] { ',' });
				xmlTextWriter.WriteElementString("selectedmaps", text);
				xmlTextWriter.WriteElementString("adminpassword", this.m_adminPassword);
				xmlTextWriter.WriteElementString("administered", this.m_isAdministrated.ToString());
				xmlTextWriter.WriteElementString("port", this.m_port.ToString());
				xmlTextWriter.WriteElementString("accountname", this.m_accountName);
				xmlTextWriter.WriteElementString("accountpassword", this.m_accountPassword);
				xmlTextWriter.WriteElementString("autorestart", this.m_autoRestart.ToString());
				xmlTextWriter.WriteElementString("easerver", this.m_easerver.ToString());
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Close();
			}
			catch
			{
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00006878 File Offset: 0x00005878
		private void LoadSettings()
		{
			try
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(string.Format("{0}{1}", this.ServerPath, "settings.xml"), XmlReadMode.InferSchema);
				DataTable dataTable = dataSet.Tables["settings"];
				DataRow dataRow = dataTable.Rows[0];
				this.m_gameName = dataRow["gamename"].ToString();
				this.m_isRanked = bool.Parse(dataRow["ranked"].ToString());
				this.m_isPasswordProtected = bool.Parse(dataRow["passwordprotected"].ToString());
				this.m_gamePassword = dataRow["gamepassword"].ToString();
				this.m_friendlyFire = (frmGameCreation.FriendlyFireType)Enum.Parse(typeof(frmGameCreation.FriendlyFireType), dataRow["friendlyfire"].ToString());
				this.m_aimAssist = (frmGameCreation.AimAssistType)Enum.Parse(typeof(frmGameCreation.AimAssistType), dataRow["aimassist"].ToString());
				this.m_maxPlayers = int.Parse(dataRow["maxplayers"].ToString());
				this.m_roundsPerMap = int.Parse(dataRow["roundspermap"].ToString());
				this.m_roundTime = int.Parse(dataRow["roundtime"].ToString());
				this.m_DMLimit = int.Parse(dataRow["dmlimit"].ToString());
				this.m_INFLimit = int.Parse(dataRow["inflimit"].ToString());
				this.m_HTLLimit = int.Parse(dataRow["htllimit"].ToString());
				this.m_BLLimit = int.Parse(dataRow["bllimit"].ToString());
				string text = dataRow["selectedmaps"].ToString();
				string[] array = text.Split(new char[] { ',' });
				this.m_selectedMaps.Clear();
				foreach (string text2 in array)
				{
					this.m_selectedMaps.Add(int.Parse(text2));
				}
				this.m_adminPassword = dataRow["adminpassword"].ToString();
				this.m_isAdministrated = bool.Parse(dataRow["administered"].ToString());
				this.m_port = int.Parse(dataRow["port"].ToString());
				this.m_accountName = dataRow["accountname"].ToString();
				this.m_accountPassword = dataRow["accountpassword"].ToString();
				if (dataRow.Table.Columns.Contains("autorestart"))
				{
					this.m_autoRestart = bool.Parse(dataRow["autorestart"].ToString());
				}
				else
				{
					this.m_autoRestart = false;
				}
				if (dataRow.Table.Columns.Contains("easerver"))
				{
					this.m_easerver = bool.Parse(dataRow["easerver"].ToString());
				}
				else
				{
					this.m_easerver = false;
				}
				this.menuItemAutoRestart.Checked = m_autoRestart;
				this.menuItemEAServerMode.Checked = m_easerver;
			}
			catch
			{
				this.ResetSettings();
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00006B44 File Offset: 0x00005B44
		private void ResetSettings()
		{
			this.m_accountName = "";
			this.m_accountPassword = "";
			this.m_gameName = "MOH";
			this.m_isRanked = true;
			this.m_isPasswordProtected = false;
			this.m_friendlyFire = frmGameCreation.FriendlyFireType.Off;
			this.m_aimAssist = frmGameCreation.AimAssistType.Enabled;
			this.m_maxPlayers = 32;
			this.m_roundsPerMap = 5;
			this.m_maxPlayers = 32;
			this.m_roundTime = 0;
			this.m_DMLimit = 0;
			this.m_INFLimit = 3;
			this.m_HTLLimit = 200;
			this.m_BLLimit = 200;
			this.m_selectedMaps = new ArrayList(MapRegistry.GetMapIds(MapRegistry.GameMode.All));
			this.m_isAdministrated = false;
			this.m_adminPassword = "";
			this.m_port = 3658;
			this.m_easerver = false;
		}


		private void StartServer()
		{
			this.Cursor = Cursors.AppStarting;
			this.btnStop.Cursor = Cursors.Default;
			this.btnGo.Enabled = false;
			this.btnStop.Enabled = true;
			this.menuItemSettings.Enabled = false;

			if (this.txtLog.Text.Length > 50000)
			{
				this.txtLog.Clear(); // Prevent memory issues from log growing too large
			}

			this.WriteStreamInfo(Database.GetString("CMN_StartingServer"), Color.Green, FontStyle.Italic);
			this.m_processStarter = new ProcessStarter(this);
			this.m_processStarter.FileName = this.ServerPath + "mohz.exe";
			this.BuildArguments(out this.m_processStarter.Arguments);
			this.m_processStarter.WorkingDirectory = this.ServerPath;
			this.m_processStarter.StdOutReceived += this.WriteOutStreamInfo;
			this.m_processStarter.StdErrReceived += this.WriteErrStreamInfo;
			this.m_processStarter.Completed += this.ProcessCompleted;
			this.m_processStarter.Cancelled += this.ProcessCancelled;
			this.m_processStarter.Failed += this.ProcessFailed;
			this.m_processStarter.Start();
			this.notifyIcon.Text = Database.GetString("CMN_TitleRunning");
			this.notifyIcon.Icon = this.Icon;
		}



		// Token: 0x06000077 RID: 119 RVA: 0x00006C00 File Offset: 0x00005C00
		private void btnGo_Click(object sender, EventArgs e)
		{
			this.m_startingGame = true;
			if (this.m_accountName == "" || this.m_accountPassword == "")
			{
				this.menuItemAcctSettings_Click(sender, e);
			}
			if (this.m_startingGame)
			{
				this.menuItemGameSettings_Click(sender, e);
				if (this.m_startingGame)
				{
					this.menuItemMapList_Click(sender, e);
					if (this.m_startingGame)
					{
						this.StartServer();
					}
				}
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00006DB0 File Offset: 0x00005DB0
		private void btnStop_Click(object sender, EventArgs e)
		{
			if (this.m_processStarter != null)
			{
				this.WriteStreamInfo(Database.GetString("CMN_StoppingServer"), Color.Green, FontStyle.Italic);
				this.m_processStarter.CancelAndWait();
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00006DE8 File Offset: 0x00005DE8
		private void frmMain_Closing(object sender, CancelEventArgs e)
		{
			if (this.m_processStarter != null)
			{
				this.m_processStarter.CancelAndWait();
			}

			if (m_logHandler != null)
			{
				m_logHandler.Dispose();
			}

			this.SaveSettings();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00006E10 File Offset: 0x00005E10
		private void menuItemAcctSettings_Click(object sender, EventArgs e)
		{
			this.m_startingGame = false;
			using (frmAcctSettings frmAcctSettings = new frmAcctSettings())
			{
				frmAcctSettings.AccountName = this.m_accountName;
				frmAcctSettings.Password = this.m_accountPassword;
				DialogResult dialogResult = frmAcctSettings.ShowDialog(this);
				if (dialogResult == DialogResult.OK)
				{
					this.m_startingGame = true;
					this.m_accountName = frmAcctSettings.AccountName;
					this.m_accountPassword = frmAcctSettings.Password;
				}
				else if (dialogResult != DialogResult.Cancel)
				{
					throw new SystemException("Unknown dialog result");
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00006EA8 File Offset: 0x00005EA8
		private void menuItemEditCopy_Click(object sender, EventArgs e)
		{
			this.txtLog.Copy();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00006EC0 File Offset: 0x00005EC0
		private void menuItemEditClear_Click(object sender, EventArgs e)
		{
			this.txtLog.Clear();
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00006ED8 File Offset: 0x00005ED8
		private void menuItemHelpAbout_Click(object sender, EventArgs e)
		{
			using (frmAbout frmAbout = new frmAbout())
			{
				frmAbout.ShowDialog(this);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00006F1C File Offset: 0x00005F1C
		private void menuItemGameSettings_Click(object sender, EventArgs e)
		{
			this.m_startingGame = false;
			using (frmGameCreation frmGameCreation = new frmGameCreation())
			{
				frmGameCreation.GameName = this.m_gameName;
				frmGameCreation.IsRanked = this.m_isRanked;
				frmGameCreation.IsPasswordProtected = this.m_isPasswordProtected;
				frmGameCreation.Password = this.m_gamePassword;
				frmGameCreation.FriendlyFire = this.m_friendlyFire;
				frmGameCreation.AimAssist = this.m_aimAssist;
				frmGameCreation.MaxPlayers = this.m_maxPlayers;
				frmGameCreation.RoundsPerMap = this.m_roundsPerMap;
				frmGameCreation.RoundTime = this.m_roundTime;
				frmGameCreation.DMLimit = this.m_DMLimit;
				frmGameCreation.INFLimit = this.m_INFLimit;
				frmGameCreation.HTLLimit = this.m_HTLLimit;
				frmGameCreation.BLLimit = this.m_BLLimit;
				DialogResult dialogResult = frmGameCreation.ShowDialog(this);
				if (dialogResult == DialogResult.OK)
				{
					this.m_startingGame = true;
					this.m_gameName = frmGameCreation.GameName;
					this.m_isRanked = frmGameCreation.IsRanked;
					this.m_isPasswordProtected = frmGameCreation.IsPasswordProtected;
					this.m_gamePassword = frmGameCreation.Password;
					this.m_friendlyFire = frmGameCreation.FriendlyFire;
					this.m_aimAssist = frmGameCreation.AimAssist;
					this.m_maxPlayers = frmGameCreation.MaxPlayers;
					this.m_roundsPerMap = frmGameCreation.RoundsPerMap;
					this.m_roundTime = frmGameCreation.RoundTime;
					this.m_DMLimit = frmGameCreation.DMLimit;
					this.m_INFLimit = frmGameCreation.INFLimit;
					this.m_HTLLimit = frmGameCreation.HTLLimit;
					this.m_BLLimit = frmGameCreation.BLLimit;
				}
				else if (dialogResult != DialogResult.Cancel)
				{
					throw new SystemException("Unknown dialog result");
				}
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000070C0 File Offset: 0x000060C0
		private void menuItemServerSettings_Click(object sender, EventArgs e)
		{
			using (frmServerSettings frmServerSettings = new frmServerSettings())
			{
				if (this.m_adminPassword != "")
				{
					frmServerSettings.AdminPassword = this.m_adminPassword;
				}
				frmServerSettings.IsAdministrated = this.m_isAdministrated;
				frmServerSettings.Port = this.m_port;
				DialogResult dialogResult = frmServerSettings.ShowDialog(this);
				if (dialogResult == DialogResult.OK)
				{
					this.m_isAdministrated = frmServerSettings.IsAdministrated;
					this.m_adminPassword = frmServerSettings.AdminPassword;
					this.m_port = frmServerSettings.Port;
				}
				else if (dialogResult != DialogResult.Cancel)
				{
					throw new SystemException("Unknown dialog result");
				}
			}
		}

        // Token: 0x06000080 RID: 128 RVA: 0x00007174 File Offset: 0x00006174
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreFromTray();
        }
        private void RestoreFromTray()
        {
            base.Show();
            base.WindowState = FormWindowState.Normal;
            base.Activate();
            this.notifyIcon.Visible = false;
        }

        // Token: 0x06000081 RID: 129 RVA: 0x000071AC File Offset: 0x000061AC
        private void menuItemCntxtShow_Click(object sender, EventArgs e)
        {
            RestoreFromTray();
        }


        // Token: 0x06000082 RID: 130 RVA: 0x000071D8 File Offset: 0x000061D8
        private void menuItemCntxtExit_Click(object sender, EventArgs e)
		{
			// If server is running, show confirmation dialog
			if (this.btnStop.Enabled)
			{
				DialogResult result = MessageBox.Show(
					"The server is still running. Are you sure you want to exit?",
					Database.GetString("CMN_Title"),
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning);

				if (result == DialogResult.No)
				{
					return;
				}
			}

			base.Close();
		}



    // Token: 0x06000083 RID: 131 RVA: 0x000071EC File Offset: 0x000061EC
    private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == base.WindowState)
            {
                // Only hide if the server is running
                if (this.btnStop.Enabled)
                {
                    base.Hide();
                    this.notifyIcon.Visible = true;

                    // Optional: Show balloon tip
                    this.notifyIcon.ShowBalloonTip(2000,
                        Database.GetString("CMN_Title"),
                        "Server is still running in the background. Double-click to restore.",
                        ToolTipIcon.Info);
                }
            }
        }


        // Token: 0x06000084 RID: 132 RVA: 0x00007214 File Offset: 0x00006214
        private void frmMain_Load(object sender, EventArgs e)
		{
			this.UpdateStats();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00007228 File Offset: 0x00006228
		private void menuItemMapList_Click(object sender, EventArgs e)
		{
			this.m_startingGame = false;
			using (frmMapList frmMapList = new frmMapList())
			{
				MapRegistry.SelectedMaps.Clear();
				MapRegistry.SelectedMaps.AddRange(this.m_selectedMaps);
				DialogResult dialogResult = frmMapList.ShowDialog(this);
				if (dialogResult == DialogResult.OK)
				{
					this.m_startingGame = true;
					this.m_selectedMaps.Clear();
					this.m_selectedMaps.AddRange(MapRegistry.SelectedMaps);
				}
				else if (dialogResult != DialogResult.Cancel)
				{
					throw new SystemException("Unknown dialog result");
				}
			}
		}




		// Token: 0x0400003E RID: 62
		private const string ServerExe = "mohz.exe";

		// Token: 0x0400003F RID: 63
		private const string StatsXml = "stats.xml";

		// Token: 0x04000040 RID: 64
		private const string StatsXsd = "stats.xsd";

		// Token: 0x04000041 RID: 65
		private const string SettingsXml = "settings.xml";

		// Token: 0x04000042 RID: 66
		private readonly string ServerPath = AppDomain.CurrentDomain.BaseDirectory;

		// Token: 0x04000043 RID: 67
		private bool m_startingGame;

		// Token: 0x04000044 RID: 68
		private ProcessStarter m_processStarter;

		// Token: 0x04000045 RID: 69
		private Thread m_statsUpdateThread;

		// Token: 0x04000046 RID: 70
		private ThreadStart m_statsUpdateThreadExec;

		// Token: 0x04000047 RID: 71
		private Mutex m_statsUpdateMutex = new Mutex();

		// Token: 0x04000048 RID: 72
		private frmMain.StatsUpdateDelegate m_statsUpdateInvoker;

		// Token: 0x04000049 RID: 73
		private FileSystemWatcher m_statsFileWatcher;

		// Token: 0x0400004A RID: 74
		private string m_accountName;

		// Token: 0x0400004B RID: 75
		private string m_accountPassword;

		// Token: 0x0400004C RID: 76
		private string m_gameName;

		// Token: 0x0400004D RID: 77
		private bool m_isRanked;

		// Token: 0x0400004E RID: 78
		private bool m_isPasswordProtected;

		// Token: 0x0400004F RID: 79
		private string m_gamePassword;

		// Token: 0x04000050 RID: 80
		private frmGameCreation.FriendlyFireType m_friendlyFire;

		// Token: 0x04000051 RID: 81
		private frmGameCreation.AimAssistType m_aimAssist;

		// Token: 0x04000052 RID: 82
		private int m_maxPlayers;

		// Token: 0x04000053 RID: 83
		private int m_roundsPerMap;

		// Token: 0x04000054 RID: 84
		private ArrayList m_selectedMaps;

		// Token: 0x04000055 RID: 85
		private int m_roundTime;

		// Token: 0x04000056 RID: 86
		private int m_DMLimit;

		// Token: 0x04000057 RID: 87
		private int m_INFLimit;

		// Token: 0x04000058 RID: 88
		private int m_HTLLimit;

		// Token: 0x04000059 RID: 89
		private int m_BLLimit;

		// Token: 0x0400005A RID: 90
		private string m_adminPassword;

		// Token: 0x0400005B RID: 91
		private bool m_isAdministrated;

		// Token: 0x0400005C RID: 92
		private int m_port;
        private bool m_autoRestart;
		private bool m_easerver;

        // Token: 0x0200000C RID: 12
        // (Invoke) Token: 0x06000087 RID: 135
        private delegate void StatsUpdateDelegate(DataSet dataSet, DataView dataView);
	}
}
