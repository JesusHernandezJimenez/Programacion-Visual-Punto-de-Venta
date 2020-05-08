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
    public partial class Almacen : Form
    {
        SqlCommand cmd;
        public Almacen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            consulta = ("INSERT INTO almacen (cantidad, idproductoalm) VALUES (@cantidad, @idproductoalm)");
            cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
            cmd.Parameters.AddWithValue("@idproductoalm", txtProducto.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Producto almacenado correctamente");
        }
    }
}
