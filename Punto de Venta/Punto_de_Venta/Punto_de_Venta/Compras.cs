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
    public partial class Compras : Form
    {
        SqlCommand cmd;

        public Compras()
        {
            InitializeComponent();
            dtFecha.Format = DateTimePickerFormat.Custom;
            dtFecha.CustomFormat = "dd/MM/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            Boolean band1 = new Conexion().Buscar_ID(con, "SELECT idproducto FROM productos", txtProducto.Text);
            Boolean band2 = new Conexion().Buscar_ID(con, "SELECT iddetcompras FROM detcompras", txtCompra.Text);
            if (band1 && band2)
            {
                consulta = ("INSERT INTO compras (fecha, cantidad_pro, total, idproductocom, iddetcomprascom) VALUES (@fecha, @cantidadto, @total, @idproductocom, @iddetcomprascom)");
                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@fecha", dtFecha.Text);
                cmd.Parameters.AddWithValue("@cantidadto", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@total", txtTotal.Text);
                cmd.Parameters.AddWithValue("@idproductocom", txtProducto.Text);
                cmd.Parameters.AddWithValue("@iddetcomprascom", txtCompra.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("La compra se ha agreado satisfactoriamente");
            }
            else
            {
                MessageBox.Show("Error en los ID's (llaves foraneas)");
            }

            
        }
    }
}
