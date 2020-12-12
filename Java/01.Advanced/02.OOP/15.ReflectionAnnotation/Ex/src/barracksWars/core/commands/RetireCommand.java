package barracksWars.core.commands;

import barracksWars.annotations.Inject;
import barracksWars.interfaces.Repository;
import jdk.jshell.spi.ExecutionControl;

public class RetireCommand extends Command{

    @Inject
    private Repository repository;

    public RetireCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() throws ExecutionControl.NotImplementedException {
        String unitType = getData()[1];
        try {
            this.repository.removeUnit(unitType);
        } catch (IllegalArgumentException e) {
            return e.getMessage();
        }
        return getData()[1] + " retired!";
    }
}
