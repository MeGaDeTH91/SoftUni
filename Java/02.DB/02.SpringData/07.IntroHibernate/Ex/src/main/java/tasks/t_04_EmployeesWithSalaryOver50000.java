package tasks;

import entities.Employee;

import javax.persistence.EntityManager;

public class t_04_EmployeesWithSalaryOver50000 extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        var query = entityManager.createQuery("SELECT e FROM Employee e " +
                "WHERE e.salary > 50000", Employee.class);

        var res = query.getResultList();

        if (res.isEmpty()) {
            System.out.println("No such employees.");
        } else {
            for (Employee emp: res) {
                System.out.println(emp.getFirstName());
            }
        }
    }
}
