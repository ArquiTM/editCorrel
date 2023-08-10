using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace EditCorrel
{
    public partial class formMain : Form
    {
        string strLogPattern = "*.correl*";
        bool status = false;



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
                        string line;
                        status = true;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("<Name>"))
                            {
                                line = line.Replace("   <Name>", "");
                                line = line.Replace("</Name>", "");
                                comboBoxNames.Items.Add(line);
                            }

                            //                                if (line.Contains("TH4") && !line.Contains("LEAK") && !line.Contains("L2VISIONCAL") && !line.Contains("L2ARNORM") && !line.Contains("L2ARGEN") && !line.Contains("RadioTst_VisCal"))
                            //                                  getPatternAndWriteToDB(line);
                        }
                    }                    
                }
            }


            catch
            {
                status = false;
            }
        }



        private void buttonView_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            OpenFile();

            if (status)
                buttonVerify.BackColor = Color.Green;

            else
                buttonVerify.BackColor = Color.Red;

        }
    }
}
