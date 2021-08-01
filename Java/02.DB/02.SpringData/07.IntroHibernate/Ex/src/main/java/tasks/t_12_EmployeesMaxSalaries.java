package tasks;

import entities.Department;

import javax.persistence.EntityManager;
import java.math.BigDecimal;

public class t_12_EmployeesMaxSalaries extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        var departments = entityManager.createQuery("SELECT d, MAX(e.salary) AS max_salary FROM Department d\n" +
                "JOIN d.employees e\n" +
                "GROUP BY d.id\n" +
                "HAVING MAX(e.salary) NOT BETWEEN 30000 AND 70000")
                .getResultList();


        if (departments.isEmpty()) {
            System.out.println("No departments in database.");
        } else {
            Object[] currentResultSet;
            String departmentName;
            BigDecimal currentMaxSalary;

            for (Object resultSet: departments) {
                currentResultSet = (Object[])resultSet;
                departmentName = ((Department)(currentResultSet)[0]).getName();
                currentMaxSalary = (BigDecimal)(currentResultSet[1]);

                System.out.printf("%s %.2f" + System.lineSeparator(),
                        departmentName,
                        currentMaxSalary);
            }
        }
    }
}
