using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _7._1
{
    public partial class Form1 : Form
    {
       static  int n = 4;
       static float averagewating, averagearound;
        int[] processes = { 1, 2, 3, 4 };
        int[] burst = new int[n];
        int[] wt = new int[n];
        int[] tat = new int[n];
        string[] s = new string[n];
        List<string> sorrt = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> l = new List<int>();
            l.Add(Convert.ToInt32(textBox1.Text));
            l.Add(Convert.ToInt32(textBox2.Text));
            l.Add(Convert.ToInt32(textBox3.Text));
            l.Add(Convert.ToInt32(textBox4.Text));
            l.Sort();

            checkedListBox1.Items.Add(l[0]);
            checkedListBox1.Items.Add(l[1]);
            checkedListBox1.Items.Add(l[2]);
            checkedListBox1.Items.Add(l[3]);

            /*checkedListBox1.Items.Add(textBox1.Text);
            checkedListBox1.Items.Add(textBox2.Text);
            checkedListBox1.Items.Add(textBox3.Text);
            checkedListBox1.Items.Add(textBox4.Text);*/

            burst[0] = l[0];
            burst[1] = l[1];
            burst[2] = l[2];
            burst[3] = l[3];

            sortt();

            /*burst[0] = Convert.ToInt32( textBox1.Text);
            burst[1] = Convert.ToInt32(textBox2.Text);
            burst[2] = Convert.ToInt32(textBox3.Text);
            burst[3] = Convert.ToInt32(textBox4.Text);*/
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32( checkedListBox1.Items[0]+"000");

            
            if (checkedListBox1.Items[0].ToString() == textBox1.Text)
            {
                textBox5.Text = "p1";
                sorrt.Add(textBox5.Text);
            }
            else if (checkedListBox1.Items[0].ToString() == textBox2.Text)
            {
                timer1.Interval = Convert.ToInt32(checkedListBox1.Items[0] + "000");
                textBox5.Text = "p2";
                sorrt.Add(textBox5.Text);
            }
            else if (checkedListBox1.Items[0].ToString() == textBox3.Text)
            {
                timer1.Interval = Convert.ToInt32(checkedListBox1.Items[0] + "000");
                textBox5.Text = "p3";
                sorrt.Add(textBox5.Text);
            }
            else if (checkedListBox1.Items[0].ToString() == textBox4.Text)
            {
                timer1.Interval = Convert.ToInt32(checkedListBox1.Items[0] + "000");
                textBox5.Text = "p4";
                sorrt.Add(textBox5.Text);
            }

            checkedListBox1.Items.RemoveAt(0);

            
            if (checkedListBox1.Items.Count <= 0)
            {
                timer1.Stop();
                //sortt();
                findav();
                MessageBox.Show("average waiting time is"+averagewating+"\n and average aroundtime is"+averagearound);
           
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;


            listView1.Columns.Add("processes", 70);
            listView1.Columns.Add("burst", 70);
            listView1.Columns.Add("waiting", 70);
            listView1.Columns.Add("around", 70);

        }
        void findav()
        {
           
            findwt(wt);
            findtat(tat, wt);
            int totalwt = 0;
            int totaltat=0;
            for(int i = 0; i < n; i++)
            {
                totalwt += wt[i];
                totaltat += tat[i];
                //sortt();
                string[] roww = { sorrt[i].ToString(), burst[i].ToString(), wt[i].ToString(), tat[i].ToString() };
                var listitems = new ListViewItem(roww);
                listView1.Items.Add(listitems);
            }
            averagearound = totaltat / n;
            averagewating = totalwt / n;

            


        }
       
        void findwt(int [] wt)
        {
            wt[0] = 0;
            for(int i = 1; i < n; i++)
            {
                wt[i] = burst[i - 1] + wt[i - 1];
            }
        }

        void findtat(int[] tat,int [] wt)
        {
            for (int i = 0; i < n; i++)
            {
                tat[i] = burst[i] + wt[i];
            }
        }


        void sortt()
       {
            for (int i = 0; i < n; i++)
            {
                if (burst[i] == Convert.ToInt32(textBox1.Text))
                {
                    s[i] = "p1";
                }
                else if (burst[i] == Convert.ToInt32(textBox2.Text))
                {
                    s[i] = "p2";
                }
                else if (burst[i] == Convert.ToInt32(textBox3.Text))
                {
                    s[i] = "p3";
                }
                else if (burst[i] == Convert.ToInt32(textBox4.Text))
                {
                    s[i] = "p4";
                }

            }
        }

    }
}
