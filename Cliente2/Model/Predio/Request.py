from datetime import datetime

class Request:
    def __init__(
        self,
        codigo: int,
        representante_legal: str,
        direccion: str,
        fecha_registro: datetime,
        estrato: int,
        consumo: float,
        valor_factura: float,
        estado: str
    ):
        self.codigo = codigo
        self.representante_legal = representante_legal
        self.direccion = direccion
        self.fecha_registro = fecha_registro
        self.estrato = estrato
        self.consumo = consumo
        self.valor_factura = valor_factura
        self.estado = estado

    @classmethod
    def from_dict(cls, data: dict):
        return cls(
            codigo=data.get("codigo", 0),
            representante_legal=data.get("representanteLegal", ""),
            direccion=data.get("direccion", ""),
            fecha_registro=datetime.fromisoformat(data.get("fechaRegistro")) if data.get("fechaRegistro") else None,
            estrato=data.get("estrato", 0),
            consumo=data.get("consumo", 0.0),
            valor_factura=data.get("valorFactura", 0.0),
            estado=data.get("estado", "")
        )

    def to_dict(self) -> dict:
        return {
            "codigo": self.codigo,
            "representanteLegal": self.representante_legal,
            "direccion": self.direccion,
            "fechaRegistro": self.fecha_registro.isoformat() if self.fecha_registro else None,
            "estrato": self.estrato,
            "consumo": self.consumo,
            "valorFactura": self.valor_factura,
            "estado": self.estado
        }
