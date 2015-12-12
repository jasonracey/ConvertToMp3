using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertToMp3
{
    public partial class FormConvertToMp3 : Form
    {
        private Converter _converter;

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
                    foreach (var file in FileFinder.GetSupportedFiles(selectedPath))
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

            var sourceFilePaths = listBox.Items.Cast<string>().ToList();

            _converter = new Converter();

            timer.Interval = 500;
            timer.Start();

            Task.Run(() =>
            {
                _converter.ConvertFiles(sourceFilePaths, checkBoxDeleteOriginals.Checked);
            })
            .ContinueWith(task => timer.Stop(), TaskScheduler.FromCurrentSynchronizationContext())
            .ContinueWith(task => SetStateIdle(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var path in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(path))
                {
                    foreach (var file in FileFinder.GetSupportedFiles(path))
                    {
                        listBox.Items.Add(file);
                    }
                }
                else if (File.Exists(path))
                {
                    listBox.Items.Add(path);
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
            if (_converter.State != null)
            {
                labelMessage.Text = _converter.State;
            }

            SetProgressLabel(_converter.ProcessedSourceFiles, _converter.TotalSourceFiles);

            progressBar.Maximum = _converter.TotalSourceFiles;
            progressBar.Value = _converter.ProcessedSourceFiles;
        }

        private void SetButtonState()
        {
            var listBoxHasItems = listBox.Items.Count > 0;
            buttonStart.Enabled = listBoxHasItems;
            buttonClear.Enabled = listBoxHasItems;
        }

        private void SetProgressLabel(int processedSourceFiles, int totalSourceFiles)
        {
            labelProgress.Text = $@"{processedSourceFiles}/{totalSourceFiles}";
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
            listBox.Enabled = true;
            listBox.Items.Clear();
            progressBar.Value = 0;
            SetProgressLabel(0, 0);
            timer.Enabled = false;
        }
    }
}
