package barracksWars.core.factories;

import barracksWars.interfaces.Unit;
import barracksWars.interfaces.UnitFactory;
import jdk.jshell.spi.ExecutionControl;

import java.lang.reflect.Constructor;

public class UnitFactoryImpl implements UnitFactory {

	private static final String UNITS_PACKAGE_NAME =
			"barracksWars.models.units.";

	@Override
	public Unit createUnit(String unitType) {
		Unit unit = null;

		try {
			Constructor<?> currentUnit = Class.forName(UNITS_PACKAGE_NAME + unitType).getDeclaredConstructors()[0];
			unit = (Unit)currentUnit.newInstance();
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		return unit;
	}
}
