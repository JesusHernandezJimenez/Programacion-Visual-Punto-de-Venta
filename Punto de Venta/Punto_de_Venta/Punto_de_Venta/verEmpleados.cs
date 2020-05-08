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
    public partial class verEmpleados : Form
    {
        private int n;
        SqlConnection con = new Conexion().crearConexion();
        SqlCommand cmd;

        public verEmpleados()
        {
            InitializeComponent();
            dtFecha.Format = DateTimePickerFormat.Custom;
            dtFecha.CustomFormat = "yyyy/MM/dd";
            con.Close();
            con.Open();
            new Conexion().mostrarDatos(con, dgvEmpleados, "SELECT idempleado, nombre, direccion, telefono, usuario, contrasenia, sexo, fecha_nacimiento, cargo from empleado");
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            if (n != -1)
            {
                txtNombre.Text = (string)dgvEmpleados.Rows[n].Cells[1].Value;
                txtDireccion.Text = (string)dgvEmpleados.Rows[n].Cells[2].Value;
                txtTelefono.Text = (string)dgvEmpleados.Rows[n].Cells[3].Value;
                txtUsuario.Text = (string)dgvEmpleados.Rows[n].Cells[4].Value;
                txtContrasena.Text = (string)dgvEmpleados.Rows[n].Cells[5].Value;
                string sexo = dgvEmpleados.Rows[n].Cells[6].Value.ToString();
                Console.WriteLine(sexo);
                if (sexo.CompareTo("H ") == 0)
                {
                 
                    rbHombre.Checked = true;
                }
                else
                {
                    rbMujer.Checked = true;
                }
                dtFecha.Text = dgvEmpleados.Rows[n].Cells[7].Value.ToString()   ;
                txtCargo.Text = (string)dgvEmpleados.Rows[n].Cells[8].Value;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de actualizar los datos del empleado?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (n != -1)
                {
                    con.Close();
                    con.Open();
                    string consulta;
                    consulta = ("UPDATE empleado SET nombre = @nombre, direccion = @direccion, telefono = @telefono, usuario = @usuario, contrasenia = @contrasenia, sexo = @sexo, fecha_nacimiento = @fecha, cargo = @cargo WHERE idempleado = @id");
                    cmd = new SqlCommand(consulta, con);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasenia", txtContrasena.Text);
                    if (this.rbHombre.Checked) {
                        cmd.Parameters.AddWithValue("@sexo","H");
                    }
                    else if(this.rbMujer.Checked){ 
                        cmd.Parameters.AddWithValue("@sexo","M");
                    }
                    cmd.Parameters.AddWithValue("@fecha", dtFecha.Text);
                    cmd.Parameters.AddWithValue("@id", dgvEmpleados.Rows[n].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);

                    cmd.ExecuteNonQuery();
                    new Conexion().mostrarDatos(con, dgvEmpleados, "SELECT idempleado, nombre, direccion, telefono, usuario, contrasenia, sexo, fecha_nacimiento, cargo from empleado");
                    MessageBox.Show("El empleado se ha actualizado satisfactoriamente");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar este empleado?", "Mensaje de Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (n != -1)
                {
                    try
                    {
                        con.Close();
                        con.Open();
                        string consulta;
                        consulta = ("DELETE FROM empleado WHERE idempleado = @id");
                        cmd = new SqlCommand(consulta, con);
                        cmd.Parameters.AddWithValue("@id", dgvEmpleados.Rows[n].Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        new Conexion().mostrarDatos(con, dgvEmpleados, "SELECT idempleado, nombre, direccion, telefono, usuario, contrasenia, sexo, fecha_nacimiento, cargo from empleado");
                        MessageBox.Show("El empleado se ha eliminado satisfactoriamente");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("No se puede eliminar a este empleado ya que tiene un historial de ventas");
                    }
                }
            }
        }
    }
}
