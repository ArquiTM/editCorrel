using System;
using System.Drawing;
using System.IO;
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
            getFile();

        }

        public void OpenFile() //Abrir o arquivo na raiz do diretório que contém ".correl"
        {
            try
            {
                foreach (string file_name in Directory.GetFiles(@".\", strLogPattern, SearchOption.TopDirectoryOnly))
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
                string nodesXml = String.Empty;
                string[] line;
                string[] vectLine;

                int countCorrect = 0;

                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;


                    if (nodesXml.Contains(comboBoxNames.Text))
                    {
                        line = nodesXml.Split(new[] { "</ValueDescription>" ,  "<ValueDescription />", "</FrequencyOffset>" }, StringSplitOptions.None);                        
                        countCorrect = line.Length;
                     
                        for (int i = 0; i < countCorrect; i++)
                        {
                            if (line[i].Contains("Frequency"))
                            {
                                freqF = line[i].Replace("<FrequencyOffset><Frequency>", "");
                                freqF = freqF.Replace("</Frequency><Offset>", " ");
                                freqF = freqF.Replace("</Offset>", "");
                                offS = freqF;
                                vectLine = freqF.Split(' ');

                                this.dataGridViewCorrel.Rows.Add(vectLine[0], vectLine[1]);

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

            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
