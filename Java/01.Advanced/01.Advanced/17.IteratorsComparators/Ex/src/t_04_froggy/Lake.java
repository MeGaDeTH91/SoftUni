package t_04_froggy;

import java.util.Iterator;

public class Lake<T> implements Iterable<T> {
    private final T[] numbers;

    public Lake(T[] numbers) {
        this.numbers = numbers;
    }

    @Override
    public Iterator<T> iterator() {
        return new Frog();
    }

    private class Frog implements Iterator<T> {
        private int index;
        private boolean endIsReached;

        public Frog() {
            this.index = 0;
        }

        @Override
        public boolean hasNext() {
            return index < numbers.length;
        }

        @Override
        public T next() {
            int currentIndex = index;

            if (index >= numbers.length - 2 && !endIsReached){
                index = 1;
                endIsReached = true;
            } else {
                index += 2;
            }

            return numbers[currentIndex];
        }
    }
}
