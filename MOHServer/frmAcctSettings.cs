using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x02000004 RID: 4
	public partial class frmAcctSettings : Form
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000027A4 File Offset: 0x000017A4
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000027BC File Offset: 0x000017BC
		public string AccountName
		{
			get
			{
				return this.txtAccount.Text;
			}
			set
			{
				this.txtAccount.Text = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000027D8 File Offset: 0x000017D8
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000027F0 File Offset: 0x000017F0
		public string Password
		{
			get
			{
				return this.txtPassword.Text;
			}
			set
			{
				this.txtPassword.Text = value;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000280C File Offset: 0x0000180C
		public frmAcctSettings()
		{
			this.InitializeComponent();
			Database.ScanAndReplaceStringIds(this);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002CA4 File Offset: 0x00001CA4
		private bool ValidPassword(string str, out string errorMsg)
		{
			errorMsg = "";
			if (str.Length < 4)
			{
				errorMsg = Database.GetString("ERR_Passwd4");
				return false;
			}
			if (str.Length > 16)
			{
				errorMsg = Database.GetString("ERR_Passwd16");
				return false;
			}
			return true;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002CE8 File Offset: 0x00001CE8
		private void txtPassword_Validating(object sender, CancelEventArgs e)
		{
			string text = "";
			if (!this.ValidPassword(this.txtPassword.Text, out text))
			{
				e.Cancel = true;
				this.txtPassword.Select(0, this.txtPassword.Text.Length);
				this.errorProviderAcctSettings.SetError(this.txtPassword, text);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002D48 File Offset: 0x00001D48
		private void txtPassword_Validated(object sender, EventArgs e)
		{
			this.errorProviderAcctSettings.SetError(this.txtPassword, "");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002D6C File Offset: 0x00001D6C
		private void txtAccount_Validating(object sender, CancelEventArgs e)
		{
			string text = "";
			if (!this.ValidPassword(this.txtAccount.Text, out text))
			{
				e.Cancel = true;
				this.txtAccount.Select(0, this.txtAccount.Text.Length);
				this.errorProviderAcctSettings.SetError(this.txtAccount, text);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002DCC File Offset: 0x00001DCC
		private void txtAccount_Validated(object sender, EventArgs e)
		{
			this.errorProviderAcctSettings.SetError(this.txtAccount, "");
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002DF0 File Offset: 0x00001DF0
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
