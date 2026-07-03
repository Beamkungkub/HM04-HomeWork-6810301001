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
using System.Text;
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
            // 1. 🧹 เคลียร์ข้อมูลเก่าของ "ทั้งคู่" ทิ้งพร้อมกันเพื่อเตรียมรับของใหม่
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            rtb.Clear(); // เคลียร์ฝั่ง TXT ด้วย

            // 2. 🔍 ตรวจสอบพาธไฟล์
            if (string.IsNullOrEmpty(tbFileName.Text) || !File.Exists(tbFileName.Text))
            {
                MessageBox.Show("กรุณาเลือกไฟล์ก่อนครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. 🔢 แปลงค่าบรรทัดเริ่มต้น (m) และสิ้นสุด (n) อย่างปลอดภัย
            int m, n;
            if (!int.TryParse(txtStartLine.Text.Trim(), out m) || !int.TryParse(txtEndLine.Text.Trim(), out n))
            {
                MessageBox.Show("กรุณากรอกตัวเลขบรรทัดให้ถูกต้อง (ห้ามมีช่องว่าง)", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m > n)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: บรรทัดเริ่มต้นต้องไม่มากกว่าบรรทัดสิ้นสุด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filterExt = txtFilter.Text.Trim();

            // เตรียมตัวเก็บข้อมูลของทั้ง 2 รูปแบบ
            DataTable dt = new DataTable();        // 🟢 สำหรับฝั่ง CSV (ตาราง)
            StringBuilder sb = new StringBuilder(); // 🔵 สำหรับฝั่ง TXT (ตัวหนังสือดิบ)

            try
            {
                using (StreamReader sr = new StreamReader(tbFileName.Text))
                {
                    string line;
                    int currentLine = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        // จัดการบรรทัดหัวตาราง (สำหรับ CSV)
                        if (line.StartsWith("#"))
                        {
                            if (line.Contains("first_seen_utc"))
                            {
                                string headerLine = line.Replace("#", "").Trim();
                                string[] headerColumns = headerLine.Split(',');

                                if (dt.Columns.Count == 0)
                                {
                                    for (int i = 0; i < headerColumns.Length; i++)
                                    {
                                        dt.Columns.Add(headerColumns[i].Trim().Replace("\"", ""));
                                    }
                                }
                            }
                            continue; // บรรทัดหัวตารางจะไม่เอาไปนับบรรทัดข้อมูล
                        }

                        currentLine++;

                        // เช็คขอบเขตบรรทัด m ถึง n (แชร์เงื่อนไขร่วมกัน)
                        if (currentLine < m || currentLine > n) continue;

                        // กรองข้อมูลด้วย Filter (แชร์เงื่อนไขร่วมกัน)
                        if (string.IsNullOrEmpty(filterExt) || line.Contains(filterExt))
                        {
                            // 🟢 จัดการเก็บเข้าฝั่ง CSV (แตกคอลัมน์ลงตาราง)
                            string[] columns = line.Split(',');
                            if (dt.Columns.Count == 0)
                            {
                                for (int i = 0; i < columns.Length; i++) dt.Columns.Add("Col" + (i + 1));
                            }

                            object[] row = new object[dt.Columns.Count];
                            for (int i = 0; i < columns.Length && i < dt.Columns.Count; i++)
                            {
                                row[i] = columns[i];
                            }
                            dt.Rows.Add(row);

                            // 🔵 จัดการเก็บเข้าฝั่ง TXT (ยัดลงตัวหนังสือดิบต่อท้ายไปเรื่อยๆ)
                            sb.AppendLine(line);
                        }
                    }
                }

                // 4. 🚀 พ่นข้อมูลออกหน้าจอพร้อมกันทั้งสองฝั่งอย่างเป็นทางการ!
                dataGridView1.DataSource = dt;   // ตารางอัปเดต
                rtb.Text = sb.ToString(); // กล่องข้อความอัปเดต
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการซิงค์ข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // ตรวจสอบกรณีใส่ช่วงบรรทัดสลับกัน (Invalid Range: m > n)
            if (m > n)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: Invalid Range (บรรทัดเริ่มต้นต้องไม่มากกว่าบรรทัดสิ้นสุด)",
                                "แจ้งเตือนระบบ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
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
                        // 🌟 [จุดแก้ไข] ตรวจสอบบรรทัดคอมเมนต์อธิบายไฟล์
                        if (line.StartsWith("#"))
                        {
                            // ถ้าเป็นบรรทัดที่มีคำว่า first_seen_utc แสดงว่าเป็นบรรทัดหัวตารางจริง!
                            if (line.Contains("first_seen_utc"))
                            {
                                // ถอดเครื่องหมาย # ออก แล้วตัดช่องว่าง
                                string headerLine = line.Replace("#", "").Trim();
                                string[] headerColumns = headerLine.Split(',');

                                if (dt.Columns.Count == 0)
                                {
                                    for (int i = 0; i < headerColumns.Length; i++)
                                    {
                                        // เอาชื่อคอลัมน์จริงใส่ในตาราง (และลบเครื่องหมายคำพูดออกถ้ามี)
                                        string colName = headerColumns[i].Trim().Replace("\"", "");
                                        dt.Columns.Add(colName);
                                    }
                                }
                            }
                            continue; // ข้ามบรรทัดคอมเมนต์อื่นๆ ไป ไม่เอามานับเป็นแถวข้อมูล
                        }

                        currentLine++;

                        // ข้ามบรรทัดที่ไม่อยู่ในขอบเขต Range (m - n) ที่กำหนด
                        if (currentLine < m || currentLine > n) continue;

                        string[] columns = line.Split(',');

                        // ตัวช่วยสำรอง: กรณีที่ไฟล์ไม่มีหัวคอลัมน์จริง ให้ใช้ Col1, Col2 ไปก่อนเพื่อไม่ให้โปรแกรมพัง
                        if (dt.Columns.Count == 0)
                        {
                            for (int i = 0; i < columns.Length; i++)
                            {
                                dt.Columns.Add("Col" + (i + 1));
                            }
                        }

                        // กรองข้อมูล (ค้นหาคำจากทั้งบรรทัด)
                        if (string.IsNullOrEmpty(filterExt) || line.Contains(filterExt))
                        {
                            object[] row = new object[dt.Columns.Count];
                            for (int i = 0; i < columns.Length && i < dt.Columns.Count; i++)
                            {
                                row[i] = columns[i];
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }

                // ผูกข้อมูล DataTable เข้ากับ DataGridView เพื่อแสดงผล
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

