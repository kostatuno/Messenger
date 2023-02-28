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
using Microsoft.EntityFrameworkCore;

namespace ShkiperWinForms
{
    public partial class FormRegistration : Form, IService
    {
        private FormWelcome formWelcome { get; set; }
        private Registration registration { get; set; }
        public IClient Client { get; set; }
        
        public FormRegistration(FormWelcome formWelcome)
        {
            this.formWelcome = formWelcome;
            registration = new Registration(formWelcome);  
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            formWelcome.Show();
            base.OnFormClosing(e);
        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {
            
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
                MessageBox.Show("Добре. Заходь");
                Close();
            }
            catch (RegistrationPasswordMismatchException)
            {
                MessageBox.Show("Паролі не збігаються. Спробуйте знову");
            }
            catch (RegistrationEmptyValuesNameOrLoginException)
            {
                MessageBox.Show("Ваш логін або нік не корекні");
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Вже є такий логін. Змініть на інший");
            }
            finally
            {
                textBoxPw.Clear();
                textBoxPwAgain.Clear();
            }
        }
    }
}
