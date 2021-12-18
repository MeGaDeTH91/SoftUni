package com.java.exam.model.binding;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Positive;

public class FireBindingModel {
    private Long attacker;
    private Long defender;

    public FireBindingModel() {
    }

    @NotNull
    @Positive
    public Long getAttacker() {
        return attacker;
    }

    public void setAttacker(Long attacker) {
        this.attacker = attacker;
    }

    @NotNull
    @Positive
    public Long getDefender() {
        return defender;
    }

    public void setDefender(Long defender) {
        this.defender = defender;
    }
}
