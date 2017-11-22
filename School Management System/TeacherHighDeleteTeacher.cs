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
    public partial class TeacherHighDeleteTeacher : MetroFramework.Forms.MetroForm
    {
        public TeacherHighDeleteTeacher()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            String query1 = "DELETE FROM `teachers` WHERE `teachers`.`T_ID` = '"+ metroTextBox1.Text +"'";
            String query2 = "DELETE FROM `prioritytable` WHERE `prioritytable`.`ID` = '"+ metroTextBox1.Text +"'";

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
    }
}
