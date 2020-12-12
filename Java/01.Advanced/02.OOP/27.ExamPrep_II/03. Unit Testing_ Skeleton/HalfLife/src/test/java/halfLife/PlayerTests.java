package halfLife;

import org.junit.Before;
import org.junit.Test;

import java.lang.instrument.UnmodifiableModuleException;

import static org.junit.Assert.*;

public class PlayerTests {
    private Player player;
    private Gun gun;

    @Before
    public void setUp(){
        player = new Player("Batman", 10000);
        gun = new Gun("P2000", 10);
    }

    @Test
    public void shouldInitializeCorrectly(){
        assertEquals("Batman", player.getUsername());
        assertEquals(10000, player.getHealth());
        assertTrue(player.getGuns().isEmpty());
    }

    @Test(expected = NullPointerException.class)
    public void shouldThrowErrorOnInitializeWithNullUsername(){
        player = new Player(null, 100);
    }

    @Test(expected = NullPointerException.class)
    public void shouldThrowErrorOnInitializeWithInvalidUsername(){
        player = new Player("", 100);
    }

    @Test(expected = IllegalArgumentException.class)
    public void shouldThrowErrorOnInitializeWithNegativeHealth(){
        player = new Player("Bat", -1);
    }

    @Test(expected = UnsupportedOperationException.class)
    public void shouldThrowErrorOnAddFromGetter(){
        player.getGuns().add(gun);
    }

    @Test(expected = NullPointerException.class)
    public void shouldThrowErrorOnAddNull(){
        player.addGun(null);
    }

    @Test
    public void shouldAddAndRemoveGunCorrectly(){
        player.addGun(gun);

        assertEquals(gun, player.getGun(gun.getName()));
        assertEquals(gun, player.getGuns().get(0));
        assertEquals(1, player.getGuns().size());

        player.removeGun(gun);

        assertNull(player.getGun(gun.getName()));
        assertEquals(0, player.getGuns().size());
    }

    @Test
    public void shouldTakeDamageCorrectly(){
        assertEquals(10000, player.getHealth());

        player.takeDamage(2000);
        assertEquals(8000, player.getHealth());
    }

    @Test
    public void shouldTakeDamageAndDieCorrectly(){
        assertEquals(10000, player.getHealth());

        player.takeDamage(10001);
        assertEquals(0, player.getHealth());
    }

    @Test(expected = IllegalStateException.class)
    public void shouldThrowErrorOnTakeDamageWithDeadPlayer(){
        player = new Player("Batman", 0);

        player.takeDamage(10);
    }
}
