using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIILab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SemanticNet sn = new SemanticNet();

        private void Form1_Load(object sender, EventArgs e)
        {


        }

		private void button1_Click(object sender, EventArgs e)
		{
            textBox7.Text = sn.GetLinkedNotions(textBox1.Text, textBox2.Text);
        }

		private void button2_Click(object sender, EventArgs e)
		{
            textBox8.Text = sn.GetRelations(textBox3.Text);
        }

		private void button3_Click(object sender, EventArgs e)
		{
            textBox9.Text = sn.GetNotionsPairs(textBox4.Text);
        }

		private void button4_Click(object sender, EventArgs e)
		{
            textBox10.Text = sn.GetRoad(textBox5.Text, textBox6.Text);
        }

		private void label14_Click(object sender, EventArgs e)
		{

		}
    }
}
