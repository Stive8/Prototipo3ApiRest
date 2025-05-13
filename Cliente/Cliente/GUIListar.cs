using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace Cliente
{
    public partial class Listar: Form
    {
        public Listar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar ventana en la pantalla
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                ApiService apiService = new ApiService();
                var residenciales = await apiService.GetResidencialesAsync();

                if (residenciales != null && residenciales.Count > 0)
                {
                    dataGridView2.DataSource = null; // Limpiar la grilla
                    dataGridView2.DataSource = residenciales;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEstratoBajo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnEstratoBajo.Checked)
                {
                    ApiService apiService = new ApiService();

                    // Llamada al backend para obtener estratos menores a 4 (1, 2, 3)
                    var residenciales = await apiService.GetResidencialesByEstratoLessAsync(4);

                    if (residenciales != null && residenciales.Count > 0)
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = residenciales;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con estratos bajos (1-3).", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView2.DataSource = null;
                    }

                    // Desmarca el checkbox de estrato alto (si estás usando ambos checkboxes)
                    btnEstratoAlto.Checked = false;
                }
                else
                {
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar filtro de estrato bajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEstratoAlto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnEstratoAlto.Checked)
                {
                    ApiService apiService = new ApiService();

                    // Llamada al backend para obtener predios con estrato mayor a 3 (4, 5, 6)
                    var residenciales = await apiService.GetResidencialesByEstratoGreaterAsync(3);

                    if (residenciales != null && residenciales.Count > 0)
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = residenciales;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros con estratos altos (4-6).", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView2.DataSource = null;
                    }

                    // Desmarca el checkbox de estrato bajo (si estás usando ambos checkboxes)
                    btnEstratoBajo.Checked = false;
                }
                else
                {
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar filtro de estrato alto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que ambos campos sean números enteros válidos
                if (!int.TryParse(txtMin.Text.Trim(), out int minEstrato))
                {
                    MessageBox.Show("El campo mínimo debe contener un número entero válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtMax.Text.Trim(), out int maxEstrato))
                {
                    MessageBox.Show("El campo máximo debe contener un número entero válido.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que estén dentro del rango permitido
                if (minEstrato < 1 || minEstrato > 6 || maxEstrato < 1 || maxEstrato > 6)
                {
                    MessageBox.Show("Los estratos deben estar entre 1 y 6.", "Rango fuera de límites", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el mínimo no sea mayor que el máximo
                if (minEstrato > maxEstrato)
                {
                    MessageBox.Show("El estrato mínimo no puede ser mayor que el máximo.", "Error de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ApiService apiService = new ApiService();
                var residenciales = await apiService.GetResidencialesByEstratoRangeAsync(minEstrato, maxEstrato);

                if (residenciales != null && residenciales.Count > 0)
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = residenciales;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros en el rango de estratos especificado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por rango de estratos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
