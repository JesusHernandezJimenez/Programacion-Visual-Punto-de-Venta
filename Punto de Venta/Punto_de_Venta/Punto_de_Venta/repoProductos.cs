using Microsoft.Reporting.WinForms;
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
using System.Windows.Forms.VisualStyles;

namespace Punto_de_Venta
{
    public partial class repoProductos : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string consulta;
        public repoProductos()
        {
            InitializeComponent();
        }

        private void repoProductos_Load(object sender, EventArgs e)
        {
            con = new Conexion().crearConexion();
            try
            {
                con.Open();
                consulta= ("select nombre, marca, descripcion, precio, costo , minimo, stok, nombrepro  from productos, proveedor where proveedor.idproveedor = productos.idproveedorpro");
                cmd = new SqlCommand(consulta, con);
                dr = cmd.ExecuteReader();
                List<reporteProductos> lrp = new List<reporteProductos>();
                while (dr.Read())
                {
                    reporteProductos rp = new reporteProductos();
                    rp.nombre = dr[0].ToString();
                    rp.marca = dr[1].ToString();
                    rp.descripcion = dr[2].ToString();
                    rp.precio = float.Parse(dr[3].ToString());
                    rp.costo = float.Parse(dr[4].ToString());
                    rp.minimo = int.Parse(dr[5].ToString());
                    rp.stok = int.Parse(dr[6].ToString());
                    rp.proveedor = dr[7].ToString();
                    lrp.Add(rp);
                    rp = null;
                }
                dr.Close();
                reporteProductosBindingSource.DataSource = lrp;
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
