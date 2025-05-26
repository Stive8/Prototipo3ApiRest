package acueducto.empresariales.services;


import acueducto.empresariales.dto.MedidorDTO;
import acueducto.empresariales.model.Medidor;
import acueducto.empresariales.model.Predio;
import acueducto.empresariales.repositories.MedidorRepository;
import acueducto.empresariales.repositories.PrediosRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

@Service
public class ServicioMedidor implements IServicioMedidor {

    @Autowired
    private MedidorRepository medidorRepository;

    @Autowired
    private PrediosRepository prediosRepository;

    @Override
    public Medidor crearMedidor(MedidorDTO dto) {

        Medidor medidor = new Medidor(dto.getMarca(), dto.getSerial(), dto.getDiametro() );

        if (dto.getIdPredio() != null) {
            Predio predio = prediosRepository.findById(dto.getIdPredio())
                    .orElseThrow(() -> new EntityNotFoundException("Predio no encontrado"));
            medidor.setPredio(predio);
        }

        return medidorRepository.save(medidor);

    }

    @Override
    public List<Medidor> getAllMedidores() {
        return medidorRepository.findAll();
    }

    @Override
    public Optional<Medidor> findById(long id) {
        return medidorRepository.findById(id);
    }

    @Override
    public boolean deleteById(long id) {
        Optional<Medidor> medidorOptional = medidorRepository.findById(id);
        if(medidorOptional.isPresent()){
            Medidor medidor = medidorOptional.get();
            medidor.setEstado(Predio.ESTADO_INACTIVO);
            medidorRepository.save(medidor);
            return true;
        }
        return false;
    }


    @Override
    public List<Medidor> listarMedidoresActivos() {
        return medidorRepository.findActivos("ACTIVO");
    }

    @Override
    public List<Medidor> obtenerMedidoresPorPredio(Long idPredio) {
        return medidorRepository.findByPredioId(idPredio);
    }


    @Override
    public Medidor updateById(Long id, MedidorDTO dto) {
        Medidor medidor = medidorRepository.findById(id)
                .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Medidor con ID " + id + " no encontrado"));

        medidor.setMarca(dto.getMarca());
        medidor.setDiametro(dto.getDiametro());
        medidor.setSerial(dto.getSerial()); // Ojo: no olvides el serial

        if (dto.getIdPredio() != null) {
            Predio predio = prediosRepository.findById(dto.getIdPredio())
                    .orElseThrow(() -> new ResponseStatusException(HttpStatus.NOT_FOUND, "Predio no encontrado"));
            medidor.setPredio(predio);
        }

        return medidorRepository.save(medidor);
    }

}
