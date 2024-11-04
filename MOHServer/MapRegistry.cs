using System;
using System.Collections;
using MOHServer.Text;

namespace MOHServer
{
	// Token: 0x0200000E RID: 14
	public class MapRegistry
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00007E94 File Offset: 0x00006E94
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00007EA8 File Offset: 0x00006EA8
		public static ArrayList SelectedMaps
		{
			get
			{
				return MapRegistry.m_selectedMaps;
			}
			set
			{
				MapRegistry.m_selectedMaps = value;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00007ED0 File Offset: 0x00006ED0
		public static ArrayList GetMapEntries()
		{
			ArrayList arrayList = new ArrayList(MapRegistry.MapList.Length);
			arrayList.AddRange(MapRegistry.MapList);
			return arrayList;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00007EF8 File Offset: 0x00006EF8
		public static ArrayList GetMapIds(MapRegistry.GameMode mode)
		{
			ArrayList arrayList = new ArrayList(MapRegistry.MapList.Length);
			for (int i = 0; i < MapRegistry.MapList.Length; i++)
			{
				if (mode == MapRegistry.GameMode.All || MapRegistry.MapList[i].Mode == mode)
				{
					arrayList.Add(MapRegistry.MapList[i].Id);
				}
			}
			return arrayList;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007F50 File Offset: 0x00006F50
		public static ArrayList GetMapNames(MapRegistry.GameMode mode)
		{
			ArrayList arrayList = new ArrayList(MapRegistry.MapList.Length);
			for (int i = 0; i < MapRegistry.MapList.Length; i++)
			{
				if ((mode == MapRegistry.GameMode.All || MapRegistry.MapList[i].Mode == mode) && !arrayList.Contains(MapRegistry.MapList[i].Name))
				{
					arrayList.Add(MapRegistry.MapList[i].Name);
				}
			}
			return arrayList;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007FB8 File Offset: 0x00006FB8
		public static string GetModeName(int id)
		{
			return MapRegistry.GetMode(id).ToString().Replace("_", " ");
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00007FE4 File Offset: 0x00006FE4
		public static MapRegistry.GameMode GetMode(int id)
		{
			for (int i = 0; i < MapRegistry.MapList.Length; i++)
			{
				if (MapRegistry.MapList[i].Id == id)
				{
					return MapRegistry.MapList[i].Mode;
				}
			}
			return MapRegistry.GameMode.All;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00008020 File Offset: 0x00007020
		public static string GetName(int id)
		{
			for (int i = 0; i < MapRegistry.MapList.Length; i++)
			{
				if (MapRegistry.MapList[i].Id == id)
				{
					return MapRegistry.MapList[i].Name;
				}
			}
			return "";
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00008060 File Offset: 0x00007060
		public static int GetId(string mapName, MapRegistry.GameMode mode)
		{
			for (int i = 0; i < MapRegistry.MapList.Length; i++)
			{
				if (MapRegistry.MapList[i].Name == mapName && MapRegistry.MapList[i].Mode == mode)
				{
					return MapRegistry.MapList[i].Id;
				}
			}
			return -1;
		}

		// Token: 0x0400008B RID: 139
		private static readonly MapRegistry.MapEntry[] MapList = new MapRegistry.MapEntry[]
		{
			new MapRegistry.MapEntry(211, MapRegistry.GameMode.Domination),
			new MapRegistry.MapEntry(281, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(222, MapRegistry.GameMode.Infiltration),
			new MapRegistry.MapEntry(282, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(283, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(245, MapRegistry.GameMode.Hold_the_Line),
			new MapRegistry.MapEntry(285, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(216, MapRegistry.GameMode.Domination),
			new MapRegistry.MapEntry(286, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(131, MapRegistry.GameMode.Demolition),
			new MapRegistry.MapEntry(181, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(132, MapRegistry.GameMode.Demolition),
			new MapRegistry.MapEntry(182, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(124, MapRegistry.GameMode.Infiltration),
			new MapRegistry.MapEntry(184, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(153, MapRegistry.GameMode.Battle_Lines),
			new MapRegistry.MapEntry(183, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(115, MapRegistry.GameMode.Domination),
			new MapRegistry.MapEntry(185, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(341, MapRegistry.GameMode.Hold_the_Line),
			new MapRegistry.MapEntry(381, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(352, MapRegistry.GameMode.Battle_Lines),
			new MapRegistry.MapEntry(382, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(383, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(324, MapRegistry.GameMode.Infiltration),
			new MapRegistry.MapEntry(384, MapRegistry.GameMode.Deathmatch),
			new MapRegistry.MapEntry(336, MapRegistry.GameMode.Demolition),
			new MapRegistry.MapEntry(386, MapRegistry.GameMode.Deathmatch)
		};

		// Token: 0x0400008C RID: 140
		private static ArrayList m_selectedMaps = new ArrayList(MapRegistry.MapList.Length);

		// Token: 0x0200000F RID: 15
		public enum GameMode
		{
			// Token: 0x0400008E RID: 142
			All,
			// Token: 0x0400008F RID: 143
			Deathmatch,
			// Token: 0x04000090 RID: 144
			Infiltration,
			// Token: 0x04000091 RID: 145
			Demolition,
			// Token: 0x04000092 RID: 146
			Hold_the_Line,
			// Token: 0x04000093 RID: 147
			Battle_Lines,
			// Token: 0x04000094 RID: 148
			Domination
		}

		// Token: 0x02000010 RID: 16
		internal class MapEntry
		{
			// Token: 0x060000A0 RID: 160 RVA: 0x00008274 File Offset: 0x00007274
			public MapEntry(int id, MapRegistry.GameMode mode)
			{
				this.m_id = id;
				this.m_mode = mode;
			}

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x060000A1 RID: 161 RVA: 0x00008298 File Offset: 0x00007298
			// (set) Token: 0x060000A2 RID: 162 RVA: 0x000082AC File Offset: 0x000072AC
			public int Id
			{
				get
				{
					return this.m_id;
				}
				set
				{
					this.m_id = value;
				}
			}

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x060000A3 RID: 163 RVA: 0x000082C0 File Offset: 0x000072C0
			public string Name
			{
				get
				{
					return Database.GetString(string.Format("MAP_{0}", this.Id));
				}
			}

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x060000A4 RID: 164 RVA: 0x000082E8 File Offset: 0x000072E8
			// (set) Token: 0x060000A5 RID: 165 RVA: 0x000082FC File Offset: 0x000072FC
			public MapRegistry.GameMode Mode
			{
				get
				{
					return this.m_mode;
				}
				set
				{
					this.m_mode = value;
				}
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x060000A6 RID: 166 RVA: 0x00008310 File Offset: 0x00007310
			public string ModeName
			{
				get
				{
					return Database.GetString(string.Format("GM_{0}", this.m_mode.ToString()));
				}
			}

			// Token: 0x04000095 RID: 149
			private int m_id;

			// Token: 0x04000096 RID: 150
			private MapRegistry.GameMode m_mode;
		}
	}
}
