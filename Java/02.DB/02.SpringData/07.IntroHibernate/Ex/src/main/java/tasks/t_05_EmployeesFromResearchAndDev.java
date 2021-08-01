package tasks;

import entities.Employee;

import javax.persistence.EntityManager;

public class t_05_EmployeesFromResearchAndDev extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        var query = entityManager.createQuery("SELECT e FROM Employee e " +
                "WHERE e.department.name = :dep_name " +
                "ORDER BY e.salary ASC, " +
                "e.id ASC", Employee.class);
        query.setParameter("dep_name", "Research and Development");

        var res = query.getResultList();

        if (res.isEmpty()) {
            System.out.println("No such employees.");
        } else {
            for (Employee emp: res) {
                System.out.printf("%s %s from Research and Development - $%.2f" + System.lineSeparator(),
                        emp.getFirstName(), emp.getLastName(), emp.getSalary());
            }
        }
    }
}
