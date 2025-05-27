import tkinter as tk
from tkinter import messagebox
import requests
import re
from utils import centrar_ventana

def GUICrearMedidor(root):
    root.title("Crear Medidor")
    centrar_ventana(root)

    labels = ["Marca", "Serial", "Diámetro", "ID del Predio"]
    entries = {}

    for i, label in enumerate(labels):
        tk.Label(root, text=label).grid(row=i, column=0, padx=10, pady=8, sticky="e")
        entry = tk.Entry(root, width=30)
        entry.grid(row=i, column=1, padx=10, pady=8)
        entries[label] = entry

    def crear_medidor():
        marca = entries["Marca"].get().strip()
        serial = entries["Serial"].get().strip()
        diametro_str = entries["Diámetro"].get().strip()
        id_predio_str = entries["ID del Predio"].get().strip()

        # Validaciones
        if not marca or not serial or not diametro_str:
            messagebox.showwarning("Campos incompletos", "Por favor complete todos los campos obligatorios.")
            return

        if re.fullmatch(r"\d+", marca):
            messagebox.showerror("Error de formato", "El campo 'Marca' no puede ser solo números.")
            return

        if re.fullmatch(r"\d+", serial):
            messagebox.showerror("Error de formato", "El campo 'Serial' no puede ser solo números.")
            return

        try:
            diametro = float(diametro_str)
            if diametro <= 0:
                raise ValueError
        except ValueError:
            messagebox.showerror("Error de formato", "El campo 'Diámetro' debe ser un número positivo.")
            return

        id_predio = None
        if id_predio_str:
            if not id_predio_str.isdigit():
                messagebox.showerror("Error de formato", "El campo 'ID del Predio' debe ser un número válido si se proporciona.")
                return
            id_predio = int(id_predio_str)

        # Enviar solicitud POST
        try:
            body = {
                "marca": marca,
                "serial": serial,
                "diametro": diametro,
                "idPredio": id_predio
            }

            response = requests.post("http://localhost:8091/medidores/", json=body)

            if response.status_code == 200:
                messagebox.showinfo("Éxito", f"Medidor creado exitosamente. Código de respuesta: {response.status_code}")
            else:
                messagebox.showerror("Error en respuesta", f"Error al crear el medidor. Código: {response.status_code}\nDetalle: {response.text}")
        except requests.exceptions.RequestException as ex:
            messagebox.showerror("Error de conexión", f"Error de red: {str(ex)}")
        except Exception as ex:
            messagebox.showerror("Error general", f"Error inesperado: {str(ex)}")

    # Botón Crear
    btn_crear = tk.Button(root, text="Crear", width=20, command=crear_medidor)
    btn_crear.grid(row=len(labels), column=0, columnspan=2, pady=20)
