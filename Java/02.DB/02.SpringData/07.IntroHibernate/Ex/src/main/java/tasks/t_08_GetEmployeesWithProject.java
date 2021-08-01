package tasks;

import entities.Employee;
import entities.Project;

import javax.persistence.EntityManager;
import java.io.BufferedReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class t_08_GetEmployeesWithProject extends EntityManagerBase {
    public static void main(String[] args) throws IOException {
        EntityManager entityManager = getEntityManager();
        BufferedReader bufferedReader = getBufferedReader();

        int employeeId = Integer.parseInt(bufferedReader.readLine());

        Employee employee = entityManager.find(Employee.class, employeeId);


        if (employee != null) {
            System.out.printf("%s %s - %s" + System.lineSeparator(),
                    employee.getFirstName(),
                    employee.getLastName(),
                    employee.getJobTitle());

            List<Project> sortedList = new ArrayList<>(employee.getProjects());
            sortedList.sort(Comparator.comparing(Project::getName));

            for (Project project: sortedList) {
                System.out.println("\t" + project.getName());
            }
        } else {
            System.out.println("No such employee!");
        }
    }
}
