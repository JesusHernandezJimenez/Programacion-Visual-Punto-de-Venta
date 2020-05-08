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

namespace Punto_de_Venta
{
    
    public partial class repoUsuarios : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string consulta;

        public repoUsuarios()
        {
            InitializeComponent();
        }

        private void repoUsuarios_Load(object sender, EventArgs e)
        {
            con = new Conexion().crearConexion();
            try
            {
                con.Open();
                consulta = ("select usuario, contrasenia, nombre, telefono, cargo, sexo from empleado;");
                cmd = new SqlCommand(consulta, con);
                dr = cmd.ExecuteReader();
                List<reporteUsuarios> lru = new List<reporteUsuarios>();
                while (dr.Read())
                {
                    reporteUsuarios ru = new reporteUsuarios();
                    ru.usuario = dr[0].ToString();
                    ru.contraseña = dr[1].ToString();
                    ru.nombre = dr[2].ToString();
                    ru.telefono = dr[3].ToString();
                    ru.cargo = dr[4].ToString();
                    ru.sexo = dr[5].ToString();
                    lru.Add(ru);
                    ru = null;
                }
                dr.Close();
                reporteUsuariosBindingSource.DataSource = lru;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }
    }
}
