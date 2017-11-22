using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace School_Management_System
{
    public partial class TeacherNormUpdateGPA : MetroFramework.Forms.MetroForm
    {
        public TeacherNormUpdateGPA()
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

            String query = "UPDATE `students` SET `GPA` = '" + metroTextBox2.Text + "' WHERE `students`.`S_ID` = '" + metroTextBox1.Text + "'";
            conn.Update(query);

            MessageBox.Show("GPA updated Successfully");
            this.Close();
        }
    }
}
