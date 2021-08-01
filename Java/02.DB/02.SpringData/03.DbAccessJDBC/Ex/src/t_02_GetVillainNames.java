import connection.Connector;

import java.sql.PreparedStatement;
import java.sql.SQLException;

public class t_02_GetVillainNames extends Connector {
    public static void main(String[] args) throws SQLException {
        PreparedStatement statement =
                connection.prepareStatement("SELECT v.name,\n" +
                        "COUNT(DISTINCT mv.minion_id) AS minions_count\n" +
                        "FROM villains AS v\n" +
                        "JOIN minions_villains AS mv\n" +
                        "ON mv.villain_id = v.id\n" +
                        "GROUP BY v.name\n" +
                        "HAVING minions_count > 15\n" +
                        "ORDER BY minions_count DESC;");

        var res = statement.executeQuery();
        while (res.next()) {
            System.out.println(res.getString("name") + " " + res.getString("minions_count"));
        }
    }
}
