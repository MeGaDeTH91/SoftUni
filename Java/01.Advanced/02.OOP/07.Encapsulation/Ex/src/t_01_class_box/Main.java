package t_01_class_box;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        int length = Integer.parseInt(reader.readLine());
        int width = Integer.parseInt(reader.readLine());
        int height = Integer.parseInt(reader.readLine());

        try {
            Box box = new Box(length, width, height);

            System.out.printf("Surface Area - %.2f%n", box.calculateSurfaceArea());
            System.out.printf("Lateral Surface Area - %.2f%n", box.calculateLateralSurfaceArea());
            System.out.printf("Volume - %.2f%n", box.calculateVolume());
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
