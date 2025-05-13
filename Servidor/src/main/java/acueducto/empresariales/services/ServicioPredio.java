package acueducto.empresariales.services;

import acueducto.empresariales.model.Predio;
import acueducto.empresariales.repositories.PrediosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.List;

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
    public void agregarPredio(Predio predio) {

    }

    @Override
    public Predio addPredio(Predio predio) {
        Predio pre = null;
        pre = prediosRepository.save(pre);
        return pre;
    }

    private double calcularValorFactura(double consumo, int estrato) {
        double tarifaBase;

        // Ejemplo: tarifas ficticias por estrato
        switch (estrato) {
            case 1 -> tarifaBase = 500;
            case 2 -> tarifaBase = 800;
            case 3 -> tarifaBase = 1000;
            case 4 -> tarifaBase = 1200;
            case 5 -> tarifaBase = 1500;
            default -> tarifaBase = 2000;
        }

        return consumo * tarifaBase;
    }

}
