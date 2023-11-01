using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace EditCorrel
{
    class DeleteAndChangeFreq
    {
        FormApp frmMain = FormApp.getInstance();
        XmlDocument myDoc = new XmlDocument();

        public void deleteLineComboBox()//Delete the test of Combo Box
        {
            if (frmMain.comboBoxNames.Text == "")
                MessageBox.Show("Não foi selecionado nenhum teste!!!", "ComboBox Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string nodesXml = string.Empty;
                myDoc = new XmlDocument();
                string file_name = frmMain.textBoxCorrelDir.Text;
                myDoc.Load(new StreamReader(file_name));

                foreach (XmlNode node in myDoc.DocumentElement.ChildNodes)
                {
                    nodesXml = node.InnerXml;

                    if (nodesXml.Contains(frmMain.comboBoxNames.Text))
                    {
                        node.RemoveAll();
                        frmMain.comboBoxNames.Items.Remove(frmMain.comboBoxNames.Text);
                        frmMain.comboBoxNames.Text = "";
                        frmMain.dataGridViewCorrel.Rows.Clear();
                        return;
                    }
                }
            }
        }

        public bool deleteNamesNewFile()//Delete the test node from correl file
        {
            if (frmMain.originalCorrel == string.Empty)
            {
                MessageBox.Show("Não há arquivo Correl selecionado!!!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                try
                {
                    if (!File.Exists(frmMain.tempCorrel))
                        File.Copy(frmMain.newCorrel, frmMain.tempCorrel);

                    using (var reader = new StreamReader(frmMain.tempCorrel))
                    {
                        using (var writer = new StreamWriter(frmMain.newCorrel))
                        {
                            myDoc = new XmlDocument();
                            myDoc.Load(new StreamReader(frmMain.tempCorrel));

                            while ((frmMain.line = reader.ReadLine()) != null)
                            {
                                if (frmMain.line.Contains("<Tests>"))
                                    frmMain.line = frmMain.line.Replace(frmMain.line, "");

                                else if (frmMain.line.Contains("<Name>"))
                                {
                                    frmMain.line = frmMain.line.Replace("    <Name>", "");
                                    frmMain.line = frmMain.line.Replace("</Name>", "");

                                    if (!frmMain.comboBoxNames.Items.Contains(frmMain.line))
                                    {
                                        while (!frmMain.line.Contains(@"</Tests>"))
                                        {
                                            frmMain.line = frmMain.line.Replace(frmMain.line, "");
                                            writer.Write(frmMain.line);
                                            frmMain.line = reader.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        writer.WriteLine("  <Tests>");
                                        frmMain.line = "    <Name>" + frmMain.line + "</Name>";
                                        writer.WriteLine(frmMain.line);
                                    }
                                }
                                else
                                    writer.WriteLine(frmMain.line);
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
        public bool changeFreqNewFile()//Change the freq of new correl file
        {
            try
            {
                if (!File.Exists(frmMain.tempCorrel))
                    File.Copy(frmMain.newCorrel, frmMain.tempCorrel);

                using (var readerN = new StreamReader(frmMain.tempCorrel))
                {
                    using (var writerN = new StreamWriter(frmMain.newCorrel))
                    {
                        myDoc = new XmlDocument();
                        myDoc.Load(new StreamReader(frmMain.tempCorrel));
                        int freqDataGridView = 0;
                        int count = frmMain.dataGridViewCorrel.Rows.Count;
                        int rowsCount = Convert.ToInt32(frmMain.dataGridViewCorrel.RowCount.ToString());
                        int i = 0;

                        while ((frmMain.line = readerN.ReadLine()) != null)
                        {
                            if (frmMain.line.Contains(frmMain.comboBoxNames.Text))
                            {
                                writerN.WriteLine(frmMain.line);
                                while ((frmMain.line = readerN.ReadLine()) != null && i < count)
                                {
                                    frmMain.dataGridViewCorrel.Rows[i].Cells[1].Value = frmMain.dataGridViewCorrel.Rows[i].Cells[2].Value;

                                    freqDataGridView = Convert.ToInt32(frmMain.dataGridViewCorrel.Rows[i].Cells[0].Value);
                                    if (frmMain.line.Contains($"<Frequency>{freqDataGridView.ToString()}"))
                                    {
                                        writerN.WriteLine(frmMain.line);
                                        frmMain.line = readerN.ReadLine();
                                        writerN.WriteLine($"      <Offset>{ frmMain.dataGridViewCorrel.Rows[i].Cells[2].Value}</Offset>");
                                        i++;
                                    }
                                    else
                                        writerN.WriteLine(frmMain.line);
                                }
                                writerN.WriteLine(frmMain.line);

                                if (frmMain.comboBoxNames.SelectedIndex < frmMain.comboBoxNames.Items.Count)
                                {
                                    while ((frmMain.line = readerN.ReadLine()) != null)
                                    {
                                        writerN.WriteLine(frmMain.line);
                                    }
                                }
                            }
                            else
                                writerN.WriteLine(frmMain.line);
                        }
                        writerN.WriteLine(frmMain.line);
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
}
