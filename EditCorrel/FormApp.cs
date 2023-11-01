using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace EditCorrel
{
    public partial class FormApp : Form
    {
        private static FormApp INSTANCE = null;
        public string originalCorrel = string.Empty;
        public string tempCorrel = string.Empty;
        public string newCorrel = string.Empty;
        public string line = string.Empty;
        public string originalDir = string.Empty;
        XmlDocument myDoc = new XmlDocument();

        EditXlsx EdX;
        FileImport fI = new FileImport();
        Utils Uts;
        FillDGV FDGV;
        OpenCorrel Oc;
        EditNodeCorrel ENC;
        DeleteAndChangeFreq DaCF;

        public object Convert { get; internal set; }

        public FormApp()
        {
            InitializeComponent();
            INSTANCE = this;
            ClassesInit();
            Uts.settingTextsBoxAndComboBox();
        }

        private void ClassesInit()
        {
            EdX = new EditXlsx();
            Uts = new Utils();
            FDGV = new FillDGV();
            Oc = new OpenCorrel();
            ENC = new EditNodeCorrel();
            DaCF = new DeleteAndChangeFreq();
        }

        public static FormApp getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new FormApp();

            return INSTANCE;
        }

        private void buttonDelete_Click(object sender, EventArgs e) //Delete test from correl file
        {
            DaCF.deleteLineComboBox();
        }

        private void buttonGravar_Click(object sender, EventArgs e)//Save the new correl
        {
            if (DaCF.deleteNamesNewFile())
            {
                copyNewtoTemp();
                if (DaCF.changeFreqNewFile())
                {
                    copyNewtoTemp();
                    File.Delete(tempCorrel);
                    FormExportOk formEOk = new FormExportOk();
                    formEOk.Show();
                    buttonSetKey.Enabled = true;
                }
            }
        }

        private void copyNewtoTemp()//Copy new file to temp file
        {
            myDoc = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Copy(newCorrel, tempCorrel, true);
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)//Button to open the correl
        {
            bool result = false;
            result = Uts.selectingCorrel();

            if (result)
                Uts.getFileStatus();
        }

        private void buttonOpenFreqFile_Click(object sender, EventArgs e)//Import data from XSLX
        {
            Uts.disableButtons();
            bool result = false;
            result = EdX.importingExcel(dataGridViewCorrel);
            if (result)
                Uts.enableButtons();
        }

        private void comboBoxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNames.Text != "")
            {
                FDGV.viewDataGridView();

                if (textBoxFreqFileDir.Text != "")
                    EdX.importingExcel(dataGridViewCorrel);
            }
        }

        private void buttonSetKey_Click(object sender, EventArgs e)
        {
            ENC.reWriteLineCorrel();
            buttonSetKey.BackColor = Color.LimeGreen;
            Uts.disableButtons();
            File.Copy(newCorrel, originalDir);
            Directory.Delete(@".\correl",true);
            FormExportOk formEOk = new FormExportOk();
            formEOk.labelStatusFinishIcon.Text = "Arquivo finalizado com sucesso!!!";
            formEOk.Show();
        }
    }
}