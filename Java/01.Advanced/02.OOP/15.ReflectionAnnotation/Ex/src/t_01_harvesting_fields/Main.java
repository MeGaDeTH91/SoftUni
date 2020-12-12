package t_01_harvesting_fields;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

public class Main {
	private static final BufferedReader reader;

	static {
	    reader = new BufferedReader(new InputStreamReader(System.in));
	}

	public static void main(String[] args) throws IOException {
		Field[] fields = RichSoilLand.class.getDeclaredFields();

		String command;
		String accessModifier;
		String fieldType;
		String fieldName;
		while (!(command = reader.readLine()).equals("HARVEST")) {
			if (command.equals("all")) {
				for (Field currField: fields) {
					accessModifier = Modifier.toString(currField.getModifiers());
					fieldType = currField.getType().getSimpleName();
					fieldName = currField.getName();

					System.out.printf("%s %s %s%n", accessModifier, fieldType, fieldName);
				}
			}
			for (Field currField: fields) {
				accessModifier = Modifier.toString(currField.getModifiers());

				if (accessModifier.equals(command)) {
					fieldType = currField.getType().getSimpleName();
					fieldName = currField.getName();

					System.out.printf("%s %s %s%n", accessModifier, fieldType, fieldName);
				}
			}
		}
	}
}
