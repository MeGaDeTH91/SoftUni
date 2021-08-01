package tasks;

import entities.Employee;

import javax.persistence.EntityManager;

public class t_10_IncreaseSalaries extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        entityManager.getTransaction().begin();
        var departmentsIds = entityManager
                .createQuery("SELECT d.id FROM Department d " +
                        "WHERE d.name IN('Engineering', 'Tool Design', 'Marketing', 'Information Services')")
                .getResultList();

        var rowsAffected = entityManager
                .createQuery("UPDATE Employee e " +
                "SET e.salary = e.salary * 1.12 " +
                "WHERE e.department.id IN :ids")
                .setParameter("ids", departmentsIds)
                .executeUpdate();

        if (rowsAffected > 0) {
            var selectQuery = entityManager.createQuery("SELECT e FROM Employee e " +
                    "WHERE e.department.id IN :ids",
                    Employee.class)
                    .setParameter("ids", departmentsIds);

            var res = selectQuery.getResultList();

            for (Employee emp: res) {
                System.out.printf("%s %s ($%.2f)" + System.lineSeparator(),
                        emp.getFirstName(),
                        emp.getLastName(),
                        emp.getSalary());
            }
        } else {
            System.out.println("There was problem with update operation.");
        }

        entityManager.getTransaction().commit();
    }
}
