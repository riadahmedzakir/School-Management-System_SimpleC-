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
    public partial class LoginPage : MetroFramework.Forms.MetroForm
    {
        private String UserName;
        private String Password;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
             //UserName = metroTextBox1.Text;
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            //Password = metroTextBox2.Text;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect conn = new DBConnect();

                String query = "SELECT * FROM `prioritytable` WHERE `ID` = '" + metroTextBox1.Text + "' AND `Password` = '" + metroTextBox2.Text + "'";               
                MySqlDataReader dr = conn.Select(query);
                int priority = -1;             

                while (dr.Read())
                {
                    UserName = Convert.ToString(dr["ID"]);
                    Password = Convert.ToString(dr["Password"]);
                    priority = Convert.ToInt32(dr["Priority"]);
                }

                if (UserName == metroTextBox1.Text && Password == metroTextBox2.Text)
                {
                    switch (priority)
                    {
                        case 0:
                            TeacherHigh aTeacher = new TeacherHigh(UserName);
                            this.Hide();
                            aTeacher.Show();
                            break;
                        case 1:
                            TeacherNorm bTeacher = new TeacherNorm(UserName);
                            this.Hide();
                            bTeacher.Show();
                            break;
                        case 2:
                            Student aStudent = new Student(UserName);
                            this.Hide();
                            aStudent.Show();
                            break;
                        case 3:
                            Parent aParent = new Parent(UserName);
                            this.Hide();
                            aParent.Show();
                            break;
                    }
                    //MessageBox.Show("Correct");
                }
                else
                {
                    MessageBox.Show("Incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
