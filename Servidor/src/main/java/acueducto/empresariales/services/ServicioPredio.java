package acueducto.empresariales.services;

import acueducto.empresariales.model.Predio;
import acueducto.empresariales.repositories.PrediosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;

@Service
public class ServicioPredio implements IServicioPredio {

    @Autowired
    private PrediosRepository prediosRepository;


    @Override
    public Predio crearPredio(String representanteLegal, String direccion, int estrato, double consumo) {
        Predio predio = new Predio();
        predio.setRepresentanteLegal(representanteLegal);
        predio.setDireccion(direccion);
        predio.setEstrato(estrato);
        predio.setConsumo(consumo);
        predio.setValorFactura(calcularValorFactura(consumo, estrato));
        predio.setFechaRegistro(LocalDate.now());
        return prediosRepository.save(predio);
    }

    @Override
    public List<Predio> getAllPredios() {
        return prediosRepository.findAll();
    }

    @Override
    public Optional<Predio> findById(Long id){
        return prediosRepository.findById(id);
    }

    @Override
    public boolean deleteById(Long id){
        if(prediosRepository.existsById(id)){
            prediosRepository.deleteById(id);
            return true;
        }
        return false;
    }

    @Override
    public Predio updateById(Long id, String representanteLegal, String direccion, int estrato, double consumo) {
        Optional<Predio> predioOptional = prediosRepository.findById(id);
        if (predioOptional.isPresent()) {
            Predio predio = predioOptional.get();
            predio.setRepresentanteLegal(representanteLegal);
            predio.setDireccion(direccion);
            predio.setEstrato(estrato);
            predio.setConsumo(consumo);
            predio.setValorFactura(calcularValorFactura(consumo, estrato));
            return prediosRepository.save(predio);
        }
        throw new RuntimeException("Predio con ID " + id + " no encontrado");
    }

    @Override
    public List<Predio> findByEstratoGreaterThan(int estrato) {
        return prediosRepository.findByEstratoGreaterThan(estrato);
    }

    @Override
    public List<Predio> findByEstratoLessThan(int estrato) {
        return prediosRepository.findByEstratoLessThan(estrato);
    }

    @Override
    public List<Predio> findByEstratoRange(int estratoMin, int estratoMax) {
        return prediosRepository.findByEstratoBetween(estratoMin, estratoMax);
    }

    private double calcularValorFactura(double consumo, int estrato) {
        double tarifaBase;

        // Ejemplo: tarifas ficticias por estrato
        switch (estrato) {
            case 1 -> tarifaBase = 100;
            case 2 -> tarifaBase = 300;
            case 3 -> tarifaBase = 5000;
            case 4 -> tarifaBase = 800;
            case 5 -> tarifaBase = 1000;
            case 6 -> tarifaBase = 1500;
            default -> tarifaBase = 2000;
        }

        return consumo * tarifaBase;
    }

}
