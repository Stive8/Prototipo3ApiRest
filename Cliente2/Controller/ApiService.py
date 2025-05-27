import requests
from typing import List
from Model.Predio.Residencial import Residencial

class ApiService:
    def __init__(self):
        self.base_url = "http://localhost:8091/predios/"

    def get_residenciales(self) -> List[Residencial]:
        try:
            response = requests.get(self.base_url)
            if response.status_code == 200:
                data = response.json()
                return [Residencial.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener residenciales: {e}")
            return []

    def get_residenciales_by_estrato_greater(self, estrato: int) -> List[Residencial]:
        try:
            response = requests.get(f"{self.base_url}estrato/greater/{estrato}")
            if response.status_code == 200:
                data = response.json()
                return [Residencial.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener residenciales con estrato mayor: {e}")
            return []

    def get_residenciales_by_estrato_less(self, estrato: int) -> List[Residencial]:
        try:
            response = requests.get(f"{self.base_url}estrato/less/{estrato}")
            if response.status_code == 200:
                data = response.json()
                return [Residencial.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener residenciales con estrato menor: {e}")
            return []

    def get_residenciales_by_estrato_range(self, min_estrato: int, max_estrato: int) -> List[Residencial]:
        try:
            response = requests.get(f"{self.base_url}estrato/rango", params={"min": min_estrato, "max": max_estrato})
            if response.status_code == 200:
                data = response.json()
                return [Residencial.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener residenciales en rango de estrato: {e}")
            return []
