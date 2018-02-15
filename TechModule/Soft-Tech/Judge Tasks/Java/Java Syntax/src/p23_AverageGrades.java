import java.text.MessageFormat;
import java.util.*;


public class p23_AverageGrades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Map<String, ArrayList<Double>> students = new TreeMap<>();

        double num = Double.parseDouble(scanner.nextLine());
        for (int i = 0; i < num; i++) {
            String[] input = scanner.nextLine().split("\\s+");
            ArrayList<Double> currList = new ArrayList<>();
            String currName = input[0];

            int currDelim = input.length - 1;
            double currAve = 0;
            for (int j = 1; j < input.length; j++) {
                Double currGrade = Double.parseDouble(input[j]);
                currAve += currGrade;
            }
            currAve = currAve / currDelim;
            currList.add(currAve);
            if (currAve >= 5.00) {
                if (!students.containsKey(currName)) {
                   students.put(currName, new ArrayList<Double>(currList)); //no ArrayList assigned, create new ArrayList

                }
                else {
                    students.get(currName).add(currAve);
                }

            }

        }
        for (Map.Entry<String, ArrayList<Double>> student : students.entrySet()) {
            Collections.sort(student.getValue());
            Collections.reverse(student.getValue());

            for (Double values : student.getValue()) {
            String format = String.format("%.2f", values);
            System.out.println(MessageFormat.format("{0} -> {1}", student.getKey(), format));
            }
        }
    }
}
