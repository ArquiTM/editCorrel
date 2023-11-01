using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace EditCorrel
{
    class FillDGV
    {
        public void viewDataGridView()//Fill Data Grid View with values
        {
            FormApp frmMain = FormApp.getInstance();
            XmlDocument myDoc = new XmlDocument();

            frmMain.dataGridViewCorrel.Rows.Clear();

            if (frmMain.comboBoxNames.Text == "")
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
                string file_name = frmMain.textBoxCorrelDir.Text;
                myDoc.Load(new StreamReader(file_name));

                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;

                    if (nodesXml.Contains(frmMain.comboBoxNames.Text))
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

                                frmMain.dataGridViewCorrel.Rows.Add(vectLine[0], vectLine[1]);
                            }
                        }
                    }
                }
            }
        }
    }
}
