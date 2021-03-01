using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production_line_simulator
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            User user1 = new User("admin", "admin");
            User user2 = new User("supervisor", "123");
            login_textBox.Text = "";
            password_textBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(User user in User.usersList)
            {
                if(login_textBox.Text == user.login && password_textBox.Text == user.password)
                {
                    label4.Visible = false;
                    production = new Production(this);
                    production.Show();
                    this.Visible = this.Enabled = false;
                }
                else if(login_textBox.Text == "" || password_textBox.Text == "")
                {
                    label4.Text = "Please complete all fields";
                    label4.Visible = true;
                }
                else
                {
                    label4.Text = "Incorrect login and/or password!";
                    label4.Visible = true;
                }
            }
        }
    }

    public class User
    {
        public string login;
        public string password;

        static public List<User> usersList = new List<User>();

        public User(string log, string pass)
        {
            this.login = log;
            this.password = pass;
            usersList.Add(this);
        }
    }
}
