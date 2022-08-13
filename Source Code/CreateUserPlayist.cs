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
    public partial class CreateUserPlayist : Form
    {
        private controller controllerObj;
        private string _id;
        public CreateUserPlayist(string id)
        {
            InitializeComponent();
            this._id = id;
            controller controllerObj = new controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            string k = textBox1.Text;
            int result = controllerObj.CreatePlaylist(_id, textBox1.Text);
            if (result > 0)
                MessageBox.Show("Inserted Successfully");
            else
                MessageBox.Show("Insertion Failed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
