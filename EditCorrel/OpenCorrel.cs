using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace EditCorrel
{
    class OpenCorrel
    {
        FormApp frmMain = FormApp.getInstance();
        FileImport fI = new FileImport();
        EditNodeCorrel ENC = new EditNodeCorrel();
        XmlDocument myDoc = new XmlDocument();

        public bool OpenFile()//Fill comboBox
        {
            try
            {
                if (!Directory.Exists(@"correl"))
                    Directory.CreateDirectory(@"correl");

                string directoryPath = @".\correl";
                string file_name = frmMain.textBoxCorrelDir.Text;
                string correctDir = string.Empty;
                int fileDir = Directory.GetFiles(directoryPath).Length;

                if (fileDir == 0)
                {
                    correctDir = fI.CopyingFile(file_name);
                    frmMain.textBoxCorrelDir.Text = correctDir;
                }

                frmMain.originalCorrel = frmMain.textBoxCorrelDir.Text.Replace(".correl", "");
                frmMain.tempCorrel = frmMain.originalCorrel + "_temporary.correl";
                frmMain.newCorrel = frmMain.originalCorrel + "_new_OK.correl";
                File.Copy(frmMain.originalCorrel + ".correl", frmMain.tempCorrel, true);
                File.Copy(frmMain.originalCorrel + ".correl", frmMain.newCorrel, true);

                if (correctDir != "" || fileDir > 0)
                {
                    ENC.changeLineCorrel();

                    if (file_name == string.Empty)
                        MessageBox.Show("Não foi selecionado nenhum arquivo para edição!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else
                    {
                        frmMain.comboBoxNames.Items.Clear();
                        using (var reader = new StreamReader(frmMain.textBoxCorrelDir.Text))
                        {
                            myDoc.Load(new StreamReader(frmMain.textBoxCorrelDir.Text));
                            while ((frmMain.line = reader.ReadLine()) != null)
                            {
                                if (frmMain.line.Contains("<Name>"))
                                {
                                    frmMain.line = frmMain.line.Replace("    <Name>", "");
                                    frmMain.line = frmMain.line.Replace("</Name>", "");
                                    frmMain.comboBoxNames.Items.Add(frmMain.line);
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
