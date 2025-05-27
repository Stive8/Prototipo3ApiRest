package acueducto.empresariales.repositories;

import acueducto.empresariales.model.Medidor;
import acueducto.empresariales.model.Predio;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Jpa21Utils;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface MedidorRepository extends JpaRepository<Medidor, Long> {

    List<Medidor> findByEstado(String estado);

    @Query("SELECT m FROM Medidor m WHERE m.predio.id = :idPredio")
    List<Medidor> findByPredioId(@Param("idPredio") Long idPredio);

}
