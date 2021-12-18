package com.demo.examprep.model.enumerations;

public enum CategoryNameEnum {
    DRINK(1),
    COFFEE(2),
    OTHER(5),
    CAKE(10);

    private final int time;
    CategoryNameEnum(int time) {
        this.time = time;
    }

    public int getTime() {
        return this.time;
    }
}
