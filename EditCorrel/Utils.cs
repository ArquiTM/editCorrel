using System.Windows.Forms;

namespace EditCorrel
{
    class Utils
    {
        FormApp frmMain = FormApp.getInstance();

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
    }
}
