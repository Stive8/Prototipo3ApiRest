import requests
from typing import List
from Model.Medidor.Medidor import Medidor  # Asegúrate de que la ruta sea correcta

class ApiServiceMedidor:
    def __init__(self):
        self.base_url = "http://localhost:8091/medidores/"

    def get_medidores(self) -> List[Medidor]:
        try:
            response = requests.get(self.base_url)
            if response.status_code == 200:
                data = response.json()
                return [Medidor.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener medidores: {e}")
            return []

    def get_medidores_activos(self) -> List[Medidor]:
        try:
            response = requests.get(f"{self.base_url}activos")
            if response.status_code == 200:
                data = response.json()
                return [Medidor.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener medidores activos: {e}")
            return []

    def get_medidores_por_predio(self, id_predio: int) -> List[Medidor]:
        try:
            response = requests.get(f"{self.base_url}byPredio/{id_predio}")
            if response.status_code == 200:
                data = response.json()
                return [Medidor.from_dict(item) for item in data]
            return []
        except requests.RequestException as e:
            print(f"Error al obtener medidores por predio: {e}")
            return []
