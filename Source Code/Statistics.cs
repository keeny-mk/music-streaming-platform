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
    public partial class Statistics : Form
    {
        private controller controllerObj;
        public Statistics()
        {
            InitializeComponent();
            controller controllerObj = new controller();
            DataTable dt = controllerObj.genrestats();
            DataTable dt1 = controllerObj.artiststats();
            DataTable dt2 = controllerObj.artiststats2();
            //dt.Columns.Add(dt2.Columns[1]);
         //   dt.Merge(dt2);
           // dt.AcceptChanges();
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt1;
            dataGridView3.DataSource = dt2;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
