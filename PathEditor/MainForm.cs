using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.IO;

namespace PathEditor
{
    public partial class MainForm : Form
    {
        private Context _currentContext { get; set; }
        private bool _backupBeforeApply { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        #region Controls

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyPrompt();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewVar(txtAdd.Text);
        }

        private void menuItemSwitch_Click(object sender, EventArgs e)
        {
            ToggleContext();
        }

        private void menuItemInvalidate_Click(object sender, EventArgs e)
        {
            InvalidatePaths(_currentContext);
        }

        private void menuItemAutoBackup_Click(object sender, EventArgs e)
        {
            menuItemAutoBackup.Checked = !menuItemAutoBackup.Checked;
            _backupBeforeApply = menuItemAutoBackup.Checked;
        }

        private void menuItemBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.DefaultExt = "txt";
                dialog.FileName = GetBackupName();

                dialog.ShowDialog();

                CreateBackup(_currentContext, dialog.FileName);
            }
        }

        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;

                dialog.ShowDialog();

                LoadBackup(dialog.FileName);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Directory.Exists(dialog.SelectedPath))
                    {
                        txtAdd.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        txtAdd.BackColor = Color.Red;
                    }

                    txtAdd.Text = dialog.SelectedPath;
                }
            }
        }

        #endregion

        private void LoadMain(object sender, EventArgs e)
        {
            _currentContext = Context.Global;
            _backupBeforeApply = menuItemAutoBackup.Checked;

            RefreshList();
        }

        private void ApplyPrompt()
        {
            var backup = _backupBeforeApply
                ? "\nA backup of the existing path variable will be automatically created.\n"
                : "\nIt is recommended to create a backup before making changes.\n";

            DialogResult confirm = MessageBox.Show(
                string.Format("You are about to apply new changes to the [{0}] PATH variable.\n{1}\nDo you wish to continue?",
                    _currentContext.ToString(), backup),
                "Do you wish to continue?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (confirm == DialogResult.Yes)
            {
                var success = _backupBeforeApply 
                    ? AutoBackup(_currentContext) 
                    : true;

                if (success)
                {
                    var pathVariable = ConstructPathFromList();
                    SetPathVariable(_currentContext, pathVariable);
                }
                else
                {
                    MessageBox.Show("Could not create backup\n\nAborting.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ToggleContext()
        {
            _currentContext = _currentContext == Context.Global
                ? Context.User
                : Context.Global;

            var title = _currentContext == Context.Global
                ? "Switch to User"
                : "Switch to Global";

            menuItemSwitch.Text = title;

            RefreshList();
        }

        private void RefreshList()
        {
            var variables = GetPathVariable(_currentContext);
            InitListView(variables);
        }

        private void InitListView(List<string> vars)
        {
            listView1.Clear();

            listView1.Scrollable = true;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Sorting = SortOrder.Ascending;

            var header = new ColumnHeader();
            header.Text = "Path (" + vars.Count.ToString() + ")";
            header.Name = "col1";
            header.Width = 600;
            listView1.Columns.Add(header);

            foreach (var v in vars)
            {
                var item = new ListViewItem(v);
                item.Checked = true;
                listView1.Items.Add(item);
            }
        }

        private void InvalidatePaths(Context ctx)
        {
            foreach(ListViewItem item in listView1.Items)
            {
                var exists = Directory.Exists(item.Text);

                item.BackColor = exists ? Color.LightGreen : Color.Red;
            }
        }

        private enum Context
        {
            Global = EnvironmentVariableTarget.Machine,
            User = EnvironmentVariableTarget.User
        }

        private void LoadBackup(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exists: " + path,
                    "Error: File does not exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            var content = File.ReadAllText(path);

            var vars = content.Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList<string>();

            InitListView(vars);
        }

        private bool AutoBackup(Context ctx)
        {
            var pathVar = Environment.GetEnvironmentVariable("path",
                (EnvironmentVariableTarget)ctx);

            var name = string.Format("path-editor-auto-backup-{0}-{1}-{2}.txt",
                    _currentContext.ToString(),
                    DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToLongTimeString());

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), name);
            
            if (File.Exists(path))
            {
                MessageBox.Show("Could not create backup file. File already exists.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                return false;
            }

            File.WriteAllText(path, pathVar);

            return true;
        }

        private void CreateBackup(Context ctx, string filename)
        {
            var pathVar = Environment.GetEnvironmentVariable("path",
                (EnvironmentVariableTarget)ctx);

            if (File.Exists(filename))
            {
                MessageBox.Show("File already exists: " + filename, 
                    "Error: File already exists", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            File.WriteAllText(filename, pathVar);
        }

        private string GetBackupName()
        {
            return string.Format("path-editor-backup-{0}-{1}-{2}",
                    _currentContext.ToString(),
                    DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToLongTimeString());
        }

        private List<string> GetPathVariable(Context ctx)
        {
            var path = Environment.GetEnvironmentVariable("path",
                (EnvironmentVariableTarget)ctx);

            return path.Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList<string>();
        }

        private void SetPathVariable(Context ctx, string var)
        {
            var pathVar = ConstructPathFromList();

            Environment.SetEnvironmentVariable("path", var,
                (EnvironmentVariableTarget)ctx);
        }

        private string ConstructPathFromList()
        {
            List<string> vars = listView1.Items
               .Cast<ListViewItem>()
               .Where(x => x.Checked)
               .Select(x => x.Text)
               .ToList<string>();

            return string.Join(";", vars);
        }

        private bool AddNewVar(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (!Directory.Exists(text))
            {
                txtAdd.BackColor = Color.Red;
                return false;
            }
            else
                txtAdd.BackColor = DefaultBackColor;

            var item = new ListViewItem();
            item.Checked = true;
            item.BackColor = Color.LightGreen;
            item.Text = text
                .TrimEnd()
                .TrimStart();

            listView1.Items.Add(item);

            return true;
        }
    }
}
