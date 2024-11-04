using System;
using System.Collections;
using System.Windows.Forms;

namespace MOHServer
{
	// Token: 0x0200000A RID: 10
	public class ListViewColumnSorter : IComparer
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000050C0 File Offset: 0x000040C0
		public ListViewColumnSorter()
		{
			this.m_sortColumn = 0;
			this.m_sortOrder = SortOrder.None;
			this.m_objectCompare = new CaseInsensitiveComparer();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000050EC File Offset: 0x000040EC
		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			int num = this.m_objectCompare.Compare(listViewItem.SubItems[this.m_sortColumn].Text, listViewItem2.SubItems[this.m_sortColumn].Text);
			if (this.m_sortOrder == SortOrder.Ascending)
			{
				return num;
			}
			if (this.m_sortOrder == SortOrder.Descending)
			{
				return -num;
			}
			return 0;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00005158 File Offset: 0x00004158
		// (set) Token: 0x06000060 RID: 96 RVA: 0x0000516C File Offset: 0x0000416C
		public int SortColumn
		{
			get
			{
				return this.m_sortColumn;
			}
			set
			{
				this.m_sortColumn = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00005180 File Offset: 0x00004180
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00005194 File Offset: 0x00004194
		public SortOrder Order
		{
			get
			{
				return this.m_sortOrder;
			}
			set
			{
				this.m_sortOrder = value;
			}
		}

		// Token: 0x0400003B RID: 59
		private int m_sortColumn;

		// Token: 0x0400003C RID: 60
		private SortOrder m_sortOrder;

		// Token: 0x0400003D RID: 61
		private CaseInsensitiveComparer m_objectCompare;
	}
}
