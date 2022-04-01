using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        int m, s, h;

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            m = 0;
            s = 0;
            h = 0;

            label1.Text = "00";
            label2.Text = "00";
            label5.Text = "00";

            label3.Visible = true;
            label4.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s < 59)
            {
                s++;
                if (s < 10)
                {
                    label2.Text = "0" + s.ToString();
                }
                else
                {
                    label2.Text = s.ToString();
                }
            }
            else
            {
                if (m < 59)
                {
                    m++;
                    if (m < 10)
                    {
                        label1.Text = "0" + m.ToString();
                    }
                    else
                    {
                        label1.Text = m.ToString();
                    }

                    s = 0;
                    label2.Text = "00";
                }
                else
                {
                    if (h < 23)
                    {
                        h++;
                        if (h < 10)
                        {
                            label5.Text = "0" + h.ToString();
                        }
                        else
                        {
                            label5.Text = h.ToString();
                        }

                        m = 0;
                        label1.Text = "00";
                    }
                    else
                    {
                        timer1.Enabled = false;

                        m = 0;
                        s = 0;
                        h = 0;

                        label1.Text = "00";
                        label2.Text = "00";
                        label5.Text = "00";
                    }
                }
            }
        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "Стоп";
            button2.Enabled = false;

            timer1.Enabled = true;

            if (m > 10)
            {
                timer1.Enabled = false;
                button1.Text = "Старт";
                button2.Enabled = true;
                MessageBox.Show("10 минут прошло!");
            }
            else
            {
                MessageBox.Show("123о!");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle= "Timer";
            notifyIcon1.BalloonTipText = "Timer";
            notifyIcon1.Text = "Timer";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;

                button1.Text = "Старт";
                button2.Enabled = true;
            }
            else 
            {
                timer1.Enabled = true;
                button1.Text = "Стоп";
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = 0;
            s = 0;
            h = 0;

            label1.Text = "00";
            label2.Text = "00";
            label5.Text = "00";
        }
    }
}
