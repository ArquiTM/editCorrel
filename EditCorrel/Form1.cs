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
        string line = string.Empty;
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



                using (var reader = new StreamReader(newCorrel))
                {
                    myDoc.Load(new StreamReader(newCorrel));

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("<Name>"))
                        {
                            line = line.Replace("    <Name>", "");
                            line = line.Replace("</Name>", "");
                            if (!comboBoxNames.Items.Contains(line))
                            {
                                using (var writer = new StreamWriter(newCorrel))
                                {

                                }
                            }
                        }

                        comboBoxNames.Items.Add(line);
                    }
                }
            }

            /*


            XmlDocument doc = new XmlDocument();
            doc.Load(newCorrel);

            foreach (XmlNode node in doc)
            {
                if (!comboBoxNames.Items.Contains(node))
                    doc.RemoveChild(node);
            }

            doc.Save(newName + "_copy.correl");



            /*string path = (newName + "_copy.correl");




            using (StreamWriter correlUptade = File.CreateText(path))
            {
                correlUptade.WriteLine(@"<?xml version=""1.0"" encoding=""utf - 16""?>");
                correlUptade.WriteLine("<CorrelationData>");
                correlUptade.WriteLine("    <XmlVersion> 2 </XmlVersion>");
                correlUptade.WriteLine("    <UnitID> NNSR2C0106 </UnitID>");

                string file_name = (textBoxCorrelDir.Text);


                using (var reader = new StreamReader(file_name))
                {
                    //  XmlDocument doc = new XmlDocument();
                    XmlElement root = myDoc.DocumentElement;
                    XmlNodeList nodes = root.SelectNodes("//CorrelationData/Tests");

                    myDoc.Load(new StreamReader(file_name));
                    status = true;
                    // while ((line = reader.ReadLine()) != null)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            if (node.InnerText.Contains(comboBoxNames.GetItemText(0)))
                            {
                                correlUptade.WriteLine("    <Tests>");
                                correlUptade.WriteLine(node.InnerXml);
                                correlUptade.WriteLine("    </Tests>");
                            }

                            //using (StreamWriter correlUptade = File.WriteAllText(node)) { }

                        }
                        correlUptade.WriteLine("</CorrelationData>");
                    }

                }

                //XmlDocument correlUpdate = new XmlDocument();






                // correlUpdate.(newName + "_copy.correl");


                /*  XmlElement root = correlUpdate.CreateElement("root");
                  correlUpdate.AppendChild(root);
                  XmlComment comment = correlUpdate.CreateComment("Comment");
                  root.AppendChild(comment);

                  XmlWriterSettings settings = new XmlWriterSettings
                  {
                      Encoding = Encoding.UTF8,
                      ConformanceLevel = ConformanceLevel.Document,
                      OmitXmlDeclaration = false,
                      CloseOutput = true,
                      Indent = true,
                      IndentChars = "  ",
                      NewLineHandling = NewLineHandling.Replace
                  };

                  using (StreamWriter sw = File.CreateText(newName + "_copy.correl"))
                  using (XmlWriter writer = XmlWriter.Create(sw, settings))
                  {
                      correlUpdate.WriteContentTo(writer);
                      writer.Close();
                  }

                 // string document = File.ReadAllText(newName + "_copy.correl");
                 */





            FormExportOk formEOk = new FormExportOk();
            formEOk.Show();
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
