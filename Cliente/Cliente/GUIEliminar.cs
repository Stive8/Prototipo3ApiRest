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
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar ventana en la pantalla
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text.Trim(), out int id))
                {
                    MessageBox.Show("Error: El ID debe ser un número entero.");
                    return;
                }

                DialogResult result = MessageBox.Show($"¿Estás seguro de eliminar el predio con ID {id}?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                var client = new RestClient("http://localhost:8091");
                var request = new RestRequest($"/predios/{id}", Method.Delete);
                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Predio eliminado exitosamente.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar predio: " + response.StatusCode + "\nContenido: " + response.Content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtRepresentanteLegal.Text = "";
            txtDireccion.Text = "";
            txtFecha.Text = "";
            //txtEstado.Text = "";
            txtEstrato.Text = "";
            txtConsumo.Text = "";
            //txtSubsidio.Text = "";
            //txtComercio.Text = "";
            txtValorFactura.Text = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text.Trim(), out int id))
                {
                    MessageBox.Show("Error: El ID debe ser un número entero.");
                    return;
                }

                var client = new RestClient("http://localhost:8091");
                var request = new RestRequest($"/predios/{id}", Method.Get);
                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var predio = JsonConvert.DeserializeObject<Residencial>(response.Content);
                    txtRepresentanteLegal.Text = predio.representanteLegal;
                    txtDireccion.Text = predio.direccion;
                    txtFecha.Text = predio.fechaRegistro.ToString("yyyy-MM-ddTHH:mm:ss");
                    txtEstrato.Text = predio.estrato.ToString();
                    txtConsumo.Text = predio.consumo.ToString();
                    txtValorFactura.Text = predio.valorFactura.ToString();
                    //txtComercio.Text = predio.TipoComercio;
                }
                else
                {
                    MessageBox.Show("Error al consultar predio: " + response.StatusCode + "\nContenido: " + response.Content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
    }
}
