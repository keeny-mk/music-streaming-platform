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
    public partial class MusicExplorer : Form
    {
        private controller controllerObj;
        private string _id;
        public MusicExplorer(string id)
        {
            InitializeComponent();
            this._id = id;
            controller controllerObj = new controller();
            DataTable dt = controllerObj.Select_Tracks_Artists_Albums();
            DataTable dt1= controllerObj.SelectArtists();
            DataTable dt2 = controllerObj.SelectAlbums();
            listBox1.DataSource = dt;
            checkedListBox1.DataSource = dt1;
            checkedListBox2.DataSource = dt2;
            listBox1.DisplayMember = "track";
            listBox1.ValueMember = "albumid";
            checkedListBox1.DisplayMember = "name";
            checkedListBox2.DisplayMember = "title";
            /*
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            checkedListBox1.Items.Add(dt.Rows[i]["artist"].ToString());
            checkedListBox2.Items.Add(dt.Rows[i]["album"].ToString());
        }
        */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            List<string> artists = new List<string>();
            List<string> albums = new List<string>();
            foreach (DataRowView s in checkedListBox1.CheckedItems) 
                artists.Add((string) s.Row["ID"]);
            foreach (DataRowView s in checkedListBox2.CheckedItems)
                albums.Add((string)s.Row["id"]);
            DataTable dt = controllerObj.SelectTracksby_Artists_Albums(artists, albums);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "Track";
            listBox1.Update();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            new MusicPlayer(listBox1.Text, (string)listBox1.SelectedValue,_id).Show();
        }

        private void playbtn_Click(object sender, EventArgs e)
        {
            controllerObj = new controller();
            new MusicPlayer(listBox1.Text, (string)listBox1.SelectedValue,_id).Show();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
