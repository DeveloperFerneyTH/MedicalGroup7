using System.Collections.Generic;
using System.Windows.Forms;

namespace MedicalGroup7.Utils
{
    public static class ControlsUtils
    {
        public static void LoadComboBox<T>(ComboBox comboBox, List<T> datasource, string displayMember, string valueMember)
        {
            comboBox.Items.Clear();
            comboBox.DataSource = datasource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
    }
}
