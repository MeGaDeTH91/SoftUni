package imdb.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import imdb.entity.Film;

public interface FilmRepository extends JpaRepository<Film, Integer> {
}
