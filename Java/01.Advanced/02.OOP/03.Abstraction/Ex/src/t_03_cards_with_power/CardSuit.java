package t_03_cards_with_power;

public enum CardSuit {
    CLUBS(0),
    DIAMONDS(13),
    HEARTS(26),
    SPADES(39);

    private final int value;

    CardSuit(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
