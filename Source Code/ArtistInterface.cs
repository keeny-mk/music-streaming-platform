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
    public partial class ArtistInterface : Form
    {
        private controller controllerObj;
        private string _id;
        public ArtistInterface(string id)
        {
            this._id = id;
            controller controllerObj = new controller();
            InitializeComponent();
            DataTable dt = controllerObj.ListAlbumsArtist(_id);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "Title";
            DataTable dt2 = controllerObj.ListTracksArtist(_id);
            listBox2.DataSource = dt2;
            listBox2.DisplayMember = "Title";
            DataTable dt3 = controllerObj.selectArtistAlbums(_id);
            comboBox1.DataSource = dt3;
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller controllerObj = new controller();
            if (Title.Text == "" || TrackLength.Text == "" || comboBox1.SelectedIndex<1 || TrackPath.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                int x = controllerObj.Insert_Track(Title.Text, TrackLength.Text, (string)comboBox1.SelectedValue, TrackPath.Text);
                if (x > 0)
                {
                    DataTable dt2 = controllerObj.ListTracksArtist(_id);
                    listBox2.DataSource = dt2;
                    listBox2.DisplayMember = "Title";
                    MessageBox.Show("Insertion successful");
                }
                else
                {
                    MessageBox.Show("Insertion failed");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller controllerObj = new controller();
            if (AlbumName.Text == "" || AlbumID2.Text == "")
            {
                MessageBox.Show("Please fill the required fields");
            }
            else
            {
                int x = controllerObj.Insert_Album(AlbumName.Text, AlbumID2.Text, _id);
                if (x > 0)
                {
                    DataTable dt = controllerObj.ListAlbumsArtist(_id);
                    listBox1.DataSource = dt;
                    listBox1.DisplayMember = "Title";
                    MessageBox.Show("Insertion successful");
                }
                else
                {
                    MessageBox.Show("Insertion failed");

                }
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInterface UI = new UserInterface(_id); UI.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Update();
            comboBox1.Update();
            listBox1.Update();
            listBox2.Update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ChangePassword(_id).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }
    }
}
