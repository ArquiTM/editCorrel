using System.Drawing;
using System.Windows.Forms;

namespace EditCorrel
{
    class Utils
    {
        FormApp frmMain = FormApp.getInstance();
        OpenCorrel Oc = new OpenCorrel(); 

        public void enableButtons()
        {
            frmMain.buttonGravar.Enabled = true;
            frmMain.buttonDelete.Enabled = true;
            frmMain.buttonOpenFile.Enabled = true;
            frmMain.buttonOpenFreqFile.Enabled = true;           
        }

        public void disableButtons()
        {
            frmMain.buttonGravar.Enabled = false;
            frmMain.buttonDelete.Enabled = false;
            frmMain.buttonOpenFile.Enabled = false;
            frmMain.buttonOpenFreqFile.Enabled = false;
            frmMain.buttonSetKey.Enabled = false;
        }
        public void settingTextsBoxAndComboBox()//Set textBoxs and comboBox to only read
        {
            frmMain.textBoxFileVerify.ReadOnly = true;
            frmMain.textBoxCorrelDir.ReadOnly = true;
            frmMain.textBoxFreqFileDir.ReadOnly = true;
            frmMain.comboBoxNames.DropDownStyle = ComboBoxStyle.DropDownList;
            frmMain.buttonSetKey.Enabled = false;
        }

        public void getFileStatus()//Import correl
        {
            bool result = Oc.OpenFile();

            if (result)
            {
                frmMain.textBoxFileVerify.Text = "File Import Successfully!!!";
                frmMain.textBoxFileVerify.BackColor = Color.LimeGreen;
                frmMain.textBoxFileVerify.ForeColor = Color.Black;
            }
            else
            {
                frmMain.textBoxFileVerify.BackColor = Color.Red;
                frmMain.textBoxFileVerify.Text = "File Import Error!!!";
                frmMain.textBoxFileVerify.ForeColor = Color.White;
            }
        }
        public bool selectingCorrel()//Select the correl
        {
            try
            {
                frmMain.openFileDialog1.Filter = "Correl files (*.correl)|*.correl|All files (*.*)|*.*";
                if (frmMain.openFileDialog1.ShowDialog() == DialogResult.OK)
                    frmMain.textBoxCorrelDir.Text = frmMain.openFileDialog1.FileName;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
