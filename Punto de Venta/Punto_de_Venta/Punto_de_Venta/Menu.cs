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
        public void AbrirForm(Object subform,  Button boton, Button boton2)
        {
            
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
            Form sub = subform as Form;
            sub.TopLevel = false;
            sub.Dock = DockStyle.Fill;
            sub.FormBorderStyle = FormBorderStyle.None;
            this.Contenedor.Controls.Add(sub);
            this.Contenedor.Tag = sub;
            boton.Visible = false;
            boton2.Visible = false;
            sub.Show();

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new verProductos());
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new verEmpleados());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new verProveedores());
        }              
                
        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new Reportes());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new verClientes());
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void detVentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirForm(new DetVentas());
        }

        private void detComprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirForm(new DetCompras());
        }

        private void Contenedor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new Compras());
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new Ventas());
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verProductos alta = new verProductos();
            AbrirForm(alta, alta.btnActualizar, alta.btnEliminar);
            alta.btnAgregar.Location = new Point(874,518);
            
                      
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verProductos actualizar = new verProductos();
            AbrirForm(actualizar, actualizar.btnAgregar, actualizar.btnEliminar);
            actualizar.btnActualizar.Location = new Point(874, 518);

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verProductos eliminar = new verProductos();
            AbrirForm(eliminar, eliminar.btnAgregar, eliminar.btnActualizar);
            eliminar.btnEliminar.Location = new Point(874, 518);

        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            verEmpleados alta = new verEmpleados();
            AbrirForm(alta, alta.btnActualizar, alta.btnEliminar);
            alta.btnAgregar.Location = new Point(874, 518);
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            verEmpleados actualizar = new verEmpleados();
            AbrirForm(actualizar, actualizar.btnAgregar, actualizar.btnEliminar);
            actualizar.btnActualizar.Location = new Point(874, 518);
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            verEmpleados eliminar = new verEmpleados();
            AbrirForm(eliminar, eliminar.btnAgregar, eliminar.btnActualizar);
            eliminar.btnEliminar.Location = new Point(874, 518);
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            verProveedores alta = new verProveedores();
            AbrirForm(alta, alta.btnActualizar, alta.btnEliminar);
            alta.btnAgregar.Location = new Point(877, 323);
        }

        private void actualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            verProveedores actualizar = new verProveedores();
            AbrirForm(actualizar, actualizar.btnAgregar, actualizar.btnEliminar);
            actualizar.btnActualizar.Location = new Point(877, 323);
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            verProveedores eliminar = new verProveedores();
            AbrirForm(eliminar, eliminar.btnAgregar, eliminar.btnActualizar);
            eliminar.btnEliminar.Location = new Point(877, 323);
        }

        private void altaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            verClientes alta = new verClientes();
            AbrirForm(alta, alta.btnActualizar, alta.btnEliminar);
            alta.btnAgregar.Location = new Point(760, 352);
        }

        private void actualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            verClientes actualizar = new verClientes();
            AbrirForm(actualizar, actualizar.btnAgregar, actualizar.btnEliminar);
            actualizar.btnActualizar.Location = new Point(760, 352);
        }

        private void eliminarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            verClientes eliminar = new verClientes();
            AbrirForm(eliminar, eliminar.btnAgregar, eliminar.btnActualizar);
            eliminar.btnEliminar.Location = new Point(760, 352);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta seguro de salir del sistema?", "Salir", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }
    }
}
