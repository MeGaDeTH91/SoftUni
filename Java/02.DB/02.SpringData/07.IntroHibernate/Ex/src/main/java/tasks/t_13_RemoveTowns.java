package tasks;

import entities.Address;
import entities.Employee;
import entities.Town;

import javax.persistence.EntityManager;
import java.io.BufferedReader;
import java.io.IOException;

public class t_13_RemoveTowns extends EntityManagerBase {
    public static void main(String[] args) throws IOException {
        EntityManager entityManager = getEntityManager();
        BufferedReader bufferedReader = getBufferedReader();

        String townName = bufferedReader.readLine();

        Town town;

        try {
            town = entityManager
                    .createQuery("SELECT t FROM Town t WHERE t.name=:twnName",
                            Town.class)
                    .setParameter("twnName", townName)
                    .getSingleResult();

            int numberOfAddresses = removeAddresses(entityManager, town);

            entityManager.getTransaction().begin();
            entityManager.remove(town);
            entityManager.getTransaction().commit();

            String addressWithSuffix = numberOfAddresses == 1 ? "address" : "addresses";
            System.out.printf("%d %s in %s deleted" + System.lineSeparator(),
                    numberOfAddresses,
                    addressWithSuffix,
                    townName);

        } catch (Exception e) {
            System.out.println("No such town or DB error.");
        }
    }

    private static int removeAddresses(EntityManager entityManager, Town town) {
        var addresses = entityManager
                .createQuery("SELECT a FROM Address a WHERE a.town.id=:twnId", Address.class)
                .setParameter("twnId", town.getId())
                .getResultList();


        for (Address addr: addresses) {
            var employees = entityManager.createQuery("SELECT e FROM Employee e WHERE e.address.id=:addrId", Employee.class)
                    .setParameter("addrId", addr.getId())
                    .getResultList();

            entityManager.getTransaction().begin();
            employees.forEach(e -> e.setAddress(null));
            entityManager.getTransaction().commit();

            entityManager.getTransaction().begin();
            entityManager.remove(addr);
            entityManager.getTransaction().commit();
        }

        return addresses.size();
    }
}
