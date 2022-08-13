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
    public partial class CreateArtist : Form
    {
        controller controllerObj;
        public CreateArtist()
        {
            InitializeComponent();
            controllerObj = new controller();
            DataTable dt = controllerObj.Select_Genres();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            secondname.Enabled = false;
            secondage.Enabled = false;
            secondmale.Enabled = false;
            secondfemale.Enabled = false;
            thirdname.Enabled = false;
            thirdage.Enabled = false;
            thirdmale.Enabled = false;
            thirdfemale.Enabled = false;

        }

        private void CreateArtist_Load(object sender, EventArgs e)
        {

        }

        private void signuptxtbox_Click(object sender, EventArgs e)
        {
            if (nametxtbox.Text == "" || idtxtbox.Text == "" || passtxtbox.Text == "")
            {
                MessageBox.Show("Fill the Required Fields");

            }

            else if (controllerObj.checkuserID(idtxtbox.Text))
            {
                MessageBox.Show("ID Already Taken");

            }
            else
            {
               int result= controllerObj.Insert_User_Artist(idtxtbox.Text, passtxtbox.Text, nametxtbox.Text, (int)phone.Value);
                result += controllerObj.Insert_Artist(nametxtbox.Text, idtxtbox.Text);
                result += controllerObj.insertArtist_Genre(idtxtbox.Text, comboBox1.Text);

                if (firstfemale.Enabled == true && secondmale.Enabled == false && thirdname.Enabled == false)
                {
                    if (firstname.Text == "")
                    {
                        MessageBox.Show("Fill The Member(s) Fields");
                    }
                    else
                    {
                        string firstgender = "U";
                        if (firstmale.Checked) firstgender = "M";
                        if (firstfemale.Checked) firstgender = "F";
                        result += controllerObj.Insert_Musician(firstname.Text, firstgender, (int)firstage.Value, idtxtbox.Text);
                        if (result > 3)
                            MessageBox.Show("Register Success");
                        else
                            MessageBox.Show("Register Failed");
                    }
                }
                else if (firstfemale.Enabled == true && secondmale.Enabled == true && thirdname.Enabled == false)
                {
                    if (firstname.Text == "" || secondname.Text == "")
                    {
                        MessageBox.Show("Fill The Member(s) Fields");
                    }
                    else
                    {
                        string firstgender = "U"; string secondgender = "U";
                        if (firstmale.Checked) firstgender = "M";
                        if (firstfemale.Checked) firstgender = "F";
                        if (secondmale.Checked) secondgender = "M";
                        if (secondfemale.Checked) secondgender = "F";
                        result += controllerObj.Insert_Musician(firstname.Text, firstgender, (int)firstage.Value, idtxtbox.Text);
                        result += controllerObj.Insert_Musician(secondname.Text, secondgender, (int)secondage.Value, idtxtbox.Text);
                        if (result > 4)
                            MessageBox.Show("Register Success");
                        else
                            MessageBox.Show("Register Failed");
                    }
                 }
                else if(firstfemale.Enabled == true && secondmale.Enabled == true && thirdname.Enabled == true)
                {
                    if (firstname.Text == "" || secondname.Text == "" || thirdname.Text == "")
                    {
                        MessageBox.Show("Fill The Member(s) Fields");
                    }
                    else
                    {
                        string firstgender = "U"; string secondgender = "U"; string thirdgender = "U";
                        if (firstmale.Checked) firstgender = "M";
                        if (firstfemale.Checked) firstgender = "F";
                        if (secondmale.Checked) secondgender = "M";
                        if (secondfemale.Checked) secondgender = "F";
                        if (thirdmale.Checked) thirdgender = "M";
                        if (thirdfemale.Checked) thirdgender = "F";
                        result += controllerObj.Insert_Musician(firstname.Text, firstgender, (int)firstage.Value, idtxtbox.Text);
                        result += controllerObj.Insert_Musician(secondname.Text, secondgender, (int)secondage.Value, idtxtbox.Text);
                        result += controllerObj.Insert_Musician(thirdage.Text, thirdgender, (int)thirdage.Value, idtxtbox.Text);
                        if (result > 5)
                            MessageBox.Show("Register Success");
                        else
                            MessageBox.Show("Register Failed");
                    }
                }    
            }
        }

        private void number_ValueChanged(object sender, EventArgs e)
        {
            if(number.Value==1)
            {
                firstage.Enabled = true;
                firstname.Enabled = true;
                firstmale.Enabled = true;
                firstfemale.Enabled = true;
                secondname.Enabled = false;
                secondage.Enabled = false;
                secondmale.Enabled = false;
                secondfemale.Enabled = false;
                thirdname.Enabled = false;
                thirdage.Enabled = false;
                thirdmale.Enabled = false;
                thirdfemale.Enabled = false;
            }
            if (number.Value==2)
            {
                firstage.Enabled = true;
                firstname.Enabled = true;
                firstmale.Enabled = true;
                firstfemale.Enabled = true;
                secondname.Enabled = true;
                secondage.Enabled = true;
                secondmale.Enabled = true;
                secondfemale.Enabled = true;
                thirdname.Enabled = false;
                thirdage.Enabled = false;
                thirdmale.Enabled = false;
                thirdfemale.Enabled = false;
            }
            if(number.Value==3)
            {
                firstage.Enabled = true;
                firstname.Enabled = true;
                firstmale.Enabled = true;
                firstfemale.Enabled = true;
                secondname.Enabled = true;
                secondage.Enabled = true;
                secondmale.Enabled = true;
                secondfemale.Enabled = true;
                thirdname.Enabled = true;
                thirdage.Enabled = true;
                thirdmale.Enabled = true;
                thirdfemale.Enabled = true;
            }
        }
    }
}
