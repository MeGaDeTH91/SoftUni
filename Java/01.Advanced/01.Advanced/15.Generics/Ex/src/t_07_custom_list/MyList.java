package t_07_custom_list;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class MyList<T extends Comparable<T>> {
    List<T> collection;

    public MyList() {
        this.collection = new ArrayList<>();
    }

    public void add(T element) {
        collection.add(element);
    }

    public T remove(int index) {
        return collection.remove(index);
    }

    public boolean contains(T element) {
        return collection.contains(element);
    }

    public void swap(int firstIndex, int secondIndex) {
        T temp = collection.get(firstIndex);

        collection.set(firstIndex, collection.get(secondIndex));
        collection.set(secondIndex, temp);
    }

    public int countGreaterThan(T element) {
        int count = 0;

        for (T currElement: collection) {
            if (currElement.compareTo(element) > 0) {
                count++;
            }
        }

        return count;
    }

    public T getMin() {
        return Collections.min(collection);
    }

    public T getMax() {
        return Collections.max(collection);
    }

    public void print() {
        for (T element: collection) {
            System.out.println(element);
        }
    }
}
