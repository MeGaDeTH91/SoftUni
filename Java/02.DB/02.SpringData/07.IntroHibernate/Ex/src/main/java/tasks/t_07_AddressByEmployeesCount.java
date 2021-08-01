package tasks;

import entities.Address;

import javax.persistence.EntityManager;

public class t_07_AddressByEmployeesCount extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        var query = entityManager.createQuery("SELECT a FROM Address a " +
                "ORDER BY a.employees.size DESC", Address.class);

        var res = query.setMaxResults(10).getResultList();

        if (res.isEmpty()) {
            System.out.println("No addresses in database.");
        } else {
            for (Address address: res) {
                System.out.printf("%s, %s - %d employees" + System.lineSeparator(),
                        address.getText(),
                        address.getTown() == null ? "Unknown" : address.getTown().getName(),
                        address.getEmployees().size());
            }
        }
    }
}
