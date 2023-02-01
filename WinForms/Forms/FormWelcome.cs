using Messenger;
using Messenger.Models;
using Database;

namespace ShkiperWinForms
{
    public partial class FormWelcome : Form
    {        
        public FormWelcome()
        {
            InitializeComponent();
            textBox1.Validating += textBox1_Validation;
            textBox2.Validating += textBox2_Validation;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validation(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Де текст проєбав?");
            }
            else errorProvider1.Clear();
        }

        private void textBox2_Validation(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "а пароль?");
            }
            else errorProvider1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (var user in db.Users)
                {
                    if (textBox1.Text == user.Login && textBox2.Text == user.Password)
                    {
                        GetFormReady(user);
                        return;
                    }
                }
                MessageBox.Show("Немає такого користувача. Сбробуйте знову, або ж створіть новий аккаунт");
                textBox2.Clear();
            }
        }

        private void GetFormReady(User user)
        {
            var form = FormReady.GetInstanse((User)user.Clone());
            LockButtons(form);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormRegistration();
            LockButtons(form);
            form.Show();
        }

        private void LockButtons(Form laucnhingform)
        {
            laucnhingform.FormClosing += (sender, e) => {
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            };
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } 
    }
}