using System.Diagnostics;
using System.Windows.Forms;

namespace AnfiniL.SqlExpressProfiler.Controls
{
    public static class Utils
    {
        public static DataGridViewColumn NewTextBoxColumn(string name, string propertyName, bool readOnly)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn
                                              { DataPropertyName = propertyName, Name = name, ReadOnly = readOnly };

            return c;
        }

        public static DataGridViewColumn NewComboBoxColumn(string name, string propertyName, bool readOnly, object dataSource, string displayMember)
        {
            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn
                                               {
                                                   DisplayMember = displayMember,
                                                   DataSource = dataSource,
                                                   DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                                                   DataPropertyName = propertyName,
                                                   Name = name,
                                                   ReadOnly = readOnly
                                               };

            return c;
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process p = new Process();
                ProcessStartInfo info = new ProcessStartInfo(url);
                p.StartInfo = info;
                p.Start();
            }
            catch
            {
            }
        }
    }
}
