import tkinter as tk
from tkinter import messagebox
import requests
from utils import centrar_ventana

def GUIActualizarMedidor(root):
    root.title("Actualizar Medidor")
    centrar_ventana(root)

    campos = [
        "ID", "Marca", "Serial", "Diámetro",
        "Fecha de Instalación", "ID del Predio", "Estado"
    ]
    entries = {}

    for i, campo in enumerate(campos):
        tk.Label(root, text=campo).grid(row=i, column=0, padx=10, pady=5, sticky="e")
        entry = tk.Entry(root, width=40)
        entry.grid(row=i, column=1, padx=10, pady=5)
        entries[campo] = entry

    # Desactivar el campo ID para que no se modifique
    entries["ID"].config(state="normal")  # Habilitado solo para ingresar ID
    entries["Fecha de Instalación"].config(state="readonly")  # No editable por el usuario

    def consultar_medidor():
        id_texto = entries["ID"].get().strip()

        if not id_texto.isdigit() or int(id_texto) <= 0:
            messagebox.showwarning("Error de entrada", "El ID debe ser un número entero válido.")
            return

        try:
            response = requests.get(f"http://localhost:8091/medidores/{id_texto}")

            if response.status_code == 200:
                medidor = response.json()

                if medidor:
                    entries["Marca"].delete(0, tk.END)
                    entries["Marca"].insert(0, medidor.get("marca", ""))

                    entries["Serial"].delete(0, tk.END)
                    entries["Serial"].insert(0, medidor.get("serial", ""))

                    entries["Diámetro"].delete(0, tk.END)
                    entries["Diámetro"].insert(0, str(medidor.get("diametro", "")))

                    entries["Fecha de Instalación"].config(state="normal")
                    entries["Fecha de Instalación"].delete(0, tk.END)
                    fecha = medidor.get("fechaInstalacion", "")
                    entries["Fecha de Instalación"].insert(0, fecha[:10] if fecha else "")
                    entries["Fecha de Instalación"].config(state="readonly")

                    entries["Estado"].delete(0, tk.END)
                    entries["Estado"].insert(0, medidor.get("estado", ""))

                    predio = medidor.get("predio")
                    entries["ID del Predio"].delete(0, tk.END)
                    entries["ID del Predio"].insert(0, str(predio.get("id")) if predio else "")
                else:
                    messagebox.showerror("Error", "No se pudo convertir la respuesta a objeto Medidor.")
            else:
                messagebox.showwarning("Consulta fallida", f"Error al consultar. Código: {response.status_code}\n{response.text}")
        except Exception as ex:
            messagebox.showerror("Error inesperado", str(ex))

    def actualizar_medidor():
        id_texto = entries["ID"].get().strip()
        if not id_texto.isdigit():
            messagebox.showerror("Error", "El ID debe ser un número válido.")
            return

        marca = entries["Marca"].get().strip()
        serial = entries["Serial"].get().strip()
        diametro_texto = entries["Diámetro"].get().strip()
        estado = entries["Estado"].get().strip()
        id_predio_texto = entries["ID del Predio"].get().strip()

        if not all([marca, serial, diametro_texto, estado]):
            messagebox.showwarning("Campos incompletos", "Todos los campos deben estar completos.")
            return

        try:
            diametro = float(diametro_texto)
        except ValueError:
            messagebox.showerror("Error", "El diámetro debe ser un número.")
            return

        id_predio = None
        if id_predio_texto:
            if id_predio_texto.isdigit():
                id_predio = int(id_predio_texto)
            else:
                messagebox.showerror("Error", "El ID del predio debe ser un número.")
                return

        data = {
            "marca": marca,
            "serial": serial,
            "diametro": diametro,
            "estado": estado.upper(),
            "idPredio": id_predio
        }

        try:
            response = requests.put(f"http://localhost:8091/medidores/{id_texto}", json=data)

            if response.status_code == 200:
                messagebox.showinfo("Éxito", "Medidor actualizado exitosamente.")
            else:
                messagebox.showerror("Error", f"Error al actualizar. Código: {response.status_code}\nDetalle: {response.text}")
        except Exception as ex:
            messagebox.showerror("Error inesperado", str(ex))

    # Botones
    frame_botones = tk.Frame(root)
    frame_botones.grid(row=len(campos), column=0, columnspan=2, pady=20)

    btn_consultar = tk.Button(frame_botones, text="Consultar", width=20, command=consultar_medidor)
    btn_consultar.pack(side="left", padx=10)

    btn_actualizar = tk.Button(frame_botones, text="Actualizar", width=20, command=actualizar_medidor)
    btn_actualizar.pack(side="right", padx=10)
