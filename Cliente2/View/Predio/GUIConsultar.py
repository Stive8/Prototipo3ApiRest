import tkinter as tk
from tkinter import messagebox
import requests
from utils import centrar_ventana

def GUIConsultar(root):
    root.title("Consultar Predio")

    labels = ["ID", "Propietario", "Dirección", "Estrato", "Consumo m3", "Fecha Registro", "Valor Factura"]
    entries = {}

    for i, label in enumerate(labels):
        tk.Label(root, text=label, anchor="w", width=15).grid(row=i, column=0, padx=10, pady=5, sticky="w")
        entry = tk.Entry(root, width=30)
        entry.grid(row=i, column=1, padx=10, pady=5)
        entries[label] = entry

    def consultar():
        try:
            id_text = entries["ID"].get().strip()
            if not id_text.isdigit() or int(id_text) <= 0:
                messagebox.showerror("Error", "El ID debe ser un número entero positivo.")
                return

            id_value = int(id_text)
            url = f"http://localhost:8091/predios/{id_value}"
            response = requests.get(url)

            if response.status_code == 200:
                predio = response.json()
                entries["Propietario"].delete(0, tk.END)
                entries["Propietario"].insert(0, predio.get("representanteLegal", ""))

                entries["Dirección"].delete(0, tk.END)
                entries["Dirección"].insert(0, predio.get("direccion", ""))

                entries["Estrato"].delete(0, tk.END)
                entries["Estrato"].insert(0, predio.get("estrato", ""))

                entries["Consumo m3"].delete(0, tk.END)
                entries["Consumo m3"].insert(0, predio.get("consumo", ""))

                entries["Fecha Registro"].delete(0, tk.END)
                entries["Fecha Registro"].insert(0, predio.get("fechaRegistro", ""))

                entries["Valor Factura"].delete(0, tk.END)
                entries["Valor Factura"].insert(0, predio.get("valorFactura", ""))
            else:
                messagebox.showerror("Error", f"No se encontró el predio con ID {id_value}. Código: {response.status_code}")
        except Exception as e:
            messagebox.showerror("Error", f"Error inesperado: {str(e)}")

    boton_consultar = tk.Button(root, text="Consultar", command=consultar)
    boton_consultar.grid(row=len(labels), column=0, columnspan=2, pady=15)

    root.update()
    centrar_ventana(root)