using System;
using System.Windows.Forms;

namespace EditCorrel
{
    public partial class FormExportOk : Form
    {
        public FormExportOk()
        {
            InitializeComponent();
        }

        private void buttonOkFinishIcon_Click(object sender, EventArgs e)
        {
            if (labelStatusFinishIcon.Text.Contains("finalizado"))
                Environment.Exit(0);

            this.Close();
        }
    }
}
