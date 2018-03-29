using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mechta_Oboishika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double wallheight = 0;
        double wallwidth_1 = 0;
        double wallwidth_2 = 0;
        double rollwidth = 0;
        double rolllength = 0;
        double drowingstep = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             wallheight = double.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
             wallwidth_1 = double.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
             wallwidth_2 = double.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            rollwidth = double.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
             rolllength = double.Parse(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
             drowingstep = double.Parse(textBox6.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sells = Math.Ceiling((2 * (wallwidth_1 + wallwidth_2) / rollwidth));                                                 //количество полос
            double scraps = wallheight % drowingstep;                                                                                   // длинна обрезка
            double sellsroll = rolllength / (wallheight + scraps);                                                                      // колличество полос из 1 рулона
            double needrolls = Math.Ceiling(sells / (int)sellsroll);                                                                    // общее количество рулонов
            double tscrapslength = (sells * scraps) + ((rolllength - ((wallheight + scraps) + sellsroll)) * needrolls);              // общая длинна обрезков
            double scrapsall = sells + needrolls;                                                                                       // колличество обрезков в шт.
            double scrapstoquantity = (100 * tscrapslength) / (needrolls * rolllength);                                                 // %
            textBox7.Text = needrolls.ToString();
            textBox8.Text = scrapsall.ToString();
            textBox9.Text = tscrapslength.ToString();
            textBox10.Text = scrapstoquantity.ToString();
        }
    }
}
