import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Deque;

public class t_06_balanced_parentheses {
    private static final BufferedReader reader;
    private static final Deque<Character> parentheses;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        parentheses = new ArrayDeque<>();
    }
    public static void main(String[] args) throws IOException {
        String inputLine = reader.readLine();
        boolean isBalanced = true;

        for (int i = 0; i < inputLine.length(); i++) {
            char currentParentheses = inputLine.charAt(i);

            if (currentParentheses == '{' || currentParentheses == '(' || currentParentheses == '[') {
                parentheses.push(currentParentheses);
            } else {
                if (!parenthesesMatch(currentParentheses)) {
                    isBalanced = false;
                    break;
                }
            }
        }

        String result = isBalanced ? "YES" : "NO" ;
        System.out.println(result);
    }

    private static boolean parenthesesMatch(char currentParentheses) {
        if (parentheses.size() < 1) {
            return false;
        }

        char lastParentheses = parentheses.pop();

        switch (currentParentheses) {
            case '}':
                return lastParentheses == '{';
            case ')':
                return lastParentheses == '(';
            case ']':
                return lastParentheses == '[';
        }

        return false;
    }
}
