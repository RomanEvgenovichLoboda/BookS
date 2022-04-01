using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
namespace Library
{
    public partial class Book : Form
    {
        static SpeechSynthesizer synth;
        public int page = 0;
        public List<string> lns = new List<string>();
        public Book()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakCompleted += Synth_SpeakCompleted;
        }
        public Book(string str, bool b = false)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.textBox1.ReadOnly = true;
            
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakCompleted += Synth_SpeakCompleted;
            if (b) { textBox1.Text = File.ReadAllText(str); }
            else
            {
                int count = 0;
                string temp = "";
                foreach (string item in File.ReadLines(FullPath(str)))
                {
                    count++;
                    temp += item;
                    if (count == 20)
                    {
                        lns.Add(temp);
                        count = 0;
                        temp = "";
                    }
                }
                textBox1.Text = lns[page].ToString();
                label1.Text = Convert.ToString(page + 1);
                textBox2.Text = lns[page++].ToString();
                label2.Text = Convert.ToString(page + 1);
            }
        }
        private static string FullPath(string str)
        { 
            string workDir = Environment.CurrentDirectory;
            string projDir = Directory.GetParent(workDir).Parent.FullName;
            return Path.Combine(projDir, str);
        }
        private void Synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            MessageBox.Show("Speech end", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(String.Empty)) { synth.SpeakAsync(textBox1.Text); }
            if (!textBox2.Text.Equals(String.Empty)) { synth.SpeakAsync(textBox2.Text); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (page < lns.Count - 1) {
                textBox1.Text = lns[page++];
                label1.Text = Convert.ToString(page + 1);
            }
            if(page < lns.Count - 1) {
                textBox2.Text = lns[page++];
                label2.Text = Convert.ToString(page + 1);
            }
            else { MessageBox.Show("End"); }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            if (page > 0)  { textBox2.Text = lns[page--];
                label2.Text = Convert.ToString(page + 1);}
            if (page > 0) {textBox1.Text = lns[page--]; 
                label1.Text = Convert.ToString(page + 1); }
            else { MessageBox.Show("End"); }
        }
    }
}
