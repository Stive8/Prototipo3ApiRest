import tkinter as tk
from tkinter import messagebox
import requests
from utils import centrar_ventana

def GUIEliminarMedidor(root):
    root.title("Eliminar Medidor (Desactivar)")
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

    # Configurar el campo Fecha como de solo lectura
    entries["Fecha de Instalación"].config(state="readonly")

    def limpiar_campos():
        for campo in campos:
            if campo == "Fecha de Instalación":
                entries[campo].config(state="normal")
            entries[campo].delete(0, tk.END)
            if campo == "Fecha de Instalación":
                entries[campo].config(state="readonly")

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

    def eliminar_medidor():
        id_texto = entries["ID"].get().strip()
        if not id_texto.isdigit():
            messagebox.showerror("Error", "El ID debe ser un número válido.")
            return

        confirmacion = messagebox.askyesno(
            title="Confirmar desactivación",
            message=f"¿Estás seguro de desactivar el medidor con ID {id_texto}?\nEsto cambiará su estado a INACTIVO."
        )

        if not confirmacion:
            return

        try:
            response = requests.delete(f"http://localhost:8091/medidores/{id_texto}")

            if response.status_code == 200:
                messagebox.showinfo("Éxito", "Medidor desactivado correctamente (estado cambiado a INACTIVO).")
                limpiar_campos()
            elif response.status_code == 404:
                messagebox.showwarning("No encontrado", f"No se encontró el medidor con ID {id_texto}.")
            else:
                messagebox.showerror("Error", f"Error al desactivar el medidor. Código: {response.status_code}\nContenido: {response.text}")
        except Exception as ex:
            messagebox.showerror("Error inesperado", str(ex))

    # Botones
    frame_botones = tk.Frame(root)
    frame_botones.grid(row=len(campos), column=0, columnspan=2, pady=20)

    btn_consultar = tk.Button(frame_botones, text="Consultar", width=20, command=consultar_medidor)
    btn_consultar.pack(side="left", padx=10)

    btn_eliminar = tk.Button(frame_botones, text="Eliminar", width=20, command=eliminar_medidor)
    btn_eliminar.pack(side="right", padx=10)
