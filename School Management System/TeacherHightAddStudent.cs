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
    public partial class TeacherHightAddStudent : MetroFramework.Forms.MetroForm
    {
        private TeacherHighAddSelection aTab;
        public TeacherHightAddStudent(TeacherHighAddSelection a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String query1 = "INSERT INTO `students` (`S_ID`, `F_NAME`, `L_NAME`, `D_ID`, `GPA`, `CLASS`, `Priority`) VALUES('"+ metroTextBox1.Text +"', '"+ metroTextBox2.Text +"', '"+ metroTextBox3.Text +"', '"+ metroTextBox4.Text +"','"+ metroTextBox5.Text +"', '"+ Convert.ToDouble(metroTextBox6.Text) +"', '2')";
            String query2 = "INSERT INTO `prioritytable` (`ID`, `Password`, `Priority`) VALUES ('" + metroTextBox1.Text + "', '" + metroTextBox7.Text + "', 2)";

            DBConnect conn = new DBConnect();

            if (metroTextBox1.Text == null || metroTextBox2.Text == null || metroTextBox3.Text == null || metroTextBox4.Text == null || metroTextBox5.Text == null || metroTextBox6.Text == null || metroTextBox7.Text == null)
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
                catch (Exception ex)
                {
                    MessageBox.Show("User Already Exists");
                }
            }
        }
    }
}
