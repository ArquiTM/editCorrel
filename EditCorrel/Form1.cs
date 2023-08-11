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
            OpenFile();

            if (status)
                buttonVerify.BackColor = Color.Green;

            else
                buttonVerify.BackColor = Color.Red;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (!status)
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {

                string[] correct;
                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    string nodesXml = node.InnerXml;
                    string combo = comboBoxNames.Text;
                    if (nodesXml.Contains(combo))
                        correct = nodesXml.Split(new string[] { "</FrequencyOffset>" }, StringSplitOptions.None);

                    
                }

                //for (int i = 0; i < correct.Length; i++)
                {
                 //   textBoxTest.Text = correct[1] + Environment.NewLine;
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
    }
}
