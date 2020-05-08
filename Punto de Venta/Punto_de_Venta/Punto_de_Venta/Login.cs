using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Punto_de_Venta
{
    public partial class Login : Form
    {
        SqlConnection con;
        public int userType;
        public int userid;
        public Login()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
            con = new SqlConnection(connectionString);
            try
            {
                con.Close();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos", "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta seguro de salir del sistema?","Salir",MessageBoxButtons.YesNo) ;
            if(dialog == DialogResult.Yes)
                Application.Exit();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUser.Text != "" && txtPassword.Text != "")
                {
                    String consulta = "select * from empleado where usuario ='" + txtUser.Text + "' and contrasenia = '"+txtPassword.Text+"'";
                    SqlCommand sql = new SqlCommand(consulta,con);
                    SqlDataReader dr = null;
                    if (sql.ExecuteScalar()!=null)
                    {
                        dr = sql.ExecuteReader();
                        if (dr.Read())
                        {
                            new Menu().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Error la guardar DataReader");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña Incorrecto", "Datos incorrectos");
                        txtPassword.Clear();
                        txtUser.Clear();
                        txtUser.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("No se han llenados todos los campos", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error:"+ex.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
