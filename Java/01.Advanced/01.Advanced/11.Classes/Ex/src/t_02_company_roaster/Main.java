package t_02_company_roaster;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int employeesCount = Integer.parseInt(reader.readLine());
        Map<String, Department> departments = new HashMap<>();

        String[] tokens;
        String name;
        double salary;
        String position;
        String departmentName;
        String email;
        int age;
        Employee employee;
        Department department;
        for (int i = 0; i < employeesCount; i++) {
            tokens = reader.readLine().split("\\s+");

            name = tokens[0];
            salary = Double.parseDouble(tokens[1]);
            position = tokens[2];
            departmentName = tokens[3];

            if (tokens.length == 6) {
                email = tokens[4];
                age = Integer.parseInt(tokens[5]);
                employee = new Employee(name, salary, position, departmentName, email, age);
            } else if (tokens.length == 5) {
                employee = tokens[4].contains("@") ? new Employee(name, salary, position, departmentName, tokens[4]): new Employee(name, salary, position, departmentName, Integer.parseInt(tokens[4]));
            } else {
                employee = new Employee(name, salary, position, departmentName);
            }

            if (!departments.containsKey(departmentName)) {
                department = new Department(departmentName);
                departments.put(departmentName, department);
            }
            departments.get(departmentName).addEmployee(employee);
        }

        Department result = null;
        double maxAvg = Double.MIN_VALUE;
        double currentAvg;
        for (Map.Entry<String, Department> currDep: departments.entrySet()) {
            currentAvg = currDep.getValue().getAvgSalary();

            if (currentAvg > maxAvg) {
                maxAvg = currentAvg;
                result = currDep.getValue();
            }
        }

        System.out.printf("Highest Average Salary: %s%n", result.getName());
        System.out.println(result.toString());
    }
}
