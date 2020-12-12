package CounterStriker.models.players;

import CounterStriker.models.guns.Gun;

import static CounterStriker.common.ExceptionMessages.INVALID_GUN;
import static CounterStriker.common.ExceptionMessages.INVALID_PLAYER_ARMOR;
import static CounterStriker.common.ExceptionMessages.INVALID_PLAYER_HEALTH;
import static CounterStriker.common.ExceptionMessages.INVALID_PLAYER_NAME;

public abstract class PlayerImpl implements Player {

    private String username;
    private int health;
    private int armor;
    private Gun gun;

    public PlayerImpl(String username, int health, int armor, Gun gun) {
        this.setUsername(username);
        this.setHealth(health);
        this.setArmor(armor);
        this.setGun(gun);
    }

    @Override
    public String getUsername() {
        return username;
    }

    @Override
    public int getHealth() {
        return health;
    }

    @Override
    public int getArmor() {
        return armor;
    }

    @Override
    public Gun getGun() {
        return gun;
    }

    @Override
    public boolean isAlive() {
        return getHealth() > 0;
    }

    private void setUsername(String username) {
        if (username == null || username.trim().isEmpty()) {
            throw new NullPointerException(INVALID_PLAYER_NAME);
        }
        this.username = username;
    }

    private void setHealth(int health) {
        if (health < 0) {
            throw new IllegalArgumentException(INVALID_PLAYER_HEALTH);
        }
        this.health = health;
    }

    private void setArmor(int armor) {
        if (armor < 0) {
            throw new IllegalArgumentException(INVALID_PLAYER_ARMOR);
        }
        this.armor = armor;
    }

    private void setGun(Gun gun) {
        if (gun == null) {
            throw new NullPointerException(INVALID_GUN);
        }
        this.gun = gun;
    }

    @Override
    public void takeDamage(int points) {
        armor -= points;
        int currHealth = getHealth();

        if (armor <= 0) {
            armor = 0;

            currHealth -= points;
        }

        if (currHealth < 0) {
            currHealth = 0;
        }
        setHealth(currHealth);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(80);

        sb.append(this.getClass().getSimpleName()).append(": ").append(getUsername()).append(System.lineSeparator());
        sb.append("--Health: ").append(getHealth()).append(System.lineSeparator());
        sb.append("--Armor: ").append(getArmor()).append(System.lineSeparator());
        sb.append("--Gun: ").append(getGun().getName()).append(System.lineSeparator());

        return sb.toString().trim();
    }
}
