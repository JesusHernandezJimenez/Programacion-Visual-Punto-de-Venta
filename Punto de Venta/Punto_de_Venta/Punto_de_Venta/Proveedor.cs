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
    public partial class Proveedor : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string consulta;
        public Proveedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new Conexion().crearConexion();
            con.Close();
            con.Open();
            consulta = ("INSERT INTO proveedor (nombrepro, direccion, rfc, telefono) VALUES (@nombrepro, @direccion, @rfc, @telefono)");
            cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@nombrepro", txtNombre.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@rfc", txtRFC.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("El proveedor se ha agreado satisfactoriamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new verProveedores().Show();
        }
    }
}
