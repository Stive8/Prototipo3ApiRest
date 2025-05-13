package acueducto.empresariales.services;

import acueducto.empresariales.model.Predio;
import acueducto.empresariales.repositories.PrediosRepository;

import java.util.List;

public interface IServicioPredio {

    Predio crearPredio (String representanteLegal, String direccion, int estrato, double consumo );
    void agregarPredio (Predio predio);
    Predio addPredio (Predio predio);
    List<Predio> getAllPredios();

}
