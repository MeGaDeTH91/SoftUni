package t_02_black_box_integer;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IllegalAccessException, InvocationTargetException, InstantiationException, IOException, NoSuchFieldException {
        Constructor<?> constructor = BlackBoxInt.class.getDeclaredConstructors()[1];
        constructor.setAccessible(true);

        BlackBoxInt blackBoxInt = (BlackBoxInt)constructor.newInstance();
        Map<String, Method> methods = new LinkedHashMap<>();

        for (Method currMethod: BlackBoxInt.class.getDeclaredMethods()) {
            currMethod.setAccessible(true);
            methods.put(currMethod.getName(), currMethod);
        }

        Field innerValue = blackBoxInt.getClass().getDeclaredField("innerValue");
        innerValue.setAccessible(true);

        String line;
        String[] tokens;
        String operation;
        int currentValue;
        while(!(line = reader.readLine()).equals("END")) {
            tokens = line.split("[_]");
            operation = tokens[0];
            currentValue = Integer.parseInt(tokens[1]);

            methods.get(operation).invoke(blackBoxInt, currentValue);
            System.out.println(innerValue.get(blackBoxInt));
        }
    }
}
