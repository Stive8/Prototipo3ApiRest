package acueducto.empresariales.controller;

import acueducto.empresariales.dto.MedidorDTO;
import acueducto.empresariales.model.Medidor;
import acueducto.empresariales.model.Predio;
import acueducto.empresariales.services.IServicioMedidor;
import jakarta.validation.Valid;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import org.springframework.beans.factory.ObjectProvider;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping(value = "/medidores")
public class MedidorController {

    @Autowired
    private IServicioMedidor servicioMedidor;

    @PostMapping("/")
    public ResponseEntity<?> addMedidor(@Valid @RequestBody MedidorDTO dto){
        Medidor medidor = servicioMedidor.crearMedidor(dto);
        return ResponseEntity.status(HttpStatus.OK).body("Medidor Creado Exitosamente");
    }

    @GetMapping("/")
    public ResponseEntity<List<Medidor>> getAllMedidores() {
        List<Medidor> medidores = servicioMedidor.getAllMedidores();
        return ResponseEntity.ok(medidores);
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getMedidorById(@PathVariable Long id){
        Optional<Medidor> mediorOptional = servicioMedidor.findById(id);
        if (mediorOptional.isPresent()){
            return ResponseEntity.ok(mediorOptional.get());
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Medidor con id " + id +" no encontrado");
        }
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> updateMedidor(@PathVariable Long id, @Valid @RequestBody MedidorDTO dto) {
        try {
            Medidor medidorActualizado = servicioMedidor.updateById(id, dto);
            return ResponseEntity.ok("Medidor actualizado exitosamente con ID " + medidorActualizado.getId());
        } catch (ResponseStatusException ex) {
            return ResponseEntity.status(ex.getStatusCode()).body("No se ha encontrado el ID del predio ingresado");
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteMedidor(@PathVariable Long id){
        boolean deleted = servicioMedidor.deleteById(id);
        return deleted ? ResponseEntity.status(HttpStatus.OK).body("El Medidor con ID " + id + " eliminado correctamente.") :
                ResponseEntity.status(HttpStatus.NOT_FOUND).body("El Medir con ID " + id + " no existe.");
    }

    @GetMapping("/activos")
    public ResponseEntity<List<Medidor>> getPrediosActivos() {
        List<Medidor> activos = servicioMedidor.listarMedidoresActivos();
        return ResponseEntity.ok(activos);
    }

    @GetMapping("/byPredio/{idPredio}")
    public ResponseEntity<List<Medidor>> obtenerMedidoresPorPredio(@PathVariable Long idPredio) {
        List<Medidor> medidores = servicioMedidor.obtenerMedidoresPorPredio(idPredio);
        return ResponseEntity.ok(medidores);
    }


}
