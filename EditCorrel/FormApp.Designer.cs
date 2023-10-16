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
            this.textBoxFileVerify = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.textBoxCorrelDir = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFreqFile = new System.Windows.Forms.Button();
            this.textBoxFreqFileDir = new System.Windows.Forms.TextBox();
            this.labelImportFreqFile = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrel)).BeginInit();
            this.groupBoxNames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxNames
            // 
            this.comboBoxNames.BackColor = System.Drawing.Color.White;
            this.comboBoxNames.FormattingEnabled = true;
            this.comboBoxNames.Location = new System.Drawing.Point(7, 199);
            this.comboBoxNames.Name = "comboBoxNames";
            this.comboBoxNames.Size = new System.Drawing.Size(244, 24);
            this.comboBoxNames.TabIndex = 0;
            this.comboBoxNames.SelectedIndexChanged += new System.EventHandler(this.comboBoxNames_SelectedIndexChanged);
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
            this.dataGridViewCorrel.Location = new System.Drawing.Point(357, 3);
            this.dataGridViewCorrel.Name = "dataGridViewCorrel";
            this.dataGridViewCorrel.Size = new System.Drawing.Size(372, 797);
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
            this.groupBoxNames.Controls.Add(this.textBoxFileVerify);
            this.groupBoxNames.Controls.Add(this.labelName);
            this.groupBoxNames.Controls.Add(this.comboBoxNames);
            this.groupBoxNames.Controls.Add(this.buttonDelete);
            this.groupBoxNames.Controls.Add(this.labelFile);
            this.groupBoxNames.Controls.Add(this.buttonGravar);
            this.groupBoxNames.Controls.Add(this.textBoxCorrelDir);
            this.groupBoxNames.Controls.Add(this.buttonOpenFile);
            this.groupBoxNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxNames.Location = new System.Drawing.Point(2, 87);
            this.groupBoxNames.Name = "groupBoxNames";
            this.groupBoxNames.Size = new System.Drawing.Size(349, 325);
            this.groupBoxNames.TabIndex = 2;
            this.groupBoxNames.TabStop = false;
            this.groupBoxNames.Text = "Correl Config";
            // 
            // textBoxFileVerify
            // 
            this.textBoxFileVerify.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBoxFileVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileVerify.ForeColor = System.Drawing.Color.Black;
            this.textBoxFileVerify.Location = new System.Drawing.Point(6, 73);
            this.textBoxFileVerify.Multiline = true;
            this.textBoxFileVerify.Name = "textBoxFileVerify";
            this.textBoxFileVerify.ReadOnly = true;
            this.textBoxFileVerify.Size = new System.Drawing.Size(279, 38);
            this.textBoxFileVerify.TabIndex = 9;
            this.textBoxFileVerify.Text = "File Verify";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(4, 180);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(260, 180);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 54);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelFile.Location = new System.Drawing.Point(6, 15);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(33, 16);
            this.labelFile.TabIndex = 8;
            this.labelFile.Text = "File:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGravar.Location = new System.Drawing.Point(10, 243);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(241, 45);
            this.buttonGravar.TabIndex = 3;
            this.buttonGravar.Text = "Gravar Alterações";
            this.buttonGravar.UseVisualStyleBackColor = false;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // textBoxCorrelDir
            // 
            this.textBoxCorrelDir.BackColor = System.Drawing.Color.White;
            this.textBoxCorrelDir.Location = new System.Drawing.Point(6, 34);
            this.textBoxCorrelDir.Name = "textBoxCorrelDir";
            this.textBoxCorrelDir.ReadOnly = true;
            this.textBoxCorrelDir.Size = new System.Drawing.Size(279, 22);
            this.textBoxCorrelDir.TabIndex = 7;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.Color.White;
            this.buttonOpenFile.Location = new System.Drawing.Point(291, 34);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(42, 22);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "...";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonOpenFreqFile
            // 
            this.buttonOpenFreqFile.BackColor = System.Drawing.Color.White;
            this.buttonOpenFreqFile.Location = new System.Drawing.Point(292, 46);
            this.buttonOpenFreqFile.Name = "buttonOpenFreqFile";
            this.buttonOpenFreqFile.Size = new System.Drawing.Size(51, 22);
            this.buttonOpenFreqFile.TabIndex = 9;
            this.buttonOpenFreqFile.Text = "...";
            this.buttonOpenFreqFile.UseVisualStyleBackColor = false;
            this.buttonOpenFreqFile.Click += new System.EventHandler(this.buttonOpenFreqFile_Click);
            // 
            // textBoxFreqFileDir
            // 
            this.textBoxFreqFileDir.BackColor = System.Drawing.Color.White;
            this.textBoxFreqFileDir.Location = new System.Drawing.Point(7, 46);
            this.textBoxFreqFileDir.Name = "textBoxFreqFileDir";
            this.textBoxFreqFileDir.ReadOnly = true;
            this.textBoxFreqFileDir.Size = new System.Drawing.Size(279, 22);
            this.textBoxFreqFileDir.TabIndex = 10;
            // 
            // labelImportFreqFile
            // 
            this.labelImportFreqFile.AutoSize = true;
            this.labelImportFreqFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelImportFreqFile.Location = new System.Drawing.Point(7, 27);
            this.labelImportFreqFile.Name = "labelImportFreqFile";
            this.labelImportFreqFile.Size = new System.Drawing.Size(84, 16);
            this.labelImportFreqFile.TabIndex = 11;
            this.labelImportFreqFile.Text = "Import Excel:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EditCorrel.Properties.Resources.flex;
            this.pictureBox1.Location = new System.Drawing.Point(87, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFreqFileDir);
            this.groupBox1.Controls.Add(this.buttonOpenFreqFile);
            this.groupBox1.Controls.Add(this.labelImportFreqFile);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(2, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 80);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel File";
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.Location = new System.Drawing.Point(8, 508);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(337, 292);
            this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWarning.TabIndex = 12;
            this.pictureBoxWarning.TabStop = false;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 807);
            this.Controls.Add(this.pictureBoxWarning);
            this.Controls.Add(this.dataGridViewCorrel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Correl v1.1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrel)).EndInit();
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxNames;
        private System.Windows.Forms.DataGridView dataGridViewCorrel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewOffset;
        private System.Windows.Forms.GroupBox groupBoxNames;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxCorrelDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button buttonOpenFreqFile;
        private System.Windows.Forms.TextBox textBoxFreqFileDir;
        private System.Windows.Forms.Label labelImportFreqFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBoxWarning;
        private System.Windows.Forms.TextBox textBoxFileVerify;
    }
}

