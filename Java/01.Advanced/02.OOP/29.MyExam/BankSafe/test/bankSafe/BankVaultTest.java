package bankSafe;


import org.junit.Before;
import org.junit.Test;

import javax.naming.OperationNotSupportedException;

import java.util.Objects;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNull;
import static org.junit.Assert.assertTrue;

public class BankVaultTest {

    private BankVault bankVault;
    private Item item;

    @Before
    public void setUp() {
        bankVault = new BankVault();
        item = new Item("Fredy", "uid");
    }

    @Test
    public void shouldInitializeCorrectly() {
        assertEquals(12, bankVault.getVaultCells().size());
        assertTrue(bankVault.getVaultCells().values().stream().allMatch(Objects::isNull));
    }

    @Test
    public void shouldAddAndRemoveCorrectly() throws OperationNotSupportedException {
        assertNull(bankVault.getVaultCells().get("A1"));
        bankVault.addItem("A1", item);
        assertEquals(item, bankVault.getVaultCells().get("A1"));

        bankVault.removeItem("A1", item);
        assertNull(bankVault.getVaultCells().get("A1"));
    }

    @Test(expected = IllegalArgumentException.class)
    public void shouldThrowErrorOnAddItemWithNonExistingCell() throws OperationNotSupportedException {
        bankVault.addItem("Z1", item);
    }

    @Test(expected = IllegalArgumentException.class)
    public void shouldThrowErrorOnAddSameItemInSameCell() throws OperationNotSupportedException {
        bankVault.addItem("A1", item);
        bankVault.addItem("A1", item);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void shouldThrowErrorOnAddSameItemInDifferentCells() throws OperationNotSupportedException {
        bankVault.addItem("B1", item);
        bankVault.addItem("A1", item);
    }

    @Test(expected = IllegalArgumentException.class)
    public void shouldThrowErrorOnRemoveItemWithNonExistingCell() {
        bankVault.removeItem("Z1", item);
    }

    @Test(expected = IllegalArgumentException.class)
    public void shouldThrowErrorOnRemoveDifferentItemCell() throws OperationNotSupportedException {
        bankVault.addItem("A1", new Item("Test", "SomeId"));
        bankVault.removeItem("A1", item);
    }

    @Test
    public void shouldShowProperMessageOnAddItem() throws OperationNotSupportedException {
        String expected = "Item:uid saved successfully!";
        String actual = bankVault.addItem("B1", item);

        assertEquals(expected, actual);
    }

    @Test
    public void shouldShowProperMessageOnRemoveItem() throws OperationNotSupportedException {
        bankVault.addItem("B1", item);

        String expected = "Remove item:uid successfully!";
        String actual = bankVault.removeItem("B1", item);

        assertEquals(expected, actual);
    }
}