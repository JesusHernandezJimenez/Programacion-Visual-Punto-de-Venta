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
    public partial class Empleado : Form
    {
        SqlCommand cmd;

        public Empleado()
        {
            InitializeComponent();
            dtFecha.Format = DateTimePickerFormat.Custom;
            dtFecha.CustomFormat = "yyyy/MM/dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char sexo = ' ';
            if (this.rbHombre.Checked == true) {
                sexo = 'H';
            } else if (this.rbMujer.Checked == true) {
                sexo = 'H';
            }
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            consulta = ("INSERT INTO empleado (nombre, direccion, telefono, usuario, contrasenia, sexo, fecha_nacimiento, cargo) VALUES (@nombre, @direccion, @telefono, @usuario, @contrasenia, @sexo, @fecha_nacimiento, @cargo)");
            cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@contrasenia", txtContrasena.Text);
            cmd.Parameters.AddWithValue("@sexo", sexo);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", dtFecha.Text);
            cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("El empleado se ha agreado satisfactoriamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new verEmpleados().Show();
        }
    }
}
