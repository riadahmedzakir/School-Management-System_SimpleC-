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
    public partial class TeacherHighAddParent : MetroFramework.Forms.MetroForm
    {
        private TeacherHighAddSelection aTab;
        public TeacherHighAddParent(TeacherHighAddSelection a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            String query1 = "INSERT INTO `parents` (`P_ID`, `F_NAME`, `L_NAME`, `Priority`) VALUES('"+ metroTextBox1.Text +"', '"+ metroTextBox2.Text +"', '"+ metroTextBox3.Text +"','3')";
            String query2 = "INSERT INTO `prioritytable` (`ID`, `Password`, `Priority`) VALUES ('" + metroTextBox1.Text + "', '" + metroTextBox4.Text + "', 3)";

            DBConnect conn = new DBConnect();

            if (metroTextBox1.Text == null || metroTextBox2.Text == null || metroTextBox3.Text == null || metroTextBox4.Text == null)
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
