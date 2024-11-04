using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x0200000D RID: 13
	public partial class frmMapList : Form
	{
		// Token: 0x0600008A RID: 138 RVA: 0x000072C4 File Offset: 0x000062C4
		public frmMapList()
		{
			this.InitializeComponent();
			this.lvwColumnSorter = new ListViewColumnSorter();
			this.listViewFrom.ListViewItemSorter = this.lvwColumnSorter;
			Database.ScanAndReplaceStringIds(this);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000079E0 File Offset: 0x000069E0
		private void frmMapList_Load(object sender, EventArgs e)
		{
			ArrayList mapEntries = MapRegistry.GetMapEntries();
			ArrayList selectedMaps = MapRegistry.SelectedMaps;
			foreach (object obj in mapEntries)
			{
				MapRegistry.MapEntry mapEntry = (MapRegistry.MapEntry)obj;
				string[] array = new string[]
				{
					mapEntry.Name,
					mapEntry.ModeName,
					mapEntry.Id.ToString()
				};
				ListViewItem listViewItem = new ListViewItem(array);
				if (selectedMaps.Contains(mapEntry.Id))
				{
					this.listViewTo.Items.Add(listViewItem);
				}
				else
				{
					this.listViewFrom.Items.Add(listViewItem);
				}
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00007AC8 File Offset: 0x00006AC8
		private void listViewFrom_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.btnAdd.Enabled = this.listViewFrom.SelectedIndices.Count > 0;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007AF4 File Offset: 0x00006AF4
		private void listViewTo_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.btnRemove.Enabled = this.listViewTo.SelectedIndices.Count > 0;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007B20 File Offset: 0x00006B20
		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (this.listViewFrom.SelectedIndices.Count > 0)
			{
				foreach (object obj in this.listViewFrom.SelectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					ListViewItem listViewItem2 = (ListViewItem)listViewItem.Clone();
					this.listViewTo.Items.Add(listViewItem2);
					this.listViewFrom.Items.Remove(listViewItem);
				}
				this.btnOk.Enabled = true;
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007BD4 File Offset: 0x00006BD4
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (this.listViewTo.SelectedIndices.Count > 0)
			{
				foreach (object obj in this.listViewTo.SelectedItems)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					ListViewItem listViewItem2 = (ListViewItem)listViewItem.Clone();
					this.listViewFrom.Items.Add(listViewItem2);
					this.listViewTo.Items.Remove(listViewItem);
				}
				this.btnOk.Enabled = this.listViewTo.Items.Count != 0;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00007CA0 File Offset: 0x00006CA0
		private void btnOk_Click(object sender, EventArgs e)
		{
			MapRegistry.SelectedMaps.Clear();
			foreach (object obj in this.listViewTo.Items)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				MapRegistry.SelectedMaps.Add(int.Parse(listViewItem.SubItems[2].Text));
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007D34 File Offset: 0x00006D34
		private void listViewFrom_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == this.lvwColumnSorter.SortColumn)
			{
				if (this.lvwColumnSorter.Order == SortOrder.Ascending)
				{
					this.lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					this.lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				this.lvwColumnSorter.SortColumn = e.Column;
				this.lvwColumnSorter.Order = SortOrder.Ascending;
			}
			this.listViewFrom.Sort();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00007DA8 File Offset: 0x00006DA8
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.listViewTo.Items.Clear();
			this.listViewFrom.Items.Clear();
			this.btnRemove.Enabled = false;
			this.btnOk.Enabled = false;
			ArrayList mapEntries = MapRegistry.GetMapEntries();
			foreach (object obj in mapEntries)
			{
				MapRegistry.MapEntry mapEntry = (MapRegistry.MapEntry)obj;
				string[] array = new string[]
				{
					mapEntry.Name,
					mapEntry.ModeName,
					mapEntry.Id.ToString()
				};
				ListViewItem listViewItem = new ListViewItem(array);
				this.listViewFrom.Items.Add(listViewItem);
			}
		}

		// Token: 0x0400007D RID: 125
		private ListViewColumnSorter lvwColumnSorter;
	}
}
