package acueducto.empresariales.services;

import acueducto.empresariales.model.Predio;
import acueducto.empresariales.repositories.PrediosRepository;

import java.util.List;
import java.util.Optional;

public interface IServicioPredio {

    Predio crearPredio (String representanteLegal, String direccion, int estrato, double consumo );
    List<Predio> getAllPredios();
    Optional<Predio> findById(Long id);
    boolean deleteById(Long id);
    Predio updateById(Long id, String representanteLegal, String direccion, int estrato, double consumo);
    List<Predio> findByEstratoLessThan(int estrato);
    List<Predio> findByEstratoGreaterThan(int estrato);
    List<Predio> findByEstratoRange(int estratoMin, int estratoMax);
    List<Predio> listarPrediosActivos();

}
