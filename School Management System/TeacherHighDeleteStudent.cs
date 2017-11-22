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
    public partial class TeacherHighDeleteStudent : MetroFramework.Forms.MetroForm
    {
        public TeacherHighDeleteStudent()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String query1 = "DELETE FROM `students` WHERE `students`.`S_ID` = '" + metroTextBox1.Text + "'";
            String query2 = "DELETE FROM `prioritytable` WHERE `prioritytable`.`ID` = '" + metroTextBox1.Text + "'";

            DBConnect conn = new DBConnect();
            if (metroTextBox1.Text == null)
            {
                MessageBox.Show("Delete Fail");
            }
            else
            {
                try
                {
                    conn.Update(query1);
                    conn.CloseConnection();
                    conn.Update(query2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
                MessageBox.Show("Delete Successful");
                this.Close();
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
