package acueducto.empresariales.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@NoArgsConstructor
@Entity
@Table(name = "MEDIDORES")
public class Medidor {

    public static final String ESTADO_ACTIVO = "ACTIVO";
    public static final String ESTADO_INACTIVO = "INACTIVO";


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    private String marca;
    private String serial;
    private Double diametro;
    private LocalDate fechaInstalacion;

    @ManyToOne
    @JoinColumn(name = "predio_id")
    private Predio predio;
    private String estado;



    public Medidor(String marca, String serial, double diametro, Predio predio) {
        this.marca = marca;
        this.serial = serial;
        this.diametro = diametro;
        this.predio = predio;
        this.fechaInstalacion = LocalDate.now();
        this.estado = Medidor.ESTADO_ACTIVO;
    }


    public Medidor(String marca, String serial, double diametro) {
        this(marca, serial, diametro, null);
    }


}
