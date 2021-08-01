import connection.Connector;

import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;
import java.util.List;

public class t_07_PrintAllMinionNames extends Connector {
    public static void main(String[] args) throws SQLException {
        PreparedStatement statement =
                connection.prepareStatement("SELECT `name`\n" +
                        "FROM minions;");

        var res = statement.executeQuery();
        List<String> minionsList = new ArrayList<>();

        while (res.next()) {
            minionsList.add(res.getString("name"));
        }

        Deque<String> minions = new ArrayDeque<>(minionsList);
        int minionsIndex = 0;
        while (!minions.isEmpty()) {
            if (minionsIndex % 2 == 0) {
                System.out.println(minions.pollFirst());
            } else {
                System.out.println(minions.pollLast());
            }
            minionsIndex++;
        }
    }
}
