using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_Venta
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new DetVentas());
        }

        private void AbrirForm(Object subform) {
            if (this.Contenedor.Controls.Count > 0) 
                this.Contenedor.Controls.RemoveAt(0);
            Form sub = subform as Form;
            sub.TopLevel = false;
            sub.Dock = DockStyle.Fill;
            sub.FormBorderStyle = FormBorderStyle.None;
            this.Contenedor.Controls.Add(sub);
            this.Contenedor.Tag = sub;
            sub.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForm(new Productos());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirForm(new Empleado());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForm(new Compras());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirForm(new Proveedor());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirForm(new Ventas());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirForm(new DetCompras());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirForm(new Cliente());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirForm(new Reportes());

        }
    }
}
