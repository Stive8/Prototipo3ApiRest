package acueducto.empresariales.services;

import acueducto.empresariales.dto.MedidorDTO;
import acueducto.empresariales.model.Medidor;

import java.util.List;
import java.util.Optional;

public interface IServicioMedidor {

    Medidor crearMedidor (MedidorDTO dto);
    List<Medidor> getAllMedidores();
    Optional<Medidor> findById(long id);
    boolean deleteById(long id);
    Medidor updateById(Long id, MedidorDTO dto);
    List<Medidor> listarMedidoresActivos();
    List<Medidor> obtenerMedidoresPorPredio(Long idPredio);

}
