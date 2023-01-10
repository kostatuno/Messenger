using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Database;
using ShkiperMessenger;

namespace ShkiperWinForms
{
    public partial class FormReady : Form
    {
        protected static ListBox listBoxOnline;
        protected static List<User> UsersOnline;
        protected User CurrentUser;

        private static FormReady formReady;

        public static FormReady GetInstanse(User user)
        {
            if (formReady == null)
            {
                formReady = new FormReady(user);
                return formReady;
            }
            listBoxOnline.Items.Remove(formReady.CurrentUser);
            formReady.CurrentUser = user;
            listBoxOnline.Items.Add(user.Name);
            UsersOnline.Add(user);
            return formReady;
        }

        static FormReady()
        {
            UsersOnline = new List<User>();
            InitializeStaticComponent();
        }

        private static void InitializeStaticComponent()
        {
            // listBoxOnline
            listBoxOnline = new ListBox();
            listBoxOnline.FormattingEnabled = true;
            listBoxOnline.ItemHeight = 15;
            listBoxOnline.Location = new System.Drawing.Point(12, 58);
            listBoxOnline.Name = "listBox1";
            listBoxOnline.Size = new System.Drawing.Size(167, 139);
            listBoxOnline.TabIndex = 1;
        }

        public FormReady(User currentUser)
        {
            Controls.Add(listBoxOnline);
            CurrentUser = currentUser;
            UsersOnline.Add(currentUser);

            InitializeComponent();

            listBoxOnline.Items.Add(CurrentUser.Name);
          
            FormClosing += fomrReady_FormClosing;
            textBoxMessage.KeyDown += textBox1_KeyEnter;
        }

        private void textBox1_KeyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxChat.Items.Add(new MessageUser(CurrentUser, textBoxMessage.Text, DateTime.Now, StatusMessage.NotRead));
                textBoxMessage.Clear();
            }
        }

        private void fomrReady_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitFromFormReady();
            Hide();
            e.Cancel = true;
        }

        private void ExitFromFormReady()
        {
            listBoxOnline.Items.Remove(CurrentUser.Name);
            UsersOnline.Remove(CurrentUser);
            listBoxChat.Items.Add("");
            listBoxChat.Items.Add($"[{CurrentUser.Name} вишов з чату]");
            listBoxChat.Items.Add("");
        }

        public void Show()
        {
            base.Show();
            listBoxChat.Items.Add($"[{CurrentUser.Name} зашов в чат]");
            listBoxChat.Items.Add("");
        }
    }
}
