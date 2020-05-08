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

    public partial class Cliente : Form
    {
        SqlCommand cmd;
        public Cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            consulta = ("INSERT INTO cliente (nombre, direccion, telefono) VALUES (@nombre, @direccion, @telefono)");
            cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("El cliente se ha agreado satisfactoriamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new verClientes().Show();
        }
    }
}
