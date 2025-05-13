using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar ventana en la pantalla
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario Form2
            Crear GUICrear = new Crear();

            // Mostrar el formulario
            GUICrear.Show();

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario Form2
            Consultar GUIConsultar = new Consultar();

            // Mostrar el formulario
            GUIConsultar.Show();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario Form2
            Eliminar GUIEliminar = new Eliminar();

            // Mostrar el formulario
            GUIEliminar.Show();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Form2
            Listar GUIListar = new Listar();

            // Mostrar el formulario
            GUIListar.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GUIActualizar GUIActualizar = new GUIActualizar();

            // Mostrar el formulario
            GUIActualizar.Show();

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Integrantes:\n Stiven Alvarez \n Brayhan Ortegon \n Juanita Rodriguez", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
