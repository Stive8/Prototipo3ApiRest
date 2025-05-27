import tkinter as tk
from tkinter import messagebox

# Importaciones para ventanas de predio
from View.Predio.GUICrear import GUICrear
from View.Predio.GUIListar import GUIListar
from View.Predio.GUIConsultar import GUIConsultar
from View.Predio.GUIActualizar import GUIActualizar
from View.Predio.GUIEliminar import GUIEliminar

# Importaciones para ventanas de medidor
from View.Medidor.GUICrearMedidor import GUICrearMedidor
from View.Medidor.GUIListarMedidor import GUIListarMedidor
from View.Medidor.GUIConsultarMedidor import GUIConsultarMedidor
from View.Medidor.GUIActualizarMedidor import GUIActualizarMedidor
from View.Medidor.GUIEliminarMedidor import GUIEliminarMedidor

from utils import centrar_ventana


def mostrar_ayuda():
    ventana_ayuda = tk.Toplevel()
    ventana_ayuda.title("Ayuda - Integrantes")
    ventana_ayuda.geometry("300x150")

    titulo = tk.Label(ventana_ayuda, text="Integrantes", font=("Arial", 14, "bold"))
    titulo.pack(pady=10)

    integrantes = [
        "Stiven Alvarez",
        "Brayhan Ortegon",
        "Juanita Rodriguez"
    ]
    for nombre in integrantes:
        tk.Label(ventana_ayuda, text=nombre, font=("Arial", 12)).pack()
    
    ventana_ayuda.update()
    centrar_ventana(ventana_ayuda)

def abrir_ventana(gui_clase, parent):
    ventana = tk.Toplevel(parent)
    ventana.update()
    centrar_ventana(ventana)
    gui_clase(ventana)


def main():
    root = tk.Tk()
    root.title("Sistema de Gestión de Predios y Medidores")
    root.geometry("500x300")
    root.update()
    centrar_ventana(root)
    

    # Crear la barra de menú
    barra_menu = tk.Menu(root)

    # Menú de Predio
    menu_predio = tk.Menu(barra_menu, tearoff=0)
    menu_predio.add_command(label="Crear", command=lambda: abrir_ventana(GUICrear, root))
    menu_predio.add_command(label="Listar", command=lambda: abrir_ventana(GUIListar, root))
    menu_predio.add_command(label="Consultar", command=lambda: abrir_ventana(GUIConsultar, root))
    menu_predio.add_command(label="Actualizar", command=lambda: abrir_ventana(GUIActualizar, root))
    menu_predio.add_command(label="Eliminar", command=lambda: abrir_ventana(GUIEliminar, root))
    barra_menu.add_cascade(label="Predio", menu=menu_predio)

    # Menú de Medidor
    menu_medidor = tk.Menu(barra_menu, tearoff=0)
    menu_medidor.add_command(label="Crear", command=lambda: abrir_ventana(GUICrearMedidor, root))
    menu_medidor.add_command(label="Listar", command=lambda: abrir_ventana(GUIListarMedidor, root))
    menu_medidor.add_command(label="Consultar", command=lambda: abrir_ventana(GUIConsultarMedidor, root))
    menu_medidor.add_command(label="Actualizar", command=lambda: abrir_ventana(GUIActualizarMedidor, root))
    menu_medidor.add_command(label="Eliminar", command=lambda: abrir_ventana(GUIEliminarMedidor, root))
    barra_menu.add_cascade(label="Medidor", menu=menu_medidor)

    # Menú de Ayuda
    barra_menu.add_command(label="Ayuda", command=mostrar_ayuda)

    # Configurar el menú en la ventana principal
    root.config(menu=barra_menu)

    # Ejecutar la aplicación
    root.mainloop()

if __name__ == "__main__":
    main()
