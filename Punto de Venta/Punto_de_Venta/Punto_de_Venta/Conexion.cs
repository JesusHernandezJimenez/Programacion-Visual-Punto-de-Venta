using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_Venta
{   

    class Conexion
    {
        SqlConnection INTEGRAL;
        SqlDataAdapter da;
        DataTable dt;
        public SqlConnection crearConexion() {
            string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
            INTEGRAL = new SqlConnection(connectionString);
            return INTEGRAL;
        }

        public void actulizar(SqlConnection con, string consulta) {
            try
            {
                con.Close();
                con.Open();
                SqlCommand c = new SqlCommand(consulta, con);
                c.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show("No se puede actualizar");
            }
        }

        public Boolean Buscar_ID(SqlConnection con, string consulta, string id) {
            con.Close();
            con.Open();
            SqlCommand c = new SqlCommand(consulta, con);
            SqlDataReader dr = c.ExecuteReader();
            int idp = Int32.Parse(id);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetInt32(0) == idp)
                    {
                        dr.Close();
                        return true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros");
            }
            dr.Close();
            return false;
        }

        public void mostrarDatos(SqlConnection con, DataGridView dgv, string consulta) {
            try {
                con.Close();
                con.Open();
                da = new SqlDataAdapter(consulta, con);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

                
            }
            catch (Exception ex) {
                MessageBox.Show("No se pueden mostrar los datos");
            }
        }
    }
}
