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
    public partial class DetCompras : Form
    {
        SqlCommand cmd;
        public DetCompras()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            consulta = ("INSERT INTO detcompras (cantidad_ind, precio, subtotal) VALUES (@cantidad_ind, @precio, @subtotal)");
            cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@cantidad_ind", txtCantidad.Text);
            cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@subtotal", txtSubtotal.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("DetComprar completado satisfactoriamente");
        }
    }
}
