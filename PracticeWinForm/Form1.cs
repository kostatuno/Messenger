using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Action action = () =>
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        Thread.Sleep(100);
                        progressBar1.Value = i;
                    }
                };

                action();

            })
            {
                IsBackground = true,
            }.Start();

            MessageBox.Show(Thread.CurrentThread.Name = "5");
            MessageBox.Show(Thread.CurrentThread.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
