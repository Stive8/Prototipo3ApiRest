package acueducto.empresariales.controller;


import acueducto.empresariales.dto.PredioDTO;
import acueducto.empresariales.model.Predio;
import acueducto.empresariales.services.ServicioPredio;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(value = "/predios")
public class PredioController {

    @Autowired
    private ServicioPredio servicioPredio;

    @GetMapping(value = "/healthCheck")
    public String healthCheck() {
        return "OK";
    }


    @PostMapping("/")
    public ResponseEntity<?> addPredio(@Valid @RequestBody PredioDTO predioDTO) {
        Predio nuevoPredio = servicioPredio.crearPredio(
                predioDTO.getRepresentanteLegal(),
                predioDTO.getDireccion(),
                predioDTO.getEstrato(),
                predioDTO.getConsumo()
        );
        return ResponseEntity.status(HttpStatus.OK).body("Predio creado exitosamente");
    }

    @GetMapping("/")
    public ResponseEntity<List<Predio>> getAllPredios() {
        List<Predio> predios = servicioPredio.getAllPredios();
        return ResponseEntity.ok(predios);
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getPredioById(@PathVariable Long id) {
        Optional<Predio> predioOptional = servicioPredio.findById(id);
        if (predioOptional.isPresent()) {
            return ResponseEntity.ok(predioOptional.get());
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("El predio con ID " + id + " no existe.");
        }
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> updatePredio(@PathVariable Long id, @Valid @RequestBody PredioDTO predioDTO) {
        try {
            Predio updatedPredio = servicioPredio.updateById(
                    id,
                    predioDTO.getRepresentanteLegal(),
                    predioDTO.getDireccion(),
                    predioDTO.getEstrato(),
                    predioDTO.getConsumo()
            );
            return ResponseEntity.status(HttpStatus.OK).body("El predio con ID " + id + " se ha actualizado correctamente.");
        } catch (RuntimeException e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("El predio con ID " + id + " no existe.");
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> deletePredio(@PathVariable Long id) {
        boolean deleted = servicioPredio.deleteById(id);
        return deleted ? ResponseEntity.status(HttpStatus.OK).body("El predio con ID " + id + " eliminado correctamente.") :
                ResponseEntity.status(HttpStatus.NOT_FOUND).body("El predio con ID " + id + " no existe.");
    }

    @GetMapping("/estrato/greater/{estrato}")
    public ResponseEntity<?> getPrediosByEstratoGreaterThan(@PathVariable int estrato) {
        List<Predio> predios = servicioPredio.findByEstratoGreaterThan(estrato);
        if (!predios.isEmpty()) {
            return ResponseEntity.ok(predios);
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("No hay predios que cumplan con el criterio");
        }
    }

    @GetMapping("/estrato/less/{estrato}")
    public ResponseEntity<?> getPrediosByEstratoLessThan(@PathVariable int estrato) {
        List<Predio> predios = servicioPredio.findByEstratoLessThan(estrato);
        if (!predios.isEmpty()) {
            return ResponseEntity.ok(predios);
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("No hay predios que cumplan con el criterio");
        }
    }

    @GetMapping("/estrato/rango")
    public ResponseEntity<?> getPrediosByEstratoRange(
            @RequestParam int min,
            @RequestParam int max) {
        List<Predio> predios = servicioPredio.findByEstratoRange(min, max);
        if (!predios.isEmpty()) {
            return ResponseEntity.ok(predios);
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("No hay predios que cumplan con el criterio");
        }
    }

}
