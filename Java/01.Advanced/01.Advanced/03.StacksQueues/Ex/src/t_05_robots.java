import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.Deque;
import java.util.ArrayDeque;

public class t_05_robots {
    private static final BufferedReader scanner;
    private static final DateTimeFormatter formatter;
    private static final DateTimeFormatter outputFormatter;
    private static final Deque<String> productQueue;

    static {
        scanner  = new BufferedReader(new InputStreamReader(System.in));
        formatter = DateTimeFormatter.ofPattern("H:mm:ss");
        outputFormatter = DateTimeFormatter.ofPattern("HH:mm:ss");
        productQueue = new ArrayDeque<>(6);
    }
    public static void main(String[] args) throws IOException {

        String[] robotsInput = scanner.readLine().split(";");
        Robot[] robots = new Robot[robotsInput.length];
        for (int i = 0; i < robots.length; i++) {
            String[] robotTokens = robotsInput[i].split("-");

            int currTime = Integer.parseInt(robotTokens[1]);

            Robot robotToAdd = new Robot(robotTokens[0], currTime, currTime);
            robots[i] = robotToAdd;
        }

        String strTime = scanner.readLine();
        LocalTime time = LocalTime.parse(strTime, formatter);



        boolean productIsProcessed;
        String product;
        while (!(product = scanner.readLine()).equals("End")) {
            productQueue.offer(product);
        }

        while (!productQueue.isEmpty()) {
            time = time.plusSeconds(1);
            String currentProduct = productQueue.poll();
            productIsProcessed = false;

            for (Robot currRobot : robots) {
                if (currRobot.isAvailable && !productIsProcessed) {
                    productIsProcessed = true;
                    currRobot.isAvailable = false;
                    System.out.printf("%s - %s [%s]\n", currRobot.name, currentProduct, time.format(outputFormatter));
                }

                if (!currRobot.isAvailable) {
                    currRobot.currentTime--;
                }

                if (currRobot.currentTime <= 0) {
                    currRobot.currentTime = currRobot.operationTime;
                    currRobot.isAvailable = true;
                }
            }

            if (!productIsProcessed) {
                productQueue.offer(currentProduct);
            }
        }
    }

    private static class Robot {
        private final String name;
        private int currentTime;
        private boolean isAvailable;
        private final int operationTime;

        public Robot(String name, int currentTime, int operationTime) {
            this.name = name;
            this.currentTime = currentTime;
            this.operationTime = operationTime;
            this.isAvailable = true;
        }
    }
}
