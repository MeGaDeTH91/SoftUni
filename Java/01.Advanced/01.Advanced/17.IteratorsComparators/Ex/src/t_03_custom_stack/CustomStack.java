package t_03_custom_stack;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class CustomStack<T> implements Iterable<T> {
    private List<T> collection;
    private int index;

    public CustomStack() {
        this.collection = new ArrayList<>();
    }

    public int size() {
        return collection.size();
    }

    public T getElementAt(int targetIndex) {
        return collection.get(targetIndex);
    }

    public void push(T... collection) {
        this.collection.addAll(List.of(collection));
    }

    public void pop() {
        if (collection.size() == 0) {
            System.out.println("No elements");
        } else {
            collection.remove(collection.size() - 1);
        }
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<>() {
            @Override
            public boolean hasNext() {
                return index < collection.size() - 1;
            }

            @Override
            public T next() {
                return collection.get(index++);
            }
        };
    }
}
