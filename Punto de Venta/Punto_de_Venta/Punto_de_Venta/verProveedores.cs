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
    public partial class verProveedores : Form
    {
        private int n;
        SqlConnection con = new Conexion().crearConexion();
        SqlCommand cmd;

        public verProveedores()
        {
            InitializeComponent();
            con.Close();
            con.Open();
            new Conexion().mostrarDatos(con, dgvProveedores, "SELECT * FROM proveedor");
        }

        private void dgvProveedores_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            if (n != -1)
            {
                txtNombre.Text = (string)dgvProveedores.Rows[n].Cells[1].Value;
                txtDireccion.Text = (string)dgvProveedores.Rows[n].Cells[2].Value;
                txtRFC.Text = (string)dgvProveedores.Rows[n].Cells[3].Value;
                txtTelefono.Text = (string)dgvProveedores.Rows[n].Cells[4].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de actualizar a este proveedor?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (n != -1)
                {
                    con.Close();
                    con.Open();
                    //string consulta;
                    //consulta = ("UPDATE proveedor SET nombrepro = @nombre, direccion = @direccion, rfc = @rfc, telefono = @telefono WHERE idproveedor = @id");
                    cmd = new SqlCommand("actualizarProveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombrepro", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@rfc", txtRFC.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@id", dgvProveedores.Rows[n].Cells[0].Value);
                    cmd.ExecuteNonQuery();
                    new Conexion().mostrarDatos(con, dgvProveedores, "SELECT * FROM proveedor");
                    MessageBox.Show("El proveedor se ha actualizado satisfactoriamente");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar a este proveedor?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (n != -1)
                {
                    try
                    {
                        con.Close();
                        con.Open();
                        //string consulta;
                        //consulta = ("DELETE FROM proveedor WHERE idproveedor = @id");
                        cmd = new SqlCommand("eliminarProveedor", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", dgvProveedores.Rows[n].Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        new Conexion().mostrarDatos(con, dgvProveedores, "SELECT * FROM proveedor");
                        MessageBox.Show("El proveedor se ha eliminado satisfactoriamente");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("No se puede eliminar a este proveedor");
                    }
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            //String consulta;
            //consulta = ("INSERT INTO proveedor (nombrepro, direccion, rfc, telefono) VALUES (@nombrepro, @direccion, @rfc, @telefono)");
            cmd = new SqlCommand("agregarProveedor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombrepro", txtNombre.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@rfc", txtRFC.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);

            cmd.ExecuteNonQuery();
            new Conexion().mostrarDatos(con, dgvProveedores, "SELECT * FROM proveedor");
            MessageBox.Show("El proveedor se ha agreado satisfactoriamente");
        }
    }
}
