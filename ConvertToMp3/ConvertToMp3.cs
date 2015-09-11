using System;
using System.IO;
using System.Windows.Forms;

namespace ConvertToMp3
{
    public partial class FormConvertToMp3 : Form
    {
        private const string FileSearchPattern = "*.*";

        public FormConvertToMp3()
        {
            InitializeComponent();
        }

        private void FormConvertToMp3_Load(object sender, EventArgs e)
        {
            SetStateIdle();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var selectedPath = folderBrowserDialog.SelectedPath;
                if (Directory.Exists(selectedPath))
                {
                    var files = Directory.GetFiles(selectedPath, FileSearchPattern, SearchOption.AllDirectories);
                    foreach (var file in files)
                    {
                        listBox.Items.Add(file);
                    }
                }
            }
            SetButtonState();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            SetStateIdle();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            SetStateBusy();
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(item))
                {
                    foreach (var file in Directory.GetFiles(item, FileSearchPattern, SearchOption.AllDirectories))
                    {
                        listBox.Items.Add(file);
                    }
                }
                else if (File.Exists(item))
                {
                    listBox.Items.Add(item);
                }
            }
            SetButtonState();
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }

        private void SetButtonState()
        {
            var listBoxHasItems = listBox.Items.Count > 0;
            buttonStart.Enabled = listBoxHasItems;
            buttonClear.Enabled = listBoxHasItems;
        }

        private void SetStateBusy()
        {
            buttonBrowse.Enabled = false;
            buttonClear.Enabled = false;
            buttonStart.Enabled = false;
            checkBoxDeleteOriginals.Enabled = false;
            labelMessage.Text = @"Converting files";
            listBox.Enabled = false;
        }

        private void SetStateIdle()
        {
            buttonBrowse.Enabled = true;
            buttonClear.Enabled = false;
            buttonStart.Enabled = false;
            checkBoxDeleteOriginals.Enabled = true;
            labelMessage.Text = @"Drop files here";
            labelProgress.Text = @"0/0";
            listBox.Enabled = true;
            listBox.Items.Clear();
            timer.Enabled = false;
        }
    }
}
