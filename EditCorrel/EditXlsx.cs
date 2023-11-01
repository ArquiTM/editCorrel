using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using EditCorrel.Properties;
using System.Windows.Forms;
using System.Data;
using System;

namespace EditCorrel
{
    class EditXlsx
    {
        FormApp frmMain = FormApp.getInstance();
        Utils Uts = new Utils();
        int countXlsx = 0;

        static void AddCell(IRow row, int columnIndex, string value)//Create new line
        {
            ICell cell = row.CreateCell(columnIndex);
            cell.SetCellValue(value);
        }

        public bool editingExcel(string xlsx)//Change the XLSX and insert the new line
        {
            try
            {
                string filePath = xlsx;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fs);

                    for (int sheetIndex = 0; sheetIndex < 3; sheetIndex++)
                    {
                        ISheet sheet = workbook.GetSheetAt(sheetIndex);

                        string verifyCell = sheet.GetRow(0).GetCell(0).StringCellValue;

                        if (verifyCell != "Amplitude")
                        {
                            sheet.ShiftRows(0, sheet.LastRowNum, 1);

                            IRow newRow = sheet.CreateRow(0);

                            AddCell(newRow, 0, "Amplitude");
                            AddCell(newRow, 1, "Meas");
                            AddCell(newRow, 2, "TestName");
                            AddCell(newRow, 3, "LL");
                            AddCell(newRow, 4, "HL");
                            AddCell(newRow, 5, "dB");
                            AddCell(newRow, 6, "Product");
                            AddCell(newRow, 7, "*");
                            AddCell(newRow, 8, "-");
                            AddCell(newRow, 9, "+");
                            AddCell(newRow, 10, "Stat");
                            AddCell(newRow, 11, "Limit");
                            AddCell(newRow, 12, "Status");
                        }
                        using (FileStream fsWrite = new FileStream(filePath, FileMode.Create))
                        {
                            workbook.Write(fsWrite);
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
        
        public bool importingExcel(DataGridView grid) //Import the XLSX to application
        {
            frmMain.pictureBoxWarning.Image = Resources.loadingGif;
            Uts.disableButtons();

            if (frmMain.textBoxFreqFileDir.Text == "")
            {
                frmMain.openFileDialog2.Filter = "Excel Files| *.xls; *.xlsx; *.xlsm|All files (*.*)|*.*";
                if (frmMain.openFileDialog2.ShowDialog() == DialogResult.OK)
                    frmMain.textBoxFreqFileDir.Text = frmMain.openFileDialog2.FileName;
            }
            try
            {
                if (frmMain.textBoxFreqFileDir.Text != "")
                {
                    if (countXlsx == 0)
                        editingExcel(frmMain.textBoxFreqFileDir.Text);

                    DataTable dt = READExcel(frmMain.textBoxFreqFileDir.Text);
                    int countR = frmMain.dataGridViewCorrel.Rows.Count;
                    double Ll = 0.0;
                    double Ul = 0.0;
                    double average = 0.0;

                    for (int i = 0; i < countR; i++)
                    {
                        Application.DoEvents();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row[2].ToString().Contains(frmMain.dataGridViewCorrel.Rows[i].Cells[0].Value.ToString()) && row[2].ToString().Contains("_AMP_"))
                            {
                                int lineDGV = Convert.ToInt32(frmMain.dataGridViewCorrel.Rows[i].Cells[0].Value);
                                Ll = Convert.ToDouble(row[3]);
                                Ul = Convert.ToDouble(row[4]);
                                average = (Ll + Ul) / 2;
                                grid.Rows[i].Cells[2].Value = average.ToString("F4");
                            }
                            Application.DoEvents();
                        }
                    }
                    frmMain.pictureBoxWarning.Image = Resources.Done;
                    Uts.enableButtons();
                    countXlsx++;
                    return true;
                }
                else
                {
                    frmMain.pictureBoxWarning.Image = null;
                    Uts.enableButtons();
                    return false;
                }
            }
            catch
            {
                frmMain.pictureBoxWarning.Image = null;
                return false;
            }
        }

        public DataTable READExcel(string strFilePath)//Read the XLSX file
        {
            DataTable dt = new DataTable();
            int indexExcel = 0;

            if (frmMain.comboBoxNames.Text.Contains("LEFT"))
                indexExcel = 1;

            else if (frmMain.comboBoxNames.Text.Contains("RIGHT"))
                indexExcel = 2;

            else if (frmMain.comboBoxNames.Text.Contains("EARPIECE"))
                indexExcel = 3;

            if (indexExcel != 0)
            {
                Microsoft.Office.Interop.Excel.Application objXL = null;
                Microsoft.Office.Interop.Excel.Workbook objWB = null;
                objXL = new Microsoft.Office.Interop.Excel.Application();
                objWB = objXL.Workbooks.Open(strFilePath);
                Microsoft.Office.Interop.Excel.Worksheet objSHT = objWB.Worksheets[indexExcel];

                int rows = objSHT.UsedRange.Rows.Count;
                int cols = objSHT.UsedRange.Columns.Count;
                int noofrow = 1;

                for (int i = 1; i <= cols; i++)
                {
                    string colname = objSHT.Cells[1, i].Text;
                    dt.Columns.Add(colname);
                    noofrow = 2;
                    Application.DoEvents();
                }

                for (int i = noofrow; i <= rows; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= cols; j++)
                    {
                        dr[j - 1] = objSHT.Cells[i, j].Text;
                        Application.DoEvents();
                    }
                    dt.Rows.Add(dr);
                    Application.DoEvents();
                }
                objWB.Close();
                objXL.Quit();
            }
            return dt;
        }
    }
}
