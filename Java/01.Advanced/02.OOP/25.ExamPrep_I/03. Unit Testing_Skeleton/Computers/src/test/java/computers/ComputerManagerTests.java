package computers;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class ComputerManagerTests {
    Computer computer;
    ComputerManager computerManager;

    @Before
    public void setUp(){
        computer = new Computer("Lenovo", "Legion", 3000);
        computerManager = new ComputerManager();
    }

    @Test
    public void shouldReturnEmptyCollectionOnInitialize(){
        Assert.assertEquals(0, computerManager.getCount());
        Assert.assertEquals(0, computerManager.getComputers().size());
    }

    @Test(expected = UnsupportedOperationException.class)
    public void shouldThrowErrorOnAdd(){
        computerManager.getComputers().add(computer);
    }

    @Test
    public void shouldAddComputerSuccessfully(){
        Assert.assertEquals(0, computerManager.getCount());

        computerManager.addComputer(computer);
        Assert.assertEquals(1, computerManager.getCount());
        Assert.assertEquals(computer, computerManager.getComputer(computer.getManufacturer(), computer.getModel()));
        Assert.assertEquals(computer, computerManager.getComputers().get(0));
        Assert.assertEquals(computer, computerManager.getComputersByManufacturer("Lenovo").get(0));
    }

    @Test(expected = IllegalArgumentException.class)
    public void shouldThrowErrorOnAddComputerWithNull(){
        Assert.assertEquals(0, computerManager.getCount());

        computerManager.addComputer(null);
    }

    @Test
    public void shouldRemoveComputerSuccessfully(){
        Assert.assertEquals(0, computerManager.getCount());

        computerManager.addComputer(computer);
        Assert.assertEquals(1, computerManager.getCount());

        computerManager.removeComputer("Lenovo", "Legion");
        Assert.assertEquals(0, computerManager.getCount());
    }
}