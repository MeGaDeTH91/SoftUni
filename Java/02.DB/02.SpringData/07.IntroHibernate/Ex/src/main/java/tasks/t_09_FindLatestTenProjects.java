package tasks;

import entities.Project;

import javax.persistence.EntityManager;
import java.time.format.DateTimeFormatter;
import java.util.Comparator;

public class t_09_FindLatestTenProjects extends EntityManagerBase {
    public static void main(String[] args) {
        EntityManager entityManager = getEntityManager();

        var query = entityManager.createQuery("SELECT p FROM Project p " +
                "ORDER BY p.startDate DESC", Project.class);

        var res = query.setMaxResults(10).getResultList();

        if (res.isEmpty()) {
            System.out.println("No projects in database.");
        } else {
            res.sort(Comparator.comparing(Project::getName));

            StringBuilder sb = new StringBuilder(80);

            String startDate = null;
            String endDate = null;
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.S");

            for (Project project: res) {
                sb.append("Project name: ").append(project.getName()).append(System.lineSeparator());

                sb.append(" \t")
                        .append("Project Description: ")
                        .append(project.getDescription())
                        .append(System.lineSeparator());

                if (project.getStartDate() != null) {
                    startDate = project.getStartDate().format(formatter);
                }

                sb.append(" \t")
                        .append("Project Start Date: ")
                        .append(startDate)
                        .append(System.lineSeparator());

                if (project.getEndDate() != null) {
                    endDate = project.getEndDate().format(formatter);
                }
                sb.append(" \t")
                        .append("Project End Date: ")
                        .append(endDate)
                        .append(System.lineSeparator());
            }

            System.out.println(sb.toString().trim());
        }
    }
}
