import tkinter as tk
from tkinter import ttk, messagebox
from Controller.ApiService import ApiService
from utils import centrar_ventana


def GUIListar(root):
    root.title("Listar Predios")
    centrar_ventana(root)

    # Columnas a mostrar
    columns = ("id", "representante_legal", "direccion", "fecha_registro", "estrato", "consumo", "valor_factura", "estado")
    tree = ttk.Treeview(root, columns=columns, show="headings", height=12)

    # Encabezados y ancho de columnas
    for col in columns:
        tree.heading(col, text=col.replace("_", " ").capitalize())
        tree.column(col, width=120)

    tree.grid(row=0, column=0, columnspan=4, padx=10, pady=10)

    api = ApiService()

    # Función para mostrar resultados en la tabla
    def mostrar_resultados(predios):
        tree.delete(*tree.get_children())
        if predios:
            for p in predios:
                tree.insert("", "end", values=(
                    p.id,
                    p.representante_legal,
                    p.direccion,
                    p.fecha_registro.strftime("%Y-%m-%d") if p.fecha_registro else "",
                    p.estrato,
                    p.consumo,
                    p.valor_factura,
                    p.estado
                ))
        else:
            messagebox.showinfo("Sin resultados", "No se encontraron registros.")

    # Botón Listar Todos
    def listar_todos():
        try:
            predios = api.get_residenciales()
            mostrar_resultados(predios)
        except Exception as e:
            messagebox.showerror("Error", str(e))

    # Marco de radios para estrato bajo o alto
    marco_radios = tk.LabelFrame(root, text="Filtrar Estratos")
    marco_radios.grid(row=1, column=0, padx=10, pady=10)

    estrato_var = tk.StringVar()

    def filtrar_por_estrato():
        try:
            if estrato_var.get() == "bajo":
                predios = api.get_residenciales_by_estrato_less(4)
            elif estrato_var.get() == "alto":
                predios = api.get_residenciales_by_estrato_greater(3)
            else:
                predios = []
            mostrar_resultados(predios)
        except Exception as e:
            messagebox.showerror("Error", str(e))

    tk.Radiobutton(marco_radios, text="Estrato 1,2,3", variable=estrato_var, value="bajo",
                   command=filtrar_por_estrato).pack(anchor="w")
    tk.Radiobutton(marco_radios, text="Estrato 4,5,6", variable=estrato_var, value="alto",
                   command=filtrar_por_estrato).pack(anchor="w")

    # Marco de rango
    marco_rango = tk.LabelFrame(root, text="Filtrar Estratos Por Rango")
    marco_rango.grid(row=1, column=1, padx=10, pady=10)

    tk.Label(marco_rango, text="MIN").grid(row=0, column=0)
    min_entry = tk.Entry(marco_rango, width=5)
    min_entry.grid(row=0, column=1)

    tk.Label(marco_rango, text="MAX").grid(row=0, column=2)
    max_entry = tk.Entry(marco_rango, width=5)
    max_entry.grid(row=0, column=3)

    def filtrar_rango():
        try:
            min_val = int(min_entry.get().strip())
            max_val = int(max_entry.get().strip())

            if min_val < 1 or max_val > 6 or min_val > max_val:
                raise ValueError("Los valores deben estar entre 1 y 6, y MIN debe ser menor o igual a MAX.")

            predios = api.get_residenciales_by_estrato_range(min_val, max_val)
            mostrar_resultados(predios)
        except ValueError as e:
            messagebox.showwarning("Entrada inválida", str(e))
        except Exception as e:
            messagebox.showerror("Error", str(e))

    tk.Button(marco_rango, text="Filtrar", command=filtrar_rango).grid(row=1, column=0, columnspan=4, pady=5)

    # Botón Listar
    btn_listar = tk.Button(root, text="Listar", width=10, command=listar_todos)
    btn_listar.grid(row=1, column=3, padx=10, pady=10)

