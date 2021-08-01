package tasks;

import javax.persistence.EntityManager;

public class t_02_ChangeCasing extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        entityManager.getTransaction().begin();

        var query = entityManager.createQuery("UPDATE Town SET name=UPPER(name) WHERE length(name) <= 5");

        query.executeUpdate();
        entityManager.getTransaction().commit();
    }
}
