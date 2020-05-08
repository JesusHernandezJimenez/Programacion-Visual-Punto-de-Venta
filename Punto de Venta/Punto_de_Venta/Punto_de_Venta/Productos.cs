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
    public partial class Productos : Form
    {
        SqlCommand cmd;
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new Conexion().crearConexion();
            Boolean band = false;
            try
            {
                con.Close();
                con.Open();
                SqlCommand c = new SqlCommand("SELECT idproveedor FROM proveedor", con);
                SqlDataReader dr = c.ExecuteReader();
                int idprov = Int32.Parse(txtProveedor.Text);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr.GetInt32(0) == idprov) {
                            band = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay registro de Proveedores");
                }
                if (band == false)
                {
                    MessageBox.Show("No se encontro registro de ese proveedor");
                }else {
                    dr.Close();
                    string consulta;

                    consulta = ("INSERT INTO productos (nombre, descripcion, marca, precio, costo, minimo, stok, idproveedorpro) VALUES (@nombre, @descripcion, @marca, @precio, @costo, @minimo, @stock, @idproveedorpro)");
                    cmd = new SqlCommand(consulta, con);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                    cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@costo", txtCosto.Text);
                    cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                    cmd.Parameters.AddWithValue("@stock", txtStock.Text);
                    cmd.Parameters.AddWithValue("@idproveedorpro", txtProveedor.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El producto se ha agreado satisfactoriamente");
                }

            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new verProductos().Show();
        }
    }
}
