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
        string originalCorrel = string.Empty;
        string tempCorrel = string.Empty;
        string newCorrel = string.Empty;
        string line = string.Empty;
        EditXlsx EdX;
        FileImport fI = new FileImport();
        XmlDocument myDoc = new XmlDocument();
        Utils Uts;

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
        }

        public static FormApp getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new FormApp();

            return INSTANCE;
        }

        public bool OpenFile()//Fill comboBox
        {
            try
            {

                if (!Directory.Exists(@"correl"))
                    Directory.CreateDirectory(@"correl");

                string directoryPath = @".\correl";
                string file_name = textBoxCorrelDir.Text;
                string correctDir = string.Empty;
                int fileDir = Directory.GetFiles(directoryPath).Length;

                if (fileDir == 0)
                {
                    correctDir = fI.CopyingFile(file_name);
                    textBoxCorrelDir.Text = correctDir;
                }

                originalCorrel = textBoxCorrelDir.Text.Replace(".correl", "");
                tempCorrel = originalCorrel + "_temporary.correl";
                newCorrel = originalCorrel + "_new_OK.correl";
                File.Copy(originalCorrel + ".correl", tempCorrel, true);
                File.Copy(originalCorrel + ".correl", newCorrel, true);

                if (correctDir != "" || fileDir > 0)
                {
                    changeLineCorrel();

                    if (file_name == string.Empty)
                        MessageBox.Show("Não foi selecionado nenhum arquivo para edição!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else
                    {
                        comboBoxNames.Items.Clear();
                        using (var reader = new StreamReader(textBoxCorrelDir.Text))
                        {
                            myDoc.Load(new StreamReader(textBoxCorrelDir.Text));
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains("<Name>"))
                                {
                                    line = line.Replace("    <Name>", "");
                                    line = line.Replace("</Name>", "");
                                    comboBoxNames.Items.Add(line);
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

        private void changeLineCorrel()//Remove a node part of correl file
        {
            string directoryPath = @".\correl";
            string fileExtension = ".correl";
            string originalXmlString = "<CorrelationData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://www.motorolamobility.com/globaltest/nextest2010/correlation\">";
            string replacementXmlString = "<CorrelationData>";
            string[] files = Directory.GetFiles(directoryPath, "*" + fileExtension);

            foreach (string filePath in files)
            {
                try
                {
                    string xmlContent = File.ReadAllText(filePath);
                    xmlContent = xmlContent.Replace(originalXmlString, replacementXmlString);
                    File.WriteAllText(filePath, xmlContent);
                }
                catch
                { }
            }
        }

        private void reWriteLineCorrel()//Insert a node part of correl
        {
            if (!Directory.Exists(@"correl"))
                Directory.CreateDirectory(@"correl");

            string directoryPath = @".\correl";
            string fileExtension = ".correl";
            string replacementXmlString = "<CorrelationData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://www.motorolamobility.com/globaltest/nextest2010/correlation\">";
            string actualXmlString = "<CorrelationData>";
            string[] files = Directory.GetFiles(directoryPath, "*" + fileExtension);

            foreach (string filePath in files)
            {
                try
                {
                    string xmlContent = File.ReadAllText(filePath);
                    xmlContent = xmlContent.Replace(actualXmlString, replacementXmlString);
                    File.WriteAllText(filePath, xmlContent);
                }
                catch
                { }
            }
        }

        private void getFile()//Import correl
        {
            bool result = OpenFile();

            if (result)
            {
                textBoxFileVerify.Text = "File Import Successfully!!!";
                textBoxFileVerify.BackColor = Color.LimeGreen;
                textBoxFileVerify.ForeColor = Color.Black;
            }
            else
            {
                textBoxFileVerify.BackColor = Color.Red;
                textBoxFileVerify.Text = "File Import Error!!!";
                textBoxFileVerify.ForeColor = Color.White;
            }
        }

        private void viewDataGridView()//Fill Data Grid View with values
        {
            dataGridViewCorrel.Rows.Clear();
            if (comboBoxNames.Text == "")
                MessageBox.Show("Não foi selecionado nenhum arquivo!!!", "ComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string freqF = string.Empty;
                string offS = string.Empty;
                string nodesXml = string.Empty;
                string[] line;
                string[] vectLine;
                int countLine = 0;

                myDoc = new XmlDocument();
                string file_name = textBoxCorrelDir.Text;
                myDoc.Load(new StreamReader(file_name));

                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;

                    if (nodesXml.Contains(comboBoxNames.Text))
                    {
                        line = nodesXml.Split(new[] { "</ValueDescription>", "<ValueDescription />", "</FrequencyOffset>" }, StringSplitOptions.None);
                        countLine = line.Length;

                        for (int i = 0; i < countLine; i++)
                        {
                            if (line[i].Contains("Frequency"))
                            {
                                freqF = line[i].Replace("<FrequencyOffset><Frequency>", "");
                                freqF = freqF.Replace("</Frequency><Offset>", " ");
                                freqF = freqF.Replace("</Offset>", "");
                                offS = freqF;
                                vectLine = freqF.Split(' ');

                                if (vectLine[0].Length == 4)
                                    vectLine[0] = "0" + vectLine[0];

                                else
                                    vectLine[0] = "00" + vectLine[0];

                                dataGridViewCorrel.Rows.Add(vectLine[0], vectLine[1]);
                            }
                        }
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) //Delete test from correl file
        {
            deleteLineComboBox();
        }

        private void deleteLineComboBox()//Delete the test of Combo Box
        {
            if (comboBoxNames.Text == "")
                MessageBox.Show("Não foi selecionado nenhum teste!!!", "ComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string nodesXml = string.Empty;

                myDoc = new XmlDocument();
                string file_name = textBoxCorrelDir.Text;
                myDoc.Load(new StreamReader(file_name));

                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;

                    if (nodesXml.Contains(comboBoxNames.Text))
                    {
                        node.RemoveAll();
                        comboBoxNames.Items.Remove(comboBoxNames.Text);
                        comboBoxNames.Text = "";
                        dataGridViewCorrel.Rows.Clear();
                        return;
                    }
                }
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)//Save the new correl
        {
            if (deleteNamesNewFile())
            {
                copyNewtoTemp();
                if (changeFreqNewFile())
                {
                    copyNewtoTemp();
                    File.Delete(tempCorrel);
                    FormExportOk formEOk = new FormExportOk();
                    formEOk.Show();
                    buttonSetKey.Enabled = true;
                }
            }
        }

        private bool deleteNamesNewFile()//Delete the test node from correl file
        {
            if (originalCorrel == string.Empty)
            {
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                try
                {
                    if (!File.Exists(tempCorrel))
                        File.Copy(newCorrel, tempCorrel);

                    using (var reader = new StreamReader(tempCorrel))
                    {
                        using (var writer = new StreamWriter(newCorrel))
                        {
                            myDoc = new XmlDocument();
                            myDoc.Load(new StreamReader(tempCorrel));

                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains("<Tests>"))
                                    line = line.Replace(line, "");

                                else if (line.Contains("<Name>"))
                                {
                                    line = line.Replace("    <Name>", "");
                                    line = line.Replace("</Name>", "");

                                    if (!comboBoxNames.Items.Contains(line))
                                    {
                                        while (!line.Contains(@"</Tests>"))
                                        {
                                            line = line.Replace(line, "");
                                            writer.Write(line);
                                            line = reader.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        writer.WriteLine("  <Tests>");
                                        line = "    <Name>" + line + "</Name>";
                                        writer.WriteLine(line);
                                    }
                                }
                                else
                                    writer.WriteLine(line);
                            }
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        private bool changeFreqNewFile()//Change the freq of new correl file
        {
            try
            {
                if (!File.Exists(tempCorrel))
                    File.Copy(newCorrel, tempCorrel);

                using (var readerN = new StreamReader(tempCorrel))
                {
                    using (var writerN = new StreamWriter(newCorrel))
                    {
                        myDoc = new XmlDocument();
                        myDoc.Load(new StreamReader(tempCorrel));
                        int freqDataGridView = 0;
                        int count = dataGridViewCorrel.Rows.Count;
                        int rowsCount = Convert.ToInt32(dataGridViewCorrel.RowCount.ToString());
                        int i = 0;

                        while ((line = readerN.ReadLine()) != null)
                        {
                            if (line.Contains(comboBoxNames.Text))
                            {
                                writerN.WriteLine(line);
                                while ((line = readerN.ReadLine()) != null && i < count)
                                {
                                    dataGridViewCorrel.Rows[i].Cells[1].Value = dataGridViewCorrel.Rows[i].Cells[2].Value;

                                    freqDataGridView = Convert.ToInt32(dataGridViewCorrel.Rows[i].Cells[0].Value);
                                    if (line.Contains($"<Frequency>{freqDataGridView.ToString()}"))
                                    {
                                        writerN.WriteLine(line);
                                        line = readerN.ReadLine();
                                        writerN.WriteLine($"      <Offset>{ dataGridViewCorrel.Rows[i].Cells[2].Value}</Offset>");
                                        i++;
                                    }
                                    else
                                        writerN.WriteLine(line);
                                }
                                writerN.WriteLine(line);

                                if (comboBoxNames.SelectedIndex < comboBoxNames.Items.Count)
                                {
                                    while ((line = readerN.ReadLine()) != null)
                                    {
                                        writerN.WriteLine(line);
                                    }
                                }
                            }
                            else
                                writerN.WriteLine(line);
                        }
                        writerN.WriteLine(line);
                    }
                }
                return true;
            }
            catch
            {
                return false;
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
            result = selectingCorrel();

            if (result)
                getFile();
        }

        private bool selectingCorrel()//Select the correl
        {
            try
            {
                openFileDialog1.Filter = "Correl files (*.correl)|*.correl|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    textBoxCorrelDir.Text = openFileDialog1.FileName;

                return true;
            }
            catch
            {
                return false;
            }
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
                viewDataGridView();

                if (textBoxFreqFileDir.Text != "")
                    EdX.importingExcel(dataGridViewCorrel);
            }
        }

        private void buttonSetKey_Click(object sender, EventArgs e)
        {
            reWriteLineCorrel();
            buttonSetKey.BackColor = Color.LimeGreen;
            Uts.disableButtons();
        }
    }
}