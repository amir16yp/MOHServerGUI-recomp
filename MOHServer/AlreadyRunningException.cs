using System;

namespace MOHServer
{
	// Token: 0x02000005 RID: 5
	public class AlreadyRunningException : ApplicationException
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002E04 File Offset: 0x00001E04
		public AlreadyRunningException()
			: base("Asynchronous operation already running")
		{
		}
	}
}
