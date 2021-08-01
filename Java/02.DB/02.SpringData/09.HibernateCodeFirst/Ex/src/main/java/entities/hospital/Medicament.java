package entities.hospital;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "medicaments")
public class Medicament {
    private int id;
    private String name;
    private Set<Patient> prescribedPatients;

    public Medicament() {
        this.prescribedPatients = new HashSet<>();
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Column
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.ALL)
    @JoinTable(
            name = "medicaments_patients",
            joinColumns = {@JoinColumn(name = "medicament_id")},
            inverseJoinColumns = {@JoinColumn(name = "patient_id")}
    )
    public Set<Patient> getPrescribedPatients() {
        return prescribedPatients;
    }

    public void setPrescribedPatients(Set<Patient> prescribedPatients) {
        this.prescribedPatients = prescribedPatients;
    }
}
