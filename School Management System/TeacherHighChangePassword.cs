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
    public partial class TeacherHighChangePassword : MetroFramework.Forms.MetroForm
    {
        private TeacherHigh aTab;
        private String userID;
        private String passWord;
        public TeacherHighChangePassword(TeacherHigh a, String u)
        {
            aTab = a;
            userID = u;
            InitializeComponent();
        }

        //Confirm Button Click
        private void metroButton1_Click(object sender, EventArgs e)
        {
            DBConnect conn = new DBConnect();
            String query = "SELECT * FROM `prioritytable` WHERE `ID` =  '" + userID + "'";
            MySqlDataReader dr = conn.Select(query);

            while (dr.Read())
            {
                passWord = Convert.ToString(dr["PASSWORD"]);
            }

            conn.CloseConnection();

            if( (metroTextBox1.Text == passWord) && (metroTextBox2.Text == metroTextBox3.Text) )
            {
                query = "UPDATE `prioritytable` SET `Password` = '"+ metroTextBox2.Text +"' WHERE `prioritytable`.`ID` = '"+ userID +"'";
                //MessageBox.Show(userID + passWord);
                conn.Update(query);
                MessageBox.Show("Password Changed Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not change Password, Try Again");
            }
        }

        //Cancel Button Click
        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
