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

        public void OpenFile()
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

        private void getFile()
        {
            OpenFile();

            if (status)
                buttonVerify.BackColor = Color.Green;

            else
                buttonVerify.BackColor = Color.Red;
        }
        private void buttonView_Click(object sender, EventArgs e)
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
                int countCorrect = 0;
                string nodesXml = String.Empty;
                string[] vectRes;

                string[] correct;
                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;


                    if (nodesXml.Contains(comboBoxNames.Text))
                    {
                        correct = nodesXml.Split(new[] { "</ValueDescription>" ,  "<ValueDescription />", "</FrequencyOffset>" }, StringSplitOptions.None);
                       // correct = nodesXml.Split(new[] { "</FrequencyOffset>" }, StringSplitOptions.None);
                        
                        countCorrect = correct.Length;

                        

                        for (int i = 1; i < countCorrect; i++)
                        {
                            if (correct[i].Contains("Frequency"))
                            {
                                freqF = correct[i].Replace("<FrequencyOffset><Frequency>", "");
                                freqF = freqF.Replace("</Frequency><Offset>", "-");
                                freqF = freqF.Replace("</Offset>", "");
                                offS = freqF;
                                vectRes = freqF.Split('-');

                              //  foreach(XmlNode nodes in correct[i])
                                {

                                }


                                //freqF = correct[i].Remove.RightToLeft
                                this.dataGridViewCorrel.Rows.Add(vectRes[0], vectRes[1]);

                            }
                        }
                    }
                }

                //for (int i = 0; i < countCorrect; i++)
                {
                    //    textBoxTest.Text = correct[i] + Environment.NewLine;
                }

                //string nameOfFreq = myDoc["CorrelationData"]["Tests"].OuterXml;


                // foreach (string frequencyFromFile in )
                {

                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!status)
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
