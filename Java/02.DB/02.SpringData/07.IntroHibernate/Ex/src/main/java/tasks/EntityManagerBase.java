package tasks;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class EntityManagerBase {
    private final static EntityManager entityManager;
    private final static BufferedReader bufferedReader;

    static {
        EntityManagerFactory emf = Persistence
                .createEntityManagerFactory("softuni");

        entityManager = emf.createEntityManager();
        bufferedReader = new BufferedReader(new InputStreamReader(System.in));;
    }

    protected static EntityManager getEntityManager(){
        return entityManager;
    }
    protected static BufferedReader getBufferedReader(){
        return bufferedReader;
    }
}
