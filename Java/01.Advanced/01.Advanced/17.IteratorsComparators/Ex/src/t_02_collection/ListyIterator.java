package t_02_collection;

import java.util.Iterator;
import java.util.List;

public class ListyIterator implements Iterable<String> {
    private int index;

    private List<String> collection;

    public ListyIterator(String... collection) {
        this.collection = List.of(collection);
    }

    public boolean move() {
        if (iterator().hasNext()) {
            index++;

            return true;
        }
        return false;
    }

    public void print() {
        if (collection == null || collection.size() < 1 || index == collection.size()) {
            System.out.println("Invalid Operation!");
        } else {
            System.out.println(collection.get(index));
        }
    }

    public void printAll() {
        if (collection == null) {
            System.out.println("Invalid Operation!");
        } else {
            System.out.println(String.join(" ", collection));
        }
    }

    @Override
    public Iterator<String> iterator() {

        return new Iterator<>() {
            @Override
            public boolean hasNext() {
                return index < collection.size() - 1;
            }

            @Override
            public String next() {
                return collection.get(index++);
            }
        };
    }
}
