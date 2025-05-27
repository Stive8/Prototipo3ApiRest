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
    public partial class GUIActualizarMedidor: Form
    {
        public GUIActualizarMedidor()
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

        private void btnActualizarMedidor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(txtId.Text.Trim(), out long id))
                {
                    MessageBox.Show("El ID debe ser un número válido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMarca.Text) ||
                    string.IsNullOrWhiteSpace(txtSerial.Text) ||
                    string.IsNullOrWhiteSpace(txtDiametro.Text) ||
                    string.IsNullOrWhiteSpace(txtEstado.Text))
                {
                    MessageBox.Show("Todos los campos deben estar completos.");
                    return;
                }

                // Validaciones específicas
                if (!double.TryParse(txtDiametro.Text.Trim(), out double diametro))
                {
                    MessageBox.Show("El diámetro debe ser numérico.");
                    return;
                }

                long? idPredio = null;
                if (long.TryParse(txtIdPredio.Text.Trim(), out long parsedIdPredio))
                {
                    idPredio = parsedIdPredio;
                }

                var requestData = new RequestMedidor
                {
                    marca = txtMarca.Text.Trim(),
                    serial = txtSerial.Text.Trim(),
                    diametro = diametro,
                    estado = txtEstado.Text.Trim().ToUpper(),
                    idPredio = idPredio.Value
                };

                var client = new RestClient("http://localhost:8091");
                var request = new RestRequest($"/medidores/{id}", Method.Put);
                request.AddJsonBody(requestData);

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Medidor actualizado exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar medidor. Código: " + (int)response.StatusCode + "\nDetalle: " + response.Content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }



    }
}
