package acueducto.empresariales.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "PREDIOS")
public class Predio {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long codigo;

    private String representanteLegal;
    private String direccion;
    private LocalDate fechaRegistro;
    private int estrato;
    private double consumo;
    private double valorFactura;

}
