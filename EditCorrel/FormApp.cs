using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace EditCorrel
{
    public partial class formMain : Form
    {
        string originalCorrel = string.Empty;
        string tempCorrel = string.Empty;
        string line = string.Empty;
        XmlDocument myDoc = new XmlDocument();

        public formMain()
        {
            InitializeComponent();
        }
        public bool OpenFile()
        {
            try
            {
                string file_name = textBoxCorrelDir.Text;

                if (file_name == string.Empty)
                    MessageBox.Show("Não foi selecionado nenhum arquivo para edição!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    using (var reader = new StreamReader(file_name))
                    {
                        myDoc.Load(new StreamReader(file_name));
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

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
                return false;
            }
            return false;
        }
        private void buttonVerify_Click(object sender, EventArgs e)
        {
            getFile();
        }
        private void getFile()
        {
            bool result = OpenFile();
            if (result)
                buttonVerify.BackColor = Color.Green;
            else
                buttonVerify.BackColor = Color.Red;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            viewDataGridView();
        }

        private void viewDataGridView()
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteLineComboBox();
        }
        private void deleteLineComboBox()
        {
            if (comboBoxNames.Text == "")
                MessageBox.Show("Não foi selecionado nenhum arquivo!!!", "ComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string nodesXml = string.Empty;

                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;

                    if (nodesXml.Contains(comboBoxNames.Text))
                    {
                        node.RemoveAll();
                        comboBoxNames.Items.Remove(comboBoxNames.Text);
                        comboBoxNames.Text = "";
                        return;
                    }
                }
            }
            dataGridViewCorrel.Rows.Clear();
            Application.DoEvents();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            bool result = false;
            result = deleteNamesNewFile();
            if (result)
            {
                changeFreqNewFile();
                FormExportOk formEOk = new FormExportOk();
                formEOk.Show();
            }
        }
        private bool deleteNamesNewFile()
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
                    if (File.Exists(tempCorrel))
                        File.Delete(tempCorrel);

                    string sourcefile = originalCorrel + ".correl";
                    File.Copy(sourcefile, tempCorrel);

                    using (var reader = new StreamReader(textBoxCorrelDir.Text))
                    using (var writer = new StreamWriter(tempCorrel))
                    {
                        myDoc.Load(new StreamReader(textBoxCorrelDir.Text));

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
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        private void changeFreqNewFile()
        {
            string finalCorrel = tempCorrel.Replace("temporary.correl", "new_OK.correl");

            if (comboBoxNames.Text != "")
            {
                if (File.Exists(tempCorrel))
                    File.Delete(tempCorrel);

                if (File.Exists(originalCorrel + "_new_OK.correl"))
                    File.Copy(originalCorrel + "_new_OK.correl", tempCorrel);

                using (var readerN = new StreamReader(tempCorrel))
                using (var writerN = new StreamWriter(finalCorrel))
                {
                    myDoc.Load(new StreamReader(tempCorrel));
                    int freqDataGridView = 0;
                    int count = dataGridViewCorrel.Rows.Count;
                    int i = 0;

                    dataGridViewCorrel.Rows[i].Cells[1].Value = dataGridViewCorrel.Rows[i].Cells[2].Value;
                    while ((line = readerN.ReadLine()) != null && i < count)
                    {
                        if (i == 35)
                            writerN.WriteLine(line);

                        dataGridViewCorrel.Rows[i].Cells[1].Value = dataGridViewCorrel.Rows[i].Cells[2].Value;

                        if (line.Contains(comboBoxNames.Text))
                        {
                            writerN.WriteLine(line);
                            while ((line = readerN.ReadLine()) != null && i < count)
                            {
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
            else
            {
                File.Copy(tempCorrel, finalCorrel, true);
            }
        }
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Correl files (*.correl)|*.correl|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxCorrelDir.Text = openFileDialog1.FileName;
                originalCorrel = textBoxCorrelDir.Text.Replace(".correl", "");
                tempCorrel = originalCorrel + "_temporary.correl";
                File.Copy(originalCorrel + ".correl", originalCorrel + "_new_OK.correl", true);
            }
        }
        public DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        private void buttonOpenFreqFile_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Comma delimited (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBoxFreqFileDir.Text = openFileDialog2.FileName;
            }
            try
            {
                DataTable freqFileDt = ConvertCSVtoDataTable(textBoxFreqFileDir.Text);
                int countR = dataGridViewCorrel.Rows.Count;
                double Ll = 0.0;
                double Ul = 0.0;
                double average = 0.0;
                for (int i = 0; i < countR; i++)
                {
                    foreach (DataRow row in freqFileDt.Rows)
                    {
                        if (row[2].ToString().Contains(dataGridViewCorrel.Rows[i].Cells[0].Value.ToString()) && row[2].ToString().Contains("_AMP_"))
                        {
                            Ll = Convert.ToDouble(row[3]);
                            Ul = Convert.ToDouble(row[4]);
                            average = (Ll + Ul) / 2;
                            dataGridViewCorrel.Rows[i].Cells[2].Value = average;
                        }
                    }
                }
            }
            catch { }
        }
    }
}
