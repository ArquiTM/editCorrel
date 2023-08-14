namespace EditCorrel
{
    partial class FormExportOk
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
            this.buttonOkFinishIcon = new System.Windows.Forms.Button();
            this.pictureBoxSuccessfully = new System.Windows.Forms.PictureBox();
            this.labelStatusFinishIcon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuccessfully)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOkFinishIcon
            // 
            this.buttonOkFinishIcon.BackColor = System.Drawing.Color.White;
            this.buttonOkFinishIcon.Location = new System.Drawing.Point(223, 91);
            this.buttonOkFinishIcon.Name = "buttonOkFinishIcon";
            this.buttonOkFinishIcon.Size = new System.Drawing.Size(70, 25);
            this.buttonOkFinishIcon.TabIndex = 0;
            this.buttonOkFinishIcon.Text = "OK";
            this.buttonOkFinishIcon.UseVisualStyleBackColor = false;
            this.buttonOkFinishIcon.Click += new System.EventHandler(this.buttonOkFinishIcon_Click);
            // 
            // pictureBoxSuccessfully
            // 
            this.pictureBoxSuccessfully.Image = global::EditCorrel.Properties.Resources.success_icon1;
            this.pictureBoxSuccessfully.Location = new System.Drawing.Point(12, 41);
            this.pictureBoxSuccessfully.Name = "pictureBoxSuccessfully";
            this.pictureBoxSuccessfully.Size = new System.Drawing.Size(43, 36);
            this.pictureBoxSuccessfully.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSuccessfully.TabIndex = 1;
            this.pictureBoxSuccessfully.TabStop = false;
            // 
            // labelStatusFinishIcon
            // 
            this.labelStatusFinishIcon.AutoSize = true;
            this.labelStatusFinishIcon.Location = new System.Drawing.Point(80, 41);
            this.labelStatusFinishIcon.Name = "labelStatusFinishIcon";
            this.labelStatusFinishIcon.Size = new System.Drawing.Size(145, 13);
            this.labelStatusFinishIcon.TabIndex = 2;
            this.labelStatusFinishIcon.Text = "Arquivo salvo com sucesso!!!";
            // 
            // FormExportOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 122);
            this.ControlBox = false;
            this.Controls.Add(this.labelStatusFinishIcon);
            this.Controls.Add(this.pictureBoxSuccessfully);
            this.Controls.Add(this.buttonOkFinishIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormExportOk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Success";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuccessfully)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOkFinishIcon;
        private System.Windows.Forms.PictureBox pictureBoxSuccessfully;
        public System.Windows.Forms.Label labelStatusFinishIcon;
    }
}