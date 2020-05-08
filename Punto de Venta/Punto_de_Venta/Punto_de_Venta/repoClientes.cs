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
    public partial class repoClientes : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string consulta;
        public repoClientes()
        {
            InitializeComponent();
        }

        private void repoClientes_Load(object sender, EventArgs e)
        {
            con = new Conexion().crearConexion();
            try
            {
                con.Open();
                consulta = ("select nombre, direccion, telefono from cliente");
                cmd = new SqlCommand(consulta, con);
                dr = cmd.ExecuteReader();
                List<reporteClientes> lrc = new List<reporteClientes>();
                while (dr.Read())
                {
                    reporteClientes rc = new reporteClientes();
                    rc.nombre = dr[0].ToString();
                    rc.direccion = dr[1].ToString();
                    rc.telefono = dr[2].ToString();
                    lrc.Add(rc);
                    rc = null;
                }
                dr.Close();
                reporteClientesBindingSource.DataSource = lrc;
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
