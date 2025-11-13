using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai09
{
    public partial class Form1 : Form
    {

        private List<string> MSSV = new List<string>();
        private List<string> TenMon = new List<string>();


        public Form1()
        {
            
            InitializeComponent();
            listBox1.Sorted = true;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                TenMon.Add(listBox1.Items[i].ToString());
            }    
            listBox2.Sorted = true;

            listBox2.Items.Clear();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                object selectedItem = listBox1.SelectedItem;

                listBox2.Items.Add(selectedItem);

                listBox1.Items.Remove(selectedItem);

                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                object selectedItem = listBox2.SelectedItem;

                listBox1.Items.Add(selectedItem);

                listBox2.Items.Remove(selectedItem);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (MSSV.Contains(textBox1.Text))
                {
                    DialogResult ketqua = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu hay không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ketqua != DialogResult.Yes)
                    {
                        textBox1.Clear();
                        return;
                    }    
                    MSSV.Remove(textBox1.Text);
                    for (int i = 0; i < dataGridView1.RowCount;  i++)
                    {
                        if (textBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            break;
                        }    
                    }
                    MessageBox.Show("Xóa dữ liệu thành công.");
                }
                else
                {
                    MessageBox.Show("Dữ liệu bạn nhập không có để xóa!");
                }
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = string.Empty;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập MSSV để xóa!");
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(comboBox1.Text) && !(checkBox1.Checked == checkBox2.Checked))
            {
                if (MSSV.Contains(textBox1.Text))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string dataCell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        if (dataCell == textBox1.Text)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = textBox2.Text;
                            dataGridView1.Rows[i].Cells[2].Value = comboBox1.Text;
                            dataGridView1.Rows[i].Cells[3].Value = checkBox1.Checked? "Nam": "Nu";
                            dataGridView1.Rows[i].Cells[4].Value = listBox2.Items.Count;

                            break;
                        }
                    }
                    MessageBox.Show("Cập nhật dữ liệu thành công.");
                }
                else
                {
                    MSSV.Add(textBox1.Text);
                    dataGridView1.Rows.Add(textBox1.Text, textBox2.Text,  comboBox1.Text, checkBox1.Checked? "Nam": "Nu", listBox2.Items.Count);
                    MessageBox.Show("Thêm dữ liệu thành công.");
                }
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = null;
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                for (int i = listBox2.Items.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Add(listBox2.Items[i]);
                    listBox2.Items.RemoveAt(i);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
            }    
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox2.Checked = false;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;
            if (char.IsDigit(e.KeyChar)) 
                return;
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;
            if (char.IsLetter(e.KeyChar))
                return;
            if (e.KeyChar == ' ') 
                return;
            e.Handled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (!dataGridView1.SelectedRows[0].IsNewRow)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    textBox1.Text = Convert.ToString(selectedRow.Cells[0].Value);
                    textBox2.Text = Convert.ToString(selectedRow.Cells[1].Value);
                    comboBox1.Text = Convert.ToString(selectedRow.Cells[2].Value);

                    string gioiTinh = Convert.ToString(selectedRow.Cells[3].Value);
                    if (gioiTinh == "Nam")
                    {
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = true;
                    }
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.Text = string.Empty; 
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                }
            }
        }


    }
}
