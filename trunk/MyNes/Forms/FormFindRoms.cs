using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMB;
namespace MyNes
{
    public partial class FormFindRoms : Form
    {
        public FormFindRoms()
        {
            InitializeComponent();
            this.Tag = "find";
            comboBox_searchBy.SelectedIndex = 0;
        }
        private bool IsNumberSelection = true;
        public event EventHandler<SearchParameters> DoTheSearch;
        private void comboBox_searchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool _temp = IsNumberSelection;

            switch (comboBox_searchBy.SelectedIndex)
            {
                case 0: IsNumberSelection = false; break;
                case 1: IsNumberSelection = true; break;
                case 2: IsNumberSelection = false; break;
                case 3: IsNumberSelection = true; break;
                case 4: IsNumberSelection = true; break;
                case 5: IsNumberSelection = false; break;
                case 6: IsNumberSelection = false; break;
                case 7: IsNumberSelection = true; break;
                case 8: IsNumberSelection = true; break;
                case 9: IsNumberSelection = true; break;
                case 10: IsNumberSelection = false; break;
                case 11: IsNumberSelection = false; break;
            }
            if (_temp != IsNumberSelection)
            {
                // Refresh condition combobox
                comboBox_condition.Items.Clear();
                if (!IsNumberSelection)
                {
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_Contains"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_DoesNotContain"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_Is"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_IsNot"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_StartWith"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_DoesNotStartWith"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_EndWith"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_DoesNotEndWith"));
                }
                else
                {
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_Equal"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("Searchcondition_DoesNotEqual"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_Larger"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_EuqalLarger"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("SearchCondition_Smaller"));
                    comboBox_condition.Items.Add(Program.ResourceManager.GetString("Searchcondition_EqualSmaller"));
                }
                comboBox_condition.SelectedIndex = 0;
            }
        }
        // Close
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Search
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_findWhat.Text.Length == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_PleaseEnterSearchWord"),
                   Program.ResourceManager.GetString("MessageCaption_FindRoms"));
                return;
            }
            if (comboBox_searchBy.SelectedIndex < 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_PleaseSelectSearchBy"),
                   Program.ResourceManager.GetString("MessageCaption_FindRoms"));
                return;
            }

            SearchMode mode = (SearchMode)(comboBox_searchBy.SelectedIndex + 1);
            TextSearchCondition textCondition = TextSearchCondition.None;
            NumberSearchCondition numberCondition = NumberSearchCondition.None;
            bool isNumber = false;
            switch (comboBox_searchBy.SelectedIndex)
            {
                case 0: isNumber = false; break;
                case 1: isNumber = true; break;
                case 2: isNumber = false; break;
                case 3: isNumber = true; break;
                case 4: isNumber = true; break;
                case 5: isNumber = false; break;
                case 6: isNumber = false; break;
                case 7: isNumber = true; break;
                case 8: isNumber = true; break;
                case 9: isNumber = true; break;
                case 10: isNumber = false; break;
                case 11: isNumber = false; break;
            }
            if (!isNumber)
            {
                switch (comboBox_condition.SelectedIndex)
                {
                    case 0: textCondition = TextSearchCondition.Contains; break;
                    case 1: textCondition = TextSearchCondition.DoesNotContain; break;
                    case 2: textCondition = TextSearchCondition.Is; break;
                    case 3: textCondition = TextSearchCondition.IsNot; break;
                    case 4: textCondition = TextSearchCondition.StartWith; break;
                    case 5: textCondition = TextSearchCondition.DoesNotStartWith; break;
                    case 6: textCondition = TextSearchCondition.EndWith; break;
                    case 7: textCondition = TextSearchCondition.DoesNotEndWith; break;
                }
            }
            else
            {
                switch (comboBox_condition.SelectedIndex)
                {
                    case 0: numberCondition = NumberSearchCondition.Equal; break;
                    case 1: numberCondition = NumberSearchCondition.DoesNotEqual; break;
                    case 2: numberCondition = NumberSearchCondition.Larger; break;
                    case 3: numberCondition = NumberSearchCondition.EuqalLarger; break;
                    case 4: numberCondition = NumberSearchCondition.Smaller; break;
                    case 5: numberCondition = NumberSearchCondition.EqualSmaller; break;
                }
            }
            if (DoTheSearch != null)
                DoTheSearch(this, new SearchParameters(textBox_findWhat.Text, mode, textCondition,
                    numberCondition, checkBox1.Checked));
        }
    }
}
