def centrar_ventana(ventana):
    ventana.update_idletasks()  # Asegura que tamaño actual esté calculado
    ancho = ventana.winfo_width()
    alto = ventana.winfo_height()
    x = (ventana.winfo_screenwidth() // 2) - (ancho // 2)
    y = (ventana.winfo_screenheight() // 2) - (alto // 2)
    ventana.geometry(f"+{x}+{y}")
