﻿using System;
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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new repoProductos().Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new repoUsuarios().Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new repoClientes().Show();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            new repoProveedores().Show();
        }
    }
}
