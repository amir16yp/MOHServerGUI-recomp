using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x02000013 RID: 19
	public class ProcessStarter : AsyncOperation
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000AC RID: 172 RVA: 0x00008358 File Offset: 0x00007358
		// (remove) Token: 0x060000AD RID: 173 RVA: 0x0000837C File Offset: 0x0000737C
		public event DataReceivedHandler StdOutReceived;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000AE RID: 174 RVA: 0x000083A0 File Offset: 0x000073A0
		// (remove) Token: 0x060000AF RID: 175 RVA: 0x000083C4 File Offset: 0x000073C4
		public event DataReceivedHandler StdErrReceived;

		// Token: 0x060000B0 RID: 176 RVA: 0x000083E8 File Offset: 0x000073E8
		public ProcessStarter(ISynchronizeInvoke isi)
			: base(isi)
		{
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00008408 File Offset: 0x00007408
		protected override void Launch()
		{
			this.StartProcess();
			while (!this.process.HasExited)
			{
				Thread.Sleep(this.SleepTime);
				if (base.CancelRequested && !base.IsDone)
				{
					this.process.Kill();
					base.AcknowledgeCancel();
				}
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00008458 File Offset: 0x00007458
		protected virtual void StartProcess()
		{
			if (!File.Exists(this.FileName))
			{
				throw new FileNotFoundException(string.Format(Database.GetString("CMN_FileNotExist"), this.FileName), this.FileName);
			}
			this.process = new Process();
			this.process.StartInfo.UseShellExecute = false;
			this.process.StartInfo.RedirectStandardOutput = true;
			this.process.StartInfo.RedirectStandardError = true;
			this.process.StartInfo.CreateNoWindow = true;
			this.process.StartInfo.FileName = this.FileName;
			this.process.StartInfo.Arguments = this.Arguments;
			this.process.StartInfo.WorkingDirectory = this.WorkingDirectory;
			this.process.Start();
			new MethodInvoker(this.ReadStdOut).BeginInvoke(null, null);
			new MethodInvoker(this.ReadStdErr).BeginInvoke(null, null);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000855C File Offset: 0x0000755C
		protected virtual void ReadStdOut()
		{
			string text;
			while ((text = this.process.StandardOutput.ReadLine()) != null)
			{
				base.FireAsync(this.StdOutReceived, new object[]
				{
					this,
					new DataReceivedEventArgs(text)
				});
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000085A0 File Offset: 0x000075A0
		protected virtual void ReadStdErr()
		{
			string text;
			while ((text = this.process.StandardError.ReadLine()) != null)
			{
				base.FireAsync(this.StdErrReceived, new object[]
				{
					this,
					new DataReceivedEventArgs(text)
				});
			}
		}

		// Token: 0x04000098 RID: 152
		public string FileName;

		// Token: 0x04000099 RID: 153
		public string Arguments;

		// Token: 0x0400009A RID: 154
		public string WorkingDirectory;

		// Token: 0x0400009D RID: 157
		public int SleepTime = 500;

		// Token: 0x0400009E RID: 158
		private Process process;
	}
}
