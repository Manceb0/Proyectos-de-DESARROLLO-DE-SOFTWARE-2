using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Receptionists : Form
    {
        public Receptionists()
        {
            InitializeComponent();
        }

        //Coneccion a la base de datos
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DelBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(RNameTb.Text == "" || RPassword.Text == "" || RAddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }else
            {
                try
                {
                    Con.Open();
                    /*SqlCommand cmd = new SqlCommand("insert into ReceptionistTbl(RecepId,RecepName,Recepphone,RecepAdd,RecepPass)values(@RN,@RP,@RA,@RPA)", Con);
                    cmd.Parameters.AddWithValue("@RN", RNameTb.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RAddressTb.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Added");*/
                    Con.Close();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
