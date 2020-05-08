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
    public partial class Ventas : Form
    {
        SqlCommand cmd;
        public Ventas()
        {
            InitializeComponent();
            dtFecha.Format = DateTimePickerFormat.Custom;
            dtFecha.CustomFormat = "dd/MM/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            string consulta;
            SqlConnection con = new Conexion().crearConexion();
            con.Close();
            con.Open();
           
            Boolean band1 = new Conexion().Buscar_ID(con,"SELECT idcliente FROM cliente", txtCliente.Text);
            Boolean band2 = new Conexion().Buscar_ID(con, "SELECT idempleado FROM empleado", txtEmpleado.Text);

            if (band1 && band2)
            {
                consulta = ("INSERT INTO ventas (fecha, cantidadto, total, idclienteven, idempleadoven) VALUES (@fecha, @cantidadto, @total, @idclienteven, @idempleadoven)");
                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@fecha", dtFecha.Text);
                cmd.Parameters.AddWithValue("@cantidadto", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@total", txtTotal.Text);
                cmd.Parameters.AddWithValue("@idclienteven", txtCliente.Text);
                cmd.Parameters.AddWithValue("@idempleadoven", txtEmpleado.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("La venta se ha agreado satisfactoriamente");
            }
            else {
                MessageBox.Show("Error en los ID's (llaves foraneas)");
            }
            
        }
    }
}
