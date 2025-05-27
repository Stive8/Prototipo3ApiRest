using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class GUICrearMedidor : Form
    {
        public GUICrearMedidor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCrearMedidor_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos vacíos
                if (string.IsNullOrWhiteSpace(txtMarca.Text) ||
                    string.IsNullOrWhiteSpace(txtSerial.Text) ||
                    string.IsNullOrWhiteSpace(txtDiametro.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string marca = txtMarca.Text.Trim();
                string serial = txtSerial.Text.Trim();

                // Validar que marca y serial no sean solo números
                if (Regex.IsMatch(marca, @"^\d+$"))
                {
                    MessageBox.Show("El campo 'Marca' no puede ser solo números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Regex.IsMatch(serial, @"^\d+$"))
                {
                    MessageBox.Show("El campo 'Serial' no puede ser solo números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar y convertir diámetro
                if (!double.TryParse(txtDiametro.Text.Trim(), out double diametro) || diametro <= 0)
                {
                    MessageBox.Show("El campo 'Diámetro' debe ser un número positivo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar y convertir predioId (opcional)
                long? idPredio = null;
                if (!string.IsNullOrWhiteSpace(txtIdPredio.Text))
                {
                    if (long.TryParse(txtIdPredio.Text.Trim(), out long id))
                    {
                        idPredio = id;
                    }
                    else
                    {
                        MessageBox.Show("El campo 'ID Predio' debe ser un número válido si se proporciona.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Crear cliente y solicitud REST
                var options = new RestClientOptions("http://localhost:8091");
                var client = new RestClient(options);
                var request = new RestRequest("/medidores/", Method.Post);
                request.RequestFormat = DataFormat.Json;

                // Agregar cuerpo JSON
                request.AddBody(new
                {
                    marca = marca,
                    serial = serial,
                    diametro = diametro,
                    idPredio = idPredio // Puede ser null
                });

                // Enviar solicitud
                var response = client.Post(request);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Medidor creado exitosamente. Código de respuesta: " + (int)response.StatusCode, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear el medidor. Código: " + (int)response.StatusCode + "\nDetalle: " + response.Content, "Error en respuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de red: " + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
