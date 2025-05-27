from datetime import datetime
from Model.Predio.Residencial import Residencial

class Medidor:
    def __init__(self, id: int, marca: str, serial: str, diametro: float,
                 fecha_instalacion: datetime, estado: str, predio: Residencial = None):
        self.id = id
        self.marca = marca
        self.serial = serial
        self.diametro = diametro
        self.fecha_instalacion = fecha_instalacion
        self.estado = estado
        self.predio = predio  # Instancia de Residencial o None

    @property
    def id_predio(self):
        return self.predio.id if self.predio else None

    @classmethod
    def from_dict(cls, data: dict):
        predio_data = data.get("predio")
        predio_obj = Residencial.from_dict(predio_data) if predio_data else None

        return cls(
            id=data.get("id", 0),
            marca=data.get("marca", ""),
            serial=data.get("serial", ""),
            diametro=data.get("diametro", 0.0),
            fecha_instalacion=datetime.fromisoformat(data.get("fechaInstalacion")) if data.get("fechaInstalacion") else None,
            estado=data.get("estado", ""),
            predio=predio_obj
        )

    def to_dict(self):
        return {
            "id": self.id,
            "marca": self.marca,
            "serial": self.serial,
            "diametro": self.diametro,
            "fechaInstalacion": self.fecha_instalacion.isoformat() if self.fecha_instalacion else None,
            "estado": self.estado,
            "predio": self.predio.to_dict() if self.predio else None
        }
