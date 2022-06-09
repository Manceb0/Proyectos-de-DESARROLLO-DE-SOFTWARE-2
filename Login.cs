using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            RoleCb.SelectedIndex = 0;
            UnameTb.Text = "";
            PassTb.Text = "";
        }

        private void RoleCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuli.YULIMANUEL\Documents\ClinicDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string Role;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione su posicion");

            }else if(RoleCb.SelectedIndex == 0)
            {
                if(UnameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }else if(UnameTb.Text == "Admin" && PassTb.Text == "Password" )
                {
                    
                    Patients Obj = new Patients();
                    Obj.Show();
                    this.Hide();
                }else
                {
                    MessageBox.Show("ADMIN INCORRECTO");
                }

            }else if (RoleCb.SelectedIndex == 1)
            {
                if (UnameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else 
                {
                    Con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from DoctorTbl where DocName='" + UnameTb.Text + "' and Docpass='" + PassTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0].ToString() == "1")
                    {
                        Prescriptions Obj = new Prescriptions();
                        Obj.Show();
                        this.Hide();


                    }else
                    {
                        MessageBox.Show("Doctor no encontrado");

                    }
                    
                    Con.Close();
                }
                

            }
            else
            {
                if (UnameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    Con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from ReceptionistTbl where RecepName='" + UnameTb.Text + "' and RecepPass='" + PassTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Homes Obj = new Homes();
                        Obj.Show();
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Recepcionista no encontrado");

                    }

                    Con.Close();
                }
            }
        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
