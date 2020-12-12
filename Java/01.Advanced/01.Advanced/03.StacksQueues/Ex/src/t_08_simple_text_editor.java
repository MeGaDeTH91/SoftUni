import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayDeque;
import java.util.Deque;

public class t_08_simple_text_editor {
    private static final BufferedReader reader;
    private static final StringBuilder text;
    private static final Deque<String> undoStack;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
        text = new StringBuilder(10);
        undoStack = new ArrayDeque<>(10);
        undoStack.push("");
    }
    public static void main(String[] args) throws IOException {
        int commandsCount = Integer.parseInt(reader.readLine());

        String[] lineTokens;
        int currentCommand;
        int currentCount;
        int currentIndex;
        String currentText;

        int currentTextLength;
        for (int i = 0; i < commandsCount; i++) {
            lineTokens = reader.readLine().split("\\s+");

            currentCommand = Integer.parseInt(lineTokens[0]);

            switch(currentCommand) {
                case 1:
                    currentText = lineTokens[1];
                    undoStack.push(text.toString());
                    text.append(currentText);
                    break;
                case 2:
                    currentCount = Integer.parseInt(lineTokens[1]);
                    undoStack.push(text.toString());
                    currentTextLength = text.length();
                    text.delete(currentTextLength - currentCount, currentTextLength);
                    break;
                case 3:
                    currentIndex = Integer.parseInt(lineTokens[1]);
                    System.out.println(text.charAt(currentIndex - 1));
                    break;
                case 4:
                    currentTextLength = text.length();
                    text.delete(0, currentTextLength);
                    text.append(undoStack.pop());
                    break;
            }
        }
    }
}
