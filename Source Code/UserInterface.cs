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
    public partial class UserInterface : Form
    {
        private controller controllerObj;
        private string _id;
        public UserInterface(string id)
        {
            InitializeComponent();
            this._id = id;
            controller controllerObj = new controller();
            DataTable dt = controllerObj.select_title_Playlists(_id);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Title";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            DataTable dt = controllerObj.select_trackstitle_PlayLists(_id, comboBox1.Text);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "TrackTitle";
            listBox2.DataSource = dt;
            listBox2.DisplayMember = "Title";
            listBox2.ValueMember = "ID";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CreateUserPlayist(_id).Show();
            this.Update();
            comboBox1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MusicExplorer(_id).Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            controllerObj = new controller();
            int result = controllerObj.DeletePlaylist(_id, comboBox1.Text);
            if (result > 0)
            {
                MessageBox.Show("Deleted Successfully");
            }
            else
                MessageBox.Show("Can Not Delete");
            comboBox1.Update();
            this.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserInterface(_id).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            int result = controllerObj.DeleteFromPlaylist(_id, comboBox1.Text, (string)listBox2.SelectedValue, listBox1.Text);
            if (result > 0)
            {
                MessageBox.Show("Song Removed Successfully");
            }
            else
                MessageBox.Show("Can Not Remove The Song");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new MusicPlayer(listBox1.Text, (string)listBox2.SelectedValue, _id).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new ChangePassword(_id).Show();
        }
    }
}
