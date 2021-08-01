import connection.Connector;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Arrays;

public class t_08_IncreaseMinionsAge extends Connector {
    public static void main(String[] args) throws SQLException, IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int[] minionIds = Arrays
                .stream(reader.readLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        StringBuilder sb = new StringBuilder(40);
        sb.append("UPDATE minions").append(System.lineSeparator());
        sb.append("SET `name` = LOWER(`name`), age = age + 1").append(System.lineSeparator());
        sb.append("WHERE id IN(");

        int minionIdsLen = minionIds.length;
        for (int i = 0; i < minionIdsLen; i++) {
            sb.append("?");

            if (i < minionIdsLen - 1) {
                sb.append(",");
            }
        }
        sb.append(");");
        PreparedStatement updateMinionsStatement =
                connection.prepareStatement(sb.toString());

        for (int i = 0; i < minionIdsLen; i++) {
            updateMinionsStatement.setInt(i + 1, minionIds[i]);
        }
        updateMinionsStatement.executeUpdate();

        PreparedStatement getMinionsStatement =
                connection.prepareStatement("SELECT `name`,\n" +
                        "age\n" +
                        "FROM minions;");

        var minionsRes = getMinionsStatement.executeQuery();

        while (minionsRes.next()) {
            System.out.println(minionsRes.getString("name") + " " +
                    minionsRes.getInt("age"));
        }
    }
}
