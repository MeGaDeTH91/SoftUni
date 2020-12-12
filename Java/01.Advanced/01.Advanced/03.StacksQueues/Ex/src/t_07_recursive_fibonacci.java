import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class t_07_recursive_fibonacci {
    private static final BufferedReader scanner;
    private static Long[] fibonacci;

    static {
        scanner = new BufferedReader(new InputStreamReader(System.in));
    }
    public static void main(String[] args) throws IOException {
        int limit = Integer.parseInt(scanner.readLine());

        fibonacci = new Long[limit + 2];

        long result = getFibonacci(limit + 1);

        System.out.println(result);
    }

    private static long getFibonacci(int index) {
        if (index == 0) {
            return 0;
        } else if (index == 1) {
            return 1;
        }

        if (fibonacci[index] != null) {
            return fibonacci[index];
        }
        fibonacci[index] = getFibonacci(index - 1) + getFibonacci(index - 2);
        return fibonacci[index];
    }
}
