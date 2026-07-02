/*
MIT License

Copyright (c) 2026 Sarayut Chaisuriya

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
 
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Note on dataset:
The included MalwareBazaar sample CSV has been modified:
- Limited to first 500 rows
- Header format adjusted for teaching purposes
See README.md for full details.
*/
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace FileProcessing
{
	public partial class frmTextView : Form
	{
		/// <summary>
		/// Initializes a new instance of the frmTextView class.
		/// </summary>
		public frmTextView()
		{
			InitializeComponent();
		}
        /// <summary>
        /// Handles the Click event of the Read button by loading the contents of the specified file into the display area.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btRead_Click(object sender, EventArgs e)
        {
            using (StreamReader srReader = new StreamReader(tbFileName.Text))
            {
                string strLine;
                bool bHeaderRead = false;
                int lineNumber = 1; 

                
                while ((strLine = srReader.ReadLine()) != null)
                {
                    

                    
                    if (!bHeaderRead) { bHeaderRead = true; continue; }

                    
                    if (lineNumber < 100) { lineNumber++; continue; }
                    if (lineNumber > 200) { break; }

                    
                    string[] columns = strLine.Split(',');
                    if (columns.Length > 6 && columns[5].Trim() == "exe") 
                    {
                        
                    }

                    lineNumber++; 
                }
            }
        
        string filePath = tbFileName.Text;

            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("กรุณาเลือกไฟล์ก่อน!");
                return;
            }
            try
            {
                
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                int m = 100;              
                int n = 200;              
                string filterExt = "exe"; 

                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    string line;
                    int lineNumber = 1;

                    
                    while ((line = reader.ReadLine()) != null)
                    {
                      
                        if (lineNumber < m)
                        {
                            lineNumber++;
                            continue; 
                        }
                        if (lineNumber > n)
                        {
                            break; 
                        }

                        string[] columns = line.Split(','); 

                        if (columns.Length > 2)
                        {
                            string currentExt = columns[2].Trim(); 

                            if (currentExt == filterExt) 
                            {
                                sb.AppendLine(line); 
                            }
                        }

                        lineNumber++; 
                    }
                }
                rtbShow.Text = sb.ToString();

                MessageBox.Show("อ่านข้อมูลเสร็จเรียบร้อย!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการอ่านไฟล์: " + ex.Message);
            }
        }
        /// <summary>
        /// Handles the Click event of the btReadCSV button, reading CSV data from the specified file and populating the
        /// DataGridView with its contents.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
		private void btReadCSV_Click(object sender, EventArgs e)
        {
            // เคลียร์ข้อมูลหน้าจอเก่าก่อนเริ่มทำงานใหม่
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            // ตรวจสอบว่ามีไฟล์อยู่จริงไหม
            if (string.IsNullOrEmpty(tbFileName.Text) || !System.IO.File.Exists(tbFileName.Text)) return;

            // แปลงค่าจากช่องกรอก Start Line และ End Line ให้เป็นตัวเลข
            int m, n;
            if (!int.TryParse(txtStartLine.Text, out m) || !int.TryParse(txtEndLine.Text, out n)) return;

            // 🌟 [เพิ่มใหม่] ตรวจสอบกรณีใส่ช่วงบรรทัดสลับกัน (Invalid Range: m > n)
            if (m > n)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: Invalid Range (บรรทัดเริ่มต้นต้องไม่มากกว่าบรรทัดสิ้นสุด)",
                                "แจ้งเตือนระบบ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // ตัดจบการทำงานทันที ระบบไม่พัง ไม่โหลดไฟล์
            }

            string filterExt = txtFilter.Text.Trim();
            DataTable dt = new DataTable();

            try
            {
                using (StreamReader sr = new StreamReader(tbFileName.Text))
                {
                    string line;
                    int currentLine = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine++;
                        string[] columns = line.Split(',');

                        // 1. สร้างหัวตารางจากบรรทัดแรกเสมอ
                        if (dt.Columns.Count == 0)
                        {
                            for (int i = 0; i < columns.Length; i++)
                            {
                                dt.Columns.Add("Col" + (i + 1));
                            }
                        }

                        // 2. ข้ามบรรทัดที่ไม่อยู่ในขอบเขต Range (m - n) ที่กำหนด
                        if (currentLine < m || currentLine > n) continue;

                        // 3. กรองข้อมูล (ค้นหาคำจากทั้งบรรทัด)
                        // ถ้าช่อง Filter ว่าง หรือพบคำค้นหาในบรรทัดนั้น ให้เพิ่มข้อมูลเข้าตาราง
                        if (string.IsNullOrEmpty(filterExt) || line.Contains(filterExt))
                        {
                            // สร้างแถวให้พอดีกับจำนวนคอลัมน์ของหัวตาราง
                            object[] row = new object[dt.Columns.Count];
                            for (int i = 0; i < columns.Length && i < dt.Columns.Count; i++)
                            {
                                row[i] = columns[i];
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }

                // ผูกข้อมูล DataTable เข้ากับ DataGridView เพื่อแสดงผลบนหน้าจอ
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
        /// <summary>
        /// Handles the Click event of the Browse button, allowing the user to select a file and displaying its path in the
        /// file name text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					tbFileName.Text = ofd.FileName;
				}
			}
		}

        private void txtStartLine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFileName.Text))
            {
                MessageBox.Show("กรุณาเลือกไฟล์ก่อนครับ!");
                return;
            }

            try
            {
                
                int m = int.Parse(txtStartLine.Text);
                int n = int.Parse(txtEndLine.Text);
                string filterExt = txtFilter.Text.Trim();

                
                if (m > n)
                {
                    MessageBox.Show("บรรทัดเริ่มต้นต้องไม่มากกว่าบรรทัดสิ้นสุดครับ!");
                    return;
                }

               
                DataTable dt = new DataTable();
               
                for (int i = 0; i < 6; i++) dt.Columns.Add("Col" + (i + 1));

                using (StreamReader sr = new StreamReader(tbFileName.Text))
                {
                    string line;
                    int currentLine = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        if (currentLine < m) { currentLine++; continue; }
                        if (currentLine > n) break;

                        
                        string[] columns = line.Split(',');

                       
                        if (string.IsNullOrEmpty(filterExt) || (columns.Length > 5 && columns[5].Trim() == filterExt))
                        {
                            dt.Rows.Add(columns);
                        }

                        currentLine++;
                    }
                }

               
                dataGridView1.DataSource = dt;
                MessageBox.Show("อ่านข้อมูลเสร็จแล้ว!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEndLine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFileName.Text))
            {
                MessageBox.Show("กรุณาเลือกไฟล์ก่อนครับ!");
                return;
            }

            try
            {
                int m = int.Parse(txtStartLine.Text);
                int n = int.Parse(txtEndLine.Text);
                string filterExt = txtFilter.Text.Trim();

                if (m > n)
                {
                    MessageBox.Show("บรรทัดเริ่มต้นต้องไม่มากกว่าบรรทัดสิ้นสุด!");
                    return;
                }

                DataTable dt = new DataTable();
                for (int i = 0; i < 6; i++) dt.Columns.Add("Col" + (i + 1));

                using (StreamReader sr = new StreamReader(tbFileName.Text))
                {
                    string line;
                    int currentLine = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (currentLine < m) { currentLine++; continue; }
                        if (currentLine > n) break;

                        string[] columns = line.Split(',');

                        if (string.IsNullOrEmpty(filterExt) || (columns.Length > 5 && columns[5].Trim() == filterExt))
                        {
                            dt.Rows.Add(columns);
                        }

                        currentLine++;
                    }
                }

           
                dataGridView1.DataSource = dt;
                MessageBox.Show("อ่านข้อมูลเสร็จแล้ว!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
    
            if (string.IsNullOrEmpty(tbFileName.Text))
            {
                MessageBox.Show("กรุณาเลือกไฟล์ก่อนครับ!");
                return;
            }

            try
            {
          
                int m = int.Parse(txtStartLine.Text);
                int n = int.Parse(txtEndLine.Text);
                string filterExt = txtFilter.Text.Trim();

   
                if (m > n)
                {
                    MessageBox.Show("บรรทัดเริ่มต้นต้องไม่มากกว่าบรรทัดสิ้นสุดครับ!");
                    return;
                }


                DataTable dt = new DataTable();
  
                for (int i = 0; i < 6; i++) dt.Columns.Add("Col" + (i + 1));

                using (StreamReader sr = new StreamReader(tbFileName.Text))
                {
                    string line;
                    int currentLine = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
   
                        if (currentLine < m) { currentLine++; continue; }
                        if (currentLine > n) break;

                  
                        string[] columns = line.Split(',');

           
                        if (string.IsNullOrEmpty(filterExt) || (columns.Length > 5 && columns[5].Trim() == filterExt))
                        {
                            dt.Rows.Add(columns);
                        }

                        currentLine++;
                    }
                }

            
                dataGridView1.DataSource = dt;
                MessageBox.Show("อ่านข้อมูลเสร็จแล้ว!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }
}

