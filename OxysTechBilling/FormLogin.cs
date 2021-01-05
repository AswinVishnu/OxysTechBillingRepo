using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace GUI_V_2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser1.Text == "Usuario")
            {
                txtuser1.Text = "";
                txtuser1.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser1.Text == "")
            {
                txtuser1.Text = "Usuario";
                txtuser1.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass1.Text == "Contraseña")
            {
                txtpass1.Text = "";
                txtpass1.ForeColor = Color.LightGray;
                txtpass1.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass1.Text == "")
            {
                txtpass1.Text = "Contraseña";
                txtpass1.ForeColor = Color.Silver;
                txtpass1.UseSystemPasswordChar = false;
            }
        }

        #endregion 

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void registerLinkClick(object sender, EventArgs e)
        {
            DisplayForm(new FormRegister());


        }

        private void DisplayForm(object RegisterForm)
        {  
            Form fh = RegisterForm as Form;           
            fh.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Username or Password is empty");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=OxysTechBilling;Integrated Security=True");
               SqlCommand cmd = new SqlCommand("select * from [user] where username='" + txtuser.Text + "' and password ='" + txtpass.Text + "'", con);
                cmd.Parameters.AddWithValue("@username", txtuser.Text);
                cmd.Parameters.AddWithValue("@password", txtpass.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Connection open here   
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dt.Rows.Count > 0)
                {

                    //after successful it will redirect  to next page .  
                    //WelcomePage settingsForm = new WelcomePage();
                    //settingsForm.Show();
                    DashboardForm(new Sidebar());
                }
                else
                {
                    MessageBox.Show("Please enter correct Username and Password");
                }
            }
            
       }
        private void DashboardForm(object DashboardForm)
        {
            Form fh = DashboardForm as Form;
            fh.Show();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
