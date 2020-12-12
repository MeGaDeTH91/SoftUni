package t_06_strategy_pattern;

import java.util.Comparator;

public class ComparatorAge implements Comparator<Person> {
    @Override
    public int compare(Person firstPerson, Person secondPerson) {
        return Integer.compare(firstPerson.getAge(), secondPerson.getAge());
    }
}
