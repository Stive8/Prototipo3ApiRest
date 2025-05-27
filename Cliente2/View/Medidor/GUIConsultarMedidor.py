import tkinter as tk
from tkinter import messagebox
import requests
from utils import centrar_ventana

def GUIConsultarMedidor(root):
    root.title("Consultar Medidor")
    centrar_ventana(root)

    labels = [
        "ID", "Marca", "Serial", "Diámetro", 
        "Fecha de Instalación", "ID del Predio", "Estado"
    ]
    entries = {}

    for i, label in enumerate(labels):
        tk.Label(root, text=label).grid(row=i, column=0, padx=10, pady=6, sticky="e")
        entry = tk.Entry(root, width=35)
        entry.grid(row=i, column=1, padx=10, pady=6)
        entries[label] = entry

    def consultar_medidor():
        id_str = entries["ID"].get().strip()

        if not id_str.isdigit() or int(id_str) <= 0:
            messagebox.showwarning("Error de entrada", "El ID debe ser un número entero válido.")
            return

        try:
            response = requests.get(f"http://localhost:8091/medidores/{id_str}")

            if response.status_code == 200:
                medidor = response.json()

                if medidor:
                    entries["Marca"].delete(0, tk.END)
                    entries["Marca"].insert(0, medidor.get("marca", ""))

                    entries["Serial"].delete(0, tk.END)
                    entries["Serial"].insert(0, medidor.get("serial", ""))

                    entries["Diámetro"].delete(0, tk.END)
                    entries["Diámetro"].insert(0, str(medidor.get("diametro", "")))

                    entries["Fecha de Instalación"].delete(0, tk.END)
                    fecha_instalacion = medidor.get("fechaInstalacion", "")
                    entries["Fecha de Instalación"].insert(0, fecha_instalacion[:10] if fecha_instalacion else "")

                    entries["Estado"].delete(0, tk.END)
                    entries["Estado"].insert(0, medidor.get("estado", ""))

                    predio = medidor.get("predio")
                    entries["ID del Predio"].delete(0, tk.END)
                    entries["ID del Predio"].insert(0, str(predio.get("id")) if predio else "Sin asignar")
                else:
                    messagebox.showerror("Error", "No se pudo convertir la respuesta a objeto Medidor.")
            else:
                messagebox.showwarning(
                    "Consulta fallida", 
                    f"Error al consultar el medidor. Código: {response.status_code}\n{response.text}"
                )
        except Exception as ex:
            messagebox.showerror("Error inesperado", str(ex))

    # Botón Consultar
    btn_consultar = tk.Button(root, text="Consultar", width=20, command=consultar_medidor)
    btn_consultar.grid(row=len(labels), column=0, columnspan=2, pady=20)
