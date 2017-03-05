namespace ConvertToMp3
{
    partial class FormConvertToMp3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox = new System.Windows.Forms.ListBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.checkBoxDeleteOriginals = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 25);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox.Size = new System.Drawing.Size(560, 459);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.TabStop = false;
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(75, 13);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Drop files here";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 526);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(317, 23);
            this.progressBar.TabIndex = 2;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(497, 526);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(335, 526);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(12, 507);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(24, 13);
            this.labelProgress.TabIndex = 5;
            this.labelProgress.Text = "0/0";
            // 
            // checkBoxDeleteOriginals
            // 
            this.checkBoxDeleteOriginals.AutoSize = true;
            this.checkBoxDeleteOriginals.Location = new System.Drawing.Point(402, 490);
            this.checkBoxDeleteOriginals.Name = "checkBoxDeleteOriginals";
            this.checkBoxDeleteOriginals.Size = new System.Drawing.Size(175, 17);
            this.checkBoxDeleteOriginals.TabIndex = 0;
            this.checkBoxDeleteOriginals.Text = "delete originals after conversion";
            this.checkBoxDeleteOriginals.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(416, 526);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select folder containing files to convert";
            this.folderBrowserDialog.SelectedPath = "Y:\\Files\\Music\\add";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // FormConvertToMp3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.checkBoxDeleteOriginals);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormConvertToMp3";
            this.Text = "ConvertToMp3";
            this.Load += new System.EventHandler(this.FormConvertToMp3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.CheckBox checkBoxDeleteOriginals;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

