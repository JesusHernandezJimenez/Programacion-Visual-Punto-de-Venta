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
    public partial class DetVentas : Form
    {
        SqlCommand cmd;

        public DetVentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            Boolean band = new Conexion().Buscar_ID(con, "SELECT idventa FROM ventas", txtVenta.Text);
            
            if (band)
            {
                consulta = ("INSERT INTO detventas (cantidad, nombre, precio, subtotal, iddetventasven) VALUES (@cantidad, @nombre, @precio, @subtotal, @iddetventasven)");
                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@subtotal", txtSubtotal.Text);
                cmd.Parameters.AddWithValue("@iddetventasven", txtVenta.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Det Venta completado");
            }
            else
            {
                MessageBox.Show("Error en el ID de Venta");
            }
            
        }
    }
}
