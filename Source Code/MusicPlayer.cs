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
    public partial class MusicPlayer : Form
    {
        private controller controllerObj;
        private string _id;
        private string _tracktitle;
        private string _albumid;
        public MusicPlayer(string tracktitle, string albumid, string id)
        {
            InitializeComponent();
            this._tracktitle = tracktitle;
            this._id = id;
            this._albumid = albumid;
            controller controllerObj = new controller();
            DataRow dt = controllerObj.SelectPlayTrack(_tracktitle, _albumid).Rows[0];
            axWindowsMediaPlayer1.URL = (string)dt["audio"];
            track.Text = (string)dt["track"];
            album.Text = (string)dt["album"];
            artist.Text = (string)dt["artist"];
            DataTable dt2 = controllerObj.select_title_Playlists(_id);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Title";
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            if(controllerObj.checkPlalylist_track(_id,comboBox1.Text,_albumid,_tracktitle))
            {
                MessageBox.Show("Song Already Exists");
            }
            else
            {
                int result = controllerObj.AddtoPlaylist(_id, comboBox1.Text, _albumid, _tracktitle);
                if (result > 0)
                {
                    MessageBox.Show("Added Successfully");
                }
                else
                    MessageBox.Show("Can Not Add To Playlist");
            }
        }
    }
}
