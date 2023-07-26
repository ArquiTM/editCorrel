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
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxTxt = new System.Windows.Forms.GroupBox();
            this.buttonImportNewValues = new System.Windows.Forms.Button();
            this.textBoxTxtName = new System.Windows.Forms.TextBox();
            this.labelTxtName = new System.Windows.Forms.Label();
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
            this.dataGridViewCorrel.Size = new System.Drawing.Size(347, 635);
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
            this.groupBoxNames.Location = new System.Drawing.Point(2, 12);
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
            this.buttonDelete.Location = new System.Drawing.Point(260, 49);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(260, 19);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 23);
            this.buttonView.TabIndex = 2;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = true;
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
            this.groupBoxTxt.Location = new System.Drawing.Point(2, 136);
            this.groupBoxTxt.Name = "groupBoxTxt";
            this.groupBoxTxt.Size = new System.Drawing.Size(339, 89);
            this.groupBoxTxt.TabIndex = 4;
            this.groupBoxTxt.TabStop = false;
            this.groupBoxTxt.Text = "New Values";
            // 
            // buttonImportNewValues
            // 
            this.buttonImportNewValues.Location = new System.Drawing.Point(260, 49);
            this.buttonImportNewValues.Name = "buttonImportNewValues";
            this.buttonImportNewValues.Size = new System.Drawing.Size(75, 23);
            this.buttonImportNewValues.TabIndex = 0;
            this.buttonImportNewValues.Text = "Import";
            this.buttonImportNewValues.UseVisualStyleBackColor = true;
            // 
            // textBoxTxtName
            // 
            this.textBoxTxtName.Location = new System.Drawing.Point(6, 50);
            this.textBoxTxtName.Name = "textBoxTxtName";
            this.textBoxTxtName.Size = new System.Drawing.Size(244, 22);
            this.textBoxTxtName.TabIndex = 1;
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
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 659);
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
    }
}

