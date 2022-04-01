using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Polka : Form
    {
        
        Book book;
        string filePath;
        List<Image> picts;
        Random rand = new Random();
        public Polka()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            radioButton1.Checked = true;
            pictureBox11.Visible = false;
            picts = new List<Image>() { global::BookShop.Properties.Resources.к1,
                global::BookShop.Properties.Resources.к2,
                global::BookShop.Properties.Resources.к3,
                global::BookShop.Properties.Resources.к4,
                global::BookShop.Properties.Resources.к5,
                global::BookShop.Properties.Resources.к6
            };
        }
        private bool ReadOrDel()
        {
            if (radioButton1.Checked == true) return true;
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = picts[new Random().Next(5)];
            using(OpenFileDialog ofd = new OpenFileDialog()) 
            {
                ofd.Filter = "TEXT|*.txt|ALL|*.*";
                ofd.Title = "Choose";
                if(ofd.ShowDialog() == DialogResult.OK) { filePath = ofd.FileName; }
            }
            pictureBox11.Visible = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book1.txt");
                book.ShowDialog();
            }
            else { pictureBox1.Visible = false; }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book2.txt");
                book.ShowDialog();
            }
            else { pictureBox2.Visible = false; }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book3.txt");
                book.ShowDialog();
            }
            else { pictureBox3.Visible = false; }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book4.txt");
                book.ShowDialog();
            }
            else { pictureBox4.Visible = false; }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book5.txt");
                book.ShowDialog();
            }
            else { pictureBox5.Visible = false; }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book6.txt");
                book.ShowDialog();
            }
            else { pictureBox6.Visible = false; }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book7.txt");
                book.ShowDialog();
            }
            else { pictureBox7.Visible = false; }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book8.txt");
                book.ShowDialog();
            }
            else { pictureBox8.Visible = false; }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book9.txt");
                book.ShowDialog();
            }
            else { pictureBox9.Visible = false; }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(@"Resources\book10.txt");
                book.ShowDialog();
            }
            else { pictureBox10.Visible = false; }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (ReadOrDel())
            {
                book = new Book(filePath,true);
                book.ShowDialog();
            }
            else { pictureBox11.Visible = false; }
        }

    }
}
