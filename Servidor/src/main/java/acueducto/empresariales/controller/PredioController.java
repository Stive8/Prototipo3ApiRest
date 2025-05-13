package acueducto.empresariales.controller;


import acueducto.empresariales.dto.PredioDTO;
import acueducto.empresariales.model.Predio;
import acueducto.empresariales.services.ServicioPredio;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

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
    public ResponseEntity<Predio> addPredio(@Valid @RequestBody PredioDTO predioDTO) {
        Predio nuevoPredio = servicioPredio.crearPredio(
                predioDTO.getRepresentanteLegal(),
                predioDTO.getDireccion(),
                predioDTO.getEstrato(),
                predioDTO.getConsumo()
        );
        return ResponseEntity.ok(nuevoPredio);
    }

    @GetMapping("/")
    public ResponseEntity<List<Predio>> getAllPredios() {
        List<Predio> predios = servicioPredio.getAllPredios();
        return ResponseEntity.ok(predios);
    }

}
