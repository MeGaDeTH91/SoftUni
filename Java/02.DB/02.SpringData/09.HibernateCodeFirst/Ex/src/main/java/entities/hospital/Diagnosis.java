package entities.hospital;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "diagnoses")
public class Diagnosis {
    private int id;
    private String name;
    private String comment;
    private Set<Patient> diagnosedPatients;

    public Diagnosis() {
        this.diagnosedPatients = new HashSet<>();
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

    @Column
    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.ALL)
    @JoinTable(
            name = "diagnoses_patients",
            joinColumns = {@JoinColumn(name = "diagnosis_id")},
            inverseJoinColumns = {@JoinColumn(name = "patient_id")}
    )
    public Set<Patient> getDiagnosedPatients() {
        return diagnosedPatients;
    }

    public void setDiagnosedPatients(Set<Patient> diagnosedPatients) {
        this.diagnosedPatients = diagnosedPatients;
    }
}
