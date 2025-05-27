from datetime import datetime

class RequestMedidor:
    def __init__(self, marca: str, serial: str, diametro: float, fecha_instalacion: datetime, estado: str, id_predio: int):
        self.marca = marca
        self.serial = serial
        self.diametro = diametro
        self.fecha_instalacion = fecha_instalacion
        self.estado = estado
        self.id_predio = id_predio

    @classmethod
    def from_dict(cls, data: dict):
        return cls(
            marca=data.get("marca", ""),
            serial=data.get("serial", ""),
            diametro=data.get("diametro", 0.0),
            fecha_instalacion=datetime.fromisoformat(data.get("fechaInstalacion")) if data.get("fechaInstalacion") else None,
            estado=data.get("estado", ""),
            id_predio=data.get("idPredio", 0)
        )

    def to_dict(self):
        return {
            "marca": self.marca,
            "serial": self.serial,
            "diametro": self.diametro,
            "fechaInstalacion": self.fecha_instalacion.isoformat() if self.fecha_instalacion else None,
            "estado": self.estado,
            "idPredio": self.id_predio
        }
