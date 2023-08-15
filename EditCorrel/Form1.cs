using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EditCorrel
{
    public partial class formMain : Form
    {
        string strLogPattern = "*.correl*";
        bool status = false;
        XmlDocument myDoc = new XmlDocument();


        public formMain()
        {
            InitializeComponent();
        }

        public void OpenFile() //Abrir o arquivo na raiz do diretório que contém ".correl"
        {
            try
            {
                if (!status)
                {
                    string file_name = (textBoxCorrelDir.Text);

                    if (file_name == string.Empty)
                        MessageBox.Show("Não foi selecionado nenhum arquivo para edição!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else
                    {
                        using (var reader = new StreamReader(file_name))
                        {
                            string line = string.Empty;

                            myDoc.Load(new StreamReader(file_name));
                            status = true;
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
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
                status = false;
            }
        }
        private void buttonVerify_Click(object sender, EventArgs e)
        {
            getFile();
        }

        private void getFile()//Abre o Arquivo ".correl"
        {
            OpenFile();

            if (status)
                buttonVerify.BackColor = Color.Green;

            else
                buttonVerify.BackColor = Color.Red;
        }
        private void buttonView_Click(object sender, EventArgs e) //Popula o data grid view
        {
            dataGridViewCorrel.Rows.Clear();
            if (comboBoxNames.Text == "")
                MessageBox.Show("Não foi selecionado nenhum arquivo!!!", "ComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (!status)
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

                                dataGridViewCorrel.Rows.Add(vectLine[0], vectLine[1]);
                            }
                        }
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) //deletar os testes não usados
        {
            if (comboBoxNames.Text == "")
                MessageBox.Show("Não foi selecionado nenhum arquivo!!!", "ComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (!status)
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    }
                }
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            string newName = textBoxCorrelDir.Text.Replace(".correl", "");

            if (newName == string.Empty)
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                string sourcefile = (newName + ".correl");

                //XmlDocument newCorrel = new XmlDocument();

                string newCorrel = (newName + "_copy.correl");
                File.Copy(sourcefile, newCorrel);


                using (var reader = new StreamReader(textBoxCorrelDir.Text))
                using (var writer = new StreamWriter(newCorrel))
                {
                    string line = string.Empty;

                    myDoc.Load(new StreamReader(textBoxCorrelDir.Text));

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("<Name>"))
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
                                writer.WriteLine(line);
                            }
                            else
                            {
                                line = "    <Name>" + line + "</Name>";
                                writer.WriteLine(line);
                            }
                        }
                        else
                            writer.WriteLine(line);
                    }
                }
                FormExportOk formEOk = new FormExportOk();
                formEOk.Show();
            }
        }




        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Correl files (*.correl)|*.correl|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxCorrelDir.Text = openFileDialog1.FileName;
            }
        }
    }
}
