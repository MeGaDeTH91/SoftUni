package classroom;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class Classroom {
    public List<Student> students;
    public int capacity;

    public Classroom(int capacity) {
        this.capacity = capacity;
        students = new ArrayList<>();
    }

    public List<Student> getStudents() {
        return students;
    }

    public int getCapacity() {
        return capacity;
    }

    public int getStudentCount() {
        return students.size();
    }

    public String registerStudent(Student student) {
        if (students.stream().anyMatch(x -> x.getFirstName().equals(student.getFirstName()) &&
                x.getLastName().equals(student.getLastName()))) {
            return "Student is already in the classroom";
        } else if (students.size() >= capacity) {
            return "No seats in the classroom";
        } else {
            students.add(student);
            return String.format("Added student %s %s", student.getFirstName(), student.getLastName());
        }
    }

    public String dismissStudent(Student student) {
        boolean removedSuccessfully = students
                .removeIf(x -> x.getFirstName().equals(student.getFirstName()) &&
                        x.getLastName().equals(student.getLastName()));

        if (removedSuccessfully) {
            return String.format("Removed student %s %s", student.getFirstName(), student.getLastName());
        }
        return "Student not found";
    }

    public String getSubjectInfo(String subject) {
        List<Student> subjectStudents = students
                .stream()
                .filter(x -> x.getBestSubject().equals(subject)).collect(Collectors.toList());

        if (subjectStudents.isEmpty()) {
            return "No students enrolled for the subject";
        }

        StringBuilder sb = new StringBuilder(35);
        sb.append("Subject: ").append(subject).append(System.lineSeparator());
        sb.append("Students:").append(System.lineSeparator());

        for (Student currStudent: subjectStudents) {
            sb.append(currStudent.getFirstName()).append(" ").append(currStudent.getLastName()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }

    public Student getStudent(String firstName, String lastName) {
        return  students.stream()
                .filter(x -> x.getFirstName().equals(firstName) && x.getLastName().equals(lastName))
                .findFirst()
                .orElse(null);
    }

    public String getStatistics() {
        StringBuilder sb = new StringBuilder();

        sb.append("Classroom size: ").append(getStudentCount()).append(System.lineSeparator());

        for (Student currStudent: students) {
            sb.append("==").append(currStudent.toString()).append(System.lineSeparator());
        }

        return sb.toString().trim();
    }
 }
