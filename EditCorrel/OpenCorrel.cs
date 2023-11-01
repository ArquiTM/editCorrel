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
        string originalCorrel = string.Empty;
        string tempCorrel = string.Empty;
        string newCorrel = string.Empty;
        string line = string.Empty;
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

                originalCorrel = frmMain.textBoxCorrelDir.Text.Replace(".correl", "");
                tempCorrel = originalCorrel + "_temporary.correl";
                newCorrel = originalCorrel + "_new_OK.correl";
                File.Copy(originalCorrel + ".correl", tempCorrel, true);
                File.Copy(originalCorrel + ".correl", newCorrel, true);

                if (correctDir != "" || fileDir > 0)
                {
                    frmMain.changeLineCorrel();

                    if (file_name == string.Empty)
                        MessageBox.Show("Não foi selecionado nenhum arquivo para edição!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else
                    {
                        frmMain.comboBoxNames.Items.Clear();
                        using (var reader = new StreamReader(frmMain.textBoxCorrelDir.Text))
                        {
                            myDoc.Load(new StreamReader(frmMain.textBoxCorrelDir.Text));
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains("<Name>"))
                                {
                                    line = line.Replace("    <Name>", "");
                                    line = line.Replace("</Name>", "");
                                    frmMain.comboBoxNames.Items.Add(line);
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
