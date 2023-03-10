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
                errorProvider1.SetError(textBoxLogin, "?? ????? ????????");
            }
            else errorProvider1.Clear();
        }

        private void textBoxPassword_Validation(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                errorProvider1.SetError(textBoxPassword, "? ???????");
            }
            else errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = authorization.Validate(textBoxLogin.Text, textBoxPassword.Text);
                User = user;
                Hide();
                var form = new FormReady(this);
                form.Show();
            }
            catch (AuthorizationNotFoundException)
            {
                MessageBox.Show("?????? ??????????? ?? ?????");
            }
            catch (AuthorizationWrongPasswordException)
            {
                MessageBox.Show("???????? ??????. ????????? ?? ???");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new FormRegistration(this);
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}