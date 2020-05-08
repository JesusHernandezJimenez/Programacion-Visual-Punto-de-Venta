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
    public partial class verProductos : Form
    {
        private int n;
        SqlConnection con = new Conexion().crearConexion();
        SqlCommand cmd;
        public verProductos()
        {
            InitializeComponent();
            
            con.Close();
            con.Open();
            new Conexion().mostrarDatos(con, dgvProductos, "SELECT idproducto, nombre AS Nombre, descripcion as Descripción, marca as Marca, precio as Precio, costo as Costo, minimo as Minimo , stok as stock, idproveedorpro FROM productos");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de actualizar este producto?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                if (n != -1)
                {
                    con.Close();
                    con.Open();
                    //string consulta;
                    //consulta = ("UPDATE productos SET nombre = @nombre, descripcion = @descripcion, marca = @marca, precio = @precio, costo = @costo, minimo = @minimo, stok = @stock, idproveedorpro =@idproveedor WHERE idproducto = @id");
                    cmd = new SqlCommand("actualizarProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                    cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@costo", txtCosto.Text);
                    cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                    cmd.Parameters.AddWithValue("@stock", txtStock.Text);
                    cmd.Parameters.AddWithValue("@idproveedorpro", txtProveedor.Text);
                    cmd.Parameters.AddWithValue("@id", dgvProductos.Rows[n].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    new Conexion().mostrarDatos(con, dgvProductos, "SELECT idproducto, nombre AS Nombre, descripcion as Descripción, marca as Marca, precio as Precio, costo as Costo, minimo as Minimo , stok as Stock, idproveedorpro FROM productos");
                    MessageBox.Show("El producto se ha actualizado satisfactoriamente");

                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            if (n != -1) {
                txtNombre.Text = (string)dgvProductos.Rows[n].Cells[1].Value;
                txtDescripcion.Text = (string)dgvProductos.Rows[n].Cells[2].Value;
                txtMarca.Text = (string)dgvProductos.Rows[n].Cells[3].Value;
                txtPrecio.Text = dgvProductos.Rows[n].Cells[4].Value.ToString();
                txtCosto.Text = dgvProductos.Rows[n].Cells[5].Value.ToString();
                txtMinimo.Text = dgvProductos.Rows[n].Cells[6].Value.ToString();
                txtStock.Text = dgvProductos.Rows[n].Cells[7].Value.ToString();
                txtProveedor.Text = dgvProductos.Rows[n].Cells[8].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                if (n != -1)
                {
                    try
                    {
                        con.Close();
                        con.Open();
                        //string consulta;
                        //consulta = ("DELETE FROM productos WHERE idproducto = @id");
                        cmd = new SqlCommand("eliminarProducto", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idproducto", dgvProductos.Rows[n].Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        new Conexion().mostrarDatos(con, dgvProductos, "SELECT idproducto as ID, nombre AS Nombre, descripcion as Descripción, marca as Marca, precio as Precio, costo as Costo, minimo as Minimo , stok as Stock, idproveedorpro FROM productos");
                        MessageBox.Show("El producto se ha eliminado satisfactoriamente");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("No se puede eliminar el producto");
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                        if (dr.GetInt32(0) == idprov)
                        {
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
                }
                else
                {
                    dr.Close();
                    //string consulta;

                    // consulta = ("INSERT INTO productos (nombre, descripcion, marca, precio, costo, minimo, stok, idproveedorpro) VALUES (@nombre, @descripcion, @marca, @precio, @costo, @minimo, @stock, @idproveedorpro)");
                    cmd = new SqlCommand("agregarProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                    cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@costo", txtCosto.Text);
                    cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                    cmd.Parameters.AddWithValue("@stock", txtStock.Text);
                    cmd.Parameters.AddWithValue("@idproveedorpro", txtProveedor.Text);
                    cmd.ExecuteNonQuery();
                    new Conexion().mostrarDatos(con, dgvProductos, "SELECT idproducto as ID, nombre AS Nombre, descripcion as Descripción, marca as Marca, precio as Precio, costo as Costo, minimo as Minimo , stok as Stock, idproveedorpro FROM productos");
                    MessageBox.Show("El producto se ha agreado satisfactoriamente");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
