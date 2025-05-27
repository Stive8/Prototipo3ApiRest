import tkinter as tk
from tkinter import messagebox
import requests
from utils import centrar_ventana

def GUIEliminar(root):
    root.title("Eliminar Predio")
    centrar_ventana(root)

    labels = ["ID", "Propietario", "Dirección", "Estrato", "Consumo m3", "Fecha Registro", "Valor Factura"]
    entries = {}

    for i, label in enumerate(labels):
        tk.Label(root, text=label).grid(row=i, column=0, padx=10, pady=5, sticky="e")
        entry = tk.Entry(root, width=30)
        entry.grid(row=i, column=1, padx=10, pady=5)
        entries[label] = entry

    def limpiar_campos():
        for entry in entries.values():
            entry.delete(0, tk.END)

    def consultar_predio():
        id_ = entries["ID"].get().strip()
        if not id_.isdigit():
            messagebox.showerror("Error", "El ID debe ser un número entero.")
            return

        try:
            response = requests.get(f"http://localhost:8091/predios/{id_}")
            if response.status_code == 200:
                predio = response.json()
                entries["Propietario"].delete(0, tk.END)
                entries["Propietario"].insert(0, predio["representanteLegal"])

                entries["Dirección"].delete(0, tk.END)
                entries["Dirección"].insert(0, predio["direccion"])

                entries["Fecha Registro"].delete(0, tk.END)
                entries["Fecha Registro"].insert(0, predio["fechaRegistro"])

                entries["Estrato"].delete(0, tk.END)
                entries["Estrato"].insert(0, str(predio["estrato"]))

                entries["Consumo m3"].delete(0, tk.END)
                entries["Consumo m3"].insert(0, str(predio["consumo"]))

                entries["Valor Factura"].delete(0, tk.END)
                entries["Valor Factura"].insert(0, str(predio["valorFactura"]))
            else:
                messagebox.showerror("Error", f"No se encontró el predio.\nCódigo: {response.status_code}\n{response.text}")
        except Exception as e:
            messagebox.showerror("Error", f"Error al consultar: {e}")

    def eliminar_predio():
        id_ = entries["ID"].get().strip()
        if not id_.isdigit():
            messagebox.showerror("Error", "El ID debe ser un número entero.")
            return

        confirm = messagebox.askyesno("Confirmar eliminación", f"¿Estás seguro de eliminar el predio con ID {id_}?")
        if not confirm:
            return

        try:
            response = requests.delete(f"http://localhost:8091/predios/{id_}")
            if response.status_code == 200:
                messagebox.showinfo("Éxito", "Predio eliminado exitosamente.")
                limpiar_campos()
            else:
                messagebox.showerror("Error", f"No se pudo eliminar el predio.\nCódigo: {response.status_code}\n{response.text}")
        except Exception as e:
            messagebox.showerror("Error", f"Error al eliminar: {e}")

    # Botones
    frame_botones = tk.Frame(root)
    frame_botones.grid(row=len(labels), column=0, columnspan=2, pady=20)

    btn_consultar = tk.Button(frame_botones, text="Consultar", width=15, command=consultar_predio)
    btn_consultar.pack(side=tk.LEFT, padx=10)

    btn_eliminar = tk.Button(frame_botones, text="Eliminar", width=15, command=eliminar_predio)
    btn_eliminar.pack(side=tk.RIGHT, padx=10)
