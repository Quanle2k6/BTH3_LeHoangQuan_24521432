using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai08
{
    public partial class Form1 : Form
    {
        private List<string> SoTaiKhoan = new List<string>();
        public Form1()
        {
            InitializeComponent();
            SoTaiKhoan.Clear();
            textBox5.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                int TongTien = int.Parse(textBox5.Text);
                if (SoTaiKhoan.Contains(textBox1.Text))
                {
                    int index = 0;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[1].Text == textBox1.Text)
                        {
                            index = int.Parse(item.SubItems[0].Text);
                        }
                    }
                    if (index - 1 >= 0)
                    {
                        int TienChenhLech = int.Parse(textBox4.Text) - int.Parse(listView1.Items[index - 1].SubItems[4].Text);
                        listView1.Items[index - 1].SubItems[2].Text = textBox2.Text;
                        listView1.Items[index - 1].SubItems[3].Text = textBox3.Text;
                        listView1.Items[index - 1].SubItems[4].Text = textBox4.Text;
                        textBox5.Text = $"{int.Parse(textBox5.Text) + TienChenhLech}";
                        MessageBox.Show("Cập nhật dữ liệu thành công.");
                    }
                    
                    
                }
                else
                {
                    SoTaiKhoan.Add(textBox1.Text);
                    ListViewItem item = new ListViewItem($"{listView1.Items.Count + 1}");
                    int TienChenhLech = int.Parse(textBox4.Text);
                    item.SubItems.Add(textBox1.Text);
                    item.SubItems.Add(textBox2.Text);
                    item.SubItems.Add(textBox3.Text);
                    item.SubItems.Add(textBox4.Text);
                    listView1.Items.Add(item);
                    textBox5.Text = $"{int.Parse(textBox5.Text) + TienChenhLech}";
                    MessageBox.Show("Thêm mới dữ liệu thành công.");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int TongTien = int.Parse(textBox5.Text);
                if (SoTaiKhoan.Contains(textBox1.Text))
                {
                    DialogResult ketqua = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ketqua != DialogResult.Yes)
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        return;
                    }
                    else
                    {
                        SoTaiKhoan.Remove(textBox1.Text);
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (item.SubItems[1].Text == textBox1.Text)
                            {
                                listView1.Items.Remove(item);
                                textBox5.Text = $"{int.Parse(textBox5.Text) - int.Parse(item.SubItems[4].Text)}";
                                break;
                            }
                        }
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            listView1.Items[i].SubItems[0].Text = $"{i + 1}";
                        }
                        MessageBox.Show("Xóa tài khoản thành công.");
                    }    


                }
                else
                {
                    MessageBox.Show("Số tài khoản không tồn tại");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }
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
            e.Handled |= true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '-')
            {
                if (textBox.SelectionStart == 0 && !textBox2.Text.Contains("-"))
                    return;
                e.Handled = true;
                return;
            }
            e.Handled = true;
        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            ListViewItem selectionItem = listView1.SelectedItems[0];
            if (selectionItem == null) return;
            textBox1.Text = selectionItem.SubItems[1].Text;
            textBox2.Text = selectionItem.SubItems[2].Text;
            textBox3.Text = selectionItem.SubItems[3].Text;
            textBox4.Text = selectionItem.SubItems[4].Text;
        }
    }
}
