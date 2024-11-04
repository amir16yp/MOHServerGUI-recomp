using System;

namespace MOHServer
{
	// Token: 0x02000012 RID: 18
	public class DataReceivedEventArgs : EventArgs
	{
		// Token: 0x060000AB RID: 171 RVA: 0x0000833C File Offset: 0x0000733C
		public DataReceivedEventArgs(string text)
		{
			this.Text = text;
		}

		// Token: 0x04000097 RID: 151
		public string Text;
	}
}
