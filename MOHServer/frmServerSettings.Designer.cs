namespace MOHServer
{
	// Token: 0x02000014 RID: 20
	public partial class frmServerSettings : global::System.Windows.Forms.Form
	{
		// Token: 0x060000BC RID: 188 RVA: 0x000086B4 File Offset: 0x000076B4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000086E0 File Offset: 0x000076E0
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxAdmin = new System.Windows.Forms.GroupBox();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtBoxAdminPassword = new System.Windows.Forms.TextBox();
            this.chkBoxAdministrated = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.errorProviderPort = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBoxAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(40, 152);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "$CMN_OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(176, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "$CMN_Cancel";
            // 
            // grpBoxAdmin
            // 
            this.grpBoxAdmin.Controls.Add(this.lblAdminPassword);
            this.grpBoxAdmin.Controls.Add(this.txtBoxAdminPassword);
            this.grpBoxAdmin.Controls.Add(this.chkBoxAdministrated);
            this.grpBoxAdmin.Location = new System.Drawing.Point(14, 48);
            this.grpBoxAdmin.Name = "grpBoxAdmin";
            this.grpBoxAdmin.Size = new System.Drawing.Size(264, 96);
            this.grpBoxAdmin.TabIndex = 2;
            this.grpBoxAdmin.TabStop = false;
            this.grpBoxAdmin.Text = "$CMN_AdminSettings";
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.Enabled = false;
            this.lblAdminPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAdminPassword.Location = new System.Drawing.Point(16, 56);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(88, 32);
            this.lblAdminPassword.TabIndex = 2;
            this.lblAdminPassword.Text = "$CMN_AdminPwd";
            // 
            // txtBoxAdminPassword
            // 
            this.txtBoxAdminPassword.Enabled = false;
            this.txtBoxAdminPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBoxAdminPassword.Location = new System.Drawing.Point(112, 56);
            this.txtBoxAdminPassword.Name = "txtBoxAdminPassword";
            this.txtBoxAdminPassword.PasswordChar = '*';
            this.txtBoxAdminPassword.Size = new System.Drawing.Size(144, 20);
            this.txtBoxAdminPassword.TabIndex = 4;
            // 
            // chkBoxAdministrated
            // 
            this.chkBoxAdministrated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBoxAdministrated.Location = new System.Drawing.Point(16, 24);
            this.chkBoxAdministrated.Name = "chkBoxAdministrated";
            this.chkBoxAdministrated.Size = new System.Drawing.Size(240, 24);
            this.chkBoxAdministrated.TabIndex = 3;
            this.chkBoxAdministrated.Text = "$CMN_AdminServer";
            this.chkBoxAdministrated.CheckedChanged += new System.EventHandler(this.chkBoxAdministrated_CheckedChanged);
            // 
            // lblPort
            // 
            this.lblPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPort.Location = new System.Drawing.Point(16, 16);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(64, 24);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port:";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Location = new System.Drawing.Point(88, 16);
            this.txtBoxPort.MaxLength = 5;
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(184, 20);
            this.txtBoxPort.TabIndex = 1;
            this.txtBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPort_KeyPress);
            this.txtBoxPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPort_Validating);
            this.txtBoxPort.Validated += new System.EventHandler(this.txtBoxPort_Validated);
            // 
            // errorProviderPort
            // 
            this.errorProviderPort.ContainerControl = this;
            // 
            // frmServerSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 191);
            this.Controls.Add(this.txtBoxPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.grpBoxAdmin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServerSettings";
            this.ShowInTaskbar = false;
            this.Text = "Server Settings";
            this.grpBoxAdmin.ResumeLayout(false);
            this.grpBoxAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.GroupBox grpBoxAdmin;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Label lblAdminPassword;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.TextBox txtBoxAdminPassword;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.CheckBox chkBoxAdministrated;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Label lblPort;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.TextBox txtBoxPort;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.ErrorProvider errorProviderPort;
        private System.ComponentModel.IContainer components;
    }
}
