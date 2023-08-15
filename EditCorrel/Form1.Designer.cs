namespace EditCorrel
{
    partial class formMain
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
            this.comboBoxNames = new System.Windows.Forms.ComboBox();
            this.dataGridViewCorrel = new System.Windows.Forms.DataGridView();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxNames = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.textBoxCorrelDir = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelFile = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFreqFile = new System.Windows.Forms.Button();
            this.textBoxFreqFileDir = new System.Windows.Forms.TextBox();
            this.labelImportFreqFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrel)).BeginInit();
            this.groupBoxNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxNames
            // 
            this.comboBoxNames.FormattingEnabled = true;
            this.comboBoxNames.Location = new System.Drawing.Point(7, 37);
            this.comboBoxNames.Name = "comboBoxNames";
            this.comboBoxNames.Size = new System.Drawing.Size(244, 24);
            this.comboBoxNames.TabIndex = 0;
            // 
            // dataGridViewCorrel
            // 
            this.dataGridViewCorrel.AllowDrop = true;
            this.dataGridViewCorrel.AllowUserToAddRows = false;
            this.dataGridViewCorrel.AllowUserToDeleteRows = false;
            this.dataGridViewCorrel.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCorrel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCorrel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.OldOffset,
            this.NewOffset});
            this.dataGridViewCorrel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewCorrel.Location = new System.Drawing.Point(347, 1);
            this.dataGridViewCorrel.Name = "dataGridViewCorrel";
            this.dataGridViewCorrel.Size = new System.Drawing.Size(382, 798);
            this.dataGridViewCorrel.TabIndex = 1;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.Name = "Frequency";
            // 
            // OldOffset
            // 
            this.OldOffset.HeaderText = "OldOffset";
            this.OldOffset.Name = "OldOffset";
            // 
            // NewOffset
            // 
            this.NewOffset.HeaderText = "NewOffset";
            this.NewOffset.Name = "NewOffset";
            // 
            // groupBoxNames
            // 
            this.groupBoxNames.Controls.Add(this.labelName);
            this.groupBoxNames.Controls.Add(this.comboBoxNames);
            this.groupBoxNames.Controls.Add(this.buttonDelete);
            this.groupBoxNames.Controls.Add(this.buttonView);
            this.groupBoxNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNames.Location = new System.Drawing.Point(2, 199);
            this.groupBoxNames.Name = "groupBoxNames";
            this.groupBoxNames.Size = new System.Drawing.Size(339, 76);
            this.groupBoxNames.TabIndex = 2;
            this.groupBoxNames.TabStop = false;
            this.groupBoxNames.Text = "Correl";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(4, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(260, 49);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonView
            // 
            this.buttonView.BackColor = System.Drawing.Color.White;
            this.buttonView.Location = new System.Drawing.Point(260, 19);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 23);
            this.buttonView.TabIndex = 2;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGravar.Location = new System.Drawing.Point(241, 311);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(100, 60);
            this.buttonGravar.TabIndex = 3;
            this.buttonGravar.Text = "Gravar Alterações";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonVerify
            // 
            this.buttonVerify.BackColor = System.Drawing.Color.Red;
            this.buttonVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonVerify.Location = new System.Drawing.Point(126, 77);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(80, 70);
            this.buttonVerify.TabIndex = 5;
            this.buttonVerify.Text = "File Verify";
            this.buttonVerify.UseVisualStyleBackColor = false;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.Color.White;
            this.buttonOpenFile.Location = new System.Drawing.Point(293, 33);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(44, 22);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "...";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxCorrelDir
            // 
            this.textBoxCorrelDir.Location = new System.Drawing.Point(8, 33);
            this.textBoxCorrelDir.Name = "textBoxCorrelDir";
            this.textBoxCorrelDir.Size = new System.Drawing.Size(279, 20);
            this.textBoxCorrelDir.TabIndex = 7;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelFile.Location = new System.Drawing.Point(8, 14);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(33, 16);
            this.labelFile.TabIndex = 8;
            this.labelFile.Text = "File:";
            // 
            // buttonOpenFreqFile
            // 
            this.buttonOpenFreqFile.BackColor = System.Drawing.Color.White;
            this.buttonOpenFreqFile.Location = new System.Drawing.Point(293, 476);
            this.buttonOpenFreqFile.Name = "buttonOpenFreqFile";
            this.buttonOpenFreqFile.Size = new System.Drawing.Size(44, 22);
            this.buttonOpenFreqFile.TabIndex = 9;
            this.buttonOpenFreqFile.Text = "...";
            this.buttonOpenFreqFile.UseVisualStyleBackColor = false;
            this.buttonOpenFreqFile.Click += new System.EventHandler(this.buttonOpenFreqFile_Click);
            // 
            // textBoxFreqFileDir
            // 
            this.textBoxFreqFileDir.Location = new System.Drawing.Point(8, 478);
            this.textBoxFreqFileDir.Name = "textBoxFreqFileDir";
            this.textBoxFreqFileDir.Size = new System.Drawing.Size(279, 20);
            this.textBoxFreqFileDir.TabIndex = 10;
            // 
            // labelImportFreqFile
            // 
            this.labelImportFreqFile.AutoSize = true;
            this.labelImportFreqFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelImportFreqFile.Location = new System.Drawing.Point(8, 459);
            this.labelImportFreqFile.Name = "labelImportFreqFile";
            this.labelImportFreqFile.Size = new System.Drawing.Size(84, 16);
            this.labelImportFreqFile.TabIndex = 11;
            this.labelImportFreqFile.Text = "Import Excel:";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 811);
            this.Controls.Add(this.labelImportFreqFile);
            this.Controls.Add(this.textBoxFreqFileDir);
            this.Controls.Add(this.buttonOpenFreqFile);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.textBoxCorrelDir);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonVerify);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.groupBoxNames);
            this.Controls.Add(this.dataGridViewCorrel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Correl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrel)).EndInit();
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxNames;
        private System.Windows.Forms.DataGridView dataGridViewCorrel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewOffset;
        private System.Windows.Forms.GroupBox groupBoxNames;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxCorrelDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button buttonOpenFreqFile;
        private System.Windows.Forms.TextBox textBoxFreqFileDir;
        private System.Windows.Forms.Label labelImportFreqFile;
    }
}

