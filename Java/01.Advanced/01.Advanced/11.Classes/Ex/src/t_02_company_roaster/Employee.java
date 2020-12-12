package t_02_company_roaster;

public class Employee implements Comparable<Employee>{
    private final String name;
    private final double salary;
    private final String position;
    private final String department;
    private final String email;
    private final int age;

    public Employee(String name, double salary, String position, String department, String email, int age) {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public double getSalary() {
        return salary;
    }

    public Employee(String name, double salary, String position, String department) {
        this(name, salary, position, department, "n/a", -1);
    }

    public Employee(String name, double salary, String position, String department, String email) {
        this(name, salary, position, department, email, -1);
    }

    public Employee(String name, double salary, String position, String department, int age) {
        this(name, salary, position, department, "n/a", age);
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %s %d%n", this.name, this.salary, this.email, this.age);
    }

    @Override
    public int compareTo(Employee other) {
        return Double.compare(other.salary, this.salary);
    }
}
