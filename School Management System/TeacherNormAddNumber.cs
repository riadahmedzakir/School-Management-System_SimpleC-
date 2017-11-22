using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_System
{
    public partial class TeacherNormAddNumber : MetroFramework.Forms.MetroForm
    {
        public TeacherNormAddNumber()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DBConnect conn = new DBConnect();

            String query = "UPDATE `acce01_result` SET `MARKS` = '" + metroTextBox2.Text + "' WHERE `acce01_result`.`S_ID` = '" + metroTextBox1.Text + "'";
            conn.Update(query);

            MessageBox.Show("Marks Updated");
            this.Close();
        }
    }
}
