import tkinter as tk
from tkinter import ttk, messagebox
from typing import List
from utils import centrar_ventana
from Controller.ApiServiceMedidor import ApiServiceMedidor
from Model.Medidor.Medidor import Medidor


class GUIListarMedidor:
    def __init__(self, root):
        self.api_service = ApiServiceMedidor()
        self.root = root
        self.root.title("Listar Medidores")
        centrar_ventana(root)
        self.root.resizable(False, False)

        # Columnas a mostrar
        columns = ("ID", "Marca", "Serial", "Diametro", "Fecha Instalación", "Estado", "ID Predio")
        self.tree = ttk.Treeview(self.root, columns=columns, show="headings", height=10)

        for col in columns:
            self.tree.heading(col, text=col)
            self.tree.column(col, width=100)

        self.tree.grid(row=0, column=0, columnspan=4, padx=10, pady=10)

        # Checkbox: Activo
        self.activo_var = tk.BooleanVar()
        self.rb_activo = tk.Checkbutton(self.root, text="Solo Activos", variable=self.activo_var, command=self.filtrar_activos)
        self.rb_activo.grid(row=1, column=0, sticky="w", padx=10)

        # Label y Entry para filtrar por predio
        tk.Label(self.root, text="Filtrar por ID de Predio:").grid(row=1, column=1, sticky="e")
        self.txt_predio = tk.Entry(self.root, width=10)
        self.txt_predio.grid(row=1, column=2, sticky="w")

        self.btn_filtrar = tk.Button(self.root, text="Filtrar", command=self.filtrar_por_predio)
        self.btn_filtrar.grid(row=1, column=3, padx=5, pady=5)

        # Botón Listar todos
        self.btn_listar = tk.Button(self.root, text="Listar Todos", width=15, command=self.listar_todos)
        self.btn_listar.grid(row=2, column=3, padx=5, pady=5, sticky="e")

    def mostrar_en_tabla(self, lista: List[Medidor], mensaje_vacio: str):
        self.tree.delete(*self.tree.get_children())
        if lista:
            for m in lista:
                self.tree.insert("", "end", values=(
                    m.id,
                    m.marca,
                    m.serial,
                    m.diametro,
                    m.fecha_instalacion.strftime("%Y-%m-%d") if m.fecha_instalacion else "",
                    m.estado,
                    m.id_predio
                ))
        else:
            messagebox.showinfo("Sin resultados", mensaje_vacio)

    def listar_todos(self):
        try:
            medidores = self.api_service.get_medidores()
            self.mostrar_en_tabla(medidores, "No se encontraron medidores.")
        except Exception as ex:
            messagebox.showerror("Error", f"Error al listar los medidores: {ex}")

    def filtrar_activos(self):
        if self.activo_var.get():
            try:
                activos = self.api_service.get_medidores_activos()
                self.mostrar_en_tabla(activos, "No hay medidores activos.")
            except Exception as ex:
                messagebox.showerror("Error", f"Error al filtrar activos: {ex}")
        else:
            self.listar_todos()  # Si se desmarca, mostrar todos

    def filtrar_por_predio(self):
        try:
            texto = self.txt_predio.get().strip()
            if not texto.isdigit():
                messagebox.showwarning("Entrada inválida", "Ingrese un ID de predio válido.")
                return
            id_predio = int(texto)
            filtrados = self.api_service.get_medidores_por_predio(id_predio)
            self.mostrar_en_tabla(filtrados, "No se encontraron medidores para el ID ingresado.")
        except Exception as ex:
            messagebox.showerror("Error", f"Error al filtrar por predio: {ex}")


if __name__ == "__main__":
    root = tk.Tk()
    app = GUIListarMedidor(root)
    root.mainloop()
