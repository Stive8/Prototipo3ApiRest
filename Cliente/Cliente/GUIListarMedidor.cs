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
    public partial class GUIListarMedidor: Form
    {
        public GUIListarMedidor()
        {
            InitializeComponent();
            
        }

        private async void btnListarMedidor_Click(object sender, EventArgs e)
        {
            try
            {
                ApiServiceMedidor apiServiceMedidor = new ApiServiceMedidor();
                var medidores = await apiServiceMedidor.GetMedidorsAsync();

                if (medidores != null && medidores.Count > 0)
                {
                    dataGridView1.DataSource = null; // Limpiar la grilla
                    dataGridView1.DataSource = medidores;
                }
                else
                {
                    MessageBox.Show("No se encontraron medidores.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar los medidores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Listar activos (por RadioButton)
        private async void btnActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (btnActivo.Checked)
            {
                try
                {
                    ApiServiceMedidor apiServiceMedidor = new ApiServiceMedidor();
                    var activos = await apiServiceMedidor.GetMedidoresActivosAsync();
                    MostrarEnTabla(activos, "No hay medidores activos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar activos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Filtrar por ID de predio
        private async void btnFiltrarPredio_Click(object sender, EventArgs e)
        {
            try
            {
                ApiServiceMedidor apiServiceMedidor = new ApiServiceMedidor();

                if (!long.TryParse(txtFiltrarPredio.Text.Trim(), out long idPredio))
                {
                    MessageBox.Show("Ingrese un ID de predio válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var filtrados = await apiServiceMedidor.GetMedidoresPorPredioAsync(idPredio);

                MostrarEnTabla(filtrados, "No se encontraron medidores para el ID ingresado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por predio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método reutilizable para cargar datos
        private void MostrarEnTabla(List<Medidor> lista, string mensajeVacio)
        {
            if (lista != null && lista.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
            else
            {
                MessageBox.Show(mensajeVacio, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
        }

    }
}
