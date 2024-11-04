namespace MOHServer
{
	// Token: 0x02000004 RID: 4
	public partial class frmAcctSettings : global::System.Windows.Forms.Form
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002834 File Offset: 0x00001834
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002860 File Offset: 0x00001860
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::MOHServer.frmAcctSettings));
			this.txtPassword = new global::System.Windows.Forms.TextBox();
			this.lblPassword = new global::System.Windows.Forms.Label();
			this.lblAccount = new global::System.Windows.Forms.Label();
			this.txtAccount = new global::System.Windows.Forms.TextBox();
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.errorProviderAcctSettings = new global::System.Windows.Forms.ErrorProvider();
			base.SuspendLayout();
			this.txtPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.txtPassword.Location = new global::System.Drawing.Point(120, 48);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new global::System.Drawing.Size(120, 20);
			this.txtPassword.TabIndex = 9;
			this.txtPassword.Text = "";
			this.txtPassword.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
			this.txtPassword.Validated += new global::System.EventHandler(this.txtPassword_Validated);
			this.lblPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblPassword.Location = new global::System.Drawing.Point(16, 48);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new global::System.Drawing.Size(96, 24);
			this.lblPassword.TabIndex = 8;
			this.lblPassword.Text = "$CMN_Password";
			this.lblAccount.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.lblAccount.Location = new global::System.Drawing.Point(16, 16);
			this.lblAccount.Name = "lblAccount";
			this.lblAccount.Size = new global::System.Drawing.Size(96, 16);
			this.lblAccount.TabIndex = 7;
			this.lblAccount.Text = "$CMN_Account";
			this.txtAccount.Location = new global::System.Drawing.Point(120, 16);
			this.txtAccount.Name = "txtAccount";
			this.txtAccount.Size = new global::System.Drawing.Size(120, 20);
			this.txtAccount.TabIndex = 6;
			this.txtAccount.Text = "";
			this.txtAccount.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtAccount_Validating);
			this.txtAccount.Validated += new global::System.EventHandler(this.txtAccount_Validated);
			this.btnOk.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOk.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnOk.Location = new global::System.Drawing.Point(16, 96);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 10;
			this.btnOk.Text = "$CMN_OK";
			this.btnCancel.CausesValidation = false;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnCancel.Location = new global::System.Drawing.Point(168, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "$CMN_Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.errorProviderAcctSettings.ContainerControl = this;
			this.errorProviderAcctSettings.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("errorProviderAcctSettings.Icon");
			base.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(266, 135);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.txtPassword);
			base.Controls.Add(this.txtAccount);
			base.Controls.Add(this.lblPassword);
			base.Controls.Add(this.lblAccount);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmAcctSettings";
			base.ShowInTaskbar = false;
			this.Text = "$CMN_AccountSettings";
			base.ResumeLayout(false);
		}

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.TextBox txtPassword;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label lblPassword;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label lblAccount;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.TextBox txtAccount;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.ErrorProvider errorProviderAcctSettings;

		// Token: 0x0400000D RID: 13
		private global::System.ComponentModel.Container components = null;
	}
}
