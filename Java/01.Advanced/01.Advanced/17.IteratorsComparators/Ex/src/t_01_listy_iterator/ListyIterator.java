package t_01_listy_iterator;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class ListyIterator implements Iterator<String> {
    private int index;

    private List<String> collection;

    public ListyIterator(String... collection) {
        this.collection = List.of(collection);
    }

    public boolean move() {
        if (hasNext()) {
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

    @Override
    public boolean hasNext() {
        return index < collection.size() - 1;
    }

    @Override
    public String next() {
        return null;
    }
}
