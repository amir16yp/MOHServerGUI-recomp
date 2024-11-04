using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x02000003 RID: 3
	public partial class frmAbout : Form
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002450 File Offset: 0x00001450
		public frmAbout()
		{
			this.InitializeComponent();
			Database.ScanAndReplaceStringIds(this);
		}
	}
}
