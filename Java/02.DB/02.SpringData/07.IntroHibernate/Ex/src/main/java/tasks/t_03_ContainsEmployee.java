package tasks;

import javax.persistence.EntityManager;
import java.io.IOException;

public class t_03_ContainsEmployee extends EntityManagerBase {
    public static void main(String[] args) throws IOException {
        EntityManager entityManager = getEntityManager();

        var reader = getBufferedReader();

        var name = reader.readLine().split("\\s+");
        var firstName=  name[0];
        var lastName=  name[1];

        var query = entityManager.createQuery("SELECT e FROM Employee e " +
                "WHERE e.firstName = :firstName AND e.lastName = :lastName");
        query.setParameter("firstName", firstName);
        query.setParameter("lastName", lastName);

        var res = query.getResultList();

        if (res.isEmpty()) {
            System.out.println("No");
        } else {
            System.out.println("Yes");
        }
    }
}
