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
    public partial class TeacherHighAddTeacher : MetroFramework.Forms.MetroForm
    {
        private TeacherHighAddSelection aTab;
        public TeacherHighAddTeacher(TeacherHighAddSelection a)
        {
            aTab = a;
            InitializeComponent();
        }

        //Confirm Buttton
        private void metroButton1_Click(object sender, EventArgs e)
        {
            String query1 = "INSERT INTO `teachers` (`T_ID`, `F_NAME`, `L_NAME`, `teachers`.`D_ID`, `POSITION`, `Priority`) VALUES ('"+ metroTextBox1.Text +"', '"+ metroTextBox2.Text +"', '"+ metroTextBox3.Text +"', '"+ Convert.ToInt32(metroTextBox4.Text) +"', '"+ metroTextBox6.Text +"', '1')";
            String query2 = "INSERT INTO `prioritytable` (`ID`, `Password`, `Priority`) VALUES ('"+ metroTextBox1.Text +"', '"+ metroTextBox5.Text +"', 1)";

            DBConnect conn = new DBConnect();

            if (metroTextBox1.Text == null || metroTextBox2.Text == null || metroTextBox3.Text == null || metroTextBox4.Text == null || metroTextBox5.Text == null || metroTextBox6.Text == null)
            {
                MessageBox.Show("Fill in all Form and try again");
            }
            else
            {
                try
                {
                    conn.Insert(query1);
                    conn.CloseConnection();
                    conn.Insert(query2);

                    MessageBox.Show("User Registration Successful");
                    this.Close();
                    aTab.Show();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("User Already Exists");
                }
            }
        }

        //Exit Button
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }
    }
}
