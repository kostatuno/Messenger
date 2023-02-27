﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;
using Messenger;
using Messenger.Data;
using Messenger.Entities;
using Messenger.Entities.UserEnity;
using Messenger.Interface;
using Messenger.Services;

namespace ShkiperWinForms
{
    public partial class FormRegistration : Form, IService
    {
        private Registration registration { get; set; }
        public IClient Client { get; set; }
        public FormRegistration(IClient client)
        {
            Client = client;
            registration = new Registration(Client);  
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != textBox4.Text)
            {
                MessageBox.Show("Паролі не збігається, єбло ти))");
                MessageBox.Show("У тебе шо рукі з жопи... по кнопкай попади баран");
                textBox2.Clear();
                textBox4.Clear();
                return;
            }

            else if (textBox1.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("Не вистачає параметру якогось. Спробуй знову");
                foreach (var item in Controls)
                {
                    if (item is TextBox obj)
                        obj.Clear();
                }
            }

            else
            {
                registration.CreateAccount(new User(textBox3.Text, textBox1.Text, textBox2.Text));       
                MessageBox.Show("Намана, бистріше залітай в чат любчику");
                this.Close();
            }
            
        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {
            
        }

        public void RunWelcome()
        {
            throw new NotImplementedException();
        }

        public void RunReady()
        {
            throw new NotImplementedException();
        }
    }
}
