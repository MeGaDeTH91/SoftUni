package tasks;

import entities.Employee;

import javax.persistence.EntityManager;
import java.io.BufferedReader;
import java.io.IOException;

public class t_11_FindEmployeesByFirstName extends EntityManagerBase {
    public static void main(String[] args) throws IOException {
        EntityManager entityManager = getEntityManager();
        BufferedReader bufferedReader = getBufferedReader();

        String nameStart = bufferedReader.readLine();

        var employees = entityManager.createQuery("SELECT e FROM Employee e " +
                "WHERE e.firstName LIKE :nameStr", Employee.class)
                .setParameter("nameStr", nameStart + "%")
                .getResultList();


        if (employees.isEmpty()) {
            System.out.println("No such employees in database.");
        } else {
            for (Employee employee: employees) {
                System.out.printf("%s %s - %s - ($%.2f)" + System.lineSeparator(),
                        employee.getFirstName(),
                        employee.getLastName(),
                        employee.getJobTitle(),
                        employee.getSalary());
            }
        }
    }
}
