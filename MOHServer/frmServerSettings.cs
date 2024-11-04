using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x02000014 RID: 20
	public partial class frmServerSettings : Form
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000085E4 File Offset: 0x000075E4
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000085FC File Offset: 0x000075FC
		public bool IsAdministrated
		{
			get
			{
				return this.chkBoxAdministrated.Checked;
			}
			set
			{
				this.chkBoxAdministrated.Checked = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00008618 File Offset: 0x00007618
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00008630 File Offset: 0x00007630
		public string AdminPassword
		{
			get
			{
				return this.txtBoxAdminPassword.Text;
			}
			set
			{
				this.txtBoxAdminPassword.Text = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000864C File Offset: 0x0000764C
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000866C File Offset: 0x0000766C
		public int Port
		{
			get
			{
				return int.Parse(this.txtBoxPort.Text);
			}
			set
			{
				this.txtBoxPort.Text = value.ToString();
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000868C File Offset: 0x0000768C
		public frmServerSettings()
		{
			this.InitializeComponent();
			Database.ScanAndReplaceStringIds(this);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00008C4C File Offset: 0x00007C4C
		private void chkBoxAdministrated_CheckedChanged(object sender, EventArgs e)
		{
			this.txtBoxAdminPassword.Enabled = this.IsAdministrated;
			this.lblAdminPassword.Enabled = this.IsAdministrated;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00008C7C File Offset: 0x00007C7C
		private void txtBoxPort_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '\r';
			e.Handled = !flag;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00008CB8 File Offset: 0x00007CB8
		private bool ValidPort(string portString, out string errorMsg)
		{
			errorMsg = "";
			if (portString.Length == 0)
			{
				errorMsg = Database.GetString("ERR_PortRequired");
				return false;
			}
			int num = int.Parse(portString);
			if (num < 1024 || num > 65505)
			{
				errorMsg = string.Format(Database.GetString("ERR_PortRange"), 1024, 65505);
				return false;
			}
			return true;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00008D24 File Offset: 0x00007D24
		private void txtBoxPort_Validated(object sender, EventArgs e)
		{
			this.errorProviderPort.SetError(this.txtBoxPort, "");
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00008D48 File Offset: 0x00007D48
		private void txtBoxPort_Validating(object sender, CancelEventArgs e)
		{
			string text = "";
			if (!this.ValidPort(this.txtBoxPort.Text, out text))
			{
				e.Cancel = true;
				this.txtBoxPort.Select(0, this.txtBoxPort.Text.Length);
				this.errorProviderPort.SetError(this.txtBoxPort, text);
			}
		}

		// Token: 0x0400009F RID: 159
		private const int PortRangeMinimum = 1024;

		// Token: 0x040000A0 RID: 160
		private const int PortRangeMaximum = 65505;
	}
}
