import tkinter as tk
from tkinter import messagebox
import requests
import json
from utils import centrar_ventana


def GUIActualizar(root):
    root.title("Actualizar Predio")
    centrar_ventana(root)

    labels = ["ID", "Propietario", "Direccion", "Estrato", "Consumo m3", "Fecha Registro", "Valor factura"]
    entries = {}

    for i, label in enumerate(labels):
        tk.Label(root, text=label).grid(row=i, column=0, padx=10, pady=5, sticky="e")
        entry = tk.Entry(root)
        entry.grid(row=i, column=1, padx=10, pady=5)
        entries[label] = entry

    entries["Fecha Registro"].config(state="readonly")

    def consultar():
        id_ = entries["ID"].get().strip()
        if not id_.isdigit():
            messagebox.showerror("Error", "El ID debe ser un número entero.")
            return

        try:
            response = requests.get(f"http://localhost:8091/predios/{id_}")
            if response.status_code == 200:
                data = response.json()
                entries["Propietario"].delete(0, tk.END)
                entries["Propietario"].insert(0, data["representanteLegal"])
                entries["Direccion"].delete(0, tk.END)
                entries["Direccion"].insert(0, data["direccion"])
                entries["Estrato"].delete(0, tk.END)
                entries["Estrato"].insert(0, data["estrato"])
                entries["Consumo m3"].delete(0, tk.END)
                entries["Consumo m3"].insert(0, data["consumo"])
                entries["Fecha Registro"].config(state="normal")
                entries["Fecha Registro"].delete(0, tk.END)
                entries["Fecha Registro"].insert(0, data["fechaRegistro"])
                entries["Fecha Registro"].config(state="readonly")
                entries["Valor factura"].delete(0, tk.END)
                entries["Valor factura"].insert(0, data["valorFactura"])
            else:
                messagebox.showerror("Error", f"Predio no encontrado. Código: {response.status_code}")
        except Exception as e:
            messagebox.showerror("Error", f"Error al consultar: {e}")

    def actualizar():
        try:
            id_ = entries["ID"].get().strip()
            if not id_.isdigit():
                messagebox.showerror("Error", "El ID debe ser un número entero.")
                return

            estrato = entries["Estrato"].get().strip()
            if not estrato.isdigit() or not (1 <= int(estrato) <= 6):
                messagebox.showerror("Error", "Estrato debe ser un número entre 1 y 6.")
                return

            consumo = entries["Consumo m3"].get().strip()
            if not consumo.replace('.', '', 1).isdigit():
                messagebox.showerror("Error", "Consumo debe ser un número positivo.")
                return

            datos = {
                "codigo": int(id_),
                "representanteLegal": entries["Propietario"].get().strip(),
                "direccion": entries["Direccion"].get().strip(),
                "estrato": int(estrato),
                "consumo": float(consumo)
            }

            response = requests.put(f"http://localhost:8091/predios/{id_}", json=datos)
            if response.status_code == 200:
                messagebox.showinfo("Éxito", "Predio actualizado exitosamente.")
            else:
                messagebox.showerror("Error", f"No se pudo actualizar el predio. Código: {response.status_code}")
        except Exception as e:
            messagebox.showerror("Error", f"Error al actualizar: {e}")

    frame_botones = tk.Frame(root)
    frame_botones.grid(row=len(labels), column=0, columnspan=2, pady=20)
    tk.Button(frame_botones, text="Consultar", command=consultar).pack(side="left", padx=10)
    tk.Button(frame_botones, text="Actualizar", command=actualizar).pack(side="right", padx=10)
