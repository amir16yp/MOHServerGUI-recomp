using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace MOHServer.Text
{
    public class Database
    {
        public static string GetString(string stringId)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Database));
            string text = resourceManager.GetString(stringId);
            if (text == null)
            {
                text = string.Format("<{0}>", stringId);
            }
            return text;
        }

        public static void ScanAndReplaceStringIds(Form frm)
        {
            ScanAndReplaceStringIdsHelper(frm);
            if (frm.Menu != null)
            {
                ScanAndReplaceStringIdsHelper(frm.Menu);
            }
        }

        public static void ScanAndReplaceStringIds(Menu menu)
        {
            foreach (MenuItem menuItem in menu.MenuItems)
            {
                ScanAndReplaceStringIdsHelper(menuItem);
            }
        }

        public static void ScanAndReplaceStringIds(Control control)
        {
            foreach (Control control2 in control.Controls)
            {
                if (control2 is ListView listView)
                {
                    ScanAndReplaceStringIdsHelper(listView);
                }
                else if (control2 is ComboBox comboBox)
                {
                    ScanAndReplaceStringIdsHelper(comboBox);
                }
                else if (control2 is DataGrid dataGrid)
                {
                    ScanAndReplaceDataGridStringIds(dataGrid);
                }
                else
                {
                    ScanAndReplaceStringIdsHelper(control2);
                }
            }
        }

        private static void ScanAndReplaceStringIdsHelper(Control control)
        {
            ReplaceStringId(control, "Text");
            ReplaceStringId(control, "ToolTipText");
            ScanAndReplaceStringIds(control);
            if (control.ContextMenu != null)
            {
                ScanAndReplaceStringIds(control.ContextMenu);
            }
        }

        private static void ScanAndReplaceDataGridStringIds(DataGrid datagrid)
        {
            // Replace strings on the DataGrid control itself
            ReplaceStringId(datagrid, "Text");
            ReplaceStringId(datagrid, "ToolTipText");

            // Handle the table styles and columns
            foreach (DataGridTableStyle tableStyle in datagrid.TableStyles)
            {
                foreach (DataGridColumnStyle columnStyle in tableStyle.GridColumnStyles)
                {
                    ReplaceStringId(columnStyle, "HeaderText");
                }
            }

            // Handle child controls if any
            foreach (Control childControl in datagrid.Controls)
            {
                ScanAndReplaceStringIdsHelper(childControl);
            }

            // Handle context menu if present
            if (datagrid.ContextMenu != null)
            {
                ScanAndReplaceStringIds(datagrid.ContextMenu);
            }
        }

        private static void ScanAndReplaceStringIdsHelper(ListView listView)
        {
            // Handle the base control properties
            ReplaceStringId(listView, "Text");
            ReplaceStringId(listView, "ToolTipText");

            // Handle columns
            foreach (ColumnHeader columnHeader in listView.Columns)
            {
                ReplaceStringId(columnHeader, "Text");
            }

            // Handle child controls
            foreach (Control childControl in listView.Controls)
            {
                ScanAndReplaceStringIdsHelper(childControl);
            }
        }

        private static void ScanAndReplaceStringIdsHelper(ComboBox combo)
        {
            // Handle the base control properties
            ReplaceStringId(combo, "Text");
            ReplaceStringId(combo, "ToolTipText");

            // Handle items
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i] is string text && text.StartsWith("$"))
                {
                    combo.Items[i] = GetString(text.Substring(1));
                }
            }

            // Handle child controls if any
            foreach (Control childControl in combo.Controls)
            {
                ScanAndReplaceStringIdsHelper(childControl);
            }
        }

        private static void ScanAndReplaceStringIdsHelper(Menu menu)
        {
            ReplaceStringId(menu, "Text");
            if (menu is MenuItem menuItem)
            {
                foreach (MenuItem childMenuItem in menuItem.MenuItems)
                {
                    ScanAndReplaceStringIdsHelper(childMenuItem);
                }
            }
        }

        private static void ReplaceStringId(object control, string propertyName)
        {
            Type type = control.GetType();
            MemberInfo[] member = type.GetMember(propertyName, MemberTypes.Property,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty);

            if (member.Length > 0)
            {
                string text = type.InvokeMember(propertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty,
                    null, control, new object[0]).ToString();

                if (text.StartsWith("$"))
                {
                    string newString = GetString(text.Substring(1));
                    type.InvokeMember(propertyName,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                        null, control, new object[] { newString });
                }
            }
        }
    }
}