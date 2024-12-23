using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x02000007 RID: 7
	public partial class frmGameCreation : Form
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000033A4 File Offset: 0x000023A4
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000033BC File Offset: 0x000023BC
		public string GameName
		{
			get
			{
				return this.txtBoxGameName.Text;
			}
			set
			{
				this.txtBoxGameName.Text = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000033D8 File Offset: 0x000023D8
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000033F0 File Offset: 0x000023F0
		public bool IsRanked
		{
			get
			{
				return this.chkBoxRanked.Checked;
			}
			set
			{
				this.chkBoxRanked.Checked = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000340C File Offset: 0x0000240C
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00003424 File Offset: 0x00002424
		public bool IsPasswordProtected
		{
			get
			{
				return this.chkBoxPassword.Checked;
			}
			set
			{
				this.chkBoxPassword.Checked = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00003440 File Offset: 0x00002440
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00003458 File Offset: 0x00002458
		public string Password
		{
			get
			{
				return this.txtBoxPassword.Text;
			}
			set
			{
				this.txtBoxPassword.Text = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00003474 File Offset: 0x00002474
		// (set) Token: 0x0600003B RID: 59 RVA: 0x0000348C File Offset: 0x0000248C
		public frmGameCreation.FriendlyFireType FriendlyFire
		{
			get
			{
				return (frmGameCreation.FriendlyFireType)this.cmbBoxFriendlyFire.SelectedIndex;
			}
			set
			{
				this.cmbBoxFriendlyFire.SelectedIndex = (int)value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000034A8 File Offset: 0x000024A8
		// (set) Token: 0x0600003D RID: 61 RVA: 0x000034C0 File Offset: 0x000024C0
		public frmGameCreation.AimAssistType AimAssist
		{
			get
			{
				return (frmGameCreation.AimAssistType)this.cmbBoxAimAssist.SelectedIndex;
			}
			set
			{
				this.cmbBoxAimAssist.SelectedIndex = (int)value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000034DC File Offset: 0x000024DC
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00003500 File Offset: 0x00002500
		public int MaxPlayers
		{
			get
			{
				return int.Parse((string)this.cmbBoxMaxPlayers.SelectedItem);
			}
			set
			{
				for (int i = 0; i < this.cmbBoxMaxPlayers.Items.Count; i++)
				{
					if ((string)this.cmbBoxMaxPlayers.Items[i] == value.ToString())
					{
						this.cmbBoxMaxPlayers.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000355C File Offset: 0x0000255C
		// (set) Token: 0x06000041 RID: 65 RVA: 0x000035A0 File Offset: 0x000025A0
		public int RoundsPerMap
		{
			get
			{
				if (this.cmbBoxRoundsPerMap.SelectedIndex == this.cmbBoxRoundsPerMap.Items.Count - 1)
				{
					return -1;
				}
				return int.Parse((string)this.cmbBoxRoundsPerMap.SelectedItem);
			}
			set
			{
				if (value == -1)
				{
					this.cmbBoxRoundsPerMap.SelectedIndex = this.cmbBoxRoundsPerMap.Items.Count - 1;
					return;
				}
				for (int i = 0; i < this.cmbBoxRoundsPerMap.Items.Count - 1; i++)
				{
					if ((string)this.cmbBoxRoundsPerMap.Items[i] == value.ToString())
					{
						this.cmbBoxRoundsPerMap.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003620 File Offset: 0x00002620
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00003654 File Offset: 0x00002654
		public int RoundTime
		{
			get
			{
				if (this.cmbTimeLimit.SelectedIndex == 0)
				{
					return 0;
				}
				return int.Parse((string)this.cmbTimeLimit.SelectedItem);
			}
			set
			{
				if (value == 0)
				{
					this.cmbTimeLimit.SelectedIndex = 0;
					return;
				}
				for (int i = 0; i < this.cmbTimeLimit.Items.Count - 1; i++)
				{
					if ((string)this.cmbTimeLimit.Items[i] == value.ToString())
					{
						this.cmbTimeLimit.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000036C0 File Offset: 0x000026C0
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000036F4 File Offset: 0x000026F4
		public int DMLimit
		{
			get
			{
				if (this.cmbDMLimit.SelectedIndex == 0)
				{
					return 0;
				}
				return int.Parse((string)this.cmbDMLimit.SelectedItem);
			}
			set
			{
				if (value == 0)
				{
					this.cmbDMLimit.SelectedIndex = 0;
					return;
				}
				for (int i = 0; i < this.cmbDMLimit.Items.Count - 1; i++)
				{
					if ((string)this.cmbDMLimit.Items[i] == value.ToString())
					{
						this.cmbDMLimit.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003760 File Offset: 0x00002760
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00003794 File Offset: 0x00002794
		public int INFLimit
		{
			get
			{
				if (this.cmbINFLimit.SelectedIndex == 0)
				{
					return 0;
				}
				return int.Parse((string)this.cmbINFLimit.SelectedItem);
			}
			set
			{
				if (value == 0)
				{
					this.cmbINFLimit.SelectedIndex = 0;
					return;
				}
				for (int i = 0; i < this.cmbINFLimit.Items.Count - 1; i++)
				{
					if ((string)this.cmbINFLimit.Items[i] == value.ToString())
					{
						this.cmbINFLimit.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003800 File Offset: 0x00002800
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00003834 File Offset: 0x00002834
		public int HTLLimit
		{
			get
			{
				if (this.cmbHTLLimit.SelectedIndex == 0)
				{
					return 0;
				}
				return int.Parse((string)this.cmbHTLLimit.SelectedItem);
			}
			set
			{
				if (value == 0)
				{
					this.cmbHTLLimit.SelectedIndex = 0;
					return;
				}
				for (int i = 0; i < this.cmbHTLLimit.Items.Count - 1; i++)
				{
					if ((string)this.cmbHTLLimit.Items[i] == value.ToString())
					{
						this.cmbHTLLimit.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000038A0 File Offset: 0x000028A0
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000038D4 File Offset: 0x000028D4
		public int BLLimit
		{
			get
			{
				if (this.cmbBLLimit.SelectedIndex == 0)
				{
					return 0;
				}
				return int.Parse((string)this.cmbBLLimit.SelectedItem);
			}
			set
			{
				if (value == 0)
				{
					this.cmbBLLimit.SelectedIndex = 0;
					return;
				}
				for (int i = 0; i < this.cmbBLLimit.Items.Count - 1; i++)
				{
					if ((string)this.cmbBLLimit.Items[i] == value.ToString())
					{
						this.cmbBLLimit.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003940 File Offset: 0x00002940
		public frmGameCreation()
		{
			this.InitializeComponent();
			Database.ScanAndReplaceStringIds(this);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004CFC File Offset: 0x00003CFC
		private bool ValidGameName(string gameString, out string errorMsg)
		{
			errorMsg = "";
			if (gameString.Length == 0)
			{
				errorMsg = Database.GetString("ERR_GameName");
				return false;
			}
			if (gameString.Length > this.txtBoxGameName.MaxLength)
			{
				errorMsg = Database.GetString("ERR_GameNameLong");
				return false;
			}
			foreach (char c in gameString)
			{
				if (!this.IsCharValidForGameName(c))
				{
					errorMsg = Database.GetString("ERR_GameNameInvalidChar");
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004D80 File Offset: 0x00003D80
		private bool ValidPassword(string gameString, out string errorMsg)
		{
			errorMsg = "";
			if (gameString.Length == 0)
			{
				this.chkBoxPassword.Checked = false;
				errorMsg = "";
				return true;
			}
			if (gameString.Length < 3)
			{
				errorMsg = Database.GetString("ERR_Passwd3");
				return false;
			}
			if (gameString.Length > 12)
			{
				errorMsg = Database.GetString("ERR_Passwd12");
				return false;
			}
			return true;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004DE4 File Offset: 0x00003DE4
		private void txtBoxGameName_Validating(object sender, CancelEventArgs e)
		{
			string text = "";
			if (!this.ValidGameName(this.txtBoxGameName.Text, out text))
			{
				e.Cancel = true;
				this.txtBoxGameName.Select(0, this.txtBoxGameName.Text.Length);
				this.errorProviderGameCreation.SetError(this.txtBoxGameName, text);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004E44 File Offset: 0x00003E44
		private void txtBoxGameName_Validated(object sender, EventArgs e)
		{
			this.errorProviderGameCreation.SetError(this.txtBoxGameName, "");
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004E68 File Offset: 0x00003E68
		private void chkBoxPassword_CheckedChanged(object sender, EventArgs e)
		{
			this.chkBoxRanked.Enabled = !this.chkBoxPassword.Checked;
			this.txtBoxPassword.Enabled = this.chkBoxPassword.Checked;
			if (this.chkBoxPassword.Checked)
			{
				this.chkBoxRanked.Checked = false;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004EC0 File Offset: 0x00003EC0
		private void chkBoxRanked_CheckedChanged(object sender, EventArgs e)
		{
			this.chkBoxPassword.Enabled = !this.chkBoxRanked.Checked;
			if (this.chkBoxRanked.Checked)
			{
				this.chkBoxPassword.Checked = false;
			}
		}

        // Token: 0x06000055 RID: 85 RVA: 0x00004F00 File Offset: 0x00003F00
        private bool IsCharValidForGameName(char c)
        {
            bool isCommonValid = ('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z') || ('0' <= c && c <= '9') || c == '\b';
            return frmMain.isPatched ? isCommonValid || c == '[' || c == ']' || c == ' ' : isCommonValid;
        }


        // Token: 0x06000056 RID: 86 RVA: 0x00004F34 File Offset: 0x00003F34
        private void txtBoxGameName_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = this.IsCharValidForGameName(e.KeyChar);
			e.Handled = !flag;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004F58 File Offset: 0x00003F58
		private void btnMapList_Click(object sender, EventArgs e)
		{
			using (frmMapList frmMapList = new frmMapList())
			{
				frmMapList.ShowDialog(this);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004F9C File Offset: 0x00003F9C
		private void txtBoxPassword_Validated(object sender, EventArgs e)
		{
			this.errorProviderGameCreation.SetError(this.txtBoxPassword, "");
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004FC0 File Offset: 0x00003FC0
		private void txtBoxPassword_Validating(object sender, CancelEventArgs e)
		{
			string text = "";
			if (!this.ValidPassword(this.txtBoxPassword.Text, out text))
			{
				e.Cancel = true;
				this.txtBoxPassword.Select(0, this.txtBoxPassword.Text.Length);
				this.errorProviderGameCreation.SetError(this.txtBoxPassword, text);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005020 File Offset: 0x00004020
		private void txtBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '\r';
			e.Handled = !flag;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000505C File Offset: 0x0000405C
		private void Combo_Validating(object sender, CancelEventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.SelectedIndex == -1)
			{
				e.Cancel = true;
				this.errorProviderGameCreation.SetError(comboBox, Database.GetString("ERR_SelectValidItem"));
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00005098 File Offset: 0x00004098
		private void Combo_Validated(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			this.errorProviderGameCreation.SetError(comboBox, "");
		}

		// Token: 0x02000008 RID: 8
		public enum FriendlyFireType
		{
			// Token: 0x04000035 RID: 53
			Off,
			// Token: 0x04000036 RID: 54
			On,
			// Token: 0x04000037 RID: 55
			Reflect
		}

		// Token: 0x02000009 RID: 9
		public enum AimAssistType
		{
			// Token: 0x04000039 RID: 57
			Enabled,
			// Token: 0x0400003A RID: 58
			Disabled
		}
	}
}
