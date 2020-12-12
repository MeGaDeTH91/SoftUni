package t_06_strategy_pattern;

import java.util.Comparator;

public class ComparatorName implements Comparator<Person> {
    @Override
    public int compare(Person firstPerson, Person secondPerson) {
        int lengthComparison = Integer.compare(firstPerson.getName().length(), secondPerson.getName().length());

        if (lengthComparison == 0) {
            return firstPerson.getName().compareToIgnoreCase(secondPerson.getName());
        }

        return lengthComparison;
    }
}
