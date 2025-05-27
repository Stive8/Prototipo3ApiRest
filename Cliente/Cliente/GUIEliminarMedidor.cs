using Newtonsoft.Json;
using RestSharp;
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
    public partial class GUIEliminarMedidor: Form
    {
        public GUIEliminarMedidor()
        {
            InitializeComponent();
        }

        private void btnConsultarMedidor_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el ID sea un número válido
                if (!long.TryParse(txtId.Text.Trim(), out long id) || id <= 0)
                {
                    MessageBox.Show("El ID debe ser un número entero válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear cliente REST
                var client = new RestClient("http://localhost:8091");
                var request = new RestRequest($"/medidores/{id}", Method.Get);

                // Ejecutar solicitud
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    // Deserializar JSON a objeto Medidor
                    var medidor = JsonConvert.DeserializeObject<Medidor>(response.Content);

                    if (medidor != null)
                    {
                        txtMarca.Text = medidor.marca;
                        txtSerial.Text = medidor.serial;
                        txtDiametro.Text = medidor.diametro.ToString();
                        txtFechaInstalacion.Text = medidor.fechaInstalacion.ToString("yyyy-MM-dd");
                        txtEstado.Text = medidor.estado;

                        // Validar si el predio está presente
                        txtIdPredio.Text = medidor.predio != null ? medidor.predio.id.ToString() : "Sin asignar";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo convertir la respuesta a objeto Medidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al consultar el medidor. Código: " + (int)response.StatusCode + "\n" + response.Content, "Consulta fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarMedidor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txtId.Text.Trim(), out long id))
                {
                    MessageBox.Show("Error: El ID debe ser un número válido.");
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Estás seguro de desactivar el medidor con ID {id}?\nEsto cambiará su estado a INACTIVO.",
                    "Confirmar desactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No)
                    return;

                var client = new RestClient("http://localhost:8091");
                var request = new RestRequest($"/medidores/{id}", Method.Delete);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Medidor desactivado correctamente (estado cambiado a INACTIVO).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); // Puedes definir esta función para borrar los TextBox.
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show($"No se encontró el medidor con ID {id}.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al desactivar el medidor: " + response.StatusCode + "\nContenido: " + response.Content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtMarca.Text = "";
            txtSerial.Text = "";
            txtDiametro.Text = "";
            txtFechaInstalacion.Text = "";
            txtIdPredio.Text = "";
            txtEstado.Text = "";

        }



    }
}
