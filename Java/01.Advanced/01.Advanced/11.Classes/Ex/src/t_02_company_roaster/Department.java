package t_02_company_roaster;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;


public class Department {
    private final String name;
    private List<Employee> employees;

    public Department(String name) {
        this.name = name;
        this.employees = new ArrayList<>();
    }

    public void addEmployee(Employee person) {
        this.employees.add(person);
    }

    public String getName() {
        return this.name;
    }

    public double getAvgSalary() {
        return this.employees.stream().mapToDouble(x -> x.getSalary()).sum() / employees.size();
    }

    @Override
    public String toString() {
        Collections.sort(this.employees);
        StringBuilder sb = new StringBuilder(26);

        this.employees.forEach(sb::append);
        return sb.toString();
    }
}
