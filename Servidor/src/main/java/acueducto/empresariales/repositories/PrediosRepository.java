package acueducto.empresariales.repositories;

import acueducto.empresariales.model.Predio;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface PrediosRepository extends JpaRepository <Predio, Long> {
}
