package t_08_family_tree;

import java.util.ArrayList;
import java.util.List;

public class FamilyMember {
    private String name;
    private String birthDay;

    private final List<FamilyMember> parents;
    private final List<FamilyMember> children;

    public FamilyMember() {
        parents = new ArrayList<>();
        children = new ArrayList<>();
    }

    public List<FamilyMember> getParents() {
        return parents;
    }

    public List<FamilyMember> getChildren() {
        return children;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setBirthDay(String birthDay) {
        this.birthDay = birthDay;
    }

    public void addChild(FamilyMember child) {
        children.add(child);
        child.addParent(this);
    }

    public void addMultipleParents(List<FamilyMember> parentsToAdd){
        parents.addAll(parentsToAdd);
    }

    public void addMultipleChildren(List<FamilyMember> childrenToAdd){
        children.addAll(childrenToAdd);
    }

    private void addParent(FamilyMember parent) {
        parents.add(parent);
    }

    @Override
    public String toString() {
        return String.format("%s %s", name, birthDay);
    }
}
