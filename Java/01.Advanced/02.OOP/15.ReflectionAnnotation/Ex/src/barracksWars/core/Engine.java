package barracksWars.core;

import barracksWars.annotations.Inject;
import barracksWars.core.commands.Command;
import barracksWars.interfaces.Repository;
import barracksWars.interfaces.Runnable;
import barracksWars.interfaces.Unit;
import barracksWars.interfaces.UnitFactory;
import jdk.jshell.spi.ExecutionControl;


import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;

public class Engine implements Runnable {

	private static final String COMMANDS_PACKAGE_NAME =
			"barracksWars.core.commands.";

	private final Repository repository;
	private final UnitFactory unitFactory;

	public Engine(Repository repository, UnitFactory unitFactory) {
		this.repository = repository;
		this.unitFactory = unitFactory;
	}

	@Override
	public void run() {
		BufferedReader reader = new BufferedReader(
				new InputStreamReader(System.in));
		while (true) {
			try {
				String input = reader.readLine();
				String[] data = input.split("\\s+");
				String commandName = data[0];
				String result = interpretCommand(data, commandName);
				if (result.equals("fight")) {
					break;
				}
				System.out.println(result);
			} catch (RuntimeException e) {
				System.out.println(e.getMessage());
			} catch (IOException | ClassNotFoundException | IllegalAccessException | InvocationTargetException | InstantiationException | ExecutionControl.NotImplementedException e) {
				e.printStackTrace();
			}
		}
	}

	private String interpretCommand(String[] data, String commandName) throws ClassNotFoundException, IllegalAccessException, InvocationTargetException, InstantiationException, ExecutionControl.NotImplementedException {
		String result = "";
		Command command;
		String capitalizedCommand = commandName.substring(0, 1).toUpperCase() + commandName.substring(1);

		Constructor<?> currentUnit = Class.forName(COMMANDS_PACKAGE_NAME + capitalizedCommand + "Command").getDeclaredConstructors()[0];
		command = (Command)currentUnit.newInstance((Object)data);

		Field[] commandFields = command.getClass().getDeclaredFields();
		for (Field field: commandFields) {
			field.setAccessible(true);

			if (field.isAnnotationPresent(Inject.class) &&
					field.getType().getSimpleName().equals("Repository")) {
				field.set(command, repository);
			} else if (field.isAnnotationPresent(Inject.class) &&
					field.getType().getSimpleName().equals("UnitFactory")) {
				field.set(command, unitFactory);
			}
		}

		result = command.execute();

		return result;
	}
}
