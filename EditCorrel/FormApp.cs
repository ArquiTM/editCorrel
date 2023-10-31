using EditCorrel.Properties;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace EditCorrel
{
    public partial class FormApp : Form
    {
        FileImport fI = new FileImport();
        string originalCorrel = string.Empty;
        string tempCorrel = string.Empty;
        string newCorrel = string.Empty;
        string line = string.Empty;
        int countXlsx = 0;

        XmlDocument myDoc = new XmlDocument();

        public FormApp()
        {
            InitializeComponent();
            settingTextsBoxAndComboBox();
        }

        public void settingTextsBoxAndComboBox()//Set textBoxs and comboBox to only read
        {
            textBoxFileVerify.ReadOnly = true;
            textBoxCorrelDir.ReadOnly = true;
            textBoxFreqFileDir.ReadOnly = true;
            comboBoxNames.DropDownStyle = ComboBoxStyle.DropDownList;
            buttonSetKey.Enabled = false;
        }

        public bool OpenFile()//Fill comboBox
        {
            try
            {
                string file_name = textBoxCorrelDir.Text;
                string correctDir = fI.CopyingFile(file_name);
                textBoxCorrelDir.Text = correctDir;

                originalCorrel = textBoxCorrelDir.Text.Replace(".correl", "");
                tempCorrel = originalCorrel + "_temporary.correl";
                newCorrel = originalCorrel + "_new_OK.correl";
                File.Copy(originalCorrel + ".correl", tempCorrel, true);
                File.Copy(originalCorrel + ".correl", newCorrel, true);

                if (correctDir != "")
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

        public DataTable READExcel(string strFilePath)//Read the XLSX file
        {
            DataTable dt = new DataTable();
            int indexExcel = 0;

            if (comboBoxNames.Text.Contains("LEFT"))
                indexExcel = 1;

            else if (comboBoxNames.Text.Contains("RIGHT"))
                indexExcel = 2;

            else if (comboBoxNames.Text.Contains("EARPIECE"))
                indexExcel = 3;

            if (indexExcel != 0)
            {
                Microsoft.Office.Interop.Excel.Application objXL = null;
                Microsoft.Office.Interop.Excel.Workbook objWB = null;
                objXL = new Microsoft.Office.Interop.Excel.Application();
                objWB = objXL.Workbooks.Open(strFilePath);
                Microsoft.Office.Interop.Excel.Worksheet objSHT = objWB.Worksheets[indexExcel];

                int rows = objSHT.UsedRange.Rows.Count;
                int cols = objSHT.UsedRange.Columns.Count;
                int noofrow = 1;

                for (int i = 1; i <= cols; i++)
                {
                    string colname = objSHT.Cells[1, i].Text;
                    dt.Columns.Add(colname);
                    noofrow = 2;
                    Application.DoEvents();
                }

                for (int i = noofrow; i <= rows; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= cols; j++)
                    {
                        dr[j - 1] = objSHT.Cells[i, j].Text;
                        Application.DoEvents();
                    }
                    dt.Rows.Add(dr);
                    Application.DoEvents();
                }
                objWB.Close();
                objXL.Quit();
            }
            return dt;
        }

        private void buttonOpenFreqFile_Click(object sender, EventArgs e)//Import data from XSLX
        {
            disableButtons();
            bool result = false;
            result = importingExcel();
            if (result)
                enableButtons();
        }

        private void enableButtons()
        {
            buttonGravar.Enabled = true;
            buttonDelete.Enabled = true;
            buttonOpenFile.Enabled = true;
            buttonOpenFreqFile.Enabled = true;
            buttonSetKey.Enabled = true;
        }

        private void disableButtons()
        {
            buttonGravar.Enabled = false;
            buttonDelete.Enabled = false;
            buttonOpenFile.Enabled = false;
            buttonOpenFreqFile.Enabled = false;
            buttonSetKey.Enabled = false;
        }

        private bool importingExcel() //Import the XLSX to application
        {
            pictureBoxWarning.Image = Resources.loadingGif;
            disableButtons();

            if (textBoxFreqFileDir.Text == "")
            {
                openFileDialog2.Filter = "Excel Files| *.xls; *.xlsx; *.xlsm|All files (*.*)|*.*";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    textBoxFreqFileDir.Text = openFileDialog2.FileName;
            }
            try
            {
                if (textBoxFreqFileDir.Text != "")
                {
                    if (countXlsx == 0)
                        editingExcel();

                    DataTable dt = READExcel(textBoxFreqFileDir.Text);
                    int countR = dataGridViewCorrel.Rows.Count;
                    double Ll = 0.0;
                    double Ul = 0.0;
                    double average = 0.0;

                    for (int i = 0; i < countR; i++)
                    {
                        Application.DoEvents();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row[2].ToString().Contains(dataGridViewCorrel.Rows[i].Cells[0].Value.ToString()) && row[2].ToString().Contains("_AMP_"))
                            {
                                int lineDGV = Convert.ToInt32(dataGridViewCorrel.Rows[i].Cells[0].Value);
                                Ll = Convert.ToDouble(row[3]);
                                Ul = Convert.ToDouble(row[4]);
                                average = (Ll + Ul) / 2;
                                dataGridViewCorrel.Rows[i].Cells[2].Value = average.ToString("F4");
                            }
                            Application.DoEvents();
                        }
                    }
                    pictureBoxWarning.Image = Resources.Done;
                    enableButtons();
                    countXlsx++;
                    return true;
                }
                else
                {
                    pictureBoxWarning.Image = null;
                    enableButtons();
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "");
                pictureBoxWarning.Image = null;
                return false;
            }
        }

        private void comboBoxNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNames.Text != "")
            {
                viewDataGridView();

                if (textBoxFreqFileDir.Text != "")
                    importingExcel();
            }
        }

        static void AddCell(IRow row, int columnIndex, string value)//Create new line
        {
            ICell cell = row.CreateCell(columnIndex);
            cell.SetCellValue(value);
        }

        private bool editingExcel()//Change the XLSX and insert the new line
        {
            try
            {
                string filePath = textBoxFreqFileDir.Text;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fs);

                    for (int sheetIndex = 0; sheetIndex < 3; sheetIndex++)
                    {
                        ISheet sheet = workbook.GetSheetAt(sheetIndex);

                        string verifyCell = sheet.GetRow(0).GetCell(0).StringCellValue;

                        if (verifyCell != "Amplitude")
                        {
                            sheet.ShiftRows(0, sheet.LastRowNum, 1);

                            IRow newRow = sheet.CreateRow(0);

                            AddCell(newRow, 0, "Amplitude");
                            AddCell(newRow, 1, "Meas");
                            AddCell(newRow, 2, "TestName");
                            AddCell(newRow, 3, "LL");
                            AddCell(newRow, 4, "HL");
                            AddCell(newRow, 5, "dB");
                            AddCell(newRow, 6, "Product");
                            AddCell(newRow, 7, "*");
                            AddCell(newRow, 8, "-");
                            AddCell(newRow, 9, "+");
                            AddCell(newRow, 10, "Stat");
                            AddCell(newRow, 11, "Limit");
                            AddCell(newRow, 12, "Status");
                        }
                        using (FileStream fsWrite = new FileStream(filePath, FileMode.Create))
                        {
                            workbook.Write(fsWrite);
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

        private void buttonSetKey_Click(object sender, EventArgs e)
        {
            reWriteLineCorrel();
            buttonSetKey.BackColor = Color.LimeGreen;
            disableButtons();
        }
    }
}