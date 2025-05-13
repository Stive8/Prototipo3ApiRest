package acueducto.empresariales.dto;

import jakarta.validation.constraints.Max;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import lombok.Data;

@Data
public class PredioDTO {

    @NotBlank(message = "El representante legal es obligatorio")
    private String representanteLegal;

    @NotBlank(message = "La dirección es obligatoria")
    private String direccion;

    @NotNull(message = "El estrato es obligatorio")
    @Min(value = 1, message = "El estrato debe ser al menos 1")
    @Max(value = 6, message = "El estrato maximo es 6")
    private Integer estrato;

    @NotNull(message = "El consumo es obligatorio")
    @Min(value = 0, message = "El consumo no puede ser negativo")
    private Double consumo;
}
