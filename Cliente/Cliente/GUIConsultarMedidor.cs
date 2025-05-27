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
    public partial class GUIConsultarMedidor: Form
    {
        public GUIConsultarMedidor()
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
