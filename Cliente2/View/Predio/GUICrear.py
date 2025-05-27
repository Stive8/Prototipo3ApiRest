import tkinter as tk
from tkinter import messagebox
import requests
from utils import centrar_ventana

def GUICrear(root):
    root.title("Crear Predio")
    centrar_ventana(root)

    # Etiquetas y entradas
    etiquetas = ["Propietario", "Dirección", "Estrato", "Consumo m3"]
    entradas = {}

    for i, texto in enumerate(etiquetas):
        tk.Label(root, text=texto + ":", font=("Arial", 12)).grid(row=i, column=0, sticky="e", padx=10, pady=5)
        entrada = tk.Entry(root, width=30)
        entrada.grid(row=i, column=1, padx=10, pady=5)
        entradas[texto.lower()] = entrada

    def crear_predio():
        try:
            representante_legal = entradas["propietario"].get().strip()
            direccion = entradas["dirección"].get().strip()
            estrato_str = entradas["estrato"].get().strip()
            consumo_str = entradas["consumo m3"].get().strip()

            if not all([representante_legal, direccion, estrato_str, consumo_str]):
                messagebox.showwarning("Campos incompletos", "Por favor complete todos los campos antes de continuar.")
                return

            if not representante_legal.replace(" ", "").isalpha():
                messagebox.showerror("Error de formato", "El campo 'Propietario' solo debe contener letras.")
                return

            try:
                estrato = int(estrato_str)
                if estrato < 1 or estrato > 6:
                    raise ValueError("Estrato fuera de rango")
            except ValueError:
                messagebox.showerror("Error de formato", "El campo 'Estrato' debe ser un número entero entre 1 y 6.")
                return

            try:
                consumo = float(consumo_str)
            except ValueError:
                messagebox.showerror("Error de formato", "El campo 'Consumo' debe ser un número decimal válido.")
                return

            datos = {
                "representanteLegal": representante_legal,
                "direccion": direccion,
                "estrato": estrato,
                "consumo": consumo
            }

            response = requests.post("http://localhost:8091/predios/", json=datos)

            if response.ok:
                messagebox.showinfo("Éxito", f"Registro creado exitosamente. Código de respuesta: {response.status_code}")
                root.destroy()
            else:
                messagebox.showerror("Error en respuesta", f"Error al crear el registro. Código: {response.status_code}\nDetalle: {response.text}")

        except requests.exceptions.RequestException as e:
            messagebox.showerror("Error de red", f"Error: {str(e)}")
        except Exception as ex:
            messagebox.showerror("Error inesperado", f"{str(ex)}")

    boton_guardar = tk.Button(root, text="Crear", command=crear_predio, bg="blue", fg="white", font=("Arial", 12))
    boton_guardar.grid(row=len(etiquetas), column=0, columnspan=2, pady=15)

    root.mainloop()
