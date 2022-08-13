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
    public partial class ProducerInterface : Form
    {
        private controller controllerObj;
        private string _id;
        public ProducerInterface(string id)
        {
            InitializeComponent();
            controller controllerObj = new controller();
            this._id = id;
            DataTable dt = controllerObj.SelectArtists();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller controllerObj = new controller();

            if (comboBox1.SelectedIndex<1)
            {
                MessageBox.Show("Please fill the required fields.");
            }
            else
            {
                string time = hour.Value.ToString() +":"+ minute.Value.ToString();
                int result = controllerObj.insert_concert((double)price.Value, dateTimePicker1.Value, time,(string) comboBox1.SelectedValue, _id);
                if (result > 0)
                {
                    MessageBox.Show("Success");
                }
                else MessageBox.Show("Fail! Try Again.");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ChangePassword(_id).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Statistics().Show();
        }
    }
}
