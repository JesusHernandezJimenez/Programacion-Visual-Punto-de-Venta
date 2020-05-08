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
    public partial class repoProveedores : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string consulta;
        public repoProveedores()
        {
            InitializeComponent();
        }

        private void repoProveedores_Load(object sender, EventArgs e)
        {
            con = new Conexion().crearConexion();
            try
            {
                con.Open();
                consulta = ("select nombrepro, direccion, rfc, telefono from proveedor");
                cmd = new SqlCommand(consulta, con);
                dr = cmd.ExecuteReader();
                List<reporteProveedores> lrp = new List<reporteProveedores>();
                while (dr.Read())
                {
                    reporteProveedores rp = new reporteProveedores();
                    rp.nombre = dr[0].ToString();
                    rp.direccion = dr[1].ToString();
                    rp.rfc = dr[2].ToString();
                    rp.telefono = dr[3].ToString();
                    lrp.Add(rp);
                    rp = null;
                }
                dr.Close();
                reporteProveedoresBindingSource.DataSource = lrp;
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
