package t_08_family_tree;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedHashMap;
import java.util.Map;

public class Main {
    private static final BufferedReader reader;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        Map<String, FamilyMember> byName = new LinkedHashMap<>();
        Map<String, FamilyMember> byDate = new LinkedHashMap<>();

        String targetInfo = reader.readLine();

        String command;
        String[] tokens;
        String leftData;
        String rightData;
        int lastSpaceIndex;
        FamilyMember currMemberName;
        FamilyMember currMemberDate;
        FamilyMember parent;
        FamilyMember child;
        while(!(command = reader.readLine()).equals("End")) {
            if (command.contains("-")) {
                tokens = command.split(" - ");

                leftData = tokens[0];
                rightData = tokens[1];

                parent = byName.containsKey(leftData) ? byName.get(leftData) : byDate.get(leftData);
                child = byName.containsKey(rightData) ? byName.get(rightData) : byDate.get(rightData);

                if (parent == null) {
                    parent = new FamilyMember();

                    if (leftData.contains("/")){
                        parent.setBirthDay(leftData);
                        byDate.put(leftData, parent);
                    } else {
                        parent.setName(leftData);
                        byName.put(leftData, parent);
                    }
                }
                if (child == null) {
                    child = new FamilyMember();

                    if (rightData.contains("/")){
                        child.setBirthDay(rightData);
                        byDate.put(rightData, child);
                    } else {
                        child.setName(rightData);
                        byName.put(rightData, child);
                    }
                }

                parent.addChild(child);
            } else {
                lastSpaceIndex = command.lastIndexOf(" ");

                leftData = command.substring(0, lastSpaceIndex);
                rightData = command.substring(lastSpaceIndex + 1);

                currMemberName = byName.get(leftData);
                currMemberDate = byDate.get(rightData);

                if (currMemberName != null && currMemberDate != null) {
                    currMemberName.addMultipleParents(currMemberDate.getParents());
                    currMemberName.addMultipleChildren(currMemberDate.getChildren());
                } else if (currMemberName == null && currMemberDate != null) {
                    currMemberName = currMemberDate;
                } else if (currMemberName == null) {
                    currMemberName = new FamilyMember();
                }

                if (currMemberDate == null) {
                    currMemberDate = currMemberName;
                }

                currMemberName.setName(leftData);
                currMemberName.setBirthDay(rightData);
                currMemberDate.setName(leftData);
                currMemberDate.setBirthDay(rightData);

                byName.put(leftData, currMemberName);
                byDate.put(rightData, currMemberName);
            }
        }

        FamilyMember member = byName.containsKey(targetInfo) ? byName.get(targetInfo) : byDate.get(targetInfo);

        System.out.println(member.toString());

        System.out.println("Parents:");
        for (FamilyMember currParent: member.getParents()) {
            System.out.println(currParent.toString());
        }

        System.out.println("Children:");
        for (FamilyMember currChild: member.getChildren()) {
            System.out.println(currChild.toString());
        }
    }
}
