import connection.Connector;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class t_03_GetMinionNames extends Connector {
    public static void main(String[] args) throws SQLException, IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Please enter villain id: ");
        int villainId = Integer.parseInt(reader.readLine());

        PreparedStatement statement =
                connection.prepareStatement("SELECT v.name,\n" +
                        "m.`name` AS minion_name,\n" +
                        "m.age\n" +
                        "FROM villains AS v\n" +
                        "JOIN minions_villains AS mv\n" +
                        "ON mv.villain_id = v.id\n" +
                        "JOIN minions AS m\n" +
                        "ON m.id = mv.minion_id\n" +
                        "WHERE v.id = ?;");
        statement.setInt(1, villainId);

        var res = statement.executeQuery();

        int minionCounter = 1;
        StringBuilder sb = new StringBuilder(80);

        while (res.next()) {
            if (minionCounter <= 1) {
                sb.append("Villain: ").append(res.getString("name")).append(System.lineSeparator());
            }
            sb.append(minionCounter).append(". ").append(res.getString("minion_name"))
                    .append(" ").append(res.getString("age")).append(System.lineSeparator());
            minionCounter++;
        }

        if (minionCounter == 1) {
            System.out.println("No villain with ID " + villainId + " exists in the database.");
        } else {
            System.out.println(sb.toString());
        }
    }
}
