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
        //string fPath;
        public Book()
        {
            InitializeComponent();
            synth = new SpeechSynthesizer();
            //textBox1.Text = File.ReadAllText(@"global::Library\Properties\Resources\book2.txt");
            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakCompleted += Synth_SpeakCompleted;
        }
        public Book(string str, bool b = false)
        {
            InitializeComponent();
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakCompleted += Synth_SpeakCompleted;
            if (b) { textBox1.Text = File.ReadAllText(str); }
            //else { textBox1.Text = File.ReadAllText(FullPath(str)); }
            else
            { 
                string[] lns = File.ReadAllLines(FullPath(str));
                for(int i = 0; i < 10 ; i++)
                {
                    textBox1.Text += lns[i];
                }
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
            //textBox1.Text = File.ReadAllText(@"global::Library.Properties.Resources.1111111");
            if (!textBox1.Text.Equals(String.Empty)) { synth.SpeakAsync(textBox1.Text); }
            if (!textBox2.Text.Equals(String.Empty)) { synth.SpeakAsync(textBox2.Text); }
        }
    }
}
