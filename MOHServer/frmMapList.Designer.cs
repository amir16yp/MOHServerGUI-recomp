namespace MOHServer
{
	// Token: 0x0200000D RID: 13
	public partial class frmMapList : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00007308 File Offset: 0x00006308
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00007334 File Offset: 0x00006334
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapList));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.listViewFrom = new System.Windows.Forms.ListView();
            this.colHeadFromMapName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadFromMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(312, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "-->";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemove.Location = new System.Drawing.Point(312, 256);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<--";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // listViewFrom
            // 
            this.listViewFrom.AutoArrange = false;
            this.listViewFrom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadFromMapName,
            this.colHeadFromMode});
            this.listViewFrom.FullRowSelect = true;
            this.listViewFrom.GridLines = true;
            this.listViewFrom.HideSelection = false;
            this.listViewFrom.Location = new System.Drawing.Point(8, 8);
            this.listViewFrom.Name = "listViewFrom";
            this.listViewFrom.Size = new System.Drawing.Size(280, 357);
            this.listViewFrom.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewFrom.TabIndex = 4;
            this.listViewFrom.UseCompatibleStateImageBehavior = false;
            this.listViewFrom.View = System.Windows.Forms.View.Details;
            this.listViewFrom.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFrom_ColumnClick);
            this.listViewFrom.SelectedIndexChanged += new System.EventHandler(this.listViewFrom_SelectedIndexChanged);
            // 
            // colHeadFromMapName
            // 
            this.colHeadFromMapName.Text = "$CMN_MapName";
            this.colHeadFromMapName.Width = 151;
            // 
            // colHeadFromMode
            // 
            this.colHeadFromMode.Text = "$CMN_GameMode";
            this.colHeadFromMode.Width = 106;
            // 
            // listViewTo
            // 
            this.listViewTo.AutoArrange = false;
            this.listViewTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewTo.FullRowSelect = true;
            this.listViewTo.GridLines = true;
            this.listViewTo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTo.HideSelection = false;
            this.listViewTo.Location = new System.Drawing.Point(416, 8);
            this.listViewTo.Name = "listViewTo";
            this.listViewTo.Size = new System.Drawing.Size(280, 357);
            this.listViewTo.TabIndex = 5;
            this.listViewTo.UseCompatibleStateImageBehavior = false;
            this.listViewTo.View = System.Windows.Forms.View.Details;
            this.listViewTo.SelectedIndexChanged += new System.EventHandler(this.listViewTo_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "$CMN_MapName";
            this.columnHeader1.Width = 149;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "$CMN_GameMode";
            this.columnHeader2.Width = 110;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(272, 424);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "$CMN_OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(392, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "$CMN_Cancel";
            // 
            // pnlControls
            // 
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Controls.Add(this.listViewFrom);
            this.pnlControls.Controls.Add(this.listViewTo);
            this.pnlControls.Controls.Add(this.btnAdd);
            this.pnlControls.Controls.Add(this.btnRemove);
            this.pnlControls.Location = new System.Drawing.Point(8, 8);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(704, 408);
            this.pnlControls.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(520, 376);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "$CMN_Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMapList
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(722, 455);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMapList";
            this.ShowInTaskbar = false;
            this.Text = "$CMN_MapSelection";
            this.Load += new System.EventHandler(this.frmMapList_Load);
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.Button btnAdd;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Button btnRemove;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.ListView listViewFrom;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.ColumnHeader colHeadFromMapName;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.ColumnHeader colHeadFromMode;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.ListView listViewTo;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Panel pnlControls;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x0400008A RID: 138
		private global::System.ComponentModel.Container components = null;
	}
}
