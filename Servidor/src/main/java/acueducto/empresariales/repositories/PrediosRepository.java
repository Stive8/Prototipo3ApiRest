package acueducto.empresariales.repositories;

import acueducto.empresariales.model.Predio;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface PrediosRepository extends JpaRepository <Predio, Long> {

    @Query("SELECT p FROM Predio p WHERE p.estrato > :estrato")
    List<Predio> findByEstratoGreaterThan(@Param("estrato") int estrato);

    // Predios con estrato menor que un valor
    @Query("SELECT p FROM Predio p WHERE p.estrato < :estrato")
    List<Predio> findByEstratoLessThan(@Param("estrato") int estrato);

    // Predios con estrato en un rango (entre min y max, inclusive)
    @Query("SELECT p FROM Predio p WHERE p.estrato BETWEEN :min AND :max")
    List<Predio> findByEstratoBetween(@Param("min") int estratoMin, @Param("max") int estratoMax);

}
