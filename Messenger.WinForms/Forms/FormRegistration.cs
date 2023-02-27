using System;
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
using Messenger.Exceptions.RegistrationExceptions;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                registration.CreateAccount(
                    textBoxName.Text,
                    textBoxLogin.Text,
                    textBoxPw.Text,
                    textBoxPwAgain.Text);
            }
            catch (RegistrationPasswordMismatchException)
            {
                MessageBox.Show("Паролі не збігаються. Спробуйте знову");
                textBoxPw.Clear();
                textBoxPwAgain.Clear();
            }
            catch (RegistrationEmptyValuesNameOrLoginException)
            {
                MessageBox.Show("Ваш логін або пароль не корекні");
                foreach (var item in Controls)
                {
                    if (item is TextBox obj)
                        obj.Clear();
                }
            }
        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
