namespace Shkiper
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            users = new Users();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            users.AddFromLog("LogUsers.txt");
            bool answer = false;
            foreach (var user in users.List)
            {
                if (textBox1.Text == user.Login && textBox2.Text == user.Password)
                {
                    new Form().Show();
                    return;
                }
            }
            if (!answer)
            {
                MessageBox.Show("Немає такого користувача. Сбробуйте знову, або ж створіть новий аккаунт");
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormRegistration().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}