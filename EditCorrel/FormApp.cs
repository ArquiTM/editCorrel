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
        XmlDocument myDoc = new XmlDocument();

        EditXlsx EdX;
        FileImport fI = new FileImport();
        Utils Uts;
        FillDGV FDGV;
        OpenCorrel Oc;
        EditNodeCorrel ENC;


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
        }

        public static FormApp getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new FormApp();

            return INSTANCE;
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
            result = Uts.selectingCorrel();

            if (result)
                Uts.getFileStatus();
        }

        //private bool selectingCorrel()//Select the correl
        //{
        //    try
        //    {
        //        openFileDialog1.Filter = "Correl files (*.correl)|*.correl|All files (*.*)|*.*";
        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //            textBoxCorrelDir.Text = openFileDialog1.FileName;

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

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
        }
    }
}