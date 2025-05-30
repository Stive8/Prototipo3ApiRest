﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace Cliente
{
    public partial class GUIActualizar : Form
    {
        public GUIActualizar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar ventana en la pantalla
            txtFecha.ReadOnly = true;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación previa de campos obligatorios
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtRepresentanteLegal.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    //string.IsNullOrWhiteSpace(txtEstado.Text) ||
                    string.IsNullOrWhiteSpace(txtEstrato.Text) ||
                    string.IsNullOrWhiteSpace(txtConsumo.Text) ||
                    string.IsNullOrWhiteSpace(txtValorFactura.Text))
                    //string.IsNullOrWhiteSpace(txtSubsidio.Text) ||
                    //string.IsNullOrWhiteSpace(txtComercio.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar ID
                if (!int.TryParse(txtCodigo.Text.Trim(), out int id))
                {
                    MessageBox.Show("El ID debe ser un número entero.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar Propietario (solo letras)
                string representanteLegal = txtRepresentanteLegal.Text.Trim();
                if (!representanteLegal.All(char.IsLetter))
                {
                    MessageBox.Show("El campo 'Propietario' solo debe contener letras.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar EstadoCuenta (AC o INAC)
                /*string estado = txtEstado.Text.Trim().ToUpper();
                if (estado != "AC" && estado != "INAC")
                {
                    MessageBox.Show("El campo 'Estado de Cuenta' debe ser 'AC' o 'INAC'.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                // Validar y convertir Estrato
                if (!int.TryParse(txtEstrato.Text.Trim(), out int estrato))
                {
                    MessageBox.Show("El campo 'Estrato' debe ser un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (estrato < 1 || estrato > 6)
                {
                    MessageBox.Show("El campo 'Estrato' debe estar entre 1 y 6.", "Error de valor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar Consumo
                if (!double.TryParse(txtConsumo.Text.Trim(), out double consumo) || consumo < 0)
                {
                    MessageBox.Show("El campo 'Consumo' debe ser un número positivo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar Subsidio
                /*if (!int.TryParse(txtSubsidio.Text.Trim(), out int subsidio) || subsidio < 0)
                {
                    MessageBox.Show("El campo 'Subsidio' debe ser un número entero positivo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                // Validar TipoVivienda (string no vacío)
                /*string tipoComercio = txtComercio.Text.Trim();
                if (string.IsNullOrWhiteSpace(tipoComercio))
                {
                    MessageBox.Show("El campo 'Tipo de Vivienda' no puede estar vacío.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                string direccion = txtDireccion.Text.Trim();

                // Crear el objeto Request
                var requestData = new Request
                {
                    codigo = id,
                    representanteLegal = representanteLegal,
                    direccion = direccion,
                    //EstadoCuenta = estado,
                    estrato = estrato,
                    consumo = consumo,
                    //Subsidio = subsidio,
                    //TipoComercio = tipoComercio
                };

                // Crear cliente REST
                var options = new RestClientOptions("http://localhost:8091");
                var client = new RestClient(options);

                // Crear solicitud PUT
                var request = new RestRequest($"/predios/{id}", Method.Put);
                request.AddJsonBody(requestData);

                // Enviar solicitud
                var response = client.Execute(request);

                // Verificar respuesta
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Predio actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar predio. Código: " + (int)response.StatusCode + "\nDetalle: " + response.Content, "Error en respuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de conexión al servidor: " + ex.Message, "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnConsultar_Click_1(object sender, EventArgs e)
        {


            try
            {
                if (!int.TryParse(txtCodigo.Text.Trim(), out int id))
                {
                    MessageBox.Show("Error: El ID debe ser un número entero.");
                    return;
                }

                var options = new RestClientOptions("http://localhost:8091");
                var client = new RestClient(options);

                var request = new RestRequest($"/predios/{id}", Method.Get);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var predio = JsonConvert.DeserializeObject<Residencial>(response.Content);
                    txtRepresentanteLegal.Text = predio.representanteLegal;
                    txtDireccion.Text = predio.direccion;
                    txtFecha.Text = predio.fechaRegistro.ToString("yyyy-MM-ddTHH:mm:ss");
                    //txtEstado.Text = predio.EstadoCuenta;
                    txtEstrato.Text = predio.estrato.ToString();
                    txtConsumo.Text = predio.consumo.ToString();
                    txtValorFactura.Text = predio.valorFactura.ToString();
                    //txtSubsidio.Text = predio.Subsidio.ToString();
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



        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConsumo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}