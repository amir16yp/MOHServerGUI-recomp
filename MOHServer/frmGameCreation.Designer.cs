namespace MOHServer
{
	// Token: 0x02000007 RID: 7
	public partial class frmGameCreation : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00003968 File Offset: 0x00002968
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003994 File Offset: 0x00002994
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::MOHServer.frmGameCreation));
			this.lblMaxPlayers = new global::System.Windows.Forms.Label();
			this.cmbBoxMaxPlayers = new global::System.Windows.Forms.ComboBox();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.lblGameName = new global::System.Windows.Forms.Label();
			this.txtBoxGameName = new global::System.Windows.Forms.TextBox();
			this.errorProviderGameCreation = new global::System.Windows.Forms.ErrorProvider();
			this.chkBoxRanked = new global::System.Windows.Forms.CheckBox();
			this.grpBoxPassword = new global::System.Windows.Forms.GroupBox();
			this.txtBoxPassword = new global::System.Windows.Forms.TextBox();
			this.lblPassword = new global::System.Windows.Forms.Label();
			this.chkBoxPassword = new global::System.Windows.Forms.CheckBox();
			this.cmbBoxFriendlyFire = new global::System.Windows.Forms.ComboBox();
			this.lblFriendlyFire = new global::System.Windows.Forms.Label();
			this.lblAimAssist = new global::System.Windows.Forms.Label();
			this.cmbBoxAimAssist = new global::System.Windows.Forms.ComboBox();
			this.cmbBoxRoundsPerMap = new global::System.Windows.Forms.ComboBox();
			this.lblRoundsPerMap = new global::System.Windows.Forms.Label();
			this.lblBLLimit = new global::System.Windows.Forms.Label();
			this.cmbBLLimit = new global::System.Windows.Forms.ComboBox();
			this.cmbINFLimit = new global::System.Windows.Forms.ComboBox();
			this.lblINFLimit = new global::System.Windows.Forms.Label();
			this.lblDMLimit = new global::System.Windows.Forms.Label();
			this.cmbDMLimit = new global::System.Windows.Forms.ComboBox();
			this.cmbHTLLimit = new global::System.Windows.Forms.ComboBox();
			this.lblHTLLimit = new global::System.Windows.Forms.Label();
			this.lblTimeLimit = new global::System.Windows.Forms.Label();
			this.cmbTimeLimit = new global::System.Windows.Forms.ComboBox();
			this.grpBoxPassword.SuspendLayout();
			base.SuspendLayout();
			this.lblMaxPlayers.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblMaxPlayers.Location = new global::System.Drawing.Point(16, 248);
			this.lblMaxPlayers.Name = "lblMaxPlayers";
			this.lblMaxPlayers.Size = new global::System.Drawing.Size(152, 23);
			this.lblMaxPlayers.TabIndex = 0;
			this.lblMaxPlayers.Text = "$CMN_MaxPlayers";
			this.cmbBoxMaxPlayers.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBoxMaxPlayers.ItemHeight = 13;
			this.cmbBoxMaxPlayers.Items.AddRange(new object[] { "4", "8", "16", "32" });
			this.cmbBoxMaxPlayers.Location = new global::System.Drawing.Point(184, 248);
			this.cmbBoxMaxPlayers.Name = "cmbBoxMaxPlayers";
			this.cmbBoxMaxPlayers.Size = new global::System.Drawing.Size(121, 21);
			this.cmbBoxMaxPlayers.TabIndex = 8;
			this.cmbBoxMaxPlayers.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbBoxMaxPlayers.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.btnOk.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOk.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnOk.Location = new global::System.Drawing.Point(8, 472);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 15;
			this.btnOk.Text = "$CMN_OK";
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnCancel.Location = new global::System.Drawing.Point(96, 472);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "$CMN_Cancel";
			this.lblGameName.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblGameName.Location = new global::System.Drawing.Point(16, 16);
			this.lblGameName.Name = "lblGameName";
			this.lblGameName.Size = new global::System.Drawing.Size(160, 23);
			this.lblGameName.TabIndex = 4;
			this.lblGameName.Text = "$CMN_GameName";
			this.txtBoxGameName.Location = new global::System.Drawing.Point(184, 16);
			this.txtBoxGameName.MaxLength = 12;
			this.txtBoxGameName.Name = "txtBoxGameName";
			this.txtBoxGameName.Size = new global::System.Drawing.Size(120, 20);
			this.txtBoxGameName.TabIndex = 1;
			this.txtBoxGameName.Text = "";
			this.txtBoxGameName.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtBoxGameName_KeyPress);
			this.txtBoxGameName.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtBoxGameName_Validating);
			this.txtBoxGameName.Validated += new global::System.EventHandler(this.txtBoxGameName_Validated);
			this.errorProviderGameCreation.ContainerControl = this;
			//this.errorProviderGameCreation.Icon = Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
            this.chkBoxRanked.Checked = true;
			this.chkBoxRanked.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkBoxRanked.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.chkBoxRanked.Location = new global::System.Drawing.Point(16, 24);
			this.chkBoxRanked.Name = "chkBoxRanked";
			this.chkBoxRanked.Size = new global::System.Drawing.Size(264, 24);
			this.chkBoxRanked.TabIndex = 3;
			this.chkBoxRanked.Text = "$CMN_Ranked";
			this.chkBoxRanked.CheckedChanged += new global::System.EventHandler(this.chkBoxRanked_CheckedChanged);
			this.grpBoxPassword.Controls.Add(this.txtBoxPassword);
			this.grpBoxPassword.Controls.Add(this.lblPassword);
			this.grpBoxPassword.Controls.Add(this.chkBoxPassword);
			this.grpBoxPassword.Controls.Add(this.chkBoxRanked);
			this.grpBoxPassword.Location = new global::System.Drawing.Point(16, 48);
			this.grpBoxPassword.Name = "grpBoxPassword";
			this.grpBoxPassword.Size = new global::System.Drawing.Size(296, 120);
			this.grpBoxPassword.TabIndex = 2;
			this.grpBoxPassword.TabStop = false;
			this.grpBoxPassword.Text = "$CMN_PwdOpts";
			this.txtBoxPassword.Enabled = false;
			this.txtBoxPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.txtBoxPassword.Location = new global::System.Drawing.Point(168, 88);
			this.txtBoxPassword.MaxLength = 12;
			this.txtBoxPassword.Name = "txtBoxPassword";
			this.txtBoxPassword.PasswordChar = '*';
			this.txtBoxPassword.Size = new global::System.Drawing.Size(112, 20);
			this.txtBoxPassword.TabIndex = 5;
			this.txtBoxPassword.Text = "";
			this.txtBoxPassword.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtBoxPassword_KeyPress);
			this.txtBoxPassword.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtBoxPassword_Validating);
			this.txtBoxPassword.Validated += new global::System.EventHandler(this.txtBoxPassword_Validated);
			this.lblPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblPassword.Location = new global::System.Drawing.Point(16, 88);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new global::System.Drawing.Size(136, 23);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "$CMN_Password";
			this.chkBoxPassword.Enabled = false;
			this.chkBoxPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.chkBoxPassword.Location = new global::System.Drawing.Point(16, 56);
			this.chkBoxPassword.Name = "chkBoxPassword";
			this.chkBoxPassword.Size = new global::System.Drawing.Size(264, 24);
			this.chkBoxPassword.TabIndex = 4;
			this.chkBoxPassword.Text = "$CMN_PwdProtected";
			this.chkBoxPassword.CheckedChanged += new global::System.EventHandler(this.chkBoxPassword_CheckedChanged);
			this.cmbBoxFriendlyFire.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBoxFriendlyFire.ItemHeight = 13;
			this.cmbBoxFriendlyFire.Items.AddRange(new object[] { "$CMN_Off", "$CMN_On", "$CMN_Reflect" });
			this.cmbBoxFriendlyFire.Location = new global::System.Drawing.Point(184, 184);
			this.cmbBoxFriendlyFire.Name = "cmbBoxFriendlyFire";
			this.cmbBoxFriendlyFire.Size = new global::System.Drawing.Size(121, 21);
			this.cmbBoxFriendlyFire.TabIndex = 6;
			this.cmbBoxFriendlyFire.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbBoxFriendlyFire.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.lblFriendlyFire.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblFriendlyFire.Location = new global::System.Drawing.Point(16, 184);
			this.lblFriendlyFire.Name = "lblFriendlyFire";
			this.lblFriendlyFire.Size = new global::System.Drawing.Size(152, 23);
			this.lblFriendlyFire.TabIndex = 10;
			this.lblFriendlyFire.Text = "$CMN_FriendlyFire";
			this.lblAimAssist.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblAimAssist.Location = new global::System.Drawing.Point(16, 216);
			this.lblAimAssist.Name = "lblAimAssist";
			this.lblAimAssist.Size = new global::System.Drawing.Size(152, 23);
			this.lblAimAssist.TabIndex = 11;
			this.lblAimAssist.Text = "$CMN_AimAssist";
			this.cmbBoxAimAssist.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBoxAimAssist.ItemHeight = 13;
			this.cmbBoxAimAssist.Items.AddRange(new object[] { "$CMN_Enabled", "$CMN_Disabled" });
			this.cmbBoxAimAssist.Location = new global::System.Drawing.Point(184, 216);
			this.cmbBoxAimAssist.Name = "cmbBoxAimAssist";
			this.cmbBoxAimAssist.Size = new global::System.Drawing.Size(121, 21);
			this.cmbBoxAimAssist.TabIndex = 7;
			this.cmbBoxAimAssist.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbBoxAimAssist.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.cmbBoxRoundsPerMap.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBoxRoundsPerMap.ItemHeight = 13;
			this.cmbBoxRoundsPerMap.Items.AddRange(new object[] { "1", "3", "5", "10", "$CMN_Infinite" });
			this.cmbBoxRoundsPerMap.Location = new global::System.Drawing.Point(184, 280);
			this.cmbBoxRoundsPerMap.Name = "cmbBoxRoundsPerMap";
			this.cmbBoxRoundsPerMap.Size = new global::System.Drawing.Size(121, 21);
			this.cmbBoxRoundsPerMap.TabIndex = 20;
			this.cmbBoxRoundsPerMap.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbBoxRoundsPerMap.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.lblRoundsPerMap.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblRoundsPerMap.Location = new global::System.Drawing.Point(16, 280);
			this.lblRoundsPerMap.Name = "lblRoundsPerMap";
			this.lblRoundsPerMap.Size = new global::System.Drawing.Size(152, 23);
			this.lblRoundsPerMap.TabIndex = 21;
			this.lblRoundsPerMap.Text = "$CMN_RoundsPerMap";
			this.lblBLLimit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblBLLimit.Location = new global::System.Drawing.Point(16, 440);
			this.lblBLLimit.Name = "lblBLLimit";
			this.lblBLLimit.Size = new global::System.Drawing.Size(152, 23);
			this.lblBLLimit.TabIndex = 29;
			this.lblBLLimit.Text = "$CMN_BLLimit";
			this.cmbBLLimit.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBLLimit.ItemHeight = 13;
			this.cmbBLLimit.Items.AddRange(new object[] { "$CMN_Off", "100", "200", "300", "500" });
			this.cmbBLLimit.Location = new global::System.Drawing.Point(184, 440);
			this.cmbBLLimit.Name = "cmbBLLimit";
			this.cmbBLLimit.Size = new global::System.Drawing.Size(121, 21);
			this.cmbBLLimit.TabIndex = 28;
			this.cmbBLLimit.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbBLLimit.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.cmbINFLimit.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbINFLimit.ItemHeight = 13;
			this.cmbINFLimit.Items.AddRange(new object[] { "$CMN_Off", "1", "3", "5", "10", "20" });
			this.cmbINFLimit.Location = new global::System.Drawing.Point(184, 376);
			this.cmbINFLimit.Name = "cmbINFLimit";
			this.cmbINFLimit.Size = new global::System.Drawing.Size(121, 21);
			this.cmbINFLimit.TabIndex = 24;
			this.cmbINFLimit.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbINFLimit.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.lblINFLimit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblINFLimit.Location = new global::System.Drawing.Point(16, 376);
			this.lblINFLimit.Name = "lblINFLimit";
			this.lblINFLimit.Size = new global::System.Drawing.Size(152, 23);
			this.lblINFLimit.TabIndex = 27;
			this.lblINFLimit.Text = "$CMN_INFLimit";
			this.lblDMLimit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblDMLimit.Location = new global::System.Drawing.Point(16, 344);
			this.lblDMLimit.Name = "lblDMLimit";
			this.lblDMLimit.Size = new global::System.Drawing.Size(152, 23);
			this.lblDMLimit.TabIndex = 26;
			this.lblDMLimit.Text = "$CMN_DMLimit";
			this.cmbDMLimit.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDMLimit.ItemHeight = 13;
			this.cmbDMLimit.Items.AddRange(new object[] { "$CMN_Off", "10", "20", "30", "40", "50", "100" });
			this.cmbDMLimit.Location = new global::System.Drawing.Point(184, 344);
			this.cmbDMLimit.Name = "cmbDMLimit";
			this.cmbDMLimit.Size = new global::System.Drawing.Size(121, 21);
			this.cmbDMLimit.TabIndex = 23;
			this.cmbDMLimit.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbDMLimit.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.cmbHTLLimit.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHTLLimit.ItemHeight = 13;
			this.cmbHTLLimit.Items.AddRange(new object[] { "$CMN_Off", "100", "200", "300", "500" });
			this.cmbHTLLimit.Location = new global::System.Drawing.Point(184, 408);
			this.cmbHTLLimit.Name = "cmbHTLLimit";
			this.cmbHTLLimit.Size = new global::System.Drawing.Size(121, 21);
			this.cmbHTLLimit.TabIndex = 25;
			this.cmbHTLLimit.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbHTLLimit.Validated += new global::System.EventHandler(this.Combo_Validated);
			this.lblHTLLimit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblHTLLimit.Location = new global::System.Drawing.Point(16, 408);
			this.lblHTLLimit.Name = "lblHTLLimit";
			this.lblHTLLimit.Size = new global::System.Drawing.Size(152, 23);
			this.lblHTLLimit.TabIndex = 22;
			this.lblHTLLimit.Text = "$CMN_HTLLimit";
			this.lblTimeLimit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblTimeLimit.Location = new global::System.Drawing.Point(16, 312);
			this.lblTimeLimit.Name = "lblTimeLimit";
			this.lblTimeLimit.Size = new global::System.Drawing.Size(152, 23);
			this.lblTimeLimit.TabIndex = 31;
			this.lblTimeLimit.Text = "$CMN_TimeLimit";
			this.cmbTimeLimit.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTimeLimit.ItemHeight = 13;
			this.cmbTimeLimit.Items.AddRange(new object[] { "$CMN_Off", "5", "10", "15", "20", "30" });
			this.cmbTimeLimit.Location = new global::System.Drawing.Point(184, 312);
			this.cmbTimeLimit.Name = "cmbTimeLimit";
			this.cmbTimeLimit.Size = new global::System.Drawing.Size(121, 21);
			this.cmbTimeLimit.TabIndex = 30;
			this.cmbTimeLimit.Validating += new global::System.ComponentModel.CancelEventHandler(this.Combo_Validating);
			this.cmbTimeLimit.Validated += new global::System.EventHandler(this.Combo_Validated);
			base.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(322, 503);
			base.Controls.Add(this.lblTimeLimit);
			base.Controls.Add(this.cmbTimeLimit);
			base.Controls.Add(this.lblBLLimit);
			base.Controls.Add(this.cmbBLLimit);
			base.Controls.Add(this.cmbINFLimit);
			base.Controls.Add(this.lblINFLimit);
			base.Controls.Add(this.lblDMLimit);
			base.Controls.Add(this.cmbDMLimit);
			base.Controls.Add(this.cmbHTLLimit);
			base.Controls.Add(this.lblHTLLimit);
			base.Controls.Add(this.lblRoundsPerMap);
			base.Controls.Add(this.cmbBoxRoundsPerMap);
			base.Controls.Add(this.cmbBoxAimAssist);
			base.Controls.Add(this.lblAimAssist);
			base.Controls.Add(this.lblFriendlyFire);
			base.Controls.Add(this.cmbBoxFriendlyFire);
			base.Controls.Add(this.grpBoxPassword);
			base.Controls.Add(this.txtBoxGameName);
			base.Controls.Add(this.lblGameName);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.cmbBoxMaxPlayers);
			base.Controls.Add(this.lblMaxPlayers);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.ImeMode = global::System.Windows.Forms.ImeMode.AlphaFull;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmGameCreation";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "$CMN_GameCreationSettings";
			this.grpBoxPassword.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Label lblGameName;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.TextBox txtBoxGameName;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.ErrorProvider errorProviderGameCreation;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.CheckBox chkBoxRanked;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.GroupBox grpBoxPassword;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.CheckBox chkBoxPassword;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label lblPassword;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.TextBox txtBoxPassword;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label lblMaxPlayers;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.ComboBox cmbBoxFriendlyFire;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Label lblFriendlyFire;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Label lblAimAssist;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.ComboBox cmbBoxAimAssist;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.ComboBox cmbBoxRoundsPerMap;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label lblRoundsPerMap;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.ComboBox cmbBoxMaxPlayers;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Label lblBLLimit;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Label lblINFLimit;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label lblDMLimit;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Label lblHTLLimit;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.ComboBox cmbBLLimit;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.ComboBox cmbINFLimit;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.ComboBox cmbDMLimit;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.ComboBox cmbHTLLimit;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Label lblTimeLimit;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.ComboBox cmbTimeLimit;

		// Token: 0x04000033 RID: 51
		private global::System.ComponentModel.Container components = null;
	}
}
