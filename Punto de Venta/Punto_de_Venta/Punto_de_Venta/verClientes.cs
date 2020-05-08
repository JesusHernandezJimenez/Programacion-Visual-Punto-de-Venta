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
    public partial class verClientes : Form
    {
        private int n;
        SqlConnection con = new Conexion().crearConexion();
        SqlCommand cmd;
        public verClientes()
        {
            InitializeComponent();
            con.Close();
            con.Open();
            new Conexion().mostrarDatos(con, dgvClientes, "SELECT * FROM cliente");
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            if (n != -1)
            {
                txtNombre.Text = (string)dgvClientes.Rows[n].Cells[1].Value;
                txtDireccion.Text = (string)dgvClientes.Rows[n].Cells[2].Value;
                txtTelefono.Text = (string)dgvClientes.Rows[n].Cells[3].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de actualizar a este cliente?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (n != -1)
                {
                    con.Close();
                    con.Open();
                    //string consulta;
                    //consulta = ("UPDATE cliente SET nombre = @nombre, direccion = @direccion, telefono = @telefono WHERE idcliente = @id");
                    cmd = new SqlCommand("actualizarCliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@id", dgvClientes.Rows[n].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    new Conexion().mostrarDatos(con, dgvClientes, "SELECT * FROM cliente");
                    MessageBox.Show("La información del cliente se ha actualizado satisfactoriamente");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar  a este cliente?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (n != -1)
                {
                    try
                    {
                        con.Close();
                        con.Open();
                        //string consulta;
                        //consulta = ("DELETE FROM cliente WHERE idcliente = @id");
                        cmd = new SqlCommand("eliminarCliente", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", dgvClientes.Rows[n].Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        new Conexion().mostrarDatos(con, dgvClientes, "SELECT * FROM cliente");
                        MessageBox.Show("El cliente se ha eliminado satisfactoriamente");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("No se puede eliminar a este cliente");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            //consulta = ("INSERT INTO cliente (nombre, direccion, telefono) VALUES (@nombre, @direccion, @telefono)");
            cmd = new SqlCommand("agregarCliente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd.ExecuteNonQuery();
            new Conexion().mostrarDatos(con, dgvClientes, "SELECT * FROM cliente");
            MessageBox.Show("El cliente se ha agreado satisfactoriamente");
        }
    }
}
