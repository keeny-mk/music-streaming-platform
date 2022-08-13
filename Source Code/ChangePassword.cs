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
    public partial class ChangePassword : Form
    {
        private string _id;
        private controller controllerObj;
        public ChangePassword(string id)
        {
            InitializeComponent();
            this._id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            if (old.Text==""||new1.Text==""||new2.Text=="")
            {
                MessageBox.Show("Fill the required fields");
            }
            else if (new1.Text!=new2.Text)
            {
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                int result = controllerObj.updatepassword(new1.Text, _id, old.Text);
                if (result>0)
                {
                    MessageBox.Show("Changed Successfully");
                }
                else
                {
                    MessageBox.Show("The password you entered is incorrect!");
                }
                   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
