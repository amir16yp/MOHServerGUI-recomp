using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace MOHServer
{
	// Token: 0x02000006 RID: 6
	public abstract class AsyncOperation
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002E1C File Offset: 0x00001E1C
		public AsyncOperation(ISynchronizeInvoke target)
		{
			this.isiTarget = target;
			this.isRunning = false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002E40 File Offset: 0x00001E40
		public void Start()
		{
			lock (this)
			{
				if (this.isRunning)
				{
					throw new AlreadyRunningException();
				}
				this.isRunning = true;
			}
			MethodInvoker methodInvoker = new MethodInvoker(this.InternalStart);
			methodInvoker.BeginInvoke(null, null);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002EA8 File Offset: 0x00001EA8
		public virtual void Cancel()
		{
			lock (this)
			{
				this.cancelledFlag = true;
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002EEC File Offset: 0x00001EEC
		public bool CancelAndWait()
		{
			lock (this)
			{
				this.cancelledFlag = true;
				while (!this.IsDone)
				{
					Monitor.Wait(this, 1000);
				}
			}
			return !this.HasCompleted;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002F4C File Offset: 0x00001F4C
		public bool WaitUntilDone()
		{
			lock (this)
			{
				while (!this.IsDone)
				{
					Monitor.Wait(this, 1000);
				}
			}
			return this.HasCompleted;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002FA4 File Offset: 0x00001FA4
		public bool IsDone
		{
			get
			{
				bool flag;
				lock (this)
				{
					flag = this.completeFlag || this.cancelAcknowledgedFlag || this.failedFlag;
				}
				return flag;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000023 RID: 35 RVA: 0x00002FFC File Offset: 0x00001FFC
		// (remove) Token: 0x06000024 RID: 36 RVA: 0x00003020 File Offset: 0x00002020
		public event EventHandler Completed;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000025 RID: 37 RVA: 0x00003044 File Offset: 0x00002044
		// (remove) Token: 0x06000026 RID: 38 RVA: 0x00003068 File Offset: 0x00002068
		public event EventHandler Cancelled;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000027 RID: 39 RVA: 0x0000308C File Offset: 0x0000208C
		// (remove) Token: 0x06000028 RID: 40 RVA: 0x000030B0 File Offset: 0x000020B0
		public event ThreadExceptionEventHandler Failed;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000030D4 File Offset: 0x000020D4
		protected ISynchronizeInvoke Target
		{
			get
			{
				return this.isiTarget;
			}
		}

		// Token: 0x0600002A RID: 42
		protected abstract void Launch();

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000030E8 File Offset: 0x000020E8
		protected bool CancelRequested
		{
			get
			{
				bool flag;
				lock (this)
				{
					flag = this.cancelledFlag;
				}
				return flag;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000312C File Offset: 0x0000212C
		protected bool HasCompleted
		{
			get
			{
				bool flag;
				lock (this)
				{
					flag = this.completeFlag;
				}
				return flag;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003170 File Offset: 0x00002170
		protected void AcknowledgeCancel()
		{
			lock (this)
			{
				this.cancelAcknowledgedFlag = true;
				this.isRunning = false;
				Monitor.Pulse(this);
				this.FireAsync(this.Cancelled, new object[]
				{
					this,
					EventArgs.Empty
				});
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000031E0 File Offset: 0x000021E0
		private void InternalStart()
		{
			this.cancelledFlag = false;
			this.completeFlag = false;
			this.cancelAcknowledgedFlag = false;
			this.failedFlag = false;
			try
			{
				this.Launch();
			}
			catch (Exception ex)
			{
				try
				{
					this.FailOperation(ex);
				}
				catch
				{
				}
				if (ex is SystemException)
				{
					throw ex;
				}
			}
			lock (this)
			{
				if (!this.cancelAcknowledgedFlag && !this.failedFlag)
				{
					this.CompleteOperation();
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000032A0 File Offset: 0x000022A0
		private void CompleteOperation()
		{
			lock (this)
			{
				this.completeFlag = true;
				this.isRunning = false;
				Monitor.Pulse(this);
				this.FireAsync(this.Completed, new object[]
				{
					this,
					EventArgs.Empty
				});
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003310 File Offset: 0x00002310
		private void FailOperation(Exception e)
		{
			lock (this)
			{
				this.failedFlag = true;
				this.isRunning = false;
				Monitor.Pulse(this);
				this.FireAsync(this.Failed, new object[]
				{
					this,
					new ThreadExceptionEventArgs(e)
				});
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003380 File Offset: 0x00002380
		protected void FireAsync(Delegate dlg, params object[] pList)
		{
			if (dlg != null)
			{
				this.Target.BeginInvoke(dlg, pList);
			}
		}

		// Token: 0x04000011 RID: 17
		private ISynchronizeInvoke isiTarget;

		// Token: 0x04000012 RID: 18
		private bool cancelledFlag;

		// Token: 0x04000013 RID: 19
		private bool completeFlag;

		// Token: 0x04000014 RID: 20
		private bool cancelAcknowledgedFlag;

		// Token: 0x04000015 RID: 21
		private bool failedFlag;

		// Token: 0x04000016 RID: 22
		private bool isRunning;
	}
}
