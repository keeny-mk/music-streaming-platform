using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicService
{
    public enum Privileges
    {
        User = 0,
        artist=1,
        producer = 2
    }
    public partial class Login : Form
    {
        private controller controllerObj;

        public Login()
        {
            InitializeComponent();
            controllerObj = new controller(); // Create the Controler Object

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void log_Click(object sender, EventArgs e)
        {
            int prvg = controllerObj.CheckPassword_Basic(nametxtbox.Text,passtxtbox.Text);
            if (prvg >= 0 && prvg <=2)
            {
                switch (prvg)
                    { 
                case 0:
                        DataRow dt = controllerObj.getuserID(nametxtbox.Text, passtxtbox.Text).Rows[0];
                        string id = (string)dt["ID"];
                        UserInterface UI = new UserInterface(id); UI.Show(this);
                        break;
                case 1:
                        dt = controllerObj.getuserID(nametxtbox.Text, passtxtbox.Text).Rows[0];
                        id = (string)dt["ID"];
                        ArtistInterface AI = new ArtistInterface(id); AI.Show(this);
                        break;
                case 2:
                        dt = controllerObj.getuserID(nametxtbox.Text, passtxtbox.Text).Rows[0];
                        id = (string)dt["ID"];
                        ProducerInterface PI = new ProducerInterface(id);  PI.Show(this);
                        break;
                }
                nametxtbox.Clear();
                passtxtbox.Clear();
                this.Hide();
            }
            else
                MessageBox.Show("Incorrect Password or Username");
        }

        private void register_Click(object sender, EventArgs e)
        {
            new AddNewUser().Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CreateArtist().Show();
        }
    }
}
