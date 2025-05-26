package acueducto.empresariales.dto;

import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import lombok.Data;

@Data
public class MedidorDTO {

    @NotBlank(message = "La marca es obligatoria")
    private String marca;

    @NotBlank(message = "El serial es obligatorio")
    private String serial;

    @NotNull(message = "El diametro es obligatorio")
    @Min(value = 0, message = "El diametro no puede ser menor a 0")
    private Double diametro;

    private Long idPredio;

}
