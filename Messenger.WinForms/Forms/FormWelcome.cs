using Messenger;
using Database;
using Messenger.Data;
using Messenger.Services;
using Microsoft.VisualBasic.ApplicationServices;
using Messenger.Interface;
using Microsoft.EntityFrameworkCore;
using User = Messenger.Entities.UserEnity.User;
using Messenger.Entities.UserManagerEntity;
using Messenger.Exceptions.AuthorizationExceptions;

namespace ShkiperWinForms
{
    public partial class FormWelcome : Form, IClient
    {        
        private Authorization authorization { get; set; }
        public User? User { get; set; }
        public FormWelcome()
        {
            authorization = new Authorization(this);
            InitializeComponent();

            textBoxLogin.Validating += textBoxLogin_Validation!;
            textBoxPassword.Validating += textBoxPassword_Validation!;
        }

        private void textBoxLogin_Validation(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxLogin.Text))
            {
                errorProvider1.SetError(textBoxLogin, "Де текст проєбав?");
            }
            else errorProvider1.Clear();
        }

        private void textBoxPassword_Validation(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                errorProvider1.SetError(textBoxPassword, "а пароль?");
            }
            else errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = authorization.Validate(textBoxLogin.Text, textBoxPassword.Text);
                GetFormReady(user);
            }
            catch (AuthorizationNotFoundException)
            {
                MessageBox.Show("Такого користувача не існує");
            }
            catch (AuthorizationWrongPasswordException)
            {
                MessageBox.Show("Невірний пароль. Спробуйте ще раз");
            }
        }

        private void GetFormReady(User user)
        {
            var form = FormReady.GetInstanse((User)user.Clone());
            LockButtons(form);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new FormRegistration(this);
            LockButtons(form);
            form.Show();
        }

        private void LockButtons(Form laucnhingform)
        {
            laucnhingform.FormClosing += (sender, e) => {
                button1.Enabled = true;
                button2.Enabled = true;
                textBoxLogin.Enabled = true;
                textBoxPassword.Enabled = true;
            };
            button1.Enabled = false;
            button2.Enabled = false;
            textBoxLogin.Enabled = false;
            textBoxPassword.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}