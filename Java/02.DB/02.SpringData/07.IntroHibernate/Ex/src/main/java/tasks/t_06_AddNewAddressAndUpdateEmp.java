package tasks;

import entities.Address;
import entities.Employee;

import javax.persistence.EntityManager;
import java.io.BufferedReader;
import java.io.IOException;

public class t_06_AddNewAddressAndUpdateEmp extends EntityManagerBase {
    public static void main(String[] args) throws IOException {
        EntityManager entityManager = getEntityManager();
        BufferedReader bufferedReader = getBufferedReader();

        String lastName = bufferedReader.readLine();

        Address address = null;
        Employee employee = null;

        try {
            employee = entityManager.createQuery("SELECT e FROM Employee e " +
                    "WHERE e.lastName=:lName", Employee.class)
                    .setParameter("lName", lastName)
                    .getSingleResult();

            address = createNewAddress(entityManager);

        } catch (Exception e){
            System.out.println("No such employee in database.");
        }

        if (employee != null) {
            entityManager.getTransaction().begin();
            employee.setAddress(address);
            entityManager.getTransaction().commit();
            System.out.println("Success!");
        }
    }

    private static Address createNewAddress(EntityManager entityManager) {
        Address address = new Address();
        address.setText("Vitoshka 15");

        entityManager.getTransaction().begin();
        entityManager.persist(address);
        entityManager.getTransaction().commit();

        return address;
    }
}
