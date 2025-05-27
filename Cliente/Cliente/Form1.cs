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

        //Ahora conexion a los GUI de medidor

        private void toolStripMenuItem8_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Form2
            GUICrearMedidor GUICrearMedidor = new GUICrearMedidor();

            // Mostrar el formulario
            GUICrearMedidor.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Integrantes:\n Stiven Alvarez \n Brayhan Ortegon \n Juanita Rodriguez", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem9_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Form2
            GUIListarMedidor GUIListarMedidor = new GUIListarMedidor();

            // Mostrar el formulario
            GUIListarMedidor.Show();
        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {

            // Crear una instancia del formulario Form2
            GUIConsultarMedidor GUIConsultarMedidor = new GUIConsultarMedidor();

            // Mostrar el formulario
            GUIConsultarMedidor.Show();

        }

        private void actualizarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            GUIActualizarMedidor GUIActualizarMedidor = new GUIActualizarMedidor();

            // Mostrar el formulario
            GUIActualizarMedidor.Show();

        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {

            // Crear una instancia del formulario Form2
            GUIEliminarMedidor GUIEliminarMedidor = new GUIEliminarMedidor();

            // Mostrar el formulario
            GUIEliminarMedidor.Show();

        }
    }
}
