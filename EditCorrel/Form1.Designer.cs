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
            this.components = new System.ComponentModel.Container();
            this.comboBoxNames = new System.Windows.Forms.ComboBox();
            this.dataGridViewCorrel = new System.Windows.Forms.DataGridView();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxNames = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxTxt = new System.Windows.Forms.GroupBox();
            this.labelTxtName = new System.Windows.Forms.Label();
            this.textBoxTxtName = new System.Windows.Forms.TextBox();
            this.buttonImportNewValues = new System.Windows.Forms.Button();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrel)).BeginInit();
            this.groupBoxNames.SuspendLayout();
            this.groupBoxTxt.SuspendLayout();
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
            this.dataGridViewCorrel.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCorrel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCorrel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.OldOffset,
            this.NewOffset});
            this.dataGridViewCorrel.Location = new System.Drawing.Point(382, 12);
            this.dataGridViewCorrel.Name = "dataGridViewCorrel";
            this.dataGridViewCorrel.Size = new System.Drawing.Size(347, 69);
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
            this.groupBoxNames.Location = new System.Drawing.Point(2, 160);
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
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(2, 624);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // groupBoxTxt
            // 
            this.groupBoxTxt.Controls.Add(this.labelTxtName);
            this.groupBoxTxt.Controls.Add(this.textBoxTxtName);
            this.groupBoxTxt.Controls.Add(this.buttonImportNewValues);
            this.groupBoxTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTxt.Location = new System.Drawing.Point(2, 284);
            this.groupBoxTxt.Name = "groupBoxTxt";
            this.groupBoxTxt.Size = new System.Drawing.Size(339, 89);
            this.groupBoxTxt.TabIndex = 4;
            this.groupBoxTxt.TabStop = false;
            this.groupBoxTxt.Text = "New Values";
            // 
            // labelTxtName
            // 
            this.labelTxtName.AutoSize = true;
            this.labelTxtName.Location = new System.Drawing.Point(6, 31);
            this.labelTxtName.Name = "labelTxtName";
            this.labelTxtName.Size = new System.Drawing.Size(45, 16);
            this.labelTxtName.TabIndex = 2;
            this.labelTxtName.Text = "Name";
            // 
            // textBoxTxtName
            // 
            this.textBoxTxtName.Location = new System.Drawing.Point(6, 50);
            this.textBoxTxtName.Name = "textBoxTxtName";
            this.textBoxTxtName.Size = new System.Drawing.Size(244, 22);
            this.textBoxTxtName.TabIndex = 1;
            // 
            // buttonImportNewValues
            // 
            this.buttonImportNewValues.BackColor = System.Drawing.Color.White;
            this.buttonImportNewValues.Location = new System.Drawing.Point(260, 49);
            this.buttonImportNewValues.Name = "buttonImportNewValues";
            this.buttonImportNewValues.Size = new System.Drawing.Size(75, 23);
            this.buttonImportNewValues.TabIndex = 0;
            this.buttonImportNewValues.Text = "Import";
            this.buttonImportNewValues.UseVisualStyleBackColor = false;
            // 
            // buttonVerify
            // 
            this.buttonVerify.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonVerify.Location = new System.Drawing.Point(149, 12);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(79, 69);
            this.buttonVerify.TabIndex = 5;
            this.buttonVerify.Text = "File Verify";
            this.buttonVerify.UseVisualStyleBackColor = false;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // textBoxTest
            // 
            this.textBoxTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTest.Location = new System.Drawing.Point(391, 133);
            this.textBoxTest.Multiline = true;
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.Size = new System.Drawing.Size(338, 503);
            this.textBoxTest.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 659);
            this.Controls.Add(this.textBoxTest);
            this.Controls.Add(this.buttonVerify);
            this.Controls.Add(this.groupBoxTxt);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxNames);
            this.Controls.Add(this.dataGridViewCorrel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Correl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCorrel)).EndInit();
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            this.groupBoxTxt.ResumeLayout(false);
            this.groupBoxTxt.PerformLayout();
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
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxTxt;
        private System.Windows.Forms.Button buttonImportNewValues;
        private System.Windows.Forms.Label labelTxtName;
        private System.Windows.Forms.TextBox textBoxTxtName;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.TextBox textBoxTest;
        private System.Windows.Forms.ImageList imageList1;
    }
}

