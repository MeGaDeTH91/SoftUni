package entities.billsystem;

import javax.persistence.*;

@Entity
@Table(name = "bank_accounts")
public class BankAccount extends BillingDetail {
    private String bankName;
    private String swift;

    public BankAccount() {
    }

    public String getBankName() {
        return bankName;
    }

    public void setBankName(String bankName) {
        this.bankName = bankName;
    }

    @Column
    public String getSwift() {
        return swift;
    }

    public void setSwift(String SWIFT) {
        this.swift = SWIFT;
    }
}
