using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicService
{
    public partial class AddNewUser : Form
    {
        controller controllerObj;
        public AddNewUser()
        {
            InitializeComponent();
            controllerObj = new controller();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void signuptxtbox_Click(object sender, EventArgs e)
        {
            if(nametxtbox.Text==""||idtxtbox.Text==""||passtxtbox.Text=="")
            {
                MessageBox.Show("Fill the Required Fields");

            }

            else if (controllerObj.checkuserID(idtxtbox.Text) )
            {
                MessageBox.Show("ID Already Taken");

            }
            else
            {
                string gender = "U";
                if (male.Checked) gender = "M";
                if (female.Checked) gender = "F";
                if (alien.Checked) gender = "A";
                int result = controllerObj.Insert_User(idtxtbox.Text, passtxtbox.Text,
                    nametxtbox.Text, (int)phonenumber.Value, (int)agenumber.Value, gender);
                if (result > 0)
                    MessageBox.Show("Register Success");
                else
                    MessageBox.Show("Register Failed");
            }
        }

        private void closetxtbox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
