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
using Messenger;
using Messenger.Data;
using Messenger.Entities.MessageEntity;
using Messenger.Entities.UserEnity;
using Messenger.Interface;
using Messenger.Entities.ChatEntity;
using Microsoft.EntityFrameworkCore;

namespace ShkiperWinForms
{
    public partial class FormReady : Form, IClient
    {
        private FormWelcome formWelcome { get; set; }
        public User? User { get; set; }
        public FormReady(FormWelcome formWelcome)
        {
            this.formWelcome = formWelcome;
            User = formWelcome.User;

            InitializeComponent();

            LoadChats();
        }

        public void LoadChats()
        {
            using var db = new ApplicationDbContext();

            User = db.Users
                .Include(P => P.PersonalChatsFromSelf)
                .Include(g => g.GroupChats)
                .FirstOrDefault(p => p.Login == User!.Login);

            foreach (var personalChat in User?.PersonalChatsFromSelf)
            {
                var button = new Button();
                button.UseVisualStyleBackColor = true;
                button.Width = 108;
                button.Height = 30;
                button.Text = personalChat.SecondUserLogin;
                button.Click += Chat_FirstClick;
                ChatPanel.Controls.Add(button);
            }

            foreach (var groupChat in User?.GroupChats)
            {
                var button = new Button();
                button.UseVisualStyleBackColor = true;
                button.Width = 108;
                button.Height = 30;
                button.Text = groupChat.Name;
                button.Click += Chat_FirstClick;
                ChatPanel.Controls.Add(button);
            }
        }

        private void Chat_FirstClick(object? sender, EventArgs e)
        {
            textBoxMessage.Enabled = true;
            var button = (Button)sender!;
            button.Click -= Chat_FirstClick;
            button.Click += Chat_Click;
        }

        private void Chat_Click(object? sender, EventArgs e)
        {
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            formWelcome.Show();
            base.OnFormClosing(e);
        }

        private void textBox1_KeyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    MessageUser message = new MessageUser((User)User.Clone(), textBoxMessage.Text, MessageStatusEnum.NotRead);
                    listBoxChat.Items.Add(message);
                    //db.Messages.Add(message);
                    db.SaveChanges();
                    textBoxMessage.Clear();
                }
            }
        }

        private void FormReady_Load(object sender, EventArgs e)
        {
            textBoxMessage.Enabled = false;
        }
    }
}
